// Implementation file for parser generated by fsyacc
module FunPar
#nowarn "64";; // turn off warnings that type variables used in production annotations are instantiated to concrete type
open Microsoft.FSharp.Text.Lexing
open Microsoft.FSharp.Text.Parsing.ParseHelpers
# 1 "..\Assignment3\FunPar.fsy"

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
  | AND
  | OR
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
    | TOKEN_AND
    | TOKEN_OR
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
    | NONTERM_Names
    | NONTERM_AtExprs
    | NONTERM_Const

// This function maps tokens to integer indexes
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
  | PLUS  -> 9 
  | MINUS  -> 10 
  | TIMES  -> 11 
  | DIV  -> 12 
  | MOD  -> 13 
  | ELSE  -> 14 
  | END  -> 15 
  | FALSE  -> 16 
  | IF  -> 17 
  | IN  -> 18 
  | LET  -> 19 
  | NOT  -> 20 
  | THEN  -> 21 
  | TRUE  -> 22 
  | AND  -> 23 
  | OR  -> 24 
  | CSTBOOL _ -> 25 
  | NAME _ -> 26 
  | CSTINT _ -> 27 

// This function maps integer indexes to symbolic token ids
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
  | 9 -> TOKEN_PLUS 
  | 10 -> TOKEN_MINUS 
  | 11 -> TOKEN_TIMES 
  | 12 -> TOKEN_DIV 
  | 13 -> TOKEN_MOD 
  | 14 -> TOKEN_ELSE 
  | 15 -> TOKEN_END 
  | 16 -> TOKEN_FALSE 
  | 17 -> TOKEN_IF 
  | 18 -> TOKEN_IN 
  | 19 -> TOKEN_LET 
  | 20 -> TOKEN_NOT 
  | 21 -> TOKEN_THEN 
  | 22 -> TOKEN_TRUE 
  | 23 -> TOKEN_AND 
  | 24 -> TOKEN_OR 
  | 25 -> TOKEN_CSTBOOL 
  | 26 -> TOKEN_NAME 
  | 27 -> TOKEN_CSTINT 
  | 30 -> TOKEN_end_of_input
  | 28 -> TOKEN_error
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
    | 24 -> NONTERM_AppExpr 
    | 25 -> NONTERM_Names 
    | 26 -> NONTERM_Names 
    | 27 -> NONTERM_AtExprs 
    | 28 -> NONTERM_AtExprs 
    | 29 -> NONTERM_Const 
    | 30 -> NONTERM_Const 
    | _ -> failwith "prodIdxToNonTerminal: bad production index"

let _fsyacc_endOfInputTag = 30 
let _fsyacc_tagOfErrorTerminal = 28

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
  | AND  -> "AND" 
  | OR  -> "OR" 
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
  | AND  -> (null : System.Object) 
  | OR  -> (null : System.Object) 
  | CSTBOOL _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | NAME _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | CSTINT _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
