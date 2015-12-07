using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StorePhone
{
    public partial class frmChange3 : Form
    {
        public frmChange3()
        {
            InitializeComponent();
        }
        #region Fields

        private int selectindex;
        private string search;
        private DataTable tb;

        #endregion // Fields

        #region Properties

        public DataTable TB
        {
            get { return tb; }
            set { tb = value; }
        }

        public int Selectindex
        {
            get { return selectindex; }
            set { selectindex = value; }
        }
        public string Search
        {
            get { return search; }
            set { search = value; }
        }
        #endregion // Properties

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            for (int x = 0; x < checkedListBox1.Items.Count; x++)
            {
                checkedListBox1.SetItemChecked(x, checkBox1.Checked);
            }
        }

        private void frmChange3_Load(object sender, EventArgs e)
        {
            for (int x = 0; x < checkedListBox1.Items.Count; x++)
            {
                checkedListBox1.SetItemChecked(x, checkBox1.Checked);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (checkedListBox1.CheckedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn cột cần import", "Thông báo");
                return;
            }

             SaveFileDialog saveFileDialog1 = new SaveFileDialog();
             saveFileDialog1.Filter = radioButton2.Checked ? "Excel|*.xls" : "text|*.txt";
             saveFileDialog1.Title = "Xuất file";
             saveFileDialog1.ShowDialog();

            

   // If the file name is not an empty string open it for saving.
         if(saveFileDialog1.FileName != "")
            {

           
                DBOperation(saveFileDialog1.FileName);

           
             }
        }

        public void DBOperation(string FileName)
        {


            DataTable table;
            PleaseWait objPleaseWait = new PleaseWait();
            try
            {
               
                objPleaseWait.Show();
                Application.DoEvents();

                string strsql = "Select ";
                foreach (var item in checkedListBox1.CheckedItems)
                {
                    if (item.ToString() == "Di động")
                        strsql += "didong,";
                    if (item.ToString() == "Tên khách hàng")
                        strsql += "ten_khach_hang,";
                    if (item.ToString() == "Điạ chỉ")
                        strsql += "dia_chi,";
                    if (item.ToString() == "Ngày")
                        strsql += "ngay,";
                    if (item.ToString() == "Tháng")
                        strsql += "thang,";
                    if (item.ToString() == "Năm sinh")
                        strsql += "namsinh,";
                    if (item.ToString() == "Cước")
                        strsql += "cuoc,";
                    if (item.ToString() == "Giới tính")
                        strsql += "gioi_tinh,";
                    if (item.ToString() == "Ngân hàng")
                        strsql += "ngan_hang,";
                    if (item.ToString() == "Sim")
                        strsql += "Sim,";
                    if (item.ToString() == "Tỉnh")
                        strsql += "tinh,";
                    if (item.ToString() == "Tỉnh cước")
                        strsql += "tinh_cuoc,";
                    if (item.ToString() == "File nguồn")
                        strsql += "filenguon,";
                }
                
                //strsql += "ghi_chu,filenguon,creatdate from dienthoai_goc  ";
                strsql = strsql.Substring(0, strsql.Length - 1) + " from dienthoai_goc ";
                switch (selectindex)
                {
                    case 0:
                    case -1:
                        strsql += string.Format("where ten_khach_hang like N'%{0}%' or didong like '%{0}%' or dia_chi like N'%{0}%' or sim like N'%{0}%' or tinh like N'%{0}%' or tinh_cuoc like N'%{0}%' or gioi_tinh like N'%{0}%' or ghi_chu like N'%{0}%'  or ngan_hang like N'%{0}%' or namsinh like N'%{0}%' or ngay like N'%{0}%' or thang like N'%{0}%'", Search);
                        break;
                    case 1:/*di dong*/
                        strsql += string.Format("where didong like '%{0}%'", Search);
                        break;
                    case 2:/*dia chi*/
                        strsql += string.Format("where dia_chi like N'%{0}%'", Search);
                        break;
                    case 3:/*"Tên khách hàng",*/
                        strsql += string.Format("where ten_khach_hang like N'%{0}%'", Search);
                        break;
                    case 4:/*Ngày*/
                        strsql += string.Format("where ngay like N'%{0}%'", Search);
                        break;
                    case 5:/*Tháng*/
                        strsql += string.Format("where thang like N'%{0}%'", Search);
                        break;
                    case 6:/*Năm sinh*/
                        strsql += string.Format("where namsinh like N'%{0}%'", Search);
                        break;
                    case 7:/*Ngân hàng*/
                        strsql += string.Format("where ngan_hang like N'%{0}%'", Search);
                        break;
                    case 8:/*Cước*/
                        strsql += string.Format("where cuoc like N'%{0}%'", Search);
                        break;
                    case 9:/*Sim*/
                        strsql += string.Format("where sim like N'%{0}%'", Search);
                        break;
                    case 10:/*tinh cuoc*/
                        strsql += string.Format("where tinh_cuoc like N'%{0}%'", Search);
                        break;
                    case 11:/*tinh*/
                        strsql += string.Format("where tinh like N'%{0}%'", Search);
                        break;
                    case 12:/*filenguon*/
                        strsql += string.Format("where filenguon like N'%{0}%'", Search);
                        break;
                    default:
                        break;
                }

                table = SQLDatabase.ExcDataTable(strsql);

                if (table.Rows.Count == 0)
                {
                    objPleaseWait.Close();
                    MessageBox.Show("Không có dữ liệu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;

                }
                if (radioButton2.Checked)
                {
                    
                    ExcelAdapter excel = new ExcelAdapter("");
                    excel.SFilePath = FileName;
                    excel.CreateAndWrite(table, "Danh sách excel", 1);
                }
                else {
                  Export.ExportText(table,FileName);
                }
                objPleaseWait.Close();
                MessageBox.Show("Xuất file thành công", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
               
            }
            catch (Exception ex)
            {
                objPleaseWait.Close();
                MessageBox.Show(ex.Message, "View DataSource", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        }

    }

