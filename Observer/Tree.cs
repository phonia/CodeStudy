using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Observer
{
    public class BankAcountH
    {
        public Action<BankAcountH> EventHandler;

        public void Withdraw()
        {
            if (EventHandler != null) EventHandler(this);
        }
    }
}