let _fsyacc_gotos = [| 0us; 65535us; 1us; 65535us; 0us; 1us; 23us; 65535us; 0us; 2us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 32us; 14us; 33us; 15us; 34us; 16us; 35us; 17us; 36us; 18us; 37us; 19us; 38us; 20us; 39us; 21us; 40us; 22us; 41us; 23us; 42us; 24us; 43us; 25us; 44us; 26us; 49us; 27us; 50us; 28us; 53us; 29us; 54us; 30us; 56us; 31us; 25us; 65535us; 0us; 4us; 4us; 61us; 6us; 4us; 8us; 4us; 10us; 4us; 12us; 4us; 32us; 4us; 33us; 4us; 34us; 4us; 35us; 4us; 36us; 4us; 37us; 4us; 38us; 4us; 39us; 4us; 40us; 4us; 41us; 4us; 42us; 4us; 43us; 4us; 44us; 4us; 49us; 4us; 50us; 4us; 53us; 4us; 54us; 4us; 56us; 4us; 61us; 61us; 23us; 65535us; 0us; 5us; 6us; 5us; 8us; 5us; 10us; 5us; 12us; 5us; 32us; 5us; 33us; 5us; 34us; 5us; 35us; 5us; 36us; 5us; 37us; 5us; 38us; 5us; 39us; 5us; 40us; 5us; 41us; 5us; 42us; 5us; 43us; 5us; 44us; 5us; 49us; 5us; 50us; 5us; 53us; 5us; 54us; 5us; 56us; 5us; 2us; 65535us; 48us; 52us; 59us; 60us; 2us; 65535us; 4us; 58us; 61us; 62us; 25us; 65535us; 0us; 45us; 4us; 45us; 6us; 45us; 8us; 45us; 10us; 45us; 12us; 45us; 32us; 45us; 33us; 45us; 34us; 45us; 35us; 45us; 36us; 45us; 37us; 45us; 38us; 45us; 39us; 45us; 40us; 45us; 41us; 45us; 42us; 45us; 43us; 45us; 44us; 45us; 49us; 45us; 50us; 45us; 53us; 45us; 54us; 45us; 56us; 45us; 61us; 45us; |]
let _fsyacc_sparseGotoTableRowOffsets = [|0us; 1us; 3us; 27us; 53us; 77us; 80us; 83us; |]
let _fsyacc_stateToProdIdxsTableElements = [| 1us; 0us; 1us; 0us; 14us; 1us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 1us; 1us; 2us; 2us; 24us; 1us; 3us; 1us; 4us; 14us; 4us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 1us; 4us; 14us; 4us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 1us; 4us; 14us; 4us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 1us; 5us; 14us; 5us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 14us; 6us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 14us; 6us; 7us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 14us; 6us; 7us; 8us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 14us; 6us; 7us; 8us; 9us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 14us; 6us; 7us; 8us; 9us; 10us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 14us; 6us; 7us; 8us; 9us; 10us; 11us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 14us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 14us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 13us; 14us; 15us; 16us; 17us; 18us; 14us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 14us; 15us; 16us; 17us; 18us; 14us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 15us; 16us; 17us; 18us; 14us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 16us; 17us; 18us; 14us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 17us; 18us; 14us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 18us; 14us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 21us; 14us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 21us; 14us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 22us; 14us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 22us; 14us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 23us; 1us; 6us; 1us; 7us; 1us; 8us; 1us; 9us; 1us; 10us; 1us; 11us; 1us; 12us; 1us; 13us; 1us; 14us; 1us; 15us; 1us; 16us; 1us; 17us; 1us; 18us; 1us; 19us; 1us; 20us; 2us; 21us; 22us; 2us; 21us; 22us; 1us; 21us; 1us; 21us; 1us; 21us; 1us; 22us; 1us; 22us; 1us; 22us; 1us; 22us; 1us; 23us; 1us; 23us; 1us; 24us; 2us; 25us; 26us; 1us; 26us; 2us; 27us; 28us; 1us; 28us; 1us; 29us; 1us; 30us; |]
let _fsyacc_stateToProdIdxsTableRowOffsets = [|0us; 2us; 4us; 19us; 21us; 24us; 26us; 28us; 43us; 45us; 60us; 62us; 77us; 79us; 94us; 109us; 124us; 139us; 154us; 169us; 184us; 199us; 214us; 229us; 244us; 259us; 274us; 289us; 304us; 319us; 334us; 349us; 364us; 366us; 368us; 370us; 372us; 374us; 376us; 378us; 380us; 382us; 384us; 386us; 388us; 390us; 392us; 394us; 397us; 400us; 402us; 404us; 406us; 408us; 410us; 412us; 414us; 416us; 418us; 420us; 423us; 425us; 428us; 430us; 432us; |]
let _fsyacc_action_rows = 65
let _fsyacc_actionTableElements = [|7us; 32768us; 1us; 56us; 10us; 12us; 17us; 6us; 19us; 47us; 25us; 64us; 26us; 46us; 27us; 63us; 0us; 49152us; 14us; 32768us; 0us; 3us; 3us; 37us; 4us; 38us; 5us; 39us; 6us; 40us; 7us; 41us; 8us; 42us; 9us; 32us; 10us; 33us; 11us; 34us; 12us; 35us; 13us; 36us; 23us; 43us; 24us; 44us; 0us; 16385us; 5us; 16386us; 1us; 56us; 19us; 47us; 25us; 64us; 26us; 46us; 27us; 63us; 0us; 16387us; 7us; 32768us; 1us; 56us; 10us; 12us; 17us; 6us; 19us; 47us; 25us; 64us; 26us; 46us; 27us; 63us; 14us; 32768us; 3us; 37us; 4us; 38us; 5us; 39us; 6us; 40us; 7us; 41us; 8us; 42us; 9us; 32us; 10us; 33us; 11us; 34us; 12us; 35us; 13us; 36us; 21us; 8us; 23us; 43us; 24us; 44us; 7us; 32768us; 1us; 56us; 10us; 12us; 17us; 6us; 19us; 47us; 25us; 64us; 26us; 46us; 27us; 63us; 14us; 32768us; 3us; 37us; 4us; 38us; 5us; 39us; 6us; 40us; 7us; 41us; 8us; 42us; 9us; 32us; 10us; 33us; 11us; 34us; 12us; 35us; 13us; 36us; 14us; 10us; 23us; 43us; 24us; 44us; 7us; 32768us; 1us; 56us; 10us; 12us; 17us; 6us; 19us; 47us; 25us; 64us; 26us; 46us; 27us; 63us; 13us; 16388us; 3us; 37us; 4us; 38us; 5us; 39us; 6us; 40us; 7us; 41us; 8us; 42us; 9us; 32us; 10us; 33us; 11us; 34us; 12us; 35us; 13us; 36us; 23us; 43us; 24us; 44us; 7us; 32768us; 1us; 56us; 10us; 12us; 17us; 6us; 19us; 47us; 25us; 64us; 26us; 46us; 27us; 63us; 5us; 16389us; 11us; 34us; 12us; 35us; 13us; 36us; 23us; 43us; 24us; 44us; 5us; 16390us; 11us; 34us; 12us; 35us; 13us; 36us; 23us; 43us; 24us; 44us; 5us; 16391us; 11us; 34us; 12us; 35us; 13us; 36us; 23us; 43us; 24us; 44us; 2us; 16392us; 23us; 43us; 24us; 44us; 2us; 16393us; 23us; 43us; 24us; 44us; 2us; 16394us; 23us; 43us; 24us; 44us; 11us; 16395us; 5us; 39us; 6us; 40us; 7us; 41us; 8us; 42us; 9us; 32us; 10us; 33us; 11us; 34us; 12us; 35us; 13us; 36us; 23us; 43us; 24us; 44us; 11us; 16396us; 5us; 39us; 6us; 40us; 7us; 41us; 8us; 42us; 9us; 32us; 10us; 33us; 11us; 34us; 12us; 35us; 13us; 36us; 23us; 43us; 24us; 44us; 11us; 16397us; 5us; 39us; 6us; 40us; 7us; 41us; 8us; 42us; 9us; 32us; 10us; 33us; 11us; 34us; 12us; 35us; 13us; 36us; 23us; 43us; 24us; 44us; 11us; 16398us; 5us; 39us; 6us; 40us; 7us; 41us; 8us; 42us; 9us; 32us; 10us; 33us; 11us; 34us; 12us; 35us; 13us; 36us; 23us; 43us; 24us; 44us; 11us; 16399us; 5us; 39us; 6us; 40us; 7us; 41us; 8us; 42us; 9us; 32us; 10us; 33us; 11us; 34us; 12us; 35us; 13us; 36us; 23us; 43us; 24us; 44us; 11us; 16400us; 5us; 39us; 6us; 40us; 7us; 41us; 8us; 42us; 9us; 32us; 10us; 33us; 11us; 34us; 12us; 35us; 13us; 36us; 23us; 43us; 24us; 44us; 13us; 16401us; 3us; 37us; 4us; 38us; 5us; 39us; 6us; 40us; 7us; 41us; 8us; 42us; 9us; 32us; 10us; 33us; 11us; 34us; 12us; 35us; 13us; 36us; 23us; 43us; 24us; 44us; 13us; 16402us; 3us; 37us; 4us; 38us; 5us; 39us; 6us; 40us; 7us; 41us; 8us; 42us; 9us; 32us; 10us; 33us; 11us; 34us; 12us; 35us; 13us; 36us; 23us; 43us; 24us; 44us; 14us; 32768us; 3us; 37us; 4us; 38us; 5us; 39us; 6us; 40us; 7us; 41us; 8us; 42us; 9us; 32us; 10us; 33us; 11us; 34us; 12us; 35us; 13us; 36us; 18us; 50us; 23us; 43us; 24us; 44us; 14us; 32768us; 3us; 37us; 4us; 38us; 5us; 39us; 6us; 40us; 7us; 41us; 8us; 42us; 9us; 32us; 10us; 33us; 11us; 34us; 12us; 35us; 13us; 36us; 15us; 51us; 23us; 43us; 24us; 44us; 14us; 32768us; 3us; 37us; 4us; 38us; 5us; 39us; 6us; 40us; 7us; 41us; 8us; 42us; 9us; 32us; 10us; 33us; 11us; 34us; 12us; 35us; 13us; 36us; 18us; 54us; 23us; 43us; 24us; 44us; 14us; 32768us; 3us; 37us; 4us; 38us; 5us; 39us; 6us; 40us; 7us; 41us; 8us; 42us; 9us; 32us; 10us; 33us; 11us; 34us; 12us; 35us; 13us; 36us; 15us; 55us; 23us; 43us; 24us; 44us; 14us; 32768us; 2us; 57us; 3us; 37us; 4us; 38us; 5us; 39us; 6us; 40us; 7us; 41us; 8us; 42us; 9us; 32us; 10us; 33us; 11us; 34us; 12us; 35us; 13us; 36us; 23us; 43us; 24us; 44us; 7us; 32768us; 1us; 56us; 10us; 12us; 17us; 6us; 19us; 47us; 25us; 64us; 26us; 46us; 27us; 63us; 7us; 32768us; 1us; 56us; 10us; 12us; 17us; 6us; 19us; 47us; 25us; 64us; 26us; 46us; 27us; 63us; 7us; 32768us; 1us; 56us; 10us; 12us; 17us; 6us; 19us; 47us; 25us; 64us; 26us; 46us; 27us; 63us; 7us; 32768us; 1us; 56us; 10us; 12us; 17us; 6us; 19us; 47us; 25us; 64us; 26us; 46us; 27us; 63us; 7us; 32768us; 1us; 56us; 10us; 12us; 17us; 6us; 19us; 47us; 25us; 64us; 26us; 46us; 27us; 63us; 7us; 32768us; 1us; 56us; 10us; 12us; 17us; 6us; 19us; 47us; 25us; 64us; 26us; 46us; 27us; 63us; 7us; 32768us; 1us; 56us; 10us; 12us; 17us; 6us; 19us; 47us; 25us; 64us; 26us; 46us; 27us; 63us; 7us; 32768us; 1us; 56us; 10us; 12us; 17us; 6us; 19us; 47us; 25us; 64us; 26us; 46us; 27us; 63us; 7us; 32768us; 1us; 56us; 10us; 12us; 17us; 6us; 19us; 47us; 25us; 64us; 26us; 46us; 27us; 63us; 7us; 32768us; 1us; 56us; 10us; 12us; 17us; 6us; 19us; 47us; 25us; 64us; 26us; 46us; 27us; 63us; 7us; 32768us; 1us; 56us; 10us; 12us; 17us; 6us; 19us; 47us; 25us; 64us; 26us; 46us; 27us; 63us; 7us; 32768us; 1us; 56us; 10us; 12us; 17us; 6us; 19us; 47us; 25us; 64us; 26us; 46us; 27us; 63us; 7us; 32768us; 1us; 56us; 10us; 12us; 17us; 6us; 19us; 47us; 25us; 64us; 26us; 46us; 27us; 63us; 0us; 16403us; 0us; 16404us; 1us; 32768us; 26us; 48us; 2us; 32768us; 3us; 49us; 26us; 59us; 7us; 32768us; 1us; 56us; 10us; 12us; 17us; 6us; 19us; 47us; 25us; 64us; 26us; 46us; 27us; 63us; 7us; 32768us; 1us; 56us; 10us; 12us; 17us; 6us; 19us; 47us; 25us; 64us; 26us; 46us; 27us; 63us; 0us; 16405us; 1us; 32768us; 3us; 53us; 7us; 32768us; 1us; 56us; 10us; 12us; 17us; 6us; 19us; 47us; 25us; 64us; 26us; 46us; 27us; 63us; 7us; 32768us; 1us; 56us; 10us; 12us; 17us; 6us; 19us; 47us; 25us; 64us; 26us; 46us; 27us; 63us; 0us; 16406us; 7us; 32768us; 1us; 56us; 10us; 12us; 17us; 6us; 19us; 47us; 25us; 64us; 26us; 46us; 27us; 63us; 0us; 16407us; 0us; 16408us; 1us; 16409us; 26us; 59us; 0us; 16410us; 5us; 16411us; 1us; 56us; 19us; 47us; 25us; 64us; 26us; 46us; 27us; 63us; 0us; 16412us; 0us; 16413us; 0us; 16414us; |]
let _fsyacc_actionTableRowOffsets = [|0us; 8us; 9us; 24us; 25us; 31us; 32us; 40us; 55us; 63us; 78us; 86us; 100us; 108us; 114us; 120us; 126us; 129us; 132us; 135us; 147us; 159us; 171us; 183us; 195us; 207us; 221us; 235us; 250us; 265us; 280us; 295us; 310us; 318us; 326us; 334us; 342us; 350us; 358us; 366us; 374us; 382us; 390us; 398us; 406us; 414us; 415us; 416us; 418us; 421us; 429us; 437us; 438us; 440us; 448us; 456us; 457us; 465us; 466us; 467us; 469us; 470us; 476us; 477us; 478us; |]
let _fsyacc_reductionSymbolCounts = [|1us; 2us; 1us; 1us; 6us; 2us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 1us; 1us; 7us; 8us; 3us; 2us; 1us; 2us; 1us; 2us; 1us; 1us; |]
let _fsyacc_productionToNonTerminalTable = [|0us; 1us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 3us; 3us; 3us; 3us; 3us; 4us; 5us; 5us; 6us; 6us; 7us; 7us; |]
let _fsyacc_immediateActions = [|65535us; 49152us; 65535us; 16385us; 65535us; 16387us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 16403us; 16404us; 65535us; 65535us; 65535us; 65535us; 16405us; 65535us; 65535us; 65535us; 16406us; 65535us; 16407us; 16408us; 65535us; 16410us; 65535us; 16412us; 16413us; 16414us; |]
let _fsyacc_reductions ()  =    [| 
# 269 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                      raise (Microsoft.FSharp.Text.Parsing.Accept(Microsoft.FSharp.Core.Operators.box _1))
                   )
                 : '_startMain));
