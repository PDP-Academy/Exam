//2-task
class main
{
    static void Main(string[] args)
    {
        string num1 = "", num2 = "";
        Console.WriteLine("Enter numbers :");
        Console.WriteLine("1-number :");
        num1 = Console.ReadLine()!;
        Console.WriteLine("2-number :");
        num2 = Console.ReadLine()!;
        IsLengthEqual(ref num1, ref num2);

        int qoldiq = 0;
        string sum = "";
        if (num1 == num2 && num1 == "0") sum = "0";

        for (int i = num1.Length-1; i >= 0; i--)
        {
            string str = "";
            int k = int.Parse(Add(num1[i].ToString(), num2[i].ToString()));
            if(k > 0)
            {
                k += qoldiq;
                qoldiq = k / 10;
                str =(k % 10).ToString();
            }
            sum = str + sum; 
        }
        string result = sum;
        if (qoldiq > 0)
        {
            result = qoldiq.ToString() + sum;
        }
        
        Console.WriteLine("Result : " + result);
       
    }
    public static string Add(string a, string b)
    {
        int sum = 0;

        sum = Convert.ToInt32(a) + Convert.ToInt32(b);

        return sum.ToString();
    }

    public static void IsLengthEqual(ref string a,ref string b)
    {
        int k = 0;
        if(a.Length > b.Length)
        {

           
            for(int i = 0; i <= a.Length - b.Length; i++)
            {
                b = "0" + b;
            }
        }
        else if(a.Length < b.Length)
        {
            
            for (int i = 0; i <= b.Length - a.Length; i++)
            {
                a = "0" + a;

            }
        }
        
    }
}