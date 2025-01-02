namespace _01Recursion;

class Program
{
    static void Main(string[] args)
    {
        // CalculateSquareIteratively(4);
        CalculateSquareRecursively(4);
    }

    private static void CalculateSquareIteratively(int n)
    {
        while (n > 0)
        {
            int square = n * n;
            Console.WriteLine(square);

            n--;
        }
    }

    private static void CalculateSquareRecursively(int n)
    {
        if (n <= 0)
            return;
        
        int square = n * n;
        Console.WriteLine(square);
        
        CalculateSquareRecursively(n -1);
    }
    
}