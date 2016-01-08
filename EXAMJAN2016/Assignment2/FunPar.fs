// Implementation file for parser generated by fsyacc
module FunPar
#nowarn "64";; // turn off warnings that type variables used in production annotations are instantiated to concrete type
open Microsoft.FSharp.Text.Lexing
open Microsoft.FSharp.Text.Parsing.ParseHelpers
# 1 "FunPar.fsy"

 (* File Fun/FunPar.fsy
    Parser for micro-ML, a small functional language; one-argument functions.
    sestoft@itu.dk * 2009-10-19
  *)

 open Absyn;

# 15 "FunPar.fs"
// This type is the type of tokens accepted by the parser
type token = 
  | EOF
  | LPAR
  | RPAR
  | EQ
  | NE
  | GT
  | LT
  | GE
  | LE
  | DEREF
  | ASSIGN
  | PLUS
  | MINUS
  | TIMES
  | DIV
  | MOD
  | ELSE
  | END
  | FALSE
  | IF
  | IN
  | LET
  | NOT
  | THEN
  | TRUE
  | REF
  | CSTBOOL of (bool)
  | NAME of (string)
  | CSTINT of (int)
// This type is used to give symbolic names to token indexes, useful for error messages
type tokenId = 
    | TOKEN_EOF
    | TOKEN_LPAR
    | TOKEN_RPAR
    | TOKEN_EQ
    | TOKEN_NE
    | TOKEN_GT
    | TOKEN_LT
    | TOKEN_GE
    | TOKEN_LE
    | TOKEN_DEREF
    | TOKEN_ASSIGN
    | TOKEN_PLUS
    | TOKEN_MINUS
    | TOKEN_TIMES
    | TOKEN_DIV
    | TOKEN_MOD
    | TOKEN_ELSE
    | TOKEN_END
    | TOKEN_FALSE
    | TOKEN_IF
    | TOKEN_IN
    | TOKEN_LET
    | TOKEN_NOT
    | TOKEN_THEN
    | TOKEN_TRUE
    | TOKEN_REF
    | TOKEN_CSTBOOL
    | TOKEN_NAME
    | TOKEN_CSTINT
    | TOKEN_end_of_input
    | TOKEN_error
// This type is used to give symbolic names to token indexes, useful for error messages
type nonTerminalId = 
    | NONTERM__startMain
    | NONTERM_Main
    | NONTERM_Expr
    | NONTERM_AtExpr
    | NONTERM_AppExpr
    | NONTERM_Const

// This function maps tokens to integers indexes
let tagOfToken (t:token) = 
  match t with
  | EOF  -> 0 
  | LPAR  -> 1 
  | RPAR  -> 2 
  | EQ  -> 3 
  | NE  -> 4 
  | GT  -> 5 
  | LT  -> 6 
  | GE  -> 7 
  | LE  -> 8 
  | DEREF  -> 9 
  | ASSIGN  -> 10 
  | PLUS  -> 11 
  | MINUS  -> 12 
  | TIMES  -> 13 
  | DIV  -> 14 
  | MOD  -> 15 
  | ELSE  -> 16 
  | END  -> 17 
  | FALSE  -> 18 
  | IF  -> 19 
  | IN  -> 20 
  | LET  -> 21 
  | NOT  -> 22 
  | THEN  -> 23 
  | TRUE  -> 24 
  | REF  -> 25 
  | CSTBOOL _ -> 26 
  | NAME _ -> 27 
  | CSTINT _ -> 28 

