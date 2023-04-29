using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FighterClass.Tests
{
    [TestClass()]
    public class InfantryTests
    {
        private ICombat_Unit artillery;
        private Infantry infantry;

        [TestInitialize]
        public void TestInitialize()
        {
            artillery = new Combat_HQ();
            infantry = new Infantry(artillery, 5, 3, 2, 2);
        }

        [TestMethod()]
        public void Infantry_ShiftTest()
        {
            // Test shifting attack range
            infantry.Shift(4);
            Assert.AreEqual(4, infantry.Get_Attack_Range());
        }

        [TestMethod()]
        public void Infantry_MoveTest()
        {
            // Test moving while active
            infantry.Move(2, 3);
            Assert.AreEqual(2, infantry.Get_Row());
            Assert.AreEqual(3, infantry.Get_Column());
            Assert.IsTrue(infantry.Is_Active());

        }

        [TestMethod()]
        public void Infantry_TargetTest()
        {
            // Test targeting a unit with greater strength
            Infantry infantry2 = new Infantry(artillery, 6, 3, 3, 3);
            bool result = infantry.Target(infantry2.Get_Row(), infantry2.Get_Column(), 7);
            Assert.IsFalse(result);

            // Test targeting a unit within range
            Infantry infantry3 = new Infantry(artillery, 4, 2, 1, 1);
            result = infantry.Target(infantry3.Get_Row(), infantry3.Get_Column(), 3);
            Assert.IsTrue(result);

            // Test targeting a unit outside range
            Infantry infantry4 = new Infantry(artillery, 4, 2, 1, 4);
            result = infantry.Target(infantry4.Get_Row(), infantry4.Get_Column(), 3);
            Assert.IsTrue(result);
        }
    }
}
