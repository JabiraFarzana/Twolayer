using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Twolayer
{
    public partial class Userprofile : System.Web.UI.Page
    {
        ConnectionCls objcls = new ConnectionCls();
        protected void Page_Load(object sender, EventArgs e)
        {
            
                string str = "select Name,Age,Address,Photo from Twolayer where Id=" + Session["id"] + "";
                SqlDataReader dr = objcls.Fn_Reader(str);
                while (dr.Read())
                {
                    TextBox1.Text = dr["Name"].ToString();
                    TextBox2.Text = dr["Age"].ToString();
                    TextBox3.Text = dr["Address"].ToString();
                    Image1.ImageUrl = dr["Photo"].ToString();
                }
            DataSet ds = objcls.Fn_DataSet(str);
            GridView1.DataSource = ds;
            GridView1.DataBind();

            DataTable dt = objcls.Fn_DataTable(str);
            DataList1.DataSource = dt;
            DataList1.DataBind();
            
        }
    }
}