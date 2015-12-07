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
    public partial class frmBackup : Form
    {
        public frmBackup()
        {
            InitializeComponent();
        }

        private void frmBackup_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = SQLDatabase.ExcDataTable("[spLoadData]");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PleaseWait objPleaseWait = new PleaseWait();
            objPleaseWait.Show();
            Application.DoEvents();

            if (SQLDatabase.ExcNonQuery("[spBackup]"))
            {
                dataGridView1.DataSource = SQLDatabase.ExcDataTable("[spLoadData]");
            }
            objPleaseWait.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            PleaseWait objPleaseWait = new PleaseWait();
          
            try
            {
                Int32 selectedRowCount =dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
                if (selectedRowCount == 0)
                    return;

                string tenbang = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["TABLE_NAME"].Value.ToString();

                if (MessageBox.Show(string.Format("Bạn có chắc là muốn khôi phục '{0}' dữ liệu này không",tenbang), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {

                        return;
                      
                }
                objPleaseWait.Show();
                Application.DoEvents();
               if( SQLDatabase.ExcNonQuery(string.Format("[spKhoiPhuc] '{0}'",tenbang))){
                    MessageBox.Show(string.Format("Khôi phục dữ liều từ db: {0}",tenbang),"Thành công",MessageBoxButtons.OK,MessageBoxIcon.Information);
               }
               objPleaseWait.Close();

            }
            catch (Exception ex)
            {
                objPleaseWait.Close();
                throw;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            PleaseWait objPleaseWait = new PleaseWait();
            try
            {
                Int32 selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
                if (selectedRowCount == 0)
                    return;

                string tenbang = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["TABLE_NAME"].Value.ToString();

                if (MessageBox.Show(string.Format("Bạn có chắc là muốn khôi phục '{0}' dữ liệu này không", tenbang), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;

                }
                objPleaseWait.Show();
                Application.DoEvents();
                if (SQLDatabase.ExcNonQuery(string.Format("drop table {0}", tenbang)))
                {
                    dataGridView1.DataSource = SQLDatabase.ExcDataTable("[spLoadData]");
                }

                objPleaseWait.Close();
            }
            catch (Exception ex)
            {
                objPleaseWait.Close();
                throw;
            }
        }
    }
}

