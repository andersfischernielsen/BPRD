//Assignment 7.2 

//(i)
void arrsum(int n, int arr[], int *sump) {
	int i; i = 0;
	int sum; sum = 0;
	
	while (i < n) {
		sum = sum + arr[i];
		i = i + 1; 
	}
	
	*sump = sum;
}

//(ii)
void squares(int n, int arr[]) {
	int i; i = 0;
	
	while (i < n) {
		arr[i] = i*i;
		i = i + 1; 
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