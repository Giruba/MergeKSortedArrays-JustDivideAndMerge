using System;
using System.Collections.Generic;
using System.Text;

namespace MergeKSortedArrays_JustMergeAll
{
    class InputProcessor
    {
        public static int[] GetArrayFromUserInput(int size = 0) {
            int[] array = null;

            try
            {
                if (size <= 0)
                {
                    Console.WriteLine("Enter the number of elements in the array");
                    size = int.Parse(Console.ReadLine());
                }
                else {
                    array = new int[size];
                    Console.WriteLine("Enter the array elements separated by space, comma or semi-colon");
                    String[] arrayElements = Console.ReadLine().Trim().Split(' ', ';', ',');
                    for (int arrayIndex = 0; arrayIndex < size; arrayIndex++) {
                        array[arrayIndex] = int.Parse(arrayElements[arrayIndex]);
                    }
                }
            }
            catch (Exception exception) {
                Console.WriteLine("InputProcessor:GetArrayFromUserInput: Thrown exception is "+exception.Message);
            }

            return array;
        }

        public static int[] MergeSortedArraysOfSameSize(int[][] jaggedArray, int start, int end) {
            int[] finalArray = null;

            if (start == end) {
                return jaggedArray[start];
            }

            if ((start >= 0) && ((start + 1) == end)) {
                return MergeArrays(jaggedArray[start], jaggedArray[end]);
            }

            if (start < end && start+1 != end)
            {
                int middle = start+end/2;
                int[] mergedArray1 = MergeSortedArraysOfSameSize(jaggedArray, start, middle);
                int[] mergedArray2 = MergeSortedArraysOfSameSize(jaggedArray, middle+1, end);

                finalArray = MergeArrays(mergedArray1, mergedArray2);
            }

            return finalArray;
        }


        public static int[] MergeArrays(int[] firstArray, int[] secondArray) {
            int[] finalArray = new int[firstArray.Length + secondArray.Length];

            int firstArrayIndex = 0;
            int secondArrayIndex = 0;
            int mergingArrayIndex = 0;

            while (firstArrayIndex < firstArray.Length && secondArrayIndex < secondArray.Length)
            {
                if (firstArray[firstArrayIndex] < secondArray[secondArrayIndex])
                {
                    finalArray[mergingArrayIndex++] = firstArray[firstArrayIndex++];
                }
                else
                {
                    finalArray[mergingArrayIndex++] = secondArray[secondArrayIndex++];
                }
            }

            while (firstArrayIndex < firstArray.Length)
            {
                finalArray[mergingArrayIndex++] = firstArray[firstArrayIndex++];
            }

            while (secondArrayIndex < secondArray.Length)
            {
                finalArray[mergingArrayIndex++] = secondArray[secondArrayIndex++];
            }
            return finalArray;
        }

        public static void PrintMergedArray(int[][] jaggedArray) {
            int[] mergedArray = MergeSortedArraysOfSameSize(jaggedArray, 0, jaggedArray.GetLength(0)-1);
            Console.WriteLine();
            Console.WriteLine("------------Printing merged array contents-------------------------");
            for (int index = 0; index < mergedArray.Length; index++) {
                Console.Write(mergedArray[index]+" ");
            }
        }
    }
}
