//Assignment 7.2 

//(i)
void arrsum(int n, int arr[], int *sump) {
	int sum; sum = 0;
	
	int i;
	for(i = 0; i < n; i = i + 1) {
		sum = sum + arr[i];
	}
	
	*sump = sum;
}

//(ii)
void squares(int n, int arr[]) {
	int i;
	for(i = 0; i < n; i = i + 1) {
		arr[i] = i*i;
	}
}

void main(int n) {	
	int arr[20];
	
	squares(n, arr);
	
	int sum;
	arrsum(n, arr, &sum);
	
	print sum;
	println;
}