using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3UnitTesting
{
    [TestClass]
    public class FighterTests
    {
        [TestMethod]
        public void TestTarget_Success()
        {
            int[] artillery = new int[] { 10, 20, 30 };
            int minimum_strength = 10;
            int armament_strength = 50;
            int attack_range = 5;
            TestFighter fighter = new TestFighter(artillery, minimum_strength, armament_strength, attack_range);

            bool result = fighter.target(2, 2, 20);
            Assert.IsTrue(result);
            Assert.AreEqual(30, fighter.GetArmamentStrength());
        }

        private class TestFighter : Fighter
        {
            public TestFighter(int[] artillery, int minimum_strength, int armament_strength, int attack_range) : base(artillery, minimum_strength, armament_strength, attack_range)
            {
            }

            public override void move(int x, int y)
            {
                throw new NotImplementedException();
            }
        }
    }

    [TestClass]
    public class TurretTests
    {
        [TestMethod]
        public void TestMove_FailedRequestsIncrease()
        {
            int[] artillery = new int[] { 10, 20, 30 };
            int maxFailedRequests = 3;
            int minimum_strength = 10;
            int armament_strength = 50;
            int attack_range = 5;
            Turret turret = new Turret(artillery, maxFailedRequests, minimum_strength, armament_strength, attack_range);

            turret.move(2, 2);
            Assert.AreEqual(1, turret.GetFailedRequests());
        }

        [TestMethod]
        public void TestRevive_TurretIsActive()
        {
            int[] artillery = new int[] { 10, 20, 30 };
            int maxFailedRequests = 3;
            int minimum_strength = 10;
            int armament_strength = 50;
            int attack_range = 5;
            Turret turret = new Turret(artillery, maxFailedRequests, minimum_strength, armament_strength, attack_range);
            turret.move(2, 2);
            turret.move(3, 3);
            turret.move(4, 4); // This should make the turret inactive
            turret.revive();

            Assert.IsTrue(turret.GetIsActive());
        }
    }

    [TestClass]
    public class InfantryTests
    {
        [TestMethod]
        public void TestMove_ChangePosition()
        {
            int[] artillery = new int[] { 10, 20, 30 };
            int minimum_strength = 10;
            int armament_strength = 50;
            int attack_range = 5;

            Infantry infantry = new Infantry(artillery, minimum_strength, armament_strength, attack_range);
            infantry.SetCurrentDirection(Infantry.Direction.North);
            infantry.move(0, 1); // Change this to a valid movement (North).

            Assert.AreEqual(0, infantry.GetRow());
            Assert.AreEqual(1, infantry.GetColumn());
        }

        [TestMethod]
        public void TestReset_InfantryIsActive()
        {
            int[] artillery = new int[] { 10, 20, 30 };
            int minimum_strength = 10;
            int armament_strength = 50;
            int attack_range = 5;
            Infantry infantry = new Infantry(artillery, minimum_strength, armament_strength, attack_range);
            infantry.SetActive(false);
            infantry.reset();
            Assert.IsTrue(infantry.IsActive());
        }

        [TestMethod]
        public void TestGetCurrentDirection()
        {
            Infantry infantry = new Infantry(new int[] { 1, 2, 3 }, 10, 20, 30);
            infantry.move(0, 0); // Move infantry to position (0,0)

            // The initial direction should be North, as set in the constructor.
            Assert.AreEqual(Infantry.Direction.North, infantry.GetCurrentDirection());

            infantry.move(0, 1);
            Assert.AreEqual(Infantry.Direction.East, infantry.GetCurrentDirection());

            infantry.move(1, 1);
            Assert.AreEqual(Infantry.Direction.South, infantry.GetCurrentDirection());

            infantry.move(1, 0);
            Assert.AreEqual(Infantry.Direction.West, infantry.GetCurrentDirection());
        }



    }
}


           