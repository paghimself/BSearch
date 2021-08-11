using System;

namespace BSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            // generate a long list of number
            // sort them if unsorted
            // get average of iteration based on amount of values in the array
            // use random generator to get arrays of different size

            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            int pointer;
            int min;
            int max;
            int iteration;
            bool positionFound;


            foreach (var item in arr)
            {
                pointer = arr.Length / 2;
                min = 0;
                max = arr.Length;
                iteration = 0;
                positionFound = false;
                Console.WriteLine($"Trying to find {item}");

                while (arr[pointer] != item)
                {
                    iteration++;
                    if (arr[pointer] > item)
                    {
                        max = pointer - 1;
                        if (max == min)
                        {
                            Output(item, max, iteration);
                            positionFound = true;
                            break;
                        }
                        else
                        {
                            pointer = ((max - min) / 2) + min;
                        }
                        if (arr[pointer] == item)
                        {
                            Output(item, pointer, iteration);
                            positionFound = true;
                            break;
                        }
                    }
                    else
                    {
                        min = pointer + 1;

                        if (min == max)
                        {
                            Output(item, min, iteration);
                            positionFound = true;
                            break;
                        }
                        else
                        {
                            pointer = ((max - min) / 2) + min;
                        }
                        if (arr[pointer] == item)
                        {
                            Output(item, pointer, iteration);
                            positionFound = true;
                            break;
                        }
                    }
                }
                if (!positionFound)
                {
                    Output(item, pointer, iteration);
                    continue;
                }
            }
        }
        static void Output(int number, int position, int iteration)
        {
            Console.WriteLine($"Number: {number} Position: {position}");
            Console.WriteLine($"Iteration: {iteration}");
            Console.WriteLine();
        }
    }
}
