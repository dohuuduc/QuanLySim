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
                    str = str.Replace("para_1", "cuoc=a.sim");
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
                    str = str.Replace("para_1", "tinh=a.tinh_cuoc");
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
    }
}
