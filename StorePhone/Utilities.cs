using JCS.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using COMExcel = Microsoft.Office.Interop.Excel;

namespace StorePhone
{
    class Utilities
    {

        public static bool CheckNumberEnterKey(string value)
        {
            try
            {
                if (value.Length >= 10 && value.Length <= 12)
                {
                    Int64.Parse(value);
                    if(value.Substring(0,2) != "84" && value.Substring(0,1) !="0")
                        return false;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

    }

    public class ConvertType
    {
        public static int ToInt(object obj)
        {
            try
            {
                if (obj == null)
                    return 0;
                int rs = System.Convert.ToInt32(obj);
                if (rs < 0)
                    return 0;
                return rs;
            }
            catch
            {
                return 0;
            }
        }
        public static double ToDouble(object obj)
        {
            try
            {
                if (obj == null)
                    return 0;
                double rs = System.Convert.ToDouble(obj);
                if (rs < 0)
                    return 0;
                return rs;
            }
            catch
            {
                return 0;
            }
        }
        public static decimal ToDecimal(object obj)
        {
            try
            {
                if (obj == null)
                    return 0;
                decimal rs = System.Convert.ToDecimal(obj);
                if (rs < 0)
                    rs = 0;
                return rs;
            }
            catch { return 0; }
        }
        public static string ToString(object obj)
        {
            try
            {
                if (obj == null)
                    return "";
                return System.Convert.ToString(obj);
            }
            catch
            {
                return "";
            }
        }
        public static float ToFloat(object obj)
        {
            try
            {
                if (obj == null)
                    return 0;
                float rs = float.Parse(obj.ToString());
                if (rs < 0)
                    return 0;
                return rs;
            }
            catch
            {
                return 0;
            }
        }
        public static DateTime ToDateTime(object obj)
        {
            try
            {
                if (obj == null)
                    return DateTime.Now;
                DateTime dt = System.Convert.ToDateTime(obj, System.Globalization.CultureInfo.InvariantCulture);

                return dt;
            }
            catch
            {
                return DateTime.Now;
            }
        }
        public static Guid ToGuid(object obj)
        {
            try
            {
                if (obj == null)
                    return Guid.Empty;
                Guid dt = new Guid(obj.ToString());
                return dt;
            }
            catch
            {
                return Guid.Empty;
            }
        }

        public static string StripDiacritics(string accented)
        {
            return Regex.Replace(StripDiacriticsNormalize(accented), @"\s+", "-");
        }
        public static string StripDiacriticsNormalize(string accented)
        {
            Regex regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");
            string strFormD = accented.Normalize(System.Text.NormalizationForm.FormD);
            strFormD = regex.Replace(strFormD, String.Empty);
            strFormD = strFormD.Replace("Đ", "D").Replace("đ", "d");
            return Regex.Replace(strFormD, @"[^A-Za-z0-9 ]", "").Trim().ToLower();
        }
        const string HTML_TAG_PATTERN = "<.*?>";

        public static string StripHTML(object inputString, int charactor)
        {
            string str = Regex.Replace(ConvertType.ToString(inputString), HTML_TAG_PATTERN, string.Empty);
            if (str.Length > charactor)
                return str.Substring(0, charactor) + "...";
            return str;
        }
        public static string StripHTML(object inputString)
        {
            string str = Regex.Replace(ConvertType.ToString(inputString), HTML_TAG_PATTERN, string.Empty);
            return str;
        }
        public static string Encode(object str)
        {
            byte[] encbuff = System.Text.Encoding.UTF8.GetBytes(str.ToString());
            return Convert.ToBase64String(encbuff);
        }
        public static string Decode(object str)
        {
            byte[] decbuff = Convert.FromBase64String(str.ToString());
            return System.Text.Encoding.UTF8.GetString(decbuff);
        }
    }


    #region SortDataGridViewRow. It was used to sort rows of DataGrid

    public class SortDataGridViewRow : IComparer<DataGridViewRow> {
        public int Compare(DataGridViewRow row1, DataGridViewRow row2) {
            return row2.Index.CompareTo(row1.Index);
        }
    }

    #endregion


    public class CachedData
    {
        #region Fields

        private int pageSize = 50000;
        private long lastRowIndex = -1;
        private DataTable cachedTable = null;
        private long totalRowCount;
        private string commandToGetCount = "";
       

        private string commandToGetData = "";

        #endregion  // Fields

        #region Properties

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }

        public long LastRowIndex
        {
            get { return lastRowIndex; }
            set { lastRowIndex = value; }
        }

        public DataTable CachedTable
        {
            get { return cachedTable; }
            set { cachedTable = value; }
        }

        public long TotalRowCount
        {
            get { return totalRowCount; }
            set { totalRowCount = value; }
        }
       

        public string CommandToGetCount
        {
            set { commandToGetCount = value; }
        }

        

        public string CommandToGetData
        {
            set { commandToGetData = value; }
        }

        #endregion  // Properties

        #region Methods

        /// <summary>
        /// Function get data for Gridview paging
        /// </summary>
        /// <param name="rowIndex"></param>
        public void UpdateCachedData(long rowIndex)
        {
            DataTable table1;
                DataTable table2;
            long lastIndex, minIndex, maxIndex;
            string sqlCommand;

            try
            {
                if (commandToGetCount == "" )
                    return;

                lastIndex = rowIndex - (rowIndex % pageSize);
                if (lastIndex == lastRowIndex)
                    return;

                if (lastRowIndex == -1)
                {
                    table1 = SQLDatabase.ExcDataTable(commandToGetCount);
                    if (table1 != null && table1.Rows.Count > 0)
                        totalRowCount = long.Parse(table1.Rows[0][0].ToString());
                    else
                        totalRowCount = 0;
                }

                lastRowIndex = lastIndex;
                minIndex = lastRowIndex + 1;
                maxIndex = lastRowIndex + pageSize;

                
                sqlCommand = commandToGetData;
                sqlCommand += " RowNumber Between " + minIndex.ToString() + " and ";
                sqlCommand += maxIndex.ToString();
                sqlCommand += " order by didong ASC";

                

                cachedTable = SQLDatabase.ExcDataTable(sqlCommand);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "GetCachedData");
            }
        }

        #endregion  // Methods
    }

