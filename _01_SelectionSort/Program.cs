namespace _01_SelectionSort;

class Program
{
    static void SelectionSort(int[] array)
    {
        int n = array.Length;
        
        // i will be the start of the unsorted subarray
        // whatever is left "behind" is the sorted subarray
        for (int i = 0; i < n - 1; i++) 
        {
            int minIndex = i;   

            for (int j = i + 1; j < n; j++) // this loop finds the min value in the unsorted subarray
            {
                if (array[j] < array[minIndex])
                    minIndex = j;
            }
            
            Swap(array, minIndex, i); // swaps the min value with the current outer loop index value
        }
    }

    static void Swap(int[] array, int i, int j)
    {
        (array[i], array[j]) = (array[j], array[i]);
    }
    
    static void Main(string[] args)
    {
        int[] array = { 64, 25, 12, 22, 11 };
        
        SelectionSort(array);
        
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
    }
}