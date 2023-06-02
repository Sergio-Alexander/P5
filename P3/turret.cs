using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 -------------------- Class Invariants -----------------

The Turret instance's failedRequests property must be non-negative.
The Turret instance's failedRequests property must be less than or equal to maxFailedRequests.
If the Turret instance's isDead property is true, its isActive property must be false.
If the Turret instance's isPermanentlyDead property is true, its isDead property must be true and its isActive property must be false.
 */


namespace FighterClass
{
    public class Turret : Fighter
    {
        private int failedRequests;
        private readonly int maxFailedRequests;
        private bool isPermanentlyDead;
        private readonly int originalArmamentStrength;

        public Turret(int[] arti, int armamentStrength, int attackRange, int fighterRow, int fighterCol) : base(arti, armamentStrength, attackRange, fighterRow, fighterCol)
        {
            failedRequests = 0;
            isPermanentlyDead = false;
            originalArmamentStrength = armamentStrength;
            maxFailedRequests = (armamentStrength % 2) + 3;

            artillery = arti;
        }


        /*
         public override void Move(int x, int y)

        Pre-conditions:
        None

        Post-conditions:
        If the Turret instance is active, sets its isActive property to false and increments its failedRequests property by 1.
        If the Turret instance is not active, does nothing.
        If the Turret instance has failed requests equal to or greater than maxFailedRequests - 1, sets its isDead property to true.
        If the Turret instance has failed requests equal to or greater than maxFailedRequests, sets its isPermanentlyDead property to true.

         */
        public override void Move(int x, int y)
        {
            isActive = false;
            failedRequests++;

            DeadChecker();

            PermaDeadChecker();
        }


        /*
         public override void Shift(int p)

        Pre-conditions:
        None

        Post-conditions:
        If p is less than 0 or greater than the Turret instance's attackRange property, increments the instance's failedRequests property by 1.
        If the Turret instance has failed requests equal to or greater than maxFailedRequests - 1, sets its isDead property to true.
        If the Turret instance has failed requests equal to or greater than maxFailedRequests, sets its isPermanentlyDead property to true.
        If the Turret instance is not active and isDead is true and isPermanentlyDead is false, sets its isActive property to true and its isDead property to false.
        If p is greater than or equal to 0, sets the Turret instance's attackRange property to the value of p.

         */

        public override void Shift(int p)
        {

            if (p < 0 || p > attackRange)
            {
                failedRequests++;
            }

            DeadChecker();

            PermaDeadChecker();

            if ((!isActive && isDead) && !isPermanentlyDead)
            {
                Revive();
            }
            else if (p >= 0)
            {
                attackRange = p;
            }
        }


        /*
         public override bool Target(int x, int y, int q)

        Pre-conditions:
        None

        Post-conditions:
        If the target is not at distance p (attackRange) from the Turret instance, returns false.
        Otherwise, performs the base class's Target method on the target's row, column, and strength values, and returns its result.

         */

        public override bool Target(int x, int y, int q)
        {
            int distance = Math.Abs(row - x);

            // Check if the target is at distance p (attackRange)
            if (distance != attackRange)
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
        If the Turret instance is not active and isDead is true and isPermanentlyDead is false, sets its isActive property to true, its isDead property to false, its failedRequests property to 0, and its armamentStrength property to its original value.

         */

        private void Revive()
        {
            isActive = true;
            isDead = false;
            failedRequests = 0;
            armamentStrength = originalArmamentStrength;
        }



        /*
         private void DeadChecker()

        Pre-conditions:
        None

        Post-conditions:
        If the Turret instance has failed requests equal to or greater than maxFailedRequests - 1, sets its isActive property to false and its isDead property to true.

         */

        private void DeadChecker()
        {
            if (failedRequests >= maxFailedRequests - 1)
            {
                isActive = false;
                isDead = true;
            }
        }


        /*
         private void PermaDeadChecker()

        Pre-conditions:
        None

        Post-conditions:
        If the Turret instance has failed requests equal to or greater than maxFailedRequests, sets its isPermanentlyDead property to true.

         */

        private void PermaDeadChecker()
        {
            if (failedRequests >= maxFailedRequests)
            {
                isPermanentlyDead = true;
            }
        }
    }
}


/*
---------------------- Implementation Invariants ----------------

The Turret instance's attackRange property must be non-negative.
The Turret instance's armamentStrength property must be non-negative.
The Turret instance's row and column properties must be non-negative.
The Turret instance's originalArmamentStrength property must be equal to its armamentStrength property at the time of its instantiation.

 */