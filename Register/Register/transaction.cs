using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Register
{
    class transaction
    {
        List<product> productList;
        private payment pay;
        private double total = 0;
        string operid;

        public transaction(string operatorID)
        {
            productList = new List<product>();
            pay = new payment();
            operid=operatorID;
        }

        public void addproduct(productInfo pInfo)
        {
            bool quit = false;
            while (!quit)
            {
                Console.Write("請輸入產品ID或按'q'結束: ");
                string str = Console.ReadLine();
                if (str == "q") quit = true;
                else
                {
                    //新增商品到交易中
                    if (pInfo.isExist(str))
                    {   
                        Console.Write(pInfo.getName(str));
                        Console.Write("  ");
                        Console.Write(pInfo.getPrice(str));
                        Console.Write("  數量:");
                        string s = Console.ReadLine();
                        int i = 0;
                        bool result = int.TryParse(s, out i);
                        if (result == true)
                        {
                            int k = int.Parse(s);
                            product p = new product(str, pInfo.getName(str), pInfo.getPrice(str), k);
                            productList.Add(p);
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                    }
                    else
                        Console.WriteLine("輸入錯誤");
                }
            }
            Console.WriteLine("新增交易完成");
            foreach (product p in productList)
            {
                total += p.getProductPrice() * p.getQuantity();
            }
            bool payquit = false;
            while (payquit != true){
            Console.WriteLine("總金額:{0}",total);
            Console.WriteLine("結帳方式(m)現金;(c)信用卡:");
            string str_method = Console.ReadLine();
                if (str_method == "m" || str_method == "c")
                {
                    if (str_method == "m")
                    {
                        double amount = 0.0;
                        do
                        {
                            Console.Write("付款金額:");
                            string coco = Console.ReadLine();
                            int x = 0;
                            bool result = int.TryParse(coco, out x);
                            if (result == true)
                            {
                                amount = double.Parse(coco);
                            }
                            else
                            {
                                Console.WriteLine("error");
                            }
                        } while (amount < total);
                        pay = new payInCach(amount, amount - total);
                    }
                    if (str_method == "c")
                    {
                        pay = new payByCard(total);
                    }
                    Console.WriteLine("==================Sevens11==================");
                    payquit = true;
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
        }
        public double getTotal()
        {
            return total;
        }
        public void payMethod(payment p)
        {
            pay = p;
        }
        public void printInvoice()
        {
            foreach (product p in productList)
            {
                p.show();
            }
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("交易金額:{0}", total);
            Console.WriteLine("付款金額:{0}", pay.getAmount());

            Console.WriteLine("找零:{0}", pay.getChange());
            Console.WriteLine("員工ID:{0}",operid);
            DateTime nowtime = DateTime.Now;
            Console.WriteLine("時間:{0}", nowtime);

        }
    }
}