// This function maps integers indexes to symbolic token ids
let tokenTagToTokenId (tokenIdx:int) = 
  match tokenIdx with
  | 0 -> TOKEN_EOF 
  | 1 -> TOKEN_LPAR 
  | 2 -> TOKEN_RPAR 
  | 3 -> TOKEN_EQ 
  | 4 -> TOKEN_NE 
  | 5 -> TOKEN_GT 
  | 6 -> TOKEN_LT 
  | 7 -> TOKEN_GE 
  | 8 -> TOKEN_LE 
  | 9 -> TOKEN_DEREF 
  | 10 -> TOKEN_ASSIGN 
  | 11 -> TOKEN_PLUS 
  | 12 -> TOKEN_MINUS 
  | 13 -> TOKEN_TIMES 
  | 14 -> TOKEN_DIV 
  | 15 -> TOKEN_MOD 
  | 16 -> TOKEN_ELSE 
  | 17 -> TOKEN_END 
  | 18 -> TOKEN_FALSE 
  | 19 -> TOKEN_IF 
  | 20 -> TOKEN_IN 
  | 21 -> TOKEN_LET 
  | 22 -> TOKEN_NOT 
  | 23 -> TOKEN_THEN 
  | 24 -> TOKEN_TRUE 
  | 25 -> TOKEN_REF 
  | 26 -> TOKEN_CSTBOOL 
  | 27 -> TOKEN_NAME 
  | 28 -> TOKEN_CSTINT 
  | 31 -> TOKEN_end_of_input
  | 29 -> TOKEN_error
  | _ -> failwith "tokenTagToTokenId: bad token"

/// This function maps production indexes returned in syntax errors to strings representing the non terminal that would be produced by that production
let prodIdxToNonTerminal (prodIdx:int) = 
  match prodIdx with
    | 0 -> NONTERM__startMain 
    | 1 -> NONTERM_Main 
    | 2 -> NONTERM_Expr 
    | 3 -> NONTERM_Expr 
    | 4 -> NONTERM_Expr 
    | 5 -> NONTERM_Expr 
    | 6 -> NONTERM_Expr 
    | 7 -> NONTERM_Expr 
    | 8 -> NONTERM_Expr 
    | 9 -> NONTERM_Expr 
    | 10 -> NONTERM_Expr 
    | 11 -> NONTERM_Expr 
    | 12 -> NONTERM_Expr 
    | 13 -> NONTERM_Expr 
    | 14 -> NONTERM_Expr 
    | 15 -> NONTERM_Expr 
    | 16 -> NONTERM_Expr 
    | 17 -> NONTERM_Expr 
    | 18 -> NONTERM_Expr 
    | 19 -> NONTERM_AtExpr 
    | 20 -> NONTERM_AtExpr 
    | 21 -> NONTERM_AtExpr 
    | 22 -> NONTERM_AtExpr 
    | 23 -> NONTERM_AtExpr 
    | 24 -> NONTERM_AtExpr 
    | 25 -> NONTERM_AppExpr 
    | 26 -> NONTERM_AppExpr 
    | 27 -> NONTERM_Const 
    | 28 -> NONTERM_Const 
    | _ -> failwith "prodIdxToNonTerminal: bad production index"

let _fsyacc_endOfInputTag = 31 
let _fsyacc_tagOfErrorTerminal = 29

// This function gets the name of a token as a string
let token_to_string (t:token) = 
  match t with 
  | EOF  -> "EOF" 
  | LPAR  -> "LPAR" 
  | RPAR  -> "RPAR" 
  | EQ  -> "EQ" 
  | NE  -> "NE" 
  | GT  -> "GT" 
  | LT  -> "LT" 
  | GE  -> "GE" 
  | LE  -> "LE" 
  | DEREF  -> "DEREF" 
  | ASSIGN  -> "ASSIGN" 
  | PLUS  -> "PLUS" 
  | MINUS  -> "MINUS" 
  | TIMES  -> "TIMES" 
  | DIV  -> "DIV" 
  | MOD  -> "MOD" 
  | ELSE  -> "ELSE" 
  | END  -> "END" 
  | FALSE  -> "FALSE" 
  | IF  -> "IF" 
  | IN  -> "IN" 
  | LET  -> "LET" 
  | NOT  -> "NOT" 
  | THEN  -> "THEN" 
  | TRUE  -> "TRUE" 
  | REF  -> "REF" 
  | CSTBOOL _ -> "CSTBOOL" 
  | NAME _ -> "NAME" 
  | CSTINT _ -> "CSTINT" 

