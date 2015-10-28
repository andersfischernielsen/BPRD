// Implementation file for parser generated by fsyacc
module RePar
#nowarn "64";; // turn off warnings that type variables used in production annotations are instantiated to concrete type
open Microsoft.FSharp.Text.Lexing
open Microsoft.FSharp.Text.Parsing.ParseHelpers
# 1 "RePar.fsy"

 open Absyn;

# 10 "RePar.fs"
// This type is the type of tokens accepted by the parser
type token = 
  | LPAR
  | RPAR
  | CHOICE
  | SPACE
  | STAR
  | EPS
  | CHAR of (char)
// This type is used to give symbolic names to token indexes, useful for error messages
type tokenId = 
    | TOKEN_LPAR
    | TOKEN_RPAR
    | TOKEN_CHOICE
    | TOKEN_SPACE
    | TOKEN_STAR
    | TOKEN_EPS
    | TOKEN_CHAR
    | TOKEN_end_of_input
    | TOKEN_error
// This type is used to give symbolic names to token indexes, useful for error messages
type nonTerminalId = 
    | NONTERM__startMain
    | NONTERM_Main
    | NONTERM_RegExpr

// This function maps tokens to integer indexes
let tagOfToken (t:token) = 
  match t with
  | LPAR  -> 0 
  | RPAR  -> 1 
  | CHOICE  -> 2 
  | SPACE  -> 3 
  | STAR  -> 4 
  | EPS  -> 5 
  | CHAR _ -> 6 

// This function maps integer indexes to symbolic token ids
let tokenTagToTokenId (tokenIdx:int) = 
  match tokenIdx with
  | 0 -> TOKEN_LPAR 
  | 1 -> TOKEN_RPAR 
  | 2 -> TOKEN_CHOICE 
  | 3 -> TOKEN_SPACE 
  | 4 -> TOKEN_STAR 
  | 5 -> TOKEN_EPS 
  | 6 -> TOKEN_CHAR 
  | 9 -> TOKEN_end_of_input
  | 7 -> TOKEN_error
  | _ -> failwith "tokenTagToTokenId: bad token"

/// This function maps production indexes returned in syntax errors to strings representing the non terminal that would be produced by that production
let prodIdxToNonTerminal (prodIdx:int) = 
  match prodIdx with
    | 0 -> NONTERM__startMain 
    | 1 -> NONTERM_Main 
    | 2 -> NONTERM_RegExpr 
    | 3 -> NONTERM_RegExpr 
    | 4 -> NONTERM_RegExpr 
    | 5 -> NONTERM_RegExpr 
    | 6 -> NONTERM_RegExpr 
    | 7 -> NONTERM_RegExpr 
    | _ -> failwith "prodIdxToNonTerminal: bad production index"

let _fsyacc_endOfInputTag = 9 
let _fsyacc_tagOfErrorTerminal = 7

// This function gets the name of a token as a string
let token_to_string (t:token) = 
  match t with 
  | LPAR  -> "LPAR" 
  | RPAR  -> "RPAR" 
  | CHOICE  -> "CHOICE" 
  | SPACE  -> "SPACE" 
  | STAR  -> "STAR" 
  | EPS  -> "EPS" 
  | CHAR _ -> "CHAR" 

// This function gets the data carried by a token as an object
let _fsyacc_dataOfToken (t:token) = 
  match t with 
  | LPAR  -> (null : System.Object) 
  | RPAR  -> (null : System.Object) 
  | CHOICE  -> (null : System.Object) 
  | SPACE  -> (null : System.Object) 
  | STAR  -> (null : System.Object) 
  | EPS  -> (null : System.Object) 
  | CHAR _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
