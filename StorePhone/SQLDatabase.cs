using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StorePhone
{
    public class thongbaokiemtra {
        public bool trangthai;
        public string NoiDung;
    }
    public class regexs
    {
        public int id { get; set; }
        public string RegexName { get; set; }
        public string Regex { get; set; }
        public string Type { get; set; }
        public string Example { get; set; }
        public int OrderId { get; set; }
    }
    public class dienthoai_new
    {
        #region Fields

        public int id;
        public string ten_khach_hang;
        public string phuong;
        public string quan_huyen;
        public string didong;
        public string dia_chi;
        public string namsinh;
        public string email;
        public string ngay;
        public string thang;
        public string cuoc;
        public string tinh_cuoc;
        public string ngay_kich_hoat;
        public string goi_cuoc;
        public string dong_may;
        public string he_dieu_hanh;
        public string chuc_vu;
        public string cong_ty;
        public string gioi_tinhold;
        public string gioi_tinh;
        public string ngan_hang;
        public string sim;
        public string tinh;
        public string ghi_chu;
        public string filenguon;

        #endregion

        public dienthoai_new()
        {
            ten_khach_hang = "";
            didong = "";
            tinh = "";
            tinh_cuoc = "";
            ghi_chu = "";
            gioi_tinhold = "";
            gioi_tinh = "";
            ngan_hang = "";
            sim = "";
            namsinh = "";
            ngay = "";
            thang = "";
            dia_chi = "";
            id = 0;
            cuoc = "";
            filenguon = "";
            ngay_kich_hoat = "";
            goi_cuoc = "";
            dong_may = "";
            he_dieu_hanh = "";
            chuc_vu = "";
            cong_ty = "";
            phuong = "";
            quan_huyen = "";
            email = "";
        }

    }


    class SQLDatabase
    {

        #region Fields

        //public static string ConnectionString;
        //public static string ConnectionString = "Data Source=(local);Initial Catalog=AppSearch;Integrated Security=True";
        //public static string ConnectionString = "Data Source=123.30.127.133;Initial Catalog=AppSearch;User ID=sa;Password=cntt@123456";
        public static string ConnectionString = System.Configuration.ConfigurationSettings.AppSettings.Get("ConnectionString");

        #endregion // Fields 


        public static bool AddDienThoaiNEW(dienthoai_new record)
        {
            SqlConnection cnn = null;
            SqlCommand cmd = null;

            object objectID;
            try
            {
                if (record == null)
                    return false;

                cnn = new SqlConnection();
                cnn.ConnectionString = ConnectionString;
                cnn.FireInfoMessageEventOnUserErrors = false;
                cnn.Open();

                cmd = new SqlCommand();
                cmd.Connection = cnn;
                //--- Insert Record
                cmd.CommandText = "Insert into dienthoai_new(ten_khach_hang,phuong,quan_huyen, didong, dia_chi, namsinh,email, ngay,thang,cuoc, gioi_tinh, ngan_hang, sim, tinh, ghi_chu,  filenguon,tinh_cuoc,ngay_kich_hoat,goi_cuoc,dong_may,he_dieu_hanh,chuc_vu,cong_ty)" +
                                    "values(@ten_khach_hang,@phuong,@quan_huyen, @didong, @dia_chi, @namsinh,@email, @ngay,@thang,@cuoc, @gioi_tinh, @ngan_hang, @sim, @tinh, @ghi_chu,  @filenguon,@tinh_cuoc,@ngay_kich_hoat,@goi_cuoc,@dong_may,@he_dieu_hanh,@chuc_vu,@cong_ty);" +
                                    "Select SCOPE_IDENTITY();";

                cmd.Parameters.AddWithValue("@ten_khach_hang", record.ten_khach_hang);
                cmd.Parameters.AddWithValue("@didong", record.didong);
                cmd.Parameters.AddWithValue("@dia_chi", record.dia_chi);
                cmd.Parameters.AddWithValue("@phuong", record.phuong);
                cmd.Parameters.AddWithValue("@quan_huyen", record.quan_huyen);
                cmd.Parameters.AddWithValue("@email", record.email);
                cmd.Parameters.AddWithValue("@namsinh",record.namsinh);
                cmd.Parameters.AddWithValue("@ngay", record.ngay);
                cmd.Parameters.AddWithValue("@thang", record.thang);
                cmd.Parameters.AddWithValue("@cuoc", record.cuoc);
                cmd.Parameters.AddWithValue("@ngan_hang", record.ngan_hang);
                cmd.Parameters.AddWithValue("@sim", record.sim);
                cmd.Parameters.AddWithValue("@tinh", record.tinh);
                cmd.Parameters.AddWithValue("@tinh_cuoc", record.tinh_cuoc);
                cmd.Parameters.AddWithValue("@ghi_chu", record.ghi_chu);
                cmd.Parameters.AddWithValue("@filenguon", record.filenguon);
                cmd.Parameters.AddWithValue("@gioi_tinh", record.gioi_tinh);
                cmd.Parameters.AddWithValue("@ngay_kich_hoat", record.ngay_kich_hoat);
                cmd.Parameters.AddWithValue("@goi_cuoc", record.goi_cuoc);
                cmd.Parameters.AddWithValue("@dong_may", record.dong_may);
                cmd.Parameters.AddWithValue("@he_dieu_hanh", record.he_dieu_hanh);
                cmd.Parameters.AddWithValue("@chuc_vu", record.chuc_vu);
                cmd.Parameters.AddWithValue("@cong_ty", record.cong_ty);
                

                objectID = cmd.ExecuteScalar();

                if (objectID == null || objectID == DBNull.Value) return false;

                record.id = Convert.ToInt32(objectID);

                return true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                    cnn.Close();
            }
        }


        public static bool UpdateDienThoaiNEW(dienthoai_new record)
        {
            SqlConnection connection = null;
            SqlCommand cmd = null;

            try
            {
                if (record == null) return false;

                // Make connection to database
                connection = new SqlConnection();
                connection.ConnectionString = ConnectionString;
                connection.FireInfoMessageEventOnUserErrors = false;
                connection.Open();
                // Create command to update GeneralGuessGroup record
                cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "Update dienthoai_goc Set ten_khach_hang=@ten_khach_hang, "
                                    + "dia_chi=@dia_chi,namsinh=@namsinh,ngay=@ngay,thang=@thang,cuoc=@cuoc, "
                                      + "ngan_hang=@ngan_hang, sim=@sim,tinh_cuoc=@tinh_cuoc ,tinh=@tinh,phuong=@phuong,quan_huyen=@quan_huyen,email=@email,ngay_kich_hoat=@ngay_kich_hoat,goi_cuoc=@goi_cuoc,dong_may=@dong_may,he_dieu_hanh=@he_dieu_hanh,chuc_vu=@chuc_vu,cong_ty=@cong_ty"
                                      + " where ID='" + record.id + "'";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@ten_khach_hang", record.ten_khach_hang);
                cmd.Parameters.AddWithValue("@didong", record.didong);
                cmd.Parameters.AddWithValue("@dia_chi", record.dia_chi);
                cmd.Parameters.AddWithValue("@phuong", record.phuong);
                cmd.Parameters.AddWithValue("@quan_huyen", record.quan_huyen);
                cmd.Parameters.AddWithValue("@email", record.email);
                cmd.Parameters.AddWithValue("@namsinh", record.namsinh);
                cmd.Parameters.AddWithValue("@ngay", record.ngay);
                cmd.Parameters.AddWithValue("@thang", record.thang);
                cmd.Parameters.AddWithValue("@cuoc", record.cuoc);
                cmd.Parameters.AddWithValue("@ngan_hang", record.ngan_hang);
                cmd.Parameters.AddWithValue("@sim", record.sim);
                cmd.Parameters.AddWithValue("@tinh", record.tinh);
                cmd.Parameters.AddWithValue("@tinh_cuoc", record.tinh_cuoc);
                cmd.Parameters.AddWithValue("@ghi_chu", record.ghi_chu);
                cmd.Parameters.AddWithValue("@filenguon", record.filenguon);
                cmd.Parameters.AddWithValue("@gioi_tinh", record.gioi_tinh);
                cmd.Parameters.AddWithValue("@ngay_kich_hoat", record.ngay_kich_hoat);
                cmd.Parameters.AddWithValue("@goi_cuoc", record.goi_cuoc);
                cmd.Parameters.AddWithValue("@dong_may", record.dong_may);
                cmd.Parameters.AddWithValue("@he_dieu_hanh", record.he_dieu_hanh);
                cmd.Parameters.AddWithValue("@chuc_vu", record.chuc_vu);
                cmd.Parameters.AddWithValue("@cong_ty", record.cong_ty);


                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "UpdateDienThoaiNEW");
                return false;
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }


        #region Execute SQL

        public static bool ExcNonQuery(string sqlcommand)
        {
            SqlConnection connection = null;
            SqlCommand command = null;

            try
            {
                connection = new SqlConnection();
                connection.ConnectionString = ConnectionString;
                connection.Open();
                command = new SqlCommand(sqlcommand, connection);
                command.CommandTimeout = 36000;
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ExcNonQuery");
                return false;
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

        public static object ExcScalar(string sqlcommand)
        {
            SqlConnection connection = null;
            SqlCommand command = null;
            object result = null;

            try
            {
                connection = new SqlConnection();
                connection.ConnectionString = ConnectionString;
                connection.Open();
                command = new SqlCommand(sqlcommand, connection);
                command.CommandTimeout = 36000;
                result = command.ExecuteScalar();
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ExcScalar");
                return null;
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

        public static DataTable ExcDataTable(string sqlcommand)
        {
            SqlConnection connection = null;
            SqlCommand command = null;
            SqlDataAdapter adp = null;
            DataTable table = null;

            try
            {
                connection = new SqlConnection();
                connection.ConnectionString = ConnectionString;
                connection.Open();
                command = new SqlCommand(sqlcommand, connection);
                command.CommandTimeout = 36000;
                table = new DataTable();
                adp = new SqlDataAdapter(command);
                adp.Fill(table);
                return table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ExcDataTable");
                return null;
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

        public static bool CheckExist(string sqlcommand)
        {
            SqlConnection connection = null;
            SqlCommand command = null;
            SqlDataReader reader = null;

            try
            {
                connection = new SqlConnection();
                connection.ConnectionString = ConnectionString;
                connection.FireInfoMessageEventOnUserErrors = false;
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = sqlcommand;
                command.CommandType = CommandType.Text;
                reader = command.ExecuteReader();
                if (reader.Read())
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "CheckExist");
                return false;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        #endregion  // Execute SQL



        #region Execute OleDB

        public static DataTable ExcOleDbSchemaTable(string connectionString)
        {
            OleDbConnection oleConnect = null;
            DataTable table = null;

            try
            {
                oleConnect = new OleDbConnection();
                oleConnect.ConnectionString = connectionString;
                oleConnect.Open();
                table = oleConnect.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                return table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ExcOleDbSchemaTable");
                return null;
            }

        }

        public static DataTable ExcOleDbSchemaColumn(string connectionString, string tableName)
        {
            OleDbConnection oleConnect = null;
            DataTable table = null;

            try
            {
                oleConnect = new OleDbConnection();
                oleConnect.ConnectionString = connectionString;
                oleConnect.Open();
                table = oleConnect.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, new object[] { null, null, tableName, null });
                return table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ExcOleDbSchemaColumn");
                return null;
            }
        }

        public static OleDbDataReader ExcOleReaderDataSource(string connectionString, string tableName, string[] columnNames)
        {
            OleDbConnection oleConnect = null;
            OleDbCommand oleCommand = null;
            OleDbDataReader oleReader = null;
            string sqlcommand = "Select ";
            string[] getType;

            try
            {
                getType = connectionString.ToString().Split('.');
                //----- Get string command
                switch (getType[getType.Length - 1])
                {
                    case "mdb":
                    case "MDB":
                        for (int i = 0; i < columnNames.Length; i++)
                        {
                            if (i == columnNames.Length - 1)
                                sqlcommand += "[" + columnNames[i] + "] ";
                            else
                                sqlcommand += "[" + columnNames[i] + "],";
                        }
                        sqlcommand += "FROM [" + tableName + "]";
                        break;
                    case "dbf":
                    case "DBF":
                        for (int i = 0; i < columnNames.Length; i++)
                        {
                            if (i == columnNames.Length - 1)
                                sqlcommand += columnNames[i] + " ";
                            else
                                sqlcommand += columnNames[i] + ",";
                        }
                        sqlcommand += "FROM [" + tableName + "] Order by " + columnNames[0];
                        break;
                    default:
                        for (int i = 0; i < columnNames.Length; i++)
                        {
                            if (i == columnNames.Length - 1)
                                sqlcommand += "[" + columnNames[i] + "] ";
                            else
                                sqlcommand += "[" + columnNames[i] + "],";
                        }
                        sqlcommand += "FROM [" + tableName + "]";
                        break;
                }

                oleConnect = new OleDbConnection(connectionString);
                oleConnect.Open();
                oleCommand = new OleDbCommand(sqlcommand, oleConnect);
                oleReader = oleCommand.ExecuteReader();
                return oleReader;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ExcOleReaderDataSource");
                return null;
            }
        }

        public static OleDbDataReader ExcOleReaderDataSource(string connectionString, string tableName, string[] columnNames, string stringWhere)
        {
            OleDbConnection oleConnect = null;
            OleDbCommand oleCommand = null;
            OleDbDataReader oleReader = null;
            string sqlcommand = "Select ";
            string[] getType;

            try
            {
                getType = connectionString.ToString().Split('.');
                //----- Get string command
                switch (getType[getType.Length - 1])
                {
                    case "mdb":
                    case "MDB":
                        for (int i = 0; i < columnNames.Length; i++)
                        {
                            if (i == columnNames.Length - 1)
                                sqlcommand += "[" + columnNames[i] + "] ";
                            else
                                sqlcommand += "[" + columnNames[i] + "],";
                        }
                        sqlcommand += "FROM [" + tableName + "] Where " + stringWhere;
                        break;
                    case "dbf":
                    case "DBF":
                        for (int i = 0; i < columnNames.Length; i++)
                        {
                            if (i == columnNames.Length - 1)
                                sqlcommand += columnNames[i] + " ";
                            else
                                sqlcommand += columnNames[i] + ",";
                        }
                        sqlcommand += "FROM [" + tableName + "] Where " + stringWhere + " Order by " + columnNames[0];
                        break;
                    default:
                        for (int i = 0; i < columnNames.Length; i++)
                        {
                            if (i == columnNames.Length - 1)
                                sqlcommand += "[" + columnNames[i] + "] ";
                            else
                                sqlcommand += "[" + columnNames[i] + "],";
                        }
                        sqlcommand += "FROM [" + tableName + "$] Where " + stringWhere;
                        break;
                }

                oleConnect = new OleDbConnection(connectionString);
                oleConnect.Open();
                oleCommand = new OleDbCommand(sqlcommand, oleConnect);
                oleReader = oleCommand.ExecuteReader();
                return oleReader;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ExcOleReaderDataSource");
                return null;
            }
        }

        public static OleDbDataReader ExcOleReaderDataSource(string connectionString, string tableName, string[] columnNames, int topRow)
        {
            OleDbConnection oleConnect = null;
            OleDbCommand oleCommand = null;
            OleDbDataReader oleReader = null;
            string sqlcommand = "Select ";
            string[] getType;

            try
            {
                getType = connectionString.ToString().Split('.');
                sqlcommand += "Top " + topRow + " ";
                //----- Get string command
                switch (getType[getType.Length - 1])
                {
                    case "mdb":
                    case "MDB":
                        for (int i = 0; i < columnNames.Length; i++)
                        {
                            if (i == columnNames.Length - 1)
                                sqlcommand += "[" + columnNames[i] + "] ";
                            else
                                sqlcommand += "[" + columnNames[i] + "],";
                        }
                        sqlcommand += "FROM [" + tableName + "]";
                        break;
                    case "dbf":
                    case "DBF":
                        for (int i = 0; i < columnNames.Length; i++)
                        {
                            if (i == columnNames.Length - 1)
                                sqlcommand += columnNames[i] + " ";
                            else
                                sqlcommand += columnNames[i] + ",";
                        }
                        sqlcommand += "FROM [" + tableName + "] Order by " + columnNames[0] + " desc";
                        break;
                    default:
                        for (int i = 0; i < columnNames.Length; i++)
                        {
                            if (i == columnNames.Length - 1)
                                sqlcommand += "[" + columnNames[i] + "] ";
                            else
                                sqlcommand += "[" + columnNames[i] + "],";
                        }
                        sqlcommand += "FROM [" + tableName + "$]";
                        break;
                }

                oleConnect = new OleDbConnection(connectionString);
                oleConnect.Open();
                oleCommand = new OleDbCommand(sqlcommand, oleConnect);
                oleReader = oleCommand.ExecuteReader();
                return oleReader;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ExcOleReaderDataSource");
                return null;
            }
        }

        public static object ExcOleScalar(string connectionString, string sqlcommand)
        {
            OleDbConnection oleConnect = null;
            OleDbCommand oleCommand = null;
            object result;

            try
            {
                oleConnect = new OleDbConnection(connectionString);
                oleConnect.Open();
                oleCommand = new OleDbCommand(sqlcommand, oleConnect);
                result = oleCommand.ExecuteScalar();
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ExcOleScalar");
                return null;
            }
        }

        #endregion  // Execute OleDB        
    }
}
