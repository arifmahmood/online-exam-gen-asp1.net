﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace final_alpha
{
    public partial class marks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] != null)
            {
                
            }
            else
            {
                Response.Redirect("adminlogin.aspx");
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Session["admin"] = null;
            Response.Redirect("adminlogin.aspx");

        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminhome.aspx");
        }
    }
}