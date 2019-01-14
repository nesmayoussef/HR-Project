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
    public partial class WebForm1 : System.Web.UI.Page
    {
        MySql.Data.MySqlClient.MySqlConnection conn;
        MySql.Data.MySqlClient.MySqlCommand cmd;
        MySql.Data.MySqlClient.MySqlDataReader reader;
        string data;
        public string overtime="0";
        public string lateness="0";
        public string earlytime="0";
        public TimeSpan dt;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login_Click1(object sender, EventArgs e)
        {
            int userId = 0;
            string constr = ConfigurationManager.ConnectionStrings["Webappconnstring"].ConnectionString;
            conn = new MySql.Data.MySqlClient.MySqlConnection(constr);
            
            conn.Open();
            string user = TextBox1.Text.ToString();
            string pass = TextBox2.Text.ToString();
            
            data = "select * from employee where Username ='" + user + "'and Password='" + pass + "'";
            
            cmd = new MySql.Data.MySqlClient.MySqlCommand(data, conn);
            reader = cmd.ExecuteReader();

            
            while (reader.HasRows && reader.Read())
            {
                userId = Convert.ToInt32(reader.GetString(0));
            }
            if (reader.HasRows)
            {

                reader.Close();
                conn.Close();
                Label3.Visible = true;
            
                string date = DateTime.Now.ToString("HH:mm:ss");

                dt = TimeSpan.Parse(date);
                Label3.Text = "Arrival time: " + dt;
                
                DateTime t = Convert.ToDateTime("09:30:00");
                if (DateTime.Now > t)
                {
                    TimeSpan ts = DateTime.Now - t;
                    Label4.Text = "Lateness: "  + ts.Hours + " hours";
                    lateness = ts.Hours.ToString();
                }
                conn.Open();

                DateTime d = DateTime.Now;
                string insertData =
                    "insert into hr.attendanceemp(EmplID,Day,ArrivalTime,DepartureTime,Absence,Overtime,lateness,earlyleave) values ('"
                    + userId.ToString() + "','" + d.ToString("dd/MM/yyyy") + "','" + dt + "','" + DateTime.Now.ToString("HH:mm:ss") +
                    "',0,'" + overtime + "','" + lateness + "','" + earlytime + "')";

                cmd = new MySql.Data.MySqlClient.MySqlCommand(insertData, conn);
                cmd.ExecuteNonQuery();
                conn.Close();         
                int over = Convert.ToInt32(overtime);


                conn.Open();
                string salary = "select salary from hire_emp where EmployeeID = '"+userId+"';";
                cmd = new MySql.Data.MySqlClient.MySqlCommand(salary, conn);
                reader = cmd.ExecuteReader();
                reader.Read();
                //double l = Convert.ToDouble(2.5);
                string s = reader.GetString(0);
                conn.Close();         
                
                    conn.Open();
                    double sa = Convert.ToDouble(lateness) * 20;
                    double total = Convert.ToInt32(s) - sa;
                    
                    string inover =
                        "insert into hr.trackingemployee(EmpId,Salary,Month) values ('"
                        + userId+ "','" + total + "','" + d.ToString("MM") + "')";

                    cmd = new MySql.Data.MySqlClient.MySqlCommand(inover, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();         
                
            }
            else
            {
                Label3.Visible = true;
                Label3.Text = "Username and/or password is incorrect.";
                
            }

            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int userId = 0;
            string constr = ConfigurationManager.ConnectionStrings["Webappconnstring"].ConnectionString;
            conn = new MySql.Data.MySqlClient.MySqlConnection(constr);

            conn.Open();
            string user = TextBox1.Text.ToString();
            string pass = TextBox2.Text.ToString();

            data = "select * from employee where Username ='" + user + "'and Password='" + pass + "'";

            cmd = new MySql.Data.MySqlClient.MySqlCommand(data, conn);
            reader = cmd.ExecuteReader();

            reader.Read();
            userId = Convert.ToInt32(reader.GetString(0));
            if (reader.HasRows)
            {
                Label3.Visible = true;
               
                Label3.Text = "Departural time is " + DateTime.Now.ToString("HH:mm:ss");
                DateTime t = Convert.ToDateTime("17:00:00");
                if (DateTime.Now > t)
                {
                    Label4.Visible = true;
                    TimeSpan ts = DateTime.Now - t;
                    overtime = ts.Hours.ToString();
                    Label4.Text = "Overtime: " + overtime + " hours";
                   
                }
                else if (DateTime.Now < t)
                {
                    Label4.Visible = true;
                    TimeSpan ts = t - DateTime.Now;
                    earlytime = ts.Hours.ToString();
                    Label4.Text = "Early Leave: " + earlytime + " hours";
                    
                }
                else {
                    Label4.Visible = true;
                    Label4.Text = "";
                }
                reader.Close();
                conn.Close();
                conn.Open();

                string updates ="update hr.attendanceemp set DepartureTime ='"+DateTime.Now.ToString("HH:mm:ss") + "', Overtime = '" + overtime + "',earlyleave ='" + earlytime + "'where EmplID ='"+ userId.ToString() +"';";

                cmd = new MySql.Data.MySqlClient.MySqlCommand(updates, conn);
                cmd.ExecuteNonQuery();

                conn.Close();

                int over = Convert.ToInt32(overtime);
                int early = Convert.ToInt32(earlytime);


                conn.Open();
                string salary = "select salary from hire_emp where EmployeeID = '" + userId + "';";
                cmd = new MySql.Data.MySqlClient.MySqlCommand(salary, conn);
                reader = cmd.ExecuteReader();
                reader.Read();
                //over = 2;

                string s = reader.GetString(0);
                conn.Close();
                double sa = 0;
                double total = Convert.ToDouble(s);
                if (over > 0 && over <= 3)
                {
                    
                    sa = over * 200;
                    total = Convert.ToDouble(s) + sa;

                }
                if(early > 0){
                    sa = early * 30;
                    total = total - sa;
                }

                conn.Open();

                 DateTime d = DateTime.Now;
                string inovere =
                    "update trackingemployee set Salary = '" + total +
                        "'where EmpId ='" + userId + "' and Month ='"+d.ToString("MM")+"';";
                    

                cmd = new MySql.Data.MySqlClient.MySqlCommand(inovere, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

            }
            else
            {
                Label3.Visible = true;
                Label3.Text = "Username and/or password is incorrect.";
            }
        }
    }
}