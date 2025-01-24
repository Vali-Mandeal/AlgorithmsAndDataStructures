namespace _06_Quicksort;

class Program
{
    static void Main(string[] args)
    {
        int[] arr = { 5, 3, 8, 4, 2, 7, 1, 9, 10 };
        QuickSort(arr, 0, arr.Length - 1);
        
        Console.WriteLine(string.Join(" ", arr));
    }

    private static void QuickSort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int pivot = HearoesPartition(arr, left, right);
            
            QuickSort(arr, left, pivot - 1);
            QuickSort(arr, pivot + 1, right);
        }
    }

    /// <summary>
    /// This is the fastest of all.
    /// Here we traverse array from both sides and keep swapping greater element on left
    /// with smaller on right while the array is not partitioned. 
    /// </summary>
    /// <param name="array"></param>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    private static int HearoesPartition(int[] arr, int left, int right)
    {
        int pivot = arr[left];
        int i = left - 1;
        int j = right + 1;
        
        while (true)
        {
            do i++;// find the next element smaller than the pivot from left to right
            while (arr[i] < pivot);

            do j--;// find the next element greater than the pivot from right to left
            while (arr[j] > pivot);
        
            if (i >= j)
                return j; // if i and j crosses, it means pivot is in it's sorted position, so no swapping required
            
            Swap(arr, i, j);
        }
    }
    
    /// <summary>
    /// This is a simple algorithm, we keep track of index of smaller elements and keep swapping. 
    /// </summary>
    /// <param name="array"></param>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    private static int LomutoPartition(int[] array, int left, int right)
    {
        int pivot = array[right];
        int i = left - 1;
    
        for (int j = left; j < right; j++)
        {
            if (array[j] <= pivot)
            {
                i++;
                Swap(array, i, j);
            }
        }
    
        Swap(array, i + 1, right);
        return i + 1;
    }
    
    /// <summary>
    /// Here we create copy of the array.
    /// First put all smaller elements and then all greater.
    /// Finally we copy the temporary array back to original array.
    /// This requires O(n) extra space.
    /// </summary>
    /// <param name="array"></param>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    private static int NaivePartition(int[] array, int left, int right)
    {
        int pivot = array[right];
        int[] temp = new int[right - left + 1];
        int idx = 0;
    
        // First fill elements smaller than or equal to pivot
        for (int i = left; i <= right; i++)
        {
            if (array[i] <= pivot)
                temp[idx++] = array[i];
        }
    
        // Now fill the elements greater than pivot
        for (int i = left; i <= right; i++)
        {
            if (array[i] > pivot)
                temp[idx++] = array[i];
        }
    
        // Copy the elements from temp to array
        for (int i = 0; i < temp.Length; i++)
        {
            array[left + i] = temp[i];
        }
    
        // Return the pivot index
        return left + idx - 1;
    }

    private static void Swap(int[] array, int a, int b)
    {
        int temp = array[a];
        array[a] = array[b];
        array[b] = temp;
    }
}