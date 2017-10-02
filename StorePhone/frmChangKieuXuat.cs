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
    public partial class frmChangKieuXuat : Form
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

        public frmChangKieuXuat()
        {
            InitializeComponent();
            kytu = "tam";
        }

        private void frmChangKieuXuat_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kytu = comboBox1.SelectedIndex == 0 ? "tam" : "goc";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}
