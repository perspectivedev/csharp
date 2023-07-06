List<string> StrList = new List<string>() { "string1", "string2", "string3", "string4" };

static void PrintList(List<string> MyList)
{
    foreach (string item in MyList)
    {
        Console.WriteLine(item);
    }
}
PrintList(StrList);

List<int> TestList = new List<int>() { 2, 7, 12, 9, 3 };

static int SumOfNumbers(List<int> IntList)
{
    int sum = 0;
    foreach (int num in IntList)
    {
        sum += num;
    }
    Console.WriteLine(sum);
    return sum;
}

SumOfNumbers(TestList);



List<int> TestList2 = new List<int>() { -9, 12, 10, 3, 17, 5 };

static int FindMax(List<int> IntList)
{
    int max = IntList[0];
    for (int i = 1; i < IntList.Count; i++)
    {
        if (IntList[i] > max)
        {
            max = IntList[i];
        }
    }
    return max;
}
Console.WriteLine(FindMax(TestList2));





static List<int> SquareValues(List<int> IntList)
{
    for (int i = 0; i < IntList.Count; i++)
    {
        IntList[i] = IntList[i] * IntList[i];
    }
    foreach (int num in IntList)
    {
        Console.WriteLine(num);
    }
    return IntList;
}
List<int> TestList3 = new List<int>() { 1, 2, 3, 4, 5 };
SquareValues(TestList3);


static int[] NonNegatives(int[] IntArray)
{
    for (int i = 0; i < IntArray.Length; i++)
    {
        if (IntArray[i] < 0 )
        {
            IntArray[i] = 0;
        }
    }
    foreach (int num in IntArray)
    {
        Console.WriteLine(num);
    }
    return IntArray;
}
int[] TestIntArray = new int[] { -1, 2, 3, -4, 5 };
NonNegatives(TestIntArray);

Dictionary<string,string> TestDict = new Dictionary<string,string>();
TestDict.Add("HeroName", "Superman");
TestDict.Add("RealName", "Clark Kent");
TestDict.Add("Powers", "Super human Powers");

static void PrintDictionary(Dictionary<string,string> MyDictionary)
{
    foreach(KeyValuePair<string, string> heroStat in MyDictionary)
    {
        Console.WriteLine($"{heroStat.Key} - {heroStat.Value}");
    }
}

PrintDictionary(TestDict);

static bool FindKey(Dictionary<string,string> MyDictionary, string SearchTerm)
{
        foreach(KeyValuePair<string, string> heroStat in MyDictionary)
    {
        if (heroStat.Key == SearchTerm)
        {
            return true;
        }
    }
    return false;
}

Console.WriteLine(FindKey(TestDict, "RealName"));
// This should print false
Console.WriteLine(FindKey(TestDict, "Name"));

 
static Dictionary<string,int> GenerateDictionary(List<string> Names, List<int> Numbers)
{
    Dictionary<string, int> Result = new Dictionary<string, int> ();

    for (int i = 0; i < Names.Count; i++)
    {
        Result.Add(Names[i] , Numbers[i]); 
    }
    return Result;
}

List<string> People = new List<string>() {"Ruben", "Kaija", "Carlie", "Allen"};
List<int> JustNums = new List<int>() {6,12,7,10};

Dictionary<string, int> WeMadeIt = new Dictionary<string, int> ();
WeMadeIt = GenerateDictionary(People, JustNums);
foreach(KeyValuePair<string, int> dict in WeMadeIt)
{
    Console.WriteLine($"{dict.Key} - {dict.Value}");
}