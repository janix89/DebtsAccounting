using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gramatvediba.ControlLayer;


namespace Gramatvediba
{
    public partial class PopUp : Form
    {
        public int Index { get; set; }
        private LoanCtrl lc;
        public PopUp()
        {
            InitializeComponent();
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            lc = new LoanCtrl();
            textBox1.Text = lc.GetLoan(Index).Name;
            textBox2.Text = lc.GetLoan(Index).Amount.ToString();
            textBox3.Text = lc.GetLoan(Index).Date;
        }

        private void PopUp_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            lc.GetDirectList("loans").ElementAt(Index).IsReturned = true;
            lc.MoveSelectedToHistory();
            if (System.Windows.Forms.Application.OpenForms["Form1"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["Form1"] as Form1).TableUpdate();
            }
            this.Dispose();
        }
    }
}
