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
        private Direction current_direction;
        private bool first_move;


        public Infantry(ICombat_Unit fighter_artillery, int armament_strength, int attack_range, int fighter_row, int fighter_col) : base(fighter_artillery, armament_strength, attack_range, fighter_row, fighter_col)
        {
            is_active = true;
            current_direction = Direction.North;
            first_move = true;
        }


        /*
        public override void Shift(int p)
      
        Pre-conditions:
        None

        Post-conditions:
        Changes the attack_range property of the Infantry instance to the value of p.
        */
        public override void Shift(int p)
        {
            attack_range = p;
        }


        /*

        public override void Move(int x, int y)

        Pre-conditions:
        None

        Post-conditions:
        If the Infantry instance is active, updates its row and column properties to the values of x and y respectively.
        If the Infantry instance is not active, does nothing.
        If the Infantry instance has not moved before, sets the first_move property to false.
        If the Infantry instance has moved before, sets the current_direction property to the direction it moved in based on its current position and the new position (North if it moved up, South if it moved down, East if it moved right, West if it moved left).

         */

        public override void Move(int x, int y)
        {
            if (is_active)
            {
                Direction newDirection = get_direction(x, y);

                if (first_move)
                {
                    first_move = false;
                }
                else
                {
                    if (current_direction == Direction.North && newDirection == Direction.South ||
                        current_direction == Direction.South && newDirection == Direction.North ||
                        current_direction == Direction.East && newDirection == Direction.West ||
                        current_direction == Direction.West && newDirection == Direction.East)
                    {
                        return;
                    }
                }

                row = x;
                column = y;
                current_direction = newDirection;
            }
            else
            {
                Reset();
            }
        }



        /*

        private Direction get_direction(int x, int y)

        Pre-conditions:
        None

        Post-conditions:
        Returns a value of type Direction that represents the direction in which the Infantry instance would need to move to get from its current position to the position (x, y).

         */

        private Direction get_direction(int x, int y)
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
        If the Infantry instance is not active, sets its is_active property to true. Does nothing otherwise.
         */

        private void Reset()
        {
            is_active = true;
        }
    }
}


/*
---------------------- Implementation Invariants ----------------

is_dead can only be true when armament_strength < minimum_strength - 1

is_active will be false when armament_strength <= minimum_strength


Can only be Reset when infantryman is inactive. I designed it so that my infantrymen will never die.

 */