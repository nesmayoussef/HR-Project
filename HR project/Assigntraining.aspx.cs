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
    public partial class Assigntraining : System.Web.UI.Page
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
                this.employee();
                this.training();
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
        private void training()
        {

            conn = new MySql.Data.MySqlClient.MySqlConnection(constr);
            conn.Open();


            data = "select training_id,training_name from hr.training";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(data, conn);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ListItem item = new ListItem();
                item.Text = reader["training_name"].ToString();
                item.Value = reader["training_id"].ToString();
                DropDownList2.Items.Add(item);
            }

            conn.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            conn = new MySql.Data.MySqlClient.MySqlConnection(constr);
            conn.Open();
            data = "insert into emp_training values ('"+ DropDownList1.SelectedValue+"','" +DropDownList2.SelectedValue+"')";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(data, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

    }
}