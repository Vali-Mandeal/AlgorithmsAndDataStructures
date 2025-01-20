namespace _01_LinkedList;

public partial class LinkedList
{
    public partial void InsertInSortedOrder(int value)
    {
        Node current = _head;

        if (IsEmpty() || value < current.Value)
        {
            InsertFirst(value);
            return;
        }

        while (current.Next != null && current.Next.Value < value)
        {
            current = current.Next;
        }

        var newNode = new Node { Value = value, Next = current.Next };
        current.Next = newNode;

        if (current.Next.Next == null)
            _tail = newNode;

        _size++;
    }
    
    public partial void InsertAtIndex(int index, int value)
    {
        if (index > _size || index < 0 || index > _size + 1)
            throw new IndexOutOfRangeException();

        if (index == 0)
        {
            InsertFirst(value);
            return;
        }
        
        var current  = _head;
        int i = 0;
        while (i < index - 1)
        {
            current = current!.Next;
            i++;
        }
        
        var newNode = new Node { Value = value, Next = current!.Next };
        current.Next = newNode;

        _size++;
    }
    
    public partial void InsertLast(int value)
    {
        Node newNode = new Node { Value = value };

        if (IsEmpty())
        {
            _head = newNode; 
            _tail = newNode;
        }
        else
        {
            _tail.Next = newNode;
            _tail = newNode;
        }
        
        _size++;
    }

    public partial void InsertFirst(int value)
    {
        Node newNode = new Node { Value = value };

        if (IsEmpty())
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            newNode.Next = _head;
            _head = newNode;
        }
        
        _size++;
    }
}