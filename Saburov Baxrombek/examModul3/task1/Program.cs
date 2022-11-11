class main
{
    static void Main(string[] args)
    {
        Dictionary<int, string> map = new Dictionary<int, string>()
        {
            {1, "1" },
            {2, "2"},
            {3, "3"},
            {4, "4"},
            {5, "5"},
            {6, "6"},
            {7, "7"},
            {8, "8"},
            {9, "9"},
            {10, "a"},
            {11, "b"},
            {12, "c"},
            {13, "d"},
            {14, "e"},
            {15, "f"}
        };
        Console.WriteLine("num =");
        int num = int.Parse(Console.ReadLine()!);
        string result = "";
        int k = 0;
        if(num <= 15)
        {
            Console.WriteLine(map[num]);
        }else
             while (num > 15)
            {
                k = num % 16;
                result += map[k];
                num /= 16;
            }

        result += num.ToString();
        Console.WriteLine(Reverse(result));
           
    }

    public static string Reverse(string str)
    {
        string res = "";
        for (int i = str.Length - 1; i>= 0; i--)
        {
            res += str[i];
        }
        return res;
    }
}