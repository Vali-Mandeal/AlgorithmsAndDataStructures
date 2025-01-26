namespace _01_DoublyLinkedList;

public partial class LinkedList
{
    public partial void RemoveFirst()
    {
        if (IsEmpty())
            return;

        _head = _head?.Next;

        if (_head != null)
            _head.Previous = null;
        else
            _tail = null;

        _size--;
    }

    public partial void RemoveLast()
    {
        if (IsEmpty())
            return;
        
        _tail = _tail?.Previous;
        
        if (_tail != null)
            _tail.Next = null;
        else
            _head = null;

        _size--;
    }

    public partial void Remove(int index)
    {
        if (IsEmpty())
            return;

        if (index < 0 || index >= _size)
            throw new IndexOutOfRangeException();

        Node? currentNode = _head;
        for (int i = 0; i < index; i++)
            currentNode = currentNode!.Next;

        if (currentNode == _head)
        {
            _head = _head?.Next;
            if (_head != null)
                _head.Previous = null;
            else
                _tail = null;
        }
        else if (currentNode == _tail)
        {
            _tail = _tail?.Previous;
            if (_tail != null)
                _tail.Next = null;
            else
                _head = null;
        }
        else
        {
            currentNode!.Next!.Previous = currentNode.Previous;
            currentNode.Previous!.Next = currentNode.Next;
        }

        _size--;
    }
}