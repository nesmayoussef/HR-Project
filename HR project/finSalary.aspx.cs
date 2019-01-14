using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;
using System.Collections;
using MySql.Data.MySqlClient;

namespace HR_project
{
    public partial class finSalary : System.Web.UI.Page
    {

        MySql.Data.MySqlClient.MySqlConnection conn;
        MySql.Data.MySqlClient.MySqlCommand cmd;
        MySql.Data.MySqlClient.MySqlDataReader reader;
        string data;
        string name;
        string constr = ConfigurationManager.ConnectionStrings["Webappconnstring"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetData();
            }

        
        }

        protected void delete(object sender, GridViewDeleteEventArgs e)
        {

            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            conn = new MySql.Data.MySqlClient.MySqlConnection(constr);
            conn.Open();
            data = "delete from sal_increase where eno = '" + id + "'";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(data, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            GetData();
        }


        private void GetData()
        {
            conn = new MySql.Data.MySqlClient.MySqlConnection(constr);
            conn.Open();
            data = "select eno,emp_id,emp_name,sal_increase, reason,date from hr.sal_increase";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(data, conn);
            //MySqlDataAdapter da = new MySqlDataAdapter();
            //da.SelectCommand = cmd;

            IDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            //da.Fill(dt);
            //if (dt.Rows.Count > 0)
            //{
            GridView1.DataSource = dt;
            GridView1.DataBind();
            //}
            conn.Close();
        }

        protected void Edit(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GetData();
        }

        protected void canceledit(object sender, GridViewCancelEditEventArgs e)
        {

            GridView1.EditIndex = -1;
            GetData();
        }
        protected void update(object sender, GridViewUpdateEventArgs e)
        {

            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            string name = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("salIncrease")).Text;

            int empid = Convert.ToInt32(((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtempid")).Text);
            conn = new MySql.Data.MySqlClient.MySqlConnection(constr);
            conn.Open();
            data = "select Salary from hr.hire_emp where EmployeeID = '" + empid + "'";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(data, conn);
            reader = cmd.ExecuteReader();
            reader.Read();
            double s = Convert.ToDouble(name);
            double sal = reader.GetDouble(0);
            //double x = Convert.ToDouble(sal);

            conn.Close();
            conn.Open();
            double sum = sal + s;
            data = "update hr.hire_emp set salary = '" + sum + "' where EmployeeID = '" + empid + "'";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(data, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            //TextBox1.Text = name;

            //conn = new MySql.Data.MySqlClient.MySqlConnection(constr);
            //conn.Open();


            //data = "update training set training_name = '" + name + "' ,start_date = '" + stdate + "' ,end_date = '" + enddate + "' ,train_time = '" + tr_time + "' where training_id = '" + id + "';";
            //cmd = new MySql.Data.MySqlClient.MySqlCommand(data, conn);
            //cmd.ExecuteNonQuery();

            //conn.Close();

           GridView1.EditIndex = -1;// no row in edit mode

            GetData();
        }


        private void savedata() {

            //MySql.Data.MySqlClient.MySqlCommand cmd;
            if (GridView1.Rows.Count != 0)
            {


                TextBox drpname1 = (TextBox)GridView1.SelectedRow.Cells[1].FindControl("txtempname");
                //TextBox drpname = (TextBox)GridView1.Rows[0].Cells[2].FindControl("txtempname");
                //    TextBox TextBoxAmount =
                //      (TextBox)GridView1.Rows[0].Cells[3].FindControl("salIncrease");
                //    TextBox TextBoxReason =
                //      (TextBox)GridView1.Rows[0].Cells[4].FindControl("txtreason");
                //    TextBox TextBoxDate =
                //      (TextBox)GridView1.Rows[0].Cells[5].FindControl("txtdate");
                    TextBox1.Text = " Date : " +drpname1.Text ;
                    //conn = new MySql.Data.MySqlClient.MySqlConnection(constr);
                    //conn.Open();

                    //data = "insert into hr.sal_increase (emp_id,emp_name,sal_increase, reason,date) values ('"
                    //    + drpname1.Text + "','" + drpname.Text + "','" + TextBoxAmount.Text + "','"
                    //    + TextBoxReason.Text + "','" + TextBoxDate.Text + "')";
                    //cmd = new MySql.Data.MySqlClient.MySqlCommand(data, conn);

                    //cmd.ExecuteNonQuery();
                    //conn.Close();
                
            }
            else
            {
                Response.Write("No Data");
            }
        }

        //protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    savedata();
        //}

        //protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //conn = new MySql.Data.MySqlClient.MySqlConnection(constr);
        //    //conn.Open();
        //    //GridViewRow row = ;
        //    string z = GridView1.SelectedRow.Cells[0].Text;
        //    TextBox1.Text = z;
        //}

        //protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e) {
        //    TextBox1.Text = "Hello";
        //    if (e.Row.RowType == DataControlRowType.DataRow) { 
        //        TextBox t = (TextBox)e.Row.Cells[1].FindControl("txtempid");
        //        TextBox1.Text= t.Text;
        //    }
        //}
        ////protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        ////{
        ////    //conn = new MySql.Data.MySqlClient.MySqlConnection(constr);
        ////    //conn.Open();
        ////    //GridViewRow row = ;
        ////   // string z = ((TextBox)GridView1.Rows[GridView1.SelectedIndex].Cells[3].FindControl("salIncrease")).Text;
        ////    TextBox1.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[0].Text;
            


        ////    //string y = row.Cells[3].Text;
        ////    //Label1.Text = "Hello " + z;
        ////    //string y = row.Cells[3].Text;
        ////    //int inc = Convert.ToInt32(y);
        ////    //int empid = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);
        ////    //data = "select salary from hr.hire_emp where EmployeeID = '" + empid + "'";
        ////    //cmd = new MySql.Data.MySqlClient.MySqlCommand(data, conn);
        ////    //reader = cmd.ExecuteReader();
        ////    //double sal = reader.GetFloat(0);

        ////    //conn.Close();
        ////    //conn.Open();
        ////    //double sum = sal + inc;
        ////    //data = "update hr.hire_emp set salary = '" + sum + "' where EmployeeID = '" + empid + "'";
        ////    //cmd = new MySql.Data.MySqlClient.MySqlCommand(data, conn);
        ////    //cmd.ExecuteNonQuery();
        ////    //conn.Close();

        ////}

    }
}