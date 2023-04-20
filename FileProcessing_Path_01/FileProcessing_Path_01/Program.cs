using System;
using System.IO;

namespace FileProcessing_Path_01
{
    class Program
    {
        static void Main(string[] args)
        {
            string strPath1 = @"aa/bb/cc.txt";
            string strPath2 = @"aa/bb/dd";
            string result = null;

            // 更改、加入副檔名
            result = Path.ChangeExtension(strPath1, ".bak");
            Console.WriteLine(result);
            result = Path.ChangeExtension(strPath2, ".jpg");
            Console.WriteLine(result);
            Console.WriteLine("");

            string[] strArr = { "aa", "bb", "cc.txt" };
            string strPath, str;

            // 將多個字串合併為一個路徑
            strPath = Path.Combine(strArr);
            Console.WriteLine("合併字串成為路徑: " + strPath);
            // 只取出路徑
            /* GetDirectoryName() 方法只取出 strPath 的路徑部分，不包含檔名*/
            str = Path.GetDirectoryName(strPath);
            Console.WriteLine("取出路徑: " + str);
            // 只取出檔案的副檔名
            str = Path.GetExtension(strPath);
            Console.WriteLine("副檔名: " + str);
            Console.WriteLine("");

            // 取出完整檔名
            /* GetFileName: Returns the file name and extension of the specified path string.*/
            str = Path.GetFileName(strPath);
            Console.WriteLine("完整檔名: " + str);
            // 只取出主檔名
            str = Path.GetFileNameWithoutExtension(strPath);
            Console.WriteLine("主檔名: " + str);
            str = Path.GetFullPath(strPath);
            Console.WriteLine("完整路徑: " + str);
            Console.WriteLine();

            bool fg = false;
            str = Path.GetTempPath();
            Console.WriteLine("取得暫存目錄: " + str);

            str = Path.GetPathRoot(str);
            Console.WriteLine("根目錄: " + str);

            str = Path.GetRandomFileName();
            Console.WriteLine("取得隨機的檔名: " + str);

            fg = Path.HasExtension(@"c:\aa\bb\cc.txt");
            Console.WriteLine("是否有副檔名: " + fg.ToString());
            Console.WriteLine();

            // Environment.SpecialFolder.DesktopDirectory 取得使用者桌面的路徑
            str = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            Console.WriteLine("取得使用者桌面的路徑: " + str);

            // Environment.SpecialFolder.MyDocuments 取得使用者相關資料夾的路徑
            str = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            Console.WriteLine("取得使用者相關資料夾的路徑: " + str);

            Console.ReadKey();
        }
    }
}
