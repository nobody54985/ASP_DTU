using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class MasterPage_USER : System.Web.UI.MasterPage
{
    MODEL model;
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie cookieUsename = new HttpCookie("UserName", Login1.UserName);
        HttpCookie cookiePassWord = new HttpCookie("Password", Login1.Password);
        if (Request.Cookies["UserNme"] !=null)
        {
           
            Login1.Visible = false;
        }
        model = new MODEL(Server.MapPath("~\\App_Data\\dbQUANLYBANHANG.mdf"));
        String SQL = "Select * from tbdanhmuc";
        this.Repeater1.DataSource = model.getDataTable(SQL);
        this.Repeater1.DataBind();

    }

    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        string sql = "Select * from tbLOGIN where UsernameID='"+Login1.UserName+"' and PasswordID='"+Login1.Password+"' ";
        DataTable tb = model.getDataTable(sql);
        if(tb.Rows.Count>0)
        {
            HttpCookie cookieUsename = new HttpCookie("UserName", Login1.UserName);
            HttpCookie cookiePassWord = new HttpCookie("Password", Login1.Password);
            Response.Cookies.Add(cookieUsename);
            Response.Cookies.Add(cookiePassWord);
                cookieUsename.Expires = DateTime.Now.AddDays(-1);
            cookiePassWord.Expires = DateTime.Now.AddDays(-1); ;
            Login1.Visible = false;
        }
    }

    protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
    {
        HttpCookie cookieUsename = new HttpCookie("UserName", Login1.UserName);
        HttpCookie cookiePassWord = new HttpCookie("Password", Login1.Password);
        cookieUsename.Expires = DateTime.Now.AddDays(-1);
        cookiePassWord.Expires = DateTime.Now.AddDays(-1);
        Response.Cookies.Set(cookieUsename);
        Response.Cookies.Set(cookiePassWord);
        //Request.Cookies.Clear();
        Login1.Visible = true;
        
        Response.Redirect("DANHSACHMATHANG.aspx");
    }
}
