namespace _01_CircularLinkedList;

public partial class LinkedList
{
    public partial void InsertLast(int value)
    {
        var newNode = new Node { Value = value };

        if (_size == 0)
            _head = newNode;
        else
            _tail.Next = newNode;

        _tail = newNode;
        _tail.Next = _head;

        _size++;
    }

    public partial void InsertFirst(int value)
    {
        var newNode = new Node { Value = value };

        if (_size == 0)
            _tail = newNode;
        else
            newNode.Next = _head;

        _head = newNode;
        _tail.Next = _head;
        _size++;
    }

    public partial void Insert(int value, int index)
    {
        if (index < 0 || index > _size)
            throw new IndexOutOfRangeException();

        var newNode = new Node { Value = value };

        if (index == 0) // should insert on first position
        {
            if (_size == 0) // list is empty
            {
                _head = newNode;
                _tail = newNode;
                _tail.Next = _head;
            }
            else // list is not empty
            {
                newNode.Next = _head;
                _head = newNode;
                _tail.Next = _head;
            }
        }
        else // insert on any other position
        {
            var current = _head;
            for (int i = 0; i < index - 1; i++) // stop on the index - 1 node
            {
                current = current.Next;
            }

            newNode.Next = current.Next; // new node's Next will be current node's Next
            current.Next = newNode; // now index - 1 Node.Next will point to the new Node

            if (index == _size) // in case index goes on the last position, tail needs to be adjusted
            {
                _tail = newNode;
            }
        }

        _size++;
    }
}