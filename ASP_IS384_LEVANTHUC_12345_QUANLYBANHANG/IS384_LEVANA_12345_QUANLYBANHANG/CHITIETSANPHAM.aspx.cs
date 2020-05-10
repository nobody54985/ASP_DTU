using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class CHITIETSANPHAM : System.Web.UI.Page
{
    MODEL model;
    public void KHOITAOGIOHANG()
    {
        DataTable tbGIOHANG = new DataTable();
        tbGIOHANG.Columns.Add("MAMH", typeof(String));
        tbGIOHANG.Columns.Add("TENMH", typeof(String));
        tbGIOHANG.Columns.Add("DONGIA", typeof(double));
        tbGIOHANG.Columns.Add("SOLUONG", typeof(int));
        tbGIOHANG.Columns.Add("THANHTIEN", typeof(double),"SOLUONG*DONGIA");
        tbGIOHANG.Columns.Add("ANHMATHANG", typeof(String));

        Session["tbGiohang"] = tbGIOHANG;
    }
    public void THEMGIOHANG(string mamh,string tenmh,double dongia,int soluong,string anhmathang)
    {
        DataTable tbgiohang = (DataTable)Session["tbGiohang"];
        bool flag = false;
        foreach (DataRow row1 in tbgiohang.Rows)
        {
            if (row1["MAMH"].ToString().Equals(mamh))
            {
                if (Int16.Parse(drop_SOLUONG.Items[this.drop_SOLUONG.Items.Count-1].ToString())
                    >= Int16.Parse(row1["SOLUONG"].ToString())+soluong)
                row1["SOLUONG"] = Int16.Parse(row1["SOLUONG"].ToString()) + soluong;
                flag = true;
            }
        }
        if (!flag)
        {
            DataRow row = tbgiohang.NewRow();
            row["MAMH"] = mamh;
            row["TENMH"] = tenmh;
            row["DONGIA"] = dongia;
            row["SOLUONG"] = soluong;
            row["THANHTIEN"] = dongia * soluong;
            row["ANHMATHANG"] = anhmathang;
            tbgiohang.Rows.Add(row);          
        }
        else
            Session["tbGiohang"] = tbgiohang;

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session.Timeout = 1;

            if (Session["tbGiohang"] == null)
                KHOITAOGIOHANG();
            string MAMH = Request.QueryString.Get("MAMH");
            model = new MODEL(Server.MapPath("~\\App_Data\\dbQUANLYBANHANG.mdf"));
            String SQL = "Select * from tbMATHANG where MAMH = " + MAMH;
            DataTable tb = model.getDataTable(SQL);
            this.Repeater2.DataSource = model.getDataTable(SQL);
            this.Repeater2.DataBind();
            int soluong = int.Parse(tb.Rows[0]["SOLUONG"].ToString());
            for (int i = 1; i <= soluong; i++)
                this.drop_SOLUONG.Items.Add(i.ToString());
        }
    }
    protected void btn_GioHang_Click(object sender, EventArgs e)
    {
        if (Request.Cookies["UserName"] != null && Request.Cookies["PassWord"] != null)
        {

            {
                string MAMH = Request.QueryString.Get("MAMH");
                model = new MODEL(Server.MapPath("~\\App_Data\\dbQUANLYBANHANG.mdf"));
                String SQL = "Select * from tbMATHANG where MAMH = " + MAMH;
                DataTable tb = model.getDataTable(SQL);

                THEMGIOHANG(tb.Rows[0]["MAMH"].ToString(),
                    tb.Rows[0]["TENMH"].ToString(),
                    double.Parse(tb.Rows[0]["DONGIA"].ToString()),
                    int.Parse(this.drop_SOLUONG.SelectedValue),
                     tb.Rows[0]["ANHMATHANG"].ToString());
            }
            Response.Redirect("WEBGIOHANG.aspx");
        }
        else
            //Response.Write("aaaa");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Login!!!');", true);

    }
}