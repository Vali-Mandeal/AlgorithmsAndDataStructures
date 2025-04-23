namespace _01_Hashing.HashSets;
/// <summary>
/// This hashset will help solve collisions in O(n) time
/// If a collision occurs, the index will be probed until the next empty position will be found
/// This happens on all methods, Add, Delete, Contains
/// </summary>
public class HashSetWithLinearProbing
{
    private string[] _items;
    private int _size;

    public HashSetWithLinearProbing(int size)
    {
        _size = size;
        _items = new string[size];
    }

    public void Add(string item)
    {
        var index = GetLinearProbedIndexForAdding(item);
        
        if (index == -1)
            throw new Exception("Hash is full");

        _items[index] = item;
    }

    public void Delete(string item)
    {
        var index = GetLinearProbedIndexForDeletion(item);

        if (index == -1)
            throw new Exception("Item not found");

        _items[index] = string.Empty;
    }

    public bool Contains(string item)
    {
        var index = GetLinearProbedIndexForContains(item);

        return index != -1;
    }

    /// <summary>
    /// When adding we need to find the first null or empty position
    /// We're also ok if the item itself is found, in this case we override it
    /// </summary>
    private int GetLinearProbedIndexForAdding(string item)
    {
        var index = GetProbedIndex(item, 
            index => string.IsNullOrEmpty(_items[index]) 
                     || _items[index] == item);

        return index;
    }

    /// <summary>
    /// For deletion we need an exact match of the item
    /// </summary>
    private int GetLinearProbedIndexForDeletion(string item)
    {
        var index = GetProbedIndex(item, 
            index => _items[index] == item);

        return index;
    }

    /// <summary>
    /// For contains we need an exact match of the item
    /// </summary>
    private int GetLinearProbedIndexForContains(string item)
    {
        var index = GetProbedIndex(item, index => _items[index] == item);

        return index;
    }
    
    /// <summary>
    /// An initial index is used, perhaps the first item is what we need
    /// In case the first item is not what we need, we probe further
    /// In case the index matches the initial index again, it means we checked all items, and no suitable spot is found
    /// </summary>
    private int GetProbedIndex(string item, Func<int, bool> matchCondition)
    {
        var initialIndex = GetIndex(item);
        var index = initialIndex;

        do
        {
            if (matchCondition(index))
                return index;

            index = (index + 1) % _size;
        } while (index != initialIndex);

        return -1;
    }

    private int GetIndex(string item)
    {
        var hash = 0;
        
        foreach (char c in item)
            hash += c;

        return hash % _size;
    }
}