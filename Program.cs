using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjCalc
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //計算數字
            //不知道有幾組

            //1. 8 * num >= 100 && <1000
            //找出num的區間

            //2. num_1 * num >= 1000 && < 10000
            //調整num的區間

            //3. num_5 * num >= 100 && < 1000
            //調整num的區間

            List<int> num = new List<int>();
            List<int[]> num_num1_dic = new List<int[]>();
            List<int[]> num_num1_num2_dic = new List<int[]>();

            //百位數
            for (int i = 100; i < 1000; i++)
            {
                if (8 * i < 1000)
                {
                    num.Add(i);
                }
            }

            //第一次調整(個位數)
            for (int i = 9; i > 1; i--)
            {
                foreach (int item in num)
                {
                    if (i * item > 1000)
                    {
                        int[] tmp = new int[] { item, i };
                        num_num1_dic.Add(tmp);
                    }
                }
            }

            //第二次調整(萬位數)
            for (int j = 1; j < 10; j++)
            {
                foreach (var item in num_num1_dic)
                {
                    if (j * item[0] < 1000)
                    {
                        int[] tmp = new int[] { item[0], item[1], j };
                        num_num1_num2_dic.Add(tmp);
                    }
                }
            }

            num_num1_num2_dic.RemoveAll(item => item[0] *
                                       (item[1] + 800 + item[2] * 10000) < 10000000);

            //Console.WriteLine(num_num1_num2_dic.Count);
            Console.WriteLine(num_num1_num2_dic[0][0]);
            Console.WriteLine(num_num1_num2_dic[0][1]);
            Console.WriteLine(num_num1_num2_dic[0][2]);
        }
    }
}