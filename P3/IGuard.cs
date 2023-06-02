using System;


/*
 -------------------- Class Invariants -----------------

An IGuard object must always be in a valid state after construction and after any operation. This means that any properties or fields it has must be in a valid state according to the rules of the class that implements IGuard.
 
 */

namespace FighterClass
{
	public interface IGuard
	{
        /*
        Preconditions:

        For the Block(int x) method, x must be a valid integer. The specific range of valid values for x would depend on the implementation in the class that implements IGuard.

        Postconditions:

        After Block(int x) is called, the state of the IGuard object may change depending on the implementation of Block(int x). The specific postcondition would depend on the class that implements IGuard.
        AliveStatus() should return a boolean value indicating whether the IGuard object is alive or not. The specific condition for being considered "alive" would depend on the class that implements IGuard.
         */
        void Block(int x);
		bool AliveStatus();
    }
}


/*
---------------------- Implementation Invariants ----------------

As IGuard is an interface, it doesn't have any implementation details itself. The implementation invariant would be specific to the classes that implement IGuard.

 */

