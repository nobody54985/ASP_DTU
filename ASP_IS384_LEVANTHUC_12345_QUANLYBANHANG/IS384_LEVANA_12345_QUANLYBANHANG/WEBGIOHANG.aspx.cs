using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class WEBGIOHANG : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        
            if (Session["tbGiohang"] != null)
            {
                DataTable tbgiohang = (DataTable)Session["tbGiohang"];
                this.gridGIOHANG.DataSource = tbgiohang;
                this.gridGIOHANG.DataBind();
            }
        
    }

    protected void btnTRAHANG_Click(object sender, EventArgs e)
    {
        DataTable tbgiohang = (DataTable)Session["tbGiohang"];
        for (int i=this.gridGIOHANG.Rows.Count-1;i>=0; i--)
        //foreach (GridViewRow grow in this.gridGIOHANG.Rows)
        {
            CheckBox ckb = null;
            GridViewRow grow = this.gridGIOHANG.Rows[i];
            if (grow.FindControl("ckbTRAHANG") is CheckBox)
                ckb = (CheckBox)grow.FindControl("ckbTRAHANG");
            if (ckb.Checked==true)
            {
                tbgiohang.Rows.RemoveAt(i);
            }
        }
        Session["tbGiohang"] = tbgiohang;
        this.gridGIOHANG.DataSource = tbgiohang;
        this.gridGIOHANG.DataBind();
    }

    protected void gridGIOHANG_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.gridGIOHANG.PageIndex = e.NewPageIndex;
        this.gridGIOHANG.DataSource = (DataTable)Session["tbGiohang"];
        this.gridGIOHANG.DataBind();

    }
}