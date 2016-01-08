module Generate

type re = Char of char
        | Eps
        | Seq of re * re
        | Star of re
        | Choice of re * re

type state = int
type sym = SEps | SChar of char
type nfa = {
    start: state;
    accept: state;
    trans: (state * sym * state) list
}

let currentState = ref 0
let newState () = (currentState := !currentState + 1; !currentState)

let firstFromTuple (t, _, _) = t

let rec generateTransFromRe re : (state * sym * state) list =
    let parseChoice c1 c2 =
        let current = !currentState
        let toFirst = (current, SEps, newState ())
        let first = generateTransFromRe r1
        let firstEnd = !currentState
        let toSecond = (current, SEps, newState ())
        let second = generateTransFromRe r2
        let secondEnd = !currentState
        let sharedEnd = newState()
        toFirst :: first @ [(firstEnd, SEps, sharedEnd)] @
        toSecond :: second @ [(secondEnd, SEps, sharedEnd)]

    match re with
        | Char c            -> [(!currentState, SChar c, newState ())]
        | Eps               -> [(!currentState, SEps, newState ())]
        | Seq (r1, r2)      -> generateTransFromRe r1
                               @ [(!currentState, SEps, newState ())]
                               @ generateTransFromRe r2
        | Star r            -> let e = generateTransFromRe r
                               let first = List.head e
                               e @ [(!currentState, SEps, firstFromTuple first)]
        | Choice (r1, r2)   -> parseChoice r1 r2

let makeNFA re =
    let start = !currentState
    let transitions = generateTransFromRe re
    { start = start; accept = !currentState; trans = transitions }
