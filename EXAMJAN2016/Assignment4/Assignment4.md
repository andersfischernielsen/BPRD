# Opgave 4

### Opgave 4.1
I ```CLex.fsl``` er følgende pattern match tilføjet:

	rule Token = parse
	  ...
	  | ".=="           { DOTEQ }
	  | ".!="           { DOTNE }
	  | ".>"            { DOTGT }
	  | ".<"            { DOTLT }
	  | ".>="           { DOTGE }
	  | ".<="           { DOTLE }
	  
I ```CPar.fsy``` er følgende tilføjet:

	ExprNotAccess:
	  ...
	  | IntervalCheck   { $1    }
	  
	IntervalCheck:
	    Expr PrimOp Expr PrimOp Expr { Andalso(Prim2($2, $1, $3), Prim2($4, $3, $5)) }
	  | Expr PrimOp Expr PrimOp Expr { Andalso(Prim2($2, $1, $3), Prim2($4, $3, $5)) }
	  | Expr PrimOp Expr PrimOp Expr { Andalso(Prim2($2, $1, $3), Prim2($4, $3, $5)) }
	  | Expr PrimOp Expr PrimOp Expr { Andalso(Prim2($2, $1, $3), Prim2($4, $3, $5)) }
	  | Expr PrimOp Expr PrimOp Expr { Andalso(Prim2($2, $1, $3), Prim2($4, $3, $5)) }
	  | Expr PrimOp Expr PrimOp Expr { Andalso(Prim2($2, $1, $3), Prim2($4, $3, $5)) }
	
	PrimOp:
	    DOTEQ                               { "=="                }
	  | DOTNE                               { "!="                }
	  | DOTGT                               { ">"                 }
	  | DOTLT                               { "<"                 }
	  | DOTGE                               { ">="                }
	  | DOTLE                               { "<="                }

Interval-checks bliver lavet til passende tokens i ```CLex.fsl```. 

I ```CPar.fsy``` er typen ```IntervalCheck``` tilføjet, der tjekker hvorvidt et interval check er til stede. 

```PrimOp```-typen er introduceret for at kunne anvende denne direkte i ```IntervalCheck```'s ```Andalso```-returværdi. Der returneres derfor blot en tekststreng, der angiver ```Prim2```-operatoren. 

Implementationen tillader derfor ikke en uendelig række af interval check, men kræver at disse er i par af to ```PrimOp``` med tre ```Expr``` imellem (dog tillades _nestede_ interval check).

### Opgave 4.2
	void main() {
		print -200 .< 2400 .> 3;
		print 2+2 .< 2/2 .== 1;
		print (1 .== 1 .== 2-1) .== 1 .<= 3;
		print (2 .== 2 .== 2) .<= 3 .!= 1;
		print -2 .!= 2 .>= 0;
	}

Ovenstående tests giver resultatet

	1 0 1 1 1
	
der er som forventet. 
Det, at bolske værdier oversættes til integers, er synligt i eksempel tre og fire, hvor den bolske værdi ```true``` sammenlignes med tallet 1. 

```Expr``` (som f.eks. ```2+2```) oversættes også korrekt inden interval check, som det ses i eksempel to  og tre.

Hvis bare én af the to interval check er ```false```er hele udtrykket også ```false```, som det ses i eksempel 2. 

Resultaterne er derfor som forventet.