    public class Export
    {
        public static void ExportText(DataTable table1, string FileName,string kytu)
        {


            System.IO.StreamWriter str = new System.IO.StreamWriter(FileName);


            if (table1.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu import", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            foreach (DataRow item in table1.Rows)
            {
                int iz = 0;
                string strLine = "";
                foreach (var item1 in table1.Columns)
                {
                    if (iz != 0)
                        //strLine += ";";
                        strLine += kytu;
                    strLine += item[iz].ToString();
                    iz++;
                }
                str.WriteLine(strLine);
            }
            str.Flush();
            str.Close();
        }

    }
    public class ExcelAdapter
    {
        protected string sFilePath;
        public string SFilePath
        {
            get { if (sFilePath == null) return ""; return sFilePath; }
            set { sFilePath = value; }
        }

        public ExcelAdapter(string filePath)
        {
            this.SFilePath = filePath;
        }

        public bool DeleteFile()
        {
            if (File.Exists(this.SFilePath))
            {
                File.Delete(this.SFilePath);
                return true;
            }
            else
                return false;
        }

        public bool IsExist()
        {
            return File.Exists(this.SFilePath);
        }

        public DataTable ReadFromFile(string commandText)
        {
            string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + this.sFilePath + ";Extended Properties=\"Excel 8.0;HDR=YES;\"";



            DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.OleDb");

            DbDataAdapter adapter = factory.CreateDataAdapter();

            DbCommand selectCommand = factory.CreateCommand();
            selectCommand.CommandText = commandText;

            DbConnection connection = factory.CreateConnection();
            connection.ConnectionString = connectionString;

            selectCommand.Connection = connection;

            adapter.SelectCommand = selectCommand;

            DataSet cities = new DataSet();

            adapter.Fill(cities);

            connection.Close();
            adapter.Dispose();

            return cities.Tables[0];
        }

        protected void FormatDate(COMExcel.Worksheet sheet, int rstart, int cstart, int rend, int cend)
        {
            COMExcel.Range range = (COMExcel.Range)sheet.Range[sheet.Cells[rstart, cstart], sheet.Cells[rend, cend]];
            range.NumberFormat = "DD/MM/YYYY";
        }

