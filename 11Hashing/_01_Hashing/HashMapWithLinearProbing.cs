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
        var initialIndex = GetIndex(key);
        var index = initialIndex;
        
        // Keep probing until we find an empty slot or the key itself
        while (true)
        {
            // If we find the same key, update its value
            if (_keys[index] == key || string.IsNullOrEmpty(_keys[index]))
                return index;
            
            // Linear probing - move to the next slot
            index = (index + 1) % _size;
            
            // If we've checked all slots, the hash map is full
            if (index == initialIndex)
                return -1;
        }

        return index;
    }
    
    private int GetLinearProbedIndexForRemoval(string key)
    {
        var initialIndex = GetIndex(key);
        var index = initialIndex;
        
        // Use do-while to ensure we check the slot at initialIndex too
        do
        {
            // If an empty slot is reached, the key is not present
            if (string.IsNullOrEmpty(_keys[index]))
                break;
            
            if (_keys[index] == key)
                return index;
            
            index = (index + 1) % _size;
        }
        while (index != initialIndex);

        return -1;
    }
    
    private int GetLinearProbedIndexForGet(string key)
    {
        var initialIndex = GetIndex(key);
        var index = initialIndex;

        while (true)
        {
            if (_keys[index] == key)
                return index;

            index = (index + 1) % _size;

            if (index == initialIndex)
                return -1;
        }
    }

    private int GetIndex(string item)
    {
        int x = 0;

        foreach (char c in item)
            x += c;

        return x % _size;
    }
}