namespace _01_Hashing.HashSets;
/// <summary>
/// This implementation will not solve any collisions.
/// It will just override the values when these occur.
/// </summary>
public class HashSetNaive // keys only
{
    private string[] _items;
    private int _size;

    public HashSetNaive(int size)
    {
        _size = size;
        _items = new string[size];
    }

    public void Add(string item)
    {
        var index = GetIndex(item);

        _items[index] = item; // naively override values
    }

    public bool Contains(string item)
    {
        var index = GetIndex(item);

        return _items[index] == item;
    }

    public void Delete(string item)
    {
        var index = GetIndex(item);
        
        if (_items[index] == item)
            _items[index] = string.Empty;
    }

    private int GetIndex(string item)
    {
        int hash = 0;

        foreach (char c in item)
            hash += c;

        return hash % _size;
    }
}