namespace _01_Hashing;

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
        var index = GetLinearProbedIndexForRemoval(key);
        
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
    
    private int GetLinearProbedIndexForAdding(string key)
    {
        return ProbeForIndex(key, 
            index => _keys[index] == key || string.IsNullOrEmpty(_keys[index]), false);
    }
    
    private int GetLinearProbedIndexForRemoval(string key)
    {
        return ProbeForIndex(key, 
            index => _keys[index] == key, true);
    }
    
    private int GetLinearProbedIndexForGet(string key)
    {
        return ProbeForIndex(key, 
            index => _keys[index] == key, false);
    }

    private int ProbeForIndex(string key, Func<int, bool> matchCondition, bool breakOnEmpty)
    {
        int initialIndex = GetIndex(key);
        int index = initialIndex;

        do
        {
            if (breakOnEmpty && string.IsNullOrEmpty(_keys[index]))
                break;

            if (matchCondition(index))
                return index;

            index = (index + 1) % _size;
        }
        while (index != initialIndex);

        return -1;
    }

    private int GetIndex(string item)
    {
        int x = 0;

        foreach (char c in item)
            x += c;

        return x % _size;
    }
}