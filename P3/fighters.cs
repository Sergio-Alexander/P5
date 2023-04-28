using System;
using System.Collections.Generic;
using System.Linq;
// testing
namespace Fighter
{
    public interface ICombat_Unit
    {
        List<int> Combat_Unit();
    }

    public class Combat_HQ : ICombat_Unit
    {
        public List<int> Combat_Unit()
        {
            return Enumerable.Range(1, 20).ToList();
        }
    }
    public abstract class Fighter
    {
        protected int row;
        protected int column;
        protected int armament_strength;
        protected int attack_range;

        protected List<int> unit;
        protected ICombat_Unit unit_combat;

        protected int minimum_strength;
        protected bool is_active;
        protected bool is_dead;


        private int total_targets_vanquished;


        public Fighter(ICombat_Unit fighter_artillery, int fighter_minimum_strength, int fighter_armament_strength, int fighter_attack_range)
        {
            unit_combat = fighter_artillery;
            minimum_strength = fighter_minimum_strength;
            armament_strength = fighter_armament_strength;
            attack_range = fighter_attack_range;
            is_active = armament_strength >= minimum_strength;
            is_dead = false;
            unit = new List<int>();
        }

        public abstract void move(int x, int y);
        public virtual void shift(int p) { }
        public bool target(int x, int y, int q)
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
                    armament_strength -= q; // Update armament strength after vanquishing the target
                    is_active = armament_strength >= minimum_strength; // Update the active state based on minimum_strength
                    total_targets_vanquished++;
                    check_is_dead();
                    return true;
                }
            }
            return false;
        }
        public int sum()
        {
            return total_targets_vanquished;
        }

        protected void check_is_dead()
        {
            if (armament_strength < 0) // Set the condition for a dead fighter (e.g., armament_strength is below 0)
            {
                is_dead = true;
            }
        }
        public int GetArmamentStrength()
        {
            return armament_strength;
        }

        public bool GetIsActive()
        {
            return is_active;
        }

        public int GetRow()
        {
            return row;
        }

        public int GetColumn()
        {
            return column;
        }
    }

}


