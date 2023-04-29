using System;
using FighterClass;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FighterClass.Tests
{
    [TestClass]
    public class FighterTests
    {
        private static readonly ICombat_Unit defaultArtillery = new Combat_HQ();

        [TestMethod]
        public void TestNewFighterNotNull()
        {
            // Arrange
            var fighter = new Infantry(defaultArtillery, 3, 2, 0, 0);

            // Act & Assert
            Assert.IsNotNull(fighter);
        }

        [TestMethod]
        public void TestTargetInRange()
        {
            // Arrange
            var fighter1 = new Infantry(defaultArtillery, 3, 2, 0, 0);
            var fighter2 = new Infantry(defaultArtillery, 1, 1, 0, 2);

            // Act
            var result = fighter1.Target(fighter2.Get_Row(), fighter2.Get_Column(), fighter2.Get_Armament_Strength());

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestTargetOutOfRange()
        {
            // Arrange
            var fighter1 = new Infantry(defaultArtillery, 3, 1, 0, 0);
            var fighter2 = new Infantry(defaultArtillery, 1, 1, 0, 2);

            // Act
            var result = fighter1.Target(fighter2.Get_Row(), fighter2.Get_Column(), fighter2.Get_Armament_Strength());

            // Assert
            Assert.IsFalse(result);
        }
    }

}

