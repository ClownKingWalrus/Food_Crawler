using System;
using Food_Crawler;

class Program
{
    static void Main(string[] args)
    {
        Player player = new Player("Tony");
        Player enemy = new Player("Burger Goblin");

        Random rand = new Random();
        Arena.NormalFight(ref player, ref enemy, rand);
    }
}