// This function gets the data carried by a token as an object
let _fsyacc_dataOfToken (t:token) = 
  match t with 
  | EOF  -> (null : System.Object) 
  | LPAR  -> (null : System.Object) 
  | RPAR  -> (null : System.Object) 
  | EQ  -> (null : System.Object) 
  | NE  -> (null : System.Object) 
  | GT  -> (null : System.Object) 
  | LT  -> (null : System.Object) 
  | GE  -> (null : System.Object) 
  | LE  -> (null : System.Object) 
  | DEREF  -> (null : System.Object) 
  | ASSIGN  -> (null : System.Object) 
  | PLUS  -> (null : System.Object) 
  | MINUS  -> (null : System.Object) 
  | TIMES  -> (null : System.Object) 
  | DIV  -> (null : System.Object) 
  | MOD  -> (null : System.Object) 
  | ELSE  -> (null : System.Object) 
  | END  -> (null : System.Object) 
  | FALSE  -> (null : System.Object) 
  | IF  -> (null : System.Object) 
  | IN  -> (null : System.Object) 
  | LET  -> (null : System.Object) 
  | NOT  -> (null : System.Object) 
  | THEN  -> (null : System.Object) 
  | TRUE  -> (null : System.Object) 
  | REF  -> (null : System.Object) 
  | CSTBOOL _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | NAME _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | CSTINT _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
