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
            if (this.GetHealth() <= 0)
            {
                new Exception("Enemey health is 0 and therefor constructor failed");
            }
        }

        static public Enemey GenerateEnemey(int TowerLevel)//loot will need to be determined however for now not implementing
        {
            //temporary will pass random generator
            Random randNumGen = new();
            string ResPath = @"..\..\..\ResourcePath\";
            int TowerMultiplier = TowerLevel * 5;
            //generate a enemey with some random stats based on this
            Enemey tempEnemey = new Enemey(randNumGen.Next(1, TowerMultiplier), randNumGen.Next(1, TowerMultiplier), 
                randNumGen.Next(1, TowerMultiplier), randNumGen.Next(1, TowerMultiplier), randNumGen.Next(1, TowerMultiplier));

            //make weapon
            int weaponNum = randNumGen.Next(3);
            Weapons weapon = new();
            switch (weaponNum) {
                case 1: //beatin stick
                    weapon.weaponpng = ResPath + "beatingstick_Weapon.png";
                    weapon.damage = 1 * TowerLevel;
                    break;
                case 2: //knife
                    weapon.weaponpng = ResPath + "knife_Weapon.png";
                    weapon.damage = 2 * TowerLevel;
                    break;
                case 3: //sickle
                    weapon.weaponpng = ResPath + "Sickle_Weapon.png";
                    weapon.damage = 3 * TowerLevel;
                    break;
            }
            tempEnemey.SetWeapons(weapon);
            
            return tempEnemey;
        }
    }
}
