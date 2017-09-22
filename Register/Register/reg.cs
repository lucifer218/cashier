using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Register
{
    class reg
    {
        string operatorID;  //properties屬性
        productInfo pInfo;
        List<transaction> tList;

        public reg()  //建構式
        {
            pInfo = new productInfo();
            tList = new List<transaction>();
        }

        public void start()
        {
            bool quit = false;
            //Console.WriteLine("System Started.");  //測試是否建立物件成功
            Console.WriteLine("收銀機啟動");
            LoadProductInfo();//放這讀入商品的缺點是不知道他甚麼時候才執行，所以也可以放去program.cs那
            Console.WriteLine("商品資訊讀取成功");


           while (!quit)  //當是ture時一直跑 >> !quit=不是false >> quit=ture
           {
               Console.Write("Input ID or press 'q' to exit: ");
               string str = Console.ReadLine();
               if (str == "q")
                   quit = true;
               else
               {
                   logon(str);  
                   operate();
               }
           }
           Console.WriteLine("登出");
        }

        public void LoadProductInfo()  //讀取商品資訊price_list.txt放在Register\Register\bin\Debug
        {
            string[] lines = System.IO.File.ReadAllLines("price_list.txt", System.Text.Encoding.Default);  //一次全部從"price_list.txt"讀取進來後一次一行讀進陣列裡
            foreach (string line in lines)  //測試 逐一拜訪陣列裡面的每一個做輸出
            {
                Console.WriteLine(line);
                string[] split = line.Split(new Char[]{' '});  //針對每一行做拆解
                pInfo.add(split[0], split[1], split[2]);
            }
        }

        public void logon(string id)
        {
            operatorID = id;  //登入的員工ID
        }

        public void operate()
        {
            bool quit = false;
            Console.WriteLine("交易開始");
            while (!quit)
            {
                Console.Write("Input 'n' or press 'q' to exit: ");
                string str = Console.ReadLine();
                if (str == "q")
                    quit = true;
                else if (str == "n")
                {
                    transaction t = new transaction(operatorID);
                    t.addproduct(pInfo);                                                 
                    t.printInvoice();
                    tList.Add(t); //新增一筆交易
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            Console.WriteLine("結束交易");
        }


    }
}
