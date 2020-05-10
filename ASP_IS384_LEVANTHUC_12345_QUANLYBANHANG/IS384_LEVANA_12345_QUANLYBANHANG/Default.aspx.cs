using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    MODEL model;
    DataTable tb_TreParent;
    protected void Page_Load(object sender, EventArgs e)
    {
        model = new MODEL();
        string sql = "Select * from TreeFamily";
        DataTable dt = new DataTable();
        dt.DefaultView.RowFilter = "IDPARENT=0";
        DataTable tb_table = dt.DefaultView.ToTable();
        
        foreach (DataRow row in tb_table.Rows)
        {
            TreeNode tn = new TreeNode(row["HOTEN"].ToString());
            tn.Target = row["Id"].ToString();
            this.TreeView1.Nodes.Add(tn);

        }
    }
    public void DequyTrefamily(TreeNode TN)
    {

    }
}