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
    public partial class Login : System.Web.UI.Page
    {
        ConnectionCls objcls = new ConnectionCls();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sel = "select count(id) from Twolayer where Username='" + TextBox1.Text + "'and Password='" + TextBox2.Text + "'";
            string cid = objcls.Fn_Scalar(sel);
            if (cid == "1")
            {
                int id1 = 0;
                string str = "select Id from Twolayer where Username='" + TextBox1.Text + "'and Password='" + TextBox2.Text + "'";
                SqlDataReader dr = objcls.Fn_Reader(str);
                while (dr.Read())
                {
                    id1 = Convert.ToInt32(dr["id"].ToString());
                }
                Session["id"] = id1;
                Response.Redirect("Userprofile.aspx");

                //string selid = "select id from Twolayer where Username='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "'";
                //string Id = objcls.Fn_Scalar(selid);
                //Session["Id"] = Id;
                //Response.Redirect("Userprofile.aspx");
            }
            else
            { 
                Label1.Text = "Invalid Username or Password";
            }
        }
    }
}