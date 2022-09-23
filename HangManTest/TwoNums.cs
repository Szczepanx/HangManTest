using System;
namespace HangManTest
{
    public class TwoNums
    {
        public static int[] TwoSum(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if ((nums[i] + nums[j]) == target)
                    {
                        return new int[] { i, j };
                    }
                }
            }
            return null;
        }


        static void Main(string[] args)
        {
            int[] nums = { 2, 7, 11, 15 };
            int target = 9;

            int[] sums = TwoSum(nums, target);

            foreach (int a in TwoSum(nums, target))
            {
                Console.Write(" " + a);
            }
            Console.Write("\n");

            int[] nums1 = { 3, 2, 4 };
            target = 6;

            foreach (int a in TwoSum(nums1, target))
            {
                Console.Write(" " + a);
            }
            Console.Write("\n");




        }
    }
}

