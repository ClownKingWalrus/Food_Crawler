// Full Arena.cs with stat boost logic added to DeathChecker (human-style)
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

// the purpose of this class is to handle all combat interactions
// feel free to add some unique combat features as we will be adding random effects over time
// remember RNG is the king of fighters as long as it's manageable

namespace Food_Crawler
{
    class Arena
    {
        // loot phase function
        public static void LootPhase(ref Player player, ref Player enemey)
        {
            if (enemey.GetLootBag() == null)
            {
                Console.WriteLine($"{enemey.GetName()} Was broke and had no loot. Fight an investor next time.");
                Thread.Sleep(1500);
                return;
            }

            Console.WriteLine("The enemy was not completely broke. Here's the loot:");
            Thread.Sleep(1500);
            enemey.PrintAllIngredients();
            Console.WriteLine("You throw the loot into your bag.");
            Thread.Sleep(1500);

            if (player.GetLootBag() != null)
            {
                player.PushLootIntoBag(ref player, ref enemey);
            }
            else
            {
                Console.WriteLine("Did you lose your loot bag or something? It's null. Let me reconstruct your loot bag for you.");
                Thread.Sleep(1500);
                player.SetNewLootBag();
                Console.WriteLine("Pushing in enemy loot into your bag, homeslice breadslice dawg.");
                Thread.Sleep(1500);
                player.PushLootIntoBag(ref player, ref enemey);
            }
        }

        // death checker
        public static void DeathChecker(ref Player player, ref Player enemey)
        {
            if (player.GetHealth() <= 0)
            {
                Console.WriteLine($"You died. Your Health is {player.GetHealth()}");
                Thread.Sleep(1500);
                return;
            }

            if (enemey.GetHealth() <= 0)
            {
                Console.WriteLine($"{enemey.GetName()} dropped dead with {enemey.GetHealth()} HP left (yikes).");
                Thread.Sleep(1500);

                LootPhase(ref player, ref enemey);

                // basic stat boost logic after enemy defeat
                Console.WriteLine("You take a bite of what's left...");
                Thread.Sleep(1000);

                var boost = StatBoostHandler.GetBoost(StatBoostHandler.FoodType.Meat); // TODO: make this dynamic later

                player.SetAttack(player.GetAttack() + boost.atk);
                player.SetArmor(player.GetArmor() + boost.def);
                player.SetMagic(player.GetMagic() + boost.mag);
                player.SetSpeed(player.GetSpeed() + boost.spd);

                boost.PrintBoost();
                Thread.Sleep(1000);
                return;
            }
        }

        // first strike attack phase
        public static void InitalStrikePhase(ref Player player, ref Player enemey, Random randNumGen)
        {
            if (player.GetSpeed() > enemey.GetSpeed())
            {
                Console.WriteLine($"{enemey.GetName()} sees you sprinting toward him like a mad man. {enemey.GetName()} wishes he did more legs.");
                Thread.Sleep(1500);
                Console.WriteLine($"{player.GetName()} is rolling for initial attack chance. Must be above 5.");
                Thread.Sleep(1500);
                int randomNum = 0;
                for (int i = 0; i < 3; i++)
                {
                    randomNum = randNumGen.Next(10);
                    Console.WriteLine(randomNum);
                    Console.WriteLine($"{enemey.GetName()} is sweating...");
                    Thread.Sleep(1500);
                }
                Console.WriteLine($"{player.GetName()} Rolled: {randomNum}");
                if (randomNum > 5)
                {
                    Console.WriteLine($"{enemey.GetName()} sheds a tear");
                    Thread.Sleep(1500);
                    int dmg = enemey.GetDamage() - player.GetArmor() / 2;
                    Console.WriteLine($"{enemey.GetName()} armor reduced this much Damage: {player.GetArmor() / 2}");
                    Console.WriteLine($"{player.GetName()} dealt {dmg} damage");
                    enemey.SetHealth(enemey.GetHealth() - dmg);
                    DeathChecker(ref player, ref enemey);
                }
                else
                {
                    Console.WriteLine($"{enemey.GetName()} dodged your slow attack.");
                }
            }
            else if (enemey.GetSpeed() > player.GetSpeed())
            {
                Console.WriteLine("It's pretty fast... it's approaching for an attack!");
                Thread.Sleep(1500);
                Console.WriteLine($"{enemey.GetName()} is rolling for initial attack chance. Must be above 5.");
                Thread.Sleep(1500);
                int randomNum = 0;
                for (int i = 0; i < 3; i++)
                {
                    randomNum = randNumGen.Next(10);
                    Console.WriteLine(randomNum);
                    Thread.Sleep(1500);
                }
                Console.WriteLine($"{enemey.GetName()} Rolled: {randomNum}");
                if (randomNum > 5)
                {
                    int dmg = enemey.GetDamage() - player.GetArmor() / 2;
                    Console.WriteLine($"Your armor reduced this much damage: {player.GetArmor() / 2}");
                    Console.WriteLine($"{enemey.GetName()} dealt {dmg} damage");
                    player.SetHealth(player.GetHealth() - dmg);
                    DeathChecker(ref player, ref enemey);
                }
                else
                {
                    Console.WriteLine("You evaded the enemy's initial strike.");
                }
            }
        }

        // simplified example of strike phases
        public static void NormalStrikePhase(ref Player player, ref Player enemey, Random randNumGen)
        {
            Console.WriteLine("Both fighters enter a strike phase!");
            int playerRoll = randNumGen.Next(1, 10);
            int enemyRoll = randNumGen.Next(1, 10);

            if (playerRoll > enemyRoll)
            {
                Console.WriteLine($"{player.GetName()} hits first!");
                enemey.SetHealth(enemey.GetHealth() - player.GetDamage());
                DeathChecker(ref player, ref enemey);
            }
            else
            {
                Console.WriteLine($"{enemey.GetName()} strikes you first!");
                player.SetHealth(player.GetHealth() - enemey.GetDamage());
                DeathChecker(ref player, ref enemey);
            }
        }

        public static void NormalFight(ref Player player, ref Player enemey, Random randNumGen)
        {
            Console.WriteLine($"You encountered {enemey.GetName()}!");
            Thread.Sleep(1500);
            InitalStrikePhase(ref player, ref enemey, randNumGen);
            while (player.GetHealth() > 0 && enemey.GetHealth() > 0)
            {
                NormalStrikePhase(ref player, ref enemey, randNumGen);
            }
        }
    }
}
