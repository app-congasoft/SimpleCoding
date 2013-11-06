using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication2
{
    public class C_calculator
    {
        int カウント = 0;
        int 入力1 = 0;
        int 入力2 = 0;
        char 演算記号;

        public void テスト()
        {
            int length = 9;
            for (int i = 0; i <= length; i++)
            {
                Console.WriteLine(数字チェック(i.ToString()));
            }

            char[] 文字列 = { '+', '-', '*', '/', 'a' };
            foreach (var c in 文字列)
            {
                Console.WriteLine(演算記号チェック(c.ToString()));
            }
        }

        public string 演算式入力(string 文字)
        {
            switch (カウント)
            {
                case 0:
                    入力1 = 数字チェック(文字);
                    //Console.WriteLine(入力1);
                    if (入力1 < 0)
                    {
                        return "数字入力エラー[0-9]";
                    }
                    カウント++;
                    break;
                case 1:
                    int エラーチェック = 演算記号チェック(文字);
                    //Console.WriteLine(文字);
                    if (エラーチェック < 0)
                    {
                        return "演算子エラー[+|-|*|/]";
                    }
                    演算記号 = 文字.Trim()[0];
                    カウント++;
                    break;

                case 2:
                    入力2 = 数字チェック(文字);
                    //Console.WriteLine(入力1);
                    if (入力2 < 0 || (演算記号 == '/' && 入力2 == 0 ) )
                    {
                        return "数字入力エラー[0-9]";
                    }

                    int 結果 = 計算(入力1, 演算記号,  入力2);
                    カウント = 0;
                    return 結果.ToString();

            }
            return "";
        }

        private int 計算(int 第一項, char 演算子, int 第二項)
        {
            int result = 0;

            switch (演算子)
            {
                case '+':
                    result = 第一項 + 第二項;
                    break;
                case '-':
                    result = 第一項 - 第二項;
                    break;
                case '*':
                    result = 第一項 * 第二項;
                    break;
                case '/':
                    result = 第一項 / 第二項;
                    break;
            }

            return result;
        }
 
        public int 演算記号チェック(string 文字)
        {
            if( 文字.Length != 1 )
            {
                return -1;
            }
            if (文字[0] == '+' || 文字[0] == '-' || 文字[0] == '*' || 文字[0] == '/')
            {
                return 1;
            }

            return -1;
        }

        public int 数字チェック(string 文字)
        {
            int 整数;
            if (int.TryParse(文字, out 整数))
            {
                return 整数;
            }

            return -1;
        }
    }
}
