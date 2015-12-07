using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StorePhone
{
    public partial class frmXemTruoc : Form
    {
        public frmXemTruoc()
        {
            InitializeComponent();
        }

        private DataTable dataSourceDate;
        private string title;

        public DataTable DataSourceDate
        {
            get { return dataSourceDate; }
            set { dataSourceDate = value; }
        }

        public string Title {
            get { return title; }
            set { title = value; }
        }

        private void frmXemTruoc_Load(object sender, EventArgs e)
        {
            PleaseWait objPleaseWait = new PleaseWait();
            objPleaseWait.Show();
            Application.DoEvents();      
            try
            {
                dataGridView1.DataSource = DataSourceDate;
                //dataGridView1.Columns[0].Width = 220;
                //dataGridView1.Columns[1].Width = 160;
                this.Text = string.Format("Xem trước {0}", title);
                objPleaseWait.Close();
            }
            catch (Exception ex)
            {
                objPleaseWait.Close();
                MessageBox.Show(ex.Message, "frmViewDateOfBirth_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
