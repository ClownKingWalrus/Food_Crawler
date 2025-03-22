using System;


/// Think of this as the post-battle food coma power-up machine.
public static class StatBoostHandler
{
    /// Different food types = different stat gains.
    /// You are what you eat. Literally.
    public enum FoodType
    {
        Meat,    // Big strong attack bois
        Veggie,  // Tanky leafy greens
        Dairy,   // Magical cheesy buffs
        Grain,   // Speedy carb ninjas
        Mystery  // Could be anything... maybe cursed?
    }

    /// Struct to hold stat increases from eating enemies.
    public struct StatBoost
    {
        public int atk;
        public int def;
        public int mag;
        public int spd;

        public StatBoost(int attack = 0, int defense = 0, int magic = 0, int speed = 0)
        {
            atk = attack;
            def = defense;
            mag = magic;
            spd = speed;
        }

        public void Display()
        {
            Console.WriteLine($"Stat Boosts → ATK: +{atk}, DEF: +{def}, MAG: +{mag}, SPD: +{spd}");
        }
    }

    /// Main logic. Feed this function a food type and it’ll spit out stat gains.
    public static StatBoost GetStatBoostFromFood(FoodType food)
    {
        Console.WriteLine($"You devour the {food} enemy. Yum.");

        switch (food)
        {
            case FoodType.Meat:
                Console.WriteLine("Protein punch! Feeling stronger already.");
                return new StatBoost(attack: 5);
            case FoodType.Veggie:
                Console.WriteLine("Leafy greens fortify your body. Defense up!");
                return new StatBoost(defense: 5);
            case FoodType.Dairy:
                Console.WriteLine("Cheese magic courses through your veins.");
                return new StatBoost(magic: 5);
            case FoodType.Grain:
                Console.WriteLine("Carb-loading successful. Speed increased!");
                return new StatBoost(speed: 3);
            case FoodType.Mystery:
                Console.WriteLine("Uh... what was that? You feel... different.");
                return new StatBoost(attack: 2, defense: 2, magic: 2, speed: 2);
            default:
                Console.WriteLine("Nothing happened. Maybe don’t eat that next time.");
                return new StatBoost();
        }
    }
}