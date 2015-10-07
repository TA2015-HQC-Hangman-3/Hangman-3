﻿
namespace Hangman.Tests.Sorters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Logic.Sorters;

    [TestClass]
    public class ComparerSorterTests
    {
        [TestMethod]
        public void ComparerSorterSort_WhenCollectionHasASingleElement_ShouldReturnCollectionWithSingleElement()
        {
            KeyValuePair<string, int>[] collection =
            {
                new KeyValuePair<string, int>("Test", 1)
            };
            var sorter = new ComparerSorter();

            //act
            var result = sorter.Sort(collection);

            //assert

            Assert.AreEqual(collection.Count(), result.Count());
            Assert.AreEqual(collection[0], result.ElementAt(0));
        }


        [TestMethod]
        public void ComparerSorterSort_WhenCollectionHasTwoSortedElements_ShouldReturnTheSameElementInTheSameOrder()
        {
            KeyValuePair<string, int>[] collection =
            {
                new KeyValuePair<string, int>("Test 1", 1),
                new KeyValuePair<string, int>("Test 2", 2)
            };
            var sorter = new ComparerSorter();

            //act
            var result = sorter.Sort(collection);

            //assert

            Assert.AreEqual(collection.Length, result.Count());
            for (int i = 0; i < collection.Length; i++)
            {
                Assert.AreEqual(collection[i], result.ElementAt(i));
            }
        }

        [TestMethod]
        public void ComparerSorterSort_WhenCollectionHasTwoUnsortedElements_ShouldReturnTheSameElementInTheSameOrder()
        {
            KeyValuePair<string, int>[] collection =
            {
                new KeyValuePair<string, int>("Test 2", 2),
                new KeyValuePair<string, int>("Test 1", 1)
            };
            var sorter = new ComparerSorter();

            //act
            var actual = sorter.Sort(collection);
            var expected = collection.OrderBy(item => item.Value).ToArray();

            //assert
            Assert.AreEqual(expected.Count(), actual.Count());
            for (int i = 0; i < expected.Count(); i++)
            {
                Assert.AreEqual(expected.ElementAt(i), actual.ElementAt(i));
            }
        }

        [TestMethod]
        public void ComparerSorterSort_WhenCollectionIsEmpty_ShouldReturnEmtpyCollection()
        {
            //arrange 
            KeyValuePair<string, int>[] collection = { };
            var sorter = new ComparerSorter();

            //act
            var result = sorter.Sort(collection);

            //assert

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ComparerSorterSort_WhenCollectionIsNull_ShouldThrow()
        {
            //arrange 
            KeyValuePair<string, int>[] collection = null;
            var sorter = new ComparerSorter();

            //act
            var result = sorter.Sort(collection);
        }
    }
}
