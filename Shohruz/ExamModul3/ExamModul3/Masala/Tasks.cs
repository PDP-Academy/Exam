using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamModul3.Masala
{
    internal class Tasks
    {
        public void Task3(int[] nums, int target)
        {
            HashSet<int> set = new HashSet<int>();
            foreach (var item in nums)
            {
                set.Add(item);
            }

            int[] res = FindSub(set, target);
            foreach (var item in res)
            {
                Console.Write(item + ", ");
            }
        }
        private int[] FindSub(HashSet<int> set, int target)
        {
            List<int> list = new List<int>();
            foreach (var item in set)
            {
                if (item <= target)
                {     //return FindSub(set.Remove(item), target);
                    list.Add(item);
                    set.Remove(item);
                    list.AddRange(FindSub(set, target - item));
                    return list.ToArray();
                }
            }
            return list.ToArray();
        }
        //=============================
        public void Task1(int num)
        {
            if (num < 0)
                num = int.MaxValue + num + 1;
            string result = "";
            while (num > 0)
            {
                result = GetHex(num % 16) + result;
                num /= 16;
            }
            Console.WriteLine(result);

            char GetHex(int num)
            {
                switch (num)
                {
                    case 0: return '0'; break;
                    case 1: return '1'; break;
                    case 2: return '2'; break;
                    case 3: return '3'; break;
                    case 4: return '4'; break;
                    case 5: return '5'; break;
                    case 6: return '6'; break;
                    case 7: return '7'; break;
                    case 8: return '8'; break;
                    case 9: return '9'; break;
                    case 10: return 'a'; break;
                    case 11: return 'b'; break;
                    case 12: return 'c'; break;
                    case 13: return 'd'; break;
                    case 14: return 'e'; break;
                    case 15: return 'f'; break;
                    default: return '\0';
                }
            }

        }
        //=============================
        public void Task2(string num1, string num2)
        {
            string result = "";
            int d = 0;
            int n = 0, m = 0;
            for (int i = 0; i < num1.Length+1 || i < num2.Length+1; i++)
            {
                if (i < num1.Length)
                {
                    n = int.Parse(num1[num1.Length - i - 1].ToString());
                }
                if (i < num2.Length)
                {
                    m = int.Parse(num2[num2.Length - i - 1].ToString());
                }
                result = ((n + m + d) % 10) + result;
                d = (n + m) / 10;
                m = 0;
                n = 0;
            }
            Console.WriteLine(result);
        }

    }

}
