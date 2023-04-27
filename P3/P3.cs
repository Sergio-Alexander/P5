
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fighter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Fighter Simulation!");

            int[] artillery = new int[] { 10, 20, 30 };
            int minimum_strength = 10;
            int armament_strength = 50;
            int attack_range = 5;

            Turret turret = new Turret(artillery, 3, minimum_strength, armament_strength, attack_range);
            Infantry infantry = new Infantry(artillery, minimum_strength, armament_strength, attack_range);

            Console.WriteLine("Initial state:");
            PrintFighterStatus(turret, "Turret");
            PrintFighterStatus(infantry, "Infantry");

            // Example scenario: Turret tries to move and reaches the maximum number of failed requests.
            turret.move(3, 4);
            turret.move(2, 2);
            turret.move(1, 1);

            // Example scenario: Infantry moves to a new position.
            infantry.move(2, 3);

            Console.WriteLine("After movements:");
            PrintFighterStatus(turret, "Turret");
            PrintFighterStatus(infantry, "Infantry");

            // Example scenario: Turret and Infantry attack a target at position (4, 4) with strength 15.
            bool turretAttackSuccess = turret.target(4, 4, 15);
            bool infantryAttackSuccess = infantry.target(4, 4, 15);

            Console.WriteLine("After attacks:");
            PrintFighterStatus(turret, "Turret");
            PrintFighterStatus(infantry, "Infantry");

            Console.WriteLine("Attack results:");
            Console.WriteLine($"Turret attack successful: {turretAttackSuccess}");
            Console.WriteLine($"Infantry attack successful: {infantryAttackSuccess}");

            Console.WriteLine("End of simulation.");
        }

        static void PrintFighterStatus(Fighter fighter, string fighterName)
        {
            Console.WriteLine($"{fighterName}:");
            Console.WriteLine($"  Position: ({fighter.GetRow()}, {fighter.GetColumn()})");
            Console.WriteLine($"  Armament strength: {fighter.GetArmamentStrength()}");
            Console.WriteLine($"  Active: {fighter.GetIsActive()}");
            Console.WriteLine();
        }
    }
}
