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
    public class GuardTests
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
            int k = 1;

            var guardSkipInfantry = new InfantrySkipGuard(arti, armamentStrength, attackRange, fighterRow, fighterCol, guard_array, k);
            var guardQuirkyInfantry = new InfantryQuirkyGuard(arti, armamentStrength, attackRange, fighterRow, fighterCol, guard_array);

            var guardSkipTurret = new TurretSkipGuard(arti, armamentStrength, attackRange, fighterRow, fighterCol, guard_array, k);
            var guardQuirkyTurret = new InfantryQuirkyGuard(arti, armamentStrength, attackRange, fighterRow, fighterCol, guard_array);

            bool result1 = guardSkipInfantry.AliveStatus();
            bool result2 = guardQuirkyInfantry.AliveStatus();
            bool result3 = guardSkipTurret.AliveStatus();
            bool result4 = guardQuirkyTurret.AliveStatus();

            Assert.IsTrue(result1);
            Assert.IsTrue(result2);
            Assert.IsTrue(result3);
            Assert.IsTrue(result4);
        }

        [TestMethod]
        public void TestBlock()
        {
            int[] arti = { 1, 2, 3 };
            int armamentStrength = 10;
            int attackRange = 10;
            int fighterRow = 5;
            int fighterCol = 5;
            int[] guard_array = { 1, 2, 3 };

            var guardQuirkyInfantry = new InfantryQuirkyGuard(arti, armamentStrength, attackRange, fighterRow, fighterCol, guard_array);
            guardQuirkyInfantry.Block(1);

            bool result = guardQuirkyInfantry.AliveStatus();

            Assert.IsTrue(result);

        }

        [TestMethod]
        public void TestBlockWithInvalidParameter()
        {
            int[] arti = { 1, 2, 3 };
            int armamentStrength = 10;
            int attackRange = 10;
            int fighterRow = 5;
            int fighterCol = 5;
            int[] guard_array = { 1, 2, 3 };
            int k = 0;

            var guardQuirkyTurret = new TurretSkipGuard(arti, armamentStrength, attackRange, fighterRow, fighterCol, guard_array, k);

            Assert.ThrowsException<ArgumentException>(() => guardQuirkyTurret.Block(-5));
        }


        [TestMethod]
        public void TestGuardConstructorWithNegativeShieldStats()
        {
            int[] negativeShieldStats = { -1, 2, 3 };
            int armamentStrength = 10;
            int attackRange = 10;
            int fighterRow = 5;
            int fighterCol = 5;
            int[] arti = { 1, 2, 3 };
      

            Assert.ThrowsException<ArgumentException>(() => new InfantryQuirkyGuard(arti, armamentStrength, attackRange, fighterRow, fighterCol, negativeShieldStats));
        }

        [TestMethod]
        public void TestAliveStatus()
        {
            int[] arti = { 1, 2, 3 };
            int armamentStrength = 10;
            int attackRange = 10;
            int fighterRow = 5;
            int fighterCol = 5;
            int[] guard_array = { 1, 2, 3 };

            var guardQuirkyTurret = new TurretQuirkyGuard(arti, armamentStrength, attackRange, fighterRow, fighterCol, guard_array);

            for (int i = 0; i < 10; i++)
            {
                guardQuirkyTurret.Block(1);
            }

            bool result = guardQuirkyTurret.AliveStatus();

            Assert.IsFalse(result);
        }



    }
}