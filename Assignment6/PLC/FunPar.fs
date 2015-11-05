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
  | FUN
  | TO
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
    | TOKEN_FUN
    | TOKEN_TO
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
  | FUN  -> 23 
  | TO  -> 24 
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
  | 23 -> TOKEN_FUN 
  | 24 -> TOKEN_TO 
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
    | 17 -> NONTERM_AtExpr 
    | 18 -> NONTERM_AtExpr 
    | 19 -> NONTERM_AtExpr 
    | 20 -> NONTERM_AtExpr 
    | 21 -> NONTERM_AtExpr 
    | 22 -> NONTERM_AtExpr 
    | 23 -> NONTERM_AppExpr 
    | 24 -> NONTERM_AppExpr 
    | 25 -> NONTERM_Const 
    | 26 -> NONTERM_Const 
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
  | FUN  -> "FUN" 
  | TO  -> "TO" 
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
  | FUN  -> (null : System.Object) 
  | TO  -> (null : System.Object) 
  | CSTBOOL _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | NAME _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | CSTINT _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
let _fsyacc_gotos = [| 0us; 65535us; 1us; 65535us; 0us; 1us; 22us; 65535us; 0us; 2us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 31us; 14us; 32us; 15us; 33us; 16us; 34us; 17us; 35us; 18us; 36us; 19us; 37us; 20us; 38us; 21us; 39us; 22us; 40us; 23us; 41us; 24us; 46us; 25us; 47us; 26us; 50us; 27us; 51us; 28us; 55us; 29us; 56us; 30us; 24us; 65535us; 0us; 4us; 4us; 58us; 5us; 59us; 6us; 4us; 8us; 4us; 10us; 4us; 12us; 4us; 31us; 4us; 32us; 4us; 33us; 4us; 34us; 4us; 35us; 4us; 36us; 4us; 37us; 4us; 38us; 4us; 39us; 4us; 40us; 4us; 41us; 4us; 46us; 4us; 47us; 4us; 50us; 4us; 51us; 4us; 55us; 4us; 56us; 4us; 22us; 65535us; 0us; 5us; 6us; 5us; 8us; 5us; 10us; 5us; 12us; 5us; 31us; 5us; 32us; 5us; 33us; 5us; 34us; 5us; 35us; 5us; 36us; 5us; 37us; 5us; 38us; 5us; 39us; 5us; 40us; 5us; 41us; 5us; 46us; 5us; 47us; 5us; 50us; 5us; 51us; 5us; 55us; 5us; 56us; 5us; 24us; 65535us; 0us; 42us; 4us; 42us; 5us; 42us; 6us; 42us; 8us; 42us; 10us; 42us; 12us; 42us; 31us; 42us; 32us; 42us; 33us; 42us; 34us; 42us; 35us; 42us; 36us; 42us; 37us; 42us; 38us; 42us; 39us; 42us; 40us; 42us; 41us; 42us; 46us; 42us; 47us; 42us; 50us; 42us; 51us; 42us; 55us; 42us; 56us; 42us; |]
let _fsyacc_sparseGotoTableRowOffsets = [|0us; 1us; 3us; 26us; 51us; 74us; |]
let _fsyacc_stateToProdIdxsTableElements = [| 1us; 0us; 1us; 0us; 12us; 1us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 1us; 1us; 2us; 2us; 23us; 2us; 3us; 24us; 1us; 4us; 12us; 4us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 1us; 4us; 12us; 4us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 1us; 4us; 12us; 4us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 1us; 5us; 12us; 5us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 12us; 6us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 12us; 6us; 7us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 12us; 6us; 7us; 8us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 12us; 6us; 7us; 8us; 9us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 12us; 6us; 7us; 8us; 9us; 10us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 12us; 6us; 7us; 8us; 9us; 10us; 11us; 11us; 12us; 13us; 14us; 15us; 16us; 12us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 12us; 13us; 14us; 15us; 16us; 12us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 13us; 14us; 15us; 16us; 12us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 14us; 15us; 16us; 12us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 15us; 16us; 12us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 16us; 12us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 19us; 12us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 19us; 12us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 20us; 12us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 20us; 12us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 21us; 12us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 22us; 1us; 6us; 1us; 7us; 1us; 8us; 1us; 9us; 1us; 10us; 1us; 11us; 1us; 12us; 1us; 13us; 1us; 14us; 1us; 15us; 1us; 16us; 1us; 17us; 1us; 18us; 2us; 19us; 20us; 2us; 19us; 20us; 1us; 19us; 1us; 19us; 1us; 19us; 1us; 20us; 1us; 20us; 1us; 20us; 1us; 20us; 1us; 21us; 1us; 21us; 1us; 21us; 1us; 22us; 1us; 22us; 1us; 23us; 1us; 24us; 1us; 25us; 1us; 26us; |]
let _fsyacc_stateToProdIdxsTableRowOffsets = [|0us; 2us; 4us; 17us; 19us; 22us; 25us; 27us; 40us; 42us; 55us; 57us; 70us; 72us; 85us; 98us; 111us; 124us; 137us; 150us; 163us; 176us; 189us; 202us; 215us; 228us; 241us; 254us; 267us; 280us; 293us; 306us; 308us; 310us; 312us; 314us; 316us; 318us; 320us; 322us; 324us; 326us; 328us; 330us; 332us; 335us; 338us; 340us; 342us; 344us; 346us; 348us; 350us; 352us; 354us; 356us; 358us; 360us; 362us; 364us; 366us; 368us; |]
let _fsyacc_action_rows = 62
let _fsyacc_actionTableElements = [|8us; 32768us; 1us; 56us; 10us; 12us; 17us; 6us; 19us; 44us; 23us; 53us; 25us; 61us; 26us; 43us; 27us; 60us; 0us; 49152us; 12us; 32768us; 0us; 3us; 3us; 36us; 4us; 37us; 5us; 38us; 6us; 39us; 7us; 40us; 8us; 41us; 9us; 31us; 10us; 32us; 11us; 33us; 12us; 34us; 13us; 35us; 0us; 16385us; 6us; 16386us; 1us; 56us; 19us; 44us; 23us; 53us; 25us; 61us; 26us; 43us; 27us; 60us; 6us; 16387us; 1us; 56us; 19us; 44us; 23us; 53us; 25us; 61us; 26us; 43us; 27us; 60us; 8us; 32768us; 1us; 56us; 10us; 12us; 17us; 6us; 19us; 44us; 23us; 53us; 25us; 61us; 26us; 43us; 27us; 60us; 12us; 32768us; 3us; 36us; 4us; 37us; 5us; 38us; 6us; 39us; 7us; 40us; 8us; 41us; 9us; 31us; 10us; 32us; 11us; 33us; 12us; 34us; 13us; 35us; 21us; 8us; 8us; 32768us; 1us; 56us; 10us; 12us; 17us; 6us; 19us; 44us; 23us; 53us; 25us; 61us; 26us; 43us; 27us; 60us; 12us; 32768us; 3us; 36us; 4us; 37us; 5us; 38us; 6us; 39us; 7us; 40us; 8us; 41us; 9us; 31us; 10us; 32us; 11us; 33us; 12us; 34us; 13us; 35us; 14us; 10us; 8us; 32768us; 1us; 56us; 10us; 12us; 17us; 6us; 19us; 44us; 23us; 53us; 25us; 61us; 26us; 43us; 27us; 60us; 11us; 16388us; 3us; 36us; 4us; 37us; 5us; 38us; 6us; 39us; 7us; 40us; 8us; 41us; 9us; 31us; 10us; 32us; 11us; 33us; 12us; 34us; 13us; 35us; 8us; 32768us; 1us; 56us; 10us; 12us; 17us; 6us; 19us; 44us; 23us; 53us; 25us; 61us; 26us; 43us; 27us; 60us; 3us; 16389us; 11us; 33us; 12us; 34us; 13us; 35us; 3us; 16390us; 11us; 33us; 12us; 34us; 13us; 35us; 3us; 16391us; 11us; 33us; 12us; 34us; 13us; 35us; 0us; 16392us; 0us; 16393us; 0us; 16394us; 9us; 16395us; 5us; 38us; 6us; 39us; 7us; 40us; 8us; 41us; 9us; 31us; 10us; 32us; 11us; 33us; 12us; 34us; 13us; 35us; 9us; 16396us; 5us; 38us; 6us; 39us; 7us; 40us; 8us; 41us; 9us; 31us; 10us; 32us; 11us; 33us; 12us; 34us; 13us; 35us; 9us; 16397us; 5us; 38us; 6us; 39us; 7us; 40us; 8us; 41us; 9us; 31us; 10us; 32us; 11us; 33us; 12us; 34us; 13us; 35us; 9us; 16398us; 5us; 38us; 6us; 39us; 7us; 40us; 8us; 41us; 9us; 31us; 10us; 32us; 11us; 33us; 12us; 34us; 13us; 35us; 9us; 16399us; 5us; 38us; 6us; 39us; 7us; 40us; 8us; 41us; 9us; 31us; 10us; 32us; 11us; 33us; 12us; 34us; 13us; 35us; 9us; 16400us; 5us; 38us; 6us; 39us; 7us; 40us; 8us; 41us; 9us; 31us; 10us; 32us; 11us; 33us; 12us; 34us; 13us; 35us; 12us; 32768us; 3us; 36us; 4us; 37us; 5us; 38us; 6us; 39us; 7us; 40us; 8us; 41us; 9us; 31us; 10us; 32us; 11us; 33us; 12us; 34us; 13us; 35us; 18us; 47us; 12us; 32768us; 3us; 36us; 4us; 37us; 5us; 38us; 6us; 39us; 7us; 40us; 8us; 41us; 9us; 31us; 10us; 32us; 11us; 33us; 12us; 34us; 13us; 35us; 15us; 48us; 12us; 32768us; 3us; 36us; 4us; 37us; 5us; 38us; 6us; 39us; 7us; 40us; 8us; 41us; 9us; 31us; 10us; 32us; 11us; 33us; 12us; 34us; 13us; 35us; 18us; 51us; 12us; 32768us; 3us; 36us; 4us; 37us; 5us; 38us; 6us; 39us; 7us; 40us; 8us; 41us; 9us; 31us; 10us; 32us; 11us; 33us; 12us; 34us; 13us; 35us; 15us; 52us; 11us; 16405us; 3us; 36us; 4us; 37us; 5us; 38us; 6us; 39us; 7us; 40us; 8us; 41us; 9us; 31us; 10us; 32us; 11us; 33us; 12us; 34us; 13us; 35us; 12us; 32768us; 2us; 57us; 3us; 36us; 4us; 37us; 5us; 38us; 6us; 39us; 7us; 40us; 8us; 41us; 9us; 31us; 10us; 32us; 11us; 33us; 12us; 34us; 13us; 35us; 8us; 32768us; 1us; 56us; 10us; 12us; 17us; 6us; 19us; 44us; 23us; 53us; 25us; 61us; 26us; 43us; 27us; 60us; 8us; 32768us; 1us; 56us; 10us; 12us; 17us; 6us; 19us; 44us; 23us; 53us; 25us; 61us; 26us; 43us; 27us; 60us; 8us; 32768us; 1us; 56us; 10us; 12us; 17us; 6us; 19us; 44us; 23us; 53us; 25us; 61us; 26us; 43us; 27us; 60us; 8us; 32768us; 1us; 56us; 10us; 12us; 17us; 6us; 19us; 44us; 23us; 53us; 25us; 61us; 26us; 43us; 27us; 60us; 8us; 32768us; 1us; 56us; 10us; 12us; 17us; 6us; 19us; 44us; 23us; 53us; 25us; 61us; 26us; 43us; 27us; 60us; 8us; 32768us; 1us; 56us; 10us; 12us; 17us; 6us; 19us; 44us; 23us; 53us; 25us; 61us; 26us; 43us; 27us; 60us; 8us; 32768us; 1us; 56us; 10us; 12us; 17us; 6us; 19us; 44us; 23us; 53us; 25us; 61us; 26us; 43us; 27us; 60us; 8us; 32768us; 1us; 56us; 10us; 12us; 17us; 6us; 19us; 44us; 23us; 53us; 25us; 61us; 26us; 43us; 27us; 60us; 8us; 32768us; 1us; 56us; 10us; 12us; 17us; 6us; 19us; 44us; 23us; 53us; 25us; 61us; 26us; 43us; 27us; 60us; 8us; 32768us; 1us; 56us; 10us; 12us; 17us; 6us; 19us; 44us; 23us; 53us; 25us; 61us; 26us; 43us; 27us; 60us; 8us; 32768us; 1us; 56us; 10us; 12us; 17us; 6us; 19us; 44us; 23us; 53us; 25us; 61us; 26us; 43us; 27us; 60us; 0us; 16401us; 0us; 16402us; 1us; 32768us; 26us; 45us; 2us; 32768us; 3us; 46us; 26us; 49us; 8us; 32768us; 1us; 56us; 10us; 12us; 17us; 6us; 19us; 44us; 23us; 53us; 25us; 61us; 26us; 43us; 27us; 60us; 8us; 32768us; 1us; 56us; 10us; 12us; 17us; 6us; 19us; 44us; 23us; 53us; 25us; 61us; 26us; 43us; 27us; 60us; 0us; 16403us; 1us; 32768us; 3us; 50us; 8us; 32768us; 1us; 56us; 10us; 12us; 17us; 6us; 19us; 44us; 23us; 53us; 25us; 61us; 26us; 43us; 27us; 60us; 8us; 32768us; 1us; 56us; 10us; 12us; 17us; 6us; 19us; 44us; 23us; 53us; 25us; 61us; 26us; 43us; 27us; 60us; 0us; 16404us; 1us; 32768us; 26us; 54us; 1us; 32768us; 24us; 55us; 8us; 32768us; 1us; 56us; 10us; 12us; 17us; 6us; 19us; 44us; 23us; 53us; 25us; 61us; 26us; 43us; 27us; 60us; 8us; 32768us; 1us; 56us; 10us; 12us; 17us; 6us; 19us; 44us; 23us; 53us; 25us; 61us; 26us; 43us; 27us; 60us; 0us; 16406us; 0us; 16407us; 0us; 16408us; 0us; 16409us; 0us; 16410us; |]
let _fsyacc_actionTableRowOffsets = [|0us; 9us; 10us; 23us; 24us; 31us; 38us; 47us; 60us; 69us; 82us; 91us; 103us; 112us; 116us; 120us; 124us; 125us; 126us; 127us; 137us; 147us; 157us; 167us; 177us; 187us; 200us; 213us; 226us; 239us; 251us; 264us; 273us; 282us; 291us; 300us; 309us; 318us; 327us; 336us; 345us; 354us; 363us; 364us; 365us; 367us; 370us; 379us; 388us; 389us; 391us; 400us; 409us; 410us; 412us; 414us; 423us; 432us; 433us; 434us; 435us; 436us; |]
let _fsyacc_reductionSymbolCounts = [|1us; 2us; 1us; 1us; 6us; 2us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 1us; 1us; 7us; 8us; 4us; 3us; 2us; 2us; 1us; 1us; |]
let _fsyacc_productionToNonTerminalTable = [|0us; 1us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 3us; 3us; 3us; 3us; 3us; 3us; 4us; 4us; 5us; 5us; |]
let _fsyacc_immediateActions = [|65535us; 49152us; 65535us; 16385us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 16401us; 16402us; 65535us; 65535us; 65535us; 65535us; 16403us; 65535us; 65535us; 65535us; 16404us; 65535us; 65535us; 65535us; 65535us; 16406us; 16407us; 16408us; 16409us; 16410us; |]
let _fsyacc_reductions ()  =    [| 
# 263 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                      raise (Microsoft.FSharp.Text.Parsing.Accept(Microsoft.FSharp.Core.Operators.box _1))
                   )
                 : '_startMain));
