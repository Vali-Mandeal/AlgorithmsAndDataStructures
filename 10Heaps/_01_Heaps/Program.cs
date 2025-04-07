namespace _01_Heaps;

class Program
{
    static void Main(string[] args)
    {
        var heap = new MaxHeap(10);
        
        heap.Insert(1);
        heap.Insert(5);
        heap.Insert(10);
        heap.Insert(15);

        Console.WriteLine($"Extract value {heap.Extract()}");

        heap.Print();
        
        Console.WriteLine($"Extract value {heap.Extract()}");

        heap.Print();
        
        Console.WriteLine($"Extract value {heap.Extract()}");

        heap.Print();
        
        Console.WriteLine($"Extract value {heap.Extract()}");

        heap.Print();
    }
}