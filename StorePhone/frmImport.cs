using SchemaSpec;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StorePhone
{
    public partial class frmImport : Form
    {
        private CachedData cachedData;
        private string connectionString = "";
        private DataTable tbTable = null;
        private List<string> dscot;
        private string NamesFile = "";
        private Thread theardProcess;
        private int _nTongRowsText;
        private string _strNameDatabase="";

        public string NameDatabase
        {
            get { return _strNameDatabase; }
            set { _strNameDatabase = value; }
        }


        public frmImport()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            PleaseWait objPleaseWait = new PleaseWait();
            objPleaseWait.Show();
            Application.DoEvents();
            try
            {
                btn_View.Enabled = false;
                btn_Import.Enabled = false;

                BindingTelNumberToGridView();
                BindingTelNumberToGridViewTonTai();
                dscot = new List<string>();

                objPleaseWait.Close();
            }
            catch (Exception ex)
            {
                objPleaseWait.Close();
                MessageBox.Show(ex.Message, "Main_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        //----- Add ChargeDebtTelephone to Gridview
        private void BindingTelNumberToGridView()
        {
            try
            {
                groupBox_grid.Text = "Khách Hàng";


                dataGrid_ListTelNumberNew.DataSource = SQLDatabase.ExcDataTable(" select  a.Id,a.didong, a.ten_khach_hang,a.phuong,a.quan_huyen ,  a.dia_chi,a.ngay,a.thang, a.namsinh,a.email, a.cuoc, a.gioi_tinh, a.ngan_hang, a.sim, a.tinh,a.tinh_cuoc,a.ngay_kich_hoat,a.goi_cuoc,a.dong_may,a.he_dieu_hanh,a.chuc_vu,a.cong_ty, a.ghi_chu,  a.filenguon,  a.creatdate "
                                                                                    + " from dienthoai_new  a left join dienthoai_goc b on a.didong=b.didong where b.didong is null");


                long totalRowCount = 0;
                DataTable table1 = SQLDatabase.ExcDataTable("Select COUNT(*) As TotalRow from dienthoai_new  a left join dienthoai_goc b on a.didong=b.didong " +
                                                            "where b.didong is null");
                if (table1 != null && Convert.ToInt32(table1.Rows[0][0]) > 0)
                {
                    totalRowCount = long.Parse(table1.Rows[0][0].ToString());
                    tabControl1.TabPages[1].Text = string.Format("Khách Hàng Chưa Tồn Tại Ở File Gốc: {0}", totalRowCount);
                    button5.Enabled = true;
                    button7.Enabled = true;
                }
                else
                {
                    totalRowCount = 0;
                    button5.Enabled = false;
                    button7.Enabled = false;
                    tabControl1.TabPages[1].Text = string.Format("Khách Hàng Chưa Tồn Tại Ở File Gốc");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "BindingTelNumberToGridView", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //----- Add ChargeDebtTelephone to Gridview
        private void BindingTelNumberToGridViewTonTai()
        {
            try
            {
                groupBox_grid.Text = "Khách Hàng";
                dataGridView_tontai.DataSource = SQLDatabase.ExcDataTable(" select  a.Id,a.didong, a.ten_khach_hang,a.phuong,a.quan_huyen ,  a.dia_chi,a.ngay,a.thang, a.namsinh,a.email, a.cuoc, a.gioi_tinh, a.ngan_hang, a.sim, a.tinh,a.tinh_cuoc,a.ngay_kich_hoat,a.goi_cuoc,a.dong_may,a.he_dieu_hanh,a.chuc_vu,a.cong_ty, a.ghi_chu,  a.filenguon,  a.creatdate "
                                                                       + " from dienthoai_new  a inner join dienthoai_goc b on a.didong=b.didong ");

                long totalRowCount = 0;
                DataTable table1 = SQLDatabase.ExcDataTable("Select COUNT(*) As TotalRow from dienthoai_new  a inner join dienthoai_goc b on a.didong=b.didong ");
                if (table1 != null && Convert.ToInt32(table1.Rows[0][0]) > 0)
                {
                    totalRowCount = long.Parse(table1.Rows[0][0].ToString());
                    tabControl1.TabPages[0].Text = string.Format("Khách Hàng Tồn Tại Ở File Gốc: {0}", totalRowCount);
                    button1.Enabled = true;
                    btnXoaTrungGoc.Enabled = true;
                    button8.Enabled = true;
                }
                else
                {
                    totalRowCount = 0;
                    button1.Enabled = false;
                    btnXoaTrungGoc.Enabled = false;
                    button8.Enabled = false;
                    tabControl1.TabPages[0].Text = string.Format("Khách Hàng Tồn Tại Ở File Gốc");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "BindingTelNumberToGridViewTonTai", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


        //----- Enabled button Edit,Delete Group
        private void EnabledButton()
        {
            try
            {
                if (dataGrid_ListTelNumberNew.Rows.Count > 0)
                {
                    btnUpdateTrung.Enabled = true;
                    btnXuatfile.Enabled = true;

                    //xoadienthoaigoc.Visible = true;
                }
                else
                {
                    btnUpdateTrung.Enabled = false;
                    btnXuatfile.Enabled = false;
                    //xoadienthoaigoc.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Enabled Button", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //----- Check Enter text value Search
        private bool CheckValueSearchKey(string value)
        {
            string[] arrText;
            try
            {
                arrText = value.Split('.', ' ');
                foreach (string str in arrText)
                {
                    Int64.Parse(str);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile;
            string[] fileNames;

            try
            {
                openFile = new OpenFileDialog();
                openFile.Filter = "Text File (*.txt)|*.txt|All files (*.*)|*.*";

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    txt_FileName.Text = openFile.FileName;
                    NamesFile = openFile.SafeFileName;
                    fileNames = openFile.FileName.Split('.');
                    if (fileNames[fileNames.Length - 1] == "txt" || fileNames[fileNames.Length - 1] == "TXT")
                        EnabledControl(false);
                    else
                        EnabledControl(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Open Source File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EnabledControl(bool enabled)
        {
            try
            {
                if (!enabled)
                {
                    btn_View.Enabled = true;
                    btn_Import.Enabled = true;
                }
                else
                {
                    btn_View.Enabled = false;
                    btn_Import.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "EnableControl", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            FileInfo fileInfo;
            string[] fileName;
            string tableName = string.Empty;
            string name = string.Empty;
            // DataTable tbGetNameDisplay;
            dscot = new List<string>();
            try
            {
                if (string.IsNullOrEmpty(txt_FileName.Text))
                {
                    MessageBox.Show("Chưa có 'dữ liệu nguồn' cần lưu", "load Data Source", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    fileInfo = new FileInfo(txt_FileName.Text);
                    if (fileInfo.Exists == false)
                    {
                        MessageBox.Show("Đường dẫn hoặc tên tập tin của dữ liệu nguồn không đúng. Vui lòng kiểm tra lại !", "load Data Source", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        /*kiễm tra định nghĩ cấu hình file txt*/
                        string path = Path.GetDirectoryName(txt_FileName.Text);
                        (new Utilities_Import()).CreateSchemaIni(txt_FileName.Text);
                        SchemaSpec.SchemeDef sdef = new SchemaSpec.SchemeDef();
                        if (Properties.Settings.Default.SchemaSpec == null)
                        {
                            if (sdef == null)
                            {
                                sdef.DelimiterType = SchemaSpec.SchemeDef.DelimType.TabDelimited;
                                sdef.UsesHeader = SchemeDef.FirstRowHeader.No;
                                List<ItemSpecification> ColumnDefinition = new List<ItemSpecification>();
                                for (int i = 1; i <= 22; i++)
                                {
                                    ColumnDefinition.Add(new ItemSpecification() { ColumnNumber = i, Name = i.ToString() , ColumnWidth = 600, TypeData = ItemSpecification.JetDataType.Text });
                                }
                                sdef.ColumnDefinition = ColumnDefinition;
                                Properties.Settings.Default.SchemaSpec = sdef;
                                Properties.Settings.Default.Save();
                            }
                        }
                        else
                        {
                            sdef = Properties.Settings.Default.SchemaSpec;
                        }

                        // create a variable to hold the connection string
                        string connbit = string.Empty;
                        switch (sdef.DelimiterType)
                        {
                            case SchemaSpec.SchemeDef.DelimType.CsvDelimited:
                                if (sdef.UsesHeader == SchemaSpec.SchemeDef.FirstRowHeader.Yes)
                                    connbit = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + @";Extended Properties=""Text;HDR=Yes;FMT=CsvDelimited""";
                                else
                                    connbit = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + @";Extended Properties=""Text;HDR=No;FMT=CsvDelimited""";
                                break;
                            case SchemaSpec.SchemeDef.DelimType.CustomDelimited:
                                if (sdef.UsesHeader == SchemaSpec.SchemeDef.FirstRowHeader.Yes)
                                    connbit = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + @";Extended Properties=""Text;HDR=Yes;FMT=Delimited(" + sdef.CustomDelimiter + ")" + "\"";
                                else
                                    connbit = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + @";Extended Properties=""Text;HDR=No;FMT=Delimited(" + sdef.CustomDelimiter + ")" + "\"";
                                break;
                            case SchemaSpec.SchemeDef.DelimType.FixedWidth:
                                if (sdef.UsesHeader == SchemaSpec.SchemeDef.FirstRowHeader.Yes)
                                    connbit = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + @";Extended Properties=""Text;HDR=Yes;FMT=FixedLength""";
                                else
                                    connbit = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + @";Extended Properties=""Text;HDR=No;FMT=FixedLength""";
                                break;
                            case SchemaSpec.SchemeDef.DelimType.TabDelimited:
                                if (sdef.UsesHeader == SchemaSpec.SchemeDef.FirstRowHeader.Yes)
                                    connbit = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + @";Extended Properties=""Text;HDR=Yes;FMT=TabDelimited""";
                                else
                                    connbit = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + @";Extended Properties=""Text;HDR=No;FMT=TabDelimited""";
                                break;
                            default:
                                break;
                        }

                        // put the connection string into the properties and save the properties
                        Properties.Settings.Default.ConnString = connbit;
                        Properties.Settings.Default.Save();

                        // make sure we have a connection string before proceeding
                        if (String.IsNullOrEmpty(connbit))
                        {
                            MessageBox.Show("Mẫu không hợp lệ; sử dụng tiện ích lược đồ để xác định giản đồ cho tệp bạn đang cần mở", "Thông Báo");
                        }

                        connectionString = connbit;

                        fileName = txt_FileName.Text.Split('.');

                        StreamReader sReader;
                        string line;
                        string[] lineParts;
                        ClearALLControl();

                        //----- Add Item combobox
                        cbb_TelNumber.Items.Add("----Chọn----");
                        cbb_ten_khach_hang.Items.Add("----Chọn----");
                        cbb_dia_chi.Items.Add("----Chọn----");
                        cbb_Ngay.Items.Add("----Chọn----");
                        cbb_Thang.Items.Add("----Chọn----");
                        cbb_namsinh.Items.Add("----Chọn----");
                        cbb_nganhang.Items.Add("----Chọn----");
                        cbb_cuoc.Items.Add("----Chọn----");
                        cbb_sim.Items.Add("----Chọn----");
                        cbb_tinh.Items.Add("----Chọn----");
                        cbb_ghichu.Items.Add("----Chọn----");
                        cbb_gioitinh.Items.Add("----Chọn----");
                        cbb_tinhcuoc.Items.Add("----Chọn----");
                        cbb_Phuong.Items.Add("----Chọn----");
                        cbb_quanhuyen.Items.Add("----Chọn----");
                        cbb_email.Items.Add("----Chọn----");
                        cbb_ngay_kich_hoat.Items.Add("----Chọn----");
                        cbb_GoiCuoc.Items.Add("----Chọn----");
                        cbb_dongmay.Items.Add("----Chọn----");
                        cbb_HeDieuhanh.Items.Add("----Chọn----");
                        cbb_chucvu.Items.Add("----Chọn----");
                        cbb_congty.Items.Add("----Chọn----");

                        sReader = new StreamReader(txt_FileName.Text);
                        _nTongRowsText = File.ReadAllLines(txt_FileName.Text).Count();
                        if (sReader.ReadLine() != null)
                        {
                            line = sReader.ReadLine();
                            char kytu = '\t';
                            lineParts = line.Split(new char[] { kytu });
                            for (int i = 1; i < lineParts.Count(); i++)
                            {
                                cbb_TelNumber.Items.AddRange(new object[] { i.ToString() });
                                cbb_ten_khach_hang.Items.AddRange(new object[] { i.ToString() });
                                cbb_dia_chi.Items.AddRange(new object[] { i.ToString() });
                                cbb_Ngay.Items.AddRange(new object[] { i.ToString() });
                                cbb_Thang.Items.AddRange(new object[] { i.ToString() });
                                cbb_namsinh.Items.AddRange(new object[] { i.ToString() });
                                cbb_nganhang.Items.AddRange(new object[] { i.ToString() });
                                cbb_cuoc.Items.AddRange(new object[] { i.ToString() });
                                cbb_sim.Items.AddRange(new object[] { i.ToString() });
                                cbb_tinh.Items.AddRange(new object[] { i.ToString() });
                                cbb_ghichu.Items.AddRange(new object[] { i.ToString() });
                                cbb_gioitinh.Items.AddRange(new object[] { i.ToString() });
                                cbb_tinhcuoc.Items.AddRange(new object[] { i.ToString() });

                                cbb_Phuong.Items.AddRange(new object[] { i.ToString() });
                                cbb_quanhuyen.Items.AddRange(new object[] { i.ToString() });
                                cbb_email.Items.AddRange(new object[] { i.ToString() });
                                cbb_ngay_kich_hoat.Items.AddRange(new object[] { i.ToString() });
                                cbb_GoiCuoc.Items.AddRange(new object[] { i.ToString() });
                                cbb_dongmay.Items.AddRange(new object[] { i.ToString() });
                                cbb_HeDieuhanh.Items.AddRange(new object[] { i.ToString() });
                                cbb_chucvu.Items.AddRange(new object[] { i.ToString() });
                                cbb_congty.Items.AddRange(new object[] { i.ToString() });

                            }
                        }
                        sReader.Close();
                        cbb_TelNumber.SelectedIndex = 0;
                        cbb_ten_khach_hang.SelectedIndex = 0;
                        cbb_dia_chi.SelectedIndex = 0;
                        cbb_Ngay.SelectedIndex = 0;
                        cbb_Thang.SelectedIndex = 0;
                        cbb_namsinh.SelectedIndex = 0;
                        cbb_nganhang.SelectedIndex = 0;
                        cbb_cuoc.SelectedIndex = 0;
                        cbb_sim.SelectedIndex = 0;
                        cbb_tinh.SelectedIndex = 0;
                        cbb_ghichu.SelectedIndex = 0;
                        cbb_gioitinh.SelectedIndex = 0;
                        cbb_tinhcuoc.SelectedIndex = 0;

                        cbb_Phuong.SelectedIndex = 0;
                        cbb_quanhuyen.SelectedIndex = 0;
                        cbb_email.SelectedIndex = 0;
                        cbb_ngay_kich_hoat.SelectedIndex = 0;
                        cbb_GoiCuoc.SelectedIndex = 0;
                        cbb_dongmay.SelectedIndex = 0;
                        cbb_HeDieuhanh.SelectedIndex = 0;
                        cbb_chucvu.SelectedIndex = 0;
                        cbb_congty.SelectedIndex = 0;



                        cbb_TelNumber.Enabled = true;
                        cbb_ten_khach_hang.Enabled = true;
                        cbb_dia_chi.Enabled = true;
                        cbb_Ngay.Enabled = true;
                        cbb_Thang.Enabled = true;
                        cbb_namsinh.Enabled = true;
                        cbb_nganhang.Enabled = true;
                        cbb_cuoc.Enabled = true;
                        cbb_sim.Enabled = true;
                        cbb_tinh.Enabled = true;
                        cbb_ghichu.Enabled = true;
                        cbb_gioitinh.Enabled = true;
                        cbb_tinhcuoc.Enabled = true;

                        cbb_Phuong.Enabled = true;
                        cbb_quanhuyen.Enabled = true;
                        cbb_email.Enabled = true;
                        cbb_ngay_kich_hoat.Enabled = true;
                        cbb_GoiCuoc.Enabled = true;
                        cbb_dongmay.Enabled = true;
                        cbb_HeDieuhanh.Enabled = true;
                        cbb_chucvu.Enabled = true;
                        cbb_congty.Enabled = true;


                    }
                }
            }
            catch (Exception ex)
            {
                //if (dlgWaitProcess != null)
                //    dlgWaitProcess.Close();
                MessageBox.Show(ex.Message, "load Data Source");
            }

        }

        private void ClearALLControl()
        {
            cbb_TelNumber.Items.Clear();
            cbb_ten_khach_hang.Items.Clear();
            cbb_dia_chi.Items.Clear();
            cbb_Ngay.Items.Clear();
            cbb_Thang.Items.Clear();
            cbb_namsinh.Items.Clear();
            cbb_nganhang.Items.Clear();
            cbb_cuoc.Items.Clear();
            cbb_sim.Items.Clear();
            cbb_tinh.Items.Clear();
            cbb_ghichu.Items.Clear();
            cbb_gioitinh.Items.Clear();
            cbb_tinhcuoc.Items.Clear();

            cbb_Phuong.Items.Clear();
            cbb_quanhuyen.Items.Clear();
            cbb_email.Items.Clear();
            cbb_ngay_kich_hoat.Items.Clear();
            cbb_GoiCuoc.Items.Clear();
            cbb_dongmay.Items.Clear();
            cbb_HeDieuhanh.Items.Clear();
            cbb_chucvu.Items.Clear();
            cbb_congty.Items.Clear();
        }

        private void EnabledControl2(bool enabled)
        {
            try
            {

                cbb_TelNumber.Enabled = enabled;
                cbb_ten_khach_hang.Enabled = enabled;
                cbb_dia_chi.Enabled = enabled;
                cbb_Ngay.Enabled = enabled;
                cbb_Thang.Enabled = enabled;
                cbb_namsinh.Enabled = enabled;
                cbb_nganhang.Enabled = enabled;
                cbb_cuoc.Enabled = enabled;
                cbb_sim.Enabled = enabled;
                cbb_tinh.Enabled = enabled;
                cbb_ghichu.Enabled = enabled;
                cbb_tinhcuoc.Enabled = enabled;
                cbb_gioitinh.Enabled = enabled;
                button3.Enabled = enabled;
                button2.Enabled = enabled;

                cbb_Phuong.Enabled = enabled;
                cbb_quanhuyen.Enabled = enabled;
                cbb_email.Enabled = enabled;
                cbb_ngay_kich_hoat.Enabled = enabled;
                cbb_GoiCuoc.Enabled = enabled;
                cbb_dongmay.Enabled = enabled;
                cbb_HeDieuhanh.Enabled = enabled;
                cbb_chucvu.Enabled = enabled;
                cbb_congty.Enabled = enabled;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "EnabledControl2");
            }
        }

        //----- Enabled button View,Import
        private void EnabledBotton()
        {
            try
            {
                if (cbb_TelNumber.Items.Count > 0)
                {
                    btn_View.Enabled = true;
                    btn_Import.Enabled = true;
                }
                else
                {
                    btn_View.Enabled = false;
                    btn_Import.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Enabled Botton");
            }
        }

        private void btn_Import_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbb_TelNumber.SelectedIndex == 0)
                {
                    MessageBox.Show("Vui lòng chọn thông tin, ít nhất phải chọn thông tin di động", "Thông báo");
                    cbb_TelNumber.Focus();
                    return;
                }
                import();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Import", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void import()
        {
            ParameterizedThreadStart par;
            ArrayList arr;
            try
            {



                /*Cấu hình controll*/
                Control.CheckForIllegalCrossThreadCalls = false;

                /*xoa tat ca file tam*/
                SQLDatabase.ExcNonQuery("spDelTam");

                par = new ParameterizedThreadStart(ProcessImport);
                theardProcess = new Thread(par);

                arr = new ArrayList();
                arr.Add(lblPhanTram);
                arr.Add(progressBar);
                arr.Add(lblmessage);


                ////http://stackoverflow.com/questions/3542061/how-do-i-stop-a-thread-when-my-winform-application-closes
                theardProcess.IsBackground = true;
                theardProcess.Start(arr);



            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "button2_Click");
            }
        }

        private void ProcessImport(object arrControl)
        {
            try
            {

                Utilities_Import Utiliti = new Utilities_Import();
                Utiliti.TableName = System.IO.Path.GetFileName(txt_FileName.Text);
                Utiliti.ConnectionString = connectionString;
                Utiliti.ColumnNamesList = DanhSachCotnew();
                Utiliti.Dict = DanhSachCot();
                Utiliti.TongrowsText = 100;
                Utiliti.ProcessImport(arrControl);



                /*===================================================================*/
                string strthongbao = Utilities_Import.hasProcess ? "Hoàn thành load số liệu." : "Tạm dừng do người dùng!!!";
                lblmessage.Text = strthongbao;
                MessageBox.Show(strthongbao, "Thông Báo");

                BindingTelNumberToGridView();
                BindingTelNumberToGridViewTonTai();

                btn_View.Enabled = true;
                button1.Enabled = true;
                button2.Enabled = true;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ProcessImport");
            }
        }

        private Dictionary<string, string> DanhSachCot()
        {
            Dictionary<string, string> mode = new Dictionary<string, string>();
            mode.Add("cbb_TelNumber", cbb_TelNumber.SelectedIndex == 0 ? "" : cbb_TelNumber.Text);
            mode.Add("cbb_ten_khach_hang", cbb_ten_khach_hang.SelectedIndex == 0 ? "" : cbb_ten_khach_hang.Text);
            mode.Add("cbb_dia_chi", cbb_dia_chi.SelectedIndex == 0 ? "" : cbb_dia_chi.Text);
            mode.Add("cbb_Ngay", cbb_Ngay.SelectedIndex == 0 ? "" : cbb_Ngay.Text);
            mode.Add("cbb_Thang", cbb_Thang.SelectedIndex == 0 ? "" : cbb_Thang.Text);
            mode.Add("cbb_namsinh", cbb_namsinh.SelectedIndex == 0 ? "" : cbb_namsinh.Text);
            mode.Add("cbb_nganhang", cbb_nganhang.SelectedIndex == 0 ? "" : cbb_nganhang.Text);
            mode.Add("cbb_cuoc", cbb_cuoc.SelectedIndex == 0 ? "" : cbb_cuoc.Text);
            mode.Add("cbb_sim", cbb_sim.SelectedIndex == 0 ? "" : cbb_sim.Text);
            mode.Add("cbb_tinh", cbb_tinh.SelectedIndex == 0 ? "" : cbb_tinh.Text);
            mode.Add("cbb_ghichu", cbb_ghichu.SelectedIndex == 0 ? "" : cbb_ghichu.Text);
            mode.Add("cbb_gioitinh", cbb_gioitinh.SelectedIndex == 0 ? "" : cbb_gioitinh.Text);
            mode.Add("cbb_tinhcuoc", cbb_tinhcuoc.SelectedIndex == 0 ? "" : cbb_tinhcuoc.Text);

            mode.Add("cbb_phuong", cbb_Phuong.SelectedIndex == 0 ? "" : cbb_Phuong.Text);
            mode.Add("cbb_quanhuyen", cbb_quanhuyen.SelectedIndex == 0 ? "" : cbb_quanhuyen.Text);
            mode.Add("cbb_email", cbb_email.SelectedIndex == 0 ? "" : cbb_email.Text);
            mode.Add("cbb_ngay_kich_hoat", cbb_ngay_kich_hoat.SelectedIndex == 0 ? "" : cbb_ngay_kich_hoat.Text);
            mode.Add("cbb_goiCuoc", cbb_GoiCuoc.SelectedIndex == 0 ? "" : cbb_GoiCuoc.Text);
            mode.Add("cbb_dongmay", cbb_dongmay.SelectedIndex == 0 ? "" : cbb_dongmay.Text);
            mode.Add("cbb_hedieuhanh", cbb_HeDieuhanh.SelectedIndex == 0 ? "" : cbb_HeDieuhanh.Text);
            mode.Add("cbb_chucvu", cbb_chucvu.SelectedIndex == 0 ? "" : cbb_chucvu.Text);
            mode.Add("cbb_congty", cbb_congty.SelectedIndex == 0 ? "" : cbb_congty.Text);

            return mode;
        }

        private List<string> DanhSachCotnew()
        {
            List<string> model = new List<string>();
            if (cbb_TelNumber.SelectedIndex != 0)     model.Add(cbb_TelNumber.Text);
            if (cbb_ten_khach_hang.SelectedIndex != 0) model.Add(cbb_ten_khach_hang.Text);
            if (cbb_dia_chi.SelectedIndex != 0) model.Add(cbb_dia_chi.Text);
            if (cbb_Ngay.SelectedIndex != 0)    model.Add(cbb_Ngay.Text);
            if (cbb_Thang.SelectedIndex != 0)  model.Add(cbb_Thang.Text);
            if (cbb_namsinh.SelectedIndex != 0)   model.Add(cbb_namsinh.Text);
            if (cbb_nganhang.SelectedIndex != 0)   model.Add(cbb_nganhang.Text);
            if (cbb_cuoc.SelectedIndex != 0) model.Add(cbb_cuoc.Text);
            if (cbb_sim.SelectedIndex != 0)   model.Add(cbb_sim.Text);
            if (cbb_tinh.SelectedIndex != 0)  model.Add(cbb_tinh.Text);
            if (cbb_ghichu.SelectedIndex != 0)  model.Add(cbb_ghichu.Text);
            if (cbb_gioitinh.SelectedIndex != 0)model.Add(cbb_gioitinh.Text);
            if (cbb_tinhcuoc.SelectedIndex != 0) model.Add(cbb_tinhcuoc.Text);
            if (cbb_Phuong.SelectedIndex != 0)  model.Add(cbb_Phuong.Text);
            if (cbb_quanhuyen.SelectedIndex != 0)   model.Add(cbb_quanhuyen.Text);
            if (cbb_email.SelectedIndex != 0)  model.Add(cbb_email.Text);
            if (cbb_ngay_kich_hoat.SelectedIndex != 0) model.Add(cbb_ngay_kich_hoat.Text);
            if (cbb_GoiCuoc.SelectedIndex != 0)  model.Add(cbb_GoiCuoc.Text);
            if (cbb_dongmay.SelectedIndex != 0)   model.Add(cbb_dongmay.Text);
            if (cbb_HeDieuhanh.SelectedIndex != 0)  model.Add(cbb_HeDieuhanh.Text);
            if (cbb_chucvu.SelectedIndex != 0)   model.Add(cbb_chucvu.Text);
            if (cbb_congty.SelectedIndex != 0) model.Add(cbb_congty.Text);

            return model;
        }

        private void btnUpdateTrung_Click(object sender, EventArgs e)
        {
            try
            {
                long totalRowCount = 0;
                DataTable table1 = SQLDatabase.ExcDataTable("select COUNT(*) from dienthoai_goc a inner join dienthoai_new b on a.dienthoai=b.dienthoai");
                if (table1 != null && table1.Rows.Count > 0)
                    totalRowCount = long.Parse(table1.Rows[0][0].ToString());
                else
                    totalRowCount = 0;

                if (totalRowCount == 0)
                {
                    MessageBox.Show("Không có điện thoại mới nào trong danh sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Bạn có chắc là muốn cập nhật trạng thái \n danh sách số điện thoại trùng sang đã sữ dụng không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (SQLDatabase.ExcNonQuery("exec spCapNhat"))
                    {
                        BindingTelNumberToGridView();
                        MessageBox.Show("Chuyễn trạng thái thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Chuyễn trạng thái thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bạn có chắc cập nhật danh sách điện thoại gốc sang đã sữ dụng với số điện thội mới không?", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXuatfile_Click(object sender, EventArgs e)
        {
            if (radexcel.Checked)
                ExportExcel();
            else
                ExportText();

        }

        void ExportExcel()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Excel files (*.xls)|*.xls|Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            saveFileDialog1.Title = "Export file excel";
            saveFileDialog1.ShowDialog();


            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {

                DataTable table1 = SQLDatabase.ExcDataTable("exec [spExport]");
                if (table1.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu import", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                Cursor.Current = Cursors.WaitCursor;
                //lb_xuatfile.Visible = true;
                string strmess = (new ExcelAdapter(saveFileDialog1.FileName)).CreateAndWrite(table1, "sodienthoai", 1);
                Cursor.Current = Cursors.Default;
                //lb_xuatfile.Visible = false;

                MessageBox.Show(strmess, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        void ExportText()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Text files (*.txt)|* | All files (*.*)|*.*"; ;
            saveFileDialog1.Title = "Export file text";
            saveFileDialog1.ShowDialog();


            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {

                System.IO.StreamWriter str = new System.IO.StreamWriter(saveFileDialog1.FileName + ".txt");

                DataTable table1 = SQLDatabase.ExcDataTable("exec [spExport]");
                if (table1.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu import", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                Cursor.Current = Cursors.WaitCursor;
                //lb_xuatfile.Visible = true;

                foreach (DataRow item in table1.Rows)
                {
                    str.WriteLine(string.Format("{0};", item["dienthoai"]));
                }
                str.Flush();
                str.Close();

                Cursor.Current = Cursors.Default;
                //lb_xuatfile.Visible = false;
                MessageBox.Show("Xuất file text thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void xoadienthoaigoc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc là muốn reset lại dữ liệu gốc không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (SQLDatabase.ExcNonQuery("exec [spDelGoc]"))
                {

                    MessageBox.Show("Reset dữ liệu gốc thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Reset dữ liệu gốc thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                BindingTelNumberToGridView();
            }
        }

        private void resetĐiệnThoạiMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc là muốn reset lại dữ liệu mới không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (SQLDatabase.ExcNonQuery("delete from dienthoai_new"))
                {
                    MessageBox.Show("Reset dữ liệu mới thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Reset dữ liệu mới thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                BindingTelNumberToGridView();
            }
        }


        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_View_Click_1(object sender, EventArgs e)
        {
            StreamReader sReader;

            DataTable table = new DataTable();
            string[] fileNames, lineParts;

            string line;
            frmXemTruoc frm;

            try
            {

                fileNames = txt_FileName.Text.Split('.');


                sReader = new StreamReader(txt_FileName.Text);
                int SoCot = 999;
                char kytu = '\t';
                /*lay so cot*/
                while ((line = sReader.ReadLine()) != null)
                {

                    lineParts = line.Split(new char[] { kytu });
                    if (lineParts.Count() != 0)
                    {
                        SoCot = lineParts.Count() <= SoCot ? lineParts.Count() : SoCot;
                    }
                }
                /*tao table*/


                for (int i = 0; i < SoCot; i++)
                {
                    table.Columns.Add(string.Format("[{0}]", i.ToString()), typeof(string));
                }
                sReader.DiscardBufferedData();
                sReader.BaseStream.Seek(0, SeekOrigin.Begin);
                sReader.BaseStream.Position = 0;

                while ((line = sReader.ReadLine()) != null)
                {
                    lineParts = line.Split(new char[] { kytu });
                    DataRow rows = table.NewRow();
                    for (int i = 0; i < SoCot; i++)
                    {

                        rows[string.Format("[{0}]", i)] = lineParts[i];
                    }
                    table.Rows.Add(rows);
                }



                if (table.Rows.Count == 0)
                    MessageBox.Show("Không có dữ liệu !", "Xem truoc", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    frm = new frmXemTruoc();
                    frm.DataSourceDate = table;
                    frm.Title = txt_FileName.Text;
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "View DataSource", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                frmChang2 frm = new frmChang2();
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

        private void button4_Click(object sender, EventArgs e)
        {
            PleaseWait objPleaseWait = null;
            try
            {
                if (MessageBox.Show("Bạn có chắc thêm mới tất cả những số điện thoại này vào dữ liệu gốc không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes)
                {
                    return;
                }
                objPleaseWait = new PleaseWait();
                objPleaseWait.Show();
                Application.DoEvents();
                /*SQLDatabase.ExcDataTable(" insert into dienthoai_goc(ten_khach_hang, didong, dia_chi,ngay,thang, namsinh, cuoc, gioi_tinh, ngan_hang, sim, tinh, ghi_chu,  filenguon ,tinh_cuoc)" +
                                         " select a.ten_khach_hang, a.didong, a.dia_chi,a.ngay,a.thang, a.namsinh, a.cuoc, a.gioi_tinh, a.ngan_hang, a.sim, a.tinh, a.ghi_chu,  a.filenguon,a.tinh_cuoc "+
                                         " from dienthoai_new  a left join dienthoai_goc b on a.didong=b.didong where b.didong is null ");
                */
                DataTable tb = SQLDatabase.ExcDataTable("spInsert");


                objPleaseWait.Close();
                BindingTelNumberToGridView();
                BindingTelNumberToGridViewTonTai();

                MessageBox.Show(string.Format("Insert thành công! số điện thoại từ danh sách nguồn sang dữ liệu gốc \n {0}", ConvertType.ToInt(tb.Rows[0][0]) == 0 ? "" : string.Format("Ghi chú: Số lượng dữ liệu trùng trong dữ liệu nguồn là '{0}' vui lòng kiễm tra dữ liệu", ConvertType.ToInt(tb.Rows[0][0]))), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                objPleaseWait.Close();
            }
            catch (Exception ex)
            {
                objPleaseWait.Close();
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                PleaseWait objPleaseWait = new PleaseWait();
                objPleaseWait.Show();
                BindingTelNumberToGridView();
                BindingTelNumberToGridViewTonTai();
                objPleaseWait.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "button6_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmImport_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string command = "";
            PleaseWait objPleaseWait = new PleaseWait();
            try
            {
                frmChange3 frm = new frmChange3();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    string strsql = frm.SQL;
                    strsql +=string.Format(" from {0}.dbo.dienthoai_new  a left join {0}.dbo.dienthoai_goc b on a.didong=b.didong ",_strNameDatabase ) +
                             " where b.didong is null";
                    /*
                    DataTable table = SQLDatabase.ExcDataTable(strsql);
                    if (table.Rows.Count == 0)
                    {
                        MessageBox.Show("Không có dữ liệu cần import", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    */
                    objPleaseWait.Show();
                    Application.DoEvents();
                    //Export.ExportText(table, frm.Filename, "\t");
                    command = string.Format("exec [spExport] '{0}','{1}'", strsql, frm.Filename);
                    if (SQLDatabase.ExcNonQuery(command))
                    {
                        MessageBox.Show("Xuất file thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else {
                        MessageBox.Show("Xuất file thất bại!", "Thông báo");
                    }
                    objPleaseWait.Close();
                }
            }

            catch (Exception ex)
            {
                objPleaseWait.Close();
                MessageBox.Show(ex.Message, "button7_Click");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string command = "";
            PleaseWait objPleaseWait = new PleaseWait();
            try
            {
                frmChangKieuXuat frm = new frmChangKieuXuat();
                if (frm.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                frmChange3 frm1 = new frmChange3();
                if (frm1.ShowDialog() == DialogResult.OK)
                {
                    string strsql = frm1.SQL;
                    if (frm.KyTu == "tam")
                        strsql += string.Format(" from {0}.dbo.dienthoai_new  a inner join {0}.dbo.dienthoai_goc b on a.didong=b.didong", _strNameDatabase);
                    else
                        strsql += string.Format(" from {0}.dbo.dienthoai_goc  a inner join {0}.dbo.dienthoai_new b on a.didong=b.didong",_strNameDatabase);
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
                    Export.ExportText(table, frm1.Filename, "\t");
                    */
                    command = string.Format("exec [spExport] '{0}','{1}'", strsql, frm1.Filename);

                    objPleaseWait1.Close();
                    MessageBox.Show("Xuất file thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                objPleaseWait.Close();
                MessageBox.Show(ex.Message, "button7_Click");
            }
        }

        private void btnXoaTrungGoc_Click(object sender, EventArgs e)
        {
            PleaseWait objPleaseWait = new PleaseWait();
            try
            {
                if (MessageBox.Show("Bạn có chắc muốn xoá dữ liệu gốc trùng với dữ liệu tạm ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    objPleaseWait.Show();
                    Application.DoEvents();
                    if (SQLDatabase.ExcNonQuery("Delete a from dienthoai_goc a inner join dienthoai_new b on a.didong=b.didong"))
                    {
                        MessageBox.Show("Xoá xong dữ liệu gốc trùng dữ liệu nguồn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BindingTelNumberToGridView();
                        BindingTelNumberToGridViewTonTai();
                    }
                    objPleaseWait.Close();
                }
            }
            catch (Exception ex)
            {
                objPleaseWait.Close();
                MessageBox.Show(ex.Message, "btnXoaTrungGoc_Click");
            }
        }
    }
}
