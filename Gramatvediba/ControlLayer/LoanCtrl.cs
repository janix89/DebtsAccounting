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
            dbl.AddLoanToFile(l);
        }
        //public List<Loan> GetList()
        //{
        //    return dbl.GetList("loans.xml");
        //}
        public List<Loan> GetDirectList(string listName)
        {
            if (listName.Equals("loans"))
            {
                return dbl.LoanList;
            }
            else if (listName.Equals("history"))
            {
                return dbl.History;
            }
            else
            {
                return null;
            }
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
        }
        public void MoveSelectedToHistory()
        {
            dbl.DeleteChosen();
        }

    }
}
