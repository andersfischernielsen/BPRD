//Assignment 7.2 

//(i)
void histogram(int n, int ns[], int max, int freq[]) {
	int i; i = 0;
	
	while (i < n) {
		int current; current = ns[i];
		
		if (current <= max) {
			freq[current] = freq[current] + 1;
		}
		i = i + 1;
	}
}

void main() {
	int arr[5];
	
	arr[0] = 0;
	arr[1] = 1;
	arr[2] = 1;
	arr[3] = 2;
	arr[4] = 3;
	
	int freq[4];
	freq[0] = 0; freq[1] = 0; freq[2] = 0; freq[3] = 0;
	
	int max; max = 3;
	histogram(5, arr, max, freq);
	
	int i; i = 0;
	while (i <= max) {
		print freq[i];
		i = i + 1;
	}
}