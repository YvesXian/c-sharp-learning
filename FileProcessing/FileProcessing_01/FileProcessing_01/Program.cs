using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileProcessing_01
{
    class Program
    {
        bool result = true;
        DirectoryInfo di;
        static void Main(string[] args)
        {
            string cmd = null;
            Program p = new Program();
            while (true)
            {
                try
                {
                    /* Console.Read(): 此方法只會讀取一個字符並返回其 ASCII 編碼的整數值。
                       Console.ReadLine(): 此方法則讀取整行的輸入，直到用戶輸入換行字元(Enter) 為止。*/
                    Console.WriteLine("Please input one of command line: 'create' 'delete' 'enum' 'move'");
                    Console.Write("cmd: ");
                    cmd = Console.ReadLine().ToString();
                    Console.WriteLine("cmd: " + cmd.ToString());

                    if (cmd == "create")
                        p.result = p.createPath();
                    else if (cmd == "delete")
                        p.result = p.deletePath();
                    else if (cmd == "enum")
                        p.result = p.Enum();
                    else if (cmd == "move")
                        p.result = p.move();
                    else if (cmd == "end")
                        Environment.Exit(0);
                    else
                    {
                        p.result = false;
                        Console.WriteLine("no command, please check it! ");
                    }
                }
                catch (IOException e)
                {
                    TextWriter errorWriter = Console.Error;
                    errorWriter.WriteLine(e.Message);
                }
                finally
                {
                    Console.WriteLine("result: " + p.result.ToString());
                    Console.ReadKey();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        private bool createPath()
        {
            string strPath = "MyDir\\SubDir";

            try
            {
                if (Directory.Exists(strPath))
                {
                    Console.WriteLine("目錄已存在");
                }

                di = Directory.CreateDirectory(strPath);
                Console.WriteLine("建立目錄已完成");

                return true;
            }
            catch (IOException ex)
            {
                Console.WriteLine("建立目錄錯誤");
                Console.WriteLine("錯誤訊息: " + ex.ToString());
                Console.ReadKey();

                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool deletePath()
        {
            string strPath = "MyDir\\SubDir";

            try
            {
                if (!Directory.Exists(strPath))
                {
                    Console.WriteLine("目錄不存在");
                }
                Directory.Delete(strPath);
                Console.WriteLine("完成刪除目錄");

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("無法刪除目錄");
                Console.WriteLine("錯誤訊息: " + ex.ToString());
                Console.ReadKey();

                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool Enum()
        {
            string strPath = @"..\..\";
            List<string> dirs;

            try
            {
                /* EnumerateDirectories 方法會返回指定目錄中的所有子目錄的可枚舉集合
                   第二個參數 *.* 指定了要返回的子目錄的篩選條件，這裡代表返回所有的子目錄，不做篩選
                   第三個參數 SearchOption.AllDirectories 指定了要搜索的範圍，這裡代表搜索所有子目錄*/
                dirs = new List<string>(
                    Directory.EnumerateDirectories(strPath, "*.*", SearchOption.AllDirectories));
            }
            catch (Exception ex)
            {
                Console.WriteLine("無法列舉清單");
                Console.WriteLine("錯誤訊息: " + ex.ToString());
                Console.ReadKey();
                return false;
            }

            foreach (var item in dirs)
                Console.WriteLine(item.ToString() + "\r\n");

            return true;
        }

        private bool move()
        {
            /* 這段程式碼使用 DirectoryInfo 類別創建一個目錄物件，指定目錄名稱為 "SourceDir"，
             * 該目錄物件可以用來操作目錄。*/
            DirectoryInfo di = new DirectoryInfo("SourceDir");

            if (!di.Exists)
            {
                di.Create();
                /* !!! 為什麼還要用一個 dis 變數去接?*/
                DirectoryInfo dis = di.CreateSubdirectory("SubDir");
                Console.WriteLine("建立目錄 Source 與目錄 SubDir 成功");
            }
            else
            {
                Console.WriteLine("目錄已存在");
                return false;
            }


            if (!Directory.Exists("..\\TempDir"))
            {
                di.MoveTo("..\\TempDir");
                Console.WriteLine("移動目錄成功");
            }
            else
            {
                Console.WriteLine("目錄已存在");
                return false;
            }

            return true;
        }
    }
}
