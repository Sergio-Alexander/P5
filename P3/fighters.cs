using System;
using System.Collections.Generic;
using System.Linq;



/*
 -------------------- Class Invariants -----------------

Row, Column, Attack Range, Armament Strength , Total Targets Vanquished
must all be non-negative integers

Minimum Strength must always be 1

unit_combat must always be a valid instance of an object implementing the ICombat_Unit interface
 
 */

namespace FighterClass
{
    public interface ICombat_Unit
    {
        int[] Combat_Unit();
    }

    public class Combat_HQ : ICombat_Unit
    {
        public int[] Combat_Unit()
        {
            return Enumerable.Range(1, 50).ToArray();
        }
    }
    public abstract class Fighter
    {
        protected int row;
        protected int column;
        protected int armament_strength;
        protected int attack_range;

        protected int[] unit;
        protected ICombat_Unit unit_combat;

        protected int minimum_strength = 1;
        protected bool is_active;
        protected bool is_dead;


        private int total_targets_vanquished;


        /*

        Pre-conditions:

        Constructor Fighter(ICombat_Unit fighter_artillery, int fighter_armament_strength, int fighter_attack_range, int fighter_row, int fighter_col)

        fighter_artillery is not null
        fighter_armament_strength is a non-negative integer
        fighter_attack_range is a non-negative integer
        fighter_row is a non-negative integer
        fighter_col is a non-negative integer


        Post-conditions:
        unit_combat is set to the value of fighter_artillery
        unit is set to the result of fighter_artillery.Combat_Unit()
        armament_strength is set to the value of fighter_armament_strength
        attack_range is set to the value of fighter_attack_range
        row is set to the value of fighter_row
        column is set to the value of fighter_col
        is_active is set to true if armament_strength >= minimum_strength, otherwise it is set to false
        is_dead is set to false
        
         */

        public Fighter(ICombat_Unit fighter_artillery, int fighter_armament_strength, int fighter_attack_range, int fighter_row, int fighter_col)
        {
            unit_combat = fighter_artillery;
            unit = unit_combat.Combat_Unit();

            armament_strength = fighter_armament_strength;
            attack_range = fighter_attack_range;
            row = fighter_row;
            column = fighter_col;
            is_active = armament_strength >= minimum_strength;
            is_dead = false;
        }


        /*
        Method Move(int x, int y)
        Pre-conditions:
        x is a non-negative integer
        y is a non-negative integer

        Post-conditions:
        row is set to the value of x
        column is set to the value of y
         */
        public abstract void Move(int x, int y);



        /*
        Method Shift(int p)
        Pre-conditions:

        p is a non-negative integer

        Post-conditions:
        None
         
        */
        public virtual void Shift(int p){}




        /*
        Method Target(int x, int y, int q)
        Pre-conditions:

        x is a non-negative integer
        y is a non-negative integer
        q is a non-negative integer
        Post-conditions:

        If is_active is false or is_dead is true, the function returns false
        If the distance between the fighter and the target is greater than attack_range, the function returns false
        If armament_strength is greater than q, total_targets_vanquished is incremented by 1, and the function returns true
        If armament_strength is less than or equal to q, armament_strength is decremented by 1
        If armament_strength is less than minimum_strength - 1, is_dead is set to true
        If armament_strength is less than or equal to minimum_strength, is_active is set to false
        The function returns false
         
        */


        public virtual bool Target(int x, int y, int q)
        {
            if (!is_active || is_dead)
            {
                return false;
            }

            // Calculate the distance between the fighter and the target
            int distance = Math.Abs(row - x) + Math.Abs(column - y);

            // Check if the target is within the attack range
            if (distance <= attack_range)
            {
                // Check if the fighter's artillery is greater than the target's strength
                if (armament_strength > q)
                {
                    total_targets_vanquished++;
                    return true;
                }

                if (armament_strength < q)
                {
                    armament_strength--;
                }
            }

            Check_Is_Dead();
            Check_Is_Active();



            return false;
        }


        public int Sum()
        {
            return total_targets_vanquished;
        }

        private void Check_Is_Dead()
        {
            if (armament_strength < minimum_strength - 1)
            {
                is_dead = true;
            }
        }

        private void Check_Is_Active()
        {
            if (armament_strength <= minimum_strength)
            {
                is_active = false;
            }
        }
        //------------------------------- For Unit Testing Purposes ------------
        public int Get_Row()
        {
            return row;
        }

        public int Get_Column()
        {
            return column;
        }

        public int Get_Attack_Range()
        {
            return attack_range;
        }

        public bool Is_Active()
        {
            return is_active;
        }

        public bool Is_Dead()
        {
            return is_dead;
        }

        public int Get_Armament_Strength()
        {
            return armament_strength;
        }
    }
}

/*
---------------------- Implementation Invariants ----------------

is_dead can only be true when armament_strength < minimum_strength - 1

is_active will be false when armament_strength <= minimum_strength

 */
