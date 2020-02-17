using System;
using NUnit.Framework;

namespace OcsicoTraining.Mikhaltsev.Lesson6.Set.Tests
{
    [TestFixture]
    public class SetTests
    {
        [Test]
        public void Count_InputSetWithFiveElements_ReturnSetWithCountEqualsFive()
        {
            //arrange
            var inputSet = new Set<int> { 1, 2, 3, 4, 5 };
            var expected = 5;

            //act
            var actual = inputSet.Count;

            //assert
            Assert.AreEqual(expected, actual, "Should be Set with 5 elements");
        }

        [Test]
        public void Indexer_ThirdElementOfSetIsFour_ReturnTrue()
        {
            //arrange
            var inputSet = new Set<int> { 1, 2, 3, 4, 5 };
            var expected = 4;

            //act
            var actual = inputSet[3];

            //assert
            Assert.AreEqual(expected, actual, "Third element of Set is 4");
        }

        [Test]
        public void Add_AddItemWhichIsNotYetInSetWithFiveElements_ReturnSetWithSixElements()
        {
            //arrange
            var inputSet = new Set<int> { 1, 2, 3, 4, 5 };
            var expected = 6;

            //act
            inputSet.Add(8);
            var actual = inputSet.Count;

            //assert
            Assert.AreEqual(expected, actual, "Should be Set with 6 elements");
        }

        [Test]
        public void Add_AddItemWhichAlreadyExistInSet_ExceptionShould()
        {
            //arrange
            var inputSet = new Set<int> { 1, 2, 3, 4, 5 };

            //act
            void GetException() => inputSet.Add(3);

            //assert
            Assert.Throws<ArgumentException>(GetException, "Should be ArgumentException");
        }

        [Test]
        public void AddRange_AddThreeElementsInSetWithFiveElements_ReturnSetWithEightElements()
        {
            //arrange
            var inputSet = new Set<int> { 1, 2, 3, 4, 5 };
            var expected = 8;

            //act
            inputSet.AddRange(new[] { 6, 7, 8 });
            var actual = inputSet.Count;

            //assert
            Assert.AreEqual(expected, actual, "Should be 8 elements");
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(4)]
        public void Contains_SetIsContainsElement_ReturnTrue(int element)
        {
            //arrange
            var inputSet = new Set<int> { 1, 2, 3, 4, 5 };

            //act
            var actual = inputSet.Contains(element);

            //assert
            Assert.IsTrue(actual, $"Set is contains element {element}");
        }

        [Test]
        public void Clear_ClearSet_ReturnEmptySet()
        {
            //arrange
            var inputSet = new Set<int> { 1, 2, 3, 4, 5 };
            var expected = 0;

            //act
            inputSet.Clear();
            var actual = inputSet.Count;

            //assert
            Assert.AreEqual(expected, actual, "Should be empty Set");
        }

        [Test]
        public void Remove_RemoveExistElementFromSetWithFiveElements_ReturnSetWithFourElements()
        {
            //arrange
            var inputSet = new Set<int> { 1, 2, 3, 4, 5 };
            var expected = 4;

            //act
            inputSet.Remove(3);
            var actual = inputSet.Count;

            //assert
            Assert.AreEqual(expected, actual, "Should be 4 elements");
        }

        [Test]
        public void Remove_RemoveItemWhichIsNotExistInSetWithFiveElements_ReturnSetWithFiveElements()
        {
            //arrange
            var inputSet = new Set<int> { 1, 2, 3, 4, 5 };
            var expected = 5;

            //act
            inputSet.Remove(6);
            var actual = inputSet.Count;

            //assert
            Assert.AreEqual(expected, actual, "Should be 5 elements");
        }

        [Test]
        public void UnionWith_UnionSetWithFiveElementsWithOtherSetWithFourElements_ReturnSetWithSixElements()
        {
            //arrange
            var firstSet = new Set<int> { 1, 2, 3, 4, 5 };
            var secondSet = new Set<int> { 3, 4, 5, 6 };
            var expected = 6;

            //act
            var resultSet = firstSet.UnionWith(secondSet);
            var actual = resultSet.Count;

            //assert
            Assert.AreEqual(expected, actual, "Should be Set with 6 elements");
        }

        [Test]
        public void ExceptWith_ExceptSetWithFiveElementsWithOtherSetWithFourElements_ReturnSetWithTwoElements()
        {
            //arrange
            var firstSet = new Set<int> { 1, 2, 3, 4, 5 };
            var secondSet = new Set<int> { 3, 4, 5, 6 };
            var expected = 2;

            //act
            var resultSet = firstSet.ExceptWith(secondSet);
            var actual = resultSet.Count;

            //assert
            Assert.AreEqual(expected, actual, "Should be Set with 2 elements");
        }

        [Test]
        public void Intersect_IntersectSetWithFiveElementsWithOtherSetWithFourElements_ReturnSetWithThreeElements()
        {
            //arrange
            var firstSet = new Set<int> { 1, 2, 3, 4, 5 };
            var secondSet = new Set<int> { 3, 4, 5, 6 };
            var expected = 3;

            //act
            var resultSet = firstSet.Intersect(secondSet);
            var actual = resultSet.Count;

            //assert
            Assert.AreEqual(expected, actual, "Should be Set with 3 elements");
        }

        [Test]
        public void SymmetricExcept_SymmetricExceptSetWithFiveElementsWithOtherSetWithThreeElements_ReturnSetWithFourElements()
        {
            //arrange
            var firstSet = new Set<int> { 1, 2, 3, 4, 5 };
            var secondSet = new Set<int> { 4, 5, 6 };
            var expected = 4;

            //act
            var resultSet = firstSet.SymmetricExcept(secondSet);
            var actual = resultSet.Count;

            //assert
            Assert.AreEqual(expected, actual, "Should be Set with 4 elements");
        }

        [Test]
        public void IsSubsetOf_FirstSetIsSubsetOfSecondSet_ReturnTrue()
        {
            //arrange
            var firstSet = new Set<int> { 3, 4, 5 };
            var secondSet = new Set<int> { 2, 3, 4, 5, 6, 7, 8 };

            //act
            var actual = firstSet.IsSubsetOf(secondSet);

            //assert
            Assert.IsTrue(actual, "First set should be Subset of second set");
        }
    }
}
