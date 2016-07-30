using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
/// <summary>
///DBAccess1 的摘要说明
/// </summary>
public class DBAccess1
{
    protected static OleDbConnection conn = new OleDbConnection();
    protected static OleDbCommand cmd = new OleDbCommand();
	public DBAccess1()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public static void Open()
    {

        string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringXS"].ConnectionString.ToString();

        if (conn.State == ConnectionState.Closed)
        {
            conn.ConnectionString = connStr;
            cmd.Connection = conn;
            try
            {
                conn.Open();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }

    /// <summary>
    /// 关闭OLE DB连接
    /// </summary>
    public static void Close()
    {
        if (conn.State == ConnectionState.Open)
            conn.Close();
        conn.Dispose();
        cmd.Dispose();
    }

    /// <summary>
    /// 执行一个SQL语句(UPDATE,INSERT)
    /// </summary>
    /// <param name="sql">SQL语句</param>
    public void ExeSql(string sql)
    {
        Close();
        Open();
        //try
        //{
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            Close();
        //}
        //catch
        //{
        //    Close();
        //}
    }

    /// <summary>
    /// 执行SQL语句返回影响行数
    /// </summary>
    /// <param name="sql">SQL语句</param>
    /// <returns>影响行数</returns>
    public int ExeSqlRows(string sql)
    {

        Open();
        try
        {
            cmd.CommandText = sql;
            int rowCount = cmd.ExecuteNonQuery();
            Close();
            return rowCount;
        }
        catch
        {
            Close();
            return 0;
        }
    }
    /// <summary>
    /// 获取DataSet
    /// </summary>
    /// <param name="sql">SQL语句</param>
    /// <returns>DataSet</returns>
    

    public DataSet GetDataSet(string sql)
    {
        Close();
        DataSet ds = null;
        try
        {
            Open();
            ds = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter();
            cmd.CommandText = sql;
            da.SelectCommand = cmd;
            da.Fill(ds, "datatable");
        }
        catch
        {
            Close();
        }
        return ds;
    }

    /// <summary>
    /// 获取DataReader
    /// </summary>
    /// <param name="sql">SQL语句</param>
    /// <returns>DataReader</returns>
    public OleDbDataReader GetDataReader(string sql)
    {

        Close();
        OleDbDataReader dr = null;
        try
        {
            Open();
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteReader();
        }
        catch
        {
            Close();
        }
        return dr;
    }

    /// <summary>
    /// 获取DataTable
    /// </summary>
    /// <param name="sql">SQL语句</param>
    /// <returns>DataTable</returns>
    public DataTable GetDataTable(string sql)//pass
    {
        OleDbDataAdapter da = new OleDbDataAdapter();
        DataTable dt = new DataTable();
        try
        {
            Open();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            da.SelectCommand = cmd;
            da.Fill(dt);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        finally
        {
            Close();
        }
        return dt;
    }

    public void UpdateDataSet(DataSet ds, string str)
    {
        Open();

        OleDbDataAdapter da = new OleDbDataAdapter(str, conn);
        OleDbCommandBuilder cmdbld = new OleDbCommandBuilder(da);

        da.Update(ds, "datatable");
        ds.AcceptChanges();

        Close();

    }
    /// <summary>
    /// 执行存储过程
    /// </summary>
    /// <param name="p_ProcedureName">存储过程名</param>
    /// <param name="p_SqlParameterArray">存储过程参数</param>
    public void ExeProcedure(string p_ProcedureName, OleDbParameter[] p_OleDbParameterArray)
    {

        Open();

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = p_ProcedureName;

        foreach (OleDbParameter Sq in p_OleDbParameterArray)
        {
            cmd.Parameters.Add(Sq);
        }
        cmd.ExecuteNonQuery();

        Close();
    }
}