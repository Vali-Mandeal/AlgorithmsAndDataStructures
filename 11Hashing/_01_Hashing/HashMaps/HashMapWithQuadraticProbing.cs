namespace _01_Hashing.HashMaps;

/// <summary>
/// This hashmap will help solve collisions using quadratic probing
/// If a collision occurs, the index will be probed using the formula: (initialIndex + i²) % size
/// This happens on all methods: Add, Remove, Get
/// </summary>
public class HashMapWithQuadraticProbing
{
    private string[] _keys;
    private string[] _values;
    private int _size;

    public HashMapWithQuadraticProbing(int size)
    {
        _size = size;
        _keys = new string[size];
        _values = new string[size];
    }

    public void Add(string key, string value)
    {
        var index = GetQuadraticProbedIndexForAdding(key);
        
        if (index == -1)
            throw new Exception("HashMap is full");
    
        _keys[index] = key;
        _values[index] = value;
    }

    public void Remove(string key)
    {
        var index = GetQuadraticProbedIndexForDeletion(key);
        
        if (index == -1)
            throw new Exception("Key not found.");
        
        _keys[index] = "";
        _values[index] = "";
    }

    public string? Get(string key)
    {
        var index = GetQuadraticProbedIndexForGet(key);

        if (index == -1)
            return null;

        return _values[index];
    }
    
    /// <summary>
    /// When adding we need to find the first null or empty position
    /// We're also ok if the key itself is found, in this case we override it
    /// </summary>
    private int GetQuadraticProbedIndexForAdding(string key)
    {
        return ProbeForIndex(key, 
            index => _keys[index] == key || string.IsNullOrEmpty(_keys[index]));
    }
    
    /// <summary>
    /// For deletion we need an exact match of the key
    /// </summary>
    private int GetQuadraticProbedIndexForDeletion(string key)
    {
        return ProbeForIndex(key, index => _keys[index] == key);
    }
    
    /// <summary>
    /// For get we need an exact match of the key
    /// </summary>
    private int GetQuadraticProbedIndexForGet(string key)
    {
        return ProbeForIndex(key, index => _keys[index] == key);
    }

    /// <summary>
    /// Probes for an index using quadratic probing strategy
    /// The formula used is: (initialIndex + i²) % size 
    /// </summary>
    private int ProbeForIndex(string key, Func<int, bool> matchCondition)
    {
        int initialIndex = GetIndex(key);
        int i = 0;
        int index;

        do
        {
            // Quadratic probing formula: h(k, i) = (h'(k) + i²) % m
            index = (initialIndex + i * i) % _size;
            
            if (matchCondition(index))
                return index;
            
            i++;
        }
        // Stop if we've probed all positions (should be enough to check size probes)
        while (i < _size);

        return -1;
    }

    private int GetIndex(string key)
    {
        var hash = 0;

        foreach (var c in key)
            hash += c;

        return hash % _size;
    }
}