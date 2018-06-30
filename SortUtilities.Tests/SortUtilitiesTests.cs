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

        [TestMethod]
        public void QuickSort_LargeArray_ExtectedArray()
        {
            int minPossibleValue = 0;
            int maxPossibleValue = 1000000;
            Random randNum = new Random();

            int[] largeTestArray = new int[Int32.MaxValue/10];
            for (int i = 0; i < largeTestArray.Length; i++)
            {
                largeTestArray[i] = randNum.Next(minPossibleValue, maxPossibleValue);
            }

            int[] expectedArray = largeTestArray;
            Array.Sort(expectedArray);

            Sortings.QuickSort(largeTestArray);
            CollectionAssert.AreEqual(expectedArray, largeTestArray);
        }

        [TestMethod,ExpectedException(typeof(ArgumentNullException))]
        public void QuickSort_Null_ArgumentNullException()
        {
            Sortings.QuickSort(null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void QuickSort_EmptyArray_ArgumentNullException()
        {
            Sortings.QuickSort(new int[] { });
        }

        [TestMethod]
        public void MergeSort_TestArraySort_ExpectedArray()
        {
            int[] testArray = { 7, -2, 1, 4, 0, 9, 5, 3, 1, 8 };
            int[] expectedArray = { -2, 0, 1, 1, 3, 4, 5, 7, 8, 9 };

            Sortings.MergeSort(testArray);
            CollectionAssert.AreEqual(expectedArray, testArray);
        }

        [TestMethod]
        public void MergeSort_LargeArray_ExtectedArray()
        {
            int minPossibleValue = 0;
            int maxPossibleValue = 1000000;
            Random randNum = new Random();

            int[] largeTestArray = new int[Int32.MaxValue / 10000];
            for (int i = 0; i < largeTestArray.Length; i++)
            {
                largeTestArray[i] = randNum.Next(minPossibleValue, maxPossibleValue);
            }

            int[] expectedArray = largeTestArray;
            Array.Sort(expectedArray);

            Sortings.MergeSort(largeTestArray);
            CollectionAssert.AreEqual(expectedArray, largeTestArray);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void MergeSort_Null_ArgumentNullException()
        {
            Sortings.MergeSort(null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void MergeSort_EmptyArray_ArgumentNullException()
        {
            Sortings.MergeSort(new int[] { });
        }
    }
}
