using System;

/// <summary>
/// 建立類別的靜態成員
/// </summary>
namespace ClassAndObject_04
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadKey();

            Account Mary = new Account("Mary");
            Account John = new Account("John");

            /* Mary 存款*/
            Mary.Deposit(1000);
            Console.WriteLine(Mary.name + "儲存1000元");
            Console.WriteLine("共同存款有 " + Account.Money.ToString() + "元");
            Console.WriteLine(John.name + "有" + John.getMoney().ToString() + "元");

            /* John 提款*/
            John.Withdrawal(300);
            Console.WriteLine(John.name + "提款300元");
            Console.WriteLine("共同存款有 " + Account.Money.ToString() + "元");
            Console.WriteLine(Mary.name + "有" + John.getMoney().ToString() + "元");

            Console.ReadKey();
        }
    }

    class Account
    {
        public static int Money = 0;
        public string name { get; }
        public Account(string str)
        {
            name = str;
        }

        /// <summary>
        /// 提款
        /// </summary>
        /// <param name="m"></param>
        public void Withdrawal(int m)
        {
            if (Money >= m)
                Money -= m;
        }

        /// <summary>
        /// 存款
        /// </summary>
        /// <param name="m"></param>
        public void Deposit(int m)
        {
            if (m >= 0)
                Money += m;
        }

        /// <summary>
        /// 得知存款多少
        /// </summary>
        /// <returns></returns>
        public int getMoney()
        {
            return Money;
        }
    }
}
