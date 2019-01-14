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
    public partial class applicants : System.Web.UI.Page
    {
        MySql.Data.MySqlClient.MySqlConnection conn;
        string data;
        string constr = ConfigurationManager.ConnectionStrings["Webappconnstring"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FirstGridViewRow();
            }
        }




        private void FirstGridViewRow()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("Col1", typeof(string)));
            dt.Columns.Add(new DataColumn("Col2", typeof(string)));
            dt.Columns.Add(new DataColumn("Col3", typeof(string)));
            dt.Columns.Add(new DataColumn("Col4", typeof(string)));
            dr = dt.NewRow();
            dr["RowNumber"] = 1;
            dr["Col1"] = string.Empty;
            dr["Col2"] = 0;
            dr["Col3"] = string.Empty;
            dr["Col4"] = string.Empty;
            dt.Rows.Add(dr);

            ViewState["CurrentTable"] = dt;

            grdincreasesalary.DataSource = dt;
            grdincreasesalary.DataBind();
        }



        private DataSet GetData(string query)
        {
            MySql.Data.MySqlClient.MySqlCommand cmd;
            conn = new MySql.Data.MySqlClient.MySqlConnection(constr);

            conn.Open();
            cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
            MySqlDataAdapter da = new MySqlDataAdapter();
            //da.SelectCommand = cmd;
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
            //reader = cmd.ExecuteReader();
            //using (SqlConnection con = new SqlConnection(conString))
            //{
            //    using (SqlDataAdapter sda = new SqlDataAdapter())
            //    {
            //        cmd.Connection = con;
            //        sda.SelectCommand = cmd;
            //        using (DataSet ds = new DataSet())
            //        {
            //            sda.Fill(ds);
            //            return ds;
            //        }
            //    }
            //}
        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Find the DropDownList in the Row
                DropDownList ddlCountries = (e.Row.FindControl("DropDownList1") as DropDownList);
                ddlCountries.DataSource = GetData("select EmployeeID,Name from hr.hire_emp");
                ddlCountries.DataTextField = "Name";
                ddlCountries.DataValueField = "EmployeeID";
                ddlCountries.DataBind();

                //Add Default Item in the DropDownList
                ddlCountries.Items.Insert(0, new ListItem("Please select"));

                //Select the Country of Customer in DropDownList
                //string country = (e.Row.FindControl("DropDownList1") as Label).Text;
                //ddlCountries.Items.FindByValue(country).Selected = true;
            }
        }


        private void AddNewRow()
        {
            int rowIndex = 0;

            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        DropDownList drpname = 
                            (DropDownList)grdincreasesalary.Rows[rowIndex].Cells[1].FindControl("DropDownList1");
                        TextBox TextBoxAmount =
                          (TextBox)grdincreasesalary.Rows[rowIndex].Cells[2].FindControl("txtamount");
                        TextBox TextBoxReason =
                          (TextBox)grdincreasesalary.Rows[rowIndex].Cells[3].FindControl("txtreason");
                        TextBox TextBoxDate =
                          (TextBox)grdincreasesalary.Rows[rowIndex].Cells[4].FindControl("txtdate");
                       
                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["RowNumber"] = i + 1;
                        
                        dtCurrentTable.Rows[i - 1]["Col1"] = drpname.Text;    
                        dtCurrentTable.Rows[i - 1]["Col2"] = TextBoxAmount.Text;
                        dtCurrentTable.Rows[i - 1]["Col3"] = TextBoxReason.Text;
                        dtCurrentTable.Rows[i - 1]["Col4"] = TextBoxDate.Text;
                        rowIndex++;
                    }
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;

                    grdincreasesalary.DataSource = dtCurrentTable;
                    grdincreasesalary.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }
            SetPreviousData();
        }

        private void SetPreviousData()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DropDownList drpname = (DropDownList)grdincreasesalary.Rows[rowIndex].Cells[1].FindControl("DropDownList1");
                        TextBox TextBoxAmount =
                          (TextBox)grdincreasesalary.Rows[rowIndex].Cells[2].FindControl("txtamount");
                        TextBox TextBoxReason =
                          (TextBox)grdincreasesalary.Rows[rowIndex].Cells[3].FindControl("txtreason");
                        TextBox TextBoxDate =
                          (TextBox)grdincreasesalary.Rows[rowIndex].Cells[4].FindControl("txtdate");
                       
                        drpname.Text = dt.Rows[i]["Col1"].ToString();
                        TextBoxAmount.Text=dt.Rows[i]["Col2"].ToString();
                        TextBoxReason.Text = dt.Rows[i]["Col3"].ToString();
                        TextBoxDate.Text = dt.Rows[i]["Col4"].ToString();
                        
                        rowIndex++;
                    }
                }
            }
        }

        // for deleting row

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            AddNewRow();
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            saveData();
        }


        //Save Data into database
        private void saveData() {

            MySql.Data.MySqlClient.MySqlCommand cmd;
            if (grdincreasesalary.Rows.Count != 0)
            {
                for (int i = 0; i < grdincreasesalary.Rows.Count; i++) {

                    DropDownList drpname = (DropDownList)grdincreasesalary.Rows[i].Cells[1].FindControl("DropDownList1");
                    TextBox TextBoxAmount =
                      (TextBox)grdincreasesalary.Rows[i].Cells[2].FindControl("txtamount");
                    TextBox TextBoxReason =
                      (TextBox)grdincreasesalary.Rows[i].Cells[3].FindControl("txtreason");
                    TextBox TextBoxDate =
                      (TextBox)grdincreasesalary.Rows[i].Cells[4].FindControl("txtdate");
                    
                    conn = new MySql.Data.MySqlClient.MySqlConnection(constr);
                    conn.Open();
                    
                    data = "insert into hr.sal_increase (emp_id,emp_name,sal_increase, reason,date) values ('"
                        +drpname.SelectedItem.Value+"','"+ drpname.SelectedItem.Text+"','"+TextBoxAmount.Text+"','"
                        +TextBoxReason.Text+"','"+TextBoxDate.Text+"')";
                    cmd = new MySql.Data.MySqlClient.MySqlCommand(data, conn);

                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            else {
                Response.Write("No Data");
            }
        }

        
        
        protected void grdincreasesalary_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SetRowData();
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                int rowIndex = Convert.ToInt32(e.RowIndex);
                if (dt.Rows.Count > 1)
                {
                    dt.Rows.Remove(dt.Rows[rowIndex]);
                    drCurrentRow = dt.NewRow();
                    ViewState["CurrentTable"] = dt;
                    grdincreasesalary.DataSource = dt;
                    grdincreasesalary.DataBind();

                    for (int i = 0; i < grdincreasesalary.Rows.Count - 1; i++)
                    {
                        grdincreasesalary.Rows[i].Cells[0].Text = Convert.ToString(i + 1);
                    }
                    SetPreviousData();
                }
            }
        }
        // set rowd data
        private void SetRowData()
        {
            int rowIndex = 0;

            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        DropDownList TextBoxName = (DropDownList)grdincreasesalary.Rows[rowIndex].Cells[1].FindControl("DropDownList1");
                        TextBox TextBoxAmount = (TextBox)grdincreasesalary.Rows[rowIndex].Cells[2].FindControl("txtamount");
                        TextBox TextBoxReason = (TextBox)grdincreasesalary.Rows[rowIndex].Cells[3].FindControl("txtreason");
                        TextBox TextBoxDate = (TextBox)grdincreasesalary.Rows[rowIndex].Cells[4].FindControl("txtdate");
                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["RowNumber"] = i + 1;
                        //drCurrentRow["Col1"] = TextBoxName.SelectedValue;
                        dtCurrentTable.Rows[i - 1]["Col1"] = TextBoxName.Text;
                        dtCurrentTable.Rows[i - 1]["Col2"] = TextBoxAmount.Text;
                        dtCurrentTable.Rows[i - 1]["Col3"] = TextBoxReason.Text;
                        dtCurrentTable.Rows[i - 1]["Col4"] = TextBoxDate.Text;
                        rowIndex++;
                    }

                    ViewState["CurrentTable"] = dtCurrentTable;
                    //grvStudentDetails.DataSource = dtCurrentTable;
                    //grvStudentDetails.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }
            //SetPreviousData();
        }

        

        
    }


}