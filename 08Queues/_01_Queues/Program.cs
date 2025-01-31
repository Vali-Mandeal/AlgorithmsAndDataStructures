namespace _01_Queues;

public class DoubleEndedQueue
{
    private Node? _head;
    private Node? _tail;

    private int _size;

    public void EnqueueFirst(int value)
    {
        var newNode = new Node { Value = value };
        
        if (_size == 0)
            _head = _tail = newNode;
        else
        {
            newNode.Next = _head;
            _head = newNode;
        }
        
        _size++;
    }

    public void EnqueueLast(int value)
    {
        var newNode = new Node { Value = value };
        
        if (_size == 0)
            _head = _tail = newNode;
        else
        {
            _tail!.Next = newNode;
            _tail = newNode;
        }
        
        _size++;
    }

    public int DequeueFirst()
    {
        if (_size == 0)
            throw new InvalidOperationException("Queue is empty");
        
        int valueToDequeue = _head!.Value;

        if (_size == 1)
            _head = _tail = null;
        else 
            _head = _head!.Next;
        
        _size--;
        
        return valueToDequeue;
    }

    public int DequeueLast()
    {
        if (_size == 0)
            throw new InvalidOperationException("Queue is empty");
        
        int valueToDequeue = _tail!.Value;
        
        if (_size == 1)
            _tail = _head = null;
        else
        {
            var currentNode = _head!;
            
            while(currentNode!.Next != _tail)
                currentNode = currentNode.Next;
            
            _tail = currentNode;
            _tail.Next = null;
        }
        
        _size--;
        return valueToDequeue;
    }

    public void Print()
    {
        if (_size == 0)
        {
            Console.WriteLine("Queue is empty");
            return;
        }
        
        var node = _head!;
        while (node != null)
        {
            Console.Write(node.Value + " ");
            node = node.Next;
        }

        Console.WriteLine();
    }
}


class Program
{
    static void Main(string[] args)
    {
        DoubleEndedQueue queue = new DoubleEndedQueue();
        queue.EnqueueFirst(0);
        queue.EnqueueFirst(1);
        queue.EnqueueFirst(2);
        queue.EnqueueFirst(3);
        queue.EnqueueLast(4);
        
        queue.Print();

        var dequeuedFirstValue = queue.DequeueFirst();
        Console.WriteLine("Dequeued first value:" + dequeuedFirstValue);
        
        queue.Print();
        
        var dequeuedLastValue = queue.DequeueLast();
        Console.WriteLine("Dequeued last value:" + dequeuedLastValue);
        
        queue.Print();
    }
}