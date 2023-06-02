using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterClass.Tests
{
    [TestClass]
    public class infantrySkipGuardTest
    {

        [TestMethod]
        public void TestCreationOfInfantrySkipGuard()
        {
            int[] arti = { 1, 2, 3 };
            int armamentStrength = 10;
            int attackRange = 10;
            int fighterRow = 5;
            int fighterCol = 5;
            int[] guard_array = { 1, 2, 3 };
            int k = 1;

            var infantrySkipGuard = new InfantrySkipGuard(arti, armamentStrength, attackRange, fighterRow, fighterCol, guard_array, k);

            bool result = infantrySkipGuard.AliveStatus();

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

            var infantrySkipGuard = new InfantrySkipGuard(arti, armamentStrength, attackRange, fighterRow, fighterCol, guard_array, k);

            infantrySkipGuard.Block(0);

            bool result = infantrySkipGuard.AliveStatus();

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

            var infantrySkipGuard = new InfantrySkipGuard(arti, armamentStrength, attackRange, fighterRow, fighterCol, guard_array, k);
            infantrySkipGuard.Block(1);

            bool result = infantrySkipGuard.AliveStatus();

            Assert.IsTrue(result);

        }

    }
}
