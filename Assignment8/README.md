//
//Assignment 8
//

//Exercise 8.1:
Due to the fact that I fomatted my code (added brackets instead of Sestoft's for loops without brackets), my CIL bytecode has tmp stored as variable number 3 instead of variable number 2. 
Anders Wind and I discovered this when comparing out bytecode, with his original Sestoft for-loops.
the compiler apparently handles the storing of variables differently when brackets are present. 
The rest of the bytecode is identical, though. 

In the java bytecode it is worth noting that I also added brackets, and that the compiler knows that j is out of scope when assigning the variable tmp later on, which is kinda cool. 


//Exercise 8.2:
The badly written string concatenation example stresses the garbage collector immensely, due to the fact that "string1" + "string2" creates a new string. It doesn't just append the second string to the first one like StringBuilder does. Therefore the two previous strings have to be garbage collected, since they're of no use after we store the new concatenated string. 
The garbage collector has to trash two objects every time the loop runs, which is.. bad. 
Using a StringBuilder appends the strings "as they are", which means that the garbage collector just has to trash the variables once when ToString is called on the StringBuilder and the final string is created. This is way better.