let _fsyacc_gotos = [| 0us; 65535us; 1us; 65535us; 0us; 1us; 24us; 65535us; 0us; 2us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 34us; 16us; 35us; 17us; 36us; 18us; 37us; 19us; 38us; 20us; 39us; 21us; 40us; 22us; 41us; 23us; 42us; 24us; 43us; 25us; 44us; 26us; 45us; 27us; 50us; 28us; 51us; 29us; 54us; 30us; 55us; 31us; 57us; 32us; 59us; 33us; 26us; 65535us; 0us; 4us; 4us; 60us; 5us; 61us; 6us; 4us; 8us; 4us; 10us; 4us; 12us; 4us; 14us; 4us; 34us; 4us; 35us; 4us; 36us; 4us; 37us; 4us; 38us; 4us; 39us; 4us; 40us; 4us; 41us; 4us; 42us; 4us; 43us; 4us; 44us; 4us; 45us; 4us; 50us; 4us; 51us; 4us; 54us; 4us; 55us; 4us; 57us; 4us; 59us; 4us; 24us; 65535us; 0us; 5us; 6us; 5us; 8us; 5us; 10us; 5us; 12us; 5us; 14us; 5us; 34us; 5us; 35us; 5us; 36us; 5us; 37us; 5us; 38us; 5us; 39us; 5us; 40us; 5us; 41us; 5us; 42us; 5us; 43us; 5us; 44us; 5us; 45us; 5us; 50us; 5us; 51us; 5us; 54us; 5us; 55us; 5us; 57us; 5us; 59us; 5us; 26us; 65535us; 0us; 46us; 4us; 46us; 5us; 46us; 6us; 46us; 8us; 46us; 10us; 46us; 12us; 46us; 14us; 46us; 34us; 46us; 35us; 46us; 36us; 46us; 37us; 46us; 38us; 46us; 39us; 46us; 40us; 46us; 41us; 46us; 42us; 46us; 43us; 46us; 44us; 46us; 45us; 46us; 50us; 46us; 51us; 46us; 54us; 46us; 55us; 46us; 57us; 46us; 59us; 46us; |]
let _fsyacc_sparseGotoTableRowOffsets = [|0us; 1us; 3us; 28us; 55us; 80us; |]
let _fsyacc_stateToProdIdxsTableElements = [| 1us; 0us; 1us; 0us; 13us; 1us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 1us; 1us; 2us; 2us; 25us; 2us; 3us; 26us; 1us; 4us; 13us; 4us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 1us; 4us; 13us; 4us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 1us; 4us; 13us; 4us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 1us; 5us; 13us; 5us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 1us; 6us; 13us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 13us; 7us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 13us; 7us; 8us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 13us; 7us; 8us; 9us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 13us; 7us; 8us; 9us; 10us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 13us; 7us; 8us; 9us; 10us; 11us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 13us; 7us; 8us; 9us; 10us; 11us; 12us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 13us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 13us; 14us; 15us; 16us; 17us; 18us; 13us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 14us; 15us; 16us; 17us; 18us; 13us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 15us; 16us; 17us; 18us; 13us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 16us; 17us; 18us; 13us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 17us; 18us; 13us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 18us; 13us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 21us; 13us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 21us; 13us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 22us; 13us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 22us; 13us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 23us; 13us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 24us; 1us; 7us; 1us; 8us; 1us; 9us; 1us; 10us; 1us; 11us; 1us; 12us; 1us; 13us; 1us; 14us; 1us; 15us; 1us; 16us; 1us; 17us; 1us; 18us; 1us; 19us; 1us; 20us; 2us; 21us; 22us; 2us; 21us; 22us; 1us; 21us; 1us; 21us; 1us; 21us; 1us; 22us; 1us; 22us; 1us; 22us; 1us; 22us; 1us; 23us; 1us; 23us; 1us; 24us; 1us; 25us; 1us; 26us; 1us; 27us; 1us; 28us; |]
let _fsyacc_stateToProdIdxsTableRowOffsets = [|0us; 2us; 4us; 18us; 20us; 23us; 26us; 28us; 42us; 44us; 58us; 60us; 74us; 76us; 90us; 92us; 106us; 120us; 134us; 148us; 162us; 176us; 190us; 204us; 218us; 232us; 246us; 260us; 274us; 288us; 302us; 316us; 330us; 344us; 358us; 360us; 362us; 364us; 366us; 368us; 370us; 372us; 374us; 376us; 378us; 380us; 382us; 384us; 386us; 389us; 392us; 394us; 396us; 398us; 400us; 402us; 404us; 406us; 408us; 410us; 412us; 414us; 416us; 418us; |]
let _fsyacc_action_rows = 64
let _fsyacc_actionTableElements = [|9us; 32768us; 1us; 57us; 9us; 14us; 12us; 12us; 19us; 6us; 21us; 48us; 25us; 59us; 26us; 63us; 27us; 47us; 28us; 62us; 0us; 49152us; 13us; 32768us; 0us; 3us; 3us; 39us; 4us; 40us; 5us; 41us; 6us; 42us; 7us; 43us; 8us; 44us; 10us; 45us; 11us; 34us; 12us; 35us; 13us; 36us; 14us; 37us; 15us; 38us; 0us; 16385us; 6us; 16386us; 1us; 57us; 21us; 48us; 25us; 59us; 26us; 63us; 27us; 47us; 28us; 62us; 6us; 16387us; 1us; 57us; 21us; 48us; 25us; 59us; 26us; 63us; 27us; 47us; 28us; 62us; 9us; 32768us; 1us; 57us; 9us; 14us; 12us; 12us; 19us; 6us; 21us; 48us; 25us; 59us; 26us; 63us; 27us; 47us; 28us; 62us; 13us; 32768us; 3us; 39us; 4us; 40us; 5us; 41us; 6us; 42us; 7us; 43us; 8us; 44us; 10us; 45us; 11us; 34us; 12us; 35us; 13us; 36us; 14us; 37us; 15us; 38us; 23us; 8us; 9us; 32768us; 1us; 57us; 9us; 14us; 12us; 12us; 19us; 6us; 21us; 48us; 25us; 59us; 26us; 63us; 27us; 47us; 28us; 62us; 13us; 32768us; 3us; 39us; 4us; 40us; 5us; 41us; 6us; 42us; 7us; 43us; 8us; 44us; 10us; 45us; 11us; 34us; 12us; 35us; 13us; 36us; 14us; 37us; 15us; 38us; 16us; 10us; 9us; 32768us; 1us; 57us; 9us; 14us; 12us; 12us; 19us; 6us; 21us; 48us; 25us; 59us; 26us; 63us; 27us; 47us; 28us; 62us; 12us; 16388us; 3us; 39us; 4us; 40us; 5us; 41us; 6us; 42us; 7us; 43us; 8us; 44us; 10us; 45us; 11us; 34us; 12us; 35us; 13us; 36us; 14us; 37us; 15us; 38us; 9us; 32768us; 1us; 57us; 9us; 14us; 12us; 12us; 19us; 6us; 21us; 48us; 25us; 59us; 26us; 63us; 27us; 47us; 28us; 62us; 4us; 16389us; 10us; 45us; 13us; 36us; 14us; 37us; 15us; 38us; 9us; 32768us; 1us; 57us; 9us; 14us; 12us; 12us; 19us; 6us; 21us; 48us; 25us; 59us; 26us; 63us; 27us; 47us; 28us; 62us; 10us; 16390us; 5us; 41us; 6us; 42us; 7us; 43us; 8us; 44us; 10us; 45us; 11us; 34us; 12us; 35us; 13us; 36us; 14us; 37us; 15us; 38us; 4us; 16391us; 10us; 45us; 13us; 36us; 14us; 37us; 15us; 38us; 4us; 16392us; 10us; 45us; 13us; 36us; 14us; 37us; 15us; 38us; 1us; 16393us; 10us; 45us; 1us; 16394us; 10us; 45us; 1us; 16395us; 10us; 45us; 10us; 16396us; 5us; 41us; 6us; 42us; 7us; 43us; 8us; 44us; 10us; 45us; 11us; 34us; 12us; 35us; 13us; 36us; 14us; 37us; 15us; 38us; 10us; 16397us; 5us; 41us; 6us; 42us; 7us; 43us; 8us; 44us; 10us; 45us; 11us; 34us; 12us; 35us; 13us; 36us; 14us; 37us; 15us; 38us; 10us; 16398us; 5us; 41us; 6us; 42us; 7us; 43us; 8us; 44us; 10us; 45us; 11us; 34us; 12us; 35us; 13us; 36us; 14us; 37us; 15us; 38us; 10us; 16399us; 5us; 41us; 6us; 42us; 7us; 43us; 8us; 44us; 10us; 45us; 11us; 34us; 12us; 35us; 13us; 36us; 14us; 37us; 15us; 38us; 10us; 16400us; 5us; 41us; 6us; 42us; 7us; 43us; 8us; 44us; 10us; 45us; 11us; 34us; 12us; 35us; 13us; 36us; 14us; 37us; 15us; 38us; 10us; 16401us; 5us; 41us; 6us; 42us; 7us; 43us; 8us; 44us; 10us; 45us; 11us; 34us; 12us; 35us; 13us; 36us; 14us; 37us; 15us; 38us; 1us; 16402us; 10us; 45us; 13us; 32768us; 3us; 39us; 4us; 40us; 5us; 41us; 6us; 42us; 7us; 43us; 8us; 44us; 10us; 45us; 11us; 34us; 12us; 35us; 13us; 36us; 14us; 37us; 15us; 38us; 20us; 51us; 13us; 32768us; 3us; 39us; 4us; 40us; 5us; 41us; 6us; 42us; 7us; 43us; 8us; 44us; 10us; 45us; 11us; 34us; 12us; 35us; 13us; 36us; 14us; 37us; 15us; 38us; 17us; 52us; 13us; 32768us; 3us; 39us; 4us; 40us; 5us; 41us; 6us; 42us; 7us; 43us; 8us; 44us; 10us; 45us; 11us; 34us; 12us; 35us; 13us; 36us; 14us; 37us; 15us; 38us; 20us; 55us; 13us; 32768us; 3us; 39us; 4us; 40us; 5us; 41us; 6us; 42us; 7us; 43us; 8us; 44us; 10us; 45us; 11us; 34us; 12us; 35us; 13us; 36us; 14us; 37us; 15us; 38us; 17us; 56us; 13us; 32768us; 2us; 58us; 3us; 39us; 4us; 40us; 5us; 41us; 6us; 42us; 7us; 43us; 8us; 44us; 10us; 45us; 11us; 34us; 12us; 35us; 13us; 36us; 14us; 37us; 15us; 38us; 10us; 16408us; 5us; 41us; 6us; 42us; 7us; 43us; 8us; 44us; 10us; 45us; 11us; 34us; 12us; 35us; 13us; 36us; 14us; 37us; 15us; 38us; 9us; 32768us; 1us; 57us; 9us; 14us; 12us; 12us; 19us; 6us; 21us; 48us; 25us; 59us; 26us; 63us; 27us; 47us; 28us; 62us; 9us; 32768us; 1us; 57us; 9us; 14us; 12us; 12us; 19us; 6us; 21us; 48us; 25us; 59us; 26us; 63us; 27us; 47us; 28us; 62us; 9us; 32768us; 1us; 57us; 9us; 14us; 12us; 12us; 19us; 6us; 21us; 48us; 25us; 59us; 26us; 63us; 27us; 47us; 28us; 62us; 9us; 32768us; 1us; 57us; 9us; 14us; 12us; 12us; 19us; 6us; 21us; 48us; 25us; 59us; 26us; 63us; 27us; 47us; 28us; 62us; 9us; 32768us; 1us; 57us; 9us; 14us; 12us; 12us; 19us; 6us; 21us; 48us; 25us; 59us; 26us; 63us; 27us; 47us; 28us; 62us; 9us; 32768us; 1us; 57us; 9us; 14us; 12us; 12us; 19us; 6us; 21us; 48us; 25us; 59us; 26us; 63us; 27us; 47us; 28us; 62us; 9us; 32768us; 1us; 57us; 9us; 14us; 12us; 12us; 19us; 6us; 21us; 48us; 25us; 59us; 26us; 63us; 27us; 47us; 28us; 62us; 9us; 32768us; 1us; 57us; 9us; 14us; 12us; 12us; 19us; 6us; 21us; 48us; 25us; 59us; 26us; 63us; 27us; 47us; 28us; 62us; 9us; 32768us; 1us; 57us; 9us; 14us; 12us; 12us; 19us; 6us; 21us; 48us; 25us; 59us; 26us; 63us; 27us; 47us; 28us; 62us; 9us; 32768us; 1us; 57us; 9us; 14us; 12us; 12us; 19us; 6us; 21us; 48us; 25us; 59us; 26us; 63us; 27us; 47us; 28us; 62us; 9us; 32768us; 1us; 57us; 9us; 14us; 12us; 12us; 19us; 6us; 21us; 48us; 25us; 59us; 26us; 63us; 27us; 47us; 28us; 62us; 9us; 32768us; 1us; 57us; 9us; 14us; 12us; 12us; 19us; 6us; 21us; 48us; 25us; 59us; 26us; 63us; 27us; 47us; 28us; 62us; 0us; 16403us; 0us; 16404us; 1us; 32768us; 27us; 49us; 2us; 32768us; 3us; 50us; 27us; 53us; 9us; 32768us; 1us; 57us; 9us; 14us; 12us; 12us; 19us; 6us; 21us; 48us; 25us; 59us; 26us; 63us; 27us; 47us; 28us; 62us; 9us; 32768us; 1us; 57us; 9us; 14us; 12us; 12us; 19us; 6us; 21us; 48us; 25us; 59us; 26us; 63us; 27us; 47us; 28us; 62us; 0us; 16405us; 1us; 32768us; 3us; 54us; 9us; 32768us; 1us; 57us; 9us; 14us; 12us; 12us; 19us; 6us; 21us; 48us; 25us; 59us; 26us; 63us; 27us; 47us; 28us; 62us; 9us; 32768us; 1us; 57us; 9us; 14us; 12us; 12us; 19us; 6us; 21us; 48us; 25us; 59us; 26us; 63us; 27us; 47us; 28us; 62us; 0us; 16406us; 9us; 32768us; 1us; 57us; 9us; 14us; 12us; 12us; 19us; 6us; 21us; 48us; 25us; 59us; 26us; 63us; 27us; 47us; 28us; 62us; 0us; 16407us; 9us; 32768us; 1us; 57us; 9us; 14us; 12us; 12us; 19us; 6us; 21us; 48us; 25us; 59us; 26us; 63us; 27us; 47us; 28us; 62us; 0us; 16409us; 0us; 16410us; 0us; 16411us; 0us; 16412us; |]
let _fsyacc_actionTableRowOffsets = [|0us; 10us; 11us; 25us; 26us; 33us; 40us; 50us; 64us; 74us; 88us; 98us; 111us; 121us; 126us; 136us; 147us; 152us; 157us; 159us; 161us; 163us; 174us; 185us; 196us; 207us; 218us; 229us; 231us; 245us; 259us; 273us; 287us; 301us; 312us; 322us; 332us; 342us; 352us; 362us; 372us; 382us; 392us; 402us; 412us; 422us; 432us; 433us; 434us; 436us; 439us; 449us; 459us; 460us; 462us; 472us; 482us; 483us; 493us; 494us; 504us; 505us; 506us; 507us; |]
let _fsyacc_reductionSymbolCounts = [|1us; 2us; 1us; 1us; 6us; 2us; 2us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 1us; 1us; 7us; 8us; 3us; 2us; 2us; 2us; 1us; 1us; |]
let _fsyacc_productionToNonTerminalTable = [|0us; 1us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 3us; 3us; 3us; 3us; 3us; 3us; 4us; 4us; 5us; 5us; |]
let _fsyacc_immediateActions = [|65535us; 49152us; 65535us; 16385us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 16403us; 16404us; 65535us; 65535us; 65535us; 65535us; 16405us; 65535us; 65535us; 65535us; 16406us; 65535us; 16407us; 65535us; 16409us; 16410us; 16411us; 16412us; |]
let _fsyacc_reductions ()  =    [| 
# 271 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                      raise (Microsoft.FSharp.Text.Parsing.Accept(Microsoft.FSharp.Core.Operators.box _1))
                   )
                 : '_startMain));
