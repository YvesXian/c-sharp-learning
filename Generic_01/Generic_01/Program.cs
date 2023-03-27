using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_01
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> intList = new List<int>() { 1, 2, 3, 4, 5 };
            List<double> doubleList = new List<double>() { 1.1, 2.2, 3.3, 4.4, 5.5 };

            Console.WriteLine($"Sum of intList: {SumList(intList)}");
            Console.WriteLine($"Sum of doubleList: {SumList(doubleList)}");
            Console.ReadKey();
        }

        static T SumList<T>(List<T> list)
        {
            /*dynamic:
             * 是 C# 中的一種型別，表示在執行期間可以動態決定型別。
             * 
             * default(T):
             * 會依據 T 的型別而定，例如若 T 為 int 型別，則 default(T) 會是 0，
             * 若 T 為 string 型別，則 default(T) 會是 null。*/
            dynamic sum = default(T);
            foreach (T item in list)
            {
                sum += item;
            }
            return sum;
        }
    }
}
