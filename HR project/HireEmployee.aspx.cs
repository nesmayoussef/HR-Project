using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace HR_project
{
    public partial class HireEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Calendar1.Visible = false;

            }
        }

        protected void TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Calendar1.Visible == false)
            {
                Calendar1.Visible = true;
            }
            else {
                Calendar1.Visible = false;
            }

        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            TextBox9.Text = Convert.ToString(Calendar1.SelectedDate);
        }

        

       


    }
}