let _fsyacc_gotos = [| 0us; 65535us; 1us; 65535us; 0us; 1us; 9us; 65535us; 0us; 2us; 2us; 6us; 4us; 5us; 5us; 6us; 6us; 6us; 7us; 6us; 8us; 6us; 10us; 7us; 12us; 8us; |]
let _fsyacc_sparseGotoTableRowOffsets = [|0us; 1us; 3us; |]
let _fsyacc_stateToProdIdxsTableElements = [| 1us; 0us; 1us; 0us; 4us; 1us; 3us; 6us; 7us; 1us; 1us; 1us; 2us; 4us; 2us; 3us; 6us; 7us; 4us; 3us; 3us; 6us; 7us; 4us; 3us; 5us; 6us; 7us; 4us; 3us; 6us; 6us; 7us; 1us; 4us; 1us; 5us; 1us; 5us; 1us; 6us; 1us; 7us; |]
let _fsyacc_stateToProdIdxsTableRowOffsets = [|0us; 2us; 4us; 9us; 11us; 13us; 18us; 23us; 28us; 33us; 35us; 37us; 39us; 41us; |]
let _fsyacc_action_rows = 14
let _fsyacc_actionTableElements = [|3us; 32768us; 0us; 10us; 3us; 4us; 6us; 9us; 0us; 49152us; 6us; 32768us; 0us; 10us; 2us; 12us; 3us; 4us; 4us; 13us; 5us; 3us; 6us; 9us; 0us; 16385us; 3us; 32768us; 0us; 10us; 3us; 4us; 6us; 9us; 5us; 16386us; 0us; 10us; 2us; 12us; 3us; 4us; 4us; 13us; 6us; 9us; 5us; 16387us; 0us; 10us; 2us; 12us; 3us; 4us; 4us; 13us; 6us; 9us; 6us; 32768us; 0us; 10us; 1us; 11us; 2us; 12us; 3us; 4us; 4us; 13us; 6us; 9us; 5us; 16390us; 0us; 10us; 2us; 12us; 3us; 4us; 4us; 13us; 6us; 9us; 0us; 16388us; 3us; 32768us; 0us; 10us; 3us; 4us; 6us; 9us; 0us; 16389us; 3us; 32768us; 0us; 10us; 3us; 4us; 6us; 9us; 0us; 16391us; |]
let _fsyacc_actionTableRowOffsets = [|0us; 4us; 5us; 12us; 13us; 17us; 23us; 29us; 36us; 42us; 43us; 47us; 48us; 52us; |]
let _fsyacc_reductionSymbolCounts = [|1us; 2us; 2us; 2us; 1us; 3us; 3us; 2us; |]
let _fsyacc_productionToNonTerminalTable = [|0us; 1us; 2us; 2us; 2us; 2us; 2us; 2us; |]
let _fsyacc_immediateActions = [|65535us; 49152us; 65535us; 16385us; 65535us; 65535us; 65535us; 65535us; 65535us; 16388us; 65535us; 16389us; 65535us; 16391us; |]
let _fsyacc_reductions ()  =    [| 
# 110 "RePar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.re)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                      raise (Microsoft.FSharp.Text.Parsing.Accept(Microsoft.FSharp.Core.Operators.box _1))
                   )
                 : '_startMain));
# 119 "RePar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.re)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 21 "RePar.fsy"
                                                  _1             
                   )
# 21 "RePar.fsy"
                 : Absyn.re));
# 130 "RePar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.re)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 25 "RePar.fsy"
                                           _2			 
                   )
# 25 "RePar.fsy"
                 : Absyn.re));
# 141 "RePar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.re)) in
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.re)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 26 "RePar.fsy"
                                                   Seq(_1, _2)	 
                   )
# 26 "RePar.fsy"
                 : Absyn.re));
# 153 "RePar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : char)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 27 "RePar.fsy"
                                                  Char _1	     
                   )
# 27 "RePar.fsy"
                 : Absyn.re));
# 164 "RePar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.re)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 28 "RePar.fsy"
                                                  _2             
                   )
# 28 "RePar.fsy"
                 : Absyn.re));
# 175 "RePar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.re)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.re)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 29 "RePar.fsy"
                                                   Choice(_1, _3) 
                   )
# 29 "RePar.fsy"
                 : Absyn.re));
# 187 "RePar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.re)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 30 "RePar.fsy"
                                                   Star(_1)       
                   )
# 30 "RePar.fsy"
                 : Absyn.re));
|]
# 199 "RePar.fs"
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
    numTerminals = 10;
    productionToNonTerminalTable = _fsyacc_productionToNonTerminalTable  }
let engine lexer lexbuf startState = (tables ()).Interpret(lexer, lexbuf, startState)
let Main lexer lexbuf : Absyn.re =
    Microsoft.FSharp.Core.Operators.unbox ((tables ()).Interpret(lexer, lexbuf, 0))
