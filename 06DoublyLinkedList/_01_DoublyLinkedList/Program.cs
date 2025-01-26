namespace _01_DoublyLinkedList;

public class Node
{
    public Node? Next { get; set; }
    public Node? Previous { get; set; }
    public int Value { get; set; }
}

public partial class LinkedList
{
    private Node? _head;
    private Node? _tail;

    private int _size = 0;

    public bool IsEmpty() => _size == 0;
    public int GetLength() => _size;

    public partial void AddFirst(int value);
    public partial void AddLast(int value);
    public partial void Add(int value, int index);
    public partial void RemoveFirst();
    public partial void RemoveLast();
    public partial void Remove(int index);

    public void PrintAscending()
    {
        if (IsEmpty())
        {
            Console.WriteLine("The list is empty");
            return;
        }

        Console.WriteLine("Ascending: ");

        Node? current = _head;
        Console.Write("null <= ");

        while (current != null)
        {
            if (current.Next == null)
            {
                Console.Write(current.Value + " => null");
            }
            else
            {
                Console.Write(current.Value + " <=> ");
            }

            current = current.Next;
        }

        Console.WriteLine();
    }
    public void PrintDescending()
    {
        if (IsEmpty())
        {
            Console.WriteLine("The list is empty");
            return;
        }

        Console.WriteLine("Descending: ");

        Node? current = _tail;
        Console.Write("null <= ");

        while (current != null)
        {
            if (current.Previous == null)
            {
                Console.Write(current.Value + " => null");
            }
            else
            {
                Console.Write(current.Value + " <=> ");
            }

            current = current.Previous;
        }

        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        LinkedList list = new LinkedList();

        list.AddLast(0);
        list.AddLast(1);
        list.AddLast(2);
        list.AddLast(3);

        list.Remove(0);

        list.PrintAscending();
        list.PrintDescending();
    }
}