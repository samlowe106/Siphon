using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siphon
{
    class Bank
    {
        // fields
        public int money;

        // constructor
        public Bank()
        {
            money = 0;
        }

        // methods
        public bool Purchase(int cost)
        {
            if (cost > money)
            {
                return false;
            }

            money -= cost;

            return true;
        }

        public void Deposit(int cost)
        {
            money += cost;
        }
    }

}
