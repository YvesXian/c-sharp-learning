using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FileProcessing_FileInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            FileInfo fi;
            List<FileInfo> strList;
            DirectoryInfo di;

            /* 示範屬性 Exits、Directory 的用法*/
            fi = new FileInfo("FileProcessing_FileInfo.exe");
            if (fi.Exists)
                Console.WriteLine("檔案存在");
            else
                Console.WriteLine("檔案不存在");

            Console.WriteLine("目前的路徑: " + fi.DirectoryName);

            di = fi.Directory;
            // 傳回目前目錄中檔案可列舉的集合。
            strList = new List<FileInfo>(di.EnumerateFiles());
            Console.WriteLine("==================");
            Console.WriteLine("目錄下的檔案: ");

            foreach (var item in strList)
                Console.WriteLine(item.Name);

            Console.WriteLine("---------------------------------");

            /* 示範如何取得檔案大小*/
            Console.WriteLine("FileProcessing_FileInfo.exe 檔案長度 = " + fi.Length.ToString() + "bytes");

            Console.WriteLine("---------------------------------");

            /* 示範使用 CreateText() 方法快速建立文字檔案*/
            fi = new FileInfo("test1.txt");
            StreamWriter sw = null;
            string str;

            if (!fi.Exists)
            {
                // 如果檔案建立不成功，則會自動釋放所有已佔用的資源
                using (sw = fi.CreateText())
                {
                    // 將敘述寫入串流器中
                    sw.WriteLine("建立新檔");
                    Console.WriteLine("Create 'test1.txt' sucess !");
                }
                    
            }
            else
                Console.WriteLine("'test1.txt' is exist !");

            // 新增日期時間
            using (sw = fi.AppendText())
            {
                str = DateTime.Now.ToString();
                sw.WriteLine("標記時間: " + str);
            }

            Console.WriteLine("---------------------------------");

            /* 示範 Create() 方法、Open() 方法、檔案串流 FileStream 物件的 Write() 與 Read() 方法*/
            // FileStream 主要用於多種檔案操作，如寫入、讀取、刪除、複製等等
            fi = new FileInfo("test2.txt");
            str = "1234567890";
            FileStream fs;
            byte[] str1;

            if (fi.Exists)
                fi.Delete();

            using (fs = fi.Create())
            {
                fs.Write(Encoding.UTF8.GetBytes(str), 0, str.Length);
            }

            // 重新整理物件的狀態
            fi.Refresh();

            // fi.Open: 使用某種特定方式開啟檔案
            // 1. 為什麼要使用 FileStream 去接 FileInfo?
            //    FileInfo 只有提供取得檔案基本資訊的方法，如果要對"操作檔案內容"，則需要使用 FileStream
            using (fs = fi.Open(FileMode.Open, FileAccess.Read))
            {
                // 宣告一個 byte 陣列，其大小設為檔案 fi 的長度
                str1 = new byte[fi.Length];
                // 使用 FileStream 讀取 fi 的內容，將其存入 str1 中
                fs.Read(str1, 0, (int)(fi.Length));
                Console.WriteLine(Encoding.Default.GetString(str1));
            }

            Console.WriteLine("---------------------------------");

            /* 示範 OpenWrite() 方法*/
            fi = new FileInfo("test2.txt");
            str = "abcde";

            try
            {
                using (fs = fi.OpenWrite())
                {
                    fs.Write(Encoding.Default.GetBytes(str), 1, 3);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("error");
            }

            Console.WriteLine("---------------------------------");

            /* 示範 Replace() 方法*/
            fi = new FileInfo("test1.txt");
            FileInfo f;

            try
            {
                // f = fi.Replace("test2.txt", "test2.txt.bak");
                // 1. 原本 fi 為 test1.txt
                // 2. fi.Replace 是將 test1.txt 的內容，取代 test2.txt
                // 3. 並將 test1.txt 刪除
                // 4. 幫原本的 test2.txt 備份為 test2.txt.bak
                f = fi.Replace("test2.txt", "test2.txt.bak");
                Console.WriteLine(f.Name.ToString());
            }
            catch
            {
                Console.WriteLine("error");
            }

            Console.ReadKey();
        }
    }
}
