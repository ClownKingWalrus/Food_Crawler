using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Crawler
{//since this class will determin enemey generation it should inherit the players attribute just to make it easier for us
    class Enemey : Player
    {
        public Enemey(int health, int armor, int weight, int speed, int damage) : base(health, armor, weight, speed, damage)
        {

        }

        static public Enemey GenerateEnemey(int TowerLevel)
        {
            int TowerMultiplier = TowerLevel * 5;
            //temporary will pass random generator
            Random randNumGen = new();
            Enemey tempEnemey = new Enemey(randNumGen.Next(1, TowerMultiplier), randNumGen.Next(1, TowerMultiplier), 
                randNumGen.Next(1, TowerMultiplier), randNumGen.Next(1, TowerMultiplier), randNumGen.Next(1, TowerMultiplier)); 
            //generate a enemey with some random stats based on this
            //some sort of Floor level getter so if 5 levels per floor then1-5 might decide a base str and so on

            
            return tempEnemey;
        }
    }
}