        protected void FormatMoney(COMExcel.Worksheet sheet, int rstart, int cstart, int rend, int cend)
        {
            COMExcel.Range range = (COMExcel.Range)sheet.Range[sheet.Cells[rstart, cstart], sheet.Cells[rend, cend]];
            range.NumberFormat = "#,##0";
        }

        protected void Format(COMExcel.Worksheet sheet, int rstart, int cstart, int rend, int cend, string type)
        {
            COMExcel.Range range = (COMExcel.Range)sheet.Range[sheet.Cells[rstart, cstart], sheet.Cells[rend, cend]];
            range.NumberFormat = type;
        }

        public string CreateAndWrite(DataTable dt, string sheetName, int noSheet)
        {
            using (new ExcelUILanguageHelper())
            {
                COMExcel.Application exApp = new COMExcel.Application();
                COMExcel.Workbook exBook = exApp.Workbooks.Add(
                              COMExcel.XlWBATemplate.xlWBATWorksheet);
                try
                {
                    // Không hiển thị chương trình excel
                    exApp.Visible = false;

                    // Lấy sheet 1.
                    COMExcel.Worksheet exSheet = (COMExcel.Worksheet)exBook.Worksheets[noSheet];
                    exSheet.Name = sheetName;

                    //////////////////////
                    int rowCount = dt.Rows.Count;
                    int colCount = dt.Columns.Count;

                    // insert header name             
                    for (int j = 1; j <= colCount; j++)
                    {
                        exSheet.Cells[1, j] = dt.Columns[j - 1].Caption;
                    }

                    // format cho header
                    COMExcel.Range headr = (COMExcel.Range)exSheet.Range[exSheet.Cells[1, 1], exSheet.Cells[1, colCount]];
                    headr.Interior.Color = System.Drawing.Color.Gray.ToArgb();
                    headr.Font.Bold = true;
                    headr.Font.Name = "Arial";
                    headr.Font.Color = System.Drawing.Color.White.ToArgb();
                    headr.Cells.RowHeight = 30;
                    headr.Cells.ColumnWidth = 20;
                    headr.HorizontalAlignment = COMExcel.Constants.xlCenter;


                    //format cho cot ngay, tien, so
                    for (int i = 1; i <= colCount; i++)
                    {
                        if (dt.Columns[i - 1].DataType == Type.GetType("System.DateTime"))
                        {
                            FormatDate(exSheet, 2, i, rowCount + 1, i);
                        }
                        else if (dt.Columns[i - 1].DataType == Type.GetType("System.Decimal"))
                        {
                            Format(exSheet, 2, i, rowCount + 1, i, "##0.0");
                        }
                        else if (dt.Columns[i - 1].DataType == Type.GetType("System.Int64"))
                        {
                            FormatMoney(exSheet, 2, i, rowCount + 1, i);
                        }
                        else if (dt.Columns[i - 1].DataType == Type.GetType("System.Int32"))
                        {
                        }
                        else
                        {
                            Format(exSheet, 2, i, rowCount + 1, i, "@");
                        }
                    }
                    for (int i = 1; i <= rowCount; i++)
                    {
                        for (int j = 1; j <= colCount; j++)
                        {
                            exSheet.Cells[i + 1, j] = dt.Rows[i - 1][j - 1].ToString();
                        }
                    }

                    //format cho toan bo sheet
                    COMExcel.Range Sheet = (COMExcel.Range)exSheet.Range[exSheet.Cells[1, 1], exSheet.Cells[rowCount + 1, colCount]];
                    Sheet.Borders.Color = System.Drawing.Color.Black.ToArgb();
                    Sheet.WrapText = true;

                    // Save file
                    exBook.SaveAs(this.SFilePath, COMExcel.XlFileFormat.xlWorkbookNormal,
                                    null, null, false, false,
                                    COMExcel.XlSaveAsAccessMode.xlExclusive,
                                    false, false, false, false, false);


                    return "Export file excel thành công.\nĐường dẫn là: " + this.sFilePath;
                }
                catch (Exception ex)
                {
                    Thread.CurrentThread.CurrentCulture.DateTimeFormat = new System.Globalization.CultureInfo("en-US").DateTimeFormat;
                    return ex.ToString();
                }
                finally
                {
                    Thread.CurrentThread.CurrentCulture.DateTimeFormat = new System.Globalization.CultureInfo("en-US").DateTimeFormat;
                    // Đóng chương trình
                    exBook.Close(false, false, false);
                    exApp.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(exBook);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(exApp);
                }
            }
        }

