using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FighterClass.Tests
{
    [TestClass()]
    public class TurretTests
    {
        private ICombat_Unit artillery;
        private Turret turret;

        [TestInitialize]
        public void TestInitialize()
        {
            artillery = new Combat_HQ();
            turret = new Turret(artillery, 20, 10, 5, 5);
        }

        [TestMethod()]
        public void Turret_ShiftTest()
        {
            // Test shift within range
            turret.Shift(5);
            Assert.AreEqual(5, turret.Get_Attack_Range());

            // Test shift beyond max range
            turret.Shift(20);
            Assert.AreEqual(20, turret.Get_Attack_Range());

            // Test shift to negative range
            turret.Shift(-5);
            Assert.AreEqual(20, turret.Get_Attack_Range());
        }

        [TestMethod()]
        public void Turret_TargetTest()
        {
            // Test targeting a unit within range
            Infantry infantry = new Infantry(artillery, 10, 5, 5, 3);
            bool result = turret.Target(infantry.Get_Row(), infantry.Get_Column(), 5);
            Assert.IsFalse(result);

            // Test targeting a unit outside range
            Infantry infantry2 = new Infantry(artillery, 10, 15, 7, 5);
            result = turret.Target(infantry2.Get_Row(), infantry2.Get_Column(), 5);
            Assert.IsFalse(result);

            // Test targeting a unit at the same distance as range but different column
            Infantry infantry3 = new Infantry(artillery, 10, 5, 5, 9);
            result = turret.Target(infantry3.Get_Row(), infantry3.Get_Column(), 5);
            Assert.IsFalse(result);

            // Test targeting a unit with greater strength
            Infantry infantry4 = new Infantry(artillery, 10, 5, 5, 1);
            result = turret.Target(infantry4.Get_Row(), infantry4.Get_Column(), 15);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void Turret_MoveTest()
        {
            // Test moving while active
            turret.Move(7, 5);
            Assert.IsFalse(turret.Is_Active());

            // Test moving while inactive
            turret.Shift(15);
            turret.Move(7, 5);
            Assert.AreEqual(5, turret.Get_Row());
            Assert.AreEqual(5, turret.Get_Column());
            Assert.IsFalse(turret.Is_Active());

            // Test moving while dead
            turret.Move(7, 5);
            Assert.IsFalse(turret.Is_Active());
            Assert.IsTrue(turret.Is_Dead());

            // Test reviving
            turret.Shift(10);
            Assert.IsTrue(turret.Is_Active());
            Assert.IsFalse(turret.Is_Dead());
        }

    }
}


