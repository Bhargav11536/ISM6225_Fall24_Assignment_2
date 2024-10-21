using System;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 42;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 121;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 4;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers in Array
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            try
            {
                // Write your code here

                // Setting up the hash set to monitor the array's numbers
                HashSet<int> presentNumbers = new HashSet<int>();
                 
                // creating list in order to hold the numbers that are missing
                List<int> absentNumbers = new List<int>();

                // Iterating through the array and add each number to the HashSet
                foreach (var num in nums)
                {
                    presentNumbers.Add(num);
                }

                // Iterating over the integers 1 through the array's length
                for (int i = 1; i <= nums.Length; i++)
                {
                    // Verifying whether the number is absent from the HashSet
                    if (!presentNumbers.Contains(i))
                    {
                        // Adding missing number to the list
                        absentNumbers.Add(i);
                    }
                }
                // Returning the list of missing numbers
                return absentNumbers;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 2: Sort Array by Parity
        public static int[] SortArrayByParity(int[] nums)
        {
            try
            {
                // Write your code here

                // Putting sorted elements in a new array
                int[] rearranged = new int[nums.Length];

                // Advice on how to arrange odd and even elements
                int startPointer = 0, endPointer = nums.Length - 1;

                // Iterating over each element in the input array
                foreach (var num in nums)
                {
                    if (num % 2 == 0)  // Checking if the number is even
                    {
                        rearranged[startPointer++] = num;  // Putting even numbers at the array's beginning
                    }
                    else
                    {
                        rearranged[endPointer--] = num;  // Placing odd numbers at the end of the array
                    }
                }
                // Returning the array with elements that are sorted by parity
                return rearranged;  // Placeholder
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 3: Two Sum
        public static int[] TwoSum(int[] nums, int target)
        {
            try
            {
                // Write your code here

                // creating dictionary to map each number to its index
                Dictionary<int, int> complementMap = new Dictionary<int, int>();

                // Iterating through the array with index
                for (int index = 0; index < nums.Length; index++)
                {
                    // Calculating the complement of the current number with respect to the target
                    int needed = target - nums[index];

                    // Checking if the complement is already in the dictionary
                    if (complementMap.ContainsKey(needed))
                    {
                        // Returning the indices of the current number and its complement
                        return new int[] { complementMap[needed], index };
                    }

                    // Adding the current number and its index to the dictionary if not already present
                    if (!complementMap.ContainsKey(nums[index]))
                    {
                        complementMap[nums[index]] = index;
                    }
                }
                // Returning an empty array if no two numbers add up to the target
                return new int[] { }; // Placeholder
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
        {
            try
            {
                // Write your code here

                // To create a product, make sure the array has at least three numbers.
                if (nums.Length < 3)
                {
                    throw new ArgumentException("Input array must contain at least three elements.");
                }

                // Sorting the array to easily find the largest and smallest numbers
                Array.Sort(nums);

                // Get the total number of elements in the array
                int length = nums.Length;

                // Compare the product of the three greatest numbers to determine the maximum product.
                // and the product of the two smallest and the largest (to handle negatives)
                return Math.Max(nums[length - 1] * nums[length - 2] * nums[length - 3], nums[0] * nums[1] * nums[length - 1]);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber)
        {
            try
            {
                // Write your code here

                // Verify whether the input number is negative, as basic conversion does not handle this.
                if (decimalNumber < 0)
                {
                    throw new ArgumentException("Negative number provided.");
                }

                // Using the built-in function to convert the non-negative integer to a binary string.
                return Convert.ToString(decimalNumber, 2);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums)
        {
            try
            {
                // Write your code here

                // Beginning a binary search to find the rotation point
                int left = 0, right = nums.Length - 1;

                // Keep reducing until the smallest component is separated.
                while (left < right)
                {
                    int mid = left + (right - left) / 2;

                    // Check to see if the middle number is higher than the right number.
                    if (nums[mid] > nums[right])
                    {
                        left = mid + 1; // The minimum must be on the right.
                    }
                    else
                    {
                        right = mid;  // Minimum is at mid or to the left
                    }
                }

                // The left should point to the minimum element once the loop has been broken.
                return nums[left];
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            try
            {
                // Write your code here

                // Negative numbers are not palindromes
                if (x < 0) return false;

                // Store the original number to compare it later
                int reversed = 0, temp = x;

                // Reversing the digits of the number
                while (x != 0)
                {
                    reversed = reversed * 10 + x % 10;

                    x /= 10;
                }
                // Verifying that the original and reversed numbers match.
                return temp == reversed;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
        {
            try
            {
                // Write your code here

                // Validate that input is non-negative
                if (n < 0) throw new ArgumentException("Fibonacci position cannot be negative.");

                // Handle the base cases
                if (n <= 1) return n;

                // Initializing the first two Fibonacci numbers
                int prev = 0, next = 1;

               // The nth Fibonacci number can be calculated iteratively.
                for (int i = 2; i <= n; i++)
                {
                    int c = prev + next;  // Compute the next Fibonacci number

                    prev = next;   // Update a to the next number in the sequence

                    next = c;   // Update b to the next number in the sequence
                }
                return next;   // Return the nth Fibonacci number

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
