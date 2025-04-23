namespace _01_Hashing.HashMaps;

/// <summary>
/// This hashmap will help solve collisions in O(n) time
/// If a collision occurs, the index will be probed until the next empty position will be found
/// This happens on all methods, Add, Delete, Contains
/// </summary>
public class HashMapWithLinearProbing
{
    private string[] _keys;
    private string[] _values;
    private int _size;

    public HashMapWithLinearProbing(int size)
    {
        _size = size;
        _keys = new string[_size];
        _values = new string[_size];
    }

    public void Add(string key, string value)
    {
        var index = GetLinearProbedIndexForAdding(key);
        if (index == -1)
            throw new Exception("HashMap is full");
    
        _keys[index] = key;
        _values[index] = value;
    }

    public void Remove(string key)
    {
        var index = GetLinearProbedIndexForDeletion(key);
        
        if (index == -1)
            throw new Exception("Key not found.");
        
        _keys[index] = "";
        _values[index] = "";
    }

    public string? Get(string key)
    {
        var index = GetLinearProbedIndexForGet(key);

        if (index == -1)
            return null;

        return _values[index];
    }
    
    /// <summary>
    /// When adding we need to find the first null or empty position
    /// We're also ok if the item itself is found, in this case we override it
    /// </summary>
    private int GetLinearProbedIndexForAdding(string key)
    {
        return ProbeForIndex(key, 
            index => _keys[index] == key || string.IsNullOrEmpty(_keys[index]));
    }
    
    /// <summary>
    /// For deletion we need an exact match of the item
    /// </summary>
    private int GetLinearProbedIndexForDeletion(string key)
    {
        return ProbeForIndex(key,index => _keys[index] == key);
    }
    
    /// <summary>
    /// For get we need an exact match of the item
    /// </summary>
    private int GetLinearProbedIndexForGet(string key)
    {
        return ProbeForIndex(key, index => _keys[index] == key);
    }

    private int ProbeForIndex(string key, Func<int, bool> matchCondition)
    {
        int initialIndex = GetIndex(key);
        int index = initialIndex;

        do
        {
            if (matchCondition(index))
                return index;

            index = (index + 1) % _size;
        }
        while (index != initialIndex);

        return -1;
    }

    private int GetIndex(string item)
    {
        int hash = 0;

        foreach (char c in item)
            hash += c;

        return hash % _size;
    }
}