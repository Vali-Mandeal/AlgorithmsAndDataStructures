using System.Security.Principal;

namespace _01_LinkedList;

public class Node
{
    public int Value { get; set; }
    public Node? Next { get; set; } 
}

public partial class LinkedList
{
    private Node? _head;
    private Node? _tail;
    private int _size;

    public bool IsEmpty() => _size == 0;
    public int GetLength() => _size;
    
    public partial void InsertInSortedOrder(int value);
    public partial void InsertFirst(int value);
    public partial void InsertLast(int value);
    public partial void InsertAtIndex(int index, int value);
    public partial void RemoveFirst();
    public partial void RemoveLast();
    public partial void RemoveAtIndex(int index);

    public partial int LinearSearch(int value);
    public partial void MergeSort();


    public partial void Print();
}

class Program
{
    static void Main(string[] args)
    {
        LinkedList list = new LinkedList();

        list.InsertFirst(55);
        list.InsertFirst(44);
        list.InsertFirst(3);
        list.InsertFirst(1);
        list.InsertFirst(9);
        list.InsertFirst(100);
        list.InsertFirst(200);
        
        list.MergeSort();

        list.Print();
    }
}