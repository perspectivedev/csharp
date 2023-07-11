public class RangeFighter : Enemy
{
    int Distance;

    public Attack Arrow;
    public Attack ThrowingKnife;

    public RangeFighter(string name) : base(name, 20)
    {
        Distance = 5;
        Arrow = new Attack("Arrow", 20);
        ThrowingKnife = new Attack("ThrowingKnife", 15);
        AttackList = new List<Attack>(){Arrow, ThrowingKnife};
    }

    public override void PerformAttack(Enemy Target, Attack ChosenAttack)
    {
        if(Distance < 20)
        {
            System.Console.WriteLine($"This is the {Distance}. Minimum distance to perform {ChosenAttack} is 10");
        } else 
        {
            base.PerformAttack(Target, ChosenAttack);
        }
    }

    public void Dash(Enemy Target)
    {
        Distance = 20;
        System.Console.WriteLine($"{Name} moved dodged by a distance of {Distance}, from {Target.Name}");
    }
}