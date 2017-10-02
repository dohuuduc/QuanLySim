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
    public partial class frmChange4 : Form
    {
        #region Fields

    
        private string name;

        #endregion // Fields

        #region Properties

      

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        #endregion // Properties

        public frmChange4()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "") return;

                if (SQLDatabase.ExcNonQuery(string.Format("EXEC sp_rename '{0}', '{1}'", name, textBox1.Text.Trim())))
                {
                    MessageBox.Show("Đổi tên thành công", "Thông báo");

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else {
                    MessageBox.Show("Không đổi thành công", "Thông báo");    
                
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Không đổi thành công","Thông báo");
            }
          
        }

        private void frmChange4_Load(object sender, EventArgs e)
        {
            label1.Text = name;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
