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
    public partial class test : System.Web.UI.Page
    {
        MySql.Data.MySqlClient.MySqlConnection conn;
        MySql.Data.MySqlClient.MySqlCommand cmd;
        MySql.Data.MySqlClient.MySqlDataReader reader;
        string data;
        string name;
        string constr = ConfigurationManager.ConnectionStrings["Webappconnstring"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                GetData();
            }

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

        protected void Update(object sender, GridViewUpdateEventArgs e)
        {

            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            string name = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtempname")).Text;
            string stdate = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtempcode")).Text;
            string enddate = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtempage")).Text;
            string tr_time = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtetpage")).Text;

            conn = new MySql.Data.MySqlClient.MySqlConnection(constr);
                conn.Open();


                data = "update training set training_name = '" + name + "' ,start_date = '" + stdate + "' ,end_date = '" + enddate + "' ,train_time = '" + tr_time + "' where training_id = '" + id + "';";
                cmd = new MySql.Data.MySqlClient.MySqlCommand(data, conn);
                cmd.ExecuteNonQuery();

            conn.Close();

            GridView1.EditIndex = -1;// no row in edit mode

            GetData();
        }


        protected void delete(object sender, GridViewDeleteEventArgs e)
        {

            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            conn = new MySql.Data.MySqlClient.MySqlConnection(constr);
            conn.Open();


            data = "delete from training where training_id = '" + id + "'";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(data, conn);
            cmd.ExecuteNonQuery();

            conn.Close();

            GetData();
        }


        private void GetData() {
            conn = new MySql.Data.MySqlClient.MySqlConnection(constr);
            conn.Open();
            data = "select * from hr.training";
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

        

        
    }
}