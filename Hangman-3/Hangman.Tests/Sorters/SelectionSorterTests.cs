namespace Hangman.Tests.Sorters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Hangman.Logic.Sorters;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Provides unit tests for <see cref="SelectionSorter"/> class.
    /// </summary>
    [TestClass]
    public class SelectionSorterTests
    {
        /// <summary>
        /// Checks if the sorter returns the right collection when there is only one element.
        /// </summary>
        [TestMethod]
        public void SelectionSorterSort_WhenCollectionHasASingleElement_ShouldReturnCollectionWithSingleElement()
        {
            KeyValuePair<string, int>[] collection =
            {
                new KeyValuePair<string, int>("Test", 1)
            };
            var sorter = new SelectionSorter();

            // act
            var result = sorter.Sort(collection);

            // assert
            Assert.AreEqual(collection.Count(), result.Count());
            Assert.AreEqual(collection[0], result.ElementAt(0));
        }
        
        /// <summary>
        /// Checks if the sorter returns the right collection when there are two sorted elements.
        /// </summary>
        [TestMethod]
        public void SelectionSorterSort_WhenCollectionHasTwoSortedElements_ShouldReturnTheSameElementInTheSameOrder()
        {
            KeyValuePair<string, int>[] collection =
            {
                new KeyValuePair<string, int>("Test 1", 1),
                new KeyValuePair<string, int>("Test 2", 2)
            };
            var sorter = new SelectionSorter();

            // act
            var result = sorter.Sort(collection);

            // assert
            Assert.AreEqual(collection.Length, result.Count());
            for (int i = 0; i < collection.Length; i++)
            {
                Assert.AreEqual(collection[i], result.ElementAt(i));
            }
        }

        /// <summary>
        /// Checks if the sorter returns the right collection when there are two unsorted elements.
        /// </summary>
        [TestMethod]
        public void SelectionSorterSort_WhenCollectionHasTwoUnsortedElements_ShouldReturnTheSameElementInTheSameOrder()
        {
            KeyValuePair<string, int>[] collection =
            {
                new KeyValuePair<string, int>("Test 2", 2),
                new KeyValuePair<string, int>("Test 1", 1)
            };
            var sorter = new SelectionSorter();

            // act
            var actual = sorter.Sort(collection);
            var expected = collection.OrderBy(item => item.Value).ToArray();

            // assert
            Assert.AreEqual(expected.Count(), actual.Count());
            for (int i = 0; i < expected.Count(); i++)
            {
                Assert.AreEqual(expected.ElementAt(i), actual.ElementAt(i));
            }
        }

        /// <summary>
        /// Checks if the sorter returns the right collection when there are no elements.
        /// </summary>
        [TestMethod]
        public void SelectionSorterSort_WhenCollectionIsEmpty_ShouldReturnEmtpyCollection()
        {
            // arrange 
            KeyValuePair<string, int>[] collection = { };
            var sorter = new SelectionSorter();

            // act
            var result = sorter.Sort(collection);

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count());
        }

        /// <summary>
        /// Checks if the sorter throws an exception when it is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SelectionSorterSort_WhenCollectionIsNull_ShouldThrow()
        {
            // arrange 
            KeyValuePair<string, int>[] collection = null;
            var sorter = new SelectionSorter();

            // act
            var result = sorter.Sort(collection);
        }
    }
}
