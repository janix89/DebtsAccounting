using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gramatvediba.ModelLayer;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.IO;

namespace Gramatvediba.DBLayer
{
    class DBLoan
    {
        private List<Loan> loanList;
        private List<Loan> history;

        public List<Loan> LoanList
        {
            get { return loanList; }
            set { loanList = value; }
        }
        public List<Loan> History
        {
            get { return history; }
            set { history = value; }
        }


        public DBLoan()
        {
            RefreshAllLists();
        }
        public void AddLoanToFile(Loan l)
        {
            List<Loan> list;
            if (loanList.Count != 0 || loanList != null)
            {
                list = loanList; 
            }
            else
            {
                list = new List<Loan>();
                //addSomeData();
            }
            list.Add(l);
            loanList = list;
            SaveList(loanList, "loans.xml");
        }

        public List<Loan> GetList(string fileName)
        {
            List<Loan> l;
            if (File.Exists(fileName))
            {
                //implementation goes here

                // Create an instance of the XmlSerializer specifying type and namespace.
                XmlSerializer serializer = new XmlSerializer(typeof(List<Loan>));

                // A FileStream is needed to read the XML document.
                FileStream fs = new FileStream(fileName, FileMode.Open);
                XmlReader reader = XmlReader.Create(fs);

                // Declare an object variable of the type to be deserialized.

                // Use the Deserialize method to restore the object's state.
                l = (List<Loan>)serializer.Deserialize(reader);
                fs.Close();
            }
            else
            {
                l = new List<Loan>();
            }
            return l;
        }

        //public void addSomeData()
        //{
        //    Loan l1 = new Loan("Janis", 200);
        //    Loan l2 = new Loan("Liene", 500);
        //    loanList.Add(l1);
        //    loanList.Add(l2);
        //}
        public void SaveList(List<Loan> l, string listName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Loan>));
            using (Stream stream = new FileStream(listName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                serializer.Serialize(stream, l);
            }
        }
        public void DeleteChosen()
        {
            List<Loan> notReturned = new List<Loan>();
            List<Loan> isReturned = GetList("history.xml");
            foreach(Loan l in loanList){
                if(!l.IsReturned){
                    
                    notReturned.Add(l);
                }
                else
                {
                    
                    isReturned.Add(l);
                }
            }
            SaveList(notReturned, "loans.xml");
            SaveList(isReturned, "history.xml");
        }
        public void RefreshAllLists()
        {
           LoanList = GetList("loans.xml");
           History = GetList("history.xml");
        }
    }
}
