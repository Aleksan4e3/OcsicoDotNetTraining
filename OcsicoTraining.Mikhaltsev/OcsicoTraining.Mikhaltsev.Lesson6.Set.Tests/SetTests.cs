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
            var inputSet = new Set<int> { 1, 3, 5, 2, 4 };
            var expected = 5;

            //act
            var actual = inputSet.Count;

            //assert
            Assert.AreEqual(expected, actual, "Should be Set with 5 elements");
        }

        [Test]
        public void Add_AddItemWhichIsNotYetInSet_ReturnTrue()
        {
            //arrange
            var inputSet = new Set<int> { 1, 3, 5, 2, 4 };

            //act
            var actual = inputSet.Add(8);

            //assert
            Assert.IsTrue(actual, "Element should be added");
        }

        [Test]
        public void Add_AddItemWhichAlreadyExistInSet_ReturnFalse()
        {
            //arrange
            var inputSet = new Set<int> { 1, 3, 5, 2, 4 };

            //act
            var actual = inputSet.Add(3);

            //assert
            Assert.IsFalse(actual, "Element should not be added");
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(4)]
        public void Contains_SetIsContainsElement_ReturnTrue(int element)
        {
            //arrange
            var inputSet = new Set<int> { 1, 3, 5, 2, 4 };

            //act
            var actual = inputSet.Contains(element);

            //assert
            Assert.IsTrue(actual, $"Set is contains element {element}");
        }

        [Test]
        public void Clear_ClearSet_ReturnEmptySet()
        {
            //arrange
            var inputSet = new Set<int> { 1, 3, 5, 2, 4 };
            var expected = 0;

            //act
            inputSet.Clear();
            var actual = inputSet.Count;

            //assert
            Assert.AreEqual(expected, actual, "Should be empty Set");
        }

        [Test]
        public void Remove_RemoveExistElementFromSet_ReturnTrue()
        {
            //arrange
            var inputSet = new Set<int> { 1, 3, 5, 2, 4 };

            //act
            var actual = inputSet.Remove(3);

            //assert
            Assert.IsTrue(actual, "Element should be removed");
        }

        [Test]
        public void Remove_RemoveItemWhichIsNotExistInSet_ReturnFalse()
        {
            //arrange
            var inputSet = new Set<int> { 1, 3, 5, 2, 4 };

            //act
            var actual = inputSet.Remove(6);

            //assert
            Assert.IsFalse(actual, "Element does not exist");
        }

        [Test]
        public void UnionWith_UnionSetWithFiveElementsWithCollectionWithFourElements_ReturnSetWithSixElements()
        {
            //arrange
            var set = new Set<int> { 1, 3, 5, 2, 4 };
            var collection = new[] { 3, 4, 6, 5 };
            var expected = 6;

            //act
            set.UnionWith(collection);
            var actual = set.Count;

            //assert
            Assert.AreEqual(expected, actual, "Should be Set with 6 elements");
        }

        [Test]
        public void ExceptWith_ExceptSetWithFiveElementsWithCollectionWithFourElements_ReturnSetWithTwoElements()
        {
            //arrange
            var set = new Set<int> { 1, 3, 5, 2, 4 };
            var collection = new[] { 3, 4, 6, 5 };
            var expected = 2;

            //act
            set.ExceptWith(collection);
            var actual = set.Count;

            //assert
            Assert.AreEqual(expected, actual, "Should be Set with 2 elements");
        }

        [Test]
        public void Intersect_IntersectSetWithFiveElementsWithCollectionWithFourElements_ReturnSetWithThreeElements()
        {
            //arrange
            var set = new Set<int> { 1, 3, 5, 2, 4 };
            var collection = new[] { 3, 4, 6, 5 };
            var expected = 3;

            //act
            set.Intersect(collection);
            var actual = set.Count;

            //assert
            Assert.AreEqual(expected, actual, "Should be Set with 3 elements");
        }

        [Test]
        public void SymmetricExcept_SymmetricExceptSetWithFiveElementsWithCollectionWithThreeElements_ReturnSetWithFourElements()
        {
            //arrange
            var set = new Set<int> { 1, 3, 5, 2, 4 };
            var collection = new[] { 4, 6, 5 };
            var expected = 4;

            //act
            set.SymmetricExcept(collection);
            var actual = set.Count;

            //assert
            Assert.AreEqual(expected, actual, "Should be Set with 4 elements");
        }

        [Test]
        public void IsSubsetOf_SetIsSubsetOfCollection_ReturnTrue()
        {
            //arrange
            var set = new Set<int> { 3, 5, 4 };
            var collection = new[] { 2, 3, 7, 6, 4, 8, 5 };

            //act
            var actual = set.IsSubsetOf(collection);

            //assert
            Assert.IsTrue(actual, "Set should be subset of collection");
        }
    }
}
