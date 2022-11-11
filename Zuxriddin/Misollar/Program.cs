using System.Data.Common;

namespace Misollar;

internal class Program
{
    static void Main(string[] args)
    {
        // 1 - misoll

        //int num = -2;
        //int num1 = 26;
        //Console.WriteLine(Misol1(num));
        //Console.WriteLine(Misol1(num1));
        

        // 2 - misoll 
        
        string num1 = "1334";
        string num2 = "99";
        Console.WriteLine(Misol2(num1,num2) + " result");

        // 3 - misol
        //int[] nums = { 2, 3, 1, 2, 4, 3 };
        //Console.WriteLine( Misol3(7,nums));

    }
    static string Misol1(int num)
    {
        string str = "";
        str = Convert.ToString(num, 16);
        return str;
    }

    static string Misol2(string num1,string num2)
    {
        string Result = "";
        int num; 
        int i = num1.Length - 1;
        int j = num2.Length - 1;
        int qoldiq = 0;
        while(i >= 0 && j >= 0)
        {
            num = int.Parse(num1[i].ToString()) + int.Parse(num2[j].ToString()) + qoldiq;
            qoldiq = 0;
            if (num > 10)
            {
                qoldiq = 1;
                num = num - 10;
            }
            Console.WriteLine(qoldiq + "qoldiq");
            i--;
            j--;
            Result = num + Result;
            Console.WriteLine( num + " num ");            
            Console.WriteLine( Result + " result ");            
        }
        while(i >= 0 )
        {
            num = int.Parse(num1[i].ToString()) + qoldiq;
            qoldiq = 0;
            i--;
            Result = num + Result ;
        }
        while (j >= 0)
        {
            num = int.Parse(num2[j].ToString()) + qoldiq;
            qoldiq = 0;
            j--;
            Result = num + Result;
        }

        return Result;
    }

    static int Misol3(int target, int[] nums)
    {

        return target;
    }

}