namespace _02_InsertionSort;

class Program
{
    private static void InsertionSort(int[] arr)
    {
        for (int i = 1; i < arr.Length; i++)
        {
            // int j = i;
            // while (j > 0 && arr[j - 1] > arr[j])
            // {
            //     Swap(arr, j, j - 1);
            //     j--;
            // }
            
            for (int j = i; j > 0; j--)
            {
                if (arr[j - 1] < arr[j])
                    break;
                
                Swap(arr, j, j - 1);
            }
        }
    }
    
    static void Swap(int[] array, int i, int j)
    {
        (array[i], array[j]) = (array[j], array[i]);
    }
    
    static void Main(string[] args)
    {
        int[] arr = { 3, 5, 8, 9, 6, 2 };
        
        InsertionSort(arr);

        foreach (var item in arr)
        {
            Console.Write(item + " ");
        }
    }
}