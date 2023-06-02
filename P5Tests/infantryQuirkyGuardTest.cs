using FighterClass;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace FighterClass.Tests
{
    [TestClass]
    public class infantryQuirkyGuardTest
    {
        [TestMethod]
        public void TestCreationOfInfantryQuirkyGuard()
        {
            int[] arti = { 1, 2, 3 };
            int armamentStrength = 10;
            int attackRange = 10;
            int fighterRow = 5;
            int fighterCol = 5;
            int[] guard_array = { 1, 2, 3 };

            var infantryQuirkyGuard = new InfantryQuirkyGuard(arti, armamentStrength, attackRange, fighterRow, fighterCol, guard_array);

            bool result = infantryQuirkyGuard.AliveStatus();

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

            var infantryQuirkyGuard = new InfantryQuirkyGuard(arti, armamentStrength, attackRange, fighterRow, fighterCol, guard_array);

            infantryQuirkyGuard.Block(0);

            bool result = infantryQuirkyGuard.AliveStatus();

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

            var infantryQuirkyGuard = new InfantryQuirkyGuard(arti, armamentStrength, attackRange, fighterRow, fighterCol, guard_array);

            Assert.ThrowsException<ArgumentException>(() => infantryQuirkyGuard.Block(-1));
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

            var infantryQuirkyGuard = new InfantryQuirkyGuard(arti, armamentStrength, attackRange, fighterRow, fighterCol, guard_array);

            infantryQuirkyGuard.Block(1);

            bool result = infantryQuirkyGuard.AliveStatus();

            Assert.IsTrue(result);
        }




    }
}
