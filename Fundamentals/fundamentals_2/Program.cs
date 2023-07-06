int[] arr = new int[10] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
string[] strArr = new string[4] {"Tim", "Martin", "Nikki", "Sara"};
bool[] boolArr = new bool[10];

Console.WriteLine(arr[0]);
Console.WriteLine(arr[1]);
Console.WriteLine(arr[2]);
Console.WriteLine(arr[3]);
Console.WriteLine(arr[4]);
Console.WriteLine(arr[5]);
Console.WriteLine(arr[7]);
Console.WriteLine(arr[8]);
Console.WriteLine(arr[9]);
Console.WriteLine(strArr[0]);
Console.WriteLine(strArr[1]);
Console.WriteLine(strArr[2]);
Console.WriteLine(strArr[3]);

for(int i = 0; i < 10; i++){
    if(i % 2 == 0){
        boolArr[i] = true;
        Console.WriteLine(boolArr[0]);
    } else {
        boolArr[i] = false;
        Console.WriteLine(boolArr[1]);
    }
}

List<string> iceCream = new List<string>() {"Cookie dough", "Oatmeal"};
iceCream.Add("Peaches and Cream");
iceCream.Add("Huskie Tracks");
iceCream.Add("Vanilla");
Console.WriteLine(iceCream.Count);
Console.WriteLine(iceCream[1]);
iceCream.RemoveAt(1);
Console.WriteLine(iceCream.Count);

Dictionary<string, string> user = new Dictionary<string, string>();

Random rand = new Random();

foreach (string name in strArr)
{
    int i = rand.Next(4);
    user.Add(name, iceCream[i]);
}

foreach (KeyValuePair<string, string> entry in user)
{
    Console.WriteLine($"{entry.Key} - {entry.Value}");
}

