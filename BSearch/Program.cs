using System;
using System.Diagnostics;

// A Binary Search Algorithm

namespace BSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            const int numberOfArrays = 1;
            const int minArrSize = 100000;
            const int maxArrSize = 1000000;
            int arrSize = Rand(minArrSize, maxArrSize);
            int pointer;
            int min;
            int max;
            int iteration;
            bool positionFound;
            double[] averageTotalIteration = new double[numberOfArrays];

            Stopwatch stopWatch = new Stopwatch();
            Console.WriteLine("Stopwatch has started...");
            stopWatch.Start();

            for (int arrays = 0; arrays < numberOfArrays; arrays++)
            {
                int[] arr = PopulateArray(arrSize);
                int[] comparedArr = new int[arrSize];
                int[] averageIteration = new int[arrSize];

                for (int position = 0; position < arr.Length; position++)
                {
                    int item = arr[position];
                    pointer = arr.Length / 2;
                    min = 0;
                    max = arr.Length;
                    iteration = 0;
                    positionFound = false;
                    //Console.WriteLine($"Trying to find {item}");

                    while (arr[pointer] != item)
                    {
                        iteration++;
                        if (arr[pointer] > item)
                        {
                            max = pointer - 1;
                            if (max == min)
                            {
                                //Output(item, position, iteration);
                                comparedArr[position] = item;
                                averageIteration[position] = iteration;
                                positionFound = true;
                                break;
                            }
                            else
                            {
                                pointer = ((max - min) / 2) + min;
                            }
                            if (arr[pointer] == item)
                            {
                                //Output(item, position, iteration);
                                comparedArr[position] = item;
                                averageIteration[position] = iteration;
                                positionFound = true;
                                break;
                            }
                        }
                        else
                        {
                            min = pointer + 1;
                            if (min == max)
                            {
                                //Output(item, position, iteration);
                                comparedArr[position] = item;
                                averageIteration[position] = iteration;
                                positionFound = true;
                                break;
                            }
                            else
                            {
                                pointer = ((max - min) / 2) + min;
                            }
                            if (arr[pointer] == item)
                            {
                                //Output(item, position, iteration);
                                comparedArr[position] = item;
                                averageIteration[position] = iteration;
                                positionFound = true;
                                break;
                            }
                        }
                    }
                    if (!positionFound)
                    {
                        //Output(item, position, iteration);
                        comparedArr[position] = item;
                        continue;
                    }
                }

                if (Validate(arr, comparedArr))
                {
                    averageTotalIteration[arrays] = GetAverageIteration(averageIteration);
                }
                else
                {
                    Console.WriteLine("  ======================================== ERROR ========================================  ");
                }
            }
            stopWatch.Stop();
            Console.WriteLine("Stopwatch has stopped...");
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine();
            Console.WriteLine("RunTime " + elapsedTime);

            GetTotalAverageIteration(averageTotalIteration);
            Console.WriteLine($"numberOfArrays: {numberOfArrays}");
            Console.WriteLine($"minArrSize: {minArrSize}");
            Console.WriteLine($"maxArrSize: {maxArrSize}");
        }

        //RunTime 00:00:03.38
        //The total average iteration is 7.94
        //numberOfArrays: 1_000
        //minArrSize: 100
        //maxArrSize: 1_000

        //RunTime 00:00:09.17
        //The total average iteration is 9.417
        //numberOfArrays: 1_000
        //minArrSize: 10_00
        //maxArrSize: 10_000

        //RunTime 00:00:01.48
        //The total average iteration is 10.003
        //numberOfArrays: 100
        //minArrSize: 1_000
        //maxArrSize: 10_000

        //RunTime 00:00:23.27
        //The total average iteration is 13.977
        //numberOfArrays: 100
        //minArrSize: 10_000
        //maxArrSize: 100_000

        //RunTime 00:04:27.42
        //The total average iteration is 17.568
        //numberOfArrays: 100
        //minArrSize: 100_000
        //maxArrSize: 1_000_000

        //RunTime 00:00:01.59
        //The total average iteration is 16.785
        //numberOfArrays: 1
        //minArrSize: 100_000
        //maxArrSize: 1_000_000

        private static double GetAverageIteration(int[] averageIteration)
        {
            int sum = 0;
            foreach (var iter in averageIteration)
            {
                sum += iter;
            }
            double average = sum / (double)averageIteration.Length;
            //Console.WriteLine($"The average iteration is {Math.Round(average, 3)}");
            return average;
        }

        private static void GetTotalAverageIteration(double[] averageIteration)
        {
            double sum = 0;
            foreach (var iter in averageIteration)
            {
                sum += iter;
            }
            double average = sum / averageIteration.Length;
            Console.WriteLine($"The total average iteration is {Math.Round(average, 3)}");
        }

        private static int[] PopulateArray(int arrSize)
        {
            int[] populatedArr = new int[arrSize];
            int lastRdn = Rand(10);
            int rdn;
            for (int position = 0; position < arrSize; position++)
            {
                rdn = Rand(lastRdn + 1, lastRdn + Rand(10) + 1);
                populatedArr[position] = rdn;
                lastRdn = rdn;
            }
            return populatedArr;
        }

        private static int Rand(int min, int max)
        {
            return new Random().Next(min, max);
        }

        private static int Rand(int max)
        {
            return new Random().Next(max);
        }

        static void Output(int number, int position, int iteration)
        {
            Console.WriteLine($"Number: {number} Position: {position}");
            Console.WriteLine($"Iteration: {iteration}");
            Console.WriteLine();
        }

        static bool Validate(int[] expected, int[] actual)
        {
            for (int position = 0; position < actual.Length; position++)
            {
                if (expected[position] != actual[position])
                    return false;
            }
            return true;
        }
    }
}