# 280 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 37 "FunPar.fsy"
                                                               _1 
                   )
# 37 "FunPar.fsy"
                 : Absyn.expr));
# 291 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 41 "FunPar.fsy"
                                                               _1                     
                   )
# 41 "FunPar.fsy"
                 : Absyn.expr));
# 302 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 42 "FunPar.fsy"
                                                               _1                     
                   )
# 42 "FunPar.fsy"
                 : Absyn.expr));
# 313 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _4 = (let data = parseState.GetInput(4) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _6 = (let data = parseState.GetInput(6) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 43 "FunPar.fsy"
                                                               If(_2, _4, _6)         
                   )
# 43 "FunPar.fsy"
                 : Absyn.expr));
# 326 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 44 "FunPar.fsy"
                                                               Prim("-", CstI 0, _2)  
                   )
# 44 "FunPar.fsy"
                 : Absyn.expr));
# 337 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 45 "FunPar.fsy"
                                                               Deref(_2)              
                   )
# 45 "FunPar.fsy"
                 : Absyn.expr));
# 348 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 46 "FunPar.fsy"
                                                               Prim("+",  _1, _3)     
                   )
# 46 "FunPar.fsy"
                 : Absyn.expr));
# 360 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 47 "FunPar.fsy"
                                                               Prim("-",  _1, _3)     
                   )
