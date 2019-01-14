using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace HR_project
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //private void DBConnect()
        //{
        //    //  if the connection is already open, do nothing.

        //    if (connection != null && connection.State == System.Data.ConnectionState.Open)
        //        return;

        //    string MyConString = "SERVER=localhost;" +
        //        "DATABASE=student_attendance_system;" +
        //        "UID=root;" +
        //        "PASSWORD=1331990;";
        //    connection = new MySqlConnection(MyConString);
        //    connection.Open();
        //}

        //private void DBDisConnect()
        //{
        //    if (connection.State == System.Data.ConnectionState.Open)
        //    {
        //        connection.Close();
        //    }
        //}
    }
}
