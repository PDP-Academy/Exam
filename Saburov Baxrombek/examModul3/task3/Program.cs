
Console.Write("Target :");
int target = int.Parse(Console.ReadLine()!);
int[] mas = { 1,4,4};
Console.WriteLine("Result : " + MinimalLength(mas, target));
Console.WriteLine();

int MinimalLength(int[] a, int target)
{
    if (a == null || a.Length == 0)
        return 0;

    int i = 0, j = 0, sum = 0, min = Int32.MaxValue;

    while (j < a.Length)
    {

        sum += a[j];
        j++;
        while (sum >= target)
        {
            min = Math.Min(min, j - i);
            sum -= a[i];
            i++;
        }
    }
    return min == Int32.MaxValue ? 0 : min;
}