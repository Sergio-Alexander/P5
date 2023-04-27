using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fighter
{
    public class Infantry : Fighter
    {
        public enum Direction { North, South, East, West }
        private Direction current_direction;
        private bool first_move;

        public Infantry(ICombat_Unit fighter_artillery, int minimum_strength, int armament_strength, int attack_range) : base(fighter_artillery, minimum_strength, armament_strength, attack_range)
        {
            is_active = true;
            current_direction = Direction.North;
            first_move = true;
        }
        public override void shift(int p)
        {
            attack_range = p;
        }

        public bool IsActive()
        {
            return is_active;
        }

        public void SetActive(bool active)
        {
            is_active = active;
        }

        public Direction GetCurrentDirection() { return current_direction; }
        public void SetCurrentDirection(Direction value) { current_direction = value; }

        public override void move(int x, int y)
        {
            if (is_active)
            {
                Direction newDirection = GetDirection(x, y);

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
        }

        private Direction GetDirection(int x, int y)
        {
            if (x > row) return Direction.South;
            if (x < row) return Direction.North;
            if (y > column) return Direction.East;
            return Direction.West;
        }

        public void reset()
        {
            if (!is_active)
            {
                is_active = true;
            }
        }
    }
}
