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
    public partial class WebForm2 : System.Web.UI.Page
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
                this.Courses();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Calendar1.Visible == false)
            {
                Calendar1.Visible = true;
            }
            else
            {
                Calendar1.Visible = false;
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            TextBox9.Text = Convert.ToString(Calendar1.SelectedDate);
        }

        private void Courses()
        {
         
            conn = new MySql.Data.MySqlClient.MySqlConnection(constr);
            conn.Open();


            data = "select * from hr.courses";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(data, conn);
            reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            ListItem item = new ListItem();
                            item.Text = reader["CrsName"].ToString();
                            item.Value = reader["CrsID"].ToString();
                            Courselist.Items.Add(item);
                        }
                    
                    conn.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            conn = new MySql.Data.MySqlClient.MySqlConnection(constr);
            conn.Open();

           string id = "select max(EmployeeID) from hr.hire_emp";
           cmd = new MySql.Data.MySqlClient.MySqlCommand(id, conn);
           reader = cmd.ExecuteReader();
           reader.Read();
           int empid = Convert.ToInt32(reader.GetString(0));
           int newemp = empid + 1;
           
           conn.Close();

           conn.Open();


           string insertData = "insert into hr.hire_emp(EmployeeID,Name,JobTitle,JobGrade,Salary,JobDescription,Bonus,Housingallowance,Gender,Date,Phonenumber,Address,MaritalStatus) values ('" +newemp.ToString() +"','"+
                TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "','" + TextBox7.Text + "','" +
                Radio.SelectedValue + "','" + TextBox9.Text + "','" + TextBox12.Text + "','" + TextBox11.Text + "','" +
                DropDownList1.SelectedValue + "')";

           cmd = new MySql.Data.MySqlClient.MySqlCommand(insertData, conn);
           cmd.ExecuteNonQuery();

           conn.Close();
           conn.Open();
           ArrayList myarray = new ArrayList();
            


            for(int i=0; i<Courselist.Items.Count-1; i++) {
                if (Courselist.Items[i].Selected)
                    myarray.Add(Courselist.Items[i].Value);    
            }

            

            for (int i = 0; i < myarray.Count; i++) {
                string incourse = "insert into hr.emp_course values ('" + newemp.ToString() + "','" +myarray[i]+"')";
                cmd = new MySql.Data.MySqlClient.MySqlCommand(incourse, conn);
                cmd.ExecuteNonQuery();
            }

                conn.Close();
          
          


        }

       
    }
}