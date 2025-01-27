namespace _01_Stacks;

class Program
{
    static void Main(string[] args)
    {
        var stack = new StackLinkedList();
        
        stack.Print();
        
        stack.Push(0);
        stack.Print();
        
        stack.Push(1);
        stack.Print();
        
        stack.Push(2);
        stack.Print();

        stack.Push(3);
        stack.Print();
        
        stack.Pop();
        stack.Print();
    }
}