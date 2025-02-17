namespace _01_BinarySearchTrees;

public class Node
{
    public int Value { get; set; }
    public Node? Left { get; set; }
    public Node? Right { get; set; }
}

public partial class BinaryTree
{
    public Node Root { get; private set; }

    public BinaryTree(int rootValue)
    {
        Root = new Node { Value = rootValue };
    }

    // Insertions
    public partial void InsertRecursive(int value);
    private partial Node InsertRecursive(Node? node, int value);
    public partial void InsertIterative(int value);

    // Search
    public partial bool RecursiveSearch(int value, Node? node);
    public partial bool IterativeSearch(int value);

    // Traversals
    public partial void PrintPreOrder(Node? node);
    public partial void PrintInOrder(Node? node);
    public partial void PrintPostOrder(Node? node);
    public partial void PrintLevelOrder(Node? node);

    public void Delete(int value)
    {
        Delete(value, Root);
    }

    private Node? Delete(int value, Node? root)
    {
        if (root == null)
            return root;

        if (value < root.Value)
            root.Left = Delete(value, root.Left);  // Assign back to root.Left
        else if (value > root.Value)
            root.Right = Delete(value, root.Right);  // Assign back to root.Right
        else // found the node
        {
            if (root.Left is null)
                return root.Right;

            if (root.Right is null)
                return root.Left;
            
            // find the max from the left subtree
            var current = root.Left;
            while (current.Right is not null)
                current = current.Right;

            root.Value = current.Value;
            root.Left = Delete(current.Value, root.Left);
        }

        return root;
    }
}



class Program
{
    static void Main(string[] args)
    {
        var bt = InitializeTestBinarySearchTree();
        //        10
        //       /  \
        //      5    15
        //     / \   / \
        //    3   7 12 18
     
        
        bt.Delete(5);
        bt.PrintLevelOrder(bt.Root);  
    }

    private static BinaryTree InitializeTestBinarySearchTree()
    {
        BinaryTree bt = new BinaryTree(10);

        bt.Root.Left = new Node { Value = 5 };
        bt.Root.Right = new Node { Value = 15 };

        bt.Root.Left.Left = new Node { Value = 3 };
        bt.Root.Left.Right = new Node { Value = 7 };
        bt.Root.Right.Left = new Node { Value = 12 };
        bt.Root.Right.Right = new Node { Value = 18 };

        return bt;
    }
}