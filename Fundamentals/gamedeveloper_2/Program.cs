// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World! Let's play two!");

MeleeFighter PussNBoots = new MeleeFighter("PussNBoots");
MeleeFighter BatMan = new MeleeFighter("BatMan");
RangeFighter Elf = new RangeFighter("Elf");
MagicCaster Oz = new MagicCaster("Oz");
Enemy Joker = new Enemy("Joker", 100);
Enemy Riddler = new Enemy("Riddler", 100);
Attack Mallet = new Attack("Mallet", 20);
Attack LapelFlower = new Attack("LapelFlower", 15);
Attack Crowbar = new Attack("Crowbar", 15);
Attack JoyBuzzer = new Attack("JoyBuzzer", 13);
Attack Cane = new Attack("Cane", 10);
Attack Holgram = new Attack("Holgram", 5);
Attack ElectricalBlast = new Attack("ElectricalBlast", 10);
Riddler.AddAttack(Cane);
PussNBoots.PerformAttack(Joker, PussNBoots.Punch);
BatMan.PerformAttack(Joker, BatMan.Kick);
BatMan.Rage(Joker);
PussNBoots.Rage(Riddler);
BatMan.Rage(Joker);
Elf.Dash(PussNBoots);
Elf.Dash(BatMan);
Oz.Heal(Joker);
Oz.Heal(Riddler);
Riddler.AddAttack(Holgram);
Riddler.AddAttack(ElectricalBlast);
Joker.AddAttack(Crowbar);
Joker.AddAttack(JoyBuzzer);
Joker.AddAttack(Mallet);
Joker.AddAttack(LapelFlower);
for(int i = 0; i < 6; i++)
{
    Joker.RndAttack();
    Riddler.RndAttack();
}