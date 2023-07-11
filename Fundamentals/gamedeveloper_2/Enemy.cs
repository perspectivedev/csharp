public class Enemy 
{
    public string Name;
    public int MaxHealth;
    private int HEALTH;
    public int _Health
    {
        get
        {
            return HEALTH;
        }
        set
        {
            HEALTH = value;
        }
    }
    public List<Attack> AttackList {get; set;}

    public Enemy(string name, int health)
    {
        Name = name;
        MaxHealth = health;
        HEALTH = health;
        AttackList = new List<Attack>();
    }

    public Enemy AddAttack(Attack name)
    {
        AttackList.Add(name);
        return this;
    }

    public Attack RndAttack()
    {
        Random rnd = new Random();
        int idx = rnd.Next(AttackList.Count);
        Console.WriteLine(AttackList[idx]);
        return AttackList[idx];
    }

    public virtual void PerformAttack(Enemy Target, Attack ChosenAttack)
    {
        if(_Health == 0)
        {
            string first_message = $"{Name} is finished, attack someone else!";
            Console.WriteLine(first_message);
            return;
        } else if (Target._Health == 0)
        {
            string second_message = $"This {Target.Name} is finished, attack someone else!";
            Console.WriteLine(second_message);
        }
        Target._Health -= ChosenAttack.DamageAmount;
        if(Target._Health < 0)
        {
            Target._Health = 0;
        }
        Console.WriteLine($"{Name} Attack {Target.Name}, dealing {ChosenAttack.DamageAmount} damage and reducing {Target.Name}'s health to {Target.HEALTH}!!");
    }
}
