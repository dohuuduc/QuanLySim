using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
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

                //----- Add Item combobox Search Type
                cbb_TypeDataSource.Items.AddRange(new object[] { "----- Chọn loại dữ liệu -----",  
                "Microsoft Excel (*.xls,*.xlsx)","Text File (*.txt)"});
                cbb_TypeDataSource.SelectedIndex = 0;
                //----- Enabled button View,Import
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
                groupBox_grid.Text = "Xem tất cả thuê bao";


                dataGrid_ListTelNumberNew.DataSource = SQLDatabase.ExcDataTable(" select    a.Id, a.ten_khach_hang, a.didong, a.dia_chi,a.ngay,a.thang, a.namsinh, a.cuoc, a.gioi_tinh, a.ngan_hang, a.sim, a.tinh, a.ghi_chu,  a.filenguon,a.tinh_cuoc,  a.creatdate "
                                                                                    + " from dienthoai_new  a left join dienthoai_goc b on a.didong=b.didong where b.didong is null");


                long totalRowCount = 0;
                DataTable table1 = SQLDatabase.ExcDataTable("Select COUNT(*) As TotalRow from dienthoai_new  a left join dienthoai_goc b on a.didong=b.didong " +
                                                            "where b.didong is null");
                if (table1 != null && Convert.ToInt32(table1.Rows[0][0]) > 0)
                {
                    totalRowCount = long.Parse(table1.Rows[0][0].ToString());
                    tabControl1.TabPages[1].Text = string.Format("Di động chưa tồn tại ở file gốc: {0}", totalRowCount);
                    button5.Enabled = true;
                    button7.Enabled = true;
                }
                else
                {
                    totalRowCount = 0;
                    button5.Enabled = false;
                    button7.Enabled = false;
                    tabControl1.TabPages[1].Text = string.Format("Di động chưa tồn tại ở file gốc");
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
                groupBox_grid.Text = "Xem tất cả thuê bao";
                dataGridView_tontai.DataSource = SQLDatabase.ExcDataTable("select  a.Id, a.ten_khach_hang, a.didong, a.dia_chi, a.ngay,a.thang,a.namsinh, a.cuoc, a.gioi_tinh, a.ngan_hang, a.sim, a.tinh, a.ghi_chu,  a.filenguon,a.tinh_cuoc,  a.creatdate "
                                                                       + " from dienthoai_new  a inner join dienthoai_goc b on a.didong=b.didong ");

                long totalRowCount = 0;
                DataTable table1 = SQLDatabase.ExcDataTable("Select COUNT(*) As TotalRow from dienthoai_new  a inner join dienthoai_goc b on a.didong=b.didong ");
                if (table1 != null && Convert.ToInt32(table1.Rows[0][0]) > 0)
                {
                    totalRowCount = long.Parse(table1.Rows[0][0].ToString());
                    tabControl1.TabPages[0].Text = string.Format("Di động tồn tại ở file gốc: {0}", totalRowCount);
                    button1.Enabled = true;
                    button8.Enabled = true;
                }
                else
                {
                    totalRowCount = 0;
                    button1.Enabled = false;
                    button8.Enabled = false;
                    tabControl1.TabPages[0].Text = string.Format("Di động tồn tại ở file gốc");
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
                if (cbb_TypeDataSource.SelectedIndex == 0)
                {
                    MessageBox.Show("Bạn chưa chọn loại Dữ liệu nguồn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {

                    if (cbb_TypeDataSource.SelectedIndex == 1)
                    {
                        openFile.Filter = "Excel files (*.xls)|*.xls|Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                    }
                    else if (cbb_TypeDataSource.SelectedIndex == 2)
                    {
                        openFile.Filter = "Text File (*.txt)|*.txt|All files (*.*)|*.*";
                    }

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
                cbb_NameTable.Enabled = enabled;

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
            DataTable tbGetNameDisplay;
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
                        fileName = txt_FileName.Text.Split('.');
                        //----- Get file to combobox

                        if (fileName[fileName.Length - 1].ToLower() == "xls" || fileName[fileName.Length - 1].ToLower() == "xlsx")
                        {
                            //----- Display infomation process
                            if (fileInfo.Length > 2000000)
                            {
                                // dlgWaitProcess = new DevExpress.Utils.WaitDialogForm("Vui lòng chờ...", "Đang lấy dữ liệu", new Size(150, 50));
                            }

                            if (fileName[fileName.Length - 1].ToLower() == "xls")
                                connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + txt_FileName.Text + ";Extended Properties=\"Excel 8.0;\"";
                            else
                                connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + txt_FileName.Text + ";Extended Properties=\"Excel 12.0;\"";

                            tbTable = SQLDatabase.ExcOleDbSchemaTable(connectionString);
                            if (tbTable != null)
                            {
                                cbb_NameTable.Items.Clear();

                                tbGetNameDisplay = new DataTable();
                                tbGetNameDisplay.Columns.Add("TableName");
                                for (int i = 0; i < tbTable.Rows.Count; i++)
                                {
                                    //----- Add TableName into Combobox
                                    name = tbTable.Rows[i]["TABLE_NAME"].ToString();
                                    if (name.Contains("$"))
                                    {
                                        if (name.Contains("'"))
                                        {
                                            for (int j = 0; j < name.Length; j++)
                                            {
                                                if (Convert.ToString(name[j]) != "'")
                                                    tableName += name[j];
                                            }
                                            cbb_NameTable.Items.Add(tableName.Substring(0, tableName.Length - 1));
                                            tableName = null;
                                        }
                                        else
                                        {
                                            cbb_NameTable.Items.Add(name.Substring(0, name.Length - 1));
                                        }
                                    }
                                }
                                cbb_NameTable.SelectedIndex = 0;
                            }
                            //----- Exit Form Process
                            // if (dlgWaitProcess != null)
                            //     dlgWaitProcess.Close();
                        }
                        else if (fileName[fileName.Length - 1] == "txt" || fileName[fileName.Length - 1] == "TXT")
                        {
                            //MessageBox.Show("Không thể lấy tên bảng và tên cột từ loại tập tin '.txt' !", "load Data Source", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            //return;
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


                            sReader = new StreamReader(txt_FileName.Text);
                            if (sReader.ReadLine() != null)
                            {
                                line = sReader.ReadLine();
                                lineParts = line.Split(new char[] { ';' });
                                for (int i = 0; i < lineParts.Count(); i++)
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
                                }
                            }
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

                        }
                        else
                        {
                            MessageBox.Show("Tập tin của dữ liệu nguồn phải có dạng (*.mdb,*.xls,*.dbf,*.txt).\nVui lòng kiểm tra lại !", "load Data Source", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
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
        }
        private void cbb_TypeDataSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_TypeDataSource.SelectedIndex == 0)
            {
                EnabledControl2(false);
            }
            else
            {
                EnabledControl2(true);
            }
        }

        private void EnabledControl2(bool enabled)
        {
            try
            {
                cbb_NameTable.Enabled = enabled;
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
                txtKyTu.Enabled = !enabled;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "EnabledControl2");
            }
        }

        private void btn_View_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbb_TypeDataSource.SelectedIndex == 0)/*excel*/
                {
                    MessageBox.Show("Chưa có 'dữ liệu nguồn' cần view", "load Data Source", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (cbb_TypeDataSource.SelectedIndex == 1)
                {
                    if (cbb_NameTable.SelectedIndex == 1)
                    {
                        MessageBox.Show("Vui lòng chọn sheet", "load Data Source", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (cbb_TelNumber.SelectedIndex == 1)
                    {
                        MessageBox.Show("Vui lòng chọn cột", "load Data Source", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else if (cbb_TypeDataSource.SelectedIndex == 2)
                {
                    if (txtKyTu.Text == "")
                    {
                        MessageBox.Show("Vui lòng nhập ký tự tách chuỗi", "load Data Source", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "btn_View_Click");
            }
        }


        private void cbb_NameTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable tbColumnSource;
            string strTableName;

            try
            {
                //----- Get tableName
                strTableName = cbb_NameTable.Text;
                if (connectionString.Contains(".xls") || connectionString.Contains(".XLS"))
                {
                    strTableName += "$";

                    if (strTableName.Contains(" "))
                    {
                        strTableName = "'" + strTableName + "'";
                    }
                }

                //----- Get columnName
                tbColumnSource = new DataTable();
                tbColumnSource = SQLDatabase.ExcOleDbSchemaColumn(connectionString, strTableName);
                //----- Clear Item combobox
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


                foreach (DataRow row in tbColumnSource.Rows)
                {
                    cbb_TelNumber.Items.Add(row["COLUMN_NAME"].ToString());
                    cbb_ten_khach_hang.Items.Add(row["COLUMN_NAME"].ToString());
                    cbb_dia_chi.Items.Add(row["COLUMN_NAME"].ToString());
                    cbb_Ngay.Items.Add(row["COLUMN_NAME"].ToString());
                    cbb_Thang.Items.Add(row["COLUMN_NAME"].ToString());
                    cbb_namsinh.Items.Add(row["COLUMN_NAME"].ToString());
                    cbb_nganhang.Items.Add(row["COLUMN_NAME"].ToString());
                    cbb_cuoc.Items.Add(row["COLUMN_NAME"].ToString());
                    cbb_sim.Items.Add(row["COLUMN_NAME"].ToString());
                    cbb_tinh.Items.Add(row["COLUMN_NAME"].ToString());
                    cbb_ghichu.Items.Add(row["COLUMN_NAME"].ToString());
                    cbb_gioitinh.Items.Add(row["COLUMN_NAME"].ToString());
                    cbb_tinhcuoc.Items.Add(row["COLUMN_NAME"].ToString());

                    dscot.Add(row["COLUMN_NAME"].ToString());

                }

                if (tbColumnSource.Rows.Count > 0)
                {
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
                }
                //----- Enabled button View,Import
                EnabledBotton();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Selected TableName");
                return;
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
            frmProcessImport dlg_ProcessImport;
            frmChange dlg_Char;
            string[] fileNames;

            try
            {
                if (cbb_TelNumber.SelectedIndex == 0)
                {
                    MessageBox.Show("Vui lòng chọn thông tin, ít nhất phải chọn thông tin di động", "Thông báo");
                    cbb_TelNumber.Focus();
                    return;
                }
                //dataGrid_ListTelNumberNew.Rows.Clear();
                dlg_ProcessImport = new frmProcessImport();

                fileNames = txt_FileName.Text.Split('.');
                if (fileNames[fileNames.Length - 1] == "txt" || fileNames[fileNames.Length - 1] == "TXT")
                {
                    if (txtKyTu.Text == "")
                    {
                        MessageBox.Show("Nhập ký tự tách chuỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    dlg_Char = new frmChange();
                    if (dlg_Char.ShowDialog() == DialogResult.Cancel)
                    {
                        return;
                    }

                    dlg_ProcessImport.ConnectionString = txt_FileName.Text;
                    dlg_ProcessImport.CharSpit = txtKyTu.Text;
                    dlg_ProcessImport.Change = dlg_Char.Change;
                    dlg_ProcessImport.FlagFileText = true;
                    dlg_ProcessImport.Nguon = NamesFile;
                    dlg_ProcessImport.Dict = DanhSachCot();


                }
                else
                {
                    dlg_Char = new frmChange();
                    if (dlg_Char.ShowDialog() == DialogResult.Cancel)
                    {
                        return;
                    }

                    //----- Get tableName and columnName                    
                    dlg_ProcessImport.ConnectionString = connectionString;
                    dlg_ProcessImport.TableName = cbb_NameTable.Text;
                    dlg_ProcessImport.ColTelNumber = cbb_TelNumber.Text;
                    dlg_ProcessImport.Change = dlg_Char.Change;
                    dlg_ProcessImport.FlagFileText = false;
                    dlg_ProcessImport.Nguon = NamesFile;
                    dlg_ProcessImport.Dict = DanhSachCot();
                    dlg_ProcessImport.ColumnNamesList = dscot;
                }


                //----- Open form processbar
                if (dlg_ProcessImport.ShowDialog() == DialogResult.OK)
                {
                    if (dlg_ProcessImport.CountInsert > 0)
                    {
                        //----- Change tilte group
                        //groupBox_ListPhone.Text = "Danh sách số điện thoại vừa Import xong";
                        if (MessageBox.Show("Đã Import xong " + dlg_ProcessImport.CountInsert
                            + " Thuê Bao hợp lệ\nBạn có muốn tiếp tục Import không ?", "Thông báo",
                            MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                        {


                            this.DialogResult = DialogResult.Cancel;
                            this.Close();

                        }
                        BindingTelNumberToGridView();
                        BindingTelNumberToGridViewTonTai();
                    }
                    else
                    {
                        MessageBox.Show("Chưa có thuê bao hợp lệ nào được import", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Import", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            return mode;
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
            OleDbDataReader reader = null;
            DataTable table = new DataTable();
            string[] columnNames, fileNames, lineParts;

            string line;
            frmXemTruoc frm;

            try
            {

                fileNames = txt_FileName.Text.Split('.');
                if (fileNames[fileNames.Length - 1] == "txt" || fileNames[fileNames.Length - 1] == "TXT")
                {

                    sReader = new StreamReader(txt_FileName.Text);
                    int SoCot = 999;
                    /*lay so cot*/
                    while ((line = sReader.ReadLine()) != null)
                    {
                        lineParts = line.Split(new char[] { ';' });
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
                        lineParts = line.Split(new char[] { ';' });
                        DataRow rows = table.NewRow();
                        for (int i = 0; i < SoCot; i++)
                        {

                            rows[string.Format("[{0}]", i)] = lineParts[i];
                        }
                        table.Rows.Add(rows);
                    }
                }
                else
                {
                    columnNames = new string[dscot.Count];

                    for (int i = 0; i < dscot.Count; i++)
                    {
                        columnNames[i] = dscot[i];
                    }

                    for (int i = 0; i < columnNames.Count(); i++)
                    {
                        table.Columns.Add(columnNames[i], typeof(string));
                    }

                    reader = SQLDatabase.ExcOleReaderDataSource(connectionString, cbb_NameTable.Text, columnNames, 200);
                    if (reader != null)
                    {
                        while (reader.Read())
                        {
                            
                            DataRow rows = table.NewRow();
                            for (int i = 0; i < columnNames.Count(); i++)
                            {
                                rows[columnNames[i]] = reader[columnNames[i]].ToString().Trim();
                            }
                            table.Rows.Add(rows);
                            //if (dlgWaitProcess != null)
                            //    dlgWaitProcess.Close();
                        }
                    }
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
                SQLDatabase.ExcDataTable(" insert into dienthoai_goc(ten_khach_hang, didong, dia_chi,ngay,thang, namsinh, cuoc, gioi_tinh, ngan_hang, sim, tinh, ghi_chu,  filenguon ,tinh_cuoc)" +
                                         " select a.ten_khach_hang, a.didong, a.dia_chi,a.ngay,a.thang, a.namsinh, a.cuoc, a.gioi_tinh, a.ngan_hang, a.sim, a.tinh, a.ghi_chu,  a.filenguon,a.tinh_cuoc "+
                                         " from dienthoai_new  a left join dienthoai_goc b on a.didong=b.didong where b.didong is null ");

                objPleaseWait.Close();
                BindingTelNumberToGridView();
                BindingTelNumberToGridViewTonTai();

                MessageBox.Show("Insert thành công! số điện thoại từ danh sách tạm sang dữ liệu gốc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);



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
            PleaseWait objPleaseWait = new PleaseWait();
            try
            {
                DataTable table = SQLDatabase.ExcDataTable(" select  a.didong,a.ten_khach_hang, a.dia_chi,a.ngay,a.thang ,a.namsinh, a.cuoc, a.gioi_tinh, a.ngan_hang, a.sim, a.tinh,a.tinh_cuoc, a.ghi_chu,a.filenguon  " +
                                                            " from dienthoai_new  a left join dienthoai_goc b on a.didong=b.didong "+
                                                            " where b.didong is null");

                if (table.Rows.Count == 0) {
                    MessageBox.Show("Không có dữ liệu cần import", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "text|*.txt";
                saveFileDialog1.Title = "Xuất file";
                saveFileDialog1.ShowDialog();

                // If the file name is not an empty string open it for saving.
                if (saveFileDialog1.FileName != "")
                {
                    
                    objPleaseWait.Show();
                    Application.DoEvents();

                    Export.ExportText(table, saveFileDialog1.FileName);

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
            PleaseWait objPleaseWait = new PleaseWait();
            try
            {
                DataTable table = SQLDatabase.ExcDataTable(" select  a.didong,a.ten_khach_hang, a.dia_chi,a.ngay,a.thang ,a.namsinh, a.cuoc, a.gioi_tinh, a.ngan_hang, a.sim, a.tinh,a.tinh_cuoc, a.ghi_chu,a.filenguon  " +
                                                           " from dienthoai_new  a inner join dienthoai_goc b on a.didong=b.didong ");
                                                            
                if (table.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu cần import", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "text|*.txt";
                saveFileDialog1.Title = "Xuất file";
                saveFileDialog1.ShowDialog();

                // If the file name is not an empty string open it for saving.
                if (saveFileDialog1.FileName != "")
                {

                    objPleaseWait.Show();
                    Application.DoEvents();

                    Export.ExportText(table, saveFileDialog1.FileName);

                    objPleaseWait.Close();
                }
            }

            catch (Exception ex)
            {
                objPleaseWait.Close();
                MessageBox.Show(ex.Message, "button7_Click");
            }
        }



    }
}
