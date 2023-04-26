using System;
using System.Collections.Generic;
using System.Data.Common;

public abstract class Fighter
{
    protected int row;
    protected int column;
    protected int armament_strength;
    protected int attack_range;
    protected int[] artillery;
    protected int minimum_strength;
    protected bool is_active;


    private int total_targets_vanquished;
    public Fighter(int[] fighter_artillery, int fighter_minimum_strength, int fighter_armament_strength, int fighter_attack_range)
    {
        artillery = fighter_artillery;
        minimum_strength = fighter_minimum_strength;
        armament_strength = fighter_armament_strength;
        attack_range = fighter_attack_range;
        is_active = armament_strength >= minimum_strength;
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

    public abstract void move(int x, int y);
    public virtual void shift(int p) { }
    public bool target(int x, int y, int q)
    {
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
                return true;
            }
        }

        return false;
    }
    public int sum(int z)
    {
        if (total_targets_vanquished >= z)
        {
            return total_targets_vanquished;
        }
        else
        {
            return 0;
        }
    }
}


public class Turret : Fighter
{
    public int failed_requests;
    public int max_failed_requests;

    public Turret(int[] artillery, int maxFailedRequests, int minimum_strength, int armament_strength, int attack_range) : base(artillery, minimum_strength, armament_strength, attack_range)
    {
        max_failed_requests = maxFailedRequests;
        is_active = true;
    }

    public int GetFailedRequests() { return failed_requests; }
    public int GetMaxFailedRequests() { return max_failed_requests; }
    public void SetMaxFailedRequests(int value) { max_failed_requests = value; }

    public override void move(int x, int y)
    {
        failed_requests++;

        if (failed_requests >= max_failed_requests)
        {
            is_active = false;
        }
    }

    public override void shift(int p)
    {
        attack_range = p;
    }

    public void revive()
    {
        if (!is_active)
        {
            is_active = true;
            failed_requests = 0;
        }
    }
}

public class Infantry : Fighter
{
    public enum Direction { North, South, East, West }
    private Direction current_direction;
    private bool first_move;

    public Infantry(int[] artillery, int minimum_strength, int armament_strength, int attack_range) : base(artillery, minimum_strength, armament_strength, attack_range)
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