# 47 "FunPar.fsy"
                 : Absyn.expr));
# 372 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 48 "FunPar.fsy"
                                                               Prim("*",  _1, _3)     
                   )
# 48 "FunPar.fsy"
                 : Absyn.expr));
# 384 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 49 "FunPar.fsy"
                                                               Prim("/",  _1, _3)     
                   )
# 49 "FunPar.fsy"
                 : Absyn.expr));
# 396 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 50 "FunPar.fsy"
                                                               Prim("%",  _1, _3)     
                   )
# 50 "FunPar.fsy"
                 : Absyn.expr));
# 408 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 51 "FunPar.fsy"
                                                               Prim("=",  _1, _3)     
                   )
# 51 "FunPar.fsy"
                 : Absyn.expr));
# 420 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 52 "FunPar.fsy"
                                                               Prim("<>", _1, _3)     
                   )
# 52 "FunPar.fsy"
                 : Absyn.expr));
# 432 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 53 "FunPar.fsy"
                                                               Prim(">",  _1, _3)     
                   )
# 53 "FunPar.fsy"
                 : Absyn.expr));
# 444 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 54 "FunPar.fsy"
                                                               Prim("<",  _1, _3)     
                   )
# 54 "FunPar.fsy"
                 : Absyn.expr));
# 456 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 55 "FunPar.fsy"
                                                               Prim(">=", _1, _3)     
                   )