# 278 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 34 "..\Assignment3\FunPar.fsy"
                                                               _1 
                   )
# 34 "..\Assignment3\FunPar.fsy"
                 : Absyn.expr));
# 289 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 38 "..\Assignment3\FunPar.fsy"
                                                               _1                     
                   )
# 38 "..\Assignment3\FunPar.fsy"
                 : Absyn.expr));
# 300 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 39 "..\Assignment3\FunPar.fsy"
                                                               _1                     
                   )
# 39 "..\Assignment3\FunPar.fsy"
                 : Absyn.expr));
# 311 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _4 = (let data = parseState.GetInput(4) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _6 = (let data = parseState.GetInput(6) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 40 "..\Assignment3\FunPar.fsy"
                                                               If(_2, _4, _6)         
                   )
# 40 "..\Assignment3\FunPar.fsy"
                 : Absyn.expr));
# 324 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 41 "..\Assignment3\FunPar.fsy"
                                                               Prim("-", CstI 0, _2)  
                   )
# 41 "..\Assignment3\FunPar.fsy"
                 : Absyn.expr));
# 335 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 42 "..\Assignment3\FunPar.fsy"
                                                               Prim("+",  _1, _3)     
                   )
# 42 "..\Assignment3\FunPar.fsy"
                 : Absyn.expr));
