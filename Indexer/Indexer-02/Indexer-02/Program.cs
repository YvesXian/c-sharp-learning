using System;

/// <summary>
/// 多個索引子的練習
/// </summary>
namespace Indexer_02
{
    /// <summary>
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int num = 5;
            int index;
            string str;

            int[] score = { 80, 92, 67, 40, 76 };
            string[] name = { "王一", "王二", "王三", "王四", "王八" };

            MyClass myClass = new MyClass(num);

            for (int b = 0; b < num; b++)
                myClass.Add(b, name[b], score[b]);

            Console.Write("請輸入編號1~5: ");
            index = int.Parse(Console.ReadLine()) - 1;

            if (index < 0 || index >= num)
            {
                Console.WriteLine("無此編號");
                return;
            }

            str = myClass[index];
            Console.WriteLine(str + " 的分數 = " + myClass[str].ToString());

            Console.ReadKey();
        }
    }

    /// <summary>
    /// MyClass 最多容納5位學生, 並且記錄分數與姓名
    /// </summary>
    class MyClass
    {
        int[] score;
        string[] name;

        /// <summary>
        /// MyClass 的建構子, 最多5位學生, 並且紀錄姓名與分數
        /// </summary>
        /// <param name="num"></param>
        public MyClass(int num)
        {
            num = (num <= 5) ? 5 : num;
            score = new int[num];
            name = new string[num];
        }

        /// <summary>
        /// 把人物與分數相互對應
        /// </summary>
        /// <param name="i"></param>
        /// <param name="str"></param>
        /// <param name="scr"></param>
        public void Add(int i, string str, int scr)
        {
            if (i < 0 || i > score.Length - 1)
                return;
            name[i] = str;
            score[i] = scr;
        }

        /// <summary>
        /// 第1個索引子, 用於回傳姓名
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public string this[int i]
        {
            get
            {
                if (i < 0 || i > name.Length - 1)
                    return "";
                else
                {
                    return name[i];
                }
            }
        }

        /// <summary>
        /// 第二個索引子, 用於回傳分數
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public int this[string str]
        {
            get
            {
                for (int b = 0; b < name.Length; b++)
                {
                    if (str.Equals(name[b]))
                        return score[b];
                }

                return -1;
            }
        }
    }
}
