using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Crawler
{
    public class Player
    {
        public struct Weapons//temp will make its own class at some point
        {
            //might make the full weapon math var in future
            public string weaponpng;
            public int damage;
        }
        private enum PlayersColor
        {
            Red,
            Green,
            Blue,
            Black,
            Yellow
        }

        //fighting attributes
        //possibly add a bag for limited loot size
        private int health;
        private int armor;
        private int weight;
        private int speed; //all good fighting games have some rng to them
        private int damage;
        private int looseStatPoints;
        private Weapons weapon;
        
        private int money;
        private List<int>? ingredientPouch; //someone should make a ingredient class
        private List<string>? potionPack;

        //players customization
        private string? name = "Player";
        PlayersColor currentColor = PlayersColor.Red; //we can treat this as a upgrade or a customization option

        //constuctor

        public Player(int H, int A, int W, int S, int D, int M)
        {
            this.health = H;
            this.armor = A;
            this.weight = W;
            this.speed = S;
            this.damage = D;
            this.money = M;
        }

        public Player(int H, int A, int W, int S, int D)
        {
            this.health = H;
            this.armor = A;
            this.weight = W;
            this.speed = S;
            this.damage = D;
        }

        public Player(int H, int A, int S, int D)
        {
            this.health = H;
            this.armor = A;
            this.speed = S;
            this.damage = D;
        }

        public Player(int H, int A, int S, int D, List<int> l)
        {
            this.health = H;
            this.armor = A;
            this.speed = S;
            this.damage = D;
            ingredientPouch = new List<int>(l);
        }

        public Player()
        {
            this.health = 1;
            this.speed = 1;
            this.damage = 2;
            this.money = 20;
            this.looseStatPoints = 20;
            potionPack = new List<string>();
        }


        //setter functions 
        public void SetHealth(int Health)
        {
            this.health = Health;
        }

        public void SetArmor(int Armor)
        {
            this.armor = Armor;
        }

        public void SetWeight(int Weight)
        {
            this.weight = Weight;
        }

        public void SetSpeed(int Speed)
        {
            this.speed = Speed;
        }

        public void SetDamage(int Damage)
        {
            this.damage = Damage;
        }

        public void SetMoney(int Money)
        {
            this.money = Money;
        }

        public void SetNewLootBag()
        {
            this.ingredientPouch = new List<int>();
        }

        public void SetName(string Name)
        {
            this.name = Name;
        }

        public void SetLooseStatPoints(int statPoints)
        {
            this.looseStatPoints = statPoints;
        }

        public void SetWeapons(Weapons weapn)
        {
            this.weapon = weapn;
        }

        //getter functions
        public int GetHealth()
        {
            return this.health;
        }

        public int GetArmor()
        {
            return this.armor;
        }

        public int GetWeight()
        {
            return this.weight;
        }

        public int GetSpeed()
        {
            return this.speed;
        }

        public int GetDamage()
        {
            return this.damage;
        }

        public int GetMoney()
        {
            return this.money;
        }

        public int GetLooseStatPoints()
        {
            return this.looseStatPoints;
        }

        public List<int>? GetLootBag()
        {
            if (this.ingredientPouch != null)
            {
                return this.ingredientPouch;
            }
            return null;
        }

        public List<string>? GetPotionPack()
        {
            if (this.potionPack != null)
            {
                return this.potionPack;
            }
            return null;
        }

        public int GetPotionCount()
        {
            return this.potionPack.Count;
        }

        public string GetName()
        {
            if (this.name != null)
            {
                return this.name;
            }
            return "?Null?";
        }

        public Weapons GetWeapon()
        {
            return this.weapon;
        }

        public void DrinkPotion(int playersMaxHp, Form1 mainForm)
        {
            if (this.potionPack.Count <= 0)
            {
                mainForm.GetNarratorTextBox().Text = $"u aint got potions";
                mainForm.NextButtonClicked(mainForm.NextButton);
                while (mainForm.NextButton.Enabled == true)
                {
                    Application.DoEvents();
                }
                return;
            }
            int hpPotion = 100;
            if (this.GetHealth() >= playersMaxHp)
            {
                mainForm.GetNarratorTextBox().Text = "Your HP is already maxed";
                mainForm.NextButtonClicked(mainForm.NextButton);
                while (mainForm.NextButton.Enabled == true)
                {
                    Application.DoEvents();
                }
                return;
            }
            while (this.GetHealth() + hpPotion > playersMaxHp)
            {
                hpPotion--;
            }
            mainForm.GetNarratorTextBox().Text = $"Healing for {hpPotion}";
            mainForm.NextButtonClicked(mainForm.NextButton);
            while (mainForm.NextButton.Enabled == true)
            {
                Application.DoEvents();
            }
            this.SetHealth(this.GetHealth() + hpPotion);
            potionPack.RemoveAt(potionPack.Count - 1);
            mainForm.PlayerStatsLabelUpdater();
            
        }
        public void PrintAllIngredients(Form1 mainForm)
        {
            if (ingredientPouch == null || ingredientPouch.Count <= 0)
            {
                mainForm.GetNarratorTextBox().Text = "No Ingredients";
                Application.DoEvents();
                return;
            }
            String tempConstruct = "Ingridents: ";
            for (int i = 0; i < ingredientPouch.Count; i++)
            {
                mainForm.GetNarratorTextBox().Text = tempConstruct + $"{ingredientPouch[i]} | ";
                Application.DoEvents();
                System.Threading.Thread.Sleep(500);
                tempConstruct = mainForm.GetNarratorTextBox().Text;
            }
        }


        public void PushLootIntoBag(ref Player player, ref Enemey enemey)
        {
            if (enemey.GetLootBag() != null && player.GetLootBag() != null)
            {
                for (int i = 0; i < enemey.GetLootBag().Count; i++)
                {
                    player.GetLootBag().Add(enemey.GetLootBag()[i]);
                }
            }
        }

        public void IncreaseHealthPotion() //Lucas
        {
            potionPack.Add("Health Potion");
        }

        public void PrintAllPotions() //Lucas
        {
            string finalString;
            if (potionPack == null || potionPack.Count <= 0)
            {
                //System.Console.WriteLine("No Ingredients");
                return;
            }

            //from stackoverflow and programiz
            finalString = string.Join(" | ", potionPack);
            MessageBox.Show(finalString);

        }
    }
}
