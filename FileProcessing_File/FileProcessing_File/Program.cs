using System;
using System.Text;
using System.IO;

namespace FileProcessing_File
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 
             * @ 符號為是指示符號，可以用來指示字串中的特殊字符（例如換行符號 \n）
             * 應該被當作字串的一部分而不是轉譯為特殊字符。在 @ 符號的字串中，反斜線 \ 
             * 不會被解釋為特殊符號，而是當作普通字符處理。
             */
            string strFileName = @"test1.txt";
            string[] strWrite = { "12345", "67890" };
            string[] strRead;

            // 寫入資料
            try
            {
                /* 在 strFileName 檔案中寫入 strWrite 的內容*/
                File.AppendAllLines(strFileName, strWrite);
                Console.WriteLine("寫入資料成功！");
            }
            catch (Exception ex)
            {
                Console.WriteLine("寫入資料錯誤");
            }

            // 讀取資料
            try
            {
                strRead = File.ReadAllLines(strFileName);
                Console.WriteLine("讀取資料成功！");
                foreach (var item in strRead)
                    Console.WriteLine(item);
            }
            catch(Exception ex)
            {
                Console.WriteLine("讀取資料錯誤");
            }

            strFileName = "test2.txt";
            FileStream fs = null;
            string str = "File Open";

            // 開啟檔案
            try
            {
                /* 
                 * 在指定路徑上以指定模式和存取來開啟
                 * strFileName: 欲開啟的檔案
                 * FileMode.Create: 若檔案不存在，則會創建。 若存在，則會覆寫。
                 * FileAccess.Write: 擁有寫入的權限
                 */
                fs = File.Open(strFileName, FileMode.Create, FileAccess.Write);
                Console.WriteLine("開啟檔案。");
                fs.Write(Encoding.UTF8.GetBytes(str), 0, str.Length);
                Console.WriteLine("寫入資料。");
            }
            catch (Exception ex)
            {
                Console.WriteLine("發生錯誤。");
            }

            // 使用 Create 方法建立檔案並寫入資料
            fs = null;
            str = "File.Create";

            fs = File.Create("test3.txt", 256, FileOptions.SequentialScan);
            fs.Write(Encoding.UTF8.GetBytes(str), 0, str.Length);
            fs.Close();
            Console.WriteLine("建立檔案並寫入檔案成功");

            // 檔案拷貝
            string strSource = "test1.txt";
            string strTarget = "copy.txt";

            if (!File.Exists(strSource))
                Console.WriteLine("檔案不存在，無法進行拷貝");
            try
            {
                File.Copy(strSource, strTarget);
                if (File.Exists(strTarget))
                    Console.WriteLine("檔案拷貝成功");
            }
            catch (Exception ex)
            {
                Console.WriteLine("檔案拷貝失敗");
            }

            // 刪除檔案
            string strDelete = "copy.txt";

            if (!File.Exists(strDelete))
                Console.WriteLine("檔案不存在");
            else
            {
                try
                {
                    File.Delete(strDelete);
                    if (!File.Exists(strDelete))
                        Console.WriteLine("刪除檔案成功");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("無法刪除檔案");
                }
            }

            // 移動檔案
            strSource = "test1.txt";
            strTarget = "..\\move.txt";

            if (!File.Exists(strSource))
                Console.WriteLine("檔案不存在");
            else
            {
                try
                {
                    File.Move(strSource, strTarget);
                    if (File.Exists(strTarget))
                        Console.WriteLine("檔案移動成功");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("檔案已存在，或檔案無法移動");
                }
            }

            Console.ReadKey();
        }
    }
}
