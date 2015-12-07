using JCS.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StorePhone
{
    public partial class frmProcessImport : Form
    {
        public frmProcessImport()
        {
            InitializeComponent();
        }

     

        #region Fields

        private string connectionString, tableName, colTelNumber,  charSpit;
        private string nguon;
        private int countInsert;
        private bool hasProcess = true, flagFileText;
        private int change = 0;
       
        private List<string> columnNamesList;
        private Dictionary<string, string> dict;

        private Thread theardProcess;
        private DataTable tberror;
      

        #endregion // Fields

        #region Properties

        public string ConnectionString
        {
            set { connectionString = value; }
        }

        public List<string> ColumnNamesList
        {
            set { columnNamesList = value; }
        }

        public Dictionary<string, string> Dict
        {
            set { dict = value; }
        }

        public string Nguon
        {
            set { nguon = value; }
        }
        public int Change
        {
            get { return change; }
            set { change = value; }
        }

        public string TableName
        {
            set { tableName = value; }
        }

        public string ColTelNumber
        {
            set { colTelNumber = value; }
        }

      

        public string CharSpit
        {
            set { charSpit = value; }
        }

        public int CountInsert
        {
            get { return countInsert; }
            set { countInsert = value; }
        }

        public bool FlagFileText
        {
            set { flagFileText = value; }
        }

        #endregion // Properties

        private void frmProcessImport_Load(object sender, EventArgs e)
        {
            ParameterizedThreadStart par;
            ArrayList arr;
           
            try
            {

                tberror = new DataTable();
                tberror.Columns.Add("vitri", typeof(int));
                tberror.Columns.Add("sodienthoai", typeof(string));
                tberror.Columns.Add("status", typeof(string));

                gridview_error.DataSource = tberror;
                
                /**/
                Control.CheckForIllegalCrossThreadCalls = false;

                if (flagFileText)
                    par = new ParameterizedThreadStart(ProcessImportFileText);
                else
                    par = new ParameterizedThreadStart(ProcessImport);

                /*kiem tra xem ghi de hay la xoa roi ghi*/
                if (change == 0)
                {/*xoa roi ghi moi*/
                    SQLDatabase.ExcNonQuery("delete from dienthoai_new");
                    SQLDatabase.ExcNonQuery("DBCC CHECKIDENT ('[dienthoai_new]', RESEED, 0)");
                }

                theardProcess = new Thread(par);
                //----- Add arraylist control
                arr = new ArrayList();
                arr.Add(lbl_Title);
                arr.Add(pictureBox_title);
                arr.Add(progressBar);
                arr.Add(btn_Stop);
                arr.Add(gridview_error);
                arr.Add(tabControl);
                arr.Add(richTextBox);
                arr.Add(btn_xuat);
                
                //----- Begin process import
                theardProcess.Start(arr);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load Form ProcessImport", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      



        //----- Process Import
        private void ProcessImport(object arrControl)
        {
            
            OleDbDataReader reader = null;
            countInsert = 0;
           
            int process = 0;
            int countErro = 0;
            object  totalRow;
            string oleDBcommand;
            

            try
            {
                //----- Add control process from
                ArrayList arr1 = (ArrayList)arrControl;
                Label lb_title1 = (Label)arr1[0];
                Label pictureBox_title1 = (Label)arr1[1];
                NeroBar progressBar11 = (NeroBar)arr1[2];
                Button btn_Stop1 = (Button)arr1[3];
                DataGridView gridview1 = (DataGridView)arr1[4];
                TabControl tabControl1 = (TabControl)arr1[5];
                RichTextBox richTextBox1 = (RichTextBox)arr1[6];
                Button btn_xuat1 = (Button)arr1[7];
                
                //----- update display control
                lb_title1.Update();
               
                btn_Stop1.Update();
                gridview1.Update();
               

                //----- Get Total row
                if (connectionString.Contains(".xls") || connectionString.Contains(".XLS"))
                    oleDBcommand = "Select COUNT(*) AS TotalRow From [" + tableName + "$]";
                else
                    oleDBcommand = "Select COUNT(*) AS TotalRow From [" + tableName + "]";

                totalRow = SQLDatabase.ExcOleScalar(connectionString, oleDBcommand);
                if (totalRow == null)
                    return;
                //----- Get Data from Source

                string[] columnNames = new string[columnNamesList.Count()];

                for (int i = 0; i < columnNames.Count(); i++){
                    columnNames[i] = columnNamesList[i];
                }
                reader = SQLDatabase.ExcOleReaderDataSource(connectionString, tableName, columnNames);

                progressBar11.MaxValue = int.Parse(totalRow.ToString());
                progressBar11.MinValue = 0;

                while (reader.Read())
                {
                    //----- Stop process if false
                    if (hasProcess)
                    {
                        process++;
                       
                                //----- Insert to TelNumberChange Table
                                dienthoai_new model= new dienthoai_new();
                                if(dict.FirstOrDefault(x=>x.Key=="cbb_TelNumber").Value !=""){
                                    model.didong = reader[dict.FirstOrDefault(x=>x.Key=="cbb_TelNumber").Value].ToString().Trim();
                                }
                                if(dict.FirstOrDefault(x=>x.Key=="cbb_ten_khach_hang").Value !=""){
                                    string xx = dict.FirstOrDefault(x => x.Key == "cbb_ten_khach_hang").Value;
                                    model.ten_khach_hang = reader[dict.FirstOrDefault(x=>x.Key=="cbb_ten_khach_hang").Value].ToString().Trim();
                                }
                                if(dict.FirstOrDefault(x=>x.Key=="cbb_dia_chi").Value !=""){
                                    model.dia_chi = reader[dict.FirstOrDefault(x=>x.Key=="cbb_dia_chi").Value].ToString().Trim();
                                }
                                if (dict.FirstOrDefault(x => x.Key == "cbb_Ngay").Value != "")
                                {
                                    model.ngay = reader[dict.FirstOrDefault(x => x.Key == "cbb_Ngay").Value].ToString().Trim();
                                }
                                if (dict.FirstOrDefault(x => x.Key == "cbb_Thang").Value != "")
                                {
                                    model.thang = reader[dict.FirstOrDefault(x => x.Key == "cbb_Thang").Value].ToString().Trim();
                                }
                                if(dict.FirstOrDefault(x=>x.Key=="cbb_namsinh").Value !=""){
                                    model.namsinh = reader[ dict.FirstOrDefault(x=>x.Key=="cbb_namsinh").Value].ToString().Trim();
                                }
                                if (dict.FirstOrDefault(x => x.Key == "cbb_gioitinh").Value != "")
                                {
                                    model.gioi_tinh = reader[dict.FirstOrDefault(x => x.Key == "cbb_gioitinh").Value].ToString().Trim();
                                }
                                if(dict.FirstOrDefault(x=>x.Key=="cbb_nganhang").Value !=""){
                                    model.ngan_hang =reader[dict.FirstOrDefault(x=>x.Key=="cbb_nganhang").Value].ToString().Trim();
                                }
                                if(dict.FirstOrDefault(x=>x.Key=="cbb_cuoc").Value !=""){
                                    model.cuoc =reader[dict.FirstOrDefault(x=>x.Key=="cbb_cuoc").Value].ToString().Trim();
                                }
                                if(dict.FirstOrDefault(x=>x.Key=="cbb_sim").Value !=""){
                                    model.sim = reader[ dict.FirstOrDefault(x=>x.Key=="cbb_sim").Value].ToString().Trim();
                                }
                                if(dict.FirstOrDefault(x=>x.Key=="cbb_tinh").Value !=""){
                                    model.tinh =reader[dict.FirstOrDefault(x=>x.Key=="cbb_tinh").Value].ToString().Trim();
                                }
                                if (dict.FirstOrDefault(x => x.Key == "cbb_tinhcuoc").Value != "")
                                {
                                    model.tinh_cuoc = reader[dict.FirstOrDefault(x => x.Key == "cbb_tinhcuoc").Value].ToString().Trim();
                                }
                                if(dict.FirstOrDefault(x=>x.Key=="cbb_ghichu").Value !=""){
                                    model.ghi_chu =reader[ dict.FirstOrDefault(x=>x.Key=="cbb_ghichu").Value].ToString().Trim();
                                }
                                model.filenguon = nguon;
                           thongbaokiemtra kq  = KiemTraSoLieu(model);
                           if (kq.trangthai)
                           {
                                int nloi = TestTelNumberExists(model.didong);
                                if (nloi == 0) {
                                    if (SQLDatabase.AddDienThoaiNEW(model) == true) {
                                        countInsert++;
                                        //lb_HasImport1.Text = countInsert.ToString() + " / " + totalRow + " thuê bao";
                                    }
                                } else {
                                    //gridview1.Rows.Add(process, model.didong, "Đã tồn tại");
                                    tberror.Rows.Add(process, model.didong, "Đã tồn tại");
                                    countErro++;
                                    /*da ton tai*/
                                }
                           } 
                            else { /*loi*/
                           // gridview1.Rows.Add(process, model.didong, kq.NoiDung);
                            tberror.Rows.Add(process, model.didong, kq.NoiDung);
                            countErro++;
                            }
                        ShowMessage(ref richTextBox1, process, countErro, countInsert, int.Parse(totalRow.ToString()));
                       
                    
                        tabControl1.TabPages[1].Text = string.Format("Error {0}", countErro);
                        tabControl1.Update();

                      
                        progressBar11.Value = process;
                        progressBar11.Update();
                        Thread.Sleep(0);
                    }
                
                }
                if (countErro == 0) {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }

                btn_Stop1.Text = "Đóng";
                btn_xuat1.Enabled = true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "ProcessImport", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

      
        //----- Process Import File Text
        private void ProcessImportFileText(object arrControl)
        {
            StreamReader sReader;
            
            countInsert = 0;
            int process = 0;
            int countErro = 0;
            object  totalRow;
            string line;
            string[] lineParts, countLines;
            char[] charSpits;

            try
            {
                //----- Add control process from
                ArrayList arr1 = (ArrayList)arrControl;
                Label lb_title1 = (Label)arr1[0];
                Label pictureBox_title1 = (Label)arr1[1];
                NeroBar progressBar11 = (NeroBar)arr1[2];
                Button btn_Stop1 = (Button)arr1[3];
                DataGridView gridview1 = (DataGridView)arr1[4];
                TabControl tabControl1 = (TabControl)arr1[5];
                RichTextBox richTextBox1 = (RichTextBox)arr1[6];
                Button btn_xuat1 = (Button)arr1[7];

                //----- update display control
                lb_title1.Update();

                btn_Stop1.Update();
                gridview1.Update();

                //----- Get Total row                
                countLines = File.ReadAllLines(connectionString);
                totalRow = countLines.Length;
                if (totalRow == null)
                    return;

                //----- Get Data from Source 
                progressBar11.MaxValue = int.Parse(totalRow.ToString());
                progressBar11.MinValue = 0;
              

                sReader = new StreamReader(connectionString);
                charSpits = charSpit.ToCharArray();
                while ((line = sReader.ReadLine()) != null)
                {
                    //----- Stop process if false
                    if (hasProcess)
                    {
                        process++;

                        lineParts = line.Split(charSpits);
                        //----- Test value import 
                        dienthoai_new model= new dienthoai_new();
                        if(dict.FirstOrDefault(x=>x.Key=="cbb_TelNumber").Value !=""){
                            model.didong = lineParts[Convert.ToInt32(dict.FirstOrDefault(x => x.Key == "cbb_TelNumber").Value)].Trim();
                        }
                        if(dict.FirstOrDefault(x=>x.Key=="cbb_ten_khach_hang").Value !=""){
                              model.ten_khach_hang = lineParts[Convert.ToInt32(dict.FirstOrDefault(x=>x.Key=="cbb_ten_khach_hang").Value)].Trim();
                        }
                        if(dict.FirstOrDefault(x=>x.Key=="cbb_dia_chi").Value !=""){
                              model.dia_chi = lineParts[Convert.ToInt32(dict.FirstOrDefault(x=>x.Key=="cbb_dia_chi").Value)].Trim();
                        }
                        if (dict.FirstOrDefault(x => x.Key == "cbb_Ngay").Value != "")
                        {
                            model.ngay = lineParts[Convert.ToInt32(dict.FirstOrDefault(x => x.Key == "cbb_Ngay").Value)].Trim();
                        }
                        if (dict.FirstOrDefault(x => x.Key == "cbb_Thang").Value != "")
                        {
                            model.thang = lineParts[Convert.ToInt32(dict.FirstOrDefault(x => x.Key == "cbb_Thang").Value)].Trim();
                        }
                        if(dict.FirstOrDefault(x=>x.Key=="cbb_gioitinh").Value !=""){
                            model.gioi_tinh = lineParts[Convert.ToInt32(dict.FirstOrDefault(x => x.Key == "cbb_gioitinh").Value)].Trim();
                        }
                        if (dict.FirstOrDefault(x => x.Key == "cbb_namsinh").Value != "")
                        {
                            model.namsinh = lineParts[Convert.ToInt32(dict.FirstOrDefault(x => x.Key == "cbb_namsinh").Value)].Trim();
                        }
                        if(dict.FirstOrDefault(x=>x.Key=="cbb_nganhang").Value !=""){
                              model.ngan_hang = lineParts[Convert.ToInt32(dict.FirstOrDefault(x=>x.Key=="cbb_nganhang").Value)].Trim();
                        }
                        if(dict.FirstOrDefault(x=>x.Key=="cbb_cuoc").Value !=""){
                              model.cuoc = lineParts[Convert.ToInt32(dict.FirstOrDefault(x=>x.Key=="cbb_cuoc").Value)].Trim();
                        }
                        if(dict.FirstOrDefault(x=>x.Key=="cbb_sim").Value !=""){
                              model.sim = lineParts[Convert.ToInt32(dict.FirstOrDefault(x=>x.Key=="cbb_sim").Value)].Trim();
                        }
                        if(dict.FirstOrDefault(x=>x.Key=="cbb_tinh").Value !=""){
                              model.tinh = lineParts[Convert.ToInt32(dict.FirstOrDefault(x=>x.Key=="cbb_tinh").Value)].Trim();
                        }
                        if (dict.FirstOrDefault(x => x.Key == "cbb_tinhcuoc").Value != "")
                        {
                            model.tinh_cuoc = lineParts[Convert.ToInt32(dict.FirstOrDefault(x => x.Key == "cbb_tinhcuoc").Value)].Trim();
                        }
                        if(dict.FirstOrDefault(x=>x.Key=="cbb_ghichu").Value !=""){
                              model.ghi_chu = lineParts[Convert.ToInt32(dict.FirstOrDefault(x=>x.Key=="cbb_ghichu").Value)].Trim();
                        }
                        model.filenguon = nguon;
                        thongbaokiemtra kq  = KiemTraSoLieu(model);
                        if (kq.trangthai)
                        {
                             //----- Test exists in database
                            int nloi = TestTelNumberExists(model.didong);
                            if (nloi == 0)
                            {
                                //----- Insert to TelNumberChange Table
                                if (SQLDatabase.AddDienThoaiNEW(model) == true)
                                    countInsert++;
                            }
                            else {
                                tberror.Rows.Add(process, model.didong, "Đã tồn tại");
                                countErro++;
                                /*da ton tai*/
                            }
                        }
                        else { /*loi*/
                            tberror.Rows.Add(process, model.didong, kq.NoiDung);
                            countErro++;
                        }

                        ShowMessage(ref richTextBox1, process, countErro, countInsert, int.Parse(totalRow.ToString()));

                        tabControl1.TabPages[1].Text = string.Format("Error {0}", countErro);
                        tabControl1.Update();

                        progressBar11.Value = process;
                        progressBar11.Update();
                        Thread.Sleep(0);
                    }
                }

             

                if (countErro == 0) {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }

                btn_Stop1.Text = "Đóng";
                btn_xuat.Enabled = true;


            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "ProcessImportFileText", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        //----- Test value NumberPhone
        private int TestTelNumberExists(string telNumber)
        {
            try
            {
                object hasValue;
            
               hasValue = SQLDatabase.ExcScalar("Select 1 From dienthoai_new Where didong='" + telNumber + "'");
                
                if (hasValue == null)
                    return 0;/*ok*/
                else
                    return 2;
            }
            catch (Exception ex)
            {
                return 1;
            }
        }

        private thongbaokiemtra KiemTraSoLieu(dienthoai_new model)
        {
            try
            {
                if(!TestTelNumber(model.didong))
                    return new thongbaokiemtra() { trangthai = false, NoiDung = "Điện thoại không đúng format" };


                if (model.gioi_tinhold != "")
                if(model.gioi_tinhold!="0"  || model.gioi_tinhold!="1" || model.gioi_tinhold.ToLower()!="trai" || model.gioi_tinhold.ToLower()!="nữ" || model.gioi_tinhold.ToLower()!="nu"||
                    model.gioi_tinhold.ToLower()!="true" || model.gioi_tinhold.ToLower()!="false")
                    return new thongbaokiemtra() { trangthai = false, NoiDung = "Giới tính không đúng format [Nam|Nữ];[0|1];[trai|gai];[true|false]" };
                return new thongbaokiemtra() { trangthai = true, NoiDung = "Số liệu đúng" };
            }
            catch (Exception ex)
            {
                return new thongbaokiemtra(){ trangthai = false, NoiDung= ex.Message};
            }
        }
        //----- Test value NumberPhone


      
        private bool TestTelNumber(string telNew)
        {
            try
            {
              
                Int64.Parse(telNew);

                if (telNew == "" || telNew.Length < 8 || telNew.Length > 13)
                {
                    
                    return false;
                }
                /*
                if (telNew.Substring(0, 2) != "84" && telNew.Substring(0, 1) != "0")
                {
                   
                    return false;
                }
                 * */
                /*kiem tra ton tai*/
                
                return true;
            }
            catch
            {
               
                return false;
            }
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            PleaseWait objPleaseWait = new PleaseWait();
            try {
                if (tberror.Rows.Count==0) {
                    MessageBox.Show("Không có dữ liệu export!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                }

                   SaveFileDialog saveFileDialog1 = new SaveFileDialog();
             saveFileDialog1.Title = "Xuất file";
             saveFileDialog1.ShowDialog();

            

   // If the file name is not an empty string open it for saving.
             if (saveFileDialog1.FileName != "")
             {

                 objPleaseWait.Show();
                 Application.DoEvents();
                 ExcelAdapter excel = new ExcelAdapter("");
                 excel.SFilePath = saveFileDialog1.FileName;
                 excel.CreateAndWrite(tberror, "ErrorImport", 1);
             }
                objPleaseWait.Close();
            } catch (Exception ex) {
                objPleaseWait.Close();
                MessageBox.Show(ex.Message, "button1_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);   
            }
           
        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {
            try
            {
                if (!hasProcess){
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    return;
                }
                hasProcess = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "btn_Stop_Click");
            }
        }

        private void ShowMessage(ref RichTextBox rich,int vitri, int loi,int insertthanhcong, int tongrows) {
            string s2 =flagFileText ? "Text" : "Excel";
            rich.Text = string.Format("Import dữ liệu.\n Đường dẫn:{0} \n Loại:{1} \n Đang xử lý: {2} \n Số lượng thành công:{3} \n Số lượng thất bại:{4}",nguon,s2,string.Format("{0}/{1}",vitri,tongrows),insertthanhcong,loi);
            rich.Update();
        }
    }
}
