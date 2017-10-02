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
        private string _strDatabase;

        public Main()
        {
            InitializeComponent();
           
        }

        private string tukhoaSearch;
       

        private void SoLuongKhachHang() {
            DataTable tb = SQLDatabase.ExcDataTable(string.Format("select count(*) from dienthoai_goc"));
            groupBox2.Text = string.Format("Thông Tin: {0}",ConvertType.ToInt(tb.Rows[0][0]));
        }
        //----- Add ChargeDebtTelephone to Gridview
        private void BindingTelNumberToGridView()
        {
            try
            {
                groupBox_grid.Text = "Xem Tất Cả Khách Hàng";
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


                                           string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where (ten_khach_hang like N'%{0}%' or didong like '%{0}%' or dia_chi like N'%{0}%' or sim like N'%{0}%' or tinh like N'%{0}%' or tinh_cuoc like N'%{0}%' or gioi_tinh like N'%{0}%' or ghi_chu like N'%{0}%'  or ngan_hang like N'%{0}%' or namsinh like N'%{0}%' or ngay like N'%{0}%' or thang like N'%{0}%' or   ghi_chu like N'%{0}%'  or   filenguon like N'%{0}%'  or   phuong like N'%{0}%' or   quan_huyen like N'%{0}%'  or   email like N'%{0}%' or ngay_kich_hoat like N'%{0}%'  or goi_cuoc like N'%{0}%'  or dong_may like N'%{0}%' or he_dieu_hanh like N'%{0}%' or chuc_vu like N'%{0}%'  or cong_ty like N'%{0}%' ) ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                         + " id, didong,ten_khach_hang,phuong,quan_huyen,dia_chi,ngay,thang,  namsinh,email, cuoc,gioi_tinh,ngan_hang,sim, tinh,tinh_cuoc,ngay_kich_hoat,goi_cuoc,dong_may,he_dieu_hanh,chuc_vu,cong_ty, ghi_chu, filenguon,  creatdate as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where ten_khach_hang like N'%{0}%' or didong like '%{0}%' or dia_chi like N'%{0}%' or sim like N'%{0}%' or tinh like N'%{0}%' or tinh_cuoc like N'%{0}%' or gioi_tinh like N'%{0}%' or ghi_chu like N'%{0}%'  or ngan_hang like N'%{0}%' or namsinh like N'%{0}%' or ngay like N'%{0}%' or thang like N'%{0}%' or   ghi_chu like N'%{0}%'  or   filenguon like N'%{0}%'  or   phuong like N'%{0}%' or   quan_huyen like N'%{0}%'  or   email like N'%{0}%' or ngay_kich_hoat like N'%{0}%'  or goi_cuoc like N'%{0}%'  or dong_may like N'%{0}%' or he_dieu_hanh like N'%{0}%' or chuc_vu like N'%{0}%'  or cong_ty like N'%{0}%'", txt_Search.Text));
                        break;
                    case 1:/*di dong*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where didong like '%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                         + " id, didong,ten_khach_hang,phuong,quan_huyen,dia_chi,ngay,thang,  namsinh,email, cuoc,gioi_tinh,ngan_hang,sim, tinh,tinh_cuoc,ngay_kich_hoat,goi_cuoc,dong_may,he_dieu_hanh,chuc_vu,cong_ty, ghi_chu, filenguon,  creatdate as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where didong like '%{0}%' ", txt_Search.Text));
                        break;
                    case 2:/*"Tên khách hàng",*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where ten_khach_hang like N'%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                         + " id, didong,ten_khach_hang,phuong,quan_huyen,dia_chi,ngay,thang,  namsinh,email, cuoc,gioi_tinh,ngan_hang,sim, tinh,tinh_cuoc,ngay_kich_hoat,goi_cuoc,dong_may,he_dieu_hanh,chuc_vu,cong_ty, ghi_chu, filenguon,  creatdate as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where ten_khach_hang like N'%{0}%' ", txt_Search.Text));
                        break;
                    case 3:/*"Phuong",*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where phuong like N'%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                         + " id, didong,ten_khach_hang,phuong,quan_huyen,dia_chi,ngay,thang,  namsinh,email, cuoc,gioi_tinh,ngan_hang,sim, tinh,tinh_cuoc,ngay_kich_hoat,goi_cuoc,dong_may,he_dieu_hanh,chuc_vu,cong_ty, ghi_chu, filenguon,  creatdate as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where phuong like N'%{0}%' ", txt_Search.Text));
                        break;
                    case 4:/*"Quan",*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where quan_huyen like N'%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                         + " id, didong,ten_khach_hang,phuong,quan_huyen,dia_chi,ngay,thang,  namsinh,email, cuoc,gioi_tinh,ngan_hang,sim, tinh,tinh_cuoc,ngay_kich_hoat,goi_cuoc,dong_may,he_dieu_hanh,chuc_vu,cong_ty, ghi_chu, filenguon,  creatdate as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where quan_huyen like N'%{0}%' ", txt_Search.Text));
                        break;
                    case 5:/*dia chi*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where dia_chi like N'%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                         + " id, didong,ten_khach_hang,phuong,quan_huyen,dia_chi,ngay,thang,  namsinh,email, cuoc,gioi_tinh,ngan_hang,sim, tinh,tinh_cuoc,ngay_kich_hoat,goi_cuoc,dong_may,he_dieu_hanh,chuc_vu,cong_ty, ghi_chu, filenguon,  creatdate as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where dia_chi like N'%{0}%' ", txt_Search.Text));
                        break;

                    case 6:/*Ngày*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where ngay like N'%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                        + " id, didong,ten_khach_hang,phuong,quan_huyen,dia_chi,ngay,thang,  namsinh,email, cuoc,gioi_tinh,ngan_hang,sim, tinh,tinh_cuoc,ngay_kich_hoat,goi_cuoc,dong_may,he_dieu_hanh,chuc_vu,cong_ty, ghi_chu, filenguon,  creatdate as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where ngay like N'%{0}%' ", txt_Search.Text));
                        break;
                    case 7:/*tháng*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where thang like N'%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                        + " id, didong,ten_khach_hang,phuong,quan_huyen,dia_chi,ngay,thang,  namsinh,email, cuoc,gioi_tinh,ngan_hang,sim, tinh,tinh_cuoc,ngay_kich_hoat,goi_cuoc,dong_may,he_dieu_hanh,chuc_vu,cong_ty, ghi_chu, filenguon,  creatdate as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where thang like N'%{0}%' ", txt_Search.Text));
                        break;
                    case 8:/*Năm sinh*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where namsinh like N'%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                        + " id, didong,ten_khach_hang,phuong,quan_huyen,dia_chi,ngay,thang,  namsinh,email, cuoc,gioi_tinh,ngan_hang,sim, tinh,tinh_cuoc,ngay_kich_hoat,goi_cuoc,dong_may,he_dieu_hanh,chuc_vu,cong_ty, ghi_chu, filenguon,  creatdate as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where namsinh like N'%{0}%' ", txt_Search.Text));
                        break;
                    case 9:/*email*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where email like N'%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                        + " id, didong,ten_khach_hang,phuong,quan_huyen,dia_chi,ngay,thang,  namsinh,email, cuoc,gioi_tinh,ngan_hang,sim, tinh,tinh_cuoc,ngay_kich_hoat,goi_cuoc,dong_may,he_dieu_hanh,chuc_vu,cong_ty, ghi_chu, filenguon,  creatdate as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where email like N'%{0}%' ", txt_Search.Text));
                        break;
                    case 10:/*Cước*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where cuoc like N'%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                        + " id, didong,ten_khach_hang,phuong,quan_huyen,dia_chi,ngay,thang,  namsinh,email, cuoc,gioi_tinh,ngan_hang,sim, tinh,tinh_cuoc,ngay_kich_hoat,goi_cuoc,dong_may,he_dieu_hanh,chuc_vu,cong_ty, ghi_chu, filenguon,  creatdate as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where cuoc like N'%{0}%' ", txt_Search.Text));
                        break;
                    case 11:/*gioitinh*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where gioi_tinh like N'%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                        + " id, didong,ten_khach_hang,phuong,quan_huyen,dia_chi,ngay,thang,  namsinh,email, cuoc,gioi_tinh,ngan_hang,sim, tinh,tinh_cuoc,ngay_kich_hoat,goi_cuoc,dong_may,he_dieu_hanh,chuc_vu,cong_ty, ghi_chu, filenguon,  creatdate as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where gioi_tinh like N'%{0}%' ", txt_Search.Text));
                        break;
                    case 12:/*Ngân hàng*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where ngan_hang like N'%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                        + " id, didong,ten_khach_hang,phuong,quan_huyen,dia_chi,ngay,thang,  namsinh,email, cuoc,gioi_tinh,ngan_hang,sim, tinh,tinh_cuoc,ngay_kich_hoat,goi_cuoc,dong_may,he_dieu_hanh,chuc_vu,cong_ty, ghi_chu, filenguon,  creatdate as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where ngan_hang like N'%{0}%' ", txt_Search.Text));
                        break;

                    case 13:/*Sim*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where sim like N'%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                        + " id, didong,ten_khach_hang,phuong,quan_huyen,dia_chi,ngay,thang,  namsinh,email, cuoc,gioi_tinh,ngan_hang,sim, tinh,tinh_cuoc,ngay_kich_hoat,goi_cuoc,dong_may,he_dieu_hanh,chuc_vu,cong_ty, ghi_chu, filenguon,  creatdate as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where sim like N'%{0}%' ", txt_Search.Text));
                        break;
                    case 14:/*tinh*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where tinh like N'%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                        + " id, didong,ten_khach_hang,phuong,quan_huyen,dia_chi,ngay,thang,  namsinh,email, cuoc,gioi_tinh,ngan_hang,sim, tinh,tinh_cuoc,ngay_kich_hoat,goi_cuoc,dong_may,he_dieu_hanh,chuc_vu,cong_ty, ghi_chu, filenguon,  creatdate as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where tinh like N'%{0}%' ", txt_Search.Text));
                        break;

                    case 15:/*tinh cuoc*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where tinh_cuoc like N'%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                        + " id, didong,ten_khach_hang,phuong,quan_huyen,dia_chi,ngay,thang,  namsinh,email, cuoc,gioi_tinh,ngan_hang,sim, tinh,tinh_cuoc,ngay_kich_hoat,goi_cuoc,dong_may,he_dieu_hanh,chuc_vu,cong_ty, ghi_chu, filenguon,  creatdate as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where tinh_cuoc like N'%{0}%' ", txt_Search.Text));
                        break;
                    case 16:/*ngay_kich_hoat*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where ngay_kich_hoat like N'%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                        + " id, didong,ten_khach_hang,phuong,quan_huyen,dia_chi,ngay,thang,  namsinh,email, cuoc,gioi_tinh,ngan_hang,sim, tinh,tinh_cuoc,ngay_kich_hoat,goi_cuoc,dong_may,he_dieu_hanh,chuc_vu,cong_ty, ghi_chu, filenguon,  creatdate as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where ngay_kich_hoat like N'%{0}%' ", txt_Search.Text));
                        break;
                    case 17:/*goi_cuoc*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where goi_cuoc like N'%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                        + " id, didong,ten_khach_hang,phuong,quan_huyen,dia_chi,ngay,thang,  namsinh,email, cuoc,gioi_tinh,ngan_hang,sim, tinh,tinh_cuoc,ngay_kich_hoat,goi_cuoc,dong_may,he_dieu_hanh,chuc_vu,cong_ty, ghi_chu, filenguon,  creatdate as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where goi_cuoc like N'%{0}%' ", txt_Search.Text));
                        break;
                    case 18:/*dong_may*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where dong_may like N'%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                        + " id, didong,ten_khach_hang,phuong,quan_huyen,dia_chi,ngay,thang,  namsinh,email, cuoc,gioi_tinh,ngan_hang,sim, tinh,tinh_cuoc,ngay_kich_hoat,goi_cuoc,dong_may,he_dieu_hanh,chuc_vu,cong_ty, ghi_chu, filenguon,  creatdate as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where dong_may like N'%{0}%' ", txt_Search.Text));
                        break;
                    case 19:/*he_dieu_hanh*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where he_dieu_hanh like N'%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                        + " id, didong,ten_khach_hang,phuong,quan_huyen,dia_chi,ngay,thang,  namsinh,email, cuoc,gioi_tinh,ngan_hang,sim, tinh,tinh_cuoc,ngay_kich_hoat,goi_cuoc,dong_may,he_dieu_hanh,chuc_vu,cong_ty, ghi_chu, filenguon,  creatdate as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where he_dieu_hanh like N'%{0}%' ", txt_Search.Text));
                        break;
                    case 20:/*chuc_vu*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where chuc_vu like N'%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                        + " id, didong,ten_khach_hang,phuong,quan_huyen,dia_chi,ngay,thang,  namsinh,email, cuoc,gioi_tinh,ngan_hang,sim, tinh,tinh_cuoc,ngay_kich_hoat,goi_cuoc,dong_may,he_dieu_hanh,chuc_vu,cong_ty, ghi_chu, filenguon,  creatdate as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where chuc_vu like N'%{0}%' ", txt_Search.Text));
                        break;
                    case 21:/*cong_ty*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where cong_ty like N'%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                        + " id, didong,ten_khach_hang,phuong,quan_huyen,dia_chi,ngay,thang,  namsinh,email, cuoc,gioi_tinh,ngan_hang,sim, tinh,tinh_cuoc,ngay_kich_hoat,goi_cuoc,dong_may,he_dieu_hanh,chuc_vu,cong_ty, ghi_chu, filenguon,  creatdate as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where cong_ty like N'%{0}%' ", txt_Search.Text));
                        break;
                    case 22:/*ghi chú*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where ghi_chu like N'%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                        + " id, didong,ten_khach_hang,phuong,quan_huyen,dia_chi,ngay,thang,  namsinh,email, cuoc,gioi_tinh,ngan_hang,sim, tinh,tinh_cuoc,ngay_kich_hoat,goi_cuoc,dong_may,he_dieu_hanh,chuc_vu,cong_ty, ghi_chu, filenguon,  creatdate as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where ghi_chu like N'%{0}%' ", txt_Search.Text));
                        break;
                    case 23:/*filenguon*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where filenguon like N'%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                        + " id, didong,ten_khach_hang,phuong,quan_huyen,dia_chi,ngay,thang,  namsinh,email, cuoc,gioi_tinh,ngan_hang,sim, tinh,tinh_cuoc,ngay_kich_hoat,goi_cuoc,dong_may,he_dieu_hanh,chuc_vu,cong_ty, ghi_chu, filenguon,  creatdate as createdate "
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


                groupBox_grid.Text = string.Format("Xem Tất Cả Khách Hàng :{0}", tongcongGoc);
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
            PleaseWait objPleaseWait = new PleaseWait();
            objPleaseWait.Show();
            Application.DoEvents();

            //BindingTelNumberToGridView();
            SoLuongKhachHang();
            cbb_dieukien.Items.AddRange(new object[] {  "--- Tất cả ---", 
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
                                                        "File Nguồn"});
            cbb_dieukien.SelectedIndex = 0;

            objPleaseWait.Close();
            tukhoaSearch = "";
            _strDatabase = SQLDatabase.ExcDataTable(string.Format("SELECT DB_NAME(0)AS [DatabaseName]; ")).Rows[0]["DatabaseName"].ToString();
        }

        private void GetValueTextbox()
        {
            try
            {
                if (dataGrid_ListTelNumber.CurrentRow != null && dataGrid_ListTelNumber.CurrentRow.IsNewRow == false)
                {
                    txtid.Text = dataGrid_ListTelNumber.SelectedRows[0].Cells[1].Value.ToString();
                    txtDidong.Text = dataGrid_ListTelNumber.SelectedRows[0].Cells[2].Value.ToString();
                    txtTen_khach_hang.Text = dataGrid_ListTelNumber.SelectedRows[0].Cells[3].Value.ToString();
                    txtPhuong.Text = dataGrid_ListTelNumber.SelectedRows[0].Cells[4].Value.ToString();
                    txtQuanHuyen.Text = dataGrid_ListTelNumber.SelectedRows[0].Cells[5].Value.ToString();
                    txtDia_Chi.Text = dataGrid_ListTelNumber.SelectedRows[0].Cells[6].Value.ToString();
                    txtNamSinh.Text = dataGrid_ListTelNumber.SelectedRows[0].Cells[9].Value.ToString();
                    txtemail.Text = dataGrid_ListTelNumber.SelectedRows[0].Cells[10].Value.ToString();
                    txtCuoc.Text = dataGrid_ListTelNumber.SelectedRows[0].Cells[11].Value.ToString();
                    txt_gioitinh.Text = dataGrid_ListTelNumber.SelectedRows[0].Cells[12].Value.ToString();
                    txtNganHang.Text = dataGrid_ListTelNumber.SelectedRows[0].Cells[13].Value.ToString();
                    txtSim.Text = dataGrid_ListTelNumber.SelectedRows[0].Cells[14].Value.ToString();
                    txtTinh.Text = dataGrid_ListTelNumber.SelectedRows[0].Cells[15].Value.ToString();
                    txt_TinhCuoc.Text = dataGrid_ListTelNumber.SelectedRows[0].Cells[16].Value.ToString();
                    txtNgayKichHoat.Text = dataGrid_ListTelNumber.SelectedRows[0].Cells[17].Value.ToString();
                    txt_goicuoc.Text = dataGrid_ListTelNumber.SelectedRows[0].Cells[18].Value.ToString();
                    txt_dongmay.Text = dataGrid_ListTelNumber.SelectedRows[0].Cells[19].Value.ToString();
                    txt_HeDieuHanh.Text = dataGrid_ListTelNumber.SelectedRows[0].Cells[20].Value.ToString();
                    txt_chucvu.Text = dataGrid_ListTelNumber.SelectedRows[0].Cells[21].Value.ToString();
                    txt_congty.Text = dataGrid_ListTelNumber.SelectedRows[0].Cells[22].Value.ToString();
                    txtNguon.Text = dataGrid_ListTelNumber.SelectedRows[0].Cells[24].Value.ToString();


                    
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

                cachedData = new CachedData();
                cachedData.LastRowIndex = -1;
                string CommandToGetCount = "";
                string CommandToGetData = "";
                switch (cbb_dieukien.SelectedIndex)
                {

                    case -1:
                    case 0:
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" :


                                           string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where (ten_khach_hang like N'%{0}%' or didong like '%{0}%' or dia_chi like N'%{0}%' or sim like N'%{0}%' or tinh like N'%{0}%' or tinh_cuoc like N'%{0}%' or gioi_tinh like N'%{0}%' or ghi_chu like N'%{0}%'  or ngan_hang like N'%{0}%' or namsinh like N'%{0}%' or ngay like N'%{0}%' or thang like N'%{0}%' or   ghi_chu like N'%{0}%'  or   filenguon like N'%{0}%'  or   phuong like N'%{0}%' or   quan_huyen like N'%{0}%'  or   email like N'%{0}%' or ngay_kich_hoat like N'%{0}%'  or goi_cuoc like N'%{0}%'  or dong_may like N'%{0}%' or he_dieu_hanh like N'%{0}%' or chuc_vu like N'%{0}%'  or cong_ty like N'%{0}%' ) ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                         + " id, didong,ten_khach_hang,phuong,quan_huyen,dia_chi,ngay,thang,  namsinh,email, cuoc,gioi_tinh,ngan_hang,sim, tinh,tinh_cuoc,ngay_kich_hoat,goi_cuoc,dong_may,he_dieu_hanh,chuc_vu,cong_ty, ghi_chu, filenguon,  creatdate as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where ten_khach_hang like N'%{0}%' or didong like '%{0}%' or dia_chi like N'%{0}%' or sim like N'%{0}%' or tinh like N'%{0}%' or tinh_cuoc like N'%{0}%' or gioi_tinh like N'%{0}%' or ghi_chu like N'%{0}%'  or ngan_hang like N'%{0}%' or namsinh like N'%{0}%' or ngay like N'%{0}%' or thang like N'%{0}%' or   ghi_chu like N'%{0}%'  or   filenguon like N'%{0}%'  or   phuong like N'%{0}%' or   quan_huyen like N'%{0}%'  or   email like N'%{0}%' or ngay_kich_hoat like N'%{0}%'  or goi_cuoc like N'%{0}%'  or dong_may like N'%{0}%' or he_dieu_hanh like N'%{0}%' or chuc_vu like N'%{0}%'  or cong_ty like N'%{0}%'", txt_Search.Text));
                        break;
                    case 1:/*di dong*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where didong like '%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                         + " id, didong,ten_khach_hang,phuong,quan_huyen,dia_chi,ngay,thang,  namsinh,email, cuoc,gioi_tinh,ngan_hang,sim, tinh,tinh_cuoc,ngay_kich_hoat,goi_cuoc,dong_may,he_dieu_hanh,chuc_vu,cong_ty, ghi_chu, filenguon,  creatdate as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where didong like '%{0}%' ", txt_Search.Text));
                        break;
                    case 2:/*"Tên khách hàng",*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where ten_khach_hang like N'%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                         + " id, didong,ten_khach_hang,phuong,quan_huyen,dia_chi,ngay,thang,  namsinh,email, cuoc,gioi_tinh,ngan_hang,sim, tinh,tinh_cuoc,ngay_kich_hoat,goi_cuoc,dong_may,he_dieu_hanh,chuc_vu,cong_ty, ghi_chu, filenguon,  creatdate as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where ten_khach_hang like N'%{0}%' ", txt_Search.Text));
                        break;
                    case 3:/*"Phuong",*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where phuong like N'%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                         + " id, didong,ten_khach_hang,phuong,quan_huyen,dia_chi,ngay,thang,  namsinh,email, cuoc,gioi_tinh,ngan_hang,sim, tinh,tinh_cuoc,ngay_kich_hoat,goi_cuoc,dong_may,he_dieu_hanh,chuc_vu,cong_ty, ghi_chu, filenguon,  creatdate as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where phuong like N'%{0}%' ", txt_Search.Text));
                        break;
                    case 4:/*"Quan",*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where quan_huyen like N'%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                         + " id, didong,ten_khach_hang,phuong,quan_huyen,dia_chi,ngay,thang,  namsinh,email, cuoc,gioi_tinh,ngan_hang,sim, tinh,tinh_cuoc,ngay_kich_hoat,goi_cuoc,dong_may,he_dieu_hanh,chuc_vu,cong_ty, ghi_chu, filenguon,  creatdate as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where quan_huyen like N'%{0}%' ", txt_Search.Text));
                        break;
                    case 5:/*dia chi*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where dia_chi like N'%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                         + " id, didong,ten_khach_hang,phuong,quan_huyen,dia_chi,ngay,thang,  namsinh,email, cuoc,gioi_tinh,ngan_hang,sim, tinh,tinh_cuoc,ngay_kich_hoat,goi_cuoc,dong_may,he_dieu_hanh,chuc_vu,cong_ty, ghi_chu, filenguon,  creatdate as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where dia_chi like N'%{0}%' ", txt_Search.Text));
                        break;

                    case 6:/*Ngày*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where ngay like N'%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                        + " id, didong,ten_khach_hang,phuong,quan_huyen,dia_chi,ngay,thang,  namsinh,email, cuoc,gioi_tinh,ngan_hang,sim, tinh,tinh_cuoc,ngay_kich_hoat,goi_cuoc,dong_may,he_dieu_hanh,chuc_vu,cong_ty, ghi_chu, filenguon,  creatdate as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where ngay like N'%{0}%' ", txt_Search.Text));
                        break;
                    case 7:/*tháng*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where thang like N'%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                        + " id, didong,ten_khach_hang,phuong,quan_huyen,dia_chi,ngay,thang,  namsinh,email, cuoc,gioi_tinh,ngan_hang,sim, tinh,tinh_cuoc,ngay_kich_hoat,goi_cuoc,dong_may,he_dieu_hanh,chuc_vu,cong_ty, ghi_chu, filenguon,  creatdate as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where thang like N'%{0}%' ", txt_Search.Text));
                        break;
                    case 8:/*Năm sinh*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where namsinh like N'%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                        + " id, didong,ten_khach_hang,phuong,quan_huyen,dia_chi,ngay,thang,  namsinh,email, cuoc,gioi_tinh,ngan_hang,sim, tinh,tinh_cuoc,ngay_kich_hoat,goi_cuoc,dong_may,he_dieu_hanh,chuc_vu,cong_ty, ghi_chu, filenguon,  creatdate as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where namsinh like N'%{0}%' ", txt_Search.Text));
                        break;
                    case 9:/*email*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where email like N'%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                        + " id, didong,ten_khach_hang,phuong,quan_huyen,dia_chi,ngay,thang,  namsinh,email, cuoc,gioi_tinh,ngan_hang,sim, tinh,tinh_cuoc,ngay_kich_hoat,goi_cuoc,dong_may,he_dieu_hanh,chuc_vu,cong_ty, ghi_chu, filenguon,  creatdate as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where email like N'%{0}%' ", txt_Search.Text));
                        break;
                    case 10:/*Cước*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where cuoc like N'%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                        + " id, didong,ten_khach_hang,phuong,quan_huyen,dia_chi,ngay,thang,  namsinh,email, cuoc,gioi_tinh,ngan_hang,sim, tinh,tinh_cuoc,ngay_kich_hoat,goi_cuoc,dong_may,he_dieu_hanh,chuc_vu,cong_ty, ghi_chu, filenguon,  creatdate as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where cuoc like N'%{0}%' ", txt_Search.Text));
                        break;
                    case 11:/*gioitinh*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where gioi_tinh like N'%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                        + " id, didong,ten_khach_hang,phuong,quan_huyen,dia_chi,ngay,thang,  namsinh,email, cuoc,gioi_tinh,ngan_hang,sim, tinh,tinh_cuoc,ngay_kich_hoat,goi_cuoc,dong_may,he_dieu_hanh,chuc_vu,cong_ty, ghi_chu, filenguon,  creatdate as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where gioi_tinh like N'%{0}%' ", txt_Search.Text));
                        break;
                    case 12:/*Ngân hàng*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where ngan_hang like N'%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                        + " id, didong,ten_khach_hang,phuong,quan_huyen,dia_chi,ngay,thang,  namsinh,email, cuoc,gioi_tinh,ngan_hang,sim, tinh,tinh_cuoc,ngay_kich_hoat,goi_cuoc,dong_may,he_dieu_hanh,chuc_vu,cong_ty, ghi_chu, filenguon,  creatdate as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where ngan_hang like N'%{0}%' ", txt_Search.Text));
                        break;

                    case 13:/*Sim*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where sim like N'%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                        + " id, didong,ten_khach_hang,phuong,quan_huyen,dia_chi,ngay,thang,  namsinh,email, cuoc,gioi_tinh,ngan_hang,sim, tinh,tinh_cuoc,ngay_kich_hoat,goi_cuoc,dong_may,he_dieu_hanh,chuc_vu,cong_ty, ghi_chu, filenguon,  creatdate as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where sim like N'%{0}%' ", txt_Search.Text));
                        break;
                    case 14:/*tinh*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where tinh like N'%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                        + " id, didong,ten_khach_hang,phuong,quan_huyen,dia_chi,ngay,thang,  namsinh,email, cuoc,gioi_tinh,ngan_hang,sim, tinh,tinh_cuoc,ngay_kich_hoat,goi_cuoc,dong_may,he_dieu_hanh,chuc_vu,cong_ty, ghi_chu, filenguon,  creatdate as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where tinh like N'%{0}%' ", txt_Search.Text));
                        break;

                    case 15:/*tinh cuoc*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where tinh_cuoc like N'%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                        + " id, didong,ten_khach_hang,phuong,quan_huyen,dia_chi,ngay,thang,  namsinh,email, cuoc,gioi_tinh,ngan_hang,sim, tinh,tinh_cuoc,ngay_kich_hoat,goi_cuoc,dong_may,he_dieu_hanh,chuc_vu,cong_ty, ghi_chu, filenguon,  creatdate as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where tinh_cuoc like N'%{0}%' ", txt_Search.Text));
                        break;
                    case 16:/*ngay_kich_hoat*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where ngay_kich_hoat like N'%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                        + " id, didong,ten_khach_hang,phuong,quan_huyen,dia_chi,ngay,thang,  namsinh,email, cuoc,gioi_tinh,ngan_hang,sim, tinh,tinh_cuoc,ngay_kich_hoat,goi_cuoc,dong_may,he_dieu_hanh,chuc_vu,cong_ty, ghi_chu, filenguon,  creatdate as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where ngay_kich_hoat like N'%{0}%' ", txt_Search.Text));
                        break;
                    case 17:/*goi_cuoc*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where goi_cuoc like N'%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                        + " id, didong,ten_khach_hang,phuong,quan_huyen,dia_chi,ngay,thang,  namsinh,email, cuoc,gioi_tinh,ngan_hang,sim, tinh,tinh_cuoc,ngay_kich_hoat,goi_cuoc,dong_may,he_dieu_hanh,chuc_vu,cong_ty, ghi_chu, filenguon,  creatdate as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where goi_cuoc like N'%{0}%' ", txt_Search.Text));
                        break;
                    case 18:/*dong_may*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where dong_may like N'%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                        + " id, didong,ten_khach_hang,phuong,quan_huyen,dia_chi,ngay,thang,  namsinh,email, cuoc,gioi_tinh,ngan_hang,sim, tinh,tinh_cuoc,ngay_kich_hoat,goi_cuoc,dong_may,he_dieu_hanh,chuc_vu,cong_ty, ghi_chu, filenguon,  creatdate as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where dong_may like N'%{0}%' ", txt_Search.Text));
                        break;
                    case 19:/*he_dieu_hanh*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where he_dieu_hanh like N'%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                        + " id, didong,ten_khach_hang,phuong,quan_huyen,dia_chi,ngay,thang,  namsinh,email, cuoc,gioi_tinh,ngan_hang,sim, tinh,tinh_cuoc,ngay_kich_hoat,goi_cuoc,dong_may,he_dieu_hanh,chuc_vu,cong_ty, ghi_chu, filenguon,  creatdate as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where he_dieu_hanh like N'%{0}%' ", txt_Search.Text));
                        break;
                    case 20:/*chuc_vu*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where chuc_vu like N'%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                        + " id, didong,ten_khach_hang,phuong,quan_huyen,dia_chi,ngay,thang,  namsinh,email, cuoc,gioi_tinh,ngan_hang,sim, tinh,tinh_cuoc,ngay_kich_hoat,goi_cuoc,dong_may,he_dieu_hanh,chuc_vu,cong_ty, ghi_chu, filenguon,  creatdate as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where chuc_vu like N'%{0}%' ", txt_Search.Text));
                        break;
                    case 21:/*cong_ty*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where cong_ty like N'%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                        + " id, didong,ten_khach_hang,phuong,quan_huyen,dia_chi,ngay,thang,  namsinh,email, cuoc,gioi_tinh,ngan_hang,sim, tinh,tinh_cuoc,ngay_kich_hoat,goi_cuoc,dong_may,he_dieu_hanh,chuc_vu,cong_ty, ghi_chu, filenguon,  creatdate as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where cong_ty like N'%{0}%' ", txt_Search.Text));
                        break;
                    case 22:/*ghi chú*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where ghi_chu like N'%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                        + " id, didong,ten_khach_hang,phuong,quan_huyen,dia_chi,ngay,thang,  namsinh,email, cuoc,gioi_tinh,ngan_hang,sim, tinh,tinh_cuoc,ngay_kich_hoat,goi_cuoc,dong_may,he_dieu_hanh,chuc_vu,cong_ty, ghi_chu, filenguon,  creatdate as createdate "
                                                        + " From dienthoai_goc {0}) Select * From Tel where", txt_Search.Text.Trim() == "" ? "" : string.Format("where ghi_chu like N'%{0}%' ", txt_Search.Text));
                        break;
                    case 23:/*filenguon*/
                        CommandToGetCount = txt_Search.Text.Trim() == "" ? "Select COUNT(*) As TotalRow From dienthoai_goc" : string.Format("Select COUNT(*) As TotalRow From dienthoai_goc where filenguon like N'%{0}%' ", txt_Search.Text);
                        CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                        + " id, didong,ten_khach_hang,phuong,quan_huyen,dia_chi,ngay,thang,  namsinh,email, cuoc,gioi_tinh,ngan_hang,sim, tinh,tinh_cuoc,ngay_kich_hoat,goi_cuoc,dong_may,he_dieu_hanh,chuc_vu,cong_ty, ghi_chu, filenguon,  creatdate as createdate "
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

                groupBox_grid.Text = string.Format("Xem Tất Cả Khách Hàng :{0}", tongcongGoc);
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

        private void SearchTelNumber(string dk)
        {
            PleaseWait objPleaseWait = new PleaseWait();
            objPleaseWait.Show();
            Application.DoEvents();
            try
            {
                groupBox_grid.Text = "Kết quả tìm kiếm";
                dataGrid_ListTelNumber.Rows.Clear();
                dataGrid_ListTelNumber.VirtualMode = true;

                cachedData = new CachedData();
                cachedData.LastRowIndex = -1;
                string CommandToGetCount = "";
                string CommandToGetData = "";
                CommandToGetCount ="Select COUNT(*) As TotalRow From dienthoai_goc" +dk;
                CommandToGetData = string.Format(" With Tel As (select ROW_NUMBER() Over (Order By creatdate asc) As RowNumber ,"
                                                + " id, didong,ten_khach_hang,phuong,quan_huyen,dia_chi,ngay,thang,  namsinh,email, cuoc,gioi_tinh,ngan_hang,sim, tinh,tinh_cuoc,ngay_kich_hoat,goi_cuoc,dong_may,he_dieu_hanh,chuc_vu,cong_ty, ghi_chu, filenguon,  creatdate as createdate "
                                                + " From dienthoai_goc {0}) Select * From Tel  where", dk);


                cachedData.CommandToGetCount = CommandToGetCount;
                cachedData.CommandToGetData = CommandToGetData;
                cachedData.UpdateCachedData(0);
                dataGrid_ListTelNumber.RowCount = (int)cachedData.TotalRowCount;



                //----- Enabled button Edit,Delete
                EnabledButton();

                //----- Sum record
                String tongcongGoc = cachedData.TotalRowCount.ToString();

                groupBox_grid.Text = string.Format("Xem Tất Cả Khách Hàng :{0}", tongcongGoc);
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
                MessageBox.Show(ex.Message, "Search TelNumber", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            if (txt_Search.Text == "") return;
            PleaseWait objPleaseWait = new PleaseWait();
            objPleaseWait.Show();
            Application.DoEvents();

            try
            {
                //BindingTelNumberToGridView();
                SoLuongKhachHang();
                SearchTelNumber();

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
                        model.tinh              = txtTinh.Text;
                        model.tinh_cuoc         = txt_TinhCuoc.Text;
                        model.gioi_tinh         = txt_gioitinh.Text;
                        model.phuong            = txtPhuong.Text;
                        model.quan_huyen        = txtQuanHuyen.Text;
                        model.email             = txtemail.Text;
                        model.ngay_kich_hoat    = txtNgayKichHoat.Text;
                        model.goi_cuoc          = txt_goicuoc.Text;
                        model.dong_may          = txt_dongmay.Text;
                        model.he_dieu_hanh      = txt_HeDieuHanh.Text;
                        model.chuc_vu           = txt_chucvu.Text;
                        model.cong_ty           = txt_congty.Text;
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
            if (txt_Search.Text == "") return;
            tukhoaSearch = "";/*nếu có gia tri tức tìm kiếm nâng cao*/
            SearchTelNumber();
        }

        private void txt_Search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                if (txt_Search.Text == "") return;
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
                frm.NameDatabase = _strDatabase;
                if (frm.ShowDialog() == DialogResult.OK) {
                    objPleaseWait = new PleaseWait();
                    objPleaseWait.Show();
                    Application.DoEvents();

                    //BindingTelNumberToGridView();
                    SoLuongKhachHang();
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
            string command = "";

            frmChange3 frm = new frmChange3();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                int selectindex = tukhoaSearch != "" ? -2 : cbb_dieukien.SelectedIndex;
                string search = tukhoaSearch != "" ? tukhoaSearch : txt_Search.Text;
                string strsql = frm.SQL;
                strsql += string.Format(" from {0}.dbo.dienthoai_goc as a ",_strDatabase);

                switch (selectindex)
                {
                    case -2:/*truong hop search nâng cao*/
                        strsql += search;
                        break;
                    case 0:
                    case -1:
                        strsql += string.Format(" where ten_khach_hang like N'%{0}%' or " +
                                                " didong like '%{0}%' or " +
                                                " dia_chi like N'%{0}%' or " +
                                                " sim like N'%{0}%' or " +
                                                " tinh like N'%{0}%' or " +
                                                " tinh_cuoc like N'%{0}%' or " +
                                                " gioi_tinh like N'%{0}%' or " +
                                                " ghi_chu like N'%{0}%'  or " +
                                                " ngan_hang like N'%{0}%' or " +
                                                " namsinh like N'%{0}%' or " +
                                                " ngay like N'%{0}%' or " +
                                                " thang like N'%{0}%' or " +
                                                " ghi_chu like N'%{0}%'  or " +
                                                " phuong like N'%{0}%'  or " +
                                                " quan_huyen like N'%{0}%'  or " +
                                                " email like N'%{0}%'  or " +
                                                " ngay_kich_hoat like N'%{0}%'  or " +
                                                " goi_cuoc like N'%{0}%'  or " +
                                                " dong_may like N'%{0}%'  or " +
                                                " he_dieu_hanh like N'%{0}%'  or " +
                                                " chuc_vu like N'%{0}%'  or " +
                                                " cong_ty like N'%{0}%'  or " +
                                                " filenguon like N'%{0}%'", search);
                        break;
                    case 1:/*di dong*/
                        strsql += string.Format("where didong like '%{0}%'", search);
                        break;
                    case 2:/*"khách hàng",*/
                        strsql += string.Format("where ten_khach_hang like N'%{0}%'", search);
                        break;
                    case 3:/*"phường",*/
                        strsql += string.Format("where phuong like N'%{0}%'", search);
                        break;
                    case 4:/*"quan_huyen",*/
                        strsql += string.Format("where quan_huyen like N'%{0}%'", search);
                        break;
                    case 5:/*dia chi*/
                        strsql += string.Format("where dia_chi like N'%{0}%'", search);
                        break;

                    case 6:/*Ngày*/
                        strsql += string.Format("where ngay like N'%{0}%'", search);
                        break;
                    case 7:/*Tháng*/
                        strsql += string.Format("where thang like N'%{0}%'", search);
                        break;
                    case 8:/*Năm sinh*/
                        strsql += string.Format("where namsinh like N'%{0}%'", search);
                        break;
                    case 9:/*email*/
                        strsql += string.Format("where email like N'%{0}%'", search);
                        break;
                    case 10:/*cuoc*/
                        strsql += string.Format("where cuoc like N'%{0}%'", search);
                        break;
                    case 11:/*gioitinh*/
                        strsql += string.Format("where gioi_tinh like N'%{0}%'", search);
                        break;
                    case 12:/*ngan_hang*/
                        strsql += string.Format("where ngan_hang like N'%{0}%'", search);
                        break;
                    case 13:/*sim*/
                        strsql += string.Format("where sim like N'%{0}%'", search);
                        break;
                    case 14:/*tinh*/
                        strsql += string.Format("where tinh like N'%{0}%'", search);
                        break;
                    case 15:/*tinh_cuoc*/
                        strsql += string.Format("where tinh_cuoc like N'%{0}%'", search);
                        break;
                    case 16:/*ngay_kich_hoat*/
                        strsql += string.Format("where ngay_kich_hoat like N'%{0}%'", search);
                        break;
                    case 17:/*goi_cuoc*/
                        strsql += string.Format("where goi_cuoc like N'%{0}%'", search);
                        break;
                    case 18:/*dong_may*/
                        strsql += string.Format("where dong_may like N'%{0}%'", search);
                        break;
                    case 19:/*he_dieu_hanh*/
                        strsql += string.Format("where he_dieu_hanh like N'%{0}%'", search);
                        break;
                    case 20:/*chuc_vu*/
                        strsql += string.Format("where chuc_vu like N'%{0}%'", search);
                        break;
                    case 21:/*cong_ty*/
                        strsql += string.Format("where cong_ty like N'%{0}%'", search);
                        break;
                    case 22:/*ghi_chu*/
                        strsql += string.Format("where ghi_chu like N'%{0}%'", search);
                        break;
                    case 23:/*filenguon*/
                        strsql += string.Format("where filenguon like N'%{0}%'", search);
                        break;
                    default:
                        break;
                }
                strsql += " Order by didong asc";
                PleaseWait objPleaseWait1 = new PleaseWait();
                objPleaseWait1.Show();
                Application.DoEvents();

                /*
                DataTable table = SQLDatabase.ExcDataTable(strsql);
                if (table.Rows.Count == 0)
                {
                    objPleaseWait1.Close();
                    MessageBox.Show("Không có dữ liệu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                Export.ExportText(table, frm.Filename, "\t");
                */

                command = string.Format("exec [spExport] '{0}','{1}'", strsql, frm.Filename);

                objPleaseWait1.Close();
                MessageBox.Show("Xuất file thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void backupDữLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmBackup frm = new frmBackup();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    BindingTelNumberToGridView();
                    SoLuongKhachHang();
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
                        MessageBox.Show("Xoá xong dữ liệu gốc và dữ liệu nguồn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //BindingTelNumberToGridView();
                        SoLuongKhachHang();
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
                if (MessageBox.Show("Bạn có chắc muốn xoá tất cả dữ liệu bảng nguồn không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    objPleaseWait.Show();
                    Application.DoEvents();
                    if (SQLDatabase.ExcNonQuery("[spDelTam]"))
                    {
                        MessageBox.Show("Xoá xong tất dữ liệu nguồn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //BindingTelNumberToGridView();
                        SoLuongKhachHang();
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

        private void button7_Click(object sender, EventArgs e)
        {
            dataGrid_ListTelNumber.SelectAll();
            DeleteTelNumber();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            frmTimNangCao frm = new frmTimNangCao();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                tukhoaSearch = frm.Search;
                SearchTelNumber(frm.Search);
            }

        }
        
    }
}
