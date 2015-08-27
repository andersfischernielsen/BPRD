// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.



//------------
//Assignment 1
//AFIN
//------------


//-----
// 1.1
//-----

type expr = 
  | CstI of int
  | Var of string
  | Prim of string * expr * expr
  | If of (expr * expr * expr)      //From exercise 1.1 (iv)

let rec lookup env x =
    match env with 
    | []        -> failwith (x + " not found")
    | (y, v)::r -> if x=y then v else lookup r x;;

//(i) & (v)
let rec eval e (env : (string * int) list) : int =
    match e with
    | CstI i                -> i
    | Var x                 -> lookup env x 
    | Prim("+", e1, e2)     -> eval e1 env + eval e2 env
    | Prim("*", e1, e2)     -> eval e1 env * eval e2 env
    | Prim("-", e1, e2)     -> eval e1 env - eval e2 env
    | Prim("max", e1, e2)   -> max (eval e1 env) (eval e2 env)
    | Prim("min", e1, e2)   -> min (eval e1 env) (eval e2 env)
    | Prim("==", e1, e2)    -> if (eval e1 env) = (eval e2 env) then 1 else 0
    | If(e1, e2, e3)        -> if (eval e1 env) <> 0 then (eval e2 env) else (eval e3 env)
    | Prim _                -> failwith "unknown primitive";;

//(ii)
let example1 = Prim("min", Prim("*", CstI 7, CstI 9), CstI 10)  //10 : expected result
let example2 = Prim("max", CstI 2, CstI 6)                      //6  : expected result
let example3 = Prim("==", CstI 6, CstI 6)                       //1  : expected result
let example4 = Prim("==", CstI 10, CstI 6)                      //0  : expected result
let example5 = Prim("max", CstI 100, CstI 6)                    //100: expected result

//(iii)
let rec evalBranch e (env : (string * int) list) : int =
    match e with
    | CstI i                -> i
    | Var x                 -> lookup env x 
    | If(e1, e2, e3)        -> if (eval e1 env) <> 0 then (eval e2 env) else (eval e3 env)
    | Prim(ope, e1, e2)     -> let eval1 = evalBranch e1 env 
                               let eval2 = evalBranch e2 env
                               match ope with 
                               | "*"    -> eval1 * eval2
                               | "-"    -> eval1 - eval2
                               | "max"  -> max eval1 eval2
                               | "min"  -> min eval1 eval2
                               | "=="   -> if eval1 = eval2 then 1 else 0
                               | _      -> failwith "unknown primitive"

//(iv)
//See type declaration at the top.

//(v)
//See (i) above.
//Test:
let testEnv1 = [("a", 0)]
let testEnv2 = ["a", 100]

let test = If(Var "a", CstI 11, CstI 22)
let result1 = eval test testEnv1
let result2 = eval test testEnv2



//-----
// 1.2
//-----


[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    0 // return an integer exit code