#pragma warning disable CS8618


List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46, "Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};
// Example Query - Prints all Stratovolcano eruptions
IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");
// Execute Assignment Tasks here!
 
// Helper method to print each item in a List or IEnumerable. This should remain at the bottom of your class!
static void PrintEach(IEnumerable<Eruption> items, string msg = "")
{
    Console.WriteLine("\n" + msg);
    foreach (Eruption item in items)
    {
        Console.WriteLine(item.ToString());
    }
}

Console.WriteLine("---------------------------------------------");

Console.WriteLine("Link Eruption exercises.");

Eruption firstInChile = eruptions.Where( e => e.Location == "Chile").OrderBy( e => e.Year).FirstOrDefault();
Console.WriteLine(firstInChile);

Eruption? FirstHawaiianIs = eruptions.Where(e => e.Location == "Hawaiian Is").FirstOrDefault();
Console.WriteLine(FirstHawaiianIs);

Eruption? firstGreenLand = eruptions.FirstOrDefault(e => e.Location == "GreenLand");
Console.WriteLine(firstGreenLand != null ? firstGreenLand : "No Greenland Eruption found.");

Eruption? after1900InMZ = eruptions.Where(e => e.Location == "New Zealand" && e.Year > 1900).FirstOrDefault();
Console.WriteLine(after1900InMZ != null ? after1900InMZ : "No New Zealand Is Eruption found.");

IEnumerable<Eruption> allEruptions = eruptions.Where( e => e.ElevationInMeters > 2000).ToList();
PrintEach(allEruptions, "This is all the Eruptions:");

IEnumerable<Eruption> AllVolcanos = eruptions.Where( e => e.Volcano[0] == 'L').ToList();
PrintEach(AllVolcanos, "This is all the Volcano's.");
Console.WriteLine("This is the amount of eruptions for all Volcano's: {0}", AllVolcanos.Count());

int HighestPeak = eruptions.Max(e => e.ElevationInMeters);
System.Console.WriteLine(HighestPeak);

IEnumerable<Eruption> VolcanoElevation = eruptions.Where( e => e.ElevationInMeters == HighestPeak);
PrintEach(VolcanoElevation, "Show me the top!!!!");

IEnumerable<Eruption> VolcanoByAlphabet = eruptions.OrderBy(e => e.Volcano);
PrintEach(VolcanoByAlphabet, "Alphabetical order Below:");

int VolcanoEvalSum = eruptions.Sum(e => e.ElevationInMeters);
System.Console.WriteLine("The sum of all Volcano elevation {0}", VolcanoEvalSum);

bool AnyVolcano = eruptions.Any( e => e.Year == 2000 );
System.Console.WriteLine(AnyVolcano);

IEnumerable<Eruption> FindType = eruptions.OrderByDescending(e => e.Type == "Stratovolcano").Take(3);
PrintEach(FindType, "Found all and ordered the first three:");

IEnumerable<string> AllEruptions =  eruptions.Where(e => e.Year > 1000).OrderBy(e => e.Volcano).Select(e => e.Volcano);
foreach( string name in AllEruptions )
{
Console.WriteLine(name);
}

