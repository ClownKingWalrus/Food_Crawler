using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

//the purpose of this class is to handle all combat interactions
//feel free to add some unique combat features as we will be adding random effects over time
//remeber RNG is the king of fighters as long as its managable
//LAUNCH PHASE is how you actually call the start of the f
namespace Food_Crawler
{
    class Arena
    {
        //loot phase function
        public static void LootPhase(ref Player player, ref Enemey enemey, Form1 mainForm)
        {
            mainForm.MusicFakeLooper();
            if (enemey.GetLootBag() == null) {
                mainForm.GetNarratorTextBox().Text = $"{enemey.GetName()} Was broke and had no loot fight an investor next time";
                Application.DoEvents();
                mainForm.NextButtonClicked(mainForm.NextButton);
                while (mainForm.NextButton.Enabled == true)
                {
                    Application.DoEvents();
                }
                return;
            }
            mainForm.GetNarratorTextBox().Text = "The enemey was not completly broke here his the loot";
            Application.DoEvents();
            mainForm.NextButtonClicked(mainForm.NextButton);
            while (mainForm.NextButton.Enabled == true)
            {
                Application.DoEvents();
            }
            enemey.PrintAllIngredients(mainForm);
            mainForm.NextButtonClicked(mainForm.NextButton);
            while (mainForm.NextButton.Enabled == true)
            {
                Application.DoEvents();
            }
            mainForm.GetNarratorTextBox().Text = "You throw the loot into your bag";
            Application.DoEvents();
            mainForm.NextButtonClicked(mainForm.NextButton);
            while (mainForm.NextButton.Enabled == true)
            {
                Application.DoEvents();
            }
            if (player.GetLootBag() != null) {
                player.PushLootIntoBag(ref player, ref enemey);
            } else {
                mainForm.GetNarratorTextBox().Text = "Did you lose your loot bag or somthing? its null let me reconsruct your loot bag for you";
                Application.DoEvents();
                mainForm.NextButtonClicked(mainForm.NextButton);
                while (mainForm.NextButton.Enabled == true)
                {
                    Application.DoEvents();
                }
                player.SetNewLootBag();
                mainForm.GetNarratorTextBox().Text = "pushing in enemey loot into your bag homeslice breadslice dawg";
                Application.DoEvents();
                mainForm.NextButtonClicked(mainForm.NextButton);
                while (mainForm.NextButton.Enabled == true)
                {
                    Application.DoEvents();
                }
                player.PushLootIntoBag(ref player, ref enemey);
            }
            mainForm.GetNarratorTextBox().Text = $"like a beast you steal {enemey.GetName()} Money";
            mainForm.NextButtonClicked(mainForm.NextButton);
            while (mainForm.NextButton.Enabled == true)
            {
                Application.DoEvents();
            }
            Random randnumgen = new();
            int randnum = 0;
            randnum = randnumgen.Next(1, 10);
            mainForm.GetNarratorTextBox().Text = $"{player.GetName()} found ${randnum} total money ${player.GetMoney() + randnum}";
            mainForm.NextButtonClicked(mainForm.NextButton);
            while (mainForm.NextButton.Enabled == true)
            {
                Application.DoEvents();
            }
            player.SetMoney(player.GetMoney() + randnum);
        }

