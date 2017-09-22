using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Register
{
    class Program
    {
        static void Main(string[] args)
        {
            reg register = new reg(); //建立物件
            //Console.WriteLine("收銀機啟動");
            //register.LoadProductInfo();
            register.start();
            Console.Read();
        }
    }
}
