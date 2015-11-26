//
//Assignment 9
//


//Exercise 9.1 (PLC 10.1):
//(i) Write 3-10 line descriptions of how the abstract machine executes each of the following instructions:
ADD: ADD untags the two topmost values on the stack (in order to be able to operate on them), adds them, and then tags the result. This result value is then set as the second topmost value on the stack, and the stack pointer is decreased.

CSTI: CSTI i grows the stack by one, takes the input i and tags it and stores it on the stack.

NIL: NIL grows the stack by one, and sets the topmost value to be 0. The value is therefore an empty reference.

IFZERO: IFZERO takes the second-topmost element of the stack. If this value is an int and not a reference, it untags the ref. and checks whether the value is 0, otherwise it checks whether the value is 0. If either of these return 1 (true), run the next instruction. If not, skip the instruction by adding one to the program counter.

CONS: CONS allocates memory for an array of two words. It then adds the current two topmost values to the generated word array. Finally the word array is put on the top of the stack, replacing the two values.

CAR: CAR retrieves the topmost cons cell from the stack (provided that there's a cons cell on top of the stack), and replaces the cons cell with the car value of the cell. 

SETCAR: SETCAR sets the car value of the topmost cons cell on the stack from the second topmost cons cell.


//(ii)
	hdr = ttttttttnnnnnnnnnnnnnnnnnnnnnngg

Length: 
	hdr >>2 
	= 
	00ttttttttnnnnnnnnnnnnnnnnnnnnnn

	0x003FFFFF 
	= 
	00000000001111111111111111111111
	
	00000000001111111111111111111111
	&
	00ttttttttnnnnnnnnnnnnnnnnnnnnnn
	=
	0000000000nnnnnnnnnnnnnnnnnnnnnn
	
Color:  
	3 
	= 
	00000000000000000000000000000011
	
	ttttttttnnnnnnnnnnnnnnnnnnnnnngg
	&
	00000000000000000000000000000011
	=
	000000000000000000000000000000gg
	

Paint:  	
	~3 
	=
	11111111111111111111111111111100
	
	ttttttttnnnnnnnnnnnnnnnnnnnnnngg
	&
	11111111111111111111111111111100
	= 
	ttttttttnnnnnnnnnnnnnnnnnnnnnn00

	ttttttttnnnnnnnnnnnnnnnnnnnnnn00
	| 
	000000000000000000000000000000cc
	=
	ttttttttnnnnnnnnnnnnnnnnnnnnnncc
	

//(iii)
No. When a cons cell should be allocated, the listmachine tries to allocate memory. The only other interaction with the mutator and garbage collector happens when there's not any free space for allocation (see iv).

//(iv)
The collect() function will be called when the listmachine is unable to allocate memory in the heap. The heap must therefore be full, and a garbage collection is needed. 


//Exercise 9.2:
See listmachine.c for implementation. 
I need some hint to solve this (see code).

//Exercise 9.3:
Not finished.
