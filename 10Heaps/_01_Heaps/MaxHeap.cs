namespace _01_Heaps;

public class MaxHeap
{
    private int[] _heap;
    private int _currentSize;
    private int _maxSize;
    
    public MaxHeap(int maxSize)
    {
        _maxSize = maxSize;
        _heap = new int[maxSize];
        _currentSize = 0;
    }

    public int Count => _currentSize;

    public void Peek()
    {
        if (_currentSize == 0)
            throw new Exception("Heap is empty");

        Console.WriteLine(_heap[0]);
    }
    
    public void Insert(int value)
    {
        if (_currentSize == _maxSize)
            throw new Exception("Heap is full");

        _heap[_currentSize] = value;
        HeapifyUp(_currentSize);
        _currentSize++;
    }

    public int Extract()
    {
        if (_currentSize == 0)
            throw new Exception("Heap is empty");

        int maxValue = _heap[0];

        // last element is moved to the root so we can do a top-down Heapify
        // extracted element is moved at the beginning of the inactive partition, so we leave 
        // a sorted array behind
        
        Swap(0, _currentSize - 1);

        _currentSize--;
        HeapifyDown(0);

        return maxValue;
    }
   
    public void Print()
    {
        for (int i = 0; i < _currentSize; i++)
        {
            Console.Write(_heap[i]);
            Console.WriteLine();
        }
    }

    /// <summary>
    /// HeapifyUp maintains the max heap property by moving a value up the tree.
    /// When we insert a new element at the bottom, this method ensures it "bubbles up"
    /// to the correct position by comparing with parents and swapping as needed.
    /// This guarantees larger values move toward the root.
    /// </summary>
    private void HeapifyUp(int index)
    {
        while (index > 0)
        {
            int parentIndex = GetParentIndex(index);

            if (_heap[index] <= _heap[parentIndex]) // Compare value to value
                break;
            
            Swap(index, parentIndex);
            index = parentIndex;
        }
    }
    
    /// <summary>
    /// HeapifyDown maintains the max heap property by moving a value down the tree.
    /// After removing the root, we place the last element at the root position,
    /// then this method "sinks" it down by comparing with children and swapping
    /// with the largest child until it reaches its proper position.
    /// This restores the heap property where parents are larger than children.
    /// </summary>
    private void HeapifyDown(int index)
    {
        while (index < _currentSize)
        {
            var leftIndex = GetLeftChildIndex(index);
            var rightIndex = GetRightChildIndex(index);
            int largestIndex = index;

            if (leftIndex < _currentSize && _heap[leftIndex] > _heap[largestIndex])
                largestIndex = leftIndex;

            if (rightIndex < _currentSize && _heap[rightIndex] > _heap[largestIndex])
                largestIndex = rightIndex;

            if (largestIndex == index)
                break;
            
            Swap(index, largestIndex);

            index = largestIndex;
        }
    }

    private static int GetParentIndex(int index) => (index - 1) / 2;
    private static int GetLeftChildIndex(int index) => 2 * index + 1;
    private static int GetRightChildIndex(int index) => 2 * index + 2;

    private void Swap(int i, int j)
    {
        (_heap[i], _heap[j]) = (_heap[j], _heap[i]);
    }
}