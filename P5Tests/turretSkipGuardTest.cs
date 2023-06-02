using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterClass.Tests
{
    [TestClass]
    public class turretSkipGuardTest
    {
        [TestMethod]
        public void TestCreationOfTurretSkipGuard()
        {
            int[] arti = { 1, 2, 3 };
            int armamentStrength = 10;
            int attackRange = 10;
            int fighterRow = 5;
            int fighterCol = 5;
            int[] guard_array = { 1, 2, 3 };
            int k = 1;

            var turretSkipGuard = new TurretSkipGuard(arti, armamentStrength, attackRange, fighterRow, fighterCol, guard_array, k);

            bool result = turretSkipGuard.AliveStatus();

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
            int k = 1;

            var turretSkipGuard = new TurretSkipGuard(arti, armamentStrength, attackRange, fighterRow, fighterCol, guard_array, k);

            turretSkipGuard.Block(0);

            bool result = turretSkipGuard.AliveStatus();

            Assert.IsTrue(result);
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
            int k = 1;

            var turretSkipGuard = new TurretSkipGuard(arti, armamentStrength, attackRange, fighterRow, fighterCol, guard_array, k);
            turretSkipGuard.Block(1);

            bool result = turretSkipGuard.AliveStatus();

            Assert.IsTrue(result);

        }
    }
}
