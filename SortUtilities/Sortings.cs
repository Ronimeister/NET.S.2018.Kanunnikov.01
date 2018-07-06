using System;

namespace SortUtilities
{
    /// <summary>
    /// Static class which provides additional sorting methods (MergeSort & QuickSort) 
    /// </summary>
    public static class Sortings
    {
        #region Sort call methods
        /// <summary>
        /// Implement Quick Sort for the input array
        /// </summary>
        /// <param name="array">The array needed to be sorted</param>
        /// <exception cref="ArgumentNullException">Throws when the array is equal to null or empty.</exception>
        /// 
        public static void QuickSort(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array) + @" can't be equal to null.");
            }

            if(array.Length == 0)
            {
                throw new ArgumentNullException(nameof(array) + @" can't be empty.");
            }

            QuickSort(array, 0, array.Length - 1);
        }

        /// <summary>
        /// Implement Merge Sort for the input array
        /// </summary>
        /// <param name="array">The array needed to be sorted</param>
        /// <exception cref="ArgumentNullException">Throws when the array is equal to null or empty.</exception>
        public static void MergeSort(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array) + @" can't be equal to null.");
            }

            if (array.Length == 0)
            {
                throw new ArgumentNullException(nameof(array) + @" can't be empty.");
            }

            MergeSort(array, 0, array.Length - 1);
        }
        #endregion

        #region QuickSort methods
        /// <summary>
        /// Uses Quick Sort for part of array lying between "leftBorder" and "rightBorder" 
        /// </summary>
        /// <param name="array">The array needed to be sorted</param>
        /// <param name="leftBorder">Left border of the array(index of first array element)</param>
        /// <param name="rightBorder">Right border of the array(index of last array element)</param>
        private static void QuickSort(int[] array, int leftBorder, int rightBorder)
        {
            int i = leftBorder;
            int j = rightBorder;
            int separator = array[(leftBorder + rightBorder) / 2];

            Reshuffle(array, ref i, ref j, ref separator);

            if (i < rightBorder)
            {
                QuickSort(array, i, rightBorder);
            }

            if (j > leftBorder)
            {
                QuickSort(array, leftBorder, j);
            }
        }

        /// <summary>
        /// Reshuffle elements of the array into two groups separated by the separator element
        /// </summary>
        /// <param name="array">The array needed to be reshuffled</param>
        /// <param name="i">Index for the first half of the array</param>
        /// <param name="j">Index for the second half of the array</param>
        /// <param name="separator">Element that divides array into two parts</param>
        private static void Reshuffle(int[] array, ref int i, ref int j, ref int separator)
        {
            while (i <= j)
            {
                while (array[i] < separator)
                {
                    i++;
                }

                while (array[j] > separator)
                {
                    j--;
                }

                if (i <= j)
                {
                    Swap(ref array[i], ref array[j]);
                    i++;
                    j--;
                }
            }
        }

        /// <summary>
        /// Swap position of two input elements
        /// </summary>
        /// <param name="firstEl">First element needed to be swaped</param>
        /// <param name="secondEl">Second element needed to be swaped</param>
        private static void Swap(ref int firstEl, ref int secondEl)
        {
            int temp;

            temp = firstEl;
            firstEl = secondEl;
            secondEl = temp;
        }
        #endregion

        #region MergeSort methods
        /// <summary>
        /// Uses Merge Sort for part of array lying between "low" and "high"
        /// </summary>
        /// <param name="array">The array needed to be sorted</param>
        /// <param name="low">Left border of the array(index of the first array element)</param>
        /// <param name="high">Right border of the array(index of the last array element)</param>
        private static void MergeSort(int[] array, int low, int high)
        {
            if (low < high)
            {
                int middle = (low + high) / 2;
                MergeSort(array, low, middle);
                MergeSort(array, middle + 1, high);

                int[] buf = InitializeBufferArray(array, low, high);

                int indexLeft = low;
                int indexRight = middle + 1;
                int current = low;

                Reshuffle(array, buf, ref indexLeft, ref indexRight, ref current, ref middle, ref high);

                int remaining = middle - indexLeft;

                for (int i = 0; i <= remaining; i++)
                {
                    array[current + i] = buf[indexLeft + i];
                }
            }
        }

        /// <summary>
        /// Initialize buffer array elements using main array
        /// </summary>
        /// <param name="array">Main array which elements will be putted in buffer array</param>
        /// <param name="low">Left border of the array(index of the first array element)</param>
        /// <param name="high">Right border of the array(index of the last array element)</param>
        /// <returns>Initialized buffer array</returns>
        private static int[] InitializeBufferArray(int[] array, int low, int high)
        {
            int[] buf = new int[array.Length];
            for (int i = low; i <= high; i++)
            {
                buf[i] = array[i];
            }

            return buf;
        }

        /// <summary>
        /// Reshuffle elements of buffer array if it needed and set them in the correct order into the main array
        /// </summary>
        /// <param name="array">Main array</param>
        /// <param name="buf">Buffer array which contains elements needed to be refhuffled</param>
        /// <param name="indexLeft">Index of the first element of buf array</param>
        /// <param name="indexRight">Index of the last element of buf array</param>
        /// <param name="current">Current index of the main array</param>
        /// <param name="middle">Middle element of the main array</param>
        /// <param name="high">Last element of the main array</param>
        private static void Reshuffle(int[] array, int[] buf, ref int indexLeft, ref int indexRight, ref int current, ref int middle, ref int high)
        {
            while (indexLeft <= middle && indexRight <= high)
            {
                if (buf[indexLeft] <= buf[indexRight])
                {
                    array[current] = buf[indexLeft];
                    indexLeft++;
                }
                else
                {
                    array[current] = buf[indexRight];
                    indexRight++;
                }

                current++;
            }
        }
        #endregion
    }
}
