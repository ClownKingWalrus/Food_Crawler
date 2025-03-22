using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Crawler
{
    class Player
    {
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
        private List<int>? ingredientPouch = new List<int>(); //someone should make a ingredient class

        //players customization
        private string? name = "Player";
        PlayersColor currentColor = PlayersColor.Red; //we can treat this as a upgrade or a customization option

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

        public void SetNewLootBag()
        {
            this.ingredientPouch = new List<int>();
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

        public List<int>? GetLootBag()
        {
            if (this.ingredientPouch != null)
            {
                return this.ingredientPouch;
            }
            return null;
        }

        public string GetName()
        {
            if (this.name != null)
            {
                return this.name;
            }
            return "?Null?";
        }

        public void PrintAllIngredients()
        {
            if (ingredientPouch == null || ingredientPouch.Count <= 0)
            {
                System.Console.WriteLine("No Ingredients");
                return;
            }

            for (int i = 0; i < ingredientPouch.Count; i++)
            {
                System.Console.WriteLine(ingredientPouch[i]);
            }
        }

        public void PushLootIntoBag(ref Player player, ref Player enemey)
        {
            if (enemey.GetLootBag() != null && player.GetLootBag() != null)
            {
                for (int i = 0; i < enemey.GetLootBag().Count; i++)
                {
                    player.GetLootBag().Add(enemey.GetLootBag()[i]);
                }
            }
        }
    }
}
