namespace _01_BinarySearchTrees;

public class QueueNode<T>
{
    public QueueNode(T value)
    {
        Value = value;
    }
    
    public T Value { get; set; }
    public QueueNode<T>? Next { get; set; }
}

public class QueueImpl<T>
{
    private QueueNode<T>? _head;
    private QueueNode<T>? _tail;

    public int Count { get; private set; } = 0;

    public void Enqueue(T value)
    {
        var queueNode = new QueueNode<T>(value);

        if (_tail != null)
            _tail.Next = queueNode;
        else
            _head = queueNode;

        _tail = queueNode;
        Count++;
    }

    public T? Dequeue()
    {
        if (_head == null)
            return default;

        var dequeuedValue = _head.Value;
        _head = _head.Next;

        if (_head == null)
            _tail = null;

        Count--;
        return dequeuedValue;
    }
}