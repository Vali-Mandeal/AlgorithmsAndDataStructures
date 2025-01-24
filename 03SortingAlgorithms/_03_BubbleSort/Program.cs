namespace _03_BubbleSort;

class Program
{
    private static void BubbleSort(int[] array)
    {
        int n = array.Length;
        int runs = 0;
        
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n - 1; j++)
            {
                runs ++;
                if (array[j] > array[j + 1])
                    Swap(array, j, j + 1);
            }
        }
        System.Console.WriteLine("Runs: " + runs);
    }

    private static void BubbleSortOptimized(int[] array)
    {
        int n = array.Length;
        int runs = 0;
        
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                runs ++;
                if (array[j] > array[j + 1])
                    Swap(array, j, j + 1);
            }
        }
        System.Console.WriteLine("Runs: " + runs);
    }
    private static void Swap(int[] array, int a, int b)
    {
        int temp = array[a];
        array[a] = array[b];
        array[b] = temp;
    }

    static void Main(string[] args)
    {
        int[] array = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
        
        BubbleSort(array);
        Console.WriteLine("Bubble Sort: " + string.Join(", ", array));
        
        BubbleSortOptimized(array);
        Console.WriteLine("Bubble Sort Optimized: " + string.Join(", ", array));
    }
}