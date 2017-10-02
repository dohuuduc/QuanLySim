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
    public partial class frmChang2 : Form {
        public frmChang2() {
            InitializeComponent();
        }

        

        private void button1_Click(object sender, EventArgs e) {
            PleaseWait objPleaseWait = new PleaseWait();
            try {
                if (checkedListBox1.CheckedItems.Count == 0) {
                    MessageBox.Show("Vui lòng chọn cột cần cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Bạn có chắc là cập nhật dữ liệu không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }
                objPleaseWait.Show();
                Application.DoEvents();
                foreach (var item in checkedListBox1.CheckedItems) {
                    string str = "update dienthoai_goc " +
                      " set para_1" +
                      " from dienthoai_new a inner join dienthoai_goc b on a.didong=b.didong" +
                      " para_2";
                    switch (item.ToString().ToLower()) {
                    case "tên khách hàng":
                    str = str.Replace("para_1", "ten_khach_hang=a.ten_khach_hang");
                    if (checkBox1.Checked)
                        str = str.Replace("para_2", "where b.ten_khach_hang is null or b.ten_khach_hang=''");
                    else
                        str = str.Replace("para_2", "");
                    break;
                    case "điạ chỉ":
                    str = str.Replace("para_1", "dia_chi=a.dia_chi");
                    if (checkBox1.Checked)
                        str = str.Replace("para_2", "where b.dia_chi is  null or  b.dia_chi=''");
                    else
                        str = str.Replace("para_2", "");
                    break;
                    case "phường":
                    str = str.Replace("para_1", "phuong=a.phuong");
                    if (checkBox1.Checked)
                        str = str.Replace("para_2", "where b.phuong is  null or  b.phuong=''");
                    else
                        str = str.Replace("para_2", "");
                    break;
                    case "quận huyện":
                    str = str.Replace("para_1", "quan_huyen=a.quan_huyen");
                    if (checkBox1.Checked)
                        str = str.Replace("para_2", "where b.quan_huyen is  null or  b.quan_huyen=''");
                    else
                        str = str.Replace("para_2", "");
                    break;
                    case "ngày":
                    str = str.Replace("para_1", "ngay=a.ngay");
                    if (checkBox1.Checked)
                        str = str.Replace("para_2", "where b.ngay is  null or  b.ngay=''");
                    else
                        str = str.Replace("para_2", "");
                    break;
                    case "tháng":
                    str = str.Replace("para_1", "thang=a.thang");
                    if (checkBox1.Checked)
                        str = str.Replace("para_2", "where b.thang is  null or b.thang=''");
                    else
                        str = str.Replace("para_2", "");
                    break;
                    case "năm sinh":
                    str = str.Replace("para_1", "namsinh=a.namsinh");
                    if (checkBox1.Checked)
                        str = str.Replace("para_2", "where b.namsinh is  null or b.namsinh=''");
                    else
                        str = str.Replace("para_2", "");
                    break;
                    case "email":
                    str = str.Replace("para_1", "email=a.email");
                    if (checkBox1.Checked)
                        str = str.Replace("para_2", "where b.email is  null or b.email=''");
                    else
                        str = str.Replace("para_2", "");
                    break;
                    case "ngân hàng":
                    str = str.Replace("para_1", "ngan_hang=a.ngan_hang");
                    if (checkBox1.Checked)
                        str = str.Replace("para_2", "where b.ngan_hang is  null or b.ngan_hang=''");
                    else
                        str = str.Replace("para_2", "");
                    break;
                    case "cước":
                    str = str.Replace("para_1", "cuoc=a.cuoc");
                    if (checkBox1.Checked)
                        str = str.Replace("para_2", "where b.cuoc is  null or b.cuoc=''");
                    else
                        str = str.Replace("para_2", "");
                        break;
                    case "sim":
                        str = str.Replace("para_1", "sim=a.sim");
                    if (checkBox1.Checked)
                        str = str.Replace("para_2", "where b.sim is  null or  b.sim=''");
                    else
                        str = str.Replace("para_2", "");
                        break;
                    case "giới tính":
                    str = str.Replace("para_1", " gioi_tinh=a.gioi_tinh");
                    if (checkBox1.Checked)
                        str = str.Replace("para_2", "where b.gioi_tinh is  null or b.gioi_tinh=''");
                    else
                        str = str.Replace("para_2", "");
                    break;
                    case "tỉnh":
                    str = str.Replace("para_1", "tinh=a.tinh");
                    if (checkBox1.Checked)
                        str = str.Replace("para_2", "where b.tinh is  null or b.tinh=''");
                    else
                        str = str.Replace("para_2", "");
                    break;
                    case "tỉnh cước":
                    str = str.Replace("para_1", "tinh_cuoc=a.tinh_cuoc");
                    if (checkBox1.Checked)
                        str = str.Replace("para_2", "where b.tinh_cuoc is  null or b.tinh_cuoc=''");
                    else
                        str = str.Replace("para_2", "");
                    break;
                    case "ghi chú":
                    str = str.Replace("para_1", "ghi_chu=a.ghi_chu");
                    if (checkBox1.Checked)
                        str = str.Replace("para_2", "where b.ghi_chu is  null or b.ghi_chu=''");
                    else
                        str = str.Replace("para_2", "");
                    break;
                    case "file nguồn":
                    str = str.Replace("para_1", "filenguon=a.filenguon");
                    if (checkBox1.Checked)
                        str = str.Replace("para_2", "where b.filenguon is  null or b.filenguon=''");
                    else
                        str = str.Replace("para_2", "");
                    break;
                    /*---------------------------------------*/
                    case "ngày kích hoạt":
                    str = str.Replace("para_1", "ngay_kich_hoat=a.ngay_kich_hoat");
                    if (checkBox1.Checked)
                        str = str.Replace("para_2", "where b.ngay_kich_hoat is  null or b.ngay_kich_hoat=''");
                    else
                        str = str.Replace("para_2", "");
                    break;
                    case "gói cước":
                    str = str.Replace("para_1", "goi_cuoc=a.goi_cuoc");
                    if (checkBox1.Checked)
                        str = str.Replace("para_2", "where b.goi_cuoc is  null or b.goi_cuoc=''");
                    else
                        str = str.Replace("para_2", "");
                    break;
                    case "dòng máy":
                    str = str.Replace("para_1", "dong_may=a.dong_may");
                    if (checkBox1.Checked)
                        str = str.Replace("para_2", "where b.dong_may is  null or b.dong_may=''");
                    else
                        str = str.Replace("para_2", "");
                    break;
                    case "hệ điều hành":
                    str = str.Replace("para_1", "he_dieu_hanh=a.he_dieu_hanh");
                    if (checkBox1.Checked)
                        str = str.Replace("para_2", "where b.he_dieu_hanh is  null or b.he_dieu_hanh=''");
                    else
                        str = str.Replace("para_2", "");
                    break;
                    case "chức vụ":
                    str = str.Replace("para_1", "chuc_vu=a.chuc_vu");
                    if (checkBox1.Checked)
                        str = str.Replace("para_2", "where b.chuc_vu is  null or b.chuc_vu=''");
                    else
                        str = str.Replace("para_2", "");
                    break;
                    case "công ty":
                    str = str.Replace("para_1", "cong_ty=a.cong_ty");
                    if (checkBox1.Checked)
                        str = str.Replace("para_2", "where b.cong_ty is  null or b.cong_ty=''");
                    else
                        str = str.Replace("para_2", "");
                    break;  
                    }
                    SQLDatabase.ExcNonQuery(str);
                    objPleaseWait.Close();
                }
                if (MessageBox.Show("Hoàn tất cập nhật, Bạn có muốn tiếp tục cập nhật không?", "Thông báo", MessageBoxButtons.YesNo,MessageBoxIcon.Question) != DialogResult.Yes) {
                    objPleaseWait.Close();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            } catch (Exception) {
                objPleaseWait.Close();
                throw;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            for (int x = 0; x < checkedListBox1.Items.Count; x++)
            {
                checkedListBox1.SetItemChecked(x, checkBox2.Checked);
            }

        }

        private void frmChang2_Load(object sender, EventArgs e)
        {
            for (int x = 0; x < checkedListBox1.Items.Count; x++)
            {
                checkedListBox1.SetItemChecked(x, checkBox2.Checked);
            }
        }
    }
}
