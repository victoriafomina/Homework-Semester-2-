using Microsoft.VisualStudio.TestTools.UnitTesting;
using SetGeneric;

namespace SetGenericTests
{
    [TestClass]
    public class SetGenericTests
    {
        private Set<int> set;

        [TestInitialize]
        public void Initialize()
        {
            set = new Set<int>();
        }

        // add tests

        [TestMethod]
        public void AddTestEmptySet()
        {
            Assert.IsFalse(set.Contains(1));
            Assert.AreEqual(0, set.Count);
            Assert.IsTrue(set.Add(1));
            Assert.AreEqual(1, set.Count);
            Assert.IsTrue(set.Contains(1));
        }

        [TestMethod]
        public void AddTestSomeElements()
        {
            Assert.IsFalse(set.Contains(0));
            Assert.IsFalse(set.Contains(3));
            Assert.IsFalse(set.Contains(9));
            Assert.IsFalse(set.Contains(75));
            Assert.IsFalse(set.Contains(-5));
            Assert.IsFalse(set.Contains(-24));
            Assert.IsTrue(set.Add(-5));
            Assert.IsTrue(set.Add(3));
            Assert.IsTrue(set.Add(9));
            Assert.IsTrue(set.Add(-24));
            Assert.IsTrue(set.Add(75));
            Assert.IsTrue(set.Add(0));
            Assert.AreEqual(6, set.Count);
            Assert.IsTrue(set.Contains(0));
            Assert.IsTrue(set.Contains(3));
            Assert.IsTrue(set.Contains(9));
            Assert.IsTrue(set.Contains(75));
            Assert.IsTrue(set.Contains(-5));
            Assert.IsTrue(set.Contains(-24));
        }

        [TestMethod]
        public void AddTestDuplicateElements()
        {
            Assert.IsTrue(set.Add(100));
            Assert.IsFalse(set.Add(100));
            Assert.AreEqual(1, set.Count);
            Assert.IsTrue(set.Contains(100));
        }

        // remove tests

        [TestMethod]
        public void RemoveTestEmptySet()
        {
            Assert.IsFalse(set.Remove(2));
        }

        [TestMethod]
        public void RemoveTestSomeElements()
        {
            set.Add(1);
            set.Add(2);
            set.Add(-5);
            set.Add(10);
            set.Add(-3);
            Assert.IsTrue(set.Contains(1));
            Assert.IsTrue(set.Contains(-5));
            Assert.IsTrue(set.Remove(1));
            Assert.IsTrue(set.Remove(-5));
            Assert.IsFalse(set.Contains(1));
            Assert.IsFalse(set.Contains(-5));
        }

        [TestMethod]
        public void RemoveTestFromOneElementSet()
        {
            set.Add(1000);
            Assert.IsTrue(set.Contains(1000));
            Assert.IsTrue(set.Remove(1000));
            Assert.IsFalse(set.Contains(1000));
            Assert.AreEqual(0, set.Count);
        }

        // clear tests

        [TestMethod]
        public void ClearTestEmptySet()
        {
            set.Clear();
            Assert.AreEqual(0, set.Count);
        }

        [TestMethod]
        public void ClearTestFromNotEmptySet()
        {
            set.Add(1);
            set.Add(2);
            set.Add(-5);
            set.Add(10);
            set.Add(-3);
            Assert.AreEqual(5, set.Count);
            set.Clear();
            Assert.AreEqual(0, set.Count);
        }

        // except with tests

        [TestMethod]
        public void ExceptWithTestCollectionsHaveIntersection()
        {
            set.Add(1);
            set.Add(2);
            set.Add(-5);
            set.Add(10);
            set.Add(-3);

            var other = new Set<int>();
            other.Add(1);
            other.Add(2);

            set.ExceptWith(other);

            Assert.AreEqual(3, set.Count);
            Assert.IsTrue(set.Contains(-5));
            Assert.IsTrue(set.Contains(-3));
            Assert.IsTrue(set.Contains(10));
        }

        [TestMethod]
        public void ExceptWithTestCollectionsHaveNoIntersections()
        {
            set.Add(7);
            set.Add(9);
            set.Add(-2);
            set.Add(-10);
            set.Add(-11);

            var other = new Set<int>();
            other.Add(12);
            other.Add(0);

            set.ExceptWith(other);

            Assert.AreEqual(5, set.Count);
            Assert.IsTrue(set.Contains(7));
            Assert.IsTrue(set.Contains(9));
            Assert.IsTrue(set.Contains(-2));
            Assert.IsTrue(set.Contains(-10));
            Assert.IsTrue(set.Contains(-11));
            Assert.IsFalse(set.Contains(12));
            Assert.IsFalse(set.Contains(0));
        }

        [TestMethod]
        public void ExceptWithTestEmptySet()
        {
            var other = new Set<int>();
            other.Add(12);
            other.Add(0);

            set.ExceptWith(other);

            Assert.AreEqual(0, set.Count);
        }

