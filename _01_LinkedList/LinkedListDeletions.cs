namespace _01_LinkedList;

public partial class LinkedList
{
    public partial void RemoveFirst()
    {
        if (IsEmpty())
            return;
        
        _head = _head!.Next;
        _size--;
        
        if (IsEmpty()) // Update _tail when _head becomes null
            _tail = null;
    }

    public partial void RemoveLast()
    {
        if (IsEmpty())
            return;

        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        else
        {
            Node current = _head!;
            while (current.Next != _tail)
                current = current.Next!;

            _tail = current;
            _tail.Next = null;
        }

        _size--;
    }

    public partial void RemoveAtIndex(int index)
    {
        if (index > _size || index < 0 || index > _size + 1)
            throw new IndexOutOfRangeException();

        if (index == 0)
        {
            RemoveFirst();
            return;
        }
        
        Node current = _head!;
        int i = 0;
        while (i < index - 1)
        {
            current = current.Next!;
            i++;
        }
        
        current.Next = current.Next!.Next!;
    }
}