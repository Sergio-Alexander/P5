using System;
using System.Collections.Generic;

/*
Name: Sergio Satyabrata
Date: April 28, 2023
Class: CPSC-3200
Revision History: Revised
Platform: MacBook Pro (OSX)


This driver program creates a number of Infantry and Turret fighters with random
properties, adds them to a list, and runs a simulation of a fight between them.
The program generates a random number of fighters between 30-50, creates an equal number of
Infantry and Turret fighters, and stores them in a list. The program then runs a
loop simulating four rounds of fighting. During each round, the program moves
each fighter to a random location and then targets a random fighter at a random
location. After all fighters have moved and targeted, the program outputs whether
each fighter vanquished its target or not and how many targets each fighter vanquished.



Assumptions:

1) There is a Combat_HQ class that implements the ICombat_Unit interface.
2) There are two types of fighters: Infantry and Turret, and each fighter type has unique properties such as armament strength, attack range, row, and column.
3) There will be at least 30 and at most 50 fighters generated with random properties.
4) There will be enough fighters to fight, meaning at least two fighters.
5) Each fighter can move to a random location within a 10x10 grid.
6) Each fighter can target another fighter at a random location within a 10x10 grid and deal damage based on their attack strength.
7) That each fighter can be vanquished or destroyed by taking enough damage.
8) That the fight loop will run four times.
9) That each fighter can be indexed and displayed in the console output.
10) The Sum() method exists for each fighter to calculate the number of vanquished targets.
11) All inputs are valid and legal.


Output:

The output of the driver program would vary each time it is run due to the random
generation of fighter properties and movement and targeting actions. The program
would generate a fight simulation between a number of Infantry and Turret
fighters, with each fighter moving to a random location and attempting to vanquish
a random target within their attack range. The program would also output the number
of targets each fighter has vanquished after each round of the simulation.
The simulation runs for 4 rounds.

Usability:

The driver program is not intended for direct user interaction.
It is a test program that demonstrates the functionality of the Fighter,
Infantry, and Turret classes. Its purpose is to create a list of Fighter objects,
simulate several rounds of combat between them, and output the results to the console.
Its usability is primarily for testing and development purposes.

*/

namespace FighterClass
{
    class Program
    {
        static void Main(string[] args)
        {
            // Seed the random number generator
            Random rand = new Random();

            // Generate a random number of fighters between 30-50
            int numFighters = rand.Next(30, 51);

            // Create a list to hold fighters
            List<Fighter> fighters = new List<Fighter>();

            // Create some Infantry fighters with random properties
            for (int i = 0; i < numFighters / 2; i++)
            {
                int armament_strength = rand.Next(10, 21);
                int attack_range = rand.Next(10, 51);
                int row = rand.Next(1, 11);
                int column = rand.Next(1, 11);
                ICombat_Unit artillery = new Combat_HQ();
                Infantry fighter = new Infantry(artillery, armament_strength, attack_range, row, column);
                fighters.Add(fighter);
            }

            // Create some Turret fighters with random properties
            for (int i = 0; i < numFighters / 2; i++)
            {
                int armament_strength = rand.Next(10, 31);
                int attack_range = rand.Next(10, 101);
                int row = rand.Next(1, 11);
                int column = rand.Next(1, 11);
                ICombat_Unit artillery = new Combat_HQ();
                Turret fighter = new Turret(artillery, armament_strength, attack_range, row, column);
                fighters.Add(fighter);
            }

            // Check if there are enough fighters to fight
            if (fighters.Count > 1)
            {
                // Run the fight loop 4 times
                for (int i = 0; i < 4; i++)
                {
                    Console.WriteLine($"------------------------ROUND {i + 1} ---------------------");

                    // Move some fighters
                    for (int j = 0; j < fighters.Count; j++)
                    {
                        fighters[j].Move(rand.Next(1, 11), rand.Next(1, 11));
                    }

                    // Target fighters
                    for (int j = 0; j < fighters.Count; j++)
                    {
                        bool vanquished = fighters[j].Target(rand.Next(1, 11), rand.Next(1, 11), rand.Next(1, 21));
                        Console.WriteLine($"Fighter {j} {(vanquished ? "vanquished" : "did not vanquish")} the target");
                    }


                    // Total Vanquished
                    foreach (Fighter fighter in fighters)
                    {
                        int j = fighters.IndexOf(fighter);
                        Console.WriteLine($"Fighter {j} vanquished {fighter.Sum()} targets");
                    }
                }
            }
        }
    }
}
