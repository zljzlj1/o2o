
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;


/// <summary>
/// DBClass 的摘要说明
/// </summary>
public class DBClass
{

	public DBClass()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    /// <summary>
    /// 数据库连接
    /// </summary>
    /// <returns>SqlConnection对象</returns>
    public SqlConnection GetConnection()
    {
        string myStr = ConfigurationManager.AppSettings["ConnectionString"].ToString();
        SqlConnection myConn = new SqlConnection(myStr);
        return myConn;
    }
}


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










































using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

/// <summary>
/// MangerClass 的摘要说明
/// </summary>
public class MangerClass
{
    DBClass dbObj = new DBClass();
	public MangerClass()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    //*************************************************************************************************
    /// <summary>
    /// GridView控件的绑定
    /// </summary>
    /// <param name="gvName">控件名字</param>
    /// <param name="P_Str_srcTable">绑定信息</param>
    public  void gvBind(GridView gvName, SqlCommand myCmd, string P_Str_srcTable)
    {      
        SqlDataAdapter da = new SqlDataAdapter(myCmd);
        DataSet ds = new DataSet();
        da.Fill(ds, P_Str_srcTable);
        gvName.DataSource = ds.Tables[P_Str_srcTable].DefaultView;
        gvName.DataBind();
    }
    /// <summary>
    /// 判断有没有最新的订单或新会员
    /// </summary>
    /// <param name="P_Str_ProcName">执行语句的存储过程名</param>
    /// <returns></returns>
    public int IsExistsNI(string P_Str_ProcName)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand(P_Str_ProcName, myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter returnValue = myCmd.Parameters.Add("returnValue", SqlDbType.Int, 4);
        returnValue.Direction = ParameterDirection.ReturnValue;
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }
        int P_Int_returnValue = Convert.ToInt32(returnValue.Value.ToString());
        return P_Int_returnValue;      
    }
    /// <summary>
    /// 绑定最新信息(最新订单信息，最新用户信息量)
    /// </summary>
    /// <param name="P_Str_ProcName">执行语句的存储过程名</param>
    /// <returns></returns>
    public SqlCommand GetNewICmd(string P_Str_ProcName)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand(P_Str_ProcName, myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter returnValue = myCmd.Parameters.Add("returnValue", SqlDbType.Int, 4);
        returnValue.Direction = ParameterDirection.ReturnValue;
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }
      
         return myCmd ;   
    }
    //*************************************************************************************************
    /// <summary>
    ///  获取订单信息
    /// </summary>
    /// <param name="P_Int_Flag">是否是功能菜单栏传来的值</param>
    /// <param name="P_Int_IsMember">是否是以员工来查询</param>
    /// <param name="P_Int_MemberID">员工编号</param>
    /// <param name="P_Int_OrderID">订单编号</param>
    /// <param name="P_Int_Confirm">是否选择了确认下拉菜单</param>
    /// <param name="P_Int_Payed">是否选择了确认下拉菜单</param>
    /// <param name="P_Int_Shipped">是否选择了付款下拉菜单</param>
    /// <param name="P_Int_Finished">是否选择了归档下拉菜单</param>
    /// <param name="P_Int_IsConfirm">订单是否已确认</param>
    /// <param name="P_Int_IsPayment">订单是否已付款</param>
    /// <param name="P_Int_IsConsignment">订单是否已发贷</param>
    /// <param name="P_Int_IsPigeonhole">订单是否已归档</param>
    /// <returns>返回Sqlcommand</returns>
    public SqlCommand  GetOrderInfo(int P_Int_Flag,int P_Int_IsMember, int P_Int_MemberID, int P_Int_OrderID, int P_Int_Confirm,int P_Int_Payed,int P_Int_Shipped,int P_Int_Finished,int P_Int_IsConfirm, int P_Int_IsPayment, int P_Int_IsConsignment, int P_Int_IsPigeonhole)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_GetOrderInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter Flag = new SqlParameter("@Flag", SqlDbType.Int, 4);
        Flag.Value = P_Int_Flag;
        myCmd.Parameters.Add(Flag);
        //添加参数
        SqlParameter IsMember = new SqlParameter("@IsMember", SqlDbType.Int, 4);
        IsMember.Value = P_Int_IsMember;
        myCmd.Parameters.Add(IsMember);
        //添加参数
        SqlParameter MemberID = new SqlParameter("@MemberID", SqlDbType.Int, 4);
        MemberID.Value = P_Int_MemberID;
        myCmd.Parameters.Add(MemberID);
        //添加参数
        SqlParameter OrderID = new SqlParameter("@OrderID", SqlDbType.Int, 4);
        OrderID.Value = P_Int_OrderID;
        myCmd.Parameters.Add(OrderID);
        //添加参数
        SqlParameter Confirm = new SqlParameter("@Confirm", SqlDbType.Int, 4);
        Confirm.Value = P_Int_Confirm;
        myCmd.Parameters.Add(Confirm);
        //添加参数
        SqlParameter Payed = new SqlParameter("@Payed", SqlDbType.Int, 4);
        Payed.Value = P_Int_Payed;
        myCmd.Parameters.Add(Payed);
        //添加参数
        SqlParameter Shipped = new SqlParameter("@Shipped", SqlDbType.Int, 4);
        Shipped.Value = P_Int_Shipped;
        myCmd.Parameters.Add(Shipped);
        SqlParameter Finished = new SqlParameter("@Finished", SqlDbType.Int, 4);
        Finished.Value = P_Int_Finished;
        myCmd.Parameters.Add(Finished);
        //添加参数
        SqlParameter IsConfirm = new SqlParameter("@IsConfirm", SqlDbType.Int, 4);
        IsConfirm.Value = P_Int_IsConfirm;
        myCmd.Parameters.Add(IsConfirm);
        //添加参数
        SqlParameter IsPayment = new SqlParameter("@IsPayment", SqlDbType.Int, 4);
        IsPayment.Value = P_Int_IsPayment;
        myCmd.Parameters.Add(IsPayment);
        //添加参数
        SqlParameter IsConsignment = new SqlParameter("@IsConsignment", SqlDbType.Int, 4);
        IsConsignment.Value = P_Int_IsConsignment;
        myCmd.Parameters.Add(IsConsignment);
        //添加参数
        SqlParameter IsPigeonhole = new SqlParameter("@IsPigeonhole", SqlDbType.Int, 4);
        IsPigeonhole.Value = P_Int_IsPigeonhole;
        myCmd.Parameters.Add(IsPigeonhole);
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }
        return myCmd;
    }
    /// <summary>
    /// 删除指定订单的信息
    /// </summary>
    /// <param name="P_Int_OrderID">订单编号</param>
    public void DeleteOrderInfo(int P_Int_OrderID)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_DeleteOrderInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter OrderID = new SqlParameter("@OrderID", SqlDbType.BigInt, 8);
        OrderID.Value = P_Int_OrderID;
        myCmd.Parameters.Add(OrderID);
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }
    }
    /// <summary>
    /// 获取运输方式名
    /// </summary>
    /// <param name="P_Int_ShipType">运输编号</param>
    /// <returns></returns>
    public string GetShipWay(int P_Int_ShipType)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_GetShipWay", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter ShipType = new SqlParameter("@ShipType", SqlDbType.Int,4);
        ShipType.Value = P_Int_ShipType;
        myCmd.Parameters.Add(ShipType);
        //执行过程
        myConn.Open();
        string P_Str_ShipWay =Convert.ToString(myCmd.ExecuteScalar());
        myCmd.Dispose();
        myConn.Close();
        return P_Str_ShipWay;
    }
    /// <summary>
    /// 获取支付方式名
    /// </summary>
    /// <param name="P_Int_PayType">支付编号</param>
    /// <returns></returns>
    public string GetPayWay(int P_Int_PayType)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_GetPayWay", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter PayType = new SqlParameter("@PayType", SqlDbType.Int, 4);
        PayType.Value = P_Int_PayType;
        myCmd.Parameters.Add(PayType);
        //执行过程
        myConn.Open();
        string P_Str_PayWay = Convert.ToString (myCmd.ExecuteScalar());
        myCmd.Dispose();
        myConn.Close();
        return P_Str_PayWay;
    }
    /// <summary>
    /// 获取订单状态的Dataset数据集
    /// </summary>
    /// <param name="P_Int_OrderID">订单编号</param>
    /// <param name="P_Str_srcTable">订单信息</param>
    /// <returns>返回Dataset</returns>
    public DataSet GetStatusDS(int P_Int_OrderID,string P_Str_srcTable)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_GetStatus", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter OrderID = new SqlParameter("@OrderID", SqlDbType.BigInt, 8);
        OrderID.Value = P_Int_OrderID;
        myCmd.Parameters.Add(OrderID);
        //执行过程
        myConn.Open();
        myCmd.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter(myCmd);
        DataSet ds=new DataSet ();
        da.Fill(ds, P_Str_srcTable);
        myCmd.Dispose();
        myConn.Dispose();
        return ds;
    }
    /// <summary>
    /// 获取订单状态的Dataset数据集
    /// </summary>
    /// <param name="P_Int_OrderID">订单编号</param>
    /// <param name="P_Str_srcTable">订单信息</param>
    /// <returns>返回Dataset</returns>
    public DataSet GetOdIfDS(int P_Int_OrderID, string P_Str_srcTable)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_GetOdIf", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter OrderID = new SqlParameter("@OrderID", SqlDbType.BigInt, 8);
        OrderID.Value = P_Int_OrderID;
        myCmd.Parameters.Add(OrderID);
        //执行过程
        myConn.Open();
        myCmd.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter(myCmd);
        DataSet ds = new DataSet();
        da.Fill(ds, P_Str_srcTable);
        myCmd.Dispose();
        myConn.Dispose();
        return ds;
    }
    /// <summary>
    /// 通过订单ID代号，获取商品信息
    /// </summary>
    /// <param name="P_Int_OrderID">订单ID代号</param>
    /// <param name="P_Str_srcTable">信息</param>
    /// <returns>返回信息的数据集Ds</returns>
    public DataSet GetGIByOID(int P_Int_OrderID, string P_Str_srcTable)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_GetGIByOID", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter OrderID = new SqlParameter("@OrderID", SqlDbType.BigInt, 8);
        OrderID.Value = P_Int_OrderID;
        myCmd.Parameters.Add(OrderID);
        //执行过程
        myConn.Open();
        myCmd.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter(myCmd);
        DataSet ds = new DataSet();
        da.Fill(ds, P_Str_srcTable);
        myCmd.Dispose();
        myConn.Dispose();
        return ds;
    }
    /// <summary>
    ///  修改订单中的信息
    /// </summary>
    /// <param name="P_Int_OrderID">订单编号</param>
    /// <param name="P_Bl_IsConfirm">是否确认</param>
    /// <param name="P_Bl_IsPayment">是否付款</param>
    /// <param name="P_Bl_IsConsignment">是否已发货</param>
    /// <param name="P_Bl_IsPigeonhole">是否已归档</param>
    public void UpdateOI(int P_Int_OrderID,bool P_Bl_IsConfirm,bool P_Bl_IsPayment,bool P_Bl_IsConsignment,bool P_Bl_IsPigeonhole)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_UpdateOI", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter OrderID = new SqlParameter("@OrderID", SqlDbType.BigInt, 8);
        OrderID.Value = P_Int_OrderID;
        myCmd.Parameters.Add(OrderID);
        //添加参数
        SqlParameter IsConfirm = new SqlParameter("@IsConfirm", SqlDbType.Bit, 1);
        IsConfirm.Value = P_Bl_IsConfirm;
        myCmd.Parameters.Add(IsConfirm);
        //添加参数
        SqlParameter IsPayment = new SqlParameter("@IsPayment", SqlDbType.Bit, 1);
        IsPayment.Value = P_Bl_IsPayment;
        myCmd.Parameters.Add(IsPayment);
        //添加参数
        SqlParameter IsConsignment = new SqlParameter("@IsConsignment", SqlDbType.Bit, 1);
        IsConsignment.Value = P_Bl_IsConsignment;
        myCmd.Parameters.Add(IsConsignment);
        //添加参数
        SqlParameter IsPigeonhole = new SqlParameter("@IsPigeonhole", SqlDbType.Bit, 1);
        IsPigeonhole.Value = P_Bl_IsPigeonhole;
        myCmd.Parameters.Add(IsPigeonhole);
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }
    }
    //*************************************************************************************************
    /// <summary>
    /// 添加商品类别名称
    /// </summary>
    /// <param name="P_Str_ClassName">商品类别名称</param>
    /// <param name="P_Str_categoryUrl">商品类别图像</param>
    /// <returns></returns>
    public int AddCategory(string P_Str_ClassName, string P_Str_categoryUrl)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_AddCategory", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter ClassName = new SqlParameter("@ClassName", SqlDbType.VarChar, 50);
        ClassName.Value = P_Str_ClassName;
        myCmd.Parameters.Add(ClassName);
        //添加参数
        SqlParameter categoryUrl = new SqlParameter("@categoryUrl", SqlDbType.VarChar, 50);
        categoryUrl.Value = P_Str_categoryUrl;
        myCmd.Parameters.Add(categoryUrl);
        //添加参数
        SqlParameter returnValue = myCmd.Parameters.Add("returnValue", SqlDbType.Int, 4);
        returnValue.Direction = ParameterDirection.ReturnValue;
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }
        int P_Int_returnValue = Convert.ToInt32(returnValue.Value.ToString());
        return P_Int_returnValue;
    }
    /// <summary>
    /// 获取商品类别的数据集
    /// </summary>
    /// <param name="P_Str_srcTable">商品类别信息表名</param>
    /// <returns>商品类别的数据集</returns>
    public DataSet GetCategory( string P_Str_srcTable)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_GetCategory", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //执行过程
        myConn.Open();
        myCmd.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter(myCmd);
        DataSet ds = new DataSet();
        da.Fill(ds, P_Str_srcTable);
        myCmd.Dispose();
        myConn.Dispose();
        return ds;
    }
    /// <summary>
    /// 获取指定商品类型的数据集
    /// </summary>
    /// <param name="P_Int_ClassID">指定商品的ID</param>
    /// <param name="P_Str_srcTable">商品类型表</param>
    /// <returns>返回指定商品信息的数据集</returns>
    public DataSet GetClassInfoByID(int P_Int_ClassID, string P_Str_srcTable)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_GetClassInfoByID", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter ClassID = new SqlParameter("@ClassID", SqlDbType.BigInt, 8);
        ClassID.Value = P_Int_ClassID;
        myCmd.Parameters.Add(ClassID);
        //执行过程
        myConn.Open();
        myCmd.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter(myCmd);
        DataSet ds = new DataSet();
        da.Fill(ds, P_Str_srcTable);
        myCmd.Dispose();
        myConn.Dispose();
        return ds;
    }
    /// <summary>
    /// 删除指定商品的类别名
    /// </summary>
    /// <param name="P_Int_ClassID">类别编号</param>
    public void  DeleteCategory(int P_Int_ClassID)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_DeleteCategory", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter ClassID = new SqlParameter("@ClassID", SqlDbType.BigInt, 8);
        ClassID.Value = P_Int_ClassID;
        myCmd.Parameters.Add(ClassID);
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }
      
    }
    /// <summary>
    /// 修改指定商品的类别名
    /// </summary>
    /// <param name="P_Int_ClassID">类别编号</param>
    /// <param name="P_Str_ClassName">类别名称</param>
    public int UpdateClassInfo(int P_Int_ClassID, string P_Str_ClassName, string P_Str_categoryUrl)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_UpdateClassInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter ClassID = new SqlParameter("@ClassID", SqlDbType.BigInt, 8);
        ClassID.Value = P_Int_ClassID;
        myCmd.Parameters.Add(ClassID);
        //添加参数
        SqlParameter ClassName = new SqlParameter("@ClassName", SqlDbType.VarChar, 50);
        ClassName.Value = P_Str_ClassName;
        myCmd.Parameters.Add(ClassName);
        //添加参数
        SqlParameter categoryUrl = new SqlParameter("@categoryUrl", SqlDbType.VarChar, 50);
        categoryUrl.Value = P_Str_categoryUrl;
        myCmd.Parameters.Add(categoryUrl);
        //添加参数
        SqlParameter returnValue = myCmd.Parameters.Add("returnValue", SqlDbType.Int, 4);
        returnValue.Direction = ParameterDirection.ReturnValue;
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }
        int P_Int_returnValue = Convert.ToInt32(returnValue.Value.ToString());
        return P_Int_returnValue;
    }

    /// <summary>
    /// 绑定商品类别名
    /// </summary>
    /// <param name="ddlName">绑定控件名</param>
    public void ddlClassBind(DropDownList ddlName)
    { 
        string P_Str_SqlStr = "select * from tb_Class";
        SqlConnection myConn = dbObj.GetConnection();
        SqlDataAdapter da = new SqlDataAdapter(P_Str_SqlStr, myConn);
        DataSet ds = new DataSet();
        da.Fill(ds, "Class");
        ddlName.DataSource = ds.Tables["Class"].DefaultView;
        ddlName.DataTextField = ds.Tables["Class"].Columns[1].ToString();
        ddlName.DataValueField = ds.Tables["Class"].Columns[0].ToString();
        ddlName.DataBind();

    }
    //*************************************************************************************************
    /// <summary>
    /// 绑定商品图像
    /// </summary>
    /// <param name="ddlName">绑定控件名</param>
    public void ddlUrl(DropDownList ddlName)
    {
        string P_Str_SqlStr = "select * from tb_Image";
        SqlConnection myConn = dbObj.GetConnection();
        SqlDataAdapter da = new SqlDataAdapter(P_Str_SqlStr, myConn);
        DataSet ds = new DataSet();
        da.Fill(ds, "Url");
        ddlName.DataSource = ds.Tables["Url"].DefaultView;
        ddlName.DataTextField = ds.Tables["Url"].Columns[1].ToString();
        ddlName.DataValueField = ds.Tables["Url"].Columns[2].ToString();
        ddlName.DataBind();
    }
    /// <summary>
    /// 添加商品信息
    /// </summary>
    /// <param name="P_Int_ClassID">商品编号</param>
    /// <param name="P_Str_GoodsName">商品名称</param>
    /// <param name="P_Str_GoodsIntroduce">商品描述</param>
    /// <param name="P_Str_GoodsBrand">商品品牌</param>
    /// <param name="P_Str_GoodsUnit">商品单位</param>
    /// <param name="P_Fl_GoodsWeight">商品重量</param>
    /// <param name="P_Str_GoodsUrl">商品图像</param>
    /// <param name="P_Fl_MemberPrice">商品会员价</param>
    /// <param name="P_Bl_Isrefinement">是否是精品</param>
    /// <param name="P_Bl_IsHot">是否是热销商品</param>
    /// <param name="P_Bl_IsDiscount">是否是最新商品</param>
    /// <returns>返回一个值，判断商品是否存在</returns>
    public int AddGInfo(int P_Int_ClassID, string P_Str_GoodsName, string P_Str_GoodsIntroduce, string P_Str_GoodsBrand, string P_Str_GoodsUnit, string P_Str_GoodsUrl,float P_Flt_MemberPrice, bool P_Bl_IsBest, bool P_Bl_IsHot, bool P_Bl_IsNew)
    {

        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_AddGoodsInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter ClassID = new SqlParameter("@ClassID", SqlDbType.BigInt,8);
        ClassID.Value = P_Int_ClassID;
        myCmd.Parameters.Add(ClassID);
        //添加参数
        SqlParameter GoodsName = new SqlParameter("@GoodsName", SqlDbType.VarChar, 50);
        GoodsName.Value = P_Str_GoodsName;
        myCmd.Parameters.Add(GoodsName);
        //添加参数
        SqlParameter GoodsIntroduce = new SqlParameter("@GoodsIntroduce", SqlDbType.NText, 1000);
        GoodsIntroduce.Value = P_Str_GoodsIntroduce;
        myCmd.Parameters.Add(GoodsIntroduce);
        //添加参数
        SqlParameter GoodsBrand = new SqlParameter("@GoodsBrand", SqlDbType.VarChar, 50);
        GoodsBrand.Value = P_Str_GoodsBrand;
        myCmd.Parameters.Add(GoodsBrand);
        //添加参数
        SqlParameter GoodsUnit = new SqlParameter("@GoodsUnit", SqlDbType.VarChar, 10);
        GoodsUnit.Value = P_Str_GoodsUnit;
        myCmd.Parameters.Add(GoodsUnit);
        //添加参数
        SqlParameter GoodsUrl = new SqlParameter("@GoodsUrl", SqlDbType.VarChar, 50);
        GoodsUrl.Value = P_Str_GoodsUrl;
        myCmd.Parameters.Add(GoodsUrl);
        //添加参数
        SqlParameter MemberPrice = new SqlParameter("@MemberPrice", SqlDbType.Float, 8);
        MemberPrice.Value = P_Flt_MemberPrice;
        myCmd.Parameters.Add(MemberPrice);
        //添加参数
        SqlParameter IsBest = new SqlParameter("@IsBest", SqlDbType.Bit, 1);
        IsBest.Value = P_Bl_IsBest;
        myCmd.Parameters.Add(IsBest);
        //添加参数
        SqlParameter IsHot = new SqlParameter("@IsHot", SqlDbType.Bit, 1);
        IsHot.Value = P_Bl_IsHot;
        myCmd.Parameters.Add(IsHot);
        //添加参数
        SqlParameter IsNew = new SqlParameter("@IsNew", SqlDbType.Bit, 1);
        IsNew.Value = P_Bl_IsNew;
        myCmd.Parameters.Add(IsNew);
        //添加参数
        SqlParameter returnValue = myCmd.Parameters.Add("returnValue",SqlDbType.Int,4);
        returnValue.Direction = ParameterDirection.ReturnValue;
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw (ex);

        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();
        }
        return Convert.ToInt32(returnValue.Value.ToString());

    }
    /// <summary>
    /// 获取商品信息的数据集
    /// </summary>
    /// <param name="P_Str_srcTable">商品信息表</param>
    /// <returns>返回商品信息的数据集</returns>
    public DataSet GetGoodsInfoDs(string P_Str_srcTable)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_GetGoodsInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //执行过程
        myConn.Open();
        myCmd.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter(myCmd);
        DataSet ds = new DataSet();
        da.Fill(ds, P_Str_srcTable);
        myCmd.Dispose();
        myConn.Dispose();
        return ds;
    }
    /// <summary>
    /// 获取指定商品信息的数据集
    /// </summary>
    /// <param name="P_Int_GoodsID">指定商品的ID</param>
    /// <param name="P_Str_srcTable">商品信息表</param>
    /// <returns>返回指定商品信息的数据集</returns>
    public DataSet GetGoodsInfoByIDDs(int P_Int_GoodsID,string P_Str_srcTable)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_GetGoodsInfoByID", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter GoodsID = new SqlParameter("@GoodsID", SqlDbType.BigInt, 8);
        GoodsID.Value = P_Int_GoodsID;
        myCmd.Parameters.Add(GoodsID);
        //执行过程
        myConn.Open();
        myCmd.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter(myCmd);
        DataSet ds = new DataSet();
        da.Fill(ds, P_Str_srcTable);
        myCmd.Dispose();
        myConn.Dispose();
        return ds;
    }
    /// <summary>
    /// 获取搜索商品信息的数据集
    /// </summary>
    /// <param name="P_Str_srcTable">商品信息表</param>
    /// <param name="P_Str_keywords">搜索的关键字</param>
    /// <returns>返回搜索商品信息的数据集</returns>
    public DataSet SearchGoodsInfoDs(string P_Str_srcTable, string P_Str_keywords)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_SearchGoodsInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter keywords = new SqlParameter("@keywords", SqlDbType.VarChar, 50);
        keywords.Value = P_Str_keywords;
        myCmd.Parameters.Add(keywords);

        //执行过程
        myConn.Open();
        myCmd.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter(myCmd);
        DataSet ds = new DataSet();
        da.Fill(ds, P_Str_srcTable);
        myCmd.Dispose();
        myConn.Dispose();
        return ds;
    }
    /// <summary>
    /// 删除指定的商品信息
    /// </summary>
    /// <param name="P_Int_GoodsID">指定商品的编号</param>
    public void DeleteGoodsInfo(int P_Int_GoodsID)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_DeleteGoodsInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter GoodsID = new SqlParameter("@GoodsID", SqlDbType.BigInt, 8);
        GoodsID.Value = P_Int_GoodsID;
        myCmd.Parameters.Add(GoodsID);
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }
    }
    public void UpdateGInfo(int P_Int_ClassID, string P_Str_GoodsName, string P_Str_GoodsIntroduce, string P_Str_GoodsBrand, string P_Str_GoodsUnit, string P_Str_GoodsUrl, float P_Flt_MemberPrice, bool P_Bl_IsBest, bool P_Bl_IsHot, bool P_Bl_IsNew, int P_Int_GoodsID)
    {

        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_UpdateGoodsInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter ClassID = new SqlParameter("@ClassID", SqlDbType.BigInt, 8);
        ClassID.Value = P_Int_ClassID;
        myCmd.Parameters.Add(ClassID);
        //添加参数
        SqlParameter GoodsName = new SqlParameter("@GoodsName", SqlDbType.VarChar, 50);
        GoodsName.Value = P_Str_GoodsName;
        myCmd.Parameters.Add(GoodsName);
        //添加参数
        SqlParameter GoodsIntroduce = new SqlParameter("@GoodsIntroduce", SqlDbType.NText, 1000);
        GoodsIntroduce.Value = P_Str_GoodsIntroduce;
        myCmd.Parameters.Add(GoodsIntroduce);
        //添加参数
        SqlParameter GoodsBrand = new SqlParameter("@GoodsBrand", SqlDbType.VarChar, 50);
        GoodsBrand.Value = P_Str_GoodsBrand;
        myCmd.Parameters.Add(GoodsBrand);
        //添加参数
        SqlParameter GoodsUnit = new SqlParameter("@GoodsUnit", SqlDbType.VarChar, 10);
        GoodsUnit.Value = P_Str_GoodsUnit;
        myCmd.Parameters.Add(GoodsUnit);
        //添加参数
        SqlParameter GoodsUrl = new SqlParameter("@GoodsUrl", SqlDbType.VarChar, 50);
        GoodsUrl.Value = P_Str_GoodsUrl;
        myCmd.Parameters.Add(GoodsUrl);
        //添加参数
        SqlParameter MemberPrice = new SqlParameter("@MemberPrice", SqlDbType.Float , 8);
        MemberPrice.Value = P_Flt_MemberPrice;
        myCmd.Parameters.Add(MemberPrice);
        //添加参数
        SqlParameter IsBest = new SqlParameter("@IsBest", SqlDbType.Bit, 1);
        IsBest.Value = P_Bl_IsBest;
        myCmd.Parameters.Add(IsBest);
        //添加参数
        SqlParameter IsHot = new SqlParameter("@IsHot", SqlDbType.Bit, 1);
        IsHot.Value = P_Bl_IsHot;
        myCmd.Parameters.Add(IsHot);
        //添加参数
        SqlParameter IsNew = new SqlParameter("@IsNew", SqlDbType.Bit, 1);
        IsNew.Value = P_Bl_IsNew;
        myCmd.Parameters.Add(IsNew);
        //添加参数
        SqlParameter GoodsID = new SqlParameter("@GoodsID", SqlDbType.BigInt, 8);
        GoodsID.Value = P_Int_GoodsID;
        myCmd.Parameters.Add(GoodsID);
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw (ex);

        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();
        }
    }
    //*************************************************************************************************
    /// <summary>
    /// 添加管理员
    /// </summary>
    /// <param name="P_Str_Admin">管理员名</param>
    /// <returns></returns>
    public int AddAdmin(string P_Str_Admin,string P_Str_Password)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_AddAdmin", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter Admin = new SqlParameter("@Admin", SqlDbType.VarChar, 50);
        Admin.Value = P_Str_Admin;
        myCmd.Parameters.Add(Admin);
        //添加参数
        SqlParameter Password = new SqlParameter("@Password", SqlDbType.VarChar, 50);
        Password.Value = P_Str_Password;
        myCmd.Parameters.Add(Password);
        //添加参数
        SqlParameter returnValue = myCmd.Parameters.Add("returnValue", SqlDbType.Int, 4);
        returnValue.Direction = ParameterDirection.ReturnValue;
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }
        int P_Int_returnValue = Convert.ToInt32(returnValue.Value.ToString());
        return P_Int_returnValue;
    }
    /// <summary>
    /// 判断管理员是否存在
    /// </summary>
    /// <param name="P_Str_Name">管理员名字</param>
    /// <param name="P_Str_Password">管理员密码</param>
    /// <returns></returns>
    public int AExists(string P_Str_Name, string P_Str_Password)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_AdminExists", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter Name = new SqlParameter("@Name", SqlDbType.VarChar, 50);
        Name.Value = P_Str_Name;
        myCmd.Parameters.Add(Name);
        //添加参数
        SqlParameter Password = new SqlParameter("@Password", SqlDbType.VarChar, 50);
        Password.Value = P_Str_Password;
        myCmd.Parameters.Add(Password);
        //添加参数
        SqlParameter returnValue = myCmd.Parameters.Add("returnValue", SqlDbType.Int, 4);
        returnValue.Direction = ParameterDirection.ReturnValue;
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }
        int P_Int_returnValue = Convert.ToInt32(returnValue.Value.ToString());
        return P_Int_returnValue;
    }
    /// <summary>
    /// 返回管理员信息
    /// </summary>
    /// <param name="P_Str_Name">管理员名</param>
    /// <param name="P_Str_Password">管理员密码</param>
    /// <param name="P_Str_srcTable">信息表名</param>
    /// <returns></returns>
    public DataSet ReturnAIDs(string P_Str_Name, string P_Str_Password, string P_Str_srcTable)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_GetAInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter Name = new SqlParameter("@Name", SqlDbType.VarChar, 50);
        Name.Value = P_Str_Name;
        myCmd.Parameters.Add(Name);
        //添加参数
        SqlParameter Password = new SqlParameter("@Password", SqlDbType.VarChar, 50);
        Password.Value = P_Str_Password;
        myCmd.Parameters.Add(Password);
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }
        SqlDataAdapter da = new SqlDataAdapter(myCmd);
        DataSet ds = new DataSet();
        da.Fill(ds, P_Str_srcTable);
        return ds;

    }
    /// <summary>
    /// 根据ID号返回管理员信息
    /// </summary>
    /// <param name="P_Int_AdminID">管理员ID</param>
    /// <param name="P_Str_srcTable">信息表名</param>
    /// <returns></returns>
    public DataSet ReturnAdminByID(int P_Int_AdminID, string P_Str_srcTable)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_GetAInfoByID", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter AdminID = new SqlParameter("@AdminID", SqlDbType.VarChar, 50);
        AdminID.Value = P_Int_AdminID;
        myCmd.Parameters.Add(AdminID);
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }
        SqlDataAdapter da = new SqlDataAdapter(myCmd);
        DataSet ds = new DataSet();
        da.Fill(ds, P_Str_srcTable);
        return ds;

    }
    /// <summary>
    /// 获取所有管理员信息
    /// </summary>
    /// <param name="P_Str_srcTable">管理员信息表名</param>
    /// <returns>返回所有管理员信息的数据集</returns>
    public DataSet ReturnAdminIDs(string P_Str_srcTable)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_GetAdminInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }
        SqlDataAdapter da = new SqlDataAdapter(myCmd);
        DataSet ds = new DataSet();
        da.Fill(ds, P_Str_srcTable);
        return ds;

    }
    /// <summary>
    /// 删除指定管理员信息
    /// </summary>
    /// <param name="P_Int_AdminID">管理员编号</param>
    public void  DeleteAdminInfo(int P_Int_AdminID)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_DeleteAdminInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter AdminID = new SqlParameter("@AdminID", SqlDbType.BigInt,8);
        AdminID.Value = P_Int_AdminID;
        myCmd.Parameters.Add(AdminID);
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }
    }
    public void UpdateAdminInfo(int P_Int_AdminID,string P_Str_Admin,string P_Str_Password)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_UpdateAdminInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter AdminID = new SqlParameter("@AdminID", SqlDbType.BigInt, 8);
        AdminID.Value = P_Int_AdminID;
        myCmd.Parameters.Add(AdminID);
        //添加参数
        SqlParameter Admin = new SqlParameter("@Admin", SqlDbType.VarChar, 50);
        Admin.Value = P_Str_Admin;
        myCmd.Parameters.Add(Admin);
        //添加参数
        SqlParameter Password = new SqlParameter("@Password", SqlDbType.VarChar, 50);
        Password.Value = P_Str_Password;
        myCmd.Parameters.Add(Password);
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }
    }
    //***********************************************************************************************************
    /// <summary>
    /// 获取图像信息
    /// </summary>
    /// <param name="P_Str_srcTable">图像信息</param>
    /// <returns>返回图像信息数据集</returns>
    public DataSet ReturnImagerDs(string P_Str_srcTable)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_GetImageInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }
        SqlDataAdapter da = new SqlDataAdapter(myCmd);
        DataSet ds = new DataSet();
        da.Fill(ds, P_Str_srcTable);
        return ds;

    }
    /// <summary>
    /// 向图像表中插入信息
    /// </summary>
    /// <param name="P_Str_ImageName">图像名</param>
    /// <param name="P_Int_ImageUrl">图像路径</param>
    public void  InsertImage(string P_Str_ImageName,string P_Str_ImageUrl)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_InsertImageInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter ImageName = new SqlParameter("@ImageName", SqlDbType.VarChar, 50);
        ImageName.Value = P_Str_ImageName;
        myCmd.Parameters.Add(ImageName);
        //添加参数
        SqlParameter ImageUrl = new SqlParameter("@ImageUrl", SqlDbType.VarChar, 200);
        ImageUrl.Value = P_Str_ImageUrl;
        myCmd.Parameters.Add(ImageUrl);
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }
    }
    /// <summary>
    /// 删除图片表中的信息
    /// </summary>
    /// <param name="P_Int_ImageID">图片表中ID</param>
    public void DeleteImage(int P_Int_ImageID)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_DeleteImageInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter ImageID = new SqlParameter("@ImageID", SqlDbType.BigInt, 8);
        ImageID.Value = P_Int_ImageID;
        myCmd.Parameters.Add(ImageID);
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }
    }
   //**************************************************************************************************
    public DataSet ReturnMemberDs(string P_Str_srcTable)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_GetAllUserInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }
        SqlDataAdapter da = new SqlDataAdapter(myCmd);
        DataSet ds = new DataSet();
        da.Fill(ds, P_Str_srcTable);
        return ds;
    }
    /// <summary>
    /// 删除指定会员的信息
    /// </summary>
    /// <param name="P_Int_MemberID">会员ID</param>
    public void DeleteMemberInfo(int P_Int_MemberID)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_DeleteMemberInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter MemberID = new SqlParameter("@MemberID", SqlDbType.BigInt, 8);
        MemberID.Value = P_Int_MemberID;
        myCmd.Parameters.Add(MemberID);
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }
    }
    //*********************************************************************************************
    /// <summary>
    /// 获取配送方式的数据集
    /// </summary>
    /// <param name="P_Str_srcTable">配送方式表的信息</param>
    /// <returns>返回配送方式的数据集</returns>
    public DataSet ReturnShipDs(string P_Str_srcTable)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_GetShipInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }
        SqlDataAdapter da = new SqlDataAdapter(myCmd);
        DataSet ds = new DataSet();
        da.Fill(ds, P_Str_srcTable);
        return ds;
    }
   /// <summary>
   /// 返回指定配送方式信息的数据集
   /// </summary>
   /// <param name="P_Int_ShipID">配送方式ID</param>
   /// <param name="P_Str_srcTable">配送方式信息</param>
   /// <returns></returns>
    public DataSet ReturnShipDsByID(int P_Int_ShipID,string P_Str_srcTable)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_GetShipInfoByID", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter ShipID = new SqlParameter("@ShipID", SqlDbType.BigInt, 8);
        ShipID.Value = P_Int_ShipID;
        myCmd.Parameters.Add(ShipID);
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }
        SqlDataAdapter da = new SqlDataAdapter(myCmd);
        DataSet ds = new DataSet();
        da.Fill(ds, P_Str_srcTable);
        return ds;
    }
    /// <summary>
    /// 删除指定配送方式信息
    /// </summary>
    /// <param name="P_Int_ShipID">指定配送方式的ID</param>
    public void DeleteShipInfo(int P_Int_ShipID)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_DeleteShipInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter ShipID = new SqlParameter("@ShipID", SqlDbType.BigInt, 8);
        ShipID.Value = P_Int_ShipID;
        myCmd.Parameters.Add(ShipID);
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }
    }
    /// <summary>
    /// 返回指定类别的名称
    /// </summary>
    /// <param name="P_Int_ClassID">指定类别的ID</param>
    /// <returns></returns>
    public string GetClass(int P_Int_ClassID)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_GetClassName", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter ClassID = new SqlParameter("@ClassID", SqlDbType.Int, 8);
        ClassID.Value = P_Int_ClassID;
        myCmd.Parameters.Add(ClassID);
        //执行过程
        myConn.Open();
        string P_Str_Class = Convert.ToString(myCmd.ExecuteScalar());
        myCmd.Dispose();
        myConn.Close();
        return P_Str_Class;
    }
    public void InsertShip(string P_Str_ShipWay, float P_Flt_ShipFee)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_InsertShipInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter ShipWay = new SqlParameter("@ShipWay", SqlDbType.VarChar, 50);
        ShipWay.Value = P_Str_ShipWay;
        myCmd.Parameters.Add(ShipWay);
        //添加参数
        SqlParameter ShipFee = new SqlParameter("@ShipFee", SqlDbType.Float , 8);
        ShipFee.Value = P_Flt_ShipFee;
        myCmd.Parameters.Add(ShipFee);
    
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }
    }
    public void UpdateShip(int P_Int_ShipID, string P_Str_ShipWay, float P_Flt_ShipFee)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_UpdateShipInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter ShipID = new SqlParameter("@ShipID", SqlDbType.BigInt, 8);
        ShipID.Value = P_Int_ShipID;
        myCmd.Parameters.Add(ShipID);
        //添加参数
        SqlParameter ShipWay = new SqlParameter("@ShipWay", SqlDbType.VarChar, 50);
        ShipWay.Value = P_Str_ShipWay;
        myCmd.Parameters.Add(ShipWay);
        //添加参数
        SqlParameter ShipFee = new SqlParameter("@ShipFee", SqlDbType.Float , 8);
        ShipFee.Value = P_Flt_ShipFee;
        myCmd.Parameters.Add(ShipFee);
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }
    }
    //*********************************************************************************************
    /// <summary>
    /// 获取支付方式的数据集
    /// </summary>
    /// <param name="P_Str_srcTable">支付方式表的信息</param>
    /// <returns>返回支付方式的数据集</returns>
    public DataSet ReturnPayDs(string P_Str_srcTable)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_GetPayInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }
        SqlDataAdapter da = new SqlDataAdapter(myCmd);
        DataSet ds = new DataSet();
        da.Fill(ds, P_Str_srcTable);
        return ds;
    }
    /// <summary>
    /// 返回指定支付方式信息的数据集
    /// </summary>
    /// <param name="P_Int_PayID">支付方式ID</param>
    /// <param name="P_Str_srcTable">支付方式信息</param>
    /// <returns></returns>
    public DataSet ReturnPayDsByID(int P_Int_PayID, string P_Str_srcTable)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_GetPayInfoByID", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter PayID = new SqlParameter("@PayID", SqlDbType.BigInt, 8);
        PayID.Value = P_Int_PayID;
        myCmd.Parameters.Add(PayID);
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }
        SqlDataAdapter da = new SqlDataAdapter(myCmd);
        DataSet ds = new DataSet();
        da.Fill(ds, P_Str_srcTable);
        return ds;
    }
    /// <summary>
    /// 删除指定支付方式信息
    /// </summary>
    /// <param name="P_Int_PayID">指定支付方式的ID</param>
    public void DeletePayInfo(int P_Int_PayID)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_DeletePayInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter PayID = new SqlParameter("@PayID", SqlDbType.BigInt, 8);
        PayID.Value = P_Int_PayID;
        myCmd.Parameters.Add(PayID);
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }
    }
    public void InsertPay(string P_Str_PayWay)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_InsertPayInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter PayWay = new SqlParameter("@PayWay", SqlDbType.VarChar, 50);
        PayWay.Value = P_Str_PayWay;
        myCmd.Parameters.Add(PayWay);  
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }
    }
    public void UpdatePay(int P_Int_PayID, string P_Str_PayWay)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_UpdatePayInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter PayID = new SqlParameter("@PayID", SqlDbType.BigInt, 8);
        PayID.Value = P_Int_PayID;
        myCmd.Parameters.Add(PayID);
        //添加参数
        SqlParameter PayWay = new SqlParameter("@PayWay", SqlDbType.VarChar, 50);
        PayWay.Value = P_Str_PayWay;
        myCmd.Parameters.Add(PayWay);
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }
    }
   //*********************************************************
    /// <summary>
    /// 查询所有配送地点信息
    /// </summary>
    /// <param name="P_Str_srcTable">地点表信息</param>
    /// <returns>返回所有配送地点信息数据集</returns>
    public DataSet ReturnAreaDs(string P_Str_srcTable)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_GetAreaInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }
        SqlDataAdapter da = new SqlDataAdapter(myCmd);
        DataSet ds = new DataSet();
        da.Fill(ds, P_Str_srcTable);
        return ds;
    }
    /// <summary>
    /// 删除指定地点的信息
    /// </summary>
    /// <param name="P_Int_AreaID">地点编号</param>
    public void DeleteAreaInfo(int P_Int_AreaID)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_DeleteAreaInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter AreaID = new SqlParameter("@AreaID", SqlDbType.BigInt, 8);
        AreaID.Value = P_Int_AreaID;
        myCmd.Parameters.Add(AreaID);
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }
    }
    /// <summary>
    /// 查询指定地点编号信息的数据集
    /// </summary>
    /// <param name="P_Int_AreaID">地点编号</param>
    /// <param name="P_Str_srcTable">地点数据表</param>
    /// <returns>返回指定地点编号信息的数据集</returns>
    public DataSet ReturnAreaDsByID(int P_Int_AreaID, string P_Str_srcTable)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_GetAreaInfoByID", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter AreaID = new SqlParameter("@AreaID", SqlDbType.BigInt, 8);
        AreaID.Value = P_Int_AreaID;
        myCmd.Parameters.Add(AreaID);
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }
        SqlDataAdapter da = new SqlDataAdapter(myCmd);
        DataSet ds = new DataSet();
        da.Fill(ds, P_Str_srcTable);
        return ds;
    }
    public void InsertArea(string P_Str_AreaName)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_InsertAreaInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter AreaName = new SqlParameter("@AreaName", SqlDbType.VarChar, 50);
        AreaName.Value = P_Str_AreaName;
        myCmd.Parameters.Add(AreaName);
     
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }
    }
    public void UpdateArea(int P_Int_AreaID,string P_Str_AreaName)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_UpdateAreaInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter AreaID = new SqlParameter("@AreaID", SqlDbType.BigInt, 8);
        AreaID.Value = P_Int_AreaID;
        myCmd.Parameters.Add(AreaID);
        //添加参数
        SqlParameter AreaName = new SqlParameter("@AreaName", SqlDbType.VarChar, 50);
        AreaName.Value = P_Str_AreaName;
        myCmd.Parameters.Add(AreaName);
       
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }
    }
    /// <summary>
    /// 用来将字符串保留到指定长度，将超出部分用“...”代替。
    /// </summary>
    /// <param name="sString">sString原字符串。</param>
    /// <param name="nLeng">nLeng长度。</param>
    /// <returns>处理后的字符串。</returns>
    public string SubStr(string sString, int nLeng)
    {
        if (sString.Length <= nLeng)
        {
            return sString;
        }
        int nStrLeng = nLeng - 3;
        string sNewStr = sString.Substring(0, nStrLeng);
        sNewStr = sNewStr + "...";
        return sNewStr;
    }
    /// <summary>
    /// 用来截取小数点后nleng位
    /// </summary>
    /// <param name="sString">sString原字符串。</param>
    /// <param name="nLeng">nLeng长度。</param>
    /// <returns>处理后的字符串。</returns>
    public string VarStr(string sString, int nLeng)
    {
        int index = sString.IndexOf(".");
        if (index == -1||index+2>=sString.Length)
            return sString;
        else
            return sString.Substring(0, (index + nLeng+1));
    }

}
