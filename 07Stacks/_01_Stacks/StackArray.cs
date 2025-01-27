namespace _01_Stacks;

public class StackArray
{
    private readonly int[] _values;
    private int _top = -1;

    private StackArray() { }

    public StackArray(int size)
    {
        _values = new int[size];    
    }

    public bool IsFull()
        => _top == _values.Length - 1;

    public bool IsEmpty()
        => _top == -1;
    
    public void Push(int value)
    {
        if (_top > _values.Length - 1)
            throw new StackOverflowException("Stack is full.");
        
        _values[++_top] = value;
    }

    public int Pop()
    {
        if (_top == -1)
            throw new Exception("Stack is empty.");
        
        return _values[_top--];
    }

    public int Peek()
    {
        return _values[_top - 1];
    }

    public void Print()
    {
        if (_top == -1)
        {
            Console.WriteLine("Stack is empty.");
            return;
        }
        
        for (int i = 0; i <= _top; i++)
            Console.Write(_values[i] + " ");

        Console.WriteLine();
    }
    
}