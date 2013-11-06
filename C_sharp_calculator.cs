﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication2
{
    public class C_sharp_calculator
    {
        int 第一項 = 0;
        char 演算子;
        int 第二項 = 0;

        // 次に呼び出すメソッドを指定するデリゲート
        delegate string dlg次の呼び出し(string 文字); 
        dlg次の呼び出し 次の呼び出し;

        Dictionary<dlg次の呼び出し, dlg次の呼び出し> 呼び出し辞書 = new Dictionary<dlg次の呼び出し, dlg次の呼び出し>();

        // 演算をするために、連想配列とラムダ式による計算を紐付ける
        Dictionary<char, Func<int, int, int>> 演算辞書 = new Dictionary<char, Func<int, int, int>>()
        {
                {'+' , (x, y) => x + y },
                {'-' , (x, y) => x - y },
                {'*',  (x, y) => x * y },
                {'/',  (x, y) => x / y } 
        };

        public 新電卓クラス()
        {
            // 第一項入力 =>  演算子入力 => 第二項入力 => 第一項入力と
            // 繰り返しになるようにするために呼び出す順番を設定 
            次の呼び出し = 第一項入力;
            呼び出し辞書[第一項入力] = 演算子入力;
            呼び出し辞書[演算子入力] = 第二項入力;
            呼び出し辞書[第二項入力] = 第一項入力;
        }

        public string ユーザ入力(string 文字)
        {
            try
            {
                string ret = 次の呼び出し(文字);
                次の呼び出し = 呼び出し辞書[次の呼び出し];
                return ret;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private string 第一項入力(string 文字)
        {
            第一項 = 数字チェック(文字);
            return "";
        }

        private string 演算子入力(string 文字)
        {
            演算子チェック(文字);
            演算子 = 文字.Trim()[0];
            return "";
        }

        private string 第二項入力(string 文字)
        {
            第二項 = 数字チェック(文字);

            if (演算子 == '/' && 第二項 == 0)
            {
                throw new Exception("0で割り算はできません");
            }

            int 結果 = 演算辞書[演算子](第一項, 第二項);
            return 結果.ToString();
        }

        private int 演算子チェック(string 文字)
        {
            if (文字.Length != 1)
            {
                throw new Exception("文字列の長さが1ではありません");
            }
            if (演算辞書.ContainsKey(文字[0]))
            {
               return 1;// 何も返さなくても良いがインターフェイスを揃えるため
            }

            throw new Exception("有効な演算子[+|-|*|/]ではありません");           
        }

        private int 数字チェック(string 文字)
        {
            int 整数;
            if (int.TryParse(文字, out 整数))
            {
                return 整数;
            }

            throw new Exception("数字入力エラー[0-9]");
        }
    }
}
