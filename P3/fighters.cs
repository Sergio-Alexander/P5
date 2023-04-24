using System;
using System.Collections.Generic;

public abstract class Fighter
{
    protected int Row;
    protected int Column;
    protected int ArmamentStrength;
    protected int AttackRange;
    protected int[] Artillery;
    protected int MinimumStrength;
    protected bool IsActive;

    public Fighter(int[] artillery)
    {
        Artillery = artillery;
    }

    public abstract void Move(int x, int y);
    public virtual void Shift(int p) { }
    public bool Target(int x, int y, int q) { /* Implement target logic */ }
    public int Sum(int z) { /* Implement sum logic */ }
}


public class Turret : Fighter
{
    public int FailedRequests { get; private set; }
    public int MaxFailedRequests { get; private set; }

    public Turret(int[] artillery, int maxFailedRequests) : base(artillery)
    {
        MaxFailedRequests = maxFailedRequests;
    }

    public override void Move(int x, int y)
    {
        FailedRequests++;
        // Check if turret should die permanently
    }

    public override void Shift(int p)
    {
        // Implement shift logic for turret
    }

    public void Revive()
    {
        // Implement revive logic for turret
    }++++
}

public class Infantry : Fighter
{
    public enum Direction { North, South, East, West }
    public Direction CurrentDirection { get; private set; }

    public Infantry(int[] artillery) : base(artillery) { }

    public override void Move(int x, int y)
    {
        // Implement move logic for infantry
    }

    public override void Shift(int p)
    {
        // Implement shift logic for infantry
    }

    public void Reset()
    {
        // Implement reset logic for infantry
    }
}
