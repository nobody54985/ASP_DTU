using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class DANHMUC : System.Web.UI.Page
{
    MODEL model;
    public void loadData()
    {
        this.GridView1.DataSource = model.getDataTable("select * from tbDanhmuc");
        this.GridView1.DataBind();
    }
        protected void Page_Load(object sender, EventArgs e)
    {
       
        model = new MODEL(Server.MapPath("~\\App_Data\\dbQUANLYBANHANG.mdf"));
        if (!IsPostBack)
            loadData();
       
    }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            String SQL = " insert into tbDanhmuc(MaDM,TEnDM) values(" 
                + txtMAM.Text + ",'" + txtTENDM.Text + "')";

            model.ExecuteSQL(SQL);
            loadData();
        }
        protected void btn_Xoa_Click(object sender, EventArgs e) {
            foreach (GridViewRow grow in this.GridView1.Rows){
                CheckBox ckb = null;
                if (grow.FindControl("cbo_Xoa") is CheckBox)
                    ckb = (CheckBox)grow.FindControl("cbo_Xoa");
                if (ckb.Checked == true)
                {
                    String SQL = "delete from tbDanhmuc where MaDM=" + grow.Cells[0].Text;
                    model.ExecuteSQL(SQL);
                }
            }
            loadData();
        }
       
}