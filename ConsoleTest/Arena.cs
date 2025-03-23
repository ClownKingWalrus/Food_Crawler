// Full Arena.cs with teammate's original code intact and ONLY stat boost logic added (clearly marked)
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

//the purpose of this class is to handle all combat interactions
//feel free to add some unique combat features as we will be adding random effects over time
//remeber RNG is the king of fighters as long as its managable
namespace Food_Crawler
{
    class Arena
    {
        //loot phase function
        public static void LootPhase(ref Player player, ref Player enemey)
        {
            if (enemey.GetLootBag() == null) {
                Console.WriteLine($"{enemey.GetName()} Was broke and had no loot fight an investor next time");
                Thread.Sleep(1500);
                return;
            }
            Console.WriteLine("The enemey was not completly broke here his the loot");
            Thread.Sleep(1500);
            enemey.PrintAllIngredients();
            Console.WriteLine("You throw the loot into your bag");
            Thread.Sleep(1500);
            if (player.GetLootBag() != null) {
                player.PushLootIntoBag(ref player, ref enemey);
            } else {
                Console.WriteLine("Did you lose your loot bag or somthing? its null let me reconsruct your loot bag for you");
                Thread.Sleep(1500);
                player.SetNewLootBag();
                Console.WriteLine("pushing in enemey loot into your bag homeslice breadslice dawg");
                Thread.Sleep(1500);
                player.PushLootIntoBag(ref player, ref enemey);
            }
        }

        //death checker MAKE THIS BOOL SO WE CAN RETURN OUT OF BATTLE ALL TOGETHER AS IT STANDS THIS CONTNUES BATTLE AS WE ONLY RETURN OUT OF THIS FUNCTION :(
        public static void DeathChecker(ref Player player, ref Player enemey)
        {
            if (player.GetHealth() <= 0) {
                Console.WriteLine($"You died your Health is {player.GetHealth()}");
                Thread.Sleep(1500);
                return;
            } 
            if (enemey.GetHealth() <= 0) {
                Console.WriteLine($"{enemey.GetName()} Died a violent death {enemey.GetName()} HP: {enemey.GetHealth()}");
                Thread.Sleep(1500);
                LootPhase(ref player, ref enemey);

                // --- Stat Boost Logic START ---
                Thread.Sleep(1000);

                var boost = StatBoostHandler.GetBoost(StatBoostHandler.FoodType.Meat); // TODO: Make this dynamic later

                player.SetDamage(player.GetDamage() + boost.atk);
                player.SetArmor(player.GetArmor() + boost.def);
                player.SetMagic(player.GetMagic() + boost.mag);
                player.SetSpeed(player.GetSpeed() + boost.spd);

                boost.PrintBoost();
                Thread.Sleep(1000);
                // --- Stat Boost Logic END ---

                return;
            }
        }

        public static void InitalStrikePhase(ref Player player, ref Player enemey, Random randNumGen) {
            if (player.GetSpeed() > enemey.GetSpeed()) {
                Console.WriteLine($"{enemey.GetName()} sees you sprinting towards him like a mad man {enemey.GetName()} wishes he did more legs");
                Thread.Sleep(1500);
                Console.WriteLine($"{player.GetName()} is rolling for inital attack chance must be above 5");
                Thread.Sleep(1500);
                int randomNum = 0;
                for (int i = 0; i < 3; i++) {
                    randomNum = randNumGen.Next(10);
                    Console.WriteLine(randomNum);
                    Console.WriteLine($"{enemey.GetName()} is sweating");
                    Thread.Sleep(1500);
                }
                Console.WriteLine($"{player.GetName()} Rolled: {randomNum}");
                if (randomNum > 5) {
                    Console.WriteLine($"{enemey.GetName()} sheds a tear");
                    Thread.Sleep(1500);
                    int dmg = enemey.GetDamage() - player.GetArmor() / 2;
                    Console.WriteLine($"{enemey.GetName()} armor reduced this much Damage: {player.GetArmor() / 2}");
                    Console.WriteLine($"{player.GetName()} just dealt {dmg} damage");
                    enemey.SetHealth(enemey.GetHealth() - dmg);
                    DeathChecker(ref player, ref enemey);
                } else {
                    Console.WriteLine($"{enemey.GetName()} absolutly dodged your slow attack");
                }
            } else if (enemey.GetSpeed() > player.GetSpeed()) {
                Console.WriteLine("It's pretty fast its approaching for an attack");
                Thread.Sleep(1500);
                Console.WriteLine($"{enemey.GetName()} is rolling for intital attack chance must be above 5");
                Thread.Sleep(1500);
                int randomNum = 0;
                for (int i = 0; i < 3; i++) {
                    randomNum = randNumGen.Next(10);
                    Console.WriteLine(randomNum);
                    Thread.Sleep(1500);
                }
                Console.WriteLine($"{enemey.GetName()} Rolled: {randomNum}");
                if (randomNum > 5) {
                    int dmg = enemey.GetDamage() - player.GetArmor() / 2;
                    Console.WriteLine($"Your armor reduced this much damage: {player.GetArmor() / 2}");
                    Console.WriteLine($"{enemey.GetName()} just dealt {dmg} damage");
                    player.SetHealth(player.GetHealth() - dmg);
                    DeathChecker(ref player, ref enemey);
                } else {
                    Console.WriteLine("You evade the enemey Inital strike");
                }
            }
        }

