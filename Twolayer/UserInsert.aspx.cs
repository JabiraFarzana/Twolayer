﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Twolayer
{
    public partial class UserInsert : System.Web.UI.Page
    {
        ConnectionCls conobj = new ConnectionCls();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string p = "~/PHS/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(p));
            string strinsert = "insert into Twolayer values('" + TextBox1.Text + "'," + TextBox2.Text + ",'" + TextBox3.Text + "','" + p + "','" + TextBox4.Text + "','" + TextBox5.Text + "')";
            int i = conobj.Fn_Nonquery(strinsert);
            if(i==1)
            {
                Label1.Text = "Inserted";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
        }
    }
}