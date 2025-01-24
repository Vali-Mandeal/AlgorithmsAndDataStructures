namespace _01_LinkedList;

public partial class LinkedList
{
    public partial void Print()
    {
        Node? current = _head;
        while (current != null) 
        {
            Console.Write(current.Value + " => ");
            current = current.Next!;
        }
        
        Console.WriteLine();
    }
}