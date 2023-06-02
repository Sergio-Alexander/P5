using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterClass.Tests
{
    [TestClass]
    public class turretQuirkyGuardTest
    {

        [TestMethod]
        public void TestCreationOfTurretQuirkyGuard()
        {
            int[] arti = { 1, 2, 3 };
            int armamentStrength = 10;
            int attackRange = 10;
            int fighterRow = 5;
            int fighterCol = 5;
            int[] guard_array = { 1, 2, 3 };

            var turretQuirkyGuard = new TurretQuirkyGuard(arti, armamentStrength, attackRange, fighterRow, fighterCol, guard_array);

            bool result = turretQuirkyGuard.AliveStatus();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestBlockMethod()
        {
            int[] arti = { 1, 2, 3 };
            int armamentStrength = 10;
            int attackRange = 10;
            int fighterRow = 5;
            int fighterCol = 5;
            int[] guard_array = { 1, 2, 3 };

            var turretQuirkyGuard = new TurretQuirkyGuard(arti, armamentStrength, attackRange, fighterRow, fighterCol, guard_array);

            turretQuirkyGuard.Block(0);

            bool result = turretQuirkyGuard.AliveStatus();

            Assert.IsTrue(result);
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

            var turretQuirkyGuard = new TurretQuirkyGuard(arti, armamentStrength, attackRange, fighterRow, fighterCol, guard_array);

            Assert.ThrowsException<ArgumentException>(() => turretQuirkyGuard.Block(-1));
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

            var turretQuirkyGuard = new TurretQuirkyGuard(arti, armamentStrength, attackRange, fighterRow, fighterCol, guard_array);

            turretQuirkyGuard.Block(1);

            bool result = turretQuirkyGuard.AliveStatus();

            Assert.IsTrue(result);
        }
    }
}
