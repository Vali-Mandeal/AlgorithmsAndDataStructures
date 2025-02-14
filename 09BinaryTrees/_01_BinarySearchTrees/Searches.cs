namespace _01_BinarySearchTrees;

public partial class BinaryTree
{
    public partial bool RecursiveSearch(int value, Node? node)
    {
        Console.WriteLine("Search on node: " + node?.Value);
        
        if (node == null)
            return false;
  
        if (value == node.Value)
            return true;

        if (value < node.Value)
            return RecursiveSearch(value, node.Left);
        
        if (value > node!.Value)
            return RecursiveSearch(value, node.Right);
        
        return false;
    }
    
    public partial bool IterativeSearch(int value)
    {
        var current = Root;

        while (current is not null)
        {
            Console.WriteLine("Search on node: " + current.Value);
            
            if (value == current.Value)
                return true;

            if (value < current.Value)
            {
                current = current.Left;
                continue;
            }

            if (value > current.Value)
            {
                current = current.Right;
            }
                
        }

        return false;
    }
}