using System;

namespace FighterClass
{
    class P5
    {
        static void Main(string[] args)
        {
            // Create a list of IGuard objects
            List<IGuard> guards = new List<IGuard>();

            // Add instances of your classes to the list
            AddGuards(guards);

            // Loop through the list and call methods on each object
            TestGuards(guards);
        }

        static void AddGuards(List<IGuard> guards)
        {
            Random rand = new Random();

            for (int i = 0; i < 10; i++)
            {
                int[] arti = { rand.Next(1, 10), rand.Next(1, 10), rand.Next(1, 10) };
                int armament_strength = rand.Next(1, 10);
                int attack_range = rand.Next(1, 10);
                int fighter_row = rand.Next(1, 10);
                int fighter_col = rand.Next(1, 10);
                int[] quirky_array = { rand.Next(1, 10), rand.Next(1, 10), rand.Next(1, 10) };
                int k = rand.Next(1, 10);

                guards.Add(new turretSkipGuard(arti, armament_strength, attack_range, fighter_row, fighter_col, quirky_array, k));
                guards.Add(new turretQuirkyGuard(arti, armament_strength, attack_range, fighter_row, fighter_col, quirky_array));
                guards.Add(new turretSkipQuirkyGuard(arti, armament_strength, attack_range, fighter_row, fighter_col, quirky_array, k));
                guards.Add(new infantrySkipGuard(arti, armament_strength, attack_range, fighter_row, fighter_col, quirky_array, k));
                guards.Add(new infantryQuirkyGuard(arti, armament_strength, attack_range, fighter_row, fighter_col, quirky_array));
                guards.Add(new infantrySkipQuirkyGuard(arti, armament_strength, attack_range, fighter_row, fighter_col, quirky_array, k));
            }
        }

        static void TestGuards(List<IGuard> guards)
        {
            Random rand = new Random();

            foreach (IGuard guard in guards)
            {
                int x = rand.Next(1, 10);
                guard.block(x);
                // Add more method calls as needed to test your classes
            }
        }
    }
}

