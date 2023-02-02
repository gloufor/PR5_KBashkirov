using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Model
{
    public class Singleton
    {
        private static Model.BankEntities1 bankEntities;
        public static Model.BankEntities1 GetContext()
        {
            if (bankEntities == null) bankEntities = new Model.BankEntities1();
            return bankEntities;
        }
    }
}
