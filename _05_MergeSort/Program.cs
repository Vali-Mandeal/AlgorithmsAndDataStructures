namespace _05_MergeSort;

class Program {

    public static void Merge(int[] A, int left, int mid, int right)
    {
        int i = left;    // left index
        int j = mid + 1; // right index
        int k = left;    // new array index
        int[] B = new int[right + 1]; // new array
        
        while (i <= mid && j <= right)
        {
            if (A[i] < A[j])
            {
                B[k] = A[i];
                i++;
            }
            else
            {
                B[k] = A[j];
                j = j + 1;
            }
            k++;
        }
        while (i <= mid)
        {
            B[k] = A[i];
            i++;
            k++;
        }
        while (j <= right)
        {
            B[k] = A[j];
            j = j + 1;
            k++;
        }
        for (int x = left; x < right + 1; x++)
            A[x] = B[x];
    }

    // Main function that
    // sorts arr[l..r] using
    // merge()
    static void MergeSort(int[] arr, int left, int right)
    {
        if (left < right) {

            // Find the middle point
            int mid = (left + right) / 2;

            // Sort first and second halves
            MergeSort(arr, left, mid);
            MergeSort(arr, mid + 1, right);

            // Merge the sorted halves
            Merge(arr, left, mid, right);
        }
    }
    
    static void PrintArray(int[] arr)
    {
        int n = arr.Length;
        
        for (int i = 0; i < n; ++i)
            Console.Write(arr[i] + " ");
        
        Console.WriteLine();
    }

    // Driver code
    public static void Main(String[] args)
    {
        int[] arr = { 44, 33, 11, 55, 66, 77 };
        
        Console.WriteLine("Given array is");
        PrintArray(arr);
        
        MergeSort(arr, 0, arr.Length - 1);
        
        Console.WriteLine("\nSorted array is");
        PrintArray(arr);
    }
}