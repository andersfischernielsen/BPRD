public class Lol {
	public static void SelectionSort(int[] arr) {
		for (int i = 0; i < arr.Length; i++) {
			int least = i;
			for (int j = i+1; j < arr.Length; j++) {
				if (arr[j] < arr[least]) {
					least = j;
				}
			}
			
			int tmp = arr[i]; arr[i] = arr[least]; arr[least] = tmp;
		}
	}
	
	static void Main() {
		int[] array = { 5, 2, 1, 4, 3 };
		SelectionSort(array);
	}
}