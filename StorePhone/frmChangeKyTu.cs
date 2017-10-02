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
    public partial class frmChangeKyTu : Form
    {

        #region Fields

        private string kytu;

        #endregion // Fields

        #region Properties

        public string KyTu
        {
            get { return kytu; }
            set { kytu = value; }
        }

        #endregion // Properties

        public frmChangeKyTu()
        {
            InitializeComponent();
            kytu = ";";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
              
                kytu= comboBox1.SelectedIndex!= 0? kytu="\t":";";
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void frmChangeKyTu_Load(object sender, EventArgs e)
        {
            comboBox1.Items.AddRange(new object[] { "(;) Chấm Phẩy","(\\t) Tab"});
            comboBox1.SelectedIndex = 0;

        }
    }
}
