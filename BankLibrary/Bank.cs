using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankProblem
{
    public class Bank
    {
        public string Name { get; private  set; }
        public List<AbstractAccount> Accounts { get; set; }

        public Bank(string name, List<AbstractAccount> accounts)
        {
            Name = name;
            Accounts = accounts;
        }
    }
}
