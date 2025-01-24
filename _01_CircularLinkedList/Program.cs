namespace _01_CircularLinkedList;

public class Node
{
    public int Value { get; set; }
    public Node? Next { get; set; }
}

public partial class LinkedList
{
    private Node _head { get; set; }
    private Node _tail { get; set; }

    private int _size = 0;
    
    public bool IsEmpty() => _size == 0;
    public int GetLength() => _size;

    public partial void InsertLast(int value);

    public partial void InsertFirst(int value);
    public partial void Insert(int value, int index);

    public partial void RemoveFirst();

    public partial void RemoveLast();
    public partial void Remove(int index);
    
    public void Print(int times)
    {
        if (IsEmpty())
        {
            Console.WriteLine("List is empty.");
            return;
        }
    
        var current = _head;
        for (var i = 0; i < times; i++)
        {
            do
            {
                Console.Write(current!.Value + " => ");
                current = current.Next;
            } while (current != _head);
        }

        Console.WriteLine();
    }
}   



class Program
{
    static void Main(string[] args)
    {
        LinkedList list = new LinkedList();
        list.InsertLast(0);
        list.InsertLast(1);
        list.InsertLast(2);
        list.InsertLast(3);
        
        list.Print(2);

        list.Remove(-2);
        list.Print(2);
    }
}