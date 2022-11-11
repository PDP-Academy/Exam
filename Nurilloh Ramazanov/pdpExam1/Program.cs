using System;
namespace algoritm;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(MinimalLength(new int[] { 1,1,1,1,1,1,1,1,1,1 }, 11));
        Console.WriteLine(SumTwoNumbersAsString("11", "123"));
        Console.ReadLine();
    }

    static string Hexadecimal(int num)
    {



        return "fffffff";
    }


    static string SumTwoNumbersAsString(string num1, string num2)
    {
        if (num1 == "0" && num2 == "0")
            return "0";
        string res = "";
        int num1Length = num1.Length-1;
        int num2Length = num2.Length-1;
        string result = "";
        string point = "";
        //11 123
        while(num1Length > -1 || num2Length > -1)
        {
            if(num1Length == -1)
            {
                res = (('0' - '0') + (num2[num2Length--] - '0').ToString());
            }
            else if(num2Length == -1)
            {
                res = ((char)(num1[num1Length--] - '0') + (char)('0' - '0')).ToString();
            }
            else
            {
                res = ( (char)(num1[num1Length--] - '0') + (char)(num2[num2Length--] - '0')).ToString();
            }

            
            
            if(res.Length > 1)
            {
                if (point.Length > 0)
                {
                    res = res[0] + ((char)res[1] - '0' + point[0] - '0').ToString();
                    point = "";
                }
                point = ( (char)res[0] - '0').ToString();
                res = res.Substring(1);
            }
            else
            {
                res = ((char)res[0] - '0' + (char)point[0] - '0').ToString();
            }
            
            result = res + result;
            

        }
        return result;
    }

    static int MinimalLength(int[] arr, int target)
    {
        int count = 0;
        int result = 0;
        int res = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            res += arr[i];
            count++;
            if (res == target)
            {
                result = count;
                count = 0;
                res = 0;
            }
            if(res > target)
            {
                res = 0;
                count = 0;
            }     
        }

        return result;
    }
}