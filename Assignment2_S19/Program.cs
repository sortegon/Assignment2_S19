using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Xml;

namespace Assignment2_S19
{
    class Program
    {
        static void Main(string[] args)
        {
            // left rotation
            Console.WriteLine("Left Rotation");
            int d = 4;
            int[] a = { 1, 2, 3, 4, 5 };
            int[] r = rotLeft(a, d);
            displayArray(r);

            // Maximum toys
            Console.WriteLine("\n\nMaximum toys");
            int k = 50;
            int[] prices = { 1, 12, 5, 111, 200, 1000, 10 };
            Console.WriteLine(maximumToys(prices, k));


            // Balanced sums
            Console.WriteLine("\n\nBalanced sums");
            List<int> arr = new List<int> { 1, 2, 3 };
            Console.WriteLine(balancedSums(arr));

            // Missing numbers
            Console.WriteLine("\n\nMissing numbers");
            int[] arr1 = { 203, 204, 205, 206, 207, 208, 203, 204, 205, 206};
            int[] brr = {203, 204, 204, 205, 206, 207, 205, 208, 203, 206, 205, 206, 204};
            int[] r2 = missingNumbers(arr1, brr);
            displayArray(r2);

            // grading students
            Console.WriteLine("\n\nGrading students");
            int[] grades = { 73, 67, 38, 33 };
            int[] r3 = gradingStudents(grades);
            displayArray(r3);

            // find the median
            Console.WriteLine("\n\nFind the median");
            int[] arr2 = { 0, 1, 2, 4, 6, 5, 3};
            Console.WriteLine(findMedian(arr2));

            // closest numbers
            Console.WriteLine("\n\nClosest numbers");
            int[] arr3 = { 5, 4, 3, 2 };
            int[] r4 = closestNumbers(arr3);
            displayArray(r4);

            // Day of programmer
            Console.WriteLine("\n\nDay of Programmer");
            int year = 2017;
            Console.WriteLine(dayOfProgrammer(year));
        }

        static void displayArray(int []arr) {
            Console.WriteLine();
            foreach(int n in arr) {
                Console.Write(n + " ");
            }
        }

        // rotLeft takes an array and rotates it left by d spaces
        static int[] rotLeft(int[] a, int d)
        {
            if (a == null)
                return null;
            int n = a.Length;
            int [] r = new int[n];
            d %= n;
            for (int i = 0; i < n;i++)
            {
                r[(i - d + n) % n] = a[i];
            }
            return r;
        }

        // Complete the maximumToys function below.
        static int maximumToys(int[] prices, int k)
        {
            int len = prices.Length;
            //Todo: Professor says to include an algorithm for sorting (bubble ArgumentOutOfRangeException Binary)
            Array.Sort(prices);
            int sum = 0;
            int q = 0;

            for (int i = 0; i < len; i++)
            {
                if (sum + prices[i] <= k)
                {
                    sum += prices[i];
                    q++;
                }
                else
                    break;
            }
            return q;
        }

        // Complete the balancedSums function below.
        static string balancedSums(List<int> arr)
        {
            int sumLeft = 0;
            int sumRight = 0;

            for(int i=1; i<arr.Count; i++)
            {
                sumRight += arr[i];
            }

            for (int j = 0; j < (arr.Count - 1); j++)
            {
                if (sumRight == sumLeft)
                {
                    return "Yes";
                }
                else
                {
                    sumLeft += arr[j];
                    //Warning: j+1 is going to go out of range by 1!?!
                    sumRight -= arr[j + 1];
                }
            }
            return "No";
        }

        // Complete the missingNumbers function below.
        static int[] missingNumbers(int[] arr, int[] brr)
        {
            int j = 0;
            Array.Sort(brr);
            Array.Sort(arr);
            int [] output = new int[brr.Length - arr.Length];

            for(int i=0; i<arr.Length; i++)
            {
                if (arr[j] != brr[i])
                {
                    output[i - j] = brr[i];
                }
                else
                {
                    j++;
                }
            }
            return output;

        }


        // Complete the gradingStudents function below.
        static int[] gradingStudents(int[] grades)
        {
            int [] output = new int[grades.Length];
            for (int i = 0; i < grades.Length; i++)
            {
                if (grades[i] % 5 > 2 && grades[i] >= 38)
                {
                    output[i] = ((grades[i] / 5) * 5) + 5;
                }
                else
                {
                    {
                        output[i] = grades[i];
                    }
                }
            }

            return output;
        }

        // Complete the findMedian function below.
        static int findMedian(int[] arr)
        {
            Array.Sort(arr);
            int len = arr.Length;
            int med = len / 2;

            if (len % 2 == 0)
            {
                return (arr[med-1]+arr[med])/2;
            }
            else
            {
                return arr[med];
            }
        }

        // Complete the closestNumbers function below.
        static int[] closestNumbers(int[] arr)
        {
            return new int[] { };
        }

        // Complete the dayOfProgrammer function below.
        static string dayOfProgrammer(int year)
        {
            return "";
        }
    }
}
