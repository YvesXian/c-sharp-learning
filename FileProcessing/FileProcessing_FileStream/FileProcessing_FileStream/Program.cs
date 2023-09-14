using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileProcessing_FileStream
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 示範建立 FileStream 物件與使用 Write() 方法*/
            FileStream fs;
            string data = "fijrforijlkjldjflkdjf";

            if (File.Exists("test.txt"))
                File.Delete("test.txt");

            try
            {
                // 將資料流給 fs
                using (fs = new FileStream("test.txt", FileMode.Create, FileAccess.Write))
                {
                    // 對 test.txt 寫入資料
                    // Encoding.Default.GetBytes(data): 寫入的資料
                    // 0: array 中以零起始的位元組位移，要從其中開始將位元組複製至資料流。
                    // data.Length: 寫入的長度
                    fs.Write(Encoding.Default.GetBytes(data), 0, data.Length);
                    Console.WriteLine("資料寫入完畢");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());  
            }

            Console.WriteLine("---------------------------------------");

            /* */
        }
    }
}
