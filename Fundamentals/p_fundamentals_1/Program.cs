    for(int i = 1; i <= 255; i++)
    {
        Console.WriteLine(i);
    }


    Random rnd = new Random();
    for(int j = 0; j < 5; j++)
    {
        Console.WriteLine(rnd.Next(10, 21));
    }
    int sum = 0;
    Random Rnd = new Random();
    for(int j = 0; j < 5; j++)
    {
        sum = sum + Rnd.Next(10, 21);
    }
    Console.WriteLine(sum);
    for(int i = 1; i <= 100; i++)
    {
        if(i % 3 == 0 && i % 5 == 0){
            continue;
        } else if ( i % 3 == 0 ^ i % 5 == 0){
            Console.WriteLine(i);
        }
    }
    for(int i = 1; i <= 100; i++)
    {
        if(i % 3 == 0 && i % 5 == 0){
            continue;
        } else if ( i % 3 == 0){
            Console.WriteLine("Fizz");
        } else if ( i % 5 == 0){
            Console.WriteLine("Buzz");
        }
    }
    for(int i = 1; i <= 100; i++)
    {
        if(i % 3 == 0 && i % 5 == 0){
            Console.WriteLine("FizzBuzz");
        } else if ( i % 3 == 0){
            Console.WriteLine("Fizz");
        } else if ( i % 5 == 0){
            Console.WriteLine("Buzz");
        }
    }

