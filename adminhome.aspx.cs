using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace final_alpha
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] != null)
            {
                Label1.Text += Session["admin"].ToString();
            }
            else
            {
                Response.Redirect("adminlogin.aspx");
            }
        }

        protected void setquestion_Click(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("addquestion.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("student_info.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("marks.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["admin"] = null;
            Response.Redirect("mainhome.aspx");
        }
    }
}