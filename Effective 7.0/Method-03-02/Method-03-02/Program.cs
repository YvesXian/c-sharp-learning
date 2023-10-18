using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Method_03_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();

            Phone[] phones = new Phone[10];
            PhoneList pl = new PhoneList(phones);
            /* check initail state*/
            Console.WriteLine("-- initial sate --");
            Console.WriteLine("phones[5].b = " + phones[5].b.ToString());
            program.ShowPhoneList(pl);

            Console.ReadKey();

            /* phones 內容改變時, 觀察 PhoneList.phones 的內容是否也改變*/
            phones[5].b = 0xFF;
            /* -- phones[5] is changed*/
            Console.WriteLine("-- phons[5] is changed --");
            Console.WriteLine("phones[5].b = " + phones[5].b.ToString());
            program.ShowPhoneList(pl);

            Console.ReadKey();
        }

        public void ShowPhoneList(PhoneList pl)
        {
            int i = 0;

            foreach (Phone phone in pl.Phones)
            {
                Console.WriteLine("PhoneList.phones[" + i.ToString() + "] = " + phone.b);
                i++;
            }

            Console.WriteLine();
        }

        public struct Phone
        {
            public int b;
        }

        public struct PhoneList
        {
            private readonly Phone[] phones;

            public PhoneList(Phone[] ph)
            {
                phones = ph;
            }

            public IEnumerable<Phone> Phones
            {
                get { return phones; }
            }
        }
    }
}
