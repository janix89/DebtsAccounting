using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gramatvediba.DBLayer;
using Gramatvediba.ModelLayer;

namespace Gramatvediba
{
    public partial class Form1 : Form
    {
        private DBLoan dbl;
        public Form1()
        {
            InitializeComponent();
            dbl = new DBLoan();

            dataGridView1.DataSource = dbl.LoanList;
            dataGridView1.BackgroundColor = Color.Silver;
            dataGridView1.Columns[3].Visible = true;

            DataGridViewCellStyle style = new DataGridViewCellStyle();
            DataGridViewCellStyle styleHeader = new DataGridViewCellStyle();
            style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            styleHeader.Alignment = DataGridViewContentAlignment.MiddleCenter;
            styleHeader.Padding = new Padding(20, 0, 0, 0);
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.RowsDefaultCellStyle.SelectionBackColor = Color.DeepSkyBlue;
            dataGridView1.RowsDefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView1.RowHeadersVisible = false;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.HeaderCell.Style = styleHeader;
                column.DefaultCellStyle = style;
            }
            dataGridView1.Columns[3].HeaderCell.Style = style;
            
        }

        private void dataGridView1_CellContentClick_3(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dbl.SaveList();
            
        }
    }
}
