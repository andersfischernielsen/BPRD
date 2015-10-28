module Check

open Absyn
open HigherFun

//Check in an environment whether "x" exists in e.g "x 2".
let rec exists x env =
    match env with 
    | []        -> false
    | y::xs     -> if x=y then true 
                   else exists x xs;;


//Check a given expression.    
let rec checkWithEnv (e : expr) (env : string list) : bool =
    match e with
    | CstI _ | CstB _               -> true
    | Var x                         -> exists x env
    | Prim(_, e1, e2)               -> checkWithEnv e1 env && checkWithEnv e2 env
    | Let(x, eRhs, letBody)         -> checkWithEnv eRhs env 
                                       && checkWithEnv letBody (x::env)
    | If(e1, e2, e3)                -> checkWithEnv e1 env 
                                       && checkWithEnv e2 env 
                                       && checkWithEnv e3 env
    | Letfun(f, x, fBody, letBody)  -> checkWithEnv fBody (f::x::env) 
                                       && checkWithEnv letBody (f::env)
    | Fun(x, funBody)               -> checkWithEnv funBody (x::env)
    | Call(eFun, eArg)              -> checkWithEnv eArg env && checkWithEnv eFun env
      
let check e = checkWithEnv e []


//let f x = g * x in f 2 end;       => true
