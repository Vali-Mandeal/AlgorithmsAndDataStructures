namespace _01_DoublyLinkedList;

public partial class LinkedList
{
    public partial void AddFirst(int value)
    {
        Node newNode = new Node { Value = value };

        if (_size == 0)
            _head = _tail = newNode;
        else
        {
            _head!.Previous = newNode;
            newNode.Next = _head;
            _head = newNode;
        }

        _size++;
    }

    public partial void AddLast(int value)
    {
        Node newNode = new Node { Value = value };

        if (IsEmpty())
            _head = _tail = newNode;
        else
        {
            newNode.Previous = _tail;
            _tail!.Next = newNode;
            _tail = newNode;
        }

        _size++;
    }

    public partial void Add(int value, int index)
    {
        if (index < 0 || index > _size)
            throw new IndexOutOfRangeException();

        Node newNode = new Node { Value = value };

        if (index == 0)
        {
            if (IsEmpty()) // empty list and index is 0
            {
                // Before: (empty list)
                // After:  newNode
                //         null <= newNode => null
                _head = _tail = newNode;
            }
            else // index 0
            {
                // Before: head -> 1 <=> 2 <=> 3 <- tail
                // After:  head -> newNode <=> 1 <=> 2 <=> 3 <- tail
                //         null <= newNode <=> 1
                newNode.Next = _head;
                _head!.Previous = newNode;
                _head = newNode;
            }
        }
        else if (index == _size) // adding at the end (size + 1)
        {
            // Before: head -> 1 <=> 2 <=> 3 <- tail
            // After:  head -> 1 <=> 2 <=> 3 <=> newNode <- tail
            //         3 <=> newNode => null
            newNode.Previous = _tail;
            _tail!.Next = newNode;
            _tail = newNode;
        }
        else // adding anywhere between head and tail
        {
            Node? currentNode = _head;
            for (int i = 0; i < index; i++)
                currentNode = currentNode!.Next;

            // example: adding 100 on index 2
            // 0 1 2 3
            newNode.Previous = currentNode!.Previous;   //   1 <= 100
            newNode.Next = currentNode;                 //   1 <= 100 => 2
            currentNode.Previous!.Next = newNode;       //   1 <=> 100 => 2
            currentNode.Previous = newNode;             //   1 <=> 100 <=> 2
        }

        _size++;
    }
}