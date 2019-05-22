using System;

namespace MergeKSortedArrays_JustMergeAll
{
    class Program
    {
        public static void Main(String[] args)
        {
            Console.WriteLine("Enter the number of arrays that have to be merged");
            try
            {
                int numberOfArrays = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the number of elements in each array");
                int eachArraySize = int.Parse(Console.ReadLine());
                //Use Jagged Array to process Input
                int[][] arrayOfArrays = new int[numberOfArrays][];
                for (int arrayIdentifierIndex = 0; arrayIdentifierIndex < numberOfArrays; arrayIdentifierIndex++) {
                    arrayOfArrays[arrayIdentifierIndex] = InputProcessor.GetArrayFromUserInput(eachArraySize);
                }
                InputProcessor.PrintMergedArray(arrayOfArrays);
            }
            catch (Exception exception) {
                Console.WriteLine("Program:Main:Exception thrown is "+exception.Message);
            }

            Console.ReadLine();
        }
    }
}
