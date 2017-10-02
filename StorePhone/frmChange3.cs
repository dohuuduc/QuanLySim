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
        private string sql;
        private string filename;

      

        #endregion // Fields

        #region Properties

        public String SQL
        {
            get { return sql; }
            set { sql = value; }
        }
        public String Filename
        {
            get { return filename; }
            set { filename = value; }
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
            saveFileDialog1.Filter = "text|*.txt";
            saveFileDialog1.Title = "Xuất file";
            saveFileDialog1.ShowDialog();

                // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName == "") {
                MessageBox.Show("Vui lòng nhập tên file","Thông Báo");
                return;
            }

            Filename = saveFileDialog1.FileName;

            string strsql = "Select ";
            foreach (var item in checkedListBox1.CheckedItems)
            {
                if (item.ToString() == "Di động")
                    strsql += "a.didong,";
                if (item.ToString() == "Tên khách hàng")
                    strsql += "a.ten_khach_hang,";
                if (item.ToString().ToLower() == "phường")
                    strsql += "a.phuong,";
                if (item.ToString().ToLower() == "quận huyện")
                    strsql += "a.quan_huyen,";
                if (item.ToString() == "Điạ chỉ")
                    strsql += "a.dia_chi,";
                if (item.ToString() == "Ngày")
                    strsql += "a.ngay,";
                if (item.ToString() == "Tháng")
                    strsql += "a.thang,";
                if (item.ToString() == "Năm sinh")
                    strsql += "a.namsinh,";
                if (item.ToString().ToLower() == "email")
                    strsql += "a.email,";
                if (item.ToString() == "Cước")
                    strsql += "a.cuoc,";
                if (item.ToString() == "Giới tính")
                    strsql += "a.gioi_tinh,";
                if (item.ToString() == "Ngân hàng")
                    strsql += "a.ngan_hang,";
                if (item.ToString() == "Sim")
                    strsql += "a.Sim,";
                if (item.ToString().ToLower() == "tỉnh đc")
                    strsql += "a.tinh,";
                if (item.ToString().ToLower() == "tỉnh cước")
                    strsql += "a.tinh_cuoc,";
                if (item.ToString() == "Ngày Kích Hoạt")
                    strsql += "a.ngay_kich_hoat,";
                if (item.ToString().ToLower() == "gói cước")
                    strsql += "a.goi_cuoc,";
                if (item.ToString().ToLower() == "dòng máy")
                    strsql += "a.dong_may,";
                if (item.ToString().ToLower() == "hệ điều hành")
                    strsql += "a.he_dieu_hanh,";
                if (item.ToString().ToLower() == "chức vụ")
                    strsql += "a.chuc_vu,";
                if (item.ToString().ToLower() == "công ty")
                    strsql += "a.cong_ty,";
                if (item.ToString().ToLower() == "ghi chú")
                    strsql += "a.ghi_chu,";
                if (item.ToString() == "File nguồn")
                    strsql += "a.filenguon,";
            }
            strsql = strsql.Substring(0, strsql.Length - 1);
            SQL = strsql;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        //public string DBOperation()
        //{
            
        //    try
        //    {
               
        //        //objPleaseWait.Show();
        //        //Application.DoEvents();

        //        string strsql = "Select ";
        //        foreach (var item in checkedListBox1.CheckedItems)
        //        {
        //            if (item.ToString() == "Di động")
        //                strsql += "didong,";
        //            if (item.ToString() == "Tên khách hàng")
        //                strsql += "ten_khach_hang,";
        //            if (item.ToString() == "Điạ chỉ")
        //                strsql += "dia_chi,";
        //            if (item.ToString() == "Ngày")
        //                strsql += "ngay,";
        //            if (item.ToString() == "Tháng")
        //                strsql += "thang,";
        //            if (item.ToString() == "Năm sinh")
        //                strsql += "namsinh,";
        //            if (item.ToString() == "Cước")
        //                strsql += "cuoc,";
        //            if (item.ToString() == "Giới tính")
        //                strsql += "gioi_tinh,";
        //            if (item.ToString() == "Ngân hàng")
        //                strsql += "ngan_hang,";
        //            if (item.ToString() == "Sim")
        //                strsql += "Sim,";
        //            if (item.ToString() == "Tỉnh")
        //                strsql += "tinh,";
        //            if (item.ToString() == "Tỉnh cước")
        //                strsql += "tinh_cuoc,";
        //            if (item.ToString() == "Ghi chú")
        //                strsql += "ghi_chu,";
        //            if (item.ToString() == "File nguồn")
        //                strsql += "filenguon,";

        //            if (item.ToString().ToLower() == "phường")
        //                strsql += "phuong,";
        //            if (item.ToString().ToLower() == "quận huyện")
        //                strsql += "quan_huyen,";
        //            if (item.ToString().ToLower() == "ngày kích hoạt")
        //                strsql += "ngay_kich_hoat,";
        //            if (item.ToString().ToLower() == "gói cước")
        //                strsql += "goi_cuoc,";
        //            if (item.ToString().ToLower() == "dòng máy")
        //                strsql += "dong_may,";
        //            if (item.ToString().ToLower() == "hệ điều hành")
        //                strsql += "he_dieu_hanh,";
        //            if (item.ToString().ToLower() == "chức vụ")
        //                strsql += "chuc_vu,";
        //            if (item.ToString().ToLower() == "công ty")
        //                strsql += "cong_ty,";
        //        }
        //        strsql = strsql.Substring(0, strsql.Length - 1);
        //        //switch (selectindex)
        //        //{
        //        //    case -2:/*truong hop search nâng cao*/
        //        //        strsql += search;
        //        //        break;
        //        //    case 0:
        //        //    case -1:
        //        //        strsql += string.Format(" where ten_khach_hang like N'%{0}%' or "+
        //        //                                " didong like '%{0}%' or "+
        //        //                                " dia_chi like N'%{0}%' or "+
        //        //                                " sim like N'%{0}%' or "+
        //        //                                " tinh like N'%{0}%' or "+
        //        //                                " tinh_cuoc like N'%{0}%' or "+
        //        //                                " gioi_tinh like N'%{0}%' or "+
        //        //                                " ghi_chu like N'%{0}%'  or "+
        //        //                                " ngan_hang like N'%{0}%' or "+
        //        //                                " namsinh like N'%{0}%' or "+
        //        //                                " ngay like N'%{0}%' or "+
        //        //                                " thang like N'%{0}%' or "+
        //        //                                " ghi_chu like N'%{0}%'  or "+
        //        //                                " phuong like N'%{0}%'  or " +
        //        //                                " quan_huyen like N'%{0}%'  or " +
        //        //                                " email like N'%{0}%'  or " +
        //        //                                " ngay_kich_hoat like N'%{0}%'  or " +
        //        //                                " goi_cuoc like N'%{0}%'  or " +
        //        //                                " dong_may like N'%{0}%'  or " +
        //        //                                " he_dieu_hanh like N'%{0}%'  or " +
        //        //                                " chuc_vu like N'%{0}%'  or " +
        //        //                                " cong_ty like N'%{0}%'  or " +
        //        //                                " filenguon like N'%{0}%'", Search);
        //        //        break;
        //        //    case 1:/*di dong*/
        //        //        strsql += string.Format("where didong like '%{0}%'", Search);
        //        //        break;
        //        //    case 2:/*"khách hàng",*/
        //        //        strsql += string.Format("where ten_khach_hang like N'%{0}%'", Search);
        //        //        break;
        //        //    case 3:/*"phường",*/
        //        //        strsql += string.Format("where phuong like N'%{0}%'", Search);
        //        //        break;
        //        //    case 4:/*"quan_huyen",*/
        //        //        strsql += string.Format("where quan_huyen like N'%{0}%'", Search);
        //        //        break;
        //        //    case 5:/*dia chi*/
        //        //        strsql += string.Format("where dia_chi like N'%{0}%'", Search);
        //        //        break;
                    
        //        //    case 6:/*Ngày*/
        //        //        strsql += string.Format("where ngay like N'%{0}%'", Search);
        //        //        break;
        //        //    case 7:/*Tháng*/
        //        //        strsql += string.Format("where thang like N'%{0}%'", Search);
        //        //        break;
        //        //    case 8:/*Năm sinh*/
        //        //        strsql += string.Format("where namsinh like N'%{0}%'", Search);
        //        //        break;
        //        //    case 9:/*email*/
        //        //        strsql += string.Format("where email like N'%{0}%'", Search);
        //        //        break;
        //        //    case 10:/*cuoc*/
        //        //        strsql += string.Format("where cuoc like N'%{0}%'", Search);
        //        //        break;
        //        //    case 11:/*gioitinh*/
        //        //        strsql += string.Format("where gioi_tinh like N'%{0}%'", Search);
        //        //        break;
        //        //    case 12:/*ngan_hang*/
        //        //        strsql += string.Format("where ngan_hang like N'%{0}%'", Search);
        //        //        break;
        //        //    case 13:/*sim*/
        //        //        strsql += string.Format("where tinh sim N'%{0}%'", Search);
        //        //        break;
        //        //    case 14:/*tinh*/
        //        //        strsql += string.Format("where tinh N'%{0}%'", Search);
        //        //        break;
        //        //    case 15:/*tinh_cuoc*/
        //        //        strsql += string.Format("where tinh_cuoc N'%{0}%'", Search);
        //        //        break;
        //        //    case 16:/*ngay_kich_hoat*/
        //        //        strsql += string.Format("where ngay_kich_hoat N'%{0}%'", Search);
        //        //        break;
        //        //    case 17:/*goi_cuoc*/
        //        //        strsql += string.Format("where goi_cuoc N'%{0}%'", Search);
        //        //        break;
        //        //    case 18:/*dong_may*/
        //        //        strsql += string.Format("where dong_may N'%{0}%'", Search);
        //        //        break;
        //        //    case 19:/*he_dieu_hanh*/
        //        //        strsql += string.Format("where he_dieu_hanh N'%{0}%'", Search);
        //        //        break;
        //        //    case 20:/*chuc_vu*/
        //        //        strsql += string.Format("where chuc_vu N'%{0}%'", Search);
        //        //        break;
        //        //    case 21:/*cong_ty*/
        //        //        strsql += string.Format("where cong_ty N'%{0}%'", Search);
        //        //        break;
        //        //    case 22:/*ghi_chu*/
        //        //        strsql += string.Format("where ghi_chu like N'%{0}%'", Search);
        //        //        break;
        //        //    case 23:/*filenguon*/
        //        //        strsql += string.Format("where filenguon like N'%{0}%'", Search);
        //        //        break;
        //        //    default:
        //        //        break;
        //        //}
        //        //strsql += " Order by didong asc";
        //        //table = SQLDatabase.ExcDataTable(strsql);

        //        //if (table.Rows.Count == 0)
        //        //{
        //        //    objPleaseWait.Close();
        //        //    MessageBox.Show("Không có dữ liệu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        //    return;

        //        //}
               
        //           //  objPleaseWait.Close();
        //             //frmChangeKyTu frm = new frmChangeKyTu();
        //             //if (frm.ShowDialog() == DialogResult.OK)
        //             //{
        //             //    PleaseWait objPleaseWait1 = new PleaseWait();
        //             //    objPleaseWait1.Show();
        //             //    Application.DoEvents();
        //             //    Export.ExportText(table, FileName, "\t");
        //             //    objPleaseWait1.Close();
        //             //}
                
        //        //MessageBox.Show("Xuất file thành công", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
               
        //    }
        //    catch (Exception ex)
        //    {
        //        //objPleaseWait.Close();
        //        MessageBox.Show(ex.Message, "View DataSource", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //}

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        }

    }