# 347 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 43 "..\Assignment3\FunPar.fsy"
                                                               Prim("-",  _1, _3)     
                   )
# 43 "..\Assignment3\FunPar.fsy"
                 : Absyn.expr));
# 359 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 44 "..\Assignment3\FunPar.fsy"
                                                               Prim("*",  _1, _3)     
                   )
# 44 "..\Assignment3\FunPar.fsy"
                 : Absyn.expr));
# 371 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 45 "..\Assignment3\FunPar.fsy"
                                                               Prim("/",  _1, _3)     
                   )
# 45 "..\Assignment3\FunPar.fsy"
                 : Absyn.expr));
# 383 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 46 "..\Assignment3\FunPar.fsy"
                                                               Prim("%",  _1, _3)     
                   )
# 46 "..\Assignment3\FunPar.fsy"
                 : Absyn.expr));
# 395 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 47 "..\Assignment3\FunPar.fsy"
                                                               Prim("=",  _1, _3)     
                   )
# 47 "..\Assignment3\FunPar.fsy"
                 : Absyn.expr));
# 407 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 48 "..\Assignment3\FunPar.fsy"
                                                               Prim("<>", _1, _3)     
                   )
# 48 "..\Assignment3\FunPar.fsy"
                 : Absyn.expr));
# 419 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 49 "..\Assignment3\FunPar.fsy"
                                                               Prim(">",  _1, _3)     
                   )
