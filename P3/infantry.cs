using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 -------------------- Class Invariants -----------------

Infantrymen can only move in the directions of North, South, East, West

Row, Column, Attack Range, Armament Strength, and Total Targets Vanquished must all be non-negative integers.
Minimum Strength must always be 1.
unit_combat must always be a valid instance of an object implementing the ICombat_Unit interface.
 
 */

namespace FighterClass
{
    public class Infantry : Fighter
    {
        public enum Direction {North, South, East, West}
        private Direction currentDirection;
        private bool firstMove;
        private readonly int originalArmamentStrength;

        public Infantry(int[] arti, int armamentStrength, int attackRange, int fighterRow, int fighterCol) : base(arti, armamentStrength, attackRange, fighterRow, fighterCol)
        {
            isActive = true;
            currentDirection = Direction.North;
            firstMove = true;
            isDead = false;
            originalArmamentStrength = armamentStrength;

            artillery = arti;
        }

        /*
        public override void Shift(int p)
      
        Pre-conditions:
        None

        Post-conditions:
        Changes the attackRange property of the Infantry instance to the value of p.
        */
        public override void Shift(int p)
        {
            attackRange = p;
        }


        /* many things need to be added.

        public override void Move(int x, int y)

        Pre-conditions:
        None

        Post-conditions:
        If the Infantry instance is active, updates its row and column properties to the values of x and y respectively.
        If the Infantry instance is not active, does nothing.
        If the Infantry instance has not moved before, sets the firstMove property to false.
        If the Infantry instance has moved before, sets the currentDirection property to the direction it moved in based on its current position and the new position (North if it moved up, South if it moved down, East if it moved right, West if it moved left).

         */

        public override void Move(int x, int y)
        {
            if (isActive)
            {
                Direction newDirection = GetDirection(x, y);

                if (firstMove)
                {
                    firstMove = false;
                }
                else
                {
                    if (currentDirection == Direction.North && newDirection == Direction.South ||
                        currentDirection == Direction.South && newDirection == Direction.North ||
                        currentDirection == Direction.East && newDirection == Direction.West ||
                        currentDirection == Direction.West && newDirection == Direction.East)
                    {
                        return;
                    }
                }

                row = x;
                column = y;
                currentDirection = newDirection;
            }
            else
            {
                if (!isActive && !isDead)
                {
                    Reset();
                }
                return;
            }
        }



        /*

        private Direction GetDirection(int x, int y)

        Pre-conditions:
        None

        Post-conditions:
        Returns a value of type Direction that represents the direction in which the Infantry instance would need to move to get from its current position to the position (x, y).

         */

        private Direction GetDirection(int x, int y)
        {
            if (x > row) return Direction.South;
            if (x < row) return Direction.North;
            if (y > column) return Direction.East;
            return Direction.West;
        }



        /*
         private void Reset()

        Pre-conditions:
        None

        Post-conditions:
        If the Infantry instance is not active, sets its isActive property to true. Does nothing otherwise.
         */

        private void Reset()
        {
            isActive = true;
            armamentStrength = originalArmamentStrength;
        }
    }
}


/*
---------------------- Implementation Invariants ----------------

isDead can only be true when armamentStrength < minimum_strength - 1

isActive will be false when armamentStrength <= minimum_strength


Can only be Reset when infantryman is inactive. I designed it so that my infantrymen will never die.

 */