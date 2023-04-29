using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 -------------------- Class Invariants -----------------

The Turret instance's failed_requests property must be non-negative.
The Turret instance's failed_requests property must be less than or equal to max_failed_requests.
If the Turret instance's is_dead property is true, its is_active property must be false.
If the Turret instance's is_permanently_dead property is true, its is_dead property must be true and its is_active property must be false.
 */


namespace FighterClass
{
    public class Turret : Fighter
    {
        private int failed_requests;
        private readonly int max_failed_requests = 5;
        private bool is_permanently_dead;
        private readonly int original_armament_strength;

        public Turret(ICombat_Unit fighter_artillery, int armament_strength, int attack_range, int fighter_row, int fighter_col) : base(fighter_artillery, armament_strength, attack_range, fighter_row, fighter_col)
        {
            failed_requests = 0;
            is_permanently_dead = false;
            original_armament_strength = armament_strength;
        }




        /*
         public override void Move(int x, int y)

        Pre-conditions:
        None

        Post-conditions:
        If the Turret instance is active, sets its is_active property to false and increments its failed_requests property by 1.
        If the Turret instance is not active, does nothing.
        If the Turret instance has failed requests equal to or greater than max_failed_requests - 1, sets its is_dead property to true.
        If the Turret instance has failed requests equal to or greater than max_failed_requests, sets its is_permanently_dead property to true.

         */
        public override void Move(int x, int y)
        {
            is_active = false;
            failed_requests++;

            Dead_Checker();

            Perma_Dead_Checker();
        }


        /*
         public override void Shift(int p)

        Pre-conditions:
        None

        Post-conditions:
        If p is less than 0 or greater than the Turret instance's attack_range property, increments the instance's failed_requests property by 1.
        If the Turret instance has failed requests equal to or greater than max_failed_requests - 1, sets its is_dead property to true.
        If the Turret instance has failed requests equal to or greater than max_failed_requests, sets its is_permanently_dead property to true.
        If the Turret instance is not active and is_dead is true and is_permanently_dead is false, sets its is_active property to true and its is_dead property to false.
        If p is greater than or equal to 0, sets the Turret instance's attack_range property to the value of p.

         */

        public override void Shift(int p)
        {

            if (p < 0 || p > attack_range)
            {
                failed_requests++;
            }

            Dead_Checker();

            Perma_Dead_Checker();

            if ((!is_active && is_dead) && !is_permanently_dead)
            {
                Revive();
            }
            else if (p >= 0)
            {
                attack_range = p;
            }
        }


        /*
         public override bool Target(int x, int y, int q)

        Pre-conditions:
        None

        Post-conditions:
        If the target is not at distance p (attack_range) from the Turret instance, returns false.
        Otherwise, performs the base class's Target method on the target's row, column, and strength values, and returns its result.

         */

        public override bool Target(int x, int y, int q)
        {
            int distance = Math.Abs(row - x);

            // Check if the target is at distance p (attack_range)
            if (distance != attack_range)
            {
                return false;
            }

            return base.Target(x, y, q);
        }


        /*
         private void Revive()

        Pre-conditions:
        None

        Post-conditions:
        If the Turret instance is not active and is_dead is true and is_permanently_dead is false, sets its is_active property to true, its is_dead property to false, its failed_requests property to 0, and its armament_strength property to its original value.

         */

        private void Revive()
        {
            is_active = true;
            is_dead = false;
            failed_requests = 0;
            armament_strength = original_armament_strength;
        }



        /*
         private void Dead_Checker()

        Pre-conditions:
        None

        Post-conditions:
        If the Turret instance has failed requests equal to or greater than max_failed_requests - 1, sets its is_active property to false and its is_dead property to true.

         */

        private void Dead_Checker()
        {
            if (failed_requests >= max_failed_requests - 1)
            {
                is_active = false;
                is_dead = true;
            }
        }


        /*
         private void Perma_Dead_Checker()

        Pre-conditions:
        None

        Post-conditions:
        If the Turret instance has failed requests equal to or greater than max_failed_requests, sets its is_permanently_dead property to true.

         */

        private void Perma_Dead_Checker()
        {
            if (failed_requests >= max_failed_requests)
            {
                is_permanently_dead = true;
            }
        }
    }
}


/*
---------------------- Implementation Invariants ----------------

The Turret instance's attack_range property must be non-negative.
The Turret instance's armament_strength property must be non-negative.
The Turret instance's row and column properties must be non-negative.
The Turret instance's original_armament_strength property must be equal to its armament_strength property at the time of its instantiation.

 */