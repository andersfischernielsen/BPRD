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
    | If of (expr * expr * expr) //From exercise 1.1 (iv)

let rec lookup env x = 
    match env with
    | [] -> failwith (x + " not found")
    | (y, v) :: r -> if x = y then v else lookup r x

//(i) & (v)
let rec eval e (env : (string * int) list) : int = 
    match e with
    | CstI i -> i
    | Var x -> lookup env x
    | Prim("+", e1, e2) -> eval e1 env + eval e2 env
    | Prim("*", e1, e2) -> eval e1 env * eval e2 env
    | Prim("-", e1, e2) -> eval e1 env - eval e2 env
    | Prim("max", e1, e2) -> max (eval e1 env) (eval e2 env)
    | Prim("min", e1, e2) -> min (eval e1 env) (eval e2 env)
    | Prim("==", e1, e2) -> 
        if (eval e1 env) = (eval e2 env) then 1
        else 0
    | If(e1, e2, e3) -> 
        if (eval e1 env) <> 0 then (eval e2 env)
        else (eval e3 env)
    | Prim _ -> failwith "unknown primitive"

//(ii)
let example1 = Prim("min", Prim("*", CstI 7, CstI 9), CstI 10) //10 : expected result
let example2 = Prim("max", CstI 2, CstI 6)                     //6  : expected result
let example3 = Prim("==", CstI 6, CstI 6)                      //1  : expected result
let example4 = Prim("==", CstI 10, CstI 6)                     //0  : expected result
let example5 = Prim("max", CstI 100, CstI 6)                   //100: expected result

//(iii)
let rec evalBranch e (env : (string * int) list) : int = 
    match e with
    | CstI i -> i
    | Var x -> lookup env x
    | If(e1, e2, e3) -> 
        if (eval e1 env) <> 0 then (eval e2 env)
        else (eval e3 env)
    | Prim(ope, e1, e2) -> 
        let eval1 = evalBranch e1 env
        let eval2 = evalBranch e2 env
        match ope with
        | "*" -> eval1 * eval2
        | "-" -> eval1 - eval2
        | "max" -> max eval1 eval2
        | "min" -> min eval1 eval2
        | "==" -> 
            if eval1 = eval2 then 1
            else 0
        | _ -> failwith "unknown primitive"

//(iv)
//See type declaration at the top.

//(v)
//See (i) above.

//Test:
let testEnv1 = [ ("a", 0) ]
let testEnv2 = [ "a", 100 ]
let test = If(Var "a", CstI 11, CstI 22)
let result1 = eval test testEnv1
let result2 = eval test testEnv2

//-----
// 1.2
//-----

//(i)
type aexpr = 
    | CstI of int
    | Var of string
    | Add of aexpr * aexpr
    | Mul of aexpr * aexpr
    | Sub of aexpr * aexpr

//(ii)
let first = Sub(Var "z", Add(Var "w", Var("z")))
let second = Mul(CstI 2, Sub(Var "v", Add(Var "w", Var "z")))
let third = Add(Var "x", Add(Var "y", Add(Var "z", Var "v")))

//(iii)
let rec fmt aexpr = 
    match aexpr with
    | CstI i             -> i.ToString()
    | Var x              -> x
    | Add(first, second) -> "(" + (fmt first) + " + " + (fmt second) + ")"
    | Mul(first, second) -> "(" + (fmt first) + " * " + (fmt second) + ")"
    | Sub(first, second) -> "(" + (fmt first) + " - " + (fmt second) + ")"

//(iv)
let simplify aexpr : aexpr = 
    match aexpr with
    | Sub(f, s)             -> if   f = s       then CstI 0
                               elif fmt f = "0" then s
                               elif fmt s = "0" then f
                               else aexpr
    | Add(f, s)             -> if   fmt f = "0" then s
                               elif fmt s = "0" then f
                               else aexpr
    | Mul(f, s)             -> if   fmt first = "0" || fmt second = "0" then CstI 0
                               elif fmt first = "1"                     then second
                               elif fmt second = "1"                    then first
                               else aexpr
    | _                     -> aexpr


//(v)
//TODO: Finish exercise.
//What is Symbolic Differentiation?


//-----
// 1.4
//-----
//TODO: Finish exercise (ugh, Java)


//-----
// 2.1
//-----
type expr2 =
    | CstI of int
    | Var of string
    | Let of (string * expr2) list * expr2
    | Prim of string * expr2 * expr2
    
let rec eval2 e (env : (string * int) list) : int =
    match e with
    | CstI i                -> i
    | Var x                 -> lookup env x 
    | Let(list, body)       -> let evaluated = List.foldBack (fun (x, right) env -> (x, eval2 right env)::env) list env
                                               //Should this be List.fold? 
                               evaluated |> eval2 body 
    | Prim("+", e1, e2)     -> eval2 e1 env + eval2 e2 env
    | Prim("*", e1, e2)     -> eval2 e1 env * eval2 e2 env
    | Prim("-", e1, e2)     -> eval2 e1 env - eval2 e2 env
    | Prim _                -> failwith "unknown primitive";;


//-----
// 2.2
//-----
let rec mem x vs = 
    match vs with
    | []      -> false
    | v :: vr -> x=v || mem x vr

let rec union (xs, ys) =
    match xs with
    | [] -> ys
    | x::xr -> if mem x ys then union(xr, ys) else x :: union(xr, ys)

let rec minus (xs, ys) =
    match xs with
    | [] -> []
    | x::xr -> if mem x ys then minus(xr, ys) else x :: minus (xr, ys)

//Exercise solution:
let rec freevars2 e : string list =
    match e with
    | CstI i -> []
    | Var x -> [x]
    | Let(list, body) -> List.foldBack (fun (x, erhs) list -> union (freevars2 erhs, minus (freevars2 body, [x])))  list []
    | Prim(ope, e1, e2) -> union (freevars2 e1, freevars2 e2)

//-----
// 2.3
//-----
type texpr =
    | TCstI of int
    | TVar of int
    | TLet of texpr * texpr
    | TPrim of string * texpr * texpr

let rec getindex vs x = 
    match vs with 
    | []    -> failwith "Variable not found"
    | y::yr -> if x=y then 0 else 1 + getindex yr x

//Exercise solution:
let rec tcomp2 (e : expr2) (cenv : string list) : texpr =
    match e with
    | CstI i                -> TCstI i
    | Var x                 -> TVar (getindex cenv x)
    | Let(list, ebody)      -> List.foldBack (fun (x, erhs) cenv -> TLet(tcomp2 erhs cenv, tcomp2 ebody (x :: cenv))) list cenv //I tried. 
    | Prim(ope, e1, e2)     -> TPrim(ope, tcomp2 e1 cenv, tcomp2 e2 cenv)

[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    0 // return an integer exit code
