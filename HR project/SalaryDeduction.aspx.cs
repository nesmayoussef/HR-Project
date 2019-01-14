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

namespace HR_project
{
    public partial class SalaryDeduction : System.Web.UI.Page
    {

        MySql.Data.MySqlClient.MySqlConnection conn;
        MySql.Data.MySqlClient.MySqlCommand cmd;
        MySql.Data.MySqlClient.MySqlDataReader reader;
        string data;
        string name;
        string constr = ConfigurationManager.ConnectionStrings["Webappconnstring"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Visible = false;
            if (!IsPostBack)
            {
                this.employee();
            }
        }



        private void employee()
        {

            conn = new MySql.Data.MySqlClient.MySqlConnection(constr);
            conn.Open();


            data = "select EmployeeID,Name from hr.hire_emp";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(data, conn);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ListItem item = new ListItem();
                item.Text = reader["Name"].ToString();
                item.Value = reader["EmployeeID"].ToString();
                DropDownList1.Items.Add(item);
            }
            

            conn.Close();
        }

        //protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        //{
        //    TextBox1.Text = Convert.ToString(Calendar1.SelectedDate);
        //}
        private double getData() {
            conn = new MySql.Data.MySqlClient.MySqlConnection(constr);
            conn.Open();
            data = "select Salary from hr.hire_emp where EmployeeID = '" + Convert.ToInt32(DropDownList1.SelectedValue) + "'";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(data, conn);
            reader =  cmd.ExecuteReader();
            reader.Read();
            double salary = reader.GetDouble(0);
            conn.Close();
            return salary;
        }

        private void updatehireEmployee(double newsal) {
            conn = new MySql.Data.MySqlClient.MySqlConnection(constr);
            conn.Open();
            data = "update hr.hire_emp set Salary = '" + newsal + "' where EmployeeID = '" + Convert.ToInt32(DropDownList1.SelectedValue) + "'";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(data, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
           
        }

        private void inserthistory(double sal,double salded) {
            conn = new MySql.Data.MySqlClient.MySqlConnection(constr);
            
                conn.Open();
                data = "insert into hr.emp_history (emp_id,Salary,Sal_deduct,Month) values ('" + Convert.ToInt32(DropDownList1.SelectedValue) + "','"
                    + sal + "','" + salded + "','" + TextBox1.Text + "')";
                cmd = new MySql.Data.MySqlClient.MySqlCommand(data, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            
            
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            conn = new MySql.Data.MySqlClient.MySqlConnection(constr);
            try
            {
                
                //DateTime t = new DateTime();
                //t = Convert.ToDateTime(TextBox1.Text);
                //string mon = t.ToString("MM");

                double salary = getData();
                
                if (RadioButtonList1.SelectedValue.Equals("Medical Insurance"))
                {
                    double am = 200.0;
                    inserthistory(salary, am);
                    salary -= am;
                    updatehireEmployee(salary);
                    conn.Open();
                    data = "insert into sal_deduct values ('"
                        + Convert.ToInt32(DropDownList1.SelectedValue) + "','" + am + "','" + TextBox1.Text + "','" + RadioButtonList1.SelectedValue + "')";
                    cmd = new MySql.Data.MySqlClient.MySqlCommand(data, conn);
                    cmd.ExecuteNonQuery();
                   
                    // Label2.Text = am.ToString();
                }
                else
                {
                    double sal = 300.0;
                    inserthistory(salary, sal);
                    salary -= sal;
                    updatehireEmployee(salary);
                    // Label2.Text = sal.ToString();
                    conn.Open();
                    data = "insert into sal_deduct values ('"
                        + Convert.ToInt32(DropDownList1.SelectedValue) + "','" + sal + "','" + TextBox1.Text + "','" + RadioButtonList1.SelectedValue + "')";
                    cmd = new MySql.Data.MySqlClient.MySqlCommand(data, conn);
                    cmd.ExecuteNonQuery();
                    
                    //Label2.Text = "";
                }
                Label1.Visible = true;
                Label1.Text = "A salary deduction has been imposed";
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                if (ex.Message.ToString().Contains("Duplicate"))
                {
                    Label3.Visible = true;
                    Label3.Text = "Date/Type is already exist.";
                }
                

            }
            finally
            {
                conn.Close();
               
            }
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {

            int i = RadioButtonList1.SelectedIndex;
            //Label2.Text = i.ToString();
            if (i == 0)
            {
                double am = 200.0;
                Label2.Text = am.ToString();
                Label1.Text = "";
            }
            if (i == 1)
            {
                double sal = 300.0;
                Label2.Text = sal.ToString();
                Label1.Text = "";
            }
        }

        //protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //if (RadioButtonList1.SelectedValue.Equals("Medical Insurance"))
        //    //{
        //    //    double am = 200.0;
        //    //    Label2.Text = am.ToString();
        //    //}
        //    //else {
        //    //    double sal = 300.0;
        //       Label2.Text = "300";
        //    //}
        //}
    }
}