# 55 "FunPar.fsy"
                 : Absyn.expr));
# 468 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 56 "FunPar.fsy"
                                                               Prim("<=", _1, _3)     
                   )
# 56 "FunPar.fsy"
                 : Absyn.expr));
# 480 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 57 "FunPar.fsy"
                                                               UpdRef(_1, _3)         
                   )
# 57 "FunPar.fsy"
                 : Absyn.expr));
# 492 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 61 "FunPar.fsy"
                                                               _1                     
                   )
# 61 "FunPar.fsy"
                 : Absyn.expr));
# 503 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 62 "FunPar.fsy"
                                                               Var _1                 
                   )
# 62 "FunPar.fsy"
                 : Absyn.expr));
# 514 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            let _4 = (let data = parseState.GetInput(4) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _6 = (let data = parseState.GetInput(6) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 63 "FunPar.fsy"
                                                               Let(_2, _4, _6)        
                   )
# 63 "FunPar.fsy"
                 : Absyn.expr));
# 527 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            let _5 = (let data = parseState.GetInput(5) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _7 = (let data = parseState.GetInput(7) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 64 "FunPar.fsy"
                                                               Letfun(_2, _3, _5, _7) 
                   )
# 64 "FunPar.fsy"
                 : Absyn.expr));
# 541 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 65 "FunPar.fsy"
                                                               _2                     
                   )