        public string CreateAndWrite(DataTable[] dtList, string[] sheetNames)
        {
            using (new ExcelUILanguageHelper())
            {
                COMExcel.Application exApp = new COMExcel.Application();
                COMExcel.Workbook exBook = exApp.Workbooks.Add(
                              COMExcel.XlWBATemplate.xlWBATWorksheet);
                try
                {
                    // Không hiển thị chương trình excel
                    exApp.Visible = false;

                    //List<COMExcel.Worksheet> exSheetList = new List<Microsoft.Office.Interop.Excel.Worksheet>();
                    for (int i = 1; i < dtList.Length; i++)
                    {
                        //exSheetList.Add((COMExcel.Worksheet)exBook.Worksheets[i]);
                        exBook.Worksheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    }
                    int noSheet = 1;
                    foreach (DataTable dt in dtList)
                    {
                        COMExcel.Worksheet exSheet = (COMExcel.Worksheet)exBook.Worksheets[noSheet];
                        exSheet.Name = sheetNames[noSheet - 1];

                        //////////////////////
                        int rowCount = dt.Rows.Count;
                        int colCount = dt.Columns.Count;

                        // insert header name             
                        for (int j = 1; j <= colCount; j++)
                        {
                            exSheet.Cells[1, j] = dt.Columns[j - 1].Caption;
                        }

                        // format cho header
                        COMExcel.Range headr = (COMExcel.Range)exSheet.Range[exSheet.Cells[1, 1], exSheet.Cells[1, colCount]];
                        headr.Interior.Color = System.Drawing.Color.Gray.ToArgb();
                        headr.Font.Bold = true;
                        headr.Font.Name = "Arial";
                        headr.Font.Color = System.Drawing.Color.White.ToArgb();
                        headr.Cells.RowHeight = 30;
                        headr.Cells.ColumnWidth = 20;
                        headr.HorizontalAlignment = COMExcel.Constants.xlCenter;


                        //format cho cot ngay, tien, so
                        for (int i = 1; i <= colCount; i++)
                        {
                            if (dt.Columns[i - 1].DataType == Type.GetType("System.DateTime"))
                            {
                                FormatDate(exSheet, 2, i, rowCount + 1, i);
                            }
                            else if (dt.Columns[i - 1].DataType == Type.GetType("System.Decimal"))
                            {
                                Format(exSheet, 2, i, rowCount + 1, i, "##0.0");
                            }
                            else if (dt.Columns[i - 1].DataType == Type.GetType("System.Int64"))
                            {
                                FormatMoney(exSheet, 2, i, rowCount + 1, i);
                            }
                            else if (dt.Columns[i - 1].DataType == Type.GetType("System.Int32"))
                            {
                            }
                            else
                            {
                                Format(exSheet, 2, i, rowCount + 1, i, "@");
                            }
                        }

                        for (int i = 1; i <= rowCount; i++)
                        {
                            for (int j = 1; j <= colCount; j++)
                            {
                                exSheet.Cells[i + 1, j] = dt.Rows[i - 1][j - 1].ToString();
                            }
                        }

                        //format cho toan bo sheet
                        COMExcel.Range Sheet = (COMExcel.Range)exSheet.Range[exSheet.Cells[1, 1], exSheet.Cells[rowCount + 1, colCount]];
                        Sheet.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        Sheet.WrapText = true;

                        noSheet++;
                    }
                    // Save file
                    exBook.SaveAs(this.SFilePath, COMExcel.XlFileFormat.xlWorkbookNormal,
                                    null, null, false, false,
                                    COMExcel.XlSaveAsAccessMode.xlExclusive,
                                    false, false, false, false, false);


                    return "Export file excel thành công.\nĐường dẫn là: " + this.sFilePath;
                }
                catch (Exception ex)
                {
                    Thread.CurrentThread.CurrentCulture.DateTimeFormat = new System.Globalization.CultureInfo("en-US").DateTimeFormat;
                    return ex.ToString();
                }
                finally
                {
                    Thread.CurrentThread.CurrentCulture.DateTimeFormat = new System.Globalization.CultureInfo("en-US").DateTimeFormat;
                    // Đóng chương trình
                    exBook.Close(false, false, false);
                    exApp.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(exBook);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(exApp);
                }
            }
        }