        [TestMethod]
        public void ExceptWithTestEmptyOther()
        {
            set.Add(7);
            set.Add(9);
            set.Add(-2);
            set.Add(-10);
            set.Add(-11);

            var other = new Set<int>();

            set.ExceptWith(other);

            Assert.AreEqual(5, set.Count);
        }

        // union with tests
        
        [TestMethod]
        public void UnionWithTestCollectionsAreNotEqual()
        {
            set.Add(56);
            set.Add(5);
            set.Add(-5);
            set.Add(0);
            set.Add(-3);

            var other = new Set<int>();
            other.Add(1);
            other.Add(2);
            other.Add(-5);

            set.UnionWith(other);

            Assert.AreEqual(7, set.Count);
            Assert.IsTrue(set.Contains(56));
            Assert.IsTrue(set.Contains(5));
            Assert.IsTrue(set.Contains(-5));
            Assert.IsTrue(set.Contains(0));
            Assert.IsTrue(set.Contains(-3));
            Assert.IsTrue(set.Contains(1));
            Assert.IsTrue(set.Contains(2));
        }

        [TestMethod]
        public void UnionWithTestCollectionsAreEqual()
        {
            set.Add(56);
            set.Add(5);
            set.Add(-5);
            set.Add(0);
            set.Add(-3);

            var other = new Set<int>();
            other.Add(56);
            other.Add(5);
            other.Add(-5);
            other.Add(0);
            other.Add(-3);

            set.UnionWith(other);

            Assert.AreEqual(5, set.Count);
            Assert.IsTrue(set.Contains(56));
            Assert.IsTrue(set.Contains(5));
            Assert.IsTrue(set.Contains(-5));
            Assert.IsTrue(set.Contains(0));
            Assert.IsTrue(set.Contains(-3));
        }

        // symmetric except with tests

        [TestMethod]
        public void SymmetricExceptWithTestCollectionsAreEqual()
        {
            set.Add(56);
            set.Add(5);
            set.Add(-5);
            set.Add(0);
            set.Add(-3);

            var other = new Set<int>();
            other.Add(56);
            other.Add(5);
            other.Add(-5);
            other.Add(0);
            other.Add(-3);

            set.SymmetricExceptWith(other);

            Assert.AreEqual(0, set.Count);
        }

        [TestMethod]
        public void SymmetricExceptWithTestCollectionsHaveNoIntersection()
        {
            set.Add(0);
            set.Add(-7);
            set.Add(2);

            var other = new Set<int>();
            other.Add(1);
            other.Add(-5);

            set.SymmetricExceptWith(other);

            Assert.AreEqual(5, set.Count);
            Assert.IsTrue(set.Contains(0));
            Assert.IsTrue(set.Contains(-7));
            Assert.IsTrue(set.Contains(2));
            Assert.IsTrue(set.Contains(1));
            Assert.IsTrue(set.Contains(-5));
        }

        public void SymmetricExceptWithCollectionsHaveIntersection()
        {
            set.Add(0);
            set.Add(-7);
            set.Add(2);

            var other = new Set<int>();
            other.Add(1);
            other.Add(-5);
            other.Add(0);

            set.SymmetricExceptWith(other);

            Assert.AreEqual(4, set.Count);
            Assert.IsFalse(set.Contains(0));
            Assert.IsTrue(set.Contains(-7));
            Assert.IsTrue(set.Contains(2));
            Assert.IsTrue(set.Contains(1));
            Assert.IsTrue(set.Contains(-5));
        }

        // set equals tests

        [TestMethod]
        public void SetEqualsTestCollectionsAreEqual()
        {
            set.Add(56);
            set.Add(5);
            set.Add(-5);
            set.Add(0);
            set.Add(-3);

            var other = new Set<int>();
            other.Add(56);
            other.Add(5);
            other.Add(-5);
            other.Add(0);
            other.Add(-3);

            Assert.IsTrue(set.SetEquals(other));
        }

        [TestMethod]
        public void SetEqualsTestCollectionsAreNotEqual()
        {
            set.Add(56);
            set.Add(5);
            set.Add(-5);
            set.Add(0);
            set.Add(-3);

            var other = new Set<int>();
            other.Add(56);
            other.Add(5);
            other.Add(-5);
            other.Add(0);

            Assert.IsFalse(set.SetEquals(other));
        }

        // overlaps tests

        [TestMethod]
        public void OverlapsTestCollectionsHaveNoOverlap()
        {
            set.Add(56);
            set.Add(5);
            set.Add(-5);
            set.Add(0);
            set.Add(-3);

            var other = new Set<int>();
            other.Add(6);
            other.Add(9);
            other.Add(7);
            other.Add(8);

            Assert.IsFalse(set.Overlaps(other));
        }

        [TestMethod]
        public void OverlapsTestCollectionsHaveOverlap()
        {
            set.Add(56);
            set.Add(5);
            set.Add(-5);
            set.Add(0);
            set.Add(-3);

            var other = new Set<int>();
            other.Add(56);
            other.Add(5);
            other.Add(-5);
            other.Add(0);

            Assert.IsTrue(set.Overlaps(other));
        }

        // is superset of tests

