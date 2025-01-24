namespace _02_BinarySearch;

class Program
{
    static void Main(string[] args)
    {
        int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        
        var binarySearchRecursiveResult = BinarySearchRecursive(array, 10, 0, array.Length - 1);
        Console.WriteLine(binarySearchRecursiveResult);

        var binarySearchIterativeResult = BinarySearchIterative(array, 10);
        Console.WriteLine(binarySearchIterativeResult);
    }

    private static int BinarySearchIterative(int[] array, int value)
    {
        int left = 0;
        int right = array.Length - 1;

        while (left <= right)
        {
            int middle = left + (right - left) / 2;

            if (value == array[middle])
                return middle;
            if (value < array[middle])
                right = middle - 1;
            else
                left = middle + 1;
        }

        return -1; // Value not found
    }

    private static int BinarySearchRecursive(int[] array, int value, int left, int right)
    {
        if (left > right)
            return -1; // Value not found

        int middle = left + (right - left) / 2;

        if (value == array[middle])
            return middle;
        if (value < array[middle])
            return BinarySearchRecursive(array, value, left, middle - 1);
        else
            return BinarySearchRecursive(array, value, middle + 1, right);
    }
}