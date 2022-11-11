using System.Reflection.Metadata.Ecma335;

namespace ImtihonTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int[] arr = { 1,4,4};
            //int target = 4;

            //Console.WriteLine(Fun3(arr, target));


            //string num1 = "123456789";
            //string num2 = "456789";

            //Console.WriteLine(Fun2(num1, num2));
        }





        public static string Fun2(string nums1, string nums2)
        {
            int res = 0;
            string result = "";
            int q = 0;

            int index1 = nums1.Length - 1;
            int index2 = nums2.Length - 1;

            while (index1 >= 0 && index2 >= 0)
            {
                res = nums1[index1--] - '0' + nums2[index2--] - '0' + q;

                if (res >= 10)
                {
                    result = $"{res - 10}" + result;
                    q = 1;
                }
                else
                {
                    result = $"{res}" + result;
                    q = 0;
                }
            }
            while (index1 >= 0)
            {
                res = nums1[index1--] - '0' + q;

                if (res >= 10)
                {
                    result = $"{res - 10 }" + result;
                    q = 1;
                }
                else
                {
                    result = $"{res}" + result;
                    q = 0;
                }
            }
            while (index2 >= 0)
            {
                res = nums2[index2--] - '0' + q;

                if (res >= 10)
                {
                    result = $"{res - 10}" + result;
                    q = 1;
                }
                else
                {
                    result = $"{res}" + result;
                    q = 0;
                }
            }
            return result;
        }


















        public static int Fun3(int[] nums, int target)
        {
            int next = 0;
            int prev = 0;

            int min = int.MaxValue;

            int sum = 0;

            while (next < nums.Length && prev < nums.Length)
            {
                if (sum < target)
                    sum += nums[next++];

                else if (sum == target)
                {
                    min = Math.Min(min, next - prev);
                    sum += nums[next++];
                    sum -= nums[prev++];
                }
                else
                    sum -= nums[prev++];

            }
            while (prev < nums.Length && sum >= target)
            {
                if (sum == target)
                {
                    min = Math.Min(min, next - prev);
                    break;
                }
                else
                    sum -= nums[prev++];
            }

            if (min == int.MaxValue)
                return 0;
            return min;
        }
    }
}