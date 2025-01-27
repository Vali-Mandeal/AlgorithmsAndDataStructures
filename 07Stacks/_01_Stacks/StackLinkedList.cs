namespace _01_Stacks;

public class StackLinkedList
{
    private Node? _head;
        
    public void IsEmpty() => _head = null;
    public int? Peek() => _head?.Value;

    public void Push(int value)
    {
        var newNode = new Node(value);
            
        newNode.Next = _head;
        _head = newNode;
    }

    public int Pop()
    {
        if (_head == null)
            throw new InvalidOperationException("Stack is empty");
            
        var valueToPop = _head.Value;
        _head = _head.Next;
            
        return valueToPop;
    }

    public void Print()
    {
        var current = _head;
        while (current != null)
        {
            Console.Write(current.Value + " ");
            current = current.Next;
        }

        Console.WriteLine();
    }
}

public class Node
{
    public int Value { get; set; }
    public Node? Next { get; set; }

    public Node(int value, Node? next = null)
    {
        Value = value;
        Next = next;
    }
}