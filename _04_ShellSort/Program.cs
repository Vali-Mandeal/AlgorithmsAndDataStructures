namespace _04_ShellSort;

class Program
{
    static void Main(string[] args)
    {
        int[] array = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
        
        ShellSort(array);
        ShellSort2(array);
        
        
        Console.WriteLine("Sorted array:");
        foreach (int item in array)
        {
            Console.Write(item + " ");
        }
    }

    static void ShellSort(int[] array)
    {
        int n = array.Length;
        for (int gap = n / 2; gap > 0; gap /= 2)
        {
            for (int i = gap; i < n; i++)
            {
                int temp = array[i];
                int j = i;
                while (j >= gap && array[j - gap] > temp)
                {
                    array[j] = array[j - gap];
                    j -= gap;
                }
                array[j] = temp;
            }
        }
    }

    static void ShellSort2(int[] array)
    {
        int n = array.Length;
        int gap = n / 2;
        
        while (gap > 0)
        {
            int i = gap;
            while (i < n)
            {
                int temp = array[i];
                int j = i;
                while (j >= gap && array[j - gap] > temp)
                {
                    array[j] = array[j - gap];
                    j -= gap;
                }
                array[j] = temp;
                i++;
            }
            gap /= 2;
        }
    }
}