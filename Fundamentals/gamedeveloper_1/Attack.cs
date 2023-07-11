public class Attack 
{
    public string Name;
    public int DamageAmount;

    public Attack(string name, int damage)
    {
        Name = name;
        DamageAmount = damage;
    }

    public override string ToString()
    {
        return $"{Name} -> {DamageAmount}";
    }
}