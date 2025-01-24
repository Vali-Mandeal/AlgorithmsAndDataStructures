namespace _04_Factorial;

class Program
{
    static int FactorialRecursive(int n)
    {
        if (n == 1)
            return 1;

        return FactorialRecursive(n - 1) * n;
    }

    static int FactorialIterative(int n)
    {
        int factorial = 1;
        for (int i = 1; i <= n; i++)
        {
            factorial = factorial * i;
        }
        
        return factorial;
    }
    
    static void Main(string[] args)
    {
        int factorialResult = FactorialRecursive(5);
        Console.WriteLine(factorialResult);
        
        int factorialIterativeResult = FactorialIterative(5);
        Console.WriteLine(factorialIterativeResult);
    }
}