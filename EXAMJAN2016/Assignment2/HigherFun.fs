(* A functional language with integers and higher-order functions
   sestoft@itu.dk 2009-09-11

   The language is higher-order because the value of an expression may
   be a function (and therefore a function can be passed as argument
   to another function).

   A function definition can have only one parameter, but a
   multiparameter (curried) function can be defined using nested
   function definitions:

      let f x = let g y = x + y in g end in f 6 7 end
 *)

module HigherFun

open Absyn

(* Environment operations *)

type 'v env = (string * 'v) list

let rec lookup env x =
    match env with
    | []        -> failwith (x + " not found")
    | (y, v)::r -> if x=y then v else lookup r x;;

(* A runtime value is an integer or a function closure *)

type value =
  | Int of int
  | Closure of string * string * expr * value env       (* (f, x, fBody, fDeclEnv) *)
  | RefVal of value ref

let rec eval (e : expr) (env : value env) : value =
    match e with
    | CstI i -> Int i
    | CstB b -> Int (if b then 1 else 0)
    | Var x  -> lookup env x
    | Prim(ope, e1, e2) ->
      let v1 = eval e1 env
      let v2 = eval e2 env
      match (ope, v1, v2) with
      | ("*", Int i1, Int i2) -> Int (i1 * i2)
      | ("+", Int i1, Int i2) -> Int (i1 + i2)
      | ("-", Int i1, Int i2) -> Int (i1 - i2)
      | ("=", Int i1, Int i2) -> Int (if i1 = i2 then 1 else 0)
      | ("<", Int i1, Int i2) -> Int (if i1 < i2 then 1 else 0)
      |  _ -> failwith "unknown primitive or wrong type"
    | Let(x, eRhs, letBody) ->
      let xVal = eval eRhs env
      let letEnv = (x, xVal) :: env
      eval letBody letEnv
    | If(e1, e2, e3) ->
      match eval e1 env with
      | Int 0 -> eval e3 env
      | Int _ -> eval e2 env
      | _     -> failwith "eval If"
    | Letfun(f, x, fBody, letBody) ->
      let bodyEnv = (f, Closure(f, x, fBody, env)) :: env
      eval letBody bodyEnv
    | Call(eFun, eArg) ->
      let fClosure = eval eFun env
      match fClosure with
      | Closure (f, x, fBody, fDeclEnv) ->
        let xVal = eval eArg env
        let fBodyEnv = (x, xVal) :: (f, fClosure) :: fDeclEnv
        in eval fBody fBodyEnv
      | _ -> failwith "eval Call: not a function"
    | Ref e -> RefVal (ref (eval e env))
    | Deref e ->
      let v = eval e env
      match v with
      | RefVal v' -> !v'
      | _         -> failwith "%A is not a reference type." v
    | UpdRef(e1, e2) ->
      let v1 = eval e1 env
      match v1 with
      | RefVal v1' -> let v2 = eval e2 env
                      v1' := v2
                      v2
      | _          -> failwith "%A is not a reference type." e1

(* Evaluate in empty environment: program must have no free variables: *)

let run e = eval e [];;

(* Examples in abstract syntax *)

let ex1 = Letfun("f1", "x", Prim("+", Var "x", CstI 1),
                 Call(Var "f1", CstI 12));

(* Factorial *)

let ex2 = Letfun("fac", "x",
                 If(Prim("=", Var "x", CstI 0),
                    CstI 1,
                    Prim("*", Var "x",
                              Call(Var "fac",
                                   Prim("-", Var "x", CstI 1)))),
                 Call(Var "fac", Var "n"));

(* let fac10 = eval ex2 [("n", Int 10)];; *)

let ex3 =
    Letfun("tw", "g",
           Letfun("app", "x", Call(Var "g", Call(Var "g", Var "x")),
                  Var "app"),
           Letfun("mul3", "y", Prim("*", CstI 3, Var "y"),
                  Call(Call(Var "tw", Var "mul3"), CstI 11)));;

let ex4 =
    Letfun("tw", "g",
           Letfun("app", "x", Call(Var "g", Call(Var "g", Var "x")),
                  Var "app"),
           Letfun("mul3", "y", Prim("*", CstI 3, Var "y"),
                  Call(Var "tw", Var "mul3")));;

(* let add1 x = x + 1 in add1 end *)
let add1 = Letfun("add1", "x",
                  Prim("+", Var "x", CstI 1),
                  Var "add1")
let add1C = eval add1 []
let add1with2 = eval (Call(Var "add1C", CstI 2)) [("add1C",add1C)]

(* let tw g = let app y = g (g y) in app end in tw end *)
let tw =
  Letfun("tw", "g",
    Letfun("app", "y", Call(Var "g", Call(Var "g", Var "y")), Var "app"),
    Var "tw")
let twC = eval tw []


let twAdd1C = eval (Call(Var "tw", Var "add1")) [("tw",twC);("add1",add1C)]
let res = eval (Call(Var "twAdd1C", CstI 1)) [("twAdd1C",twAdd1C)]
