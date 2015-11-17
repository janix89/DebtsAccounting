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
    public partial class Form1 : Form
    {
        private LoanCtrl lctrl;
        public Form1()
        {
            InitializeComponent();
            lctrl = new LoanCtrl();

            dataGridView1.DataSource = lctrl.GetList();
            dataGridView1.BackgroundColor = Color.Silver;
            dataGridView1.Columns[3].Visible = true;
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;

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
        private void DataGridView1_CellDoubleClick(Object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                PopUp p = new PopUp();
                p.Index = e.RowIndex;
                p.Show();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            lctrl.MoveSelectedToHistory();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            int amount = Int32.Parse(textBox2.Text);
            lctrl.MakeLoan(name,amount);
            TableUpdate();
        }
        public void TableUpdate()
        {
            DataSet ds = new DataSet();
            BindingSource bs = new BindingSource();
            bs.DataSource = lctrl.GetList();
            dataGridView1.DataSource = bs;
        }
    }
}
