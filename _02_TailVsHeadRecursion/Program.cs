namespace _02_TailVsHeadRecursion;

/// <summary>
/// Calculating square for n-1 using both tail and head recursion
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Calling calculate square head:");
        CalculateSquareHead(4);

        Console.WriteLine();

        Console.WriteLine("Calling calculate square tail:");
        CalculateSquareTail(4);
    }

    // result: 1 4 9 16 
    private static void CalculateSquareHead(int n)
    {
        if (n > 0)
        {
            // The recursive call is always the first
            // That's why it's called "head"
            CalculateSquareHead(n - 1);
            
            int result = n * n;
            Console.Write(result + " ");
        }
    }
    
    // result: 16 9 4 1 
    private static void CalculateSquareTail(int n)
    {
        if (n > 0)
        {
            int result = n * n;
            Console.Write(result + " ");
            
            // the recursive call is always the last
            // That's why it's called "tail"
            CalculateSquareTail(n - 1);
        }
    }
}