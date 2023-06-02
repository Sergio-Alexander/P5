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
    public class skipGuardTests
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
            var guardSkipTurret = new TurretSkipGuard(arti, armamentStrength, attackRange, fighterRow, fighterCol, guard_array, k);
      
            bool result1 = guardSkipInfantry.AliveStatus();
            bool result2 = guardSkipTurret.AliveStatus();
        

            Assert.IsTrue(result1);
            Assert.IsTrue(result2);
       
        }
        [TestMethod]
        public void TestInvalidK()
        {
            int[] arti = { 1, 2, 3 };
            int armamentStrength = 10;
            int attackRange = 10;
            int fighterRow = 5;
            int fighterCol = 5;
            int[] guard_array = { 1, 2, 3 };
            int k = -3;

            Assert.ThrowsException<ArgumentException>(() => new InfantrySkipGuard(arti, armamentStrength, attackRange, fighterRow, fighterCol, guard_array, k));
            Assert.ThrowsException<ArgumentException>(() => new TurretSkipGuard(arti, armamentStrength, attackRange, fighterRow, fighterCol, guard_array, k));
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

            var guard1 = new TurretSkipGuard(arti, armamentStrength, attackRange, fighterRow, fighterCol, guard_array, k);
            var guard2 = new InfantrySkipGuard(arti, armamentStrength, attackRange, fighterRow, fighterCol, guard_array, k);

            guard1.Block(0);
            Assert.AreEqual(0, guard_array[1]); 

            guard2.Block(2);
            Assert.AreEqual(0, guard_array[0]); 
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

            var guard = new TurretSkipGuard(arti, armamentStrength, attackRange, fighterRow, fighterCol, guard_array, k);

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
            int k = 1;

            var guard = new TurretSkipGuard(arti, armamentStrength, attackRange, fighterRow, fighterCol, guard_array, k);

            bool result = guard.AliveStatus();

            Assert.IsFalse(result);
        }


    }
}