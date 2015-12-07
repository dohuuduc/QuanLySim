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
    public partial class frmChange : Form
    {

        #region Fields

        private int change;

        #endregion // Fields

        #region Properties

        public int Change
        {
            get { return change; }
            set { change = value; }
        }

        #endregion // Properties

        public frmChange()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(rado1.Checked)
                    change =1;
                else
                    change = 0;

                    this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
