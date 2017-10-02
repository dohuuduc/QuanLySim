using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StorePhone {
    public partial class frmTimNangCao : Form {
        public frmTimNangCao()
        {
            InitializeComponent();
        }

        #region Fields

      
        private string search;
      

        #endregion // Fields

        #region Properties

       
        public string Search
        {
            get { return search; }
            set { search = value; }
        }
        #endregion // Properties

        private void cbb1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb1.SelectedIndex == 0)
            {
                cbb2.Visible = false;
                cbb_dieukien2.Visible = false;
                cbb_dieukien3.Visible = false;
                txt_Search2.Visible = false;
                txt_Search3.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                txt_Search2.Text = "";
                txt_Search3.Text = "";

                checkBox2.Visible = false;
                checkBox3.Visible = false;
            }
            else {
                cbb2.Visible = true;
                cbb_dieukien2.Visible = true;
                checkBox2.Visible = true;
                txt_Search2.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
            }
        }

        private void cbb2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb2.SelectedIndex == 0)
            {
                cbb_dieukien3.Visible = false;
                txt_Search3.Visible = false;
                checkBox3.Visible = false;
                label3.Visible = false;
                txt_Search3.Text = "";
            }
            else {

                cbb_dieukien3.Visible = true;
                txt_Search3.Visible = true;
                label3.Visible = true;
                checkBox3.Visible = true;
            }
           
        }

        private void frmTimNangCao_Load(object sender, EventArgs e)
        {
            object[] obj = new object[] {                "--- Tất cả ---", 
                                                        "Di Động",
                                                        "Khách Hàng",
                                                        "Phường",
                                                        "Quận",
                                                        "Địa Chỉ",
                                                        "Ngày",
                                                        "Tháng",
                                                        "Năm Sinh",
                                                        "Email",
                                                        "Cước",
                                                        "Giới Tính",
                                                        "Ngân Hàng",
                                                        "Sim",
                                                        "Tỉnh ĐC",
                                                        "Tỉnh Cước",
                                                        "Ngày Kích Hoạt",
                                                        "Gói Cước",
                                                        "Dòng Máy",
                                                        "Hệ Điều Hành",
                                                        "Chức Vụ",
                                                        "Công Ty",
                                                        "Ghi Chú",
                                                        "File Nguồn"};
           
            cbb_dieukien1.Items.AddRange(obj);
            cbb_dieukien1.SelectedIndex = 0;
            cbb_dieukien2.Items.AddRange(obj);
            cbb_dieukien2.SelectedIndex = 0;
            cbb_dieukien3.Items.AddRange(obj);
            cbb_dieukien3.SelectedIndex = 0;

            cbb1.SelectedIndex = 0;
            cbb2.SelectedIndex = 0;
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_Search1.Text == "") {
                MessageBox.Show("Vui lòng nhập thông tin điều kiện 1");
                return;
            }

            if (cbb1.SelectedIndex != 0)
            {
                if (txt_Search2.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập thông tin điều kiện 2");
                    return;
                }
            }
            
            if (cbb2.SelectedIndex != 0)
            {
                if (txt_Search3.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập thông tin điều kiện 3");
                    return;
                }
            }

            
           search += " where " + chuoidk(cbb_dieukien1.SelectedIndex, txt_Search1.Text,checkBox1.Checked);
            if (cbb1.SelectedIndex != 0)
            {
                search += string.Format(" {0} ", cbb1.SelectedItem);
                search += chuoidk(cbb_dieukien2.SelectedIndex, txt_Search2.Text, checkBox2.Checked);
                if (cbb2.SelectedIndex != 0) {
                    search += string.Format(" {0} ", cbb2.SelectedItem);
                    search += chuoidk(cbb_dieukien3.SelectedIndex, txt_Search3.Text, checkBox3.Checked);
                }
            }
            this.DialogResult = DialogResult.OK;
            this.Close();

        }
        private string chuoidk(int vitri, string xxxx, bool Checked)
        {
            string dk = "";
            if (vitri == 0) {
                if(!Checked)
                    dk += string.Format("( ten_khach_hang like N'%{0}%' or phuong like '%{0}%' or quan_huyen like N'%{0}%' or email like N'%{0}%' or ngay_kich_hoat like N'%{0}%' or goi_cuoc like N'%{0}%' or dong_may like N'%{0}%' or chuc_vu like N'%{0}%' or cong_ty like N'%{0}%' or he_dieu_hanh like N'%{0}%' or didong like N'%{0}%' or dia_chi like N'%{0}%' or sim like N'%{0}%' or tinh like N'%{0}%' or tinh_cuoc like N'%{0}%' or gioi_tinh like N'%{0}%' or ghi_chu like N'%{0}%'  or ngan_hang like N'%{0}%' or namsinh like N'%{0}%' or ngay like N'%{0}%' or thang like N'%{0}%' or   ghi_chu like N'%{0}%'  or   filenguon like N'%{0}%')", xxxx);
                else
                    dk += string.Format("(  left(ten_khach_hang,{0}) = '{1}'  or "+
                                           "left(didong ,{0})= '{1}' or "+
                                           "left(dia_chi,{0})=N'{1}' or "+ 
                                           "left(sim,{0})=N'{1}' or "+
                                           "left(tinh,{0})=N'{1}' or "+
                                           "left(tinh_cuoc,{0})=N'{1}' or "+
                                           "left(gioi_tinh,{0})=N'{1}' or "+
                                           "left(ghi_chu,{0})=N'{1}'  or "+
                                           "left(ngan_hang,{0})=N'{1}' or "+
                                           "left(namsinh,{0}) =N'{1}' or "+
                                           "left(ngay,{0})=N'{1}' or "+
                                           "left(thang,{0})=N'{1}' or "+ 
                                           "left(ghi_chu,{0})=N'{1}' or "+ 
                                           "left(filenguon,{0})=N'{1}' or " +
                                           "left(phuong,{0})=N'{1}' or " +
                                           "left(quan_huyen,{0})=N'{1}' or " +
                                           "left(email,{0})=N'{1}' or " +
                                           "left(ngay_kich_hoat,{0})=N'{1}' or " +
                                           "left(goi_cuoc,{0})=N'{1}' or " +
                                           "left(dong_may,{0})=N'{1}' or " +
                                           "left(he_dieu_hanh,{0})=N'{1}' or " +
                                           "left(chuc_vu,{0})=N'{1}' or " +
                                           "left(cong_ty,{0})=N'{1}')"
                                           ,xxxx.Length ,xxxx);

            }
            else if (vitri == 1) {
                if(!Checked)
                    dk  = dk + string.Format(" didong like N'%{0}%' ",xxxx);
                else
                    dk = dk + string.Format(" left(didong,{0}) = N'{1}' ",xxxx.Length, xxxx);
            }
            else if (vitri == 2)
            {
                if (!Checked)
                    dk = dk + string.Format(" ten_khach_hang  like N'%{0}%' ", xxxx);
                else
                    dk = dk + string.Format(" left(ten_khach_hang,{0})=N'{1}' ", xxxx.Length, xxxx);
            }
            else if (vitri == 3)
            {
                if (!Checked)
                    dk = dk + string.Format(" phuong  like N'%{0}%' ", xxxx);
                else
                    dk = dk + string.Format(" left(phuong,{0})=N'{1}' ", xxxx.Length, xxxx);
            }
            else if (vitri == 4)
            {
                if (!Checked)
                    dk = dk + string.Format(" quan_huyen  like N'%{0}%' ", xxxx);
                else
                    dk = dk + string.Format(" left(quan_huyen,{0})=N'{1}' ", xxxx.Length, xxxx);
            }
            
            else if (vitri == 5) {
                if(!Checked)
                    dk = dk + string.Format(" dia_chi like N'%{0}%' ", xxxx);
                else
                    dk = dk + string.Format(" left(dia_chi,{0}) = N'{1}' ",xxxx.Length, xxxx);
            }
           
            else if (vitri == 6)
            {
                if(!Checked)
                    dk = dk + string.Format(" ngay like N'%{0}%' ", xxxx);
                else
                    dk = dk + string.Format(" left(ngay,{0}) = N'{1}' ",xxxx.Length, xxxx);
            }
            else if (vitri == 7)
            {
                if (!Checked)
                    dk = dk + string.Format(" thang like N'%{0}%' ", xxxx);
                else
                    dk = dk + string.Format(" left(thang,{0}) = N'{1}' ", xxxx.Length, xxxx);

            }
            else if (vitri == 8)
            {
                if (!Checked)
                    dk = dk + string.Format(" namsinh like N'%{0}%' ", xxxx);
                else
                    dk = dk + string.Format(" left(namsinh,{0}) = N'{1}' ", xxxx.Length, xxxx);
            }
            else if (vitri == 9)
            {
                if (!Checked)
                    dk = dk + string.Format(" email  like N'%{0}%' ", xxxx);
                else
                    dk = dk + string.Format(" left(email,{0})=N'{1}' ", xxxx.Length, xxxx);
            }
            else if (vitri == 10)
            {

                if (!Checked)
                    dk = dk + string.Format(" cuoc like N'%{0}%' ", xxxx);
                else
                    dk = dk + string.Format(" left(cuoc,{0}) = N'{1}' ", xxxx.Length, xxxx);
            }
            else if (vitri == 11)
            {
                if (!Checked)
                    dk = dk + string.Format(" gioi_tinh like N'%{0}%' ", xxxx);
                else
                    dk = dk + string.Format(" left(gioi_tinh,{0}) = N'{1}' ", xxxx.Length, xxxx);
            }
            else if (vitri == 12)
            {
                if (!Checked)
                    dk = dk + string.Format(" ngan_hang like N'%{0}%' ", xxxx);
                else
                    dk = dk + string.Format(" left(ngan_hang,{0}) = N'{1}' ", xxxx.Length, xxxx);
            }
            
            else if (vitri == 13)
            {
                if (!Checked)
                    dk = dk + string.Format(" sim like N'%{0}%' ", xxxx);
                else
                    dk = dk + string.Format(" left(sim,{0}) = N'{1}' ", xxxx.Length, xxxx);
            }
            else if (vitri == 14)
            {
                if (!Checked)
                    dk = dk + string.Format(" tinh like N'%{0}%' ", xxxx);
                else
                    dk = dk + string.Format(" left(tinh,{0}) = N'{1}' ", xxxx.Length, xxxx);
            }
             else if (vitri == 15)
            {
                if (!Checked)
                    dk = dk + string.Format(" tinh_cuoc like N'%{0}%' ", xxxx);
                else
                    dk = dk + string.Format(" left(tinh_cuoc,{0}) = N'{1}' ", xxxx.Length, xxxx);
            }
            else if (vitri == 16)
            {
                if (!Checked)
                    dk = dk + string.Format(" ngay_kich_hoat like N'%{0}%' ", xxxx);
                else
                    dk = dk + string.Format(" left(ngay_kich_hoat,{0}) = N'{1}' ", xxxx.Length, xxxx);
            }
            else if (vitri == 17)
            {
                if (!Checked)
                    dk = dk + string.Format(" goi_cuoc like N'%{0}%' ", xxxx);
                else
                    dk = dk + string.Format(" left(goi_cuoc,{0}) = N'{1}' ", xxxx.Length, xxxx);
            }
            else if (vitri == 18)
            {
                if (!Checked)
                    dk = dk + string.Format(" dong_may like N'%{0}%' ", xxxx);
                else
                    dk = dk + string.Format(" left(dong_may,{0}) = N'{1}' ", xxxx.Length, xxxx);
            }
            else if (vitri == 19)
            {
                if (!Checked)
                    dk = dk + string.Format(" he_dieu_hanh like N'%{0}%' ", xxxx);
                else
                    dk = dk + string.Format(" left(he_dieu_hanh,{0}) = N'{1}' ", xxxx.Length, xxxx);
            }
            else if (vitri == 20)
            {
                if (!Checked)
                    dk = dk + string.Format(" chuc_vu like N'%{0}%' ", xxxx);
                else
                    dk = dk + string.Format(" left(chuc_vu,{0}) = N'{1}' ", xxxx.Length, xxxx);
            }
            else if (vitri == 21)
            {
                if (!Checked)
                    dk = dk + string.Format(" cong_ty like N'%{0}%' ", xxxx);
                else
                    dk = dk + string.Format(" left(cong_ty,{0}) = N'{1}' ", xxxx.Length, xxxx);
            }
            else if (vitri == 22)
            {
                if (!Checked)
                    dk = dk + string.Format(" ghi_chu like N'%{0}%' ", xxxx);
                else
                    dk = dk + string.Format(" left(ghi_chu,{0}) = N'{1}' ", xxxx.Length, xxxx);
            }
            else if (vitri == 23)
            {
                if (!Checked)
                    dk = dk + string.Format(" filenguon like N'%{0}%' ", xxxx);
                else
                    dk = dk + string.Format(" left(filenguon,{0}) = N'{1}' ", xxxx.Length, xxxx);
            }

            return dk;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_Search1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(null, null);
            }
        }

        private void txt_Search2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(null, null);
            }
        }

        private void txt_Search3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(null, null);
            }
        }
    }
}
