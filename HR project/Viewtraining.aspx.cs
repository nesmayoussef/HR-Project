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
    public partial class WebForm3 : System.Web.UI.Page
    {

        MySql.Data.MySqlClient.MySqlConnection conn;
        MySql.Data.MySqlClient.MySqlCommand cmd;
        MySql.Data.MySqlClient.MySqlDataReader reader;
        string data;
        string name;
        string constr = ConfigurationManager.ConnectionStrings["Webappconnstring"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.Visible = true; ;
            if (!IsPostBack)
            {
                this.employee();
                Bindata();

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

        private void Bindata() {
            conn = new MySql.Data.MySqlClient.MySqlConnection(constr);
            conn.Open();
            data = "select training_id from hr.emp_training where emp_id = '" + DropDownList1.SelectedValue + "'";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(data, conn);
            reader = cmd.ExecuteReader();
            ArrayList array = new ArrayList();
            // reader.Read();
            while (reader.Read())
            {
                array.Add(reader.GetInt32(0));
            }
            conn.Close();

            conn.Open();
            if (array.Count == 0) {
                GridView1.Visible = false;
            }
            DataTable dt = new DataTable();
            for (int i = 0; i < array.Count; i++)
            {
             
                data = "select training_name as Name, start_date as Start, end_date as End, train_time as Duration from hr.training where training_id = '" + array[i] + "'";
                cmd = new MySql.Data.MySqlClient.MySqlCommand(data, conn);
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
             
                da.Fill(dt);
               
            }
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else {
                GridView1.Visible = false;
            }

            conn.Close();    
        }

        protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            
            Bindata();
        }

    }
}