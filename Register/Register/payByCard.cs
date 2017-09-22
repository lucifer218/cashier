using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Register
{
    class payByCard: payment
    {
        public payByCard(double amount)
        {
            base.amount = amount;
            base.method = "Card";
        }
    }
}
