using System;
using System.Collections.Generic;
using System.Data.Common;
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
    //public interface ICombat_Unit
    //{
    //    int[] Combat_Unit();
    //}

    //public class Combat_HQ : ICombat_Unit
    //{
    //    private int[] main_artillery;

    //    public Combat_HQ(int[] artillery)
    //    {
    //        main_artillery = artillery;
    //    }

    //    public int[] Combat_Unit()
    //    {
    //        return main_artillery;
    //    }
    //}



    public abstract class Fighter
    {
        protected int row;
        protected int column;
        protected int armamentStrength;
        protected int attackRange;

        protected int[] artillery;


        //protected ICombat_Unit unit_combat;

        protected int minimumStrength;
        protected bool isActive;
        protected bool isDead;


        private int totalTargetsVanquished;


        /*

        Pre-conditions:

        Constructor Fighter(ICombat_Unit fighter_artillery, int fighterArmamentStrength, int fighterAttackRange, int fighterRow, int fighterCol)

        fighter_artillery is not null
        fighterArmamentStrength is a non-negative integer
        fighterAttackRange is a non-negative integer
        fighterRow is a non-negative integer
        fighterCol is a non-negative integer


        Post-conditions:
        unit_combat is set to the value of fighter_artillery
        unit is set to the result of fighter_artillery.Combat_Unit()
        armamentStrength is set to the value of fighterArmamentStrength
        attackRange is set to the value of fighterAttackRange
        row is set to the value of fighterRow
        column is set to the value of fighterCol
        isActive is set to true if armamentStrength >= minimumStrength, otherwise it is set to false
        isDead is set to false
        
         */

        // Constructor with error checking
        public Fighter(int[] arti, int fighterArmamentStrength, int fighterAttackRange, int fighterRow, int fighterCol)
        {
            if (fighterArmamentStrength < 0 || fighterAttackRange < 0 || fighterRow < 0 || fighterCol < 0)
                throw new ArgumentException("Invalid argument provided to constructor.");

            //unit_combat = fighter_artillery ?? throw new ArgumentNullException(nameof(fighter_artillery));
            //unit = unit_combat.Combat_Unit();

            artillery = arti;

            armamentStrength = fighterArmamentStrength;
            attackRange = fighterAttackRange;
            row = fighterRow;
            column = fighterCol;
            isActive = armamentStrength >= minimumStrength;
            isDead = false;
            minimumStrength = artillery[artillery.Length - 1];
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
        // Move method with default implementation
        public virtual void Move(int x, int y)
        {
            // By default do nothing, can be overridden in derived classes

            if (x < 0 || y < 0)
            {
                throw new ArgumentException("Values must not be negative!");
            }
            row = x;
            column = y;
        }



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

        If isActive is false or isDead is true, the function returns false
        If the distance between the fighter and the target is greater than attackRange, the function returns false
        If armamentStrength is greater than q, totalTargetsVanquished is incremented by 1, and the function returns true
        If armamentStrength is less than or equal to q, armamentStrength is decremented by 1
        If armamentStrength is less than minimumStrength - 1, isDead is set to true
        If armamentStrength is less than or equal to minimumStrength, isActive is set to false
        The function returns false
         
        */

        public virtual bool Target(int x, int y, int q)
        {
            if (!isActive || isDead)
            {
                return false;
            }

            // Calculate the distance between the fighter and the target
            int distance = Math.Abs(row - x) + Math.Abs(column - y);

            // Check if the target is within the attack range
            if (distance <= attackRange)
            {
                // Check if the fighter's artillery is greater than the target's strength
                if (armamentStrength > q)
                {
                    totalTargetsVanquished++;
                    return true;
                }

                if (armamentStrength < q)
                {
                    armamentStrength--;
                }
            }

            CheckIsDead();
            CheckIsActive();

            return false;
        }


        public int Sum()
        {
            return totalTargetsVanquished;
        }

        private void CheckIsDead()
        {
            if (armamentStrength < minimumStrength - 1)
            {
                isDead = true;
            }
        }

        private void CheckIsActive()
        {
            if (armamentStrength <= minimumStrength)
            {
                isActive = false;
            }
        }
        //------------------------------- For Unit Testing Purposes -------------//

        /*
        public int Get_Row()
        {
            return row;
        }

        public int Get_Column()
        {
            return column;
        }

        public int Get_attackRange()
        {
            return attackRange;
        }

        public bool Is_Active()
        {
            return isActive;
        }

        public bool Is_Dead()
        {
            return isDead;
        }

        public int Get_armamentStrength()
        {
            return armamentStrength;
        }
        */
        
    }
}

/*
---------------------- Implementation Invariants ----------------

isDead can only be true when armamentStrength < minimumStrength - 1

isActive will be false when armamentStrength <= minimumStrength

 */
