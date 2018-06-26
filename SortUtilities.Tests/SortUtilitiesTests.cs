using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortUtilities;

namespace SortUtilities.Tests
{
    [TestClass]
    public class SortUtilitiesTests
    {
        [TestMethod]
        public void QuickSort_TestArraySort_ExpectedArray()
        {
            int[] testArray = { 7, -2, 1, 4, 0, 9, 5, 3, 1, 8 };
            int[] expectedArray = { -2, 0, 1, 1, 3, 4, 5, 7, 8, 9 };

            Sortings.QuickSort(testArray);
            CollectionAssert.AreEqual(expectedArray, testArray);
        }

        [TestMethod,ExpectedException(typeof(ArgumentNullException))]
        public void QuickSort_Null_ArgumentNullException()
        {
            Sortings.QuickSort(null);
        }
        
        [TestMethod]
        public void MergeSort_TestArraySort_ExpectedArray()
        {
            int[] testArray = { 7, -2, 1, 4, 0, 9, 5, 3, 1, 8 };
            int[] expectedArray = { -2, 0, 1, 1, 3, 4, 5, 7, 8, 9 };

            Sortings.MergeSort(testArray);
            CollectionAssert.AreEqual(expectedArray, testArray);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void MergeSort_Null_ArgumentNullException()
        {
            Sortings.MergeSort(null);
        }

        [TestMethod]
        public void MergeSort_EmptyArray_EmptyArray()
        {
            int[] x = { };
            int[] y = { };
            Sortings.MergeSort(x);
            CollectionAssert.AreEqual(x, y);
        }
    }
}
