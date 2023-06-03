using Microsoft.VisualStudio.TestTools.UnitTesting;
using FighterClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterClass.Tests
{
    [TestClass]
    public class quirkyGuardTests
    {
        [TestMethod]
        public void TestCreationOfAGuard()
        {
            int[] arti = { 1, 2, 3 };
            int armamentStrength = 10;
            int attackRange = 10;
            int fighterRow = 5;
            int fighterCol = 5;
            int[] guard_array = { 1, 2, 3 };
           

            var guardSkipInfantry = new InfantryQuirkyGuard(arti, armamentStrength, attackRange, fighterRow, fighterCol, guard_array);
            var guardSkipTurret = new TurretQuirkyGuard(arti, armamentStrength, attackRange, fighterRow, fighterCol, guard_array);
            var guards = new QuirkyGuard(guard_array);

            bool result1 = guardSkipInfantry.AliveStatus();
            bool result2 = guardSkipTurret.AliveStatus();
            bool result3 = guards.AliveStatus();

            Assert.IsTrue(result1);
            Assert.IsTrue(result2);
            Assert.IsTrue(result3);

        }


        [TestMethod]
        public void TestBlockMethod()
        {
            int[] arti = { 1, 2, 3 };
            int armamentStrength = 10;
            int attackRange = 10;
            int fighterRow = 5;
            int fighterCol = 5;
            int[] guard_array1 = { 1, 2, 3 };
            int[] guard_array2 = { 1, 2, 3 };
            int[] guard_array3 = { 1, 2, 3 };

            var guard1 = new TurretQuirkyGuard(arti, armamentStrength, attackRange, fighterRow, fighterCol, guard_array1);
            var guard2 = new InfantryQuirkyGuard(arti, armamentStrength, attackRange, fighterRow, fighterCol, guard_array2);

            var guard3 = new QuirkyGuard(guard_array3);

            guard1.Block(0);
            Assert.AreEqual(0, guard_array1[0]); 

            guard2.Block(1);
            Assert.AreEqual(3, guard_array2[2]);

            guard3.Block(2);
            Assert.AreEqual(2, guard_array3[1]);
        }

        [TestMethod]
        public void TestBlockWithNegativeNumber()
        {
            int[] arti = { 1, 2, 3 };
            int armamentStrength = 10;
            int attackRange = 10;
            int fighterRow = 5;
            int fighterCol = 5;
            int[] guard_array = { 1, 2, 3 };

            var guard = new TurretQuirkyGuard(arti, armamentStrength, attackRange, fighterRow, fighterCol, guard_array);

            Assert.ThrowsException<ArgumentException>(() => guard.Block(-10));
        }


        [TestMethod]
        public void TestAliveStatusWhenGuardIsAlive()
        {
            int[] arti = { 1, 2, 3 };
            int armamentStrength = 10;
            int attackRange = 10;
            int fighterRow = 5;
            int fighterCol = 5;
            int[] guard_array = { 1, 2, 3 };

            var guard = new TurretQuirkyGuard(arti, armamentStrength, attackRange, fighterRow, fighterCol, guard_array);

            bool result = guard.AliveStatus();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestAliveStatusWhenGuardIsNotAlive()
        {
            int[] arti = { 1, 2, 3 };
            int armamentStrength = 10;
            int attackRange = 10;
            int fighterRow = 5;
            int fighterCol = 5;
            int[] guard_array = { 0, 0, 0 };

            var guard = new TurretQuirkyGuard(arti, armamentStrength, attackRange, fighterRow, fighterCol, guard_array);

            bool result = guard.AliveStatus();

            Assert.IsFalse(result);
        }
    }
}