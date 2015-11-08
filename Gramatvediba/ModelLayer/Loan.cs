using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Gramatvediba.ModelLayer
{
    public class Loan
    {
        [DisplayName("Vārds")]
        public string Name { get; set; }
        [DisplayName("Summa")]
        public int Amount { get; set; }
        [DisplayName("Datums")]
        public string Date { get; set; }
        [DisplayName("Atdots")]
        public bool IsReturned { get; set; }


        public Loan(string name, int amount)
        {
            Name = name;
            Amount = amount;
        }

        public Loan()
        {

        }
    }
}
