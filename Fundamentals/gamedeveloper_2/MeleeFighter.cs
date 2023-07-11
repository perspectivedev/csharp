public class MeleeFighter : Enemy
{
    public Attack Punch;
    public Attack Kick;
    public Attack Tackle;

    public MeleeFighter(string name) : base(name, 120)
    {
        Punch = new Attack("Punch", 20);
        Kick = new Attack("kick", 15);
        Tackle = new Attack("Tackle", 25);
        AttackList = new List<Attack>(){Punch, Kick, Tackle};
    }

    public void Rage(Enemy Target)
    {
        Attack Name = base.RndAttack();
        Name.DamageAmount += 10;
        PerformAttack(Target, Name);
        Name.DamageAmount -= 10;
    }
}