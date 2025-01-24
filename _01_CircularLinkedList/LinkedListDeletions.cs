namespace _01_CircularLinkedList;

public partial class LinkedList
{
    public partial void RemoveFirst()
    {
        if (IsEmpty())
            return;

        if (_size == 1) // If there's only one element we can assign null to both head and tail
        {
            _head = null;
            _tail = null;
        }
        else
        {
            _head = _head!.Next!; // head becomes the next position
            _tail.Next = _head;   // tail points to the new head
        }

        _size--;
    }

    public partial void RemoveLast()
    {
        if (IsEmpty())
            return;

        if (_size == 1)
        {
            _tail = null;
            _head = null;
        }
        else
        {
            var current = _head!;
            while (current.Next != _tail) // go until _tail - 1
                current = current.Next!;
            
            current.Next = _head;
            _tail = current;
        }
        
        _size--;
    }

    public partial void Remove(int index)
    {
        if (index < 0 || index >= _size) 
            throw new IndexOutOfRangeException();

        if (index == 0)
        {
            _head = _head!.Next!;
            _tail.Next = _head;
        }
        else
        {
            var current = _head!;
            
            for (int i = 0; i < index - 1; i++)
                current = current.Next!;

            if (current.Next == _tail)
                _tail = current;
            
            current.Next = current.Next!.Next!;
        }

        _size--;
    }
}