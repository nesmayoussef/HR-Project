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
    public partial class Penalty : System.Web.UI.Page
    {
        MySql.Data.MySqlClient.MySqlConnection conn;
        MySql.Data.MySqlClient.MySqlCommand cmd;
        MySql.Data.MySqlClient.MySqlDataReader reader;
        string data;
        string name;
        string constr = ConfigurationManager.ConnectionStrings["Webappconnstring"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel2.Visible = false;
            Label1.Visible = false;
            Label2.Visible = false;
           // Calendar1.Visible = false;
            if (Radio.SelectedValue == "Auto")
            {
                Panel2.Visible = false;
                Panel1.Visible = true;
                
            }
            else {
                Panel1.Visible = false;
                Panel2.Visible = true;
            }

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
                DropDownList2.Items.Add(item);
            }

            conn.Close();
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            TextBox1.Text = Convert.ToString(Calendar1.SelectedDate);
            TextBox5.Text = Convert.ToString(Calendar2.SelectedDate);
        }

       
        protected void Radio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Radio.SelectedValue == "Auto")
            {
                Panel2.Visible = false;
                Panel1.Visible = true;
            }
            else {
                Panel1.Visible = false;
                Panel2.Visible = true;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            conn = new MySql.Data.MySqlClient.MySqlConnection(constr);

            conn.Open();
            DateTime t = new DateTime();
            t = Convert.ToDateTime(TextBox1.Text);
            string mon = t.ToString("dd/MM/yyyy");

            data = "insert into penalty values ('"
                + Convert.ToInt32(DropDownList1.SelectedValue) + "','" + Convert.ToDouble(TextBox2.Text) +"','" + mon + "','" + RadioButtonList1.SelectedValue + "')";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(data, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            Label1.Visible = true;
            Label1.Text = "A penalty has been imposed";
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label1.Visible = false;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            conn = new MySql.Data.MySqlClient.MySqlConnection(constr);

            conn.Open();
            DateTime t = new DateTime();
            t = Convert.ToDateTime(TextBox5.Text);
            string mon = t.ToString("dd/MM/yyyy");

            data = "insert into penalty values ('"
                + Convert.ToInt32(DropDownList2.SelectedValue) + "','" + Convert.ToDouble(TextBox6.Text) + "','" + mon + "','" + TextBox4.Text + "')";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(data, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            Label2.Visible = true;
            Label2.Text = "A penalty has been imposed";
        }

        
    }
}