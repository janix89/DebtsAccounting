using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gramatvediba.ModelLayer;
using Gramatvediba.DBLayer;

namespace Gramatvediba.ControlLayer
{
    class LoanCtrl
    {
        public LoanCtrl()
        {

        }

        public void MakeLoan(string name, int amount)
        {
            Loan l = new Loan(name, amount);
            DBLoan dbl = new DBLoan();
            dbl.AddLoanToFile(l);
        }
        public List<Loan> GetAllList()
        {
            DBLoan dbl = new DBLoan();
            return dbl.LoanList;
        }

    }
}
