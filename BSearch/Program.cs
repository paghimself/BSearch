using System;

namespace BSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            // found after x move
            //foreach item in array try position
            // use test asset 
            //

            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            int pointer = arr.Length / 2;
            int min = 0;
            int max = arr.Length;

            foreach (var item in arr)
            {
                Console.WriteLine($"Trying to find {item}");

                while (arr[pointer] != item)
                {
                    if (arr[pointer] > item)
                    {
                        max = pointer - 1;
                        if (max == min)
                        {
                            Console.WriteLine($"item {item} found at position {max}");
                            break;
                        }
                        else
                        {
                            pointer = ((max - min) / 2) + min;
                        }
                        if (arr[pointer] == item)
                        {
                            Console.WriteLine($"item {item} found at position {pointer}");
                            break;
                        }
                    }
                    else
                    {
                        min = pointer + 1;

                        if (max == min)
                        {
                            Console.WriteLine($"item {item} found at position {max}");
                            break;
                        }
                        else
                        {
                            pointer = ((max - min) / 2) + min;
                        }
                        if (arr[pointer] == item)
                        {
                            Console.WriteLine($"item {item} found at position {pointer}");
                            break;
                        }
                    }
                }
                Console.WriteLine($"item {item} found at position {pointer}");
                break;

            }
        }
    }
}