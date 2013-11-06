using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            //C_calculator calc = new C_calculator();
            C_sharp_calculator calc = new C_sharp_calculator();
            //calc.テスト();

            Console.Write(">");

            while (true)
            {
                string 文字 = Console.ReadLine();
                
                if (文字[0] == 'q')
                {
                    break;
                }

                string 結果 = calc.ユーザ入力(文字) ;
                if (結果.Length > 0)
                {
                    Console.WriteLine(結果);
                }


                Console.Write(">");
            }
        }
    }
}
