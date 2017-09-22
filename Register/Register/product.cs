using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Register
{
    class product
    {
        string productID;
        string productName;
        double productPrice;
        int quantity;

        public string getproductID()
        {
            return productID;
        }
        public product(string pid, string pname, string price,int k)
        {
            productID = pid;
            productName = pname;
            productPrice = Double.Parse(price);
            quantity=k;
        }
        public double getProductPrice()
        {
            return productPrice;
        }
        public double getQuantity()
        {
            return quantity;
        }

        public void show()
        {
            Console.WriteLine(productID + " " + productName + " " + productPrice + "*" + quantity + "=" + productPrice * quantity);
        }
    }
}
