using System;
using System.Collections.Generic;

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
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Round {i + 1}:");
                TestGuards(guards);
                Console.WriteLine();
            }
        }

        static void AddGuards(List<IGuard> guards)
        {
            Random rand = new Random();

            for (int i = 0; i < 5; i++)
            {
                int[] arti = { rand.Next(1, 10), rand.Next(1, 10), rand.Next(1, 10) };
                int armamentStrength = rand.Next(1, 10);
                int attackRange = rand.Next(1, 10);
                int fighterRow = rand.Next(1, 10);
                int fighterCol = rand.Next(1, 10);
                int[] guard_array = { rand.Next(1, 10), rand.Next(1, 10), rand.Next(1, 10) };
                int k = rand.Next(1, 10);

                guards.Add(new TurretSkipGuard(arti, armamentStrength, attackRange, fighterRow, fighterCol, guard_array, k));
                guards.Add(new TurretQuirkyGuard(arti, armamentStrength, attackRange, fighterRow, fighterCol, guard_array));

                guards.Add(new InfantrySkipGuard(arti, armamentStrength, attackRange, fighterRow, fighterCol, guard_array, k));
                guards.Add(new InfantryQuirkyGuard(arti, armamentStrength, attackRange, fighterRow, fighterCol, guard_array));
            }
        }

        static void TestGuards(List<IGuard> guards)
        {
            Random rand = new Random();

            int guardCounter = 1;
            foreach (IGuard guard in guards)
            {
                int x = rand.Next(1, 10);
                Console.WriteLine($"Guard{guardCounter} is blocking attack of strength {x}.");
                guard.Block(x);

                guardCounter++;
            }

            // Remove dead guards
            guards.RemoveAll(guard => !guard.AliveStatus());
        }
    }
}
