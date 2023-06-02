using System;
namespace FighterClass
{
	public class SkipGuard : Guard
	{
        private readonly int unstableK;

        public SkipGuard(int[] skipArray, int k) : base(skipArray)
        {
            if (k < 0)
            {
                throw new ArgumentException("K is a negative number (INVALID)");
            }
            unstableK = k;
        }
        public override void Block(int x)
        {
            int offsetX = (x + unstableK) % shieldArray.Length; // This is done so that it would always be within the range of the array (no out of bounds)

            if (offsetX < 0 || offsetX > shieldArray.Length)
            {
                throw new ArgumentException("Cannot Block a negative number. X IS INVALID");
            }
          

            base.Block(offsetX);
        }
    }
}

