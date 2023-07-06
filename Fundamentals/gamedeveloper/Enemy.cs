public class Enemy 
{
    public string Name;
    public int Health;
    public List<Attack> AttackList {get; set;}

    public Enemy(string name, int health = 100)
    {
        Name = name;
        Health = health;
        AttackList = new List<Attack>();
    }

    public void AddAttack(Attack name)
    {
        AttackList.Add(name);
    }

    public void RndAttack()
    {
        Random rnd = new Random();
        int idx = rnd.Next(AttackList.Count);
        Console.WriteLine(AttackList[idx]);
    }
}
