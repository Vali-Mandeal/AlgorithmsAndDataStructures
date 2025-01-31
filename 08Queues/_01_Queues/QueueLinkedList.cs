namespace _01_Queues;

public class QueueLinkedList
{
    private Node? _head;
    private Node? _tail;

    private int _count;
    
    public void Enqueue(int value)
    {
        var newNode = new Node { Value = value };

        if (_count == 0)
            _head = _tail = newNode;
        else
        {
            _tail!.Next = newNode;
            _tail = newNode;
        }
        
        _count++;
    }

    public int Dequeue()
    {
        if (_count == 0)
            throw new InvalidOperationException("Queue is empty");
        
        int valueToReturn = _head!.Value;
        
        _head = _head.Next;
        
        _count--;
        
        return valueToReturn;
    }

    public void Print()
    {
        if (_count == 0)
            Console.WriteLine("Queue is empty");
        
        var currentNode = _head;
        while (currentNode != null)
        {
            Console.Write(currentNode.Value + " ");
            currentNode = currentNode.Next;
        }

        Console.WriteLine();
    }
}