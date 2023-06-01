using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FighterClass;

namespace FighterClass.Tests
{
    [TestClass]
    public class infantryQuirkyGuardTests
    {
        [TestMethod]
        public void Block_WithValidInput_ShouldDecreaseDurability()
        {
            // Arrange
            int[] arti = { 5, 5, 5 };
            int armament_strength = 5;
            int attack_range = 5;
            int fighter_row = 5;
            int fighter_col = 5;
            int[] quirky_array = { 5, 5, 5 };
            infantryQuirkyGuard guard = new infantryQuirkyGuard(arti, armament_strength, attack_range, fighter_row, fighter_col, quirky_array);

            // Act
            guard.block(2);

            // Assert
            // Add your assertions here. For example, you might check that the durability of the shield has decreased.
            // Assert.AreEqual(expectedDurability, guard.GetDurability());
        }

        [TestMethod]
        public void Update_Alive_Status_Should_Update_Is_Alive()
        {
            // Arrange
            int[] arti = { 5, 5, 5 };
            int armament_strength = 5;
            int attack_range = 5;
            int fighter_row = 5;
            int fighter_col = 5;
            int[] quirky_array = { 5, 5, 5 };
            infantryQuirkyGuard guard = new infantryQuirkyGuard(arti, armament_strength, attack_range, fighter_row, fighter_col, quirky_array);

            // Act
            guard.update_alive_status();

            // Assert
            // Add your assertions here. For example, you might check that the is_alive status has been updated.
            // Assert.AreEqual(expectedIsAlive, guard.GetIsAlive());
        }

        [TestMethod]
        public void RNG_Up_Down_Should_Update_Shield_Up_Down()
        {
            // Arrange
            int[] arti = { 5, 5, 5 };
            int armament_strength = 5;
            int attack_range = 5;
            int fighter_row = 5;
            int fighter_col = 5;
            int[] quirky_array = { 5, 5, 5 };
            infantryQuirkyGuard guard = new infantryQuirkyGuard(arti, armament_strength, attack_range, fighter_row, fighter_col, quirky_array);

            // Act
            guard.rng_up_down();

            // Assert
            // Add your assertions here. For example, you might check that the shield_up_down status has been updated.
            // Assert.AreEqual(expectedShieldUpDown, guard.GetShieldUpDown());
        }
    }
}
