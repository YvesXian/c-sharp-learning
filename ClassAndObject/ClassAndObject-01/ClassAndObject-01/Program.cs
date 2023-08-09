using System;
using System.Drawing;

/// <summary>
/// 建立類別與物件
/// </summary>
namespace ClassAndObject_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Size s = new Size();
            Shape shp = new Shape();

            string input = null;

            Console.Write("請輸入 Width: ");
            input = Console.ReadLine();
            shp.Width = int.Parse(input);

            Console.Write("請輸入 Height: ");
            input = Console.ReadLine();
            shp.Height = int.Parse(input);

            shp.getSize(ref s);

            Console.WriteLine("s.Width = " + s.Width.ToString());
            Console.WriteLine("s.Height = " + s.Height.ToString());

            Console.ReadKey();
        }
    }

    public class Shape
    {
        private int _width = 1;
        private int _height = 1;

        public int Width
        {
            get => _width;
            set => _width = value;
        }

        public int Height
        {
            get => _height;
            set => _height = value;
        }

        public void getSize(ref Size s)
        {
            s.Width = _width;
            s.Height = _height;
        }
    }
}