        [TestMethod]
        public void IsSupersetOfTestWhenItIsNot()
        {
            set.Add(56);
            set.Add(5);
            set.Add(-5);
            set.Add(0);
            set.Add(-3);

            var other = new Set<int>();
            other.Add(56);
            other.Add(5);
            other.Add(-5);
            other.Add(0);
            other.Add(1);

            Assert.IsFalse(set.IsSupersetOf(other));
        }

        [TestMethod]
        public void IsSupersetOfTestWhenItIsSuperset()
        {
            set.Add(56);
            set.Add(5);
            set.Add(-5);
            set.Add(0);
            set.Add(-3);

            var other = new Set<int>();
            other.Add(56);
            other.Add(5);
            other.Add(-5);

            Assert.IsTrue(set.IsSupersetOf(other));
        }

        // is subset of tests

        [TestMethod]
        public void IsSubsetOfTestWhenItIsSubset()
        {
            set.Add(56);
            set.Add(5);

            var other = new Set<int>();
            other.Add(56);
            other.Add(5);
            other.Add(-5);
            other.Add(0);
            other.Add(-3);

            Assert.IsTrue(set.IsSubsetOf(other));
        }

        [TestMethod]
        public void IsSubsetOfTestWhenItIsNot()
        {
            set.Add(56);
            set.Add(5);
            set.Add(100);

            var other = new Set<int>();
            other.Add(56);
            other.Add(5);
            other.Add(-5);
            other.Add(0);
            other.Add(-3);

            Assert.IsFalse(set.IsSubsetOf(other));
        }

        // is proper superset of tests

        [TestMethod]
        public void IsProperSupersetOfTestWhenSetsAreEqual()
        {
            set.Add(56);
            set.Add(5);
            set.Add(-5);
            set.Add(0);
            set.Add(-3);

            var other = new Set<int>();
            other.Add(56);
            other.Add(5);
            other.Add(-5);
            other.Add(0);
            other.Add(-3);

            Assert.IsFalse(set.IsProperSupersetOf(other));
        }

        [TestMethod]
        public void IsProperSupersetOfTestWhenItIsNotProperSuperset()
        {
            set.Add(56);
            set.Add(5);
            set.Add(-5);
            set.Add(0);
            set.Add(-3);

            var other = new Set<int>();
            other.Add(56);
            other.Add(5);
            other.Add(-5);
            other.Add(1);
            other.Add(-3);

            Assert.IsFalse(set.IsProperSupersetOf(other));
        }

        [TestMethod]
        public void IsProperSupersetOfTestWhenItIsProperSuperset()
        {
            set.Add(56);
            set.Add(5);
            set.Add(-5);
            set.Add(0);
            set.Add(-3);

            var other = new Set<int>();
            other.Add(56);
            other.Add(5);
            other.Add(-5);

            Assert.IsTrue(set.IsProperSupersetOf(other));
        }

        // is proper subset of tests

        [TestMethod]
        public void IsProperSubsetOfTestSetsAreEqual()
        {
            set.Add(56);
            set.Add(5);
            set.Add(-5);
            set.Add(0);
            set.Add(-3);

            var other = new Set<int>();
            other.Add(56);
            other.Add(5);
            other.Add(-5);
            other.Add(0);
            other.Add(-3);

            Assert.IsFalse(set.IsProperSubsetOf(other));
        }

        [TestMethod]
        public void IsProperSubsetOfTestWhenItIsNotProperSubset()
        {
            set.Add(56);
            set.Add(5);
            set.Add(-5);
            set.Add(1);

            var other = new Set<int>();
            other.Add(56);
            other.Add(5);
            other.Add(-5);
            other.Add(0);
            other.Add(-3);

            Assert.IsFalse(set.IsProperSubsetOf(other));
        }
        
        [TestMethod]
        public void IsProperSubsetOfTestWhenItIsProperSubset()
        {
            set.Add(56);
            set.Add(5);
            set.Add(-5);
            set.Add(0);

            var other = new Set<int>();
            other.Add(56);
            other.Add(5);
            other.Add(-5);
            other.Add(0);
            other.Add(-3);

            Assert.IsTrue(set.IsProperSubsetOf(other));
        }

        // intersect with tests

        [TestMethod]
        public void IntersectWithTestSetsDoNotIntersect()
        {
            set.Add(56);
            set.Add(5);
            set.Add(-5);
            set.Add(0);

            var other = new Set<int>();
            other.Add(6);
            other.Add(55);
            other.Add(-55);
            other.Add(1);

            set.IntersectWith(other);

            Assert.AreEqual(0, set.Count);                
        }

        [TestMethod]
        public void IntersectWithTestSetsIntersect()
        {
            set.Add(56);
            set.Add(5);
            set.Add(-5);
            set.Add(0);

            var other = new Set<int>();
            other.Add(6);
            other.Add(5);
            other.Add(-5);
            other.Add(1);

            set.IntersectWith(other);

            Assert.AreEqual(2, set.Count);
            Assert.IsTrue(set.Contains(5));
            Assert.IsTrue(set.Contains(-5));
        }
    }
}