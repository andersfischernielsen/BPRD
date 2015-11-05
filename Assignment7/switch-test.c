void main() {
    int i;
    i = 0;
    int j;

    switch (++i) {
   	    case 0: { j = 2; }
   	    case 1: { j = 1; }
   	    case 2: { j = 0; }
    }

    print j;
}
