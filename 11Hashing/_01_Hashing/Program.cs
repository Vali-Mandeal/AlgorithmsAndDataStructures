using _01_Hashing.HashMaps;

namespace _01_Hashing;

class Program
{
    static void Main(string[] args)
    {
        // var naiveHashTable = new NaiveHashTable(100);
        // naiveHashTable.Add("test1", "it is test 1 indeed");
        // naiveHashTable.Add("test50", "it is test 50 indeed");
        // naiveHashTable.Add("test100", "it is test 100 indeed");
        //
        // Console.WriteLine(naiveHashTable.Get("test1"));
        // Console.WriteLine(naiveHashTable.Get("test50"));
        // Console.WriteLine(naiveHashTable.Get("test100"));

        // var hashMapWithLinearProbing = new HashMapWithLinearProbing(5);
        // // all of these keys create collisions
        // hashMapWithLinearProbing.Add("test1", "this is test 1 indeed");
        // hashMapWithLinearProbing.Add("1test", "this is test 2 indeed");
        // hashMapWithLinearProbing.Add("t1est", "this is test 3 indeed");
        // hashMapWithLinearProbing.Add("te1st", "this is test 4 indeed");
        // hashMapWithLinearProbing.Add("tes1t", "this is test 5 indeed");
        //
        // Console.WriteLine(hashMapWithLinearProbing.Get("test1"));
        // Console.WriteLine(hashMapWithLinearProbing.Get("1test"));
        // Console.WriteLine(hashMapWithLinearProbing.Get("t1est"));
        // Console.WriteLine(hashMapWithLinearProbing.Get("te1st"));
        // Console.WriteLine(hashMapWithLinearProbing.Get("tes1t"));

        var hashMapWithChaining = new HashMapWithChaining();
        
        hashMapWithChaining.Add("test1", "this is test 1");
        hashMapWithChaining.Add("test2", "this is test 2");
        hashMapWithChaining.Add("test3", "this is test 3");
        hashMapWithChaining.Add("test4", "this is test 4");
    }
}