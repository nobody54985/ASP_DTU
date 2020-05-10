using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DANHSACHMATHANG : System.Web.UI.Page
{
    MODEL model;
    protected void Page_Load(object sender, EventArgs e)
    {

        model = new MODEL(Server.MapPath("~\\App_Data\\dbQUANLYBANHANG.mdf"));
        String MADM = Request.QueryString.Get("MADM");
        String SQL =null;
        if(MADM==null)
        {
             SQL = "Select top(3) * from tbMATHANG ";
        }
        else SQL = "Select * from tbMATHANG where MADM="+MADM;
        this.DataList1.DataSource = model.getDataTable(SQL);
        this.DataList1.DataBind();
    }
}