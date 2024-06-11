using System.Diagnostics;

var stopwatch = new Stopwatch();
stopwatch.Start();
var test1 = Methods.areAnagram1("abcd", "dbca");
Console.WriteLine(test1);
stopwatch.Stop();
Console.WriteLine(stopwatch.Elapsed);

Console.WriteLine();

stopwatch.Start();
var test2 = Methods.areAnagram2("abcd", "dbca");
Console.WriteLine(test2);
stopwatch.Stop();
Console.WriteLine(stopwatch.Elapsed);

Console.WriteLine();

stopwatch.Start();
var test3 = Methods.countVowels("Hello World");
Console.WriteLine(test3);
stopwatch.Stop();
Console.WriteLine(stopwatch.Elapsed);

Console.WriteLine();

stopwatch.Start();
var test4 = Methods.maxOccuringChar1("Hello World");
Console.WriteLine(test4);
stopwatch.Stop();
Console.WriteLine(stopwatch.Elapsed);

Console.WriteLine();

stopwatch.Start();
var test5 = Methods.maxOccuringChar2("Hello World");
Console.WriteLine(test5);
stopwatch.Stop();
Console.WriteLine(stopwatch.Elapsed);





Console.ReadLine();

public class Methods
{
    //O(n log n)
    public static bool areAnagram1(string first, string second)
    {
        if (first == null || second == null || first.Length != second.Length) return false;

        //O(n)
        var array1 = first.ToLower().ToArray();
        var array2 = second.ToLower().ToArray();

        //O(n log n)
        Array.Sort(array1);
        Array.Sort(array2);

        return array1.SequenceEqual(array2);
    }

    //O(n) - faster
    public static bool areAnagram2(string first, string second)
    {
        if (first == null || second == null || first.Length != second.Length) return false;

        const int ENGLISH_ALPHABET = 26;

        int[] frequencies = new int[ENGLISH_ALPHABET];

        int index;

        first = first.ToLower();
        //O(n)
        for (int i = 0; i < first.Length; i++)
        {
            index = first[i] - 'a';
            frequencies[index]++; 
        }

        second = second.ToLower();
        //O(n)
        for (int i = 0;i < second.Length;i++)
        {
            index = second[i] - 'a';
            if (frequencies[index] == 0)
            {
                return false;
            }
            else
            {
                frequencies[index]--;
            }
        }

        return true;
    }


    public static int countVowels(string str)
    {
        if(str == null) return 0;

        int count = 0;
        const string VOWELS = "aeiou";

        foreach (char s in str.ToLower().ToCharArray())
        {
            if(VOWELS.IndexOf(s) != -1) count++;
        }

        return count;
    }

    public static char maxOccuringChar1(string str)
    {
        if(str == null || str.Trim() == "") return '\0';

        var frequencies = new Dictionary<char, int>();

        foreach (char c in str.ToLower().ToCharArray())
        {
            if (frequencies.ContainsKey(c))
            {
                frequencies[c] = frequencies[c] + 1;
            }
            else
            {
                frequencies.Add(c, 1);
            }
        }

        return frequencies.OrderByDescending(x => x.Value).First().Key;
    }

    public static char maxOccuringChar2(string str)
    {
        const int ASCII_SIZE = 256;

        int[] frequencies = new int[ASCII_SIZE];

        foreach (char c in str.ToLower().ToCharArray())
        {
            frequencies[(int)c]++;
        }

        int max = 0;
        char result = ' ';

        for (int i = 0; i < frequencies.Length; i++)
        {
            if (frequencies[i] > max)
            {
                max = frequencies[i];
                result = (char)i;
            }
        }

        return result;
    }
}