# 272 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 34 "FunPar.fsy"
                                                               _1 
                   )
# 34 "FunPar.fsy"
                 : Absyn.expr));
# 283 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 38 "FunPar.fsy"
                                                               _1                     
                   )
# 38 "FunPar.fsy"
                 : Absyn.expr));
# 294 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 39 "FunPar.fsy"
                                                               _1                     
                   )
# 39 "FunPar.fsy"
                 : Absyn.expr));
# 305 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _4 = (let data = parseState.GetInput(4) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _6 = (let data = parseState.GetInput(6) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 40 "FunPar.fsy"
                                                               If(_2, _4, _6)         
                   )
# 40 "FunPar.fsy"
                 : Absyn.expr));
# 318 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 41 "FunPar.fsy"
                                                               Prim("-", CstI 0, _2)  
                   )
# 41 "FunPar.fsy"
                 : Absyn.expr));
# 329 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 42 "FunPar.fsy"
                                                               Prim("+",  _1, _3)     
                   )
# 42 "FunPar.fsy"
                 : Absyn.expr));
# 341 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 43 "FunPar.fsy"
                                                               Prim("-",  _1, _3)     
                   )
# 43 "FunPar.fsy"
                 : Absyn.expr));
# 353 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 44 "FunPar.fsy"
                                                               Prim("*",  _1, _3)     
                   )