# 65 "FunPar.fsy"
                 : Absyn.expr));
# 552 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 66 "FunPar.fsy"
                                                               Ref _2                 
                   )
# 66 "FunPar.fsy"
                 : Absyn.expr));
# 563 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 70 "FunPar.fsy"
                                                               Call(_1, _2)           
                   )
# 70 "FunPar.fsy"
                 : Absyn.expr));
# 575 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 71 "FunPar.fsy"
                                                               Call(_1, _2)           
                   )
# 71 "FunPar.fsy"
                 : Absyn.expr));
# 587 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : int)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 75 "FunPar.fsy"
                                                               CstI(_1)               
                   )
# 75 "FunPar.fsy"
                 : Absyn.expr));
# 598 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : bool)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 76 "FunPar.fsy"
                                                               CstB(_1)               
                   )
# 76 "FunPar.fsy"
                 : Absyn.expr));
|]
# 610 "FunPar.fs"
let tables () : Microsoft.FSharp.Text.Parsing.Tables<_> = 
  { reductions= _fsyacc_reductions ();
    endOfInputTag = _fsyacc_endOfInputTag;
    tagOfToken = tagOfToken;
    dataOfToken = _fsyacc_dataOfToken; 
    actionTableElements = _fsyacc_actionTableElements;
    actionTableRowOffsets = _fsyacc_actionTableRowOffsets;
    stateToProdIdxsTableElements = _fsyacc_stateToProdIdxsTableElements;
    stateToProdIdxsTableRowOffsets = _fsyacc_stateToProdIdxsTableRowOffsets;
    reductionSymbolCounts = _fsyacc_reductionSymbolCounts;
    immediateActions = _fsyacc_immediateActions;
    gotos = _fsyacc_gotos;
    sparseGotoTableRowOffsets = _fsyacc_sparseGotoTableRowOffsets;
    tagOfErrorTerminal = _fsyacc_tagOfErrorTerminal;
    parseError = (fun (ctxt:Microsoft.FSharp.Text.Parsing.ParseErrorContext<_>) -> 
                              match parse_error_rich with 
                              | Some f -> f ctxt
                              | None -> parse_error ctxt.Message);
    numTerminals = 32;
    productionToNonTerminalTable = _fsyacc_productionToNonTerminalTable  }
let engine lexer lexbuf startState = (tables ()).Interpret(lexer, lexbuf, startState)
let Main lexer lexbuf : Absyn.expr =
    Microsoft.FSharp.Core.Operators.unbox ((tables ()).Interpret(lexer, lexbuf, 0))