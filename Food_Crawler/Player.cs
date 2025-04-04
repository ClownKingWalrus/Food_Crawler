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
        private int looseStatPoints;
        private List<int>? ingredientPouch; //someone should make a ingredient class

        //players customization
        private string? name = "Player";
        PlayersColor currentColor = PlayersColor.Red; //we can treat this as a upgrade or a customization option
        
        //constuctor
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
            this.looseStatPoints = 20;
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
