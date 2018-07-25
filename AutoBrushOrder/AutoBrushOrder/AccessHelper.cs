using System;
using System.Data;
using System.Configuration;
using System.Web;
//using System.Web.Security;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.Web.UI.WebControls.WebParts;
//using System.Web.UI.HtmlControls;
using System.Data.OleDb;
using System.Windows.Forms;


/// <summary>
/// AccessHelper 的摘要说明
/// </summary>
public class AccessHelper
{
    protected static OleDbConnection conn = new OleDbConnection();
    protected static OleDbCommand comm = new OleDbCommand();

    public AccessHelper()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    /// <summary>
    /// 打开数据库
    /// </summary>
    private static void openConnection()
    {
        if (conn.State == ConnectionState.Closed)
        {
            //conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["myconn"].ToString() + ";Jet OLEDB:Database PassWord=sa";
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\config\\ciku.accdb;Provider=Microsoft.ACE.OLEDB.12.0" + ";Jet OLEDB:Database PassWord=sa";

            comm.Connection = conn;
            try
            {
                conn.Open();
            }
            catch (Exception e)
            { throw new Exception(e.Message); }

        }

    }
    /// <summary>
    /// 关闭数据库
    /// </summary>
    private static void closeConnection()
    {
        if (conn.State == ConnectionState.Open)
        {
            conn.Close();
            conn.Dispose();
            comm.Dispose();
        }
    }
    /// <summary>
    /// 执行sql语句
    /// </summary>
    /// <param name="sqlstr"></param>
    public static void excuteSql(string sqlstr)
    {
        try
        {
            openConnection();
            comm.CommandType = CommandType.Text;
            comm.CommandText = sqlstr;
            comm.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        finally
        { closeConnection(); }
    }
    /// <summary>
    /// 返回指定sql语句的OleDbDataReader对象，使用时请注意关闭这个对象。
    /// </summary>
    /// <param name="sqlstr"></param>
    /// <returns></returns>
    public static OleDbDataReader dataReader(string sqlstr)
    {
        OleDbDataReader dr = null;
        try
        {
            openConnection();
            comm.CommandText = sqlstr;
            comm.CommandType = CommandType.Text;

            dr = comm.ExecuteReader(CommandBehavior.CloseConnection);
        }
        catch
        {
            try
            {
                dr.Close();
                closeConnection();
            }
            catch { }
        }
        return dr;
    }
    /// <summary>
    /// 返回指定sql语句的OleDbDataReader对象,使用时请注意关闭
    /// </summary>
    /// <param name="sqlstr"></param>
    /// <param name="dr"></param>
    public static void dataReader(string sqlstr, ref OleDbDataReader dr)
    {
        try
        {
            openConnection();
            comm.CommandText = sqlstr;
            comm.CommandType = CommandType.Text;
            dr = comm.ExecuteReader(CommandBehavior.CloseConnection);
        }
        catch
        {
            try
            {
                if (dr != null && !dr.IsClosed)
                    dr.Close();
            }
            catch
            {
            }
            finally
            {
                closeConnection();
            }
        }
    }
    /// <summary>
    /// 返回指定sql语句的dataset
    /// </summary>
    /// <param name="sqlstr"></param>
    /// <returns></returns>
    public static DataSet dataSet(string sqlstr)
    {
        DataSet ds = new DataSet();
        OleDbDataAdapter da = new OleDbDataAdapter();
        try
        {
            openConnection();
            comm.CommandType = CommandType.Text;
            comm.CommandText = sqlstr;
            da.SelectCommand = comm;
            da.Fill(ds);

        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        finally
        {
            closeConnection();
        }
        return ds;
    }
    /// <summary>
    /// 返回指定sql语句的dataset
    /// </summary>
    /// <param name="sqlstr"></param>
    /// <param name="ds"></param>
    public static void dataSet(string sqlstr, ref DataSet ds)
    {
        OleDbDataAdapter da = new OleDbDataAdapter();
        try
        {
            openConnection();
            comm.CommandType = CommandType.Text;
            comm.CommandText = sqlstr;
            da.SelectCommand = comm;
            da.Fill(ds);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        finally
        {
            closeConnection();
        }
    }
    /// <summary>
    /// 返回指定sql语句的datatable
    /// </summary>
    /// <param name="sqlstr"></param>
    /// <returns></returns>
    public static DataTable dataTable(string sqlstr)
    {
        DataTable dt = new DataTable();
        OleDbDataAdapter da = new OleDbDataAdapter();
        try
        {
            openConnection();
            comm.CommandType = CommandType.Text;
            comm.CommandText = sqlstr;
            da.SelectCommand = comm;
            da.Fill(dt);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        finally
        {
            closeConnection();
        }
        return dt;
    }
    /// <summary>
    /// 返回指定sql语句的datatable
    /// </summary>
    /// <param name="sqlstr"></param>
    /// <param name="dt"></param>
    public static void dataTable(string sqlstr, ref DataTable dt)
    {
        OleDbDataAdapter da = new OleDbDataAdapter();
        try
        {
            openConnection();
            comm.CommandType = CommandType.Text;
            comm.CommandText = sqlstr;
            da.SelectCommand = comm;
            da.Fill(dt);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        finally
        {
            closeConnection();
        }
    }
    /// <summary>
    /// 返回指定sql语句的dataview
    /// </summary>
    /// <param name="sqlstr"></param>
    /// <returns></returns>
    public static DataView dataView(string sqlstr)
    {
        OleDbDataAdapter da = new OleDbDataAdapter();
        DataView dv = new DataView();
        DataSet ds = new DataSet();
        try
        {
            openConnection();
            comm.CommandType = CommandType.Text;
            comm.CommandText = sqlstr;
            da.SelectCommand = comm;
            da.Fill(ds);
            dv = ds.Tables[0].DefaultView;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        finally
        {
            closeConnection();
        }
        return dv;
    }
}

















//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Data.OleDb;
//using System.Data;
//using System.Windows.Forms;

//namespace yxdain
//{
//    public class AccessHelper
//    {
//        private string conn_str = null;
//        private OleDbConnection ole_connection = null;
//        private OleDbCommand ole_command = null;
//        private OleDbDataReader ole_reader = null;
//        private DataTable dt = null;

//        /// <summary>
//        /// 构造函数
//        /// </summary>
//        public AccessHelper()
//        {
//            //conn_str = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + Environment.CurrentDirectory + "\\yxdain.accdb'";
//            conn_str = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + Environment.CurrentDirectory + "\\ciku.accdb'";

//            InitDB();
//        }

//        private void InitDB()
//        {
//            ole_connection = new OleDbConnection(conn_str);//创建实例
//            ole_command = new OleDbCommand();
//        }

//        /// <summary>
//        /// 构造函数
//        /// </summary>
//        /// <param name="db_path">数据库路径</param>
//        public AccessHelper(string db_path)
//        {
//            //conn_str ="Provider=Microsoft.Jet.OLEDB.4.0;Data Source='"+ db_path + "'";
//            conn_str = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + db_path + "'";

//            InitDB();
//        }

//        /// <summary>
//        /// 转换数据格式
//        /// </summary>
//        /// <param name="reader">数据源</param>
//        /// <returns>数据列表</returns>
//        private DataTable ConvertOleDbReaderToDataTable(ref OleDbDataReader reader)
//        {
//            DataTable dt_tmp = null;
//            DataRow dr = null;
//            int data_column_count = 0;
//            int i = 0;

//            data_column_count = reader.FieldCount;
//            dt_tmp = BuildAndInitDataTable(data_column_count);

//            if (dt_tmp == null)
//            {
//                return null;
//            }

//            while (reader.Read())
//            {
//                dr = dt_tmp.NewRow();

//                for (i = 0; i < data_column_count; ++i)
//                {
//                    dr[i] = reader[i];
//                }

//                dt_tmp.Rows.Add(dr);
//            }

//            return dt_tmp;
//        }

//        /// <summary>
//        /// 创建并初始化数据列表
//        /// </summary>
//        /// <param name="Field_Count">列的个数</param>
//        /// <returns>数据列表</returns>
//        private DataTable BuildAndInitDataTable(int Field_Count)
//        {
//            DataTable dt_tmp = null;
//            DataColumn dc = null;
//            int i = 0;

//            if (Field_Count <= 0)
//            {
//                return null;
//            }

//            dt_tmp = new DataTable();

//            for (i = 0; i < Field_Count; ++i)
//            {
//                dc = new DataColumn(i.ToString());
//                dt_tmp.Columns.Add(dc);
//            }

//            return dt_tmp;
//        }

//        /// <summary>
//        /// 从数据库里面获取数据
//        /// </summary>
//        /// <param name="strSql">查询语句</param>
//        /// <returns>数据列表</returns>
//        public DataTable GetDataTableFromDB(string strSql)
//        {
//            if (conn_str == null)
//            {
//                return null;
//            }

//            try
//            {
//                ole_connection.Open();//打开连接

//                if (ole_connection.State == ConnectionState.Closed)
//                {
//                    return null;
//                }

//                ole_command.CommandText = strSql;
//                ole_command.Connection = ole_connection;

//                ole_reader = ole_command.ExecuteReader(CommandBehavior.Default);

//                dt = ConvertOleDbReaderToDataTable(ref ole_reader);

//                ole_reader.Close();
//                ole_reader.Dispose();
//            }
//            catch (System.Exception e)
//            {
//                //Console.WriteLine(e.ToString());
//                MessageBox.Show(e.Message);
//            }
//            finally
//            {
//                if (ole_connection.State != ConnectionState.Closed)
//                {
//                    ole_connection.Close();
//                }
//            }

//            return dt;
//        }

//        /// <summary>
//        /// 执行sql语句
//        /// </summary>
//        /// <param name="strSql">sql语句</param>
//        /// <returns>返回结果</returns>
//        public int ExcuteSql(string strSql)
//        {
//            int nResult = 0;

//            try
//            {
//                ole_connection.Open();//打开数据库连接
//                if (ole_connection.State == ConnectionState.Closed)
//                {
//                    return nResult;
//                }

//                ole_command.Connection = ole_connection;
//                ole_command.CommandText = strSql;

//                nResult = ole_command.ExecuteNonQuery();
//            }
//            catch (System.Exception e)
//            {
//                //Console.WriteLine(e.ToString());
//                MessageBox.Show(e.Message);
//                return nResult;
//            }
//            finally
//            {
//                if (ole_connection.State != ConnectionState.Closed)
//                {
//                    ole_connection.Close();
//                }
//            }

//            return nResult;
//        }
//    }
//}
