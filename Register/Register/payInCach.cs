using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Register
{
    class payInCach: payment
    {
        public payInCach(double amount,double change)
        {
            base.amount = amount;
            base.method = "Cach";
            base.change = change;
        }
    }
}
