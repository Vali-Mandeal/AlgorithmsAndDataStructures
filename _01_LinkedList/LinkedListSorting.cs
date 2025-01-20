namespace _01_LinkedList;

public partial class LinkedList
{
    public partial void MergeSort()
    {
        _head = MergeSort(_head);
        UpdateTail();
    }

    private Node MergeSort(Node head)
    {
        if (head == null || head.Next == null)
            return head;

        Node middle = GetMiddle(head);
        Node nextOfMiddle = middle.Next;
        middle.Next = null;

        Node left = MergeSort(head);
        Node right = MergeSort(nextOfMiddle);

        return SortedMerge(left, right);
    }

    private Node SortedMerge(Node left, Node right)
    {
        if (left == null)
            return right;
        if (right == null)
            return left;

        Node result;
        if (left.Value <= right.Value)
        {
            result = left;
            result.Next = SortedMerge(left.Next, right);
        }
        else
        {
            result = right;
            result.Next = SortedMerge(left, right.Next);
        }

        return result;
    }

    private Node GetMiddle(Node head)
    {
        if (head == null)
            return head;

        Node slow = head, fast = head;
        while (fast.Next != null && fast.Next.Next != null)
        {
            slow = slow.Next;
            fast = fast.Next.Next;
        }

        return slow;
    }

    private void UpdateTail()
    {
        Node current = _head;
        while (current != null && current.Next != null)
        {
            current = current.Next;
        }
        _tail = current;
    }
}