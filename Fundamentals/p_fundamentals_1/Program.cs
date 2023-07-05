 // For loop that INCLUDES 10
// for(int i = 1; i <= 255; i++)
// {
//     Console.WriteLine(i);
// }


    // Random rnd = new Random();
    // for(int j = 0; j < 5; j++)
    // {
    //     Console.WriteLine(rnd.Next(10, 21));
    // }
    
    Random rnd = new Random();
    int sum = new int();
    for(int j = 0; j < 5; j++)
    {
        
        Console.WriteLine("Trying to print rnd : {0}", rnd.Next(10, 21));
        Console.WriteLine("Sum : {0}",sum + rnd.Next(10, 20));
    }

