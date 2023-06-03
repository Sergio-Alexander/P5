/*
Name: Sergio Satyabrata
Date: June 2, 2023 
Class: CPSC-3200
Revision History: Revised
Platform: MacBook Pro (OSX)
Assignment: P5

This program simulates a battle scenario between different types of guards, specifically Infantry and Turret guards.
The guards are represented as objects of classes that implement the IGuard interface. 
Each guard has properties such as armamentStrength, attackRange, and aliveStatus, and methods such as Move(), Target(), and Block() [IF THEY ARE A CROSS-PRODUCT]
A guard can also be SkipGuard or QuirkyGuard without the properties of a Fighter

The P5 driver must test the use of the ‘multiply-inherited’ types together.
Thus, it will differ from the unit tests which test each type separately.
Additionally:
1) Use at least one heterogeneous collection for testing functionality
2) Instantiate a variety of objects
3) Trigger a variety of mode changes


- I am testing all the miltiply inherited types together
- I am using a heterogeneous collection <LIST> to test the functionality
- I am instantiating a variety of objects {skipGuard, quirkyGuard, turretSkipGuard, turretQuirkyGuard, infantrySkipGuard, and infantryQuirkyGuard}
- Within the Guard class, the mode change will happen automatically.

Upgrades and fixes from P3:
Classes:
- Fixed classes so that each implementation invariant contains essential details
- Did not use random generator Random() in the class
- Error Checking implemented in the constructor

Fighter:
- Move implemented
- Made many functions private

Turret:
- Made max-failed-request unique to each object

Infantry:
- Reconfigured reset

P5 Driver:
- Functional decomposition has been added
- Made sure every public function has been tested

P5 Unit Test:
- Unit Tests have been decomposed into various units


ASSUMPTIONS:

The battle takes place in a 2D grid, with each guard occupying a specific position.

Each guard can move and target any position within its attack range.

A guard can block an attack if it is targeted.

The strength of an attack is a random number, and a guard's ability to block an attack depends on its armamentStrength.

A guard is considered dead if its armamentStrength falls below a certain level.

The battle continues until only one guard is left standing.
*/


using System;
using System.Collections.Generic;
using System.Text;

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
            for (int i = 0; i < 5; i++)
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
                int guardArrayLength = rand.Next(1, 10); // Generate a random length for the array
                int[] guardArray = new int[guardArrayLength]; // Initialize the array with the random length

                for (int j = 0; j < guardArrayLength; j++)
                {
                    guardArray[j] = rand.Next(1, 10); // Fill the array with random numbers
                }
                int k = rand.Next(1, 10);

                guards.Add(new SkipGuard(guardArray, k));
                guards.Add(new QuirkyGuard(guardArray));

                guards.Add(new TurretSkipGuard(arti, armamentStrength, attackRange, fighterRow, fighterCol, guardArray, k));
                guards.Add(new TurretQuirkyGuard(arti, armamentStrength, attackRange, fighterRow, fighterCol, guardArray));

                guards.Add(new InfantrySkipGuard(arti, armamentStrength, attackRange, fighterRow, fighterCol, guardArray, k));
                guards.Add(new InfantryQuirkyGuard(arti, armamentStrength, attackRange, fighterRow, fighterCol, guardArray));
            }
        }
        static void TestGuards(List<IGuard> guards)
        {
            // Store the initial number of guards
            int initialNumGuards = guards.Count;

            // If all guards are dead, return from the method
            if (guards.Count <= 1)
            {
                Console.WriteLine($"The last guard standing is Guard{1}.");
                return;
            }
            Random rand = new Random();

            for (int round = 0; round < 20; round++)
            {
               
                for (int i = 0; i < guards.Count; i++)
                {
                    // Randomly select a guard to block the attack
                    int blockingGuardIndex = rand.Next(guards.Count);

                    // Randomly select a guard to attack
                    int attackingGuardIndex = rand.Next(guards.Count);

                    // Ensure the blocking guard is not the same as the attacking guard
                    while (blockingGuardIndex == attackingGuardIndex)
                    {
                        attackingGuardIndex = rand.Next(guards.Count);
                    }

                    // If the attacking guard is not alive, skip the attack
                    if (!guards[attackingGuardIndex].AliveStatus() || !guards[blockingGuardIndex].AliveStatus())
                    {
                        continue;
                    }

                    // Determine the strength of the attack
                    int attackIndex = rand.Next(1, 10);

                    // Generate random coordinates for the Move() and Target() methods
                    int x = rand.Next(1, 5);
                    int y = rand.Next(1, 5);
                    int z = rand.Next(1, 5);

                    // Test the Move() and Target() methods if the guard is an Infantry
                    if (guards[i] is Infantry infantry)
                    {
                        infantry.Move(x, y);
                        infantry.Target(x, y, z);
                    }

                    // Test the Target() method if the guard is a Turret
                    if (guards[i] is Turret turret)
                    {
                        turret.Target(x, y, z);
                    }

                    // If the guard is being targeted, it blocks the attack
                    if (i == attackingGuardIndex)
                    {
                        Console.WriteLine($"Guard{blockingGuardIndex + 1} is blocking attack from Guard{attackingGuardIndex + 1}.");
                        guards[blockingGuardIndex].Block(attackIndex);
                    }
                }
                // Remove dead guards
                guards.RemoveAll(guard => !guard.AliveStatus());
            }

            int aliveGuards = guards.Count;
            int deadGuards = initialNumGuards - aliveGuards;
            Console.WriteLine($"After this round, there are {aliveGuards} guards alive and {deadGuards} guards dead.");
        }

    }
}
