# Opgave 3

### Opgave 3.1
I ```Absyn.fs``` er følgende tilføjet:

	and expr =
	  ...
	  | CstS of string
	  ...

I ```CPar.fsy``` er følgende tilføjet:

	AtExprNotAccess:
	    ...
	  | CSTSTRING        { CstS $1 }
	  
I ```Machine.fs``` er følgende tilføjet:

	type instr =
	  ...	  
	  | CSTS of string

-
    ...
    let CODESETCDR = 31;
    let CODECSTS   = 32;

-

	let makelabenv (addr, labenv) instr =
	    match instr with
	    ...
	    | CSTS s         -> (addr+s.Length+2, labenv)

-

	let rec emitints getlab instr ints =
	    match instr with
	    ...
	    | CSTS s -> CODECSTS :: (String.length s) :: ((explode s) @ ints)
	    
I ```Comp.fs``` er følgende tilføjet:

	and cExpr (e : expr) (varEnv : varEnv) (funEnv : funEnv) : instr list =
	    match e with
	    ...
	    | CstS s         -> [CSTS s]
	    ...
	    
I ```listmachine.c``` er følgende tilføjet: 

	#define CONSTAG 0
	#define STRINGTAG 1
	
-

	#define SETCDR 31
	#define CSTS 32
	
-

	int execcode(int p[], int s[], int iargs[], int iargc, int /* boolean */ trace) {
	  ...
	    switch (p[pc++]) {
	    ...
	    case CSTS: {
	      int lenStr = p[pc++];
	      int sizeStr = lenStr + 1; // Extra for zero terminating string, \0.
	      int sizeW = (sizeStr % 4 == 0)?sizeStr/4:(sizeStr/4)+1; // 4 chars per word
	      sizeW = sizeW + 1; // Extra for string length.
	      word* strPtr = allocate(STRINGTAG, sizeW, s, sp);
	      s[++sp] = (int)strPtr;
	      strPtr[1] = lenStr;
	      char* toPtr = (char*)(strPtr+2);
	      for (int i=0; i<lenStr; i++)
	        toPtr[i] = (char) p[pc++];
	        toPtr[lenStr] = '\0'; // Zero terminate string!
	        printf ("The string \"%s\" has now been allocated.\n", toPtr); /* Debug */
	      } break;
	    ...
	    
Keywords for konstante strenge er tilføjet til lexer og parser, således at disse kan repræsenteres i det abstrakte syntaks-træ. 
Når labels skal oprettes i ```Machine.fs``` gøres der plads til strengen ved at lægge den givne strengs længde + 2 til den nuværende adresse. Dette gøres, da der også skal være plads til strengens _header_ plus ```lenStr``` inden strenges indhold. 
Herefter lægges strengens indhold ind ved at konvertere hver karaktér til en ```int```.

Under eksekvering af den generede bytecode, når instruktionen for ```CSTS``` læses, læses næste program-instruktion fra ```p[]```, hvor strengens længde findes. Der allokeres herefter plads til strengen, og strengens længde og karaktererer skrives til ```p[]```. Strengens adresse skrives til sidst ind på stakken.


### Opgave 3.2 
Af den genererede abstrakte syntax
	
	Prog
	  [Fundec
	     (null,"main",[],
	      Block
	        [Dec (TypD,"s1"); Dec (TypD,"s2");
	         Stmt (Expr (Assign (AccVar "s1",CstS "Hi there")));
	         Stmt (Expr (Assign (AccVar "s2",CstS "Hi there again")))])]

ses det, at der erklæres to dynamiske variable (```TypD```), kaldet ```s1``` og ```s2```, der herefter tildeles hver sin ```CstS``` vha. ```Assign``` og ```AccVar```. Disser tilgår ti sammen variablerne og assigner strengene til dem. 

Alt dette sker i den deklarerede funktion ```"main"``` (erklæret vha. ```Fundec```), hvor deklarationen af ```s1```og ```s2``` efterfølges af to statements (```Stmt```), der indeholder tildelings-syntaksen beskrevet ovenfor. 

-

Med programmet fra opgaven printes

	The string "Hi there" has now been allocated.
	The string "Hi there again" has now been allocated.
	
	Used   0.000 cpu seconds
	
ved kørsel af ```.out```-filen med ```listmachine```.
 
Ved at debugge ```listmachine.c``` ses det, at længden af strengen, samt mængden af ord der skal allokeres i hoben, er korrekt. 

	(lldb)
	Process 6659 stopped
	...
	   219 	      int lenStr = p[pc++];
	   220 	      int sizeStr = lenStr + 1; // Extra for zero terminating string, \0.
	   221 	      int sizeW = (sizeStr % 4 == 0)?sizeStr/4:(sizeStr/4)+1; 
	-> 222 	      sizeW = sizeW + 1; // Extra for string length.
	   223 	      word* strPtr = allocate(STRINGTAG, sizeW, s, sp);
	(lldb) p sizeW
	(int) $12 = 3
	...
	(lldb) p p[pc-1] // = lenStr. p[pc-1] da koden lægger én til pc inden.
	(int) $15 = 8
	(lldb) p (char) p[pc]
	(char) $16 = 'H' //Ønsket indhold
	(lldb) p (char) p[pc+1]
	(char) $17 = 'i'

Det ser hermed ud til, at strengen er gemt korrekt i hoben. 

Analyse af de genererede bytecode-instruktioner for programmet giver også tiltro til, at programmet er korrekt. 

	LDARGS; 
	CALL (0,"L1");         //Gå til første funktion, main().
	STOP; 
	
	Label "L1";            //main() funktion
	NIL;                   //Opret NIL variable
	NIL;                   //Opret NIL variable
	GETBP; 
	CSTI 0; 
	ADD;                   //Placering af første variabel (på BP+0)
	CSTS "Hi there";       //Opret streng
	STI;                   //Gem i første variabel 
	INCSP -1;
	GETBP; 
	CSTI 1; 
	ADD;                   //Placering af anden variabel (på BP+1)
	CSTS "Hi there again"; //Samme som ovenfor, bare anden streng
	STI;                   //Gem streng i anden variabel
	INCSP -1; 
	INCSP -2;              //Smid alt væk (intet returneres)
	RET -1
	