public class Lol {
	public static void SelectionSort(int[] arr) {
		for (int i = 0; i < arr.length; i++) {
			int least = i;
			for (int j = i+1; j < arr.length; j++) {
				if (arr[j] < arr[least]) {
					least = j;
				}
			}
			
			int tmp = arr[i]; arr[i] = arr[least]; arr[least] = tmp;
		}
	}
	
	static void Main(String[] args) {
		int[] array = { 5, 2, 1, 4, 3 };
		SelectionSort(array);
	}
}