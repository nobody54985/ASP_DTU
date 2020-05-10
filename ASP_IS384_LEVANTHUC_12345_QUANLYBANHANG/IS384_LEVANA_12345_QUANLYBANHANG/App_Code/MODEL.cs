using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MODEL
/// </summary>
using System.Data;
using System.Data.SqlClient;
public class MODEL
{
    SqlConnection con;
    public MODEL(String DPath)
    {
        con = new SqlConnection();
        con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="
            + DPath + ";Integrated Security=True";
        
    }
    public MODEL ()
    {
        con = new SqlConnection();
        con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\source\repos\ASP_IS384_LEVANTHUC_12345_QUANLYBANHANG\IS384_LEVANA_12345_QUANLYBANHANG\App_Data\dbQUANLYBANHANG.mdf;Integrated Security=True";
    }
    public void Moketnoi()
    {
        if (con.State == ConnectionState.Closed)
            con.Open();
    }
    public void Dongketnoi()
    {
        if (con.State == ConnectionState.Open)
            con.Close();
    }
    public DataTable getDataTable(String SQL)
    {
        this.Moketnoi();
        SqlDataAdapter adp = new SqlDataAdapter(SQL, con);
        DataTable tb = new DataTable();
        adp.Fill(tb);
        this.Dongketnoi();
        return tb;
    }
    public void getDataSet(ref DataSet ds, String sql)
    {
        DataTable tb = this.getDataTable(sql);
        ds.Tables.Add(tb);
    }
    public int ExecuteSQL(string SQL)
    {
        this.Moketnoi();
        SqlCommand command = new SqlCommand();
        command.Connection = con;
        command.CommandText = SQL;
        command.CommandType = CommandType.Text;
        int k = (int)command.ExecuteNonQuery();
        this.Dongketnoi();
        return k;
    }
    public void ExecuteStorProceduce(String tenthutuc, SqlParameter[] pr)
    {
        this.Moketnoi();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = tenthutuc;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddRange(pr);    
        cmd.ExecuteNonQuery();
        Dongketnoi();
    }
    public DataTable getTableStorProceduce(String tenthutuc, SqlParameter[] pr)
    {
        this.Moketnoi();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = tenthutuc;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddRange(pr);
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        DataTable tb = new DataTable();
        adp.Fill(tb);
        Dongketnoi();
        return tb;
    }
}