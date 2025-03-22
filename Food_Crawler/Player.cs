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
        private int health;
        private int armor;
        private int weight;
        private int speed; //all good fighting games have some rng to them
        private List<int>? ingredientPouch = new List<int>(); //someone should make a ingredient class

        //players customization
        private string? name = "Player";
        PlayersColor currentColor = PlayersColor.Red; //we can treat this as a upgrade or a customization option

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

    }
}