        //death checker MAKE THIS BOOL SO WE CAN RETURN OUT OF BATTLE ALL TOGETHER AS IT STANDS THIS CONTNUES BATTLE AS WE ONLY RETURN OUT OF THIS FUNCTION :(
        public static bool DeathChecker(ref Player player, ref Enemey enemey, Form1 mainForm)
        {
            mainForm.MusicFakeLooper();
            mainForm.PlayerStatsLabelUpdater();
            mainForm.EnemeyStatsLabelUpdater(ref enemey);
            if (player.GetHealth() <= 0) {
                mainForm.GetNarratorTextBox().Text = $"You died your Health is {player.GetHealth()}";
                Application.DoEvents();

                mainForm.NextButtonClicked(mainForm.NextButton);
                while (mainForm.NextButton.Enabled == true)
                {
                    Application.DoEvents();
                }

                return true;
            } 
            if (enemey.GetHealth() <= 0) {
                mainForm.GetNarratorTextBox().Text = $"{enemey.GetName()} Died a violent death {enemey.GetName()} HP: {enemey.GetHealth()}";
                Application.DoEvents();

                mainForm.NextButtonClicked(mainForm.NextButton);
                while (mainForm.NextButton.Enabled == true)
                {
                    Application.DoEvents();
                }
                //temporary
                Random rand = new();
                int lspGained = 0;
                int exphpmuli = 0;
                if (player.GetHealth() < enemey.GetDamage())
                {
                    exphpmuli = 10;
                } else if (player.GetHealth() < (enemey.GetDamage() * 2)) {
                    exphpmuli = 5;
                } else {
                    exphpmuli = 2;
                }
                lspGained = rand.Next(1, 5);
                lspGained = lspGained + exphpmuli;
                mainForm.GetNarratorTextBox().Text = $"LSP gained from fight is {lspGained} for a total of {lspGained + player.GetLooseStatPoints()}";
                mainForm.NextButtonClicked(mainForm.NextButton);
                while (mainForm.NextButton.Enabled == true)
                {
                    Application.DoEvents();
                }
                player.SetLooseStatPoints(player.GetLooseStatPoints() + lspGained);
                LootPhase(ref player, ref enemey, mainForm);
                return true;
            }
            return false;
        }

