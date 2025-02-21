namespace _01_BinarySearchTrees;

public partial class BinaryTree
{
    public partial void PrintPreOrder(Node? node)
    {
        //         1
        //       /  \
        //      2     5
        //     / \   / \
        //    3   4 6   7
        if (node == null)
            return;

        Console.WriteLine(node.Value);
        
        PrintPreOrder(node.Left);
        
        PrintPreOrder(node.Right);
    }
    
    public partial void PrintInOrder(Node? node)
    {
        // This will print:
        //         4
        //       /  \
        //      2     6
        //     / \   / \
        //    1   3 5   7
        if (node == null)
            return;
        
        PrintInOrder(node.Left);

        Console.WriteLine(node.Value);
        
        PrintInOrder(node.Right);
    }

    public partial void PrintPostOrder(Node? node)
    {
        //         7
        //       /   \
        //      3     6
        //     / \   / \
        //    1   2 4   5

        if (node == null)
            return;
        
        PrintPostOrder(node.Left);
        PrintPostOrder(node.Right);

        Console.WriteLine(node.Value);
    }

    public partial void PrintLevelOrder(Node? node)
    {
        // this will print:
        
        //         1
        //       /  \
        //      2     3
        //     / \   / \
        //    4   5 6   7
        if (node == null)
            return;

        var queue = new QueueImpl<Node>(); 
        
        queue.Enqueue(node);

        while (queue.Count != 0)
        {
            var current = queue.Dequeue();

            Console.WriteLine(current.Value);
            
            if (current.Left != null)
                queue.Enqueue(current.Left);

            if (current.Right != null)
                queue.Enqueue(current.Right);
        }
    }
    
    public partial int GetNodeCount(Node? node)
    {
        if (node is null) 
            return 0;
        
        var x = GetNodeCount(node.Left);
        var y = GetNodeCount(node.Right);

        return x + y + 1; // 1 is the root node
    }

    public partial int GetHeight(Node? node)
    {
        if (node is null)
            return 0;

        var x = GetHeight(node.Left);
        var y = GetHeight(node.Right);

        if (x > y)
            return x + 1;
        else
            return y + 1;
    }
}