# 49 "..\Assignment3\FunPar.fsy"
                 : Absyn.expr));
# 431 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 50 "..\Assignment3\FunPar.fsy"
                                                               Prim("<",  _1, _3)     
                   )
# 50 "..\Assignment3\FunPar.fsy"
                 : Absyn.expr));
# 443 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 51 "..\Assignment3\FunPar.fsy"
                                                               Prim(">=", _1, _3)     
                   )
# 51 "..\Assignment3\FunPar.fsy"
                 : Absyn.expr));
# 455 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 52 "..\Assignment3\FunPar.fsy"
                                                               Prim("<=", _1, _3)     
                   )
# 52 "..\Assignment3\FunPar.fsy"
                 : Absyn.expr));
# 467 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 53 "..\Assignment3\FunPar.fsy"
                                                               If(_1, _2, "false"     
                   )
# 53 "..\Assignment3\FunPar.fsy"
                 : Absyn.expr));
# 479 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 54 "..\Assignment3\FunPar.fsy"
                                                               If(_1, "true", _2)     
                   )
# 54 "..\Assignment3\FunPar.fsy"
                 : Absyn.expr));
# 491 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 58 "..\Assignment3\FunPar.fsy"
                                                               _1                     
                   )
# 58 "..\Assignment3\FunPar.fsy"
                 : Absyn.expr));
