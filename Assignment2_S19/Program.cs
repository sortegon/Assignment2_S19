using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;

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
            // if array is null or empty, return as-is
            if (a == null || a.Length == 0)
                return a;
            int n = a.Length;
            int[] r = new int[n];
            // reduce d  to within the size of the array to prevent rotating all the way through the array (potentially multiple times)
            d %= n;
            //loop through array calculating the new index for the new array for each element of the old array
            for (int i = 0; i < n;i++)
            {
                // reduce i by d to rotate left by d places 
                // add n to keep index positive without affecting modulus
                // modular-divide by n to stay within range of array
                r[(i - d + n) % n] = a[i];
            }
            return r;
        }

        // maximumToys takes an array of toy prices and determines the maximum possible toys that can be purchased given a dollar amount, k
        static int maximumToys(int[] prices, int k)
        {
            //
            // return 0 for null array
            if (prices == null)
            {
                return 0;
            }
            int len = prices.Length;
            // Sort the prices array so that the smaller amounts are added first, ensuring the most toys are purchasable
            bubbleSort(prices);
            // Use sum as a running total of how much money has been spent
            int sum = 0;
            // Use q as a running total of how many toys have been purchased
            int q = 0;

            // Loop through the array adding the toy price to sum if the addition does not exceed total money, k.
            // Add 1 to q each time the loop passes the if statement.
            for (int i = 0; i < len; i++)
            {
                if (sum + prices[i] <= k)
                {
                    sum += prices[i];
                    q++;
                }
                else
                    break; // Exit the program if the toy cost makes the sum too high
            }
            return q;
        }

        // balancedSums takes a list and determines if there is any number in the list where
        // the sum of all the numbers to the left equals the sum of all the numbers to the right
        static string balancedSums(List<int> arr)
        {
            // a null list has no sums so therefore it doesn't have balanced sums
            if (arr == null)
            {
                return "No";
            }
            int sumLeft = 0;
            int sumRight = 0;

            // loop through the list to determine the sum  of the list after the first integer
            for (int i=1; i<arr.Count; i++)
            {
                sumRight += arr[i];
            }

            // loop through the list to compare the sum of the integers to the right to the sum of the integers to the left
            // each time through remove the right most integer from the right sum and add the integer to the left of that to the left sum
            // return Yes and exit the method if sumRight equals sumLeft, indicating we found a balance point
            for (int j = 0; j < (arr.Count - 1); j++)
            {
                if (sumRight == sumLeft)
                {
                    return "Yes";
                }
                else
                {
                    sumLeft += arr[j];
                    sumRight -= arr[j + 1];
                }
            }
            // we have checked the entire array without finding a balance point
            return "No";
        }

        // missingNumbers takes 2 arrays and determines all the missing numbers from one to the other
        static int[] missingNumbers(int[] arr, int[] brr)
        {
            // if arr is null or empty everything in brr is missing
            if (arr == null || arr.Length == 0)
            {
                return brr;
            }

            int j = 0;

            //sort each array to make it easier to compare the two
            bubbleSort(brr);
            bubbleSort(arr);

            // we've already checked that arr has one element, so if brr has none then arr contains elements not in brr
            // if the largest element of arr is greater than the largest element of brr, then arr contains elements not in brr
            if (brr == null || brr.Length == 0 || arr[arr.Length-1]>brr[brr.Length-1])
            {
                throw new ArgumentException("arr must not contain elements that are not in brr");
            }
            // instantiate new array with a length of the difference of the two arrays since brr has either an equal or greater length than arr
            // and any numbers missing from the one are in the other
            int [] output = new int[brr.Length - arr.Length];

            // loop through the each array comparing the values
            // increase the counter for the smaller array only if the values of the values being compared are equal
            // increase the counter for the original array by one each time through the loop
            for(int i=0; i<brr.Length; i++)
            {
                // if the value in the smaller array is less than the value in the original array then arr likely contains elements not in brr
                if (arr[j]<brr[i])
                {
                    throw new ArgumentException("arr must not contain elements that are not in brr");
                }
                else if (arr[j] > brr[i])
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


        // gradingStudents takes an array of grades and either rounds them up
        // if they are close to a multiple of 5 or keeps them the same
        static int[] gradingStudents(int[] grades)
        {
            // can't round a null value so return null
            if (grades == null)
            {
                return null;
            }
            // instantiate a new array of the same length to hold the values of the rounded (or not) grades
            int [] output = new int[grades.Length];
            // loop through the array
            for (int i = 0; i < grades.Length; i++)
            {
                // check if grade is 38 or more as anything less than 38 would not be rounded because it is a failing grade
                // any remainder of 3 or 4 after dividing by 5 means round up
                // dividing by 5 drops the remainder then multiply by 5 and add 5 to simulate rounding up
                if (grades[i] % 5 > 2 && grades[i] >= 38)
                {
                    output[i] = ((grades[i] / 5) * 5) + 5;
                }
                else
                {
                    // no rounding occurs if previous conditions are not met
                    {
                        output[i] = grades[i];
                    }
                }
            }

            return output;
        }

        // findMedian takes an array and finds the middle number, incrementally,
        // Method averages the two middle numbers if the array length is even.
        static int findMedian(int[] arr)
        {
            // there is no median of a null array
            if (arr == null)
            {
                throw new NullReferenceException("The array cannot be null.");
            }
            // there is no median of an empty array
            if (arr.Length == 0)
            {
                throw new ArgumentException("The length of the array must be greater than or equal to 1");
            }
            bubbleSort(arr);
            int len = arr.Length;
            // instantiate variable to hold the half way index value of an array
            int med = len / 2;
            
            // if the array length is even, average the middle two values
            if (len % 2 == 0)
            {
                return (arr[med-1]+arr[med])/2;
            }
            else
            {
                return arr[med];
            }
        }

        // closestNumbers takes an array and determines what combination of integers has the smallest difference
        static int[] closestNumbers(int[] arr)
        {
            // A null or empty array can not calculate differences
            if (arr == null || arr.Length == 0)
            {
                return arr;
            }
            
            // instantiate a variable with the maximum count of values the function can contain
            int count = 2*(arr.Length)-2;
            // having the array in numerical order helps determine the difference without using a Math function
            bubbleSort(arr);
            // find the maximum difference in values. 
            int min = arr[arr.Length-1] - arr[0];            
            
            // Loop through array comparing each difference to value until the smallest difference is determined
            for (int i=0; i<arr.Length-1;i++)
            {
                // if only one pair meets the minimum difference criteria, the length of the new array is overwritten to be 2
                if ((arr[i + 1] - arr[i]) < min)
                {
                    min = arr[i + 1] - arr[i];
                    count = 2;
                }
                // if difference already equals the minimum, add 2 spaces to the length of the new array
                else if((arr[i + 1] - arr[i]) == min)
                {
                    count += 2;
                }
            }

            // instantiate a new array with the length determined in previous for loop
            int[] newArray = new int[count];
            int k = 0;
            // loop through adding the pairs that meet the minimum value to the new array
            for (int j = 0; j < arr.Length - 1; j++)
            {
                if ((arr[j+1]-arr[j]) == min)
                {
                    newArray[k] = arr[j];
                    newArray[k + 1] = arr[j + 1];
                    k += 2;
                }
            }

            return newArray;
        }

        // dayOfProgrammer takes any year and determines what the 256th day of the year was/will be in Russia
        static string dayOfProgrammer(int year)
        {
            int programmingDay = 256;
            // Calculate all days from January through August not including February
            int normDays = 243;
            // The programming day is always in September so calculate how many days into September the day is on a normal non leap year
            int septDays = programmingDay - normDays;

            // determine whether the year is a Julian Leap year, a Gregorian Leap year or the Transition year
            bool isJulianLeap = year >= 1700 && year <= 1917 && year % 4 == 0;
            bool isGregLeap = (year >1918 && year%400 ==0) || (year % 4 == 0 && year % 100 != 0);
            bool isTransitionYear = year == 1918;

            // subtract one day if it is a leap year
            if (isJulianLeap || isGregLeap)
            {
                septDays -= 1;
            }
            // add 14 days for the transition year
            else if (isTransitionYear)
            {
                septDays += 14;
            }

            return septDays + ".09." + year;
        }

        //bubbleSort takes an array of integers and sorts them from least to greatest
        static void bubbleSort(int[] array)
        {
            if (array == null)
            {
                return;
            }
            int n = array.Length;
            do
            {
                int nextN = 0;
                for (int i = 1; i < n; i++)
                {
                    if (array[i - 1] > array[i])
                    {
                        int temp=array[i - 1];
                        array[i-1] = array[i];
                        array[i] = temp;
                        nextN = i;
                    }
                }
                n = nextN;
            } while (n>1);            
        }
    }
}