# 44 "FunPar.fsy"
                 : Absyn.expr));
# 365 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 45 "FunPar.fsy"
                                                               Prim("/",  _1, _3)     
                   )
# 45 "FunPar.fsy"
                 : Absyn.expr));
# 377 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 46 "FunPar.fsy"
                                                               Prim("%",  _1, _3)     
                   )
# 46 "FunPar.fsy"
                 : Absyn.expr));
# 389 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 47 "FunPar.fsy"
                                                               Prim("=",  _1, _3)     
                   )
# 47 "FunPar.fsy"
                 : Absyn.expr));
# 401 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 48 "FunPar.fsy"
                                                               Prim("<>", _1, _3)     
                   )
# 48 "FunPar.fsy"
                 : Absyn.expr));
# 413 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 49 "FunPar.fsy"
                                                               Prim(">",  _1, _3)     
                   )
# 49 "FunPar.fsy"
                 : Absyn.expr));
# 425 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 50 "FunPar.fsy"
                                                               Prim("<",  _1, _3)     
                   )
# 50 "FunPar.fsy"
                 : Absyn.expr));
# 437 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 51 "FunPar.fsy"
                                                               Prim(">=", _1, _3)     
                   )
# 51 "FunPar.fsy"
                 : Absyn.expr));
# 449 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 52 "FunPar.fsy"
                                                               Prim("<=", _1, _3)     
                   )