        //first strike attack phase
        public static bool InitalStrikePhase(ref Player player, ref Enemey enemey, Random randNumGen, Form1 mainForm) {
            if (player.GetSpeed() > enemey.GetSpeed()) {
                mainForm.GetNarratorTextBox().Text = $"{enemey.GetName()} sees you sprinting towards him like a mad man {enemey.GetName()} wishes he did more legs";
                Application.DoEvents();
                mainForm.NextButtonClicked(mainForm.NextButton);
                while (mainForm.NextButton.Enabled == true)
                {
                    Application.DoEvents();
                }
                mainForm.GetNarratorTextBox().Text = $"{player.GetName()} is rolling for inital attack chance must be above 5";
                Application.DoEvents();

                mainForm.NextButtonClicked(mainForm.NextButton);
                while (mainForm.NextButton.Enabled == true)
                {
                    Application.DoEvents();
                }

                int randomNum = 0;
                for (int i = 0; i < 3; i++)
                {
                    randomNum = randNumGen.Next(10);
                    mainForm.GetNarratorTextBox().Text = ".";
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(200);
                    mainForm.GetNarratorTextBox().Text = "..";
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(200);
                    mainForm.GetNarratorTextBox().Text = "...";
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(200);
                    mainForm.GetNarratorTextBox().Text = $"{enemey.GetName()} is sweating";
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(400);
                }
                mainForm.GetNarratorTextBox().Text = $"{player.GetName()} Rolled: {randomNum}";
                Application.DoEvents();
                mainForm.NextButtonClicked(mainForm.NextButton);

                while (mainForm.NextButton.Enabled == true)
                {
                    Application.DoEvents();
                }

                if (randomNum > 5)
                {
                    mainForm.GetNarratorTextBox().Text = $"{enemey.GetName()} sheds a tear";
                    Application.DoEvents();
                    mainForm.NextButtonClicked(mainForm.NextButton);
                    while (mainForm.NextButton.Enabled == true)
                    {
                        Application.DoEvents();
                    }
                    int dmg = player.GetDamage() - enemey.GetArmor() / 2;
                    if (enemey.GetArmor()/2 >= player.GetDamage())
                    {
                        dmg = 1;
                        enemey.SetHealth(enemey.GetHealth() - dmg);
                    } else
                    {
                        enemey.SetHealth(enemey.GetHealth() - dmg);
                    }
                    mainForm.GetNarratorTextBox().Text = $"{enemey.GetName()} armor reduced this much Damage: {enemey.GetArmor() / 2}";
                    Application.DoEvents();
                    mainForm.NextButtonClicked(mainForm.NextButton);
                    while (mainForm.NextButton.Enabled == true)
                    {
                        Application.DoEvents();
                    }
                    mainForm.GetNarratorTextBox().Text = $"{player.GetName()} just dealt {dmg} damage";
                    Application.DoEvents();
                    mainForm.NextButtonClicked(mainForm.NextButton);
                    while (mainForm.NextButton.Enabled == true)
                    {
                        Application.DoEvents();
                    }
                    if (DeathChecker(ref player, ref enemey, mainForm))
                    {
                        return true;
                    }
                }
                else
                {
                    mainForm.GetNarratorTextBox().Text = $"{enemey.GetName()} absolutly dodged your slow attack";
                    Application.DoEvents();

                    mainForm.NextButtonClicked(mainForm.NextButton);
                    while (mainForm.NextButton.Enabled == true)
                    {
                        Application.DoEvents();
                    }
                }
            } else if (enemey.GetSpeed() > player.GetSpeed()) {
                mainForm.GetNarratorTextBox().Text = "It's pretty fast its approaching for an attack";
                Application.DoEvents();
                mainForm.NextButtonClicked(mainForm.NextButton);
                while (mainForm.NextButton.Enabled == true)
                {
                    Application.DoEvents();
                }
                mainForm.GetNarratorTextBox().Text = $"{enemey.GetName()} is rolling for intital attack chance must be above 5";
                Application.DoEvents();
                mainForm.NextButtonClicked(mainForm.NextButton);
                while (mainForm.NextButton.Enabled == true)
                {
                    Application.DoEvents();
                }
                int randomNum = 0;
                for (int i = 0; i < 3; i++)
                {
                    randomNum = randNumGen.Next(10);
                    mainForm.GetNarratorTextBox().Text = ".";
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(500);
                    mainForm.GetNarratorTextBox().Text = "..";
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(500);
                    mainForm.GetNarratorTextBox().Text = "...";
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(500);
                }
                mainForm.GetNarratorTextBox().Text = $"{enemey.GetName()} Rolled: {randomNum}";
                Application.DoEvents();

                mainForm.NextButtonClicked(mainForm.NextButton);
                while (mainForm.NextButton.Enabled == true)
                {
                    Application.DoEvents();
                }

                if (randomNum > 5)
                {
                    int dmg = enemey.GetDamage() - player.GetArmor() / 2;
                    if (player.GetArmor()/2 > enemey.GetDamage())
                    {
                        dmg = 1;
                        player.SetHealth(player.GetHealth() - dmg);
                    } else
                    {
                        player.SetHealth(player.GetHealth() - dmg);
                    }

                        mainForm.GetNarratorTextBox().Text = $"Your armor reduced this much damage: {player.GetArmor() / 2}";
                    Application.DoEvents();
                    mainForm.NextButtonClicked(mainForm.NextButton);
                    while (mainForm.NextButton.Enabled == true)
                    {
                        Application.DoEvents();
                    }
                    mainForm.GetNarratorTextBox().Text = $"{enemey.GetName()} just dealt {dmg} damage";
                    Application.DoEvents();
                    mainForm.NextButtonClicked(mainForm.NextButton);
                    while (mainForm.NextButton.Enabled == true)
                    {
                        Application.DoEvents();
                    }
                    if (DeathChecker(ref player, ref enemey, mainForm))
                    {
                        return true;
                    }
                }
                else {
                    mainForm.GetNarratorTextBox().Text = "You evade the enemey Inital strike";
                    Application.DoEvents();
                    mainForm.NextButtonClicked(mainForm.NextButton);
                    while (mainForm.NextButton.Enabled == true)
                    {
                        Application.DoEvents();
                    }
                }
            }
            return false;
        }

        //true = player one wins/ false = player two wins
        public static bool DodgeChance(int playerOne, int playerTwo, Random randNumGen, Form1 mainForm)
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

