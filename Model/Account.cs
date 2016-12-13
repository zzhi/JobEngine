using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Model
{
    public class Account
    {

        public IEBankType BankType { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }

    }
}
