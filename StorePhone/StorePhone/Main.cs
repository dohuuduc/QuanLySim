using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace StorePhone
{
    public partial class Main : Form
    {
        private CachedData cachedData;

        public Main()
        {
            InitializeComponent();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        //----- Add ChargeDebtTelephone to Gridview
        private void BindingTelNumberToGridView()
        {
            try
            {
                groupBox_grid.Text = "Xem tất cả thuê bao";
                dataGrid_ListTelNumber.Rows.Clear();
                dataGrid_ListTelNumber.VirtualMode = true;

                //----- Create object to cache data from database
                cachedData = new CachedData();
                cachedData.LastRowIndex = -1;
                string CommandToGetCount = "";
                string CommandToGetData = "";
                switch (cbb_dieukien.SelectedIndex)
                {

                    case -1:
                    case 0:
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" :


                                                              string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where (ten_khach_hang like N'%{0}%' or didong like '%{0}%' or dia_chi like N'%{0}%' or sim like N'%{0}%' or tinh like N'%{0}%' or tinh_cuoc like N'%{0}%' or gioi_tinh like N'%{0}%' or ghi_chu like N'%{0}%'  or ngan_hang like N'%{0}%' or namsinh like N'%{0}%' or ngay like N'%{0}%' or thang like N'%{0}%') ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                        + " id,ten_khach_hang, didong,  dia_chi,ngay,thang, namsinh , cuoc,gioi_tinh,ngan_hang,   sim, tinh,tinh_cuoc, ghi_chu, filenguon,  (CONVERT(VARCHAR(10), CONVERT(DATETIME, creatdate),103) + ' ' + CONVERT(VARCHAR(8), CONVERT(DATETIME, creatdate),108)) as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where ten_khach_hang like N'%{0}%' or didong like '%{0}%' or dia_chi like N'%{0}%' or sim like N'%{0}%' or tinh like N'%{0}%' or tinh_cuoc like N'%{0}%' or gioi_tinh like N'%{0}%' or ghi_chu like N'%{0}%'  or ngan_hang like N'%{0}%' or namsinh like N'%{0}%' or ngay like N'%{0}%' or thang like N'%{0}%'", txt_Search.Text));
                        break;
                    case 1:/*di dong*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where didong like '%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                        + " id,ten_khach_hang, didong,  dia_chi,ngay,thang, namsinh, cuoc,gioi_tinh,ngan_hang,   sim, tinh,tinh_cuoc, ghi_chu, filenguon,  (CONVERT(VARCHAR(10), CONVERT(DATETIME, creatdate),103) + ' ' + CONVERT(VARCHAR(8), CONVERT(DATETIME, creatdate),108)) as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where didong like '%{0}%' ", txt_Search.Text));
                        break;
                    case 2:/*dia chi*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where dia_chi like N'%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                        + " id,ten_khach_hang, didong,  dia_chi,ngay,thang,  namsinh, cuoc,gioi_tinh,ngan_hang,   sim, tinh,tinh_cuoc, ghi_chu, filenguon,  (CONVERT(VARCHAR(10), CONVERT(DATETIME, creatdate),103) + ' ' + CONVERT(VARCHAR(8), CONVERT(DATETIME, creatdate),108)) as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where dia_chi like N'%{0}%' ", txt_Search.Text));
                        break;
                    case 3:/*"Tên khách hàng",*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where ten_khach_hang like N'%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                        + " id,ten_khach_hang, didong,  dia_chi,ngay,thang, namsinh, cuoc,gioi_tinh,ngan_hang,   sim, tinh,tinh_cuoc, ghi_chu, filenguon,  (CONVERT(VARCHAR(10), CONVERT(DATETIME, creatdate),103) + ' ' + CONVERT(VARCHAR(8), CONVERT(DATETIME, creatdate),108)) as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where ten_khach_hang like N'%{0}%' ", txt_Search.Text));
                        break;
                    case 4:/*Ngày*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where ngay like '%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                        + " id,ten_khach_hang, didong,  dia_chi,ngay,thang,  namsinh, cuoc,gioi_tinh,ngan_hang,   sim, tinh,tinh_cuoc, ghi_chu, filenguon,  (CONVERT(VARCHAR(10), CONVERT(DATETIME, creatdate),103) + ' ' + CONVERT(VARCHAR(8), CONVERT(DATETIME, creatdate),108)) as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where ngay like '%{0}%' ", txt_Search.Text));
                        break;
                    case 5:/*tháng*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where thang like '%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                        + " id,ten_khach_hang, didong,  dia_chi,ngay,thang, namsinh, cuoc,gioi_tinh,ngan_hang,   sim, tinh,tinh_cuoc, ghi_chu, filenguon,  (CONVERT(VARCHAR(10), CONVERT(DATETIME, creatdate),103) + ' ' + CONVERT(VARCHAR(8), CONVERT(DATETIME, creatdate),108)) as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where thang like '%{0}%' ", txt_Search.Text));
                        break;
                    case 6:/*Năm sinh*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where namsinh like '%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                        + " id,ten_khach_hang, didong,  dia_chi,ngay,thang,  namsinh, cuoc,gioi_tinh,ngan_hang,   sim, tinh,tinh_cuoc, ghi_chu, filenguon,  (CONVERT(VARCHAR(10), CONVERT(DATETIME, creatdate),103) + ' ' + CONVERT(VARCHAR(8), CONVERT(DATETIME, creatdate),108)) as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where namsinh like '%{0}%' ", txt_Search.Text));
                        break;
                    case 7:/*Ngân hàng*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where ngan_hang like N'%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                        + " id,ten_khach_hang, didong,  dia_chi,ngay,thang,  namsinh, cuoc,gioi_tinh,ngan_hang,   sim, tinh,tinh_cuoc, ghi_chu, filenguon,  (CONVERT(VARCHAR(10), CONVERT(DATETIME, creatdate),103) + ' ' + CONVERT(VARCHAR(8), CONVERT(DATETIME, creatdate),108)) as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where ngan_hang like N'%{0}%' ", txt_Search.Text));
                        break;
                    case 8:/*Cước*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where cuoc like '%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                        + " id,ten_khach_hang, didong,  dia_chi,ngay,thang,  namsinh, cuoc,gioi_tinh,ngan_hang,   sim, tinh,tinh_cuoc, ghi_chu, filenguon,  (CONVERT(VARCHAR(10), CONVERT(DATETIME, creatdate),103) + ' ' + CONVERT(VARCHAR(8), CONVERT(DATETIME, creatdate),108)) as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where cuoc like '%{0}%' ", txt_Search.Text));
                        break;
                    case 9:/*Sim*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where sim like N'%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                        + " id,ten_khach_hang, didong,  dia_chi,ngay,thang, CONVERT(VARCHAR(10),namsinh,103) as namsinh, cuoc,gioi_tinh,ngan_hang,   sim, tinh,tinh_cuoc, ghi_chu, filenguon,  (CONVERT(VARCHAR(10), CONVERT(DATETIME, creatdate),103) + ' ' + CONVERT(VARCHAR(8), CONVERT(DATETIME, creatdate),108)) as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where sim like N'%{0}%' ", txt_Search.Text));
                        break;
                    case 10:/*tinh cuoc*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where tinh_cuoc like N'%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                        + " id,ten_khach_hang, didong,  dia_chi,ngay,thang, namsinh, cuoc,gioi_tinh,ngan_hang,   sim, tinh,tinh_cuoc, ghi_chu, filenguon,  (CONVERT(VARCHAR(10), CONVERT(DATETIME, creatdate),103) + ' ' + CONVERT(VARCHAR(8), CONVERT(DATETIME, creatdate),108)) as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where tinh_cuoc like N'%{0}%' ", txt_Search.Text));
                        break;
                    case 11:/*tinh*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where tinh like N'%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                        + " id,ten_khach_hang, didong,  dia_chi,ngay,thang,  namsinh, cuoc,gioi_tinh,ngan_hang,   sim, tinh,tinh_cuoc, ghi_chu, filenguon,  (CONVERT(VARCHAR(10), CONVERT(DATETIME, creatdate),103) + ' ' + CONVERT(VARCHAR(8), CONVERT(DATETIME, creatdate),108)) as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where tinh like N'%{0}%' ", txt_Search.Text));
                        break;
                    case 12:/*filenguon*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where filenguon like N'%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                        + " id,ten_khach_hang, didong,  dia_chi,ngay,thang, namsinh, cuoc,gioi_tinh,ngan_hang,   sim, tinh,tinh_cuoc, ghi_chu, filenguon,  (CONVERT(VARCHAR(10), CONVERT(DATETIME, creatdate),103) + ' ' + CONVERT(VARCHAR(8), CONVERT(DATETIME, creatdate),108)) as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where filenguon like N'%{0}%' ", txt_Search.Text));
                        break;
                    default:
                        break;
                }



                cachedData.CommandToGetCount = CommandToGetCount;
                cachedData.CommandToGetData = CommandToGetData;

                cachedData.UpdateCachedData(0);
                dataGrid_ListTelNumber.RowCount = (int)cachedData.TotalRowCount;
                //----- value textbox
                GetValueTextbox();
                //----- Enabled button Edit,Delete
                EnabledButton();
                //----- Sum record
                String tongcongGoc = cachedData.TotalRowCount.ToString();


                groupBox_grid.Text = string.Format("Xem tất cả thuê bao :{0}", tongcongGoc);
                dataGrid_ListTelNumber.Focus();



                long totalRowCount = 0;
                /*====================================*/
                DataTable table2 = SQLDatabase.ExcDataTable("select COUNT(*) from dienthoai_goc");
                if (table2 != null && table2.Rows.Count > 0)
                    totalRowCount = long.Parse(table2.Rows[0][0].ToString());
                else
                    totalRowCount = 0;

                lb_goc.Text = totalRowCount.ToString("N0", CultureInfo.InvariantCulture);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "BindingTelNumberToGridView", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //----- get data to Gridview
        private void dataGrid_ListTelNumber_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            int indexRow;
            try
            {
                if (cachedData.CachedTable.Rows.Count <= 0) return;
                cachedData.UpdateCachedData(e.RowIndex);
                if (cachedData.CachedTable == null)
                    return;
                indexRow = e.RowIndex % cachedData.PageSize;
                e.Value = cachedData.CachedTable.Rows[indexRow][e.ColumnIndex];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DataGrid CellValueNeeded", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        private void dataGrid_ListTelNumber_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                GetValueTextbox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "dataGrid_ListTelNumber_MouseClick", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            BindingTelNumberToGridView();
            cbb_dieukien.Items.AddRange(new object[] {  "--- Tất cả ---", 
                                                        "Di động",
                                                        "Địa chỉ",
                                                        "Tên khách hàng",
                                                        "Ngày",
                                                        "Tháng",
                                                        "Năm sinh",
                                                        "Ngân hàng",
                                                        "Cước",
                                                        "Sim",
                                                        "Tỉnh cước",
                                                        "Tỉnh",
                                                        "Gới Tính",
                                                        "Ghi Chú",
                                                        "file nguồn"});
            cbb_dieukien.SelectedIndex = 0;

        }

        private void GetValueTextbox()
        {
            try
            {
                if (dataGrid_ListTelNumber.CurrentRow != null && dataGrid_ListTelNumber.CurrentRow.IsNewRow == false)
                {
                    txtid.Text = dataGrid_ListTelNumber.SelectedRows[0].Cells[1].Value.ToString();
                    txtTen_khach_hang.Text = dataGrid_ListTelNumber.SelectedRows[0].Cells[2].Value.ToString();
                    txtDidong.Text = dataGrid_ListTelNumber.SelectedRows[0].Cells[3].Value.ToString();
                    txtDia_Chi.Text = dataGrid_ListTelNumber.SelectedRows[0].Cells[4].Value.ToString();
                    txtNamSinh.Text = dataGrid_ListTelNumber.SelectedRows[0].Cells[7].Value.ToString();
                    txtCuoc.Text = dataGrid_ListTelNumber.SelectedRows[0].Cells[8].Value.ToString();
                    txt_gioitinh.Text = dataGrid_ListTelNumber.SelectedRows[0].Cells[9].Value.ToString();
                    txtNganHang.Text = dataGrid_ListTelNumber.SelectedRows[0].Cells[10].Value.ToString();
                    txtSim.Text = dataGrid_ListTelNumber.SelectedRows[0].Cells[11].Value.ToString();
                    txtTinh.Text = dataGrid_ListTelNumber.SelectedRows[0].Cells[12].Value.ToString();
                    txt_TinhCuoc.Text = dataGrid_ListTelNumber.SelectedRows[0].Cells[13].Value.ToString();
                    txtNguon.Text = dataGrid_ListTelNumber.SelectedRows[0].Cells[15].Value.ToString();


                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "GetValueTextbox", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //----- Enabled button Edit,Delete Group
        private void EnabledButton()
        {
            try
            {
                if (dataGrid_ListTelNumber.Rows.Count > 0)
                {
                    btn_Delete.Enabled = true;
                    btn_Update.Enabled = true;
                }
                else
                {
                    btn_Delete.Enabled = false;
                    btn_Update.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Enabled Button", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchTelNumber()
        {
            PleaseWait objPleaseWait = new PleaseWait();
            objPleaseWait.Show();
            Application.DoEvents();
            try
            {
               

                groupBox_grid.Text = "Kết quả tìm kiếm";
                dataGrid_ListTelNumber.Rows.Clear();
                dataGrid_ListTelNumber.VirtualMode = true;

                cachedData.LastRowIndex = -1;
                string CommandToGetCount = "";
                string CommandToGetData = "";
                switch (cbb_dieukien.SelectedIndex)
                {

                    case -1:
                    case 0:
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" :
                                                              string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where (ten_khach_hang like N'%{0}%' or didong like '%{0}%' or dia_chi like N'%{0}%' or sim like N'%{0}%' or tinh like N'%{0}%' or tinh_cuoc like N'%{0}%' or gioi_tinh like N'%{0}%' or ghi_chu like N'%{0}%'  or ngan_hang like N'%{0}%' or namsinh like N'%{0}%' or ngay like N'%{0}%' or thang like N'%{0}%') ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                        + " id,ten_khach_hang, didong,  dia_chi,ngay,thang, namsinh , cuoc,gioi_tinh,ngan_hang,   sim, tinh,tinh_cuoc, ghi_chu, filenguon,  (CONVERT(VARCHAR(10), CONVERT(DATETIME, creatdate),103) + ' ' + CONVERT(VARCHAR(8), CONVERT(DATETIME, creatdate),108)) as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where ten_khach_hang like N'%{0}%' or didong like '%{0}%' or dia_chi like N'%{0}%' or sim like N'%{0}%' or tinh like N'%{0}%' or tinh_cuoc like N'%{0}%' or gioi_tinh like N'%{0}%' or ghi_chu like N'%{0}%'  or ngan_hang like N'%{0}%' or namsinh like N'%{0}%' or ngay like N'%{0}%' or thang like N'%{0}%'", txt_Search.Text));
                        break;
                    case 1:/*di dong*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where didong like '%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                        + " id,ten_khach_hang, didong,  dia_chi,ngay,thang, namsinh, cuoc,gioi_tinh,ngan_hang,   sim, tinh,tinh_cuoc, ghi_chu, filenguon,  (CONVERT(VARCHAR(10), CONVERT(DATETIME, creatdate),103) + ' ' + CONVERT(VARCHAR(8), CONVERT(DATETIME, creatdate),108)) as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where didong like '%{0}%' ", txt_Search.Text));
                        break;
                    case 2:/*dia chi*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where dia_chi like N'%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                        + " id,ten_khach_hang, didong,  dia_chi,ngay,thang,  namsinh, cuoc,gioi_tinh,ngan_hang,   sim, tinh,tinh_cuoc, ghi_chu, filenguon,  (CONVERT(VARCHAR(10), CONVERT(DATETIME, creatdate),103) + ' ' + CONVERT(VARCHAR(8), CONVERT(DATETIME, creatdate),108)) as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where dia_chi like N'%{0}%' ", txt_Search.Text));
                        break;
                    case 3:/*"Tên khách hàng",*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where ten_khach_hang like N'%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                        + " id,ten_khach_hang, didong,  dia_chi,ngay,thang, namsinh, cuoc,gioi_tinh,ngan_hang,   sim, tinh,tinh_cuoc, ghi_chu, filenguon,  (CONVERT(VARCHAR(10), CONVERT(DATETIME, creatdate),103) + ' ' + CONVERT(VARCHAR(8), CONVERT(DATETIME, creatdate),108)) as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where ten_khach_hang like N'%{0}%' ", txt_Search.Text));
                        break;
                    case 4:/*Ngày*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where ngay like '%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                        + " id,ten_khach_hang, didong,  dia_chi,ngay,thang,  namsinh, cuoc,gioi_tinh,ngan_hang,   sim, tinh,tinh_cuoc, ghi_chu, filenguon,  (CONVERT(VARCHAR(10), CONVERT(DATETIME, creatdate),103) + ' ' + CONVERT(VARCHAR(8), CONVERT(DATETIME, creatdate),108)) as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where ngay like '%{0}%' ", txt_Search.Text));
                        break;
                    case 5:/*tháng*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where thang like '%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                        + " id,ten_khach_hang, didong,  dia_chi,ngay,thang, namsinh, cuoc,gioi_tinh,ngan_hang,   sim, tinh,tinh_cuoc, ghi_chu, filenguon,  (CONVERT(VARCHAR(10), CONVERT(DATETIME, creatdate),103) + ' ' + CONVERT(VARCHAR(8), CONVERT(DATETIME, creatdate),108)) as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where thang like '%{0}%' ", txt_Search.Text));
                        break;
                    case 6:/*Năm sinh*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where namsinh like '%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                        + " id,ten_khach_hang, didong,  dia_chi,ngay,thang,  namsinh, cuoc,gioi_tinh,ngan_hang,   sim, tinh,tinh_cuoc, ghi_chu, filenguon,  (CONVERT(VARCHAR(10), CONVERT(DATETIME, creatdate),103) + ' ' + CONVERT(VARCHAR(8), CONVERT(DATETIME, creatdate),108)) as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where namsinh like '%{0}%' ", txt_Search.Text));
                        break;
                    case 7:/*Ngân hàng*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where ngan_hang like N'%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                        + " id,ten_khach_hang, didong,  dia_chi,ngay,thang,  namsinh, cuoc,gioi_tinh,ngan_hang,   sim, tinh,tinh_cuoc, ghi_chu, filenguon,  (CONVERT(VARCHAR(10), CONVERT(DATETIME, creatdate),103) + ' ' + CONVERT(VARCHAR(8), CONVERT(DATETIME, creatdate),108)) as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where ngan_hang like N'%{0}%' ", txt_Search.Text));
                        break;
                    case 8:/*Cước*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where cuoc like '%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                        + " id,ten_khach_hang, didong,  dia_chi,ngay,thang,  namsinh, cuoc,gioi_tinh,ngan_hang,   sim, tinh,tinh_cuoc, ghi_chu, filenguon,  (CONVERT(VARCHAR(10), CONVERT(DATETIME, creatdate),103) + ' ' + CONVERT(VARCHAR(8), CONVERT(DATETIME, creatdate),108)) as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where cuoc like '%{0}%' ", txt_Search.Text));
                        break;
                    case 9:/*Sim*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where sim like N'%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                        + " id,ten_khach_hang, didong,  dia_chi,ngay,thang, CONVERT(VARCHAR(10),namsinh,103) as namsinh, cuoc,gioi_tinh,ngan_hang,   sim, tinh,tinh_cuoc, ghi_chu, filenguon,  (CONVERT(VARCHAR(10), CONVERT(DATETIME, creatdate),103) + ' ' + CONVERT(VARCHAR(8), CONVERT(DATETIME, creatdate),108)) as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where sim like N'%{0}%' ", txt_Search.Text));
                        break;
                    case 10:/*tinh cuoc*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where tinh_cuoc like N'%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                        + " id,ten_khach_hang, didong,  dia_chi,ngay,thang, namsinh, cuoc,gioi_tinh,ngan_hang,   sim, tinh,tinh_cuoc, ghi_chu, filenguon,  (CONVERT(VARCHAR(10), CONVERT(DATETIME, creatdate),103) + ' ' + CONVERT(VARCHAR(8), CONVERT(DATETIME, creatdate),108)) as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where tinh_cuoc like N'%{0}%' ", txt_Search.Text));
                        break;
                    case 11:/*tinh*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where tinh like N'%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                        + " id,ten_khach_hang, didong,  dia_chi,ngay,thang,  namsinh, cuoc,gioi_tinh,ngan_hang,   sim, tinh,tinh_cuoc, ghi_chu, filenguon,  (CONVERT(VARCHAR(10), CONVERT(DATETIME, creatdate),103) + ' ' + CONVERT(VARCHAR(8), CONVERT(DATETIME, creatdate),108)) as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where tinh like N'%{0}%' ", txt_Search.Text));
                        break;
                    case 12:/*gioi tinh*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where gioi_tinh like N'%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                        + " id,ten_khach_hang, didong,  dia_chi,ngay,thang,  namsinh, cuoc,gioi_tinh,ngan_hang,   sim, tinh,tinh_cuoc, ghi_chu, filenguon,  (CONVERT(VARCHAR(10), CONVERT(DATETIME, creatdate),103) + ' ' + CONVERT(VARCHAR(8), CONVERT(DATETIME, creatdate),108)) as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where gioi_tinh like N'%{0}%' ", txt_Search.Text));
                        break;
                    case 13:/*ghi_chu*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where ghi_chu like N'%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                        + " id,ten_khach_hang, didong,  dia_chi,ngay,thang,  namsinh, cuoc,gioi_tinh,ngan_hang,   sim, tinh,tinh_cuoc, ghi_chu, filenguon,  (CONVERT(VARCHAR(10), CONVERT(DATETIME, creatdate),103) + ' ' + CONVERT(VARCHAR(8), CONVERT(DATETIME, creatdate),108)) as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where ghi_chu like N'%{0}%' ", txt_Search.Text));
                        break;
                    case 14:/*filenguon*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where filenguon like N'%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                        + " id,ten_khach_hang, didong,  dia_chi,ngay,thang, namsinh, cuoc,gioi_tinh,ngan_hang,   sim, tinh,tinh_cuoc, ghi_chu, filenguon,  (CONVERT(VARCHAR(10), CONVERT(DATETIME, creatdate),103) + ' ' + CONVERT(VARCHAR(8), CONVERT(DATETIME, creatdate),108)) as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where filenguon like N'%{0}%' ", txt_Search.Text));
                        break;
                    default:
                        break;
                }


                cachedData.CommandToGetCount = CommandToGetCount;
                cachedData.CommandToGetData = CommandToGetData;
                cachedData.UpdateCachedData(0);
                dataGrid_ListTelNumber.RowCount = (int)cachedData.TotalRowCount;

               

                //----- Enabled button Edit,Delete
                EnabledButton();

                //----- Sum record
                String tongcongGoc = cachedData.TotalRowCount.ToString();

                groupBox_grid.Text = string.Format("Xem tất cả thuê bao :{0}", tongcongGoc);
                dataGrid_ListTelNumber.Focus();

                //----- Sum record
                //txt_Sum.Text = cachedData.TotalRowCount.ToString();
                dataGrid_ListTelNumber.Focus();
                objPleaseWait.Close();
                if (cachedData.TotalRowCount <= 0)
                {
                    MessageBox.Show("Không tìm thấy số điện thoại nào với từ khóa : " + txt_Search.Text, "Tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                objPleaseWait.Close();
                MessageBox.Show(ex.Message, "Search TelNumber" ,MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            PleaseWait objPleaseWait = new PleaseWait();
            objPleaseWait.Show();
            Application.DoEvents();

            try
            {
                BindingTelNumberToGridView();
                objPleaseWait.Close();
            }
            catch (Exception ex)
            {
                objPleaseWait.Close();
                MessageBox.Show(ex.Message, "btn_Refresh_Click" ,MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btn_Update_Click(object sender, EventArgs e)
        {
            //TelNumberChange telNumber;
            DataGridViewRow updatedRow;
            int indexRow;
            string sqlcommand;
            object hasValue;

            try
            {

                if (dataGrid_ListTelNumber.SelectedRows.Count < 1)
                    return;
                updatedRow = dataGrid_ListTelNumber.SelectedRows[0];
                if (updatedRow == null || updatedRow.IsNewRow == true)
                    return;

                if (string.IsNullOrEmpty(txtDidong.Text))
                {
                    MessageBox.Show("Bạn chưa nhập 'số di động'", "Cap nhat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (Utilities.CheckNumberEnterKey(txtDidong.Text) == false)
                {
                    MessageBox.Show("Khong dung format 'số di động'", "Cap nhat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                   

                    sqlcommand = string.Format("SELECT 1 FROM dienthoai_goc WHERE didong='{0}' and id <>'{1}'", txtDidong.Text.Trim(), txtid.Text);
                    hasValue = SQLDatabase.ExcScalar(sqlcommand);
                    if (hasValue != null)
                    {
                        MessageBox.Show("Số điện thoại  '" + txtDidong.Text + "' đã tồn tại. Không thể cập nhật", "Cap nhat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        //----- Test has key update value (OldTelNumber)
                        dienthoai_new model     = new dienthoai_new();
                        model.id                = Convert.ToInt32(txtid.Text);
                        model.ten_khach_hang    = txtTen_khach_hang.Text;
                        model.dia_chi           = txtDia_Chi.Text;
                        model.didong            = txtDidong.Text;
                        model.tinh              = txtTinh.Text;
                        model.namsinh           = txtNamSinh.Text;
                        model.ngan_hang         = txtNganHang.Text;
                        model.cuoc              = txtCuoc.Text;
                        model.sim               = txtSim.Text;
                        model.tinh_cuoc         = txt_TinhCuoc.Text;
                        model.gioi_tinh         = txt_gioitinh.Text;

                        //----- Update TelNumberChange into Database
                        if (!SQLDatabase.UpdateDienThoaiNEW(model))
                        {
                            MessageBox.Show("Lỗi trong khi cập nhật số điện thoại", "Cap nhat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            //----- Add log
                            //Utilities.Database.AddActionLog(SQLDatabase.SQLDatabase.empID, "ChangeTel", "Số cũ: " + txt_OldTelNumber.Text.Trim() + ", số mới (trước: " + updatedRow.Cells[1].Value.ToString() + ", sau cập nhật: " + txt_NewTelNumber.Text.Trim() + ")", DateTime.Now, 2);

                            if (dataGrid_ListTelNumber.VirtualMode == false)
                            {
                                updatedRow.Cells[1].Value = txtDidong.Text.Trim();
                            }
                            else
                            {
                                indexRow = updatedRow.Index;
                                cachedData.LastRowIndex = -1;
                                cachedData.UpdateCachedData(indexRow);
                                dataGrid_ListTelNumber.Refresh();
                                if (!updatedRow.Displayed)
                                    dataGrid_ListTelNumber.FirstDisplayedScrollingRowIndex = indexRow;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "btn_Update_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        private void DeleteTelNumber()
        {
          
            int indexRowDisplay = -1;
            DataGridViewRow[] selectedRows;
            SortDataGridViewRow sort;
            object countData;
            int soluongchon = 0;
            PleaseWait objPleaseWait = new PleaseWait();
            try
            {
                if (dataGrid_ListTelNumber.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("Bạn chắc chắn muốn xóa " + dataGrid_ListTelNumber.SelectedRows.Count.ToString() + " Số điện thoại này ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                    soluongchon = dataGrid_ListTelNumber.SelectedRows.Count;
                    if (soluongchon >= 10)
                    {
                        
                        
                        objPleaseWait.Show();
                        Application.DoEvents();
                    }
                   
                   

                    selectedRows = new DataGridViewRow[dataGrid_ListTelNumber.SelectedRows.Count];
                    dataGrid_ListTelNumber.SelectedRows.CopyTo(selectedRows, 0);
                    sort = new SortDataGridViewRow();
                    Array.Sort(selectedRows, sort);


                    foreach (DataGridViewRow row in selectedRows)
                    {
                        if (row.Displayed)
                        {
                            indexRowDisplay = row.Index - 1;
                        }
                        //----- Delete from database
                      
                        if (SQLDatabase.ExcNonQuery("Delete from dienthoai_goc where id='" + row.Cells[1].Value.ToString() + "'") == false)
                        {
                            MessageBox.Show("Lỗi xóa điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            //http://www.aspdotnet-pools.com/2014/09/splash-screen-with-please-wait-or.html
                            //https://app.box.com/s/7x1bdzf4m0uq26fsxune
                            //----- Add log
                           // Utilities.Database.AddActionLog(SQLDatabase.SQLDatabase.empID, "ChangeTel", "Số cũ: " + row.Cells[0].Value.ToString() + " - số mới: " + row.Cells[1].Value.ToString(), DateTime.Now, 3);
                            if (dataGrid_ListTelNumber.VirtualMode == false)
                            {
                                dataGrid_ListTelNumber.Rows.Remove(row);
                            }
                        }
                    }

                    //----- Update Gridview
                    if (dataGrid_ListTelNumber.VirtualMode == true)
                    {
                        countData = SQLDatabase.ExcScalar("Select Count(*) from dienthoai_goc");

                        if (indexRowDisplay == -1 || ((int)countData) < indexRowDisplay)
                            indexRowDisplay = 0;

                        cachedData.LastRowIndex = -1;
                        cachedData.UpdateCachedData(indexRowDisplay);
                        dataGrid_ListTelNumber.RowCount = (int)cachedData.TotalRowCount;
                        foreach (DataGridViewRow row in dataGrid_ListTelNumber.SelectedRows)
                        {
                            row.Selected = false;
                        }
                        if (indexRowDisplay < dataGrid_ListTelNumber.RowCount)
                        {
                            dataGrid_ListTelNumber.Rows[indexRowDisplay].Selected = true;
                        }
                        else
                        {
                            if (dataGrid_ListTelNumber.RowCount > 0)
                                dataGrid_ListTelNumber.Rows[dataGrid_ListTelNumber.RowCount - 1].Selected = true;
                        }

                        dataGrid_ListTelNumber.Refresh();
                    }
                    if (soluongchon >= 10) {
                        objPleaseWait.Close();
                    }
                    
                    //----- value textbox
                    GetValueTextbox();
                    //----- Enabled button Edit,Delete
                    EnabledButton();
                    //----- Sum record
                    //txt_Sum.Text = dataGrid_ListTelNumber.RowCount.ToString();
                }
            }
            catch (Exception ex)
            {
                //if (dlgWaitProcess != null)
                //    dlgWaitProcess.Close();
                MessageBox.Show(ex.Message, "DeleteTelNumber", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            SearchTelNumber();
        }

        private void txt_Search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                SearchTelNumber();
            }
        }

        private void dataGrid_ListTelNumber_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Delete)
                {
                    DeleteTelNumber();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "dataGrid_ListTelNumber_KeyDown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void xoaSoDienThoaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteTelNumber();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ToolStripMenuItem_Delete_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteTelNumber();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ToolStripMenuItem_Delete_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button9_Click(object sender, EventArgs e)
        {
            PleaseWait objPleaseWait = null;
            try
            {
                frmImport frm = new frmImport();
                if (frm.ShowDialog() == DialogResult.OK) {
                    objPleaseWait = new PleaseWait();
                    objPleaseWait.Show();
                    Application.DoEvents();

                    BindingTelNumberToGridView();

                    objPleaseWait.Close();
                }
            }
            catch (Exception)
            {
                objPleaseWait.Close();
                throw;
            }
        }

        private void xuấtFileNguồnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
            frmChange3 frm = new frmChange3();
            frm.ShowDialog();
             * */
            ExcelAdapter excel = new ExcelAdapter("");
            excel.SFilePath=@"d:\exce.xls";
            excel.CreateAndWrite(GetTable(), "ErrorImport", 1);

        }
        static DataTable GetTable()
        {
            // Here we create a DataTable with four columns.
            DataTable table = new DataTable();
            table.Columns.Add("Dosage", typeof(int));
            table.Columns.Add("Drug", typeof(string));
            table.Columns.Add("Patient", typeof(string));
            table.Columns.Add("Date", typeof(DateTime));

            // Here we add five DataRows.
            table.Rows.Add(25, "Indocin", "David", DateTime.Now);
            table.Rows.Add(50, "Enebrel", "Sam", DateTime.Now);
            table.Rows.Add(10, "Hydralazine", "Christoff", DateTime.Now);
            table.Rows.Add(21, "Combivent", "Janet", DateTime.Now);
            table.Rows.Add(100, "Dilantin", "Melanie", DateTime.Now);
            return table;
        }

        private void button6_Click(object sender, EventArgs e)
        {
           
            frmChange3 frm = new frmChange3();
            frm.Selectindex = cbb_dieukien.SelectedIndex;
            frm.Search = txt_Search.Text;
            frm.ShowDialog();
                
        }

        private void backupDữLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmBackup frm = new frmBackup();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    BindingTelNumberToGridView();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void xoáDữLiệuHệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PleaseWait objPleaseWait = new PleaseWait();
            try
            {
                if (MessageBox.Show("Bạn có chắc muốn xoá tất cả dữ liệu gốc và nguồn không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    objPleaseWait.Show();
                    Application.DoEvents();
                    if(SQLDatabase.ExcNonQuery("[spDelGoc]")){
                        MessageBox.Show("Xoá xong dữ liệu gốc và dữ liệu tạm","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        BindingTelNumberToGridView();
                    } 
                    objPleaseWait.Close();
                }
            }
            catch (Exception ex)
            {
                 objPleaseWait.Close();
                 MessageBox.Show(ex.Message, "xoáDữLiệuHệThốngToolStripMenuItem_Click");
            }
        }

        private void xoáDữLiệuBảngTạmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PleaseWait objPleaseWait = new PleaseWait();
            try
            {
                if (MessageBox.Show("Bạn có chắc muốn xoá tất cả dữ liệu bảng tạm không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    objPleaseWait.Show();
                    Application.DoEvents();
                    if (SQLDatabase.ExcNonQuery("[spDelTam]"))
                    {
                        MessageBox.Show("Xoá xong tất dữ liệu tạm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BindingTelNumberToGridView();
                    }
                    objPleaseWait.Close();
                }
            }
            catch (Exception ex)
            {
                objPleaseWait.Close();
                MessageBox.Show(ex.Message, "xoáDữLiệuBảngTạmToolStripMenuItem_Click");
            }
        }
        
    }
}