        public static bool NormalStrikePhaseMainPlayerTurn(ref Player player, ref Enemey enemey, Random randNumGen, bool isPlayer, Form1 mainForm)
        {
            mainForm.GetNarratorTextBox().Text = $"Player aims there next attack at {enemey.GetName()}";
            mainForm.NextButtonClicked(mainForm.NextButton);
            while (mainForm.NextButton.Enabled == true)
            {
                Application.DoEvents();
            }
            int randomNum = 0;
            randomNum = randNumGen.Next(1, 2);
            mainForm.GetNarratorTextBox().Text = $"{player.GetName()} Strike at {enemey.GetName()} For: {player.GetDamage()}";
            Application.DoEvents();
            mainForm.NextButtonClicked(mainForm.NextButton);
            while (mainForm.NextButton.Enabled == true)
            {
                Application.DoEvents();
            }
            if (randomNum == 1)
            { //if the enemey decides to hunker down
                mainForm.GetNarratorTextBox().Text = $"{enemey.GetName()} Decides to hunker down increasing is armor by half for a total of {enemey.GetArmor() + enemey.GetArmor() / 2}";
                Application.DoEvents();
                mainForm.NextButtonClicked(mainForm.NextButton);
                while (mainForm.NextButton.Enabled == true)
                {
                    Application.DoEvents();
                }
                mainForm.GetNarratorTextBox().Text = $"{player.GetName()} Damage is currently {player.GetDamage()}";
                Application.DoEvents();
                mainForm.NextButtonClicked(mainForm.NextButton);
                while (mainForm.NextButton.Enabled == true)
                {
                    Application.DoEvents();
                }
                int dmg = player.GetDamage();
                if (enemey.GetArmor() + (enemey.GetArmor() / 2) >= player.GetDamage())
                {
                    dmg = 1;
                    enemey.SetHealth(enemey.GetHealth() - dmg);
                } else
                {
                    dmg = dmg - (enemey.GetArmor() + (enemey.GetArmor() / 2));
                    enemey.SetHealth(enemey.GetHealth() - dmg);
                }
                    mainForm.GetNarratorTextBox().Text = $"{player.GetName()} Damage is reduced to {dmg}";
                Application.DoEvents();
                mainForm.NextButtonClicked(mainForm.NextButton);
                while (mainForm.NextButton.Enabled == true)
                {
                    Application.DoEvents();
                }
                
                if (DeathChecker(ref player, ref enemey, mainForm)) { return true; }

            }
            else
            { //if the enemey decides to dodge
                int dmg = player.GetDamage();
                mainForm.GetNarratorTextBox().Text = $"{enemey.GetName()} Decides not to become a shish kebob and attempts to dodge";
                Application.DoEvents();
                for (int i = 0; i < 3; i++)
                {
                    randomNum = randNumGen.Next(enemey.GetSpeed() / 2);
                    mainForm.GetNarratorTextBox().Text = ".";
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(200);
                    mainForm.GetNarratorTextBox().Text = "..";
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(200);
                    mainForm.GetNarratorTextBox().Text = "...";
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(200);
                    mainForm.GetNarratorTextBox().Text = $"{enemey.GetName()} is sweating";
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(400);
                }
                mainForm.GetNarratorTextBox().Text = $"{enemey.GetName()} Rolled: {randomNum}";
                Application.DoEvents();
                mainForm.NextButtonClicked(mainForm.NextButton);
                while (mainForm.NextButton.Enabled == true)
                {
                    Application.DoEvents();
                }
                if (randomNum <= 0)
                {
                    mainForm.GetNarratorTextBox().Text = $"giving two pity points because {enemey.GetName()} managed to roll a zero D:";
                    Application.DoEvents();
                    mainForm.NextButtonClicked(mainForm.NextButton);
                    while (mainForm.NextButton.Enabled == true)
                    {
                        Application.DoEvents();
                    }
                    randomNum = 2;
                }
                mainForm.GetNarratorTextBox().Text = $"Initating Roll phase Highest number decides winner";
                Application.DoEvents();
                mainForm.NextButtonClicked(mainForm.NextButton);
                while (mainForm.NextButton.Enabled == true)
                {
                    Application.DoEvents();
                }
                if (DodgeChance(randomNum, player.GetSpeed(), randNumGen, mainForm))
                {
                    mainForm.GetNarratorTextBox().Text = $"{enemey.GetName()} weaves your attack by the luck of the gods";
                    Application.DoEvents();
                    mainForm.NextButtonClicked(mainForm.NextButton);
                    while (mainForm.NextButton.Enabled == true)
                    {
                        Application.DoEvents();
                    }
                }
                else
                {
                    if (enemey.GetArmor() >= player.GetDamage())
                    {
                        dmg = 1;
                        enemey.SetHealth(enemey.GetHealth() - dmg);
                    }
                    else
                    {
                        dmg = dmg - (enemey.GetArmor());
                        enemey.SetHealth(enemey.GetHealth() - dmg);
                    }
                    mainForm.GetNarratorTextBox().Text = $"{enemey.GetName()} Gets clobberd over the head for {dmg}";
                    Application.DoEvents();
                    mainForm.NextButtonClicked(mainForm.NextButton);
                    while (mainForm.NextButton.Enabled == true)
                    {
                        Application.DoEvents();
                    }
                    if (DeathChecker(ref player, ref enemey, mainForm))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static bool NormalStrikePhaseMainEnemeyTurn(ref Enemey enemey, ref Player player, Random randNumGen, bool isPlayer, Form1 mainForm)
        {
            mainForm.GetNarratorTextBox().Text = $"{enemey.GetName()} aims there next attack at {player.GetName()}";
            mainForm.NextButtonClicked(mainForm.NextButton);
            while (mainForm.NextButton.Enabled == true)
            {
                Application.DoEvents();
            }
            int randomNum = 0;
            mainForm.GetNarratorTextBox().Text = "1 = HunkerDown 1.5x armor  2 = Dodge";
            Application.DoEvents();
            System.Threading.Thread.Sleep(1500);
            Button tempChoiceHunker = new();
            Button tempChoiceDodge = new();
            mainForm.ButtonCreator(ref tempChoiceHunker, "tempChoiceHunker", tempChoiceHunker.Width, mainForm.GetNarratorTextBox().Location.Y - 100, 100, 100, "1", mainForm.DisableButton);
            mainForm.ButtonCreator(ref tempChoiceDodge, "tempChoiceDodge", tempChoiceHunker.Width + 500, mainForm.GetNarratorTextBox().Location.Y - 100, 100, 100, "2", mainForm.DisableButton);
            while (tempChoiceHunker.Enabled && tempChoiceDodge.Enabled)
            {
                Application.DoEvents();
            }
            if (tempChoiceHunker.Enabled)
            {
                randomNum = 2;
            }
            else
            {
                randomNum = 1;
            }
            mainForm.Controls.Remove(tempChoiceHunker);
            mainForm.Controls.Remove(tempChoiceDodge);
            tempChoiceHunker.Dispose();
            tempChoiceDodge.Dispose();

            mainForm.GetNarratorTextBox().Text = $"{enemey.GetName()} Strike at {player.GetName()} For: {enemey.GetDamage()}";
            Application.DoEvents();
            mainForm.NextButtonClicked(mainForm.NextButton);
            while (mainForm.NextButton.Enabled == true)
            {
                Application.DoEvents();
            }
            if (randomNum == 1)
            { //if the player decides to hunker down
                mainForm.GetNarratorTextBox().Text = $"{player.GetName()} Decides to hunker down increasing is armor by half for a total of {player.GetArmor() + player.GetArmor() / 2}";
                Application.DoEvents();
                mainForm.NextButtonClicked(mainForm.NextButton);
                while (mainForm.NextButton.Enabled == true)
                {
                    Application.DoEvents();
                }
                mainForm.GetNarratorTextBox().Text = $"{enemey.GetName()} Damage is currently {enemey.GetDamage()}";
                Application.DoEvents();
                mainForm.NextButtonClicked(mainForm.NextButton);
                while (mainForm.NextButton.Enabled == true)
                {
                    Application.DoEvents();
                }
                int dmg = enemey.GetDamage();
                dmg = dmg - (player.GetArmor() + (player.GetArmor() / 2));
                if ((player.GetArmor() + (player.GetArmor() / 2)) >= enemey.GetDamage())
                {
                    dmg = 1;
                    player.SetHealth(player.GetHealth() - dmg);
                } else
                {
                    player.SetHealth(player.GetHealth() - dmg);
                }
                    mainForm.GetNarratorTextBox().Text = $"{player.GetName()} Damage is reduced to {dmg}";
                Application.DoEvents();
                mainForm.NextButtonClicked(mainForm.NextButton);
                while (mainForm.NextButton.Enabled == true)
                {
                    Application.DoEvents();
                }
                if(DeathChecker(ref player, ref enemey, mainForm)) {return true;}

            }
            else
            { //if the player decides to dodge
                int dmg = enemey.GetDamage();
                mainForm.GetNarratorTextBox().Text = $"{player.GetName()} Decides not to become a shish kebob and attempts to dodge";
                Application.DoEvents();
                mainForm.NextButtonClicked(mainForm.NextButton);
                while (mainForm.NextButton.Enabled == true)
                {
                    Application.DoEvents();
                }
                for (int i = 0; i < 3; i++)
                {
                    randomNum = randNumGen.Next(player.GetSpeed() / 2);
                    mainForm.GetNarratorTextBox().Text = ".";
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(200);
                    mainForm.GetNarratorTextBox().Text = "..";
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(200);
                    mainForm.GetNarratorTextBox().Text = "...";
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(200);
                    mainForm.GetNarratorTextBox().Text = $"{player.GetName()} is sweating";
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(400);
                }
                mainForm.GetNarratorTextBox().Text = $"{player.GetName()} Rolled: {randomNum}";
                Application.DoEvents();
                System.Threading.Thread.Sleep(800);
                if (randomNum <= 0)
                {
                    mainForm.GetNarratorTextBox().Text = $"giving two pity points because {player.GetName()} managed to roll a zero :[]";
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(1000);
                    randomNum = 2;
                }
                mainForm.GetNarratorTextBox().Text = $"Initating Roll phase Highest number decides winner";
                Application.DoEvents();
                mainForm.NextButtonClicked(mainForm.NextButton);
                while (mainForm.NextButton.Enabled == true)
                {
                    Application.DoEvents();
                }
                if (DodgeChance(randomNum, enemey.GetSpeed(), randNumGen, mainForm))
                {
                    mainForm.GetNarratorTextBox().Text = $"{player.GetName()} weaves the attack by the luck of the gods";
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(1000);
                }
                else
                {
                    if (player.GetArmor() >= dmg)
                    {
                        dmg = 1;
                        player.SetHealth(player.GetHealth() - dmg);
                    } else
                    {
                        dmg = enemey.GetDamage() - player.GetArmor();
                        player.SetHealth(player.GetHealth() - dmg);
                    }
                    mainForm.GetNarratorTextBox().Text = $"{player.GetName()} Gets clobberd over the head for {dmg}";
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(1000);
                    if(DeathChecker(ref player, ref enemey, mainForm))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool NormalStrikePhase(ref Player player, ref Enemey enemey, Random randNumGen, Form1 mainForm, int MaxHP)
        {
            DrinkPotionQuestion(mainForm, player, MaxHP);
            if (player.GetSpeed() > enemey.GetSpeed()) {
                if (NormalStrikePhaseMainPlayerTurn(ref player, ref enemey, randNumGen, false, mainForm))
                {
                    return true;
                }
                if(NormalStrikePhaseMainEnemeyTurn(ref enemey, ref player, randNumGen, true, mainForm)) {
                    return true;
                }
            } else if (enemey.GetSpeed() > player.GetSpeed()) {
                if (NormalStrikePhaseMainEnemeyTurn(ref enemey, ref player, randNumGen, true, mainForm))
                {
                    return true;
                }
                if (NormalStrikePhaseMainPlayerTurn(ref player, ref enemey, randNumGen, false, mainForm))
                {
                    return true;
                }
            } else { //same speed
                mainForm.GetNarratorTextBox().Text = "Since you are just as fast as eachother you coin flip to see who attacks first";
                Application.DoEvents();
                mainForm.NextButtonClicked(mainForm.NextButton);
                while (mainForm.NextButton.Enabled == true)
                {
                    Application.DoEvents();
                }
                if (randNumGen.Next(1) == 1) {
                    mainForm.GetNarratorTextBox().Text = $"good job {player.GetName()} won the coin flip";
                    Application.DoEvents();
                    mainForm.NextButtonClicked(mainForm.NextButton);
                    while (mainForm.NextButton.Enabled == true)
                    {
                        Application.DoEvents();
                    }
                    if (NormalStrikePhaseMainPlayerTurn(ref player, ref enemey, randNumGen, false, mainForm))
                    {
                        return true;
                    }
                    if (NormalStrikePhaseMainEnemeyTurn(ref enemey, ref player, randNumGen, true, mainForm))
                    {
                        return true;
                    }
                } else {
                    mainForm.GetNarratorTextBox().Text = $"{enemey.GetName()} won the coin flip";
                    Application.DoEvents();
                    mainForm.NextButtonClicked(mainForm.NextButton);
                    while (mainForm.NextButton.Enabled == true)
                    {
                        Application.DoEvents();
                    }
                    if (NormalStrikePhaseMainEnemeyTurn(ref enemey, ref player, randNumGen, true, mainForm))
                    {
                        return true;
                    }
                    if (NormalStrikePhaseMainPlayerTurn(ref player, ref enemey, randNumGen, false, mainForm))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        //if you dont know what call by reference is look it up
        public static void LaunchFight(ref Player player, ref Enemey enemey, Random randNumGen, Form1 mainForm)
        {
            int maxHP = player.GetHealth();
            mainForm.PlayerStatsLabelUpdater();
            mainForm.EnemeyStatsLabelUpdater(ref enemey);
            mainForm.GetNarratorTextBox().Text = $"You Encounterd {enemey.GetName()}";
            Application.DoEvents();
            mainForm.NextButtonClicked(mainForm.NextButton);
            while (mainForm.NextButton.Enabled == true)
            {
                Application.DoEvents();
            }
            //First strike attack phase
            InitalStrikePhase(ref player, ref enemey, randNumGen, mainForm);
            while (true && enemey.GetHealth() > 0)
            {
                if (NormalStrikePhase(ref player, ref enemey, randNumGen, mainForm, maxHP))
                {
                    break;
                }
            }
            //this loop only breaks once enemey or player is dead
            //player would have looted if he won
            if (player.GetHealth() <= 0)
            {
                mainForm.gameOver = true;
                return; //for now return might do some more stuff later
            }
            //return incase we want the option to do stuff here later
            return;
        }
        public static void DrinkPotionQuestion(Form1 mainForm, Player mainPlayer, int MaxHealth)
        {
            if (mainPlayer.GetHealth() >= MaxHealth)
            {
                return;
            }
            mainForm.GetNarratorTextBox().Text = "you can choose to drink a potion";
            mainForm.NextButtonClicked(mainForm.NextButton);
            while (mainForm.NextButton.Enabled == true)
            {
                Application.DoEvents();
            }
            Button DrinkPotion = new();
            Button DontDrinkPotion = new();
            mainForm.ButtonCreator(ref DrinkPotion, "DrinkPotion", DrinkPotion.Width, mainForm.GetNarratorTextBox().Location.Y - 100, 100, 100, "Drink Potion", mainForm.DisableButton);
            mainForm.ButtonCreator(ref DontDrinkPotion, "DontDrinkPotion", DontDrinkPotion.Width + 500, mainForm.GetNarratorTextBox().Location.Y - 100, 100, 100, "Dont Drink Potion", mainForm.DisableButton);
            while (DrinkPotion.Enabled && DontDrinkPotion.Enabled)
            {
                Application.DoEvents();
            }
            if (DrinkPotion.Enabled)//meaning drink potion not selected
            {
                //currently should just be ignored can fix later
            }
            else
            {
                mainPlayer.DrinkPotion(MaxHealth, mainForm);
            }
            mainForm.Controls.Remove(DrinkPotion);
            mainForm.Controls.Remove(DontDrinkPotion);
            DrinkPotion.Dispose();
            DontDrinkPotion.Dispose();
        }
    }
}
