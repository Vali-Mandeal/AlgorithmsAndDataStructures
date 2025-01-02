namespace _03_SumOfNNumbers;

class Program
{
    private static int GetSumOfNNumbersWithMathFormula(int n)
    {
        int result = n * (n + 1) / 2;
        return result;
    }
    
    private static int GetSumOfNNumbersRecursively(int n)
    {
        if (n == 0)
            return 0;
        
        return GetSumOfNNumbersRecursively(n - 1) + n;
    }

    private static int GetSumOfNNumbersIteratively(int n)
    {
        int sum = 0;

        for (int i = n; i > 0; i--)
        {
            sum += i;
        }

        return sum;
    }
    
    static void Main(string[] args)
    {
        int mathResult = GetSumOfNNumbersWithMathFormula(5);
        Console.WriteLine(mathResult);
        
        int recursiveResult = GetSumOfNNumbersRecursively(5);
        Console.WriteLine(recursiveResult);
        
        int iterativeResult = GetSumOfNNumbersIteratively(5);
        Console.WriteLine(iterativeResult);
    }
}