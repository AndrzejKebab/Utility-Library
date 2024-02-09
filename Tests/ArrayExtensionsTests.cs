using System;
using NUnit.Framework;
using UtilityLibrary.Unity.Runtime;

namespace UtilityLibrary.Core
{
    [TestFixture]
    public class ArrayExtensionsTests
    {
        [Test]
        public void FlattenIndex_ReturnsCorrectIndex_ForTwoDimensionalArray()
        {
            // Arrange
            var array = new int[3,3];
            var x = 2;
            var y = 2;

            // Act
            var result = array.FlattenIndex(x, y);

            // Assert
            Assert.AreEqual(array.Length - 1, result);
        }

        [Test]
        public void FlattenIndex_ReturnsCorrectIndex_ForThreeDimensionalArray()
        {
            // Arrange
            var array = new int[3,3,3];
            var x = 2;
            var y = 2;
            var z = 2;

            // Act
            var result = array.FlattenIndex(x, y, z);

            // Assert
            Assert.AreEqual(array.Length - 1, result);
        }
        
        [Test]
        public void FlattenFrom2D_ReturnsCorrectFlattenedArray()
        {
            // Arrange
            var input = new[,] { { 1, 2 }, { 3, 4 } };

            // Act
            var result = ArrayExtensions.FlattenFrom2D(input);

            // Assert
            Assert.AreEqual(new[] { 1, 2, 3, 4 }, result);
        }

        [Test]
        public void FlattenFrom2D_WithEmptyArray_ReturnsEmptyArray()
        {
            // Arrange
            var input = new int[0, 0];

            // Act
            var result = ArrayExtensions.FlattenFrom2D(input);

            // Assert
            Assert.AreEqual(Array.Empty<int>(), result);
        }

        [Test]
        public void UnflattenTo2D_ReturnsCorrect2DArray()
        {
            // Arrange
            var input = new int[] { 1, 2, 3, 4 };

            // Act
            var result = ArrayExtensions.UnflattenTo2D(input, 2, 2);

            // Assert
            Assert.AreEqual(
                new[,] { { 1, 2 }, { 3, 4 } }, result);
        }

        [Test]
        public void UnflattenTo2D_WithEmptyArray_ReturnsEmpty2DArray()
        {
            // Arrange
            var input = Array.Empty<int>();

            // Act
            var result = ArrayExtensions.UnflattenTo2D(input, 0, 0);

            // Assert
            Assert.AreEqual(new int[0, 0], result);
        }
    }
}