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
        public List<Loan> loanList;
        public DBLoan()
        {
            //loanList = new List<Loan>();
            //addSomeData();
            GetLoanList();
            //SaveList();
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
                addSomeData();
            }
            list.Add(l);
            loanList = list;
            XmlSerializer serializer = new XmlSerializer(typeof(List<Loan>));
            using (Stream stream = new FileStream("loans.xml", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                serializer.Serialize(stream, loanList);
            }
        }

        public void GetLoanList()
        {
            if (File.Exists("loans.xml"))
            {
                //implementation goes here

                // Create an instance of the XmlSerializer specifying type and namespace.
                XmlSerializer serializer = new XmlSerializer(typeof(List<Loan>));

                // A FileStream is needed to read the XML document.
                FileStream fs = new FileStream("loans.xml", FileMode.Open);
                XmlReader reader = XmlReader.Create(fs);

                // Declare an object variable of the type to be deserialized.
                List<Loan> l;

                // Use the Deserialize method to restore the object's state.
                l = (List<Loan>)serializer.Deserialize(reader);
                fs.Close();
                loanList = l;
            }
           
        }
        public List<Loan> LoanList
        {
            get { return loanList; }
            set { loanList = value; }
        }
        public void addSomeData()
        {
            Loan l1 = new Loan("Janis", 200);
            Loan l2 = new Loan("Liene", 500);
            loanList.Add(l1);
            loanList.Add(l2);
        }
        public void SaveList()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Loan>));
            using (Stream stream = new FileStream("loans.xml", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                serializer.Serialize(stream, loanList);
            }
        }
    }
}
