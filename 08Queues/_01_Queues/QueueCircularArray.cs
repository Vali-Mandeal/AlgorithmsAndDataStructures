namespace _01_Queues;

public class QueueCircularArray
{
    private readonly int[] _arr;
    private readonly int _maxSize;
    private int _head;
    private int _tail;
    private int _count;

    public QueueCircularArray(int size)
    {
        _arr = new int[size];
        _maxSize = size;
        _head = 0;
        _tail = 0;
        _count = 0;
    }

    public bool IsFull()
    {
        return _count == _maxSize;
    }

    public bool IsEmpty()
    {
        return _count == 0;
    }

    public void Enqueue(int value)
    {
        if (IsFull())
        {
            Console.WriteLine("Queue is full.");
            return;
        }

        _arr[_tail] = value;
        _tail = (_tail + 1) % _maxSize;
        _count++;
    }

    public int Dequeue()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Queue is empty.");
            return - 1;
        }

        int dequeuedValue = _arr[_head];
        _head = (_head + 1) % _maxSize;
        _count--;

        return dequeuedValue;
    }

    public void Print()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Queue is empty.");
            return;
        }

        for (int i = 0; i < _count; i++)
        {
            int index = (_head + i) % _maxSize;
            Console.Write(_arr[index] + " ");
        }

        Console.WriteLine();
    }
}