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
        DBLoan dbl;
        public LoanCtrl()
        {
            dbl = new DBLoan();
        }

        public void MakeLoan(string name, int amount)
        {
            Loan l = new Loan(name, amount);
            DBLoan dbl = new DBLoan();
            dbl.AddLoanToFile(l);
        }
        public List<Loan> GetList()
        {
            return dbl.GetList("loans.xml");
        }
        public Loan GetLoan(int index)
        {
            Loan l = null;
            if (index >= 0)
            {
                l = dbl.LoanList.ElementAt(index);
                return l;
            }
            return l;
        }
        public void RemoveLoan(int index)
        {
            Loan l = dbl.LoanList.ElementAt(index);
            dbl.LoanList.RemoveAt(index);
            //dbl.SaveList(dbl.LoanList, "loans.xml");
            dbl.History.Add(l);
            dbl.DeleteChosen();
            dbl.RefreshAllLists();
        }
        public void MoveSelectedToHistory()
        {
            dbl.DeleteChosen();
        }

    }
}