# 52 "FunPar.fsy"
                 : Absyn.expr));
# 461 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 56 "FunPar.fsy"
                                                               _1                     
                   )
# 56 "FunPar.fsy"
                 : Absyn.expr));
# 472 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 57 "FunPar.fsy"
                                                               Var _1                 
                   )
# 57 "FunPar.fsy"
                 : Absyn.expr));
# 483 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            let _4 = (let data = parseState.GetInput(4) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _6 = (let data = parseState.GetInput(6) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 58 "FunPar.fsy"
                                                               Let(_2, _4, _6)        
                   )
# 58 "FunPar.fsy"
                 : Absyn.expr));
# 496 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            let _5 = (let data = parseState.GetInput(5) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _7 = (let data = parseState.GetInput(7) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 59 "FunPar.fsy"
                                                               Letfun(_2, _3, _5, _7) 
                   )
# 59 "FunPar.fsy"
                 : Absyn.expr));
# 510 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            let _4 = (let data = parseState.GetInput(4) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 60 "FunPar.fsy"
                                                               Fun(_2, _4)            
                   )
# 60 "FunPar.fsy"
                 : Absyn.expr));
# 522 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 61 "FunPar.fsy"
                                                               _2                     
                   )
# 61 "FunPar.fsy"
                 : Absyn.expr));
# 533 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 65 "FunPar.fsy"
                                                               Call(_1, _2)           
                   )
# 65 "FunPar.fsy"
                 : Absyn.expr));
# 545 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 66 "FunPar.fsy"
                                                               Call(_1, _2)           
                   )
# 66 "FunPar.fsy"
                 : Absyn.expr));
# 557 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : int)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 70 "FunPar.fsy"
                                                               CstI(_1)               
                   )
# 70 "FunPar.fsy"
                 : Absyn.expr));
# 568 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : bool)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 71 "FunPar.fsy"
                                                               CstB(_1)               
                   )
# 71 "FunPar.fsy"
                 : Absyn.expr));
|]
# 580 "FunPar.fs"
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