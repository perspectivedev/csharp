public class MagicCaster : Enemy
{
    int Distance;

    public Attack FireBall;
    public Attack LigtheningBolt;
    public Attack StaffStrike;

    public MagicCaster(string name) : base(name, 80)
    {
        Distance = 5;
        FireBall = new Attack("FireBall", 25);
        LigtheningBolt = new Attack("LighteningBolt", 20);
        StaffStrike = new Attack("StaffStrike", 10);
        AttackList = new List<Attack>(){FireBall, LigtheningBolt, StaffStrike};
    }

    public virtual void Heal(Enemy Target)
    {
        if(_Health == 0)
        {
            System.Console.WriteLine($"{Name} doesn't have anything left.");
            return;
        } else if(Target._Health == 0)
        {
            System.Console.WriteLine($"{Target.Name} you can't save this one.");
        }

        Target._Health += 40;
        if(Target._Health > Target.MaxHealth)
        {
            Target._Health = Target.MaxHealth;
        }
        System.Console.WriteLine($"{Target.Name} health is currently {Target._Health}");
    }


}