        public static bool DodgeChance(int playerOne, int playerTwo, Random randNumGen)
        {
            int playerOneHighestNum = 0;
            int playerTwoHighestNum = 0;
            int temp = 0;
            for (int i = 0; i < playerOne; i++) {
                temp = randNumGen.Next(100);
                if (playerOneHighestNum < temp) {
                    playerOneHighestNum = temp;
                }
            }
            temp = 0;
            for (int i = 0; i < playerTwo; i++) {
                temp = randNumGen.Next(100);
                if (playerTwoHighestNum < temp) {
                    playerTwoHighestNum = temp;
                }
            }
            return playerOne >= playerTwo;
        }

        public static void NormalStrikePhaseMain(ref Player player, ref Player enemey, Random randNumGen, bool isPlayer)
        {
            int randomNum = 0;
            if (isPlayer) {
                Console.WriteLine("1 = HunkerDown 1.5x armor  2 = Dodge");
                Thread.Sleep(1500);
                int choice = 0;
                while (choice != 1 && choice != 2) {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                randomNum = choice;
            } else {
                randomNum = randNumGen.Next(1, 2);
            }

            Console.WriteLine($"{player.GetName()} Strike at {enemey.GetName()} For: {player.GetDamage()}");
            Thread.Sleep(1500);
            if (randomNum == 1) {
                Console.WriteLine($"{enemey.GetName()} Decides to hunker down increasing is armor by half for a total of {enemey.GetArmor() + enemey.GetArmor() / 2}");
                Thread.Sleep(1500);
                Console.WriteLine($"{player.GetName()} Damage is currently {player.GetDamage()}");
                Thread.Sleep(1500);
                int dmg = player.GetDamage();
                dmg = dmg - (enemey.GetArmor() + (enemey.GetArmor() / 2));
                Console.WriteLine($"{player.GetName()} Damage is reduced to {dmg}");
                Thread.Sleep(1500);
                enemey.SetHealth(enemey.GetHealth() - dmg);
                DeathChecker(ref player, ref enemey);
            } else {
                int dmg = player.GetDamage();
                Console.WriteLine($"{enemey.GetName()} Decides not to become a shish kebob and attempts to dodge");
                for (int i = 0; i < 3; i++) {
                    Console.WriteLine($"{enemey.GetName()} and rolls");
                    randomNum = randNumGen.Next(enemey.GetSpeed() / 2);
                    Console.WriteLine(randomNum);
                    Thread.Sleep(1500);
                }
                Console.WriteLine($"{enemey.GetName()} Rolled: {randomNum}");
                if (randomNum <= 0) {
                    Console.WriteLine($"giving two pity points because {enemey.GetName} managed to roll a zero :[]");
                    Thread.Sleep(1500);
                    randomNum = 2;
                }
                Console.WriteLine($"Initating Roll phase Highest number decides winner");
                if (DodgeChance(randomNum, player.GetSpeed(), randNumGen)) {
                    Console.WriteLine($"{enemey.GetName()} weaves your attack by the luck of the gods");
                    Thread.Sleep(1500);
                } else {
                    Console.WriteLine($"{enemey.GetName()} Gets clobberd over the head for {dmg}");
                    Thread.Sleep(1500);
                    enemey.SetHealth(enemey.GetHealth() - dmg);
                    DeathChecker(ref player, ref enemey);
                }
            }
        }

        public static void NormalStrikePhase(ref Player player, ref Player enemey, Random randNumGen)
        {
            if (player.GetSpeed() > enemey.GetSpeed()) {
                NormalStrikePhaseMain(ref player, ref enemey, randNumGen, false);
                NormalStrikePhaseMain(ref enemey, ref player, randNumGen, true);
            } else if (enemey.GetSpeed() > player.GetSpeed()) {
                NormalStrikePhaseMain(ref enemey, ref player, randNumGen, true);
                NormalStrikePhaseMain(ref player, ref enemey, randNumGen, false);
            } else {
                Console.WriteLine("Since you are just as fast as eachother you coin flip to see who attacks first");
                Thread.Sleep(1500);
                if (randNumGen.Next(1) == 1) {
                    Console.WriteLine($"good job {player.GetName()} won the coin flip");
                    Thread.Sleep(1500);
                    NormalStrikePhaseMain(ref player, ref enemey, randNumGen, false);
                    NormalStrikePhaseMain(ref enemey, ref player, randNumGen, true);
                } else {
                    Console.WriteLine($"{enemey.GetName()} won the coin flip");
                    Thread.Sleep(1500);
                    NormalStrikePhaseMain(ref enemey, ref player, randNumGen, true);
                    NormalStrikePhaseMain(ref player, ref enemey, randNumGen, false);
                }
            }
        }

        public static void NormalFight(ref Player player, ref Player enemey, Random randNumGen)
        {
            Console.WriteLine($"You Encounterd {enemey.GetName()}");
            Thread.Sleep(1500);
            InitalStrikePhase(ref player, ref enemey, randNumGen);
            while (player.GetHealth() > 0 || enemey.GetHealth() > 0) {
                NormalStrikePhase(ref player, ref enemey, randNumGen);
            }
        }
    }
}
