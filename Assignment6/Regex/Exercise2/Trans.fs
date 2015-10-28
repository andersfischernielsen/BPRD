module Trans
    type state = int
    
    type sym = 
          SEps 
        | SChar of char
        
    type nfa =
        { 
            start  : state;
            accept : state;
            trans  : (state * sym * state) list
        }
        
        
    let order nfa = 
        let extract (a, b, _) = a, b
        let sorted = Seq.sortBy (fun s -> extract s) nfa.trans 
                     |> List.ofSeq
                    
        { start = nfa.start; accept = nfa.accept; trans = sorted }
        
    let test1 = 
        let s1 = { start = 0; 
                   accept = 1; 
                   trans = [ 
                             (0, SChar 'b', 1);
                             (0, SChar 'a', 2);
                             (1, SChar 'p', 4);
                             (4, SChar 'x', 1);
                             (4, SChar 'y', 5);
                             (2, SChar 'e', 3);
                             (2, SChar 'i', 1);
                             (3, SChar 'i', 2);
                             (3, SChar 'a', 4) 
                           ]
                 }
        order s1
    
    
    let isDfa nfa = 
        let trans = nfa.trans
        let noEps = List.forall (fun (_, b, _) -> b <> SEps) trans
        let rec sameSym list =
            let allDifferent f s l = 
                List.forall (fun (a2, b2, _) -> f <> a2 && s <> b2) l
            
            match list with 
            | (a, b, _)::xs -> if allDifferent a b xs
                               then sameSym xs
                               else false
            | []            -> true
            
        noEps && (sameSym trans)
        
    let test2 = 
        let dfa = { start = 0; 
                    accept = 1; 
                    trans = [ 
                              (0, SChar 'a', 1); 
                              (0, SChar 'a', 2)
                            ] 
                  }
        isDfa dfa