namespace _02SearchingAlgorithms;

class Program
{
    static void Main(string[] args)
    {
        int[] array = [22, 5, 3, 2, 8];

        int searchResult = search(array, 8);
        
        Console.WriteLine(searchResult);
    }

    static int search(int[] array, int value)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == value)
                return i;
        }
        
        return -1;
    }
}