module Absyn

type re = 
    | Char of char
    | Eps
    | Seq of re * re
    | Star of re
    | Choice of re * re