using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Register
{
    class payment
    {
        protected double amount;
        protected string method;
        protected double change;

        public double getAmount()
        {
            return amount;
        }
        public double getChange()
        {
            return change;
        }
    }
}
