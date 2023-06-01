using System;
using FighterClass;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace FighterClass.Tests
{
    [TestClass]
    public class GuardTests
    {
        private int[] arti = { 1, 2, 3 };
        private int armament_strength = 5;
        private int attack_range = 10;
        private int fighter_row = 1;
        private int fighter_col = 1;
        private int[] quirky_array = { 1, 2, 3 };

        [TestMethod]
        public void TestGuardBlock()
        {
            var guard = new turretQuirkyGuard(arti, armament_strength, attack_range, fighter_row, fighter_col, quirky_array);
            guard.block(1);
            // Add assertions to check the state of the guard after calling block
            // For example, if block method decreases the shield durability by 1, you can check it like this:
            Assert.AreEqual(0, guard.shield_array[1]);
        }



    }

}

