using System;
namespace FighterClass
{
	public class QuirkyGuard : Guard
	{
        private int counter;
		public QuirkyGuard(int[] quirkyArray):base(quirkyArray)
        {
            counter = 0;
        }

        public override void Block(int x)
        {

            int ignoredNumber = ArbitrarilySelectedShield(x);


            // Check if offset_x is within the bounds of the array
            if (ignoredNumber < 0 || ignoredNumber >= shieldArray.Length)
            {
                throw new ArgumentException("Invalid, OUT OF BOUNDS.");
            }

            base.Block(ignoredNumber);
        }

		private int ArbitrarilySelectedShield(int x)
		{
            return (counter++ + x) % shieldArray.Length;
        }
    }
}

