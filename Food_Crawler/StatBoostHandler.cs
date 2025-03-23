// Full StatBoostHandler.cs (human-style, natural student-written tone)
using System;

namespace Food_Crawler
{
    public static class StatBoostHandler
    {
        // basic food types used for stat boosts
        public enum FoodType
        {
            Meat,
            Veggie,
            Dairy,
            Grain,
            Unknown
        }

        // simple structure to return boost values
        public struct Boost
        {
            public int atk;
            public int def;
            public int mag;
            public int spd;

            public Boost(int a, int d, int m, int s)
            {
                atk = a;
                def = d;
                mag = m;
                spd = s;
            }

            public void PrintBoost()
            {
                Console.WriteLine($"Gained -> ATK: +{atk}, DEF: +{def}, MAG: +{mag}, SPD: +{spd}");
            }
        }

        // maps food type to specific stat boosts
        public static Boost GetBoost(FoodType food)
        {
            Console.WriteLine($"You ate a {food} enemy.");

            switch (food)
            {
                case FoodType.Meat:
                    return new Boost(5, 1, 0, 0); // Strong but not very magical
                case FoodType.Veggie:
                    return new Boost(1, 4, 0, 2); // Healthy defense and a bit of speed
                case FoodType.Dairy:
                    return new Boost(0, 1, 5, 0); // Magical cheese energy
                case FoodType.Grain:
                    return new Boost(1, 1, 1, 3); // Speedy carbs
                default:
                    return new Boost(1, 1, 1, 1); // Default fallback
            }
        }
    }
}
