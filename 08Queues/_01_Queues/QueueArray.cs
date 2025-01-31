namespace _01_Queues;

public class QueueArray
{
    private int[] _arr;
    private int _maxSize;
    private int _tail;
    private const int Head = 0;

    public QueueArray(int size)
    {
        _arr = new int[size];
        _maxSize = size;
        
        _tail = 0;
    }

    public void Enqueue(int value)
    {
        if (_tail == _maxSize)
        {
            Console.WriteLine("Queue is full.");
            return;
        }
        
        _arr[_tail] = value;
        _tail++;
    }

    public int Dequeue()
    {
        if (_tail == 0)
        {
            Console.WriteLine("Queue is empty.");
            return - 1;
        }

        // 0 1 2 3
        var dequeuedValue = _arr[Head];
        
        for (int i = 0; i < _tail; i++)
            _arr[i] = _arr[i + 1];
        
        _tail--;
        
        return dequeuedValue;
    }

    public void Print()
    {
        for (int i = 0; i < _arr.Length; i++)
        {
            Console.Write(_arr[i] + " ");
        }
    }
}