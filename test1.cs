using System;
class test1
{
    public static void Main()
    {
        // 出力
        Console.WriteLine("helloworld");

        // 変数, 演算子
        String str1, str2, str3;
        String num_str, judge_str;
        int num1, num2, num3;
        double num_double;
        bool judge1;

        str1 = "hello";
        str2 = "world";
        str3 = str1 + str2;

        num1 = 5;
        num2 = 10;
        num3 = num1 - num2;
        num3++;
        num3 = num3 * num3;
        num_double = num3 * 0.1;

        judge1 = num1 > num2;

        var str = str3;
        var num = num_double;
        var boolean = judge1;
        judge_str = boolean.ToString();

        num_str = num.ToString();
        String[] array_str = {str, num_str, judge_str};

        Console.WriteLine(array_str[0] + array_str[1] + array_str[2]);

        String null_str = null;
        null_str = null_str?.Trim();
        int? null_int = null;
        Object[] nullArray = new Object[2];
        nullArray[0] = null_str;
        nullArray[1] = null_int;
    }
} 