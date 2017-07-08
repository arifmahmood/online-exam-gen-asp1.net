using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;



namespace final_alpha
{
    
    public partial class WebForm7 : System.Web.UI.Page
    {
        static int i = 1;
        int j;
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["databaseConnectionString"].ConnectionString);
            conn.Open();

            
            
            if (Session["student"] != null)
            {

            }
            else
            {
                i = 1;
                Response.Redirect("login.aspx");
            }
            string check = "select attain from students where username='" + Session["student"] + "'";
            SqlCommand att = new SqlCommand(check, conn);
            int at = Convert.ToInt32(att.ExecuteScalar().ToString());
            if (at == 1)
            {
                Response.Redirect("studenthome.aspx");
            }
            
            string getquestion = "select question from qbank where question_id=@id";
            string getquestion1 = "select count(*) from qbank";
            string geta = "select a from options where question_id=@ida";
            string getb = "select b from options where question_id=@idb";
            string getc = "select c from options where question_id=@idc";
            string getd = "select d from options where question_id=@idd";

            SqlCommand count = new SqlCommand(getquestion1, conn);
            SqlCommand get = new SqlCommand(getquestion, conn);
            SqlCommand geta1 = new SqlCommand(geta, conn);
            SqlCommand getb1 = new SqlCommand(getb, conn);
            SqlCommand getc1 = new SqlCommand(getc, conn);
            SqlCommand getd1 = new SqlCommand(getd, conn);

            j = Convert.ToInt32(count.ExecuteScalar().ToString());
            get.Parameters.AddWithValue("@id", i);
            geta1.Parameters.AddWithValue("@ida", i);
            getb1.Parameters.AddWithValue("@idb", i);
            getc1.Parameters.AddWithValue("@idc", i);
            getd1.Parameters.AddWithValue("@idd", i);

            if (i <= j)
            {
                string abc = get.ExecuteScalar().ToString();
                string aa = geta1.ExecuteScalar().ToString();
                string bb = getb1.ExecuteScalar().ToString();
                string cc = getc1.ExecuteScalar().ToString();
                string dd = getd1.ExecuteScalar().ToString();
                qbox.Text = abc;
                a.Text = aa;
                b.Text = bb;
                c.Text = cc;
                d.Text = dd;
                
                
            }
            //Response.Write(abc);
            Response.Write("bi:");
            Response.Write(i);
            
            Response.Write("ai:");
            Response.Write(i);
            conn.Close();


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Write("ac:");
            i += 1;
            Response.Write(i);

            if (i > j+1)
            {
                i = 1;
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["databaseConnectionString"].ConnectionString);
                conn.Open();

                string setattain = "update students set attain=1 where username='" + Session["student"] + "'";
                SqlCommand setat = new SqlCommand(setattain, conn);
                setat.ExecuteNonQuery();
                conn.Close();
                
                Response.Redirect("studenthome.aspx");
            }

        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked == true)
            {
                Response.Write("here:");
                Response.Write(i);
                if (i <= j)
                {
                    SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["databaseConnectionString"].ConnectionString);
                    conn1.Open();


                    string getid = "select student_id from students where username='" + Session["student"] + "'";
                    SqlCommand con = new SqlCommand(getid, conn1);
                    int id = Convert.ToInt32(con.ExecuteScalar().ToString());


                    SqlCommand com1 = new SqlCommand();
                    com1.CommandType = System.Data.CommandType.StoredProcedure;
                    com1.CommandText = "ANSWERADD";

                    SqlParameter p1 = new SqlParameter();
                    p1.ParameterName = "@sid";
                    p1.Value = id;


                    SqlParameter p2 = new SqlParameter();
                    p2.ParameterName = "@qid";
                    p2.Value = i;


                    SqlParameter p3 = new SqlParameter();
                    p3.ParameterName = "@ans";
                    p3.Value = "a";


                    SqlParameter p4 = new SqlParameter();
                    p4.ParameterName = "@ans_id";
                    string abc = "select count(*) from answers";
                    SqlCommand getansid = new SqlCommand(abc, conn1);
                    int ii = Convert.ToInt32(getansid.ExecuteScalar().ToString());
                    ii += 1;
                    p4.Value = ii;
                    
                    
                    string getcans = "select correct from options where question_id=" + i + "";
                    SqlCommand getca = new SqlCommand(getcans, conn1);
                    string ca = getca.ExecuteScalar().ToString();
                    SqlParameter p5 = new SqlParameter();
                    p5.ParameterName = "@cans";
                    p5.Value = ca;

                    

                    






                    com1.Parameters.Add(p1);
                    com1.Parameters.Add(p2);
                    com1.Parameters.Add(p3);
                    com1.Parameters.Add(p4);
                    com1.Parameters.Add(p5);
                    

                    com1.Connection = conn1;
                    com1.ExecuteNonQuery();
                    int marks = 0;
                    if (ca == "a")
                    {
                        marks = 5;
                    }
                    string updatemarks = "update answers set marks=" + marks + " where answer_id=" + ii + "";
                    SqlCommand udatem = new SqlCommand(updatemarks, conn1);
                    udatem.ExecuteNonQuery();

                    CheckBox1.Checked = false;
                    conn1.Close();
                    //Response.Write("ok");
                }
            }
        }

        protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox2.Checked == true)
            {
                CheckBox2.Checked = false;
                //Response.Write("ok");

            }
        }

        protected void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox3.Checked == true)
            {
                CheckBox3.Checked = false;
                //Response.Write("ok");

            }
        }

        protected void CheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox4.Checked == true)
            {
                CheckBox4.Checked = false;
                //Response.Write("ok");

            }
        }

       
        

        
    }
}