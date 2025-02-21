namespace _01_BinarySearchTrees;

public partial class BinaryTree
{
    public partial void Delete(int value)
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