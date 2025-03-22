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
                System.Console.WriteLine($"{enemey.GetName()} Was broke and had no loot fight an investor next time");
                System.Threading.Thread.Sleep(1500);
                return;
            }
            System.Console.WriteLine("The enemey was not completly broke here his the loot");
            System.Threading.Thread.Sleep(1500);
            enemey.PrintAllIngredients();
            System.Console.WriteLine("You throw the loot into your bag");
            System.Threading.Thread.Sleep(1500);
            if (player.GetLootBag() != null) {
                player.PushLootIntoBag(ref player, ref enemey);
            } else {
                System.Console.WriteLine("Did you lose your loot bag or somthing? its null let me reconsruct your loot bag for you");
                System.Threading.Thread.Sleep(1500);
                player.SetNewLootBag();
                System.Console.WriteLine("pushing in enemey loot into your bag homeslice breadslice dawg");
                System.Threading.Thread.Sleep(1500);
                player.PushLootIntoBag(ref player, ref enemey);
            }
        }

        //death checker MAKE THIS BOOL SO WE CAN RETURN OUT OF BATTLE ALL TOGETHER AS IT STANDS THIS CONTNUES BATTLE AS WE ONLY RETURN OUT OF THIS FUNCTION :(
        public static void DeathChecker(ref Player player, ref Player enemey)
        {
            if (player.GetHealth() <= 0) {
                System.Console.WriteLine($"You died your Health is {player.GetHealth()}");
                System.Threading.Thread.Sleep(1500);
                return;
            } 
            if (enemey.GetHealth() <= 0) {
                System.Console.WriteLine($"{enemey.GetName()} Died a violent death {enemey.GetName()} HP: {enemey.GetHealth()}");
                System.Threading.Thread.Sleep(1500);
                LootPhase(ref player, ref enemey);
                return;
            }
        }

        //first strike attack phase
        public static void InitalStrikePhase(ref Player player, ref Player enemey, Random randNumGen) {
            if (player.GetSpeed() > enemey.GetSpeed()) {
                System.Console.WriteLine($"{enemey.GetName()} sees you sprinting towards him like a mad man {enemey.GetName()} wishes he did more legs");
                System.Threading.Thread.Sleep(1500);
                System.Console.WriteLine($"{player.GetName()} is rolling for inital attack chance must be above 5");
                System.Threading.Thread.Sleep(1500);
                int randomNum = 0;
                for (int i = 0; i < 3; i++)
                {
                    randomNum = randNumGen.Next(10);
                    System.Console.WriteLine(randomNum);
                    System.Console.WriteLine($"{enemey.GetName()} is sweating");
                    System.Threading.Thread.Sleep(1500);
                }
                System.Console.WriteLine($"{player.GetName()} Rolled: {randomNum}");
                if (randomNum > 5)
                {
                    System.Console.WriteLine($"{enemey.GetName()} sheds a tear");
                    System.Threading.Thread.Sleep(1500);
                    int dmg = enemey.GetDamage() - player.GetArmor() / 2;
                    System.Console.WriteLine($"{enemey.GetName()} armor reduced this much Damage: {enemey.GetArmor() / 2}");
                    System.Threading.Thread.Sleep(1500);
                    System.Console.WriteLine($"{player.GetName()} just dealt {dmg} damage");
                    System.Threading.Thread.Sleep(1500);
                    enemey.SetHealth(enemey.GetHealth() - dmg);
                    DeathChecker(ref player, ref enemey);
                }
                else
                {
                    System.Console.WriteLine($"{enemey.GetName()} absolutly dodged your slow attack");
                }
            } else if (enemey.GetSpeed() > player.GetSpeed()) {
                System.Console.WriteLine("It's pretty fast its approaching for an attack");
                System.Threading.Thread.Sleep(1500);
                System.Console.WriteLine($"{enemey.GetName()} is rolling for intital attack chance must be above 5");
                System.Threading.Thread.Sleep(1500);
                int randomNum = 0;
                for (int i = 0; i < 3; i++)
                {
                    randomNum = randNumGen.Next(10);
                    System.Console.WriteLine(randomNum);
                    System.Threading.Thread.Sleep(1500);
                }
                System.Console.WriteLine($"{enemey.GetName()} Rolled: {randomNum}");
                if (randomNum > 5)
                {
                    int dmg = enemey.GetDamage() - player.GetArmor() / 2;
                    System.Console.WriteLine($"Your armor reduced this much damage: {player.GetArmor() / 2}");
                    System.Console.WriteLine($"{enemey.GetName()} just dealt {dmg} damage");
                    player.SetHealth(player.GetHealth() - dmg);
                    DeathChecker(ref player, ref enemey);
                }
                else {
                    System.Console.WriteLine("You evade the enemey Inital strike");
                }
            }
        }

        //true = player one wins/ false = player two wins
        public static bool DodgeChance(int playerOne, int playerTwo, Random randNumGen)
        {
            int playerOneHighestNum = 0;
            int playerTwoHighestNum = 0;
            int temp = 0;
            for (int i = 0; i < playerOne; i++)
            {
                temp = randNumGen.Next(100);
                if (playerOneHighestNum < temp) {
                    playerOneHighestNum = temp;
                }
            }
            temp = 0;
            for (int i = 0; i < playerTwo; i++)
            {
                temp = randNumGen.Next(100);
                if (playerTwoHighestNum < temp) {
                    playerTwoHighestNum = temp;
                }
            }
            if (playerOne >= playerTwo) {
                return true;
            } else {
                return false;
            }
        }

        public static void NormalStrikePhaseMain(ref Player player, ref Player enemey, Random randNumGen, bool isPlayer)
        {
            int randomNum = 0;
            if (isPlayer) {
                System.Console.WriteLine("1 = HunkerDown 1.5x armor  2 = Dodge");
                System.Threading.Thread.Sleep(1500);
                int choice = 0;
                while (choice != 1 && choice != 2) { //this should ensure either 1 or 2 is pressed
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                randomNum = choice;
            } else {
                randomNum = randNumGen.Next(1, 2);
            }
                
            System.Console.WriteLine($"{player.GetName()} Strike at {enemey.GetName()} For: {player.GetDamage()}");
            System.Threading.Thread.Sleep(1500);
            if (randomNum == 1)
            { //if the enemey decides to hunker down
                System.Console.WriteLine($"{enemey.GetName()} Decides to hunker down increasing is armor by half for a total of {enemey.GetArmor() + enemey.GetArmor() / 2}");
                System.Threading.Thread.Sleep(1500);
                
                System.Console.WriteLine($"{player.GetName()} Damage is currently {player.GetDamage()}");
                System.Threading.Thread.Sleep(1500);
                int dmg = player.GetDamage();
                dmg = dmg - (enemey.GetArmor() + (enemey.GetArmor() / 2));
                System.Console.WriteLine($"{player.GetName()} Damage is reduced to {dmg}");
                System.Threading.Thread.Sleep(1500);
                enemey.SetHealth(enemey.GetHealth() - dmg);
                DeathChecker(ref player, ref enemey);

            } else { //if the enemey decides to dodge
                int dmg = player.GetDamage();
                System.Console.WriteLine($"{enemey.GetName()} Decides not to become a shish kebob and attempts to dodge");
                for (int i = 0; i < 3; i++)
                {
                    System.Console.WriteLine($"{enemey.GetName()} and rolls");
                    randomNum = randNumGen.Next(enemey.GetSpeed() / 2);
                    System.Console.WriteLine(randomNum);
                    System.Threading.Thread.Sleep(1500);
                }
                System.Console.WriteLine($"{enemey.GetName()} Rolled: {randomNum}");
                if (randomNum <= 0)
                {
                    System.Console.WriteLine($"giving two pity points because {enemey.GetName} managed to roll a zero :[]");
                    System.Threading.Thread.Sleep(1500);
                    randomNum = 2;
                }
                System.Console.WriteLine($"Initating Roll phase Highest number decides winner");
                if (DodgeChance(randomNum, player.GetSpeed(), randNumGen)) {
                    System.Console.WriteLine($"{enemey.GetName()} weaves your attack by the luck of the gods");
                    System.Threading.Thread.Sleep(1500);
                } else {
                    System.Console.WriteLine($"{enemey.GetName()} Gets clobberd over the head for {dmg}");
                    System.Threading.Thread.Sleep(1500);
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
            } else { //same speed
                System.Console.WriteLine("Since you are just as fast as eachother you coin flip to see who attacks first");
                System.Threading.Thread.Sleep(1500);
                if (randNumGen.Next(1) == 1) {
                    System.Console.WriteLine($"good job {player.GetName()} won the coin flip");
                    System.Threading.Thread.Sleep(1500);
                    NormalStrikePhaseMain(ref player, ref enemey, randNumGen, false);
                    NormalStrikePhaseMain(ref enemey, ref player, randNumGen, true);
                } else {
                    System.Console.WriteLine($"{enemey.GetName()} won the coin flip");
                    System.Threading.Thread.Sleep(1500);
                    NormalStrikePhaseMain(ref enemey, ref player, randNumGen, true);
                    NormalStrikePhaseMain(ref player, ref enemey, randNumGen, false);
                }
            }
        }
        //if you dont know what call by reference is look it up
        public static void NormalFight(ref Player player, ref Player enemey, Random randNumGen)
        {
            //this will need to be changed to be visual at some point
            System.Console.WriteLine($"You Encounterd {enemey.GetName()}");
            System.Threading.Thread.Sleep(1500);
            //First strike attack phase
            InitalStrikePhase(ref player, ref enemey, randNumGen);
            while (player.GetHealth() > 0 || enemey.GetHealth() > 0)
            {
                NormalStrikePhase(ref player, ref enemey, randNumGen);
            }
        }
    }
}
