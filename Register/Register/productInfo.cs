using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Register
{
    class productInfo
    {
        Hashtable productName;
        Hashtable productPrice;

        public productInfo()
        {
            productName = new Hashtable();
            productPrice = new Hashtable();
        }

        public void add(string pid, string name, string price)
        {   
            productName.Add(pid,name);
            productPrice.Add(pid,price);
        }
        public string getName(string pid)
        {
            return productName[pid].ToString();
        }
        public string getPrice(string pid)
        {
            return productPrice[pid].ToString();
        }
        public bool isExist(string pid)
        {
            return productName.ContainsKey(pid) && productPrice.ContainsKey(pid);
        }

    }
}
