namespace _01_Hashing.HashMaps;
/// <summary>
/// This implementation will not solve any collisions.
/// It will just override the values when these occur.
/// </summary>
public class HashMapNaive // key values (like Dictionary)
{
    private int _size;
    private string[] _keys;
    private string[] _values;
    
    public HashMapNaive(int size)
    {
        _size = size;
        _keys = new string[size];
        _values = new string[size];
    }

    public void Add(string key, string value)
    {
        var index = GetIndex(key);

        _keys[index] = key;
        _values[index] = value;
    }

    public string Get(string key)
    {
        var index = GetIndex(key);

        if (_keys[index] == key)
            return _values[index];

        throw new Exception("Key not found");
    }

    public void Delete(string key)
    {
        var index = GetIndex(key);

        if (_keys[index] != key)
            return;

        _keys[index] = string.Empty;
        _values[index] = String.Empty;
    }

    private int GetIndex(string key)
    {
        int hash = 0;
        foreach (char c in key)
        {
            hash += c;
        }

        return hash % _size;
    }
}