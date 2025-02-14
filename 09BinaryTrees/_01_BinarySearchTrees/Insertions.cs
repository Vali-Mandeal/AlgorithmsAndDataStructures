namespace _01_BinarySearchTrees;

public partial class BinaryTree
{
    public partial void InsertRecursive(int value)
    {
        Root = InsertRecursive(Root, value);
    }

    private partial Node InsertRecursive(Node? node, int value)
    {
        if (node == null)
            return new Node { Value = value };
    
        if (value < node.Value)
            node.Left = InsertRecursive(node.Left, value);
        else if (value > node.Value)
            node.Right = InsertRecursive(node.Right, value);
        else
            throw new Exception("Inserting duplicates is not allowed");

        return node;
    }
    public partial void InsertIterative(int value)
    {
        var newNode = new Node { Value = value };

        if (Root == null)
        {
            Root = newNode;
            return;
        }

        var currentNode = Root;
        while (true)
        {
            if (value == currentNode.Value)
                throw new Exception("Inserting duplicates is not allowed");

            if (value < currentNode.Value)
            {
                if (currentNode.Left == null)
                {
                    currentNode.Left = newNode;
                    break;
                }
                currentNode = currentNode.Left;
            }
            else
            {
                if (currentNode.Right == null)
                {
                    currentNode.Right = newNode;
                    break;
                }
                currentNode = currentNode.Right;
            }
        }
    }

}