        public class ExcelUILanguageHelper : IDisposable
        {
            private System.Globalization.CultureInfo m_CurrentCulture;

            public ExcelUILanguageHelper()
            {
                // save current culture and set culture to en-US            
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                m_CurrentCulture = Thread.CurrentThread.CurrentCulture;
                m_CurrentCulture.DateTimeFormat.ShortDatePattern = "MM/dd/yyyy";
            }

            #region IDisposable Members

            public void Dispose()
            {
                // return to normal culture
                Thread.CurrentThread.CurrentCulture = m_CurrentCulture;
            }

            #endregion
        } 

    }

    public class Utilities_Import
    {
        public static bool hasProcess = true; /*khai bao bien stop*/
        private string connectionString, tableName, colTelNumber;
        private List<string> columnNamesList;
        private Dictionary<string, string> dict;
        private int nTongrowsText = 0;



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

        public int TongrowsText
        {
            get { return nTongrowsText; }
            set { nTongrowsText = value; }
        }

        public string TableName
        {
            set { tableName = value; }
        }

        public string ColTelNumber
        {
            set { colTelNumber = value; }
        }
        #endregion // Properties

        public void ProcessImport(object arrControl)
        {

            OleDbDataReader reader = null;
            object totalRow;

            try
            {
                //----- Add control process from
                ArrayList arr1 = (ArrayList)arrControl;
                Label lblPhanTram = (Label)arr1[0];
                NeroBar progressBar11 = (NeroBar)arr1[1];
                Label lblmessage = (Label)arr1[2];

                //----- update display control
                lblPhanTram.Update();
                lblmessage.Update();
                totalRow = TongrowsText;
                if (totalRow == null)
                    return;
                //----- Get Data from Source

                string[] columnNames = new string[columnNamesList.Count()];

                for (int i = 0; i < columnNames.Count(); i++)
                {
                    columnNames[i] = columnNamesList[i];
                }

                /***********text*****************/
                /*
                OleDbConnection con = new OleDbConnection(connectionString);
                con.Open();

                OleDbDataAdapter dap = new OleDbDataAdapter("select * from [096test.txt]", con);

                DataTable dt = new DataTable();
                dt.TableName = "Data";
                dap.Fill(dt);
                */

                reader = SQLDatabase.ExcOleReaderDataSource(connectionString, tableName, columnNames);

                progressBar11.MaxValue = int.Parse(totalRow.ToString());
                progressBar11.MinValue = 0;
                progressBar11.Update();
                // Set up the bulk copy object.
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(SQLDatabase.ConnectionString))
                {
                    //http://csharp-video-tutorials.blogspot.com/2014/09/part-20-sqlbulkcopy-notifyafter-example_27.html
                    bulkCopy.NotifyAfter = 5000;
                    bulkCopy.BatchSize = 10000;
                    bulkCopy.SqlRowsCopied += (sender, e) =>
                    {
                        progressBar11.Value = e.RowsCopied;
                        progressBar11.Update();
                        lblmessage.Text = string.Format("Insert số liệu vào database. ->{0}/{1}", e.RowsCopied.ToString("N0"), ConvertType.ToInt(totalRow).ToString("N0"));
                        Thread.Sleep(0);
                    };
                    bulkCopy.DestinationTableName = "dbo.dienthoai_new";
                    
                    if (dict.FirstOrDefault(x => x.Key == "cbb_TelNumber").Value != "")
                    {
                        SqlBulkCopyColumnMapping cbb_TelNumber = new SqlBulkCopyColumnMapping(dict.FirstOrDefault(x => x.Key == "cbb_TelNumber").Value, "didong");
                        bulkCopy.ColumnMappings.Add(cbb_TelNumber);
                    }

                    if (dict.FirstOrDefault(x => x.Key == "cbb_ten_khach_hang").Value != "")
                    {
                        SqlBulkCopyColumnMapping cbb_ten_khach_hang = new SqlBulkCopyColumnMapping(dict.FirstOrDefault(x => x.Key == "cbb_ten_khach_hang").Value, "ten_khach_hang");
                        bulkCopy.ColumnMappings.Add(cbb_ten_khach_hang);
                    }

                    if (dict.FirstOrDefault(x => x.Key == "cbb_dia_chi").Value != "")
                    {
                        SqlBulkCopyColumnMapping cbb_dia_chi = new SqlBulkCopyColumnMapping(dict.FirstOrDefault(x => x.Key == "cbb_dia_chi").Value, "dia_chi");
                        bulkCopy.ColumnMappings.Add(cbb_dia_chi);
                    }
                    
                    if (dict.FirstOrDefault(x => x.Key == "cbb_Ngay").Value != "")
                    {
                        SqlBulkCopyColumnMapping cbb_Ngay = new SqlBulkCopyColumnMapping(dict.FirstOrDefault(x => x.Key == "cbb_Ngay").Value, "ngay");
                        bulkCopy.ColumnMappings.Add(cbb_Ngay);
                    }
                    if (dict.FirstOrDefault(x => x.Key == "cbb_Thang").Value != "")
                    {
                        SqlBulkCopyColumnMapping cbb_Thang = new SqlBulkCopyColumnMapping(dict.FirstOrDefault(x => x.Key == "cbb_Thang").Value, "thang");
                        bulkCopy.ColumnMappings.Add(cbb_Thang);
                    }
                    if (dict.FirstOrDefault(x => x.Key == "cbb_namsinh").Value != "")
                    {
                        SqlBulkCopyColumnMapping cbb_namsinh = new SqlBulkCopyColumnMapping(dict.FirstOrDefault(x => x.Key == "cbb_namsinh").Value, "namsinh");
                        bulkCopy.ColumnMappings.Add(cbb_namsinh);
                    }
                    if (dict.FirstOrDefault(x => x.Key == "cbb_nganhang").Value != "")
                    {
                        SqlBulkCopyColumnMapping cbb_nganhang = new SqlBulkCopyColumnMapping(dict.FirstOrDefault(x => x.Key == "cbb_nganhang").Value, "ngan_hang");
                        bulkCopy.ColumnMappings.Add(cbb_nganhang);
                    }
                   
                    if (dict.FirstOrDefault(x => x.Key == "cbb_cuoc").Value != "")
                    {
                        SqlBulkCopyColumnMapping cbb_cuoc = new SqlBulkCopyColumnMapping(dict.FirstOrDefault(x => x.Key == "cbb_cuoc").Value, "cuoc");
                        bulkCopy.ColumnMappings.Add(cbb_cuoc);
                    }

                    if (dict.FirstOrDefault(x => x.Key == "cbb_sim").Value != "")
                    {
                        SqlBulkCopyColumnMapping cbb_sim = new SqlBulkCopyColumnMapping(dict.FirstOrDefault(x => x.Key == "cbb_sim").Value, "sim");
                        bulkCopy.ColumnMappings.Add(cbb_sim);
                    }

                    if (dict.FirstOrDefault(x => x.Key == "cbb_tinh").Value != "")
                    {
                        SqlBulkCopyColumnMapping cbb_tinh = new SqlBulkCopyColumnMapping(dict.FirstOrDefault(x => x.Key == "cbb_tinh").Value, "tinh");
                        bulkCopy.ColumnMappings.Add(cbb_tinh);
                    }

                    if (dict.FirstOrDefault(x => x.Key == "cbb_ghichu").Value != "")
                    {
                        SqlBulkCopyColumnMapping cbb_ghichu = new SqlBulkCopyColumnMapping(dict.FirstOrDefault(x => x.Key == "cbb_ghichu").Value, "ghi_chu");
                        bulkCopy.ColumnMappings.Add(cbb_ghichu);
                    }

                    if (dict.FirstOrDefault(x => x.Key == "cbb_gioitinh").Value != "")
                    {
                        SqlBulkCopyColumnMapping cbb_gioitinh = new SqlBulkCopyColumnMapping(dict.FirstOrDefault(x => x.Key == "cbb_gioitinh").Value, "gioi_tinh");
                        bulkCopy.ColumnMappings.Add(cbb_gioitinh);
                    }
                    
                    if (dict.FirstOrDefault(x => x.Key == "cbb_tinhcuoc").Value != "")
                    {
                        SqlBulkCopyColumnMapping cbb_tinhcuoc = new SqlBulkCopyColumnMapping(dict.FirstOrDefault(x => x.Key == "cbb_tinhcuoc").Value, "tinh_cuoc");
                        bulkCopy.ColumnMappings.Add(cbb_tinhcuoc);
                    }
                    if (dict.FirstOrDefault(x => x.Key == "cbb_phuong").Value != "")
                    {
                        SqlBulkCopyColumnMapping cbb_Phuong = new SqlBulkCopyColumnMapping(dict.FirstOrDefault(x => x.Key == "cbb_phuong").Value, "phuong");
                        bulkCopy.ColumnMappings.Add(cbb_Phuong);

                    }

                    if (dict.FirstOrDefault(x => x.Key == "cbb_quanhuyen").Value != "")
                    {
                        SqlBulkCopyColumnMapping cbb_quanhuyen = new SqlBulkCopyColumnMapping(dict.FirstOrDefault(x => x.Key == "cbb_quanhuyen").Value, "quan_huyen");
                        bulkCopy.ColumnMappings.Add(cbb_quanhuyen);
                    }

                    if (dict.FirstOrDefault(x => x.Key == "cbb_email").Value != "")
                    {
                        SqlBulkCopyColumnMapping cbb_email = new SqlBulkCopyColumnMapping(dict.FirstOrDefault(x => x.Key == "cbb_email").Value, "email");
                        bulkCopy.ColumnMappings.Add(cbb_email);
                    }

                    if (dict.FirstOrDefault(x => x.Key == "cbb_ngay_kich_hoat").Value != "")
                    {
                        SqlBulkCopyColumnMapping cbb_ngay_kich_hoat = new SqlBulkCopyColumnMapping(dict.FirstOrDefault(x => x.Key == "cbb_ngay_kich_hoat").Value, "ngay_kich_hoat");
                        bulkCopy.ColumnMappings.Add(cbb_ngay_kich_hoat);
                    }
                    if (dict.FirstOrDefault(x => x.Key == "cbb_goiCuoc").Value != "")
                    {
                        SqlBulkCopyColumnMapping cbb_GoiCuoc = new SqlBulkCopyColumnMapping(dict.FirstOrDefault(x => x.Key == "cbb_goiCuoc").Value, "goi_cuoc");
                        bulkCopy.ColumnMappings.Add(cbb_GoiCuoc);
                    }
                    if (dict.FirstOrDefault(x => x.Key == "cbb_dongmay").Value != "")
                    {
                        SqlBulkCopyColumnMapping cbb_dongmay = new SqlBulkCopyColumnMapping(dict.FirstOrDefault(x => x.Key == "cbb_dongmay").Value, "dong_may");
                        bulkCopy.ColumnMappings.Add(cbb_dongmay);
                    }

                    if (dict.FirstOrDefault(x => x.Key == "cbb_hedieuhanh").Value != "")
                    {
                        SqlBulkCopyColumnMapping cbb_HeDieuhanh = new SqlBulkCopyColumnMapping(dict.FirstOrDefault(x => x.Key == "cbb_hedieuhanh").Value, "he_dieu_hanh");
                        bulkCopy.ColumnMappings.Add(cbb_HeDieuhanh);
                    }
                    if (dict.FirstOrDefault(x => x.Key == "cbb_chucvu").Value != "")
                    {
                        SqlBulkCopyColumnMapping cbb_chucvu = new SqlBulkCopyColumnMapping(dict.FirstOrDefault(x => x.Key == "cbb_chucvu").Value, "chuc_vu");
                        bulkCopy.ColumnMappings.Add(cbb_chucvu);
                    }
                    if (dict.FirstOrDefault(x => x.Key == "cbb_congty").Value != "")
                    {
                        SqlBulkCopyColumnMapping cbb_congty = new SqlBulkCopyColumnMapping(dict.FirstOrDefault(x => x.Key == "cbb_congty").Value, "cong_ty");
                        bulkCopy.ColumnMappings.Add(cbb_congty);
                    }
                    try
                    {
                        bulkCopy.WriteToServer(reader);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        progressBar11.Value = 100;
                        progressBar11.Update();
                        lblmessage.Text = string.Format("Hoàn thành import {0}", int.Parse(totalRow.ToString()));
                        Thread.Sleep(0);

                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ProcessImport");
            }
        }

        /// <summary>
        /// Create a schema.ini file to control the format and data types used 
        /// within the applications - this must be saved in the path of the input file.
        /// It will overwrite any existing schema.ini file there but the whole process
        /// is transparent to the end user.  The specification of the actual input file
        /// received from Intuit/Medfusion must match here exactly.
        /// 
        /// If you wish to conceal any information from the end user just hide the column 
        /// in LoadFileData()
        /// </summary>
        /// <param name="filePath"></param>
        public void CreateSchemaIni(string filePath)
        {
            try
            {
                // define a new schema definition and populate it from the 
                // application properties
                SchemaSpec.SchemeDef sdef = new SchemaSpec.SchemeDef();
                if (Properties.Settings.Default.SchemaSpec == null)
                {
                    MessageBox.Show("No schema has been defined; prior to opening a CSV file, use the Schema tool to construct a schema definition", "Missing Schema");
                    return;
                }
                else
                {
                    sdef = Properties.Settings.Default.SchemaSpec;
                }

                // start a string builder to hold the contents of the schema file as it is construction
                StringBuilder sb = new StringBuilder();

                // the first line of the schema file is the file name in brackets
                sb.Append("[" + System.IO.Path.GetFileName(filePath) + "]" + Environment.NewLine);

                // the next line of the schema file will be used to determine whether or not
                // the first line of the file contains column headers or not
                string colHeader = sdef.UsesHeader == SchemaSpec.SchemeDef.FirstRowHeader.No ? "ColNameHeader=False" : "ColNameHeader=True";
                sb.Append(colHeader + Environment.NewLine);

                //  next we need to add the format to the schema file
                switch (sdef.DelimiterType)
                {
                    case SchemaSpec.SchemeDef.DelimType.CsvDelimited:
                        // a comma delimited file
                        sb.Append("Format=CsvDelimited" + Environment.NewLine);
                        break;
                    case SchemaSpec.SchemeDef.DelimType.CustomDelimited:
                        // a custom delimiter is used here; need to check and make sure the user
                        // provided a character to serve as a delimiter
                        if (String.IsNullOrEmpty(sdef.CustomDelimiter))
                        {
                            MessageBox.Show("A custom delimiter was not identified for this schema.", "Invalid Schema");
                            return;
                        }
                        sb.Append("Format=Delimited(" + sdef.CustomDelimiter + ")" + Environment.NewLine);
                        break;
                    case SchemaSpec.SchemeDef.DelimType.FixedWidth:
                        // the file columns here have a fixed width; no other delimiter is supplied
                        sb.Append("Format=FixedLength" + Environment.NewLine);
                        break;
                    case SchemaSpec.SchemeDef.DelimType.TabDelimited:
                        // the columns here are tab delimited
                        sb.Append("Format=TabDelimited" + Environment.NewLine);
                        break;
                    default:
                        break;
                }

                // next each column number, name and data type is added to the schema file
                foreach (SchemaSpec.ItemSpecification s in sdef.ColumnDefinition)
                {
                    string tmp = "Col" + s.ColumnNumber.ToString() + "=" + s.Name + " " + s.TypeData;

                    if (s.ColumnWidth > 0)
                        tmp += " Width " + s.ColumnWidth.ToString();

                    sb.Append(tmp + Environment.NewLine);
                }

                // the schema.ini file has to live in the same folder as the file we are going to open; it has to carry the name
                // schema.ini.  When we connect to the file, the connection will find and use this schema.ini file to 
                // determine how to treat the file contents; only the correct schema.ini file for a particular file type can 
                // be used - you cannot, for example, open a comma delimited file with a schema.ini file defined for a 
                // pipe delimited file.
                using (StreamWriter outfile = new StreamWriter(System.IO.Path.GetDirectoryName(filePath) + @"\schema.ini"))
                {
                    outfile.Write(sb.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

    }
}