# 502 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 59 "..\Assignment3\FunPar.fsy"
                                                               Var _1                 
                   )
# 59 "..\Assignment3\FunPar.fsy"
                 : Absyn.expr));
# 513 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            let _4 = (let data = parseState.GetInput(4) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _6 = (let data = parseState.GetInput(6) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 60 "..\Assignment3\FunPar.fsy"
                                                               Let(_2, _4, _6)        
                   )
# 60 "..\Assignment3\FunPar.fsy"
                 : Absyn.expr));
# 526 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : 'Names)) in
            let _5 = (let data = parseState.GetInput(5) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _7 = (let data = parseState.GetInput(7) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 61 "..\Assignment3\FunPar.fsy"
                                                               Letfun(_2, _3, _5, _7) 
                   )
# 61 "..\Assignment3\FunPar.fsy"
                 : Absyn.expr));
# 540 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 62 "..\Assignment3\FunPar.fsy"
                                                               _2                     
                   )
# 62 "..\Assignment3\FunPar.fsy"
                 : Absyn.expr));
# 551 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'AtExprs)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 66 "..\Assignment3\FunPar.fsy"
                                                               Call(_1, _2)           
                   )
# 66 "..\Assignment3\FunPar.fsy"
                 : Absyn.expr));
# 563 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 70 "..\Assignment3\FunPar.fsy"
                                                               [_1]                   
                   )
# 70 "..\Assignment3\FunPar.fsy"
                 : 'Names));
# 574 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'Names)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 71 "..\Assignment3\FunPar.fsy"
                                                               _1 :: _2               
                   )
# 71 "..\Assignment3\FunPar.fsy"
                 : 'Names));
# 586 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 75 "..\Assignment3\FunPar.fsy"
                                                               [_1]                   
                   )
# 75 "..\Assignment3\FunPar.fsy"
                 : 'AtExprs));
# 597 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'AtExprs)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 76 "..\Assignment3\FunPar.fsy"
                                                               _1 :: _2               
                   )
# 76 "..\Assignment3\FunPar.fsy"
                 : 'AtExprs));
# 609 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : int)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 80 "..\Assignment3\FunPar.fsy"
                                                               CstI(_1)               
                   )
# 80 "..\Assignment3\FunPar.fsy"
                 : Absyn.expr));
# 620 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : bool)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 81 "..\Assignment3\FunPar.fsy"
                                                               CstB(_1)               
                   )
# 81 "..\Assignment3\FunPar.fsy"
                 : Absyn.expr));
|]
# 632 "FunPar.fs"
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
    numTerminals = 31;
    productionToNonTerminalTable = _fsyacc_productionToNonTerminalTable  }
let engine lexer lexbuf startState = (tables ()).Interpret(lexer, lexbuf, startState)
let Main lexer lexbuf : Absyn.expr =
    Microsoft.FSharp.Core.Operators.unbox ((tables ()).Interpret(lexer, lexbuf, 0))
