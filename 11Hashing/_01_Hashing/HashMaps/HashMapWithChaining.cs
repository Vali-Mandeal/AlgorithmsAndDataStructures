namespace _01_Hashing.HashMaps;

public class HashMapWithChaining
{
    private LinkedList<KeyValuePair<string, string>>[] _buckets;
    private int _size = 3;
    private const double _loadFactorThreshHold = 0.75;
    public int Count { get; private set; } = 0;

    public HashMapWithChaining()
    {
        _buckets = new LinkedList<KeyValuePair<string, string>>[_size];

        for (int i = 0; i < _size; i++)
            _buckets[i] = new LinkedList<KeyValuePair<string, string>>();
    }

    public bool Contains(string key)
    {
        var index = GetBucketIndex(key);

        var bucket = _buckets[index];

        foreach (var kvp in bucket)
        {
            if (kvp.Key == key)
                return true;
        }

        return false;
    }

    public void Add(string key, string value)
    {
        var index = GetBucketIndex(key);
        var bucket = _buckets[index];

        bool hasUpdated = false;
        foreach (var kvp in bucket)
        {
            if (kvp.Key != key) 
                continue;
            
            bucket.Remove(kvp);
            hasUpdated = true;
            break;
        }

        bucket.AddLast(new KeyValuePair<string, string>(key, value));
        
        if (!hasUpdated)
            Count++;

        if (DoesCountExceedLoadFactor())
            Resize();
    }

    private void Resize()
    {
        var newSize = _size * 2;
        
        var newBuckets = new LinkedList<KeyValuePair<string, string>>[newSize];
        for (int i = 0; i < newSize; i++)
            newBuckets[i] = new LinkedList<KeyValuePair<string, string>>();
    
        foreach (var bucket in _buckets)
        {
            foreach (var kvp in bucket)
            {
                var newIndex = Math.Abs(kvp.Key.GetHashCode() % newSize);
                newBuckets[newIndex].AddLast(kvp);
            }
        }

        _buckets = newBuckets;
        _size = newSize;
    }

    public bool Remove(string key)
    {
        int index = GetBucketIndex(key);
        var bucket = _buckets[index];

        foreach (var pair in bucket)
        {
            if (pair.Key == key)
            {
                bucket.Remove(pair);
                Count--;
                
                return true;
            }
        }

        return false;
    }

    public string? Get(string key)
    {
        int index = GetBucketIndex(key);
        var bucket = _buckets[index];

        foreach (var pair in bucket)
        {
            if (pair.Key == key)
                return pair.Value;
        }

        return null;
    }

    private bool DoesCountExceedLoadFactor()
    {
        var sizeLoadFactorRatio = (double)Count / _size;

        return sizeLoadFactorRatio > _loadFactorThreshHold;
    }
    
    private int GetBucketIndex(string key)
    {
        var hash = key.GetHashCode();

        return Math.Abs(hash % _size);
    }
}