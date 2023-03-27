using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallByReference_01
{
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int a = 5;
            Console.WriteLine("a = " + a.ToString());
            /*將變數 a 的"記憶體位置"丟進 ref_add 的 method 中。*/
            ref_add(ref a);
            Console.WriteLine("a = " + a.ToString());
            Console.ReadKey();
        }

        /// <summary>
        /// -> 為什麼 ref_add() 需要加上 static ?
        /// <- 在 C# 中，靜態成員是屬於類別而非物件的成員。
        ///    這意味著如果您想在類別層級上共享一個變數，您需要使用 static 關鍵字來聲明該變數。
        ///    這樣做可以確保所有類別的物件共享同一個變數，而不是每個物件都擁有自己的變數。
        /// </summary>
        /// <param name="b"></param>
        static void ref_add(ref int b)
        {
            /*將記憶體位置丟進變數 b 中，因此如果變數 b 有做改變，就會連同影響丟進來的引數*/
            b += 5;
        }
    }
}
