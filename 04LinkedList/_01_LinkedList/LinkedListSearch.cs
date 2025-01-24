namespace _01_LinkedList;

public partial class LinkedList
{
    public partial int LinearSearch(int value)
    {
        Node? current = _head;
        int i = 0;
        
        while (current != null)
        {
            if (current.Value == value)
                return i;

            current = current.Next;
            i++;
        }

        return -1;  
    }
}