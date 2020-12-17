using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


namespace FruitAndVegAPP
{
    public partial class CustomerPage : System.Web.UI.Page
    {
        public static List<string> lst_check = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_CreateCustomer_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateCustomerPage.aspx");
        }

        protected void btn_Home_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrdersPage.aspx");
        }


        protected void btn_Search_Click(object sender, EventArgs e)
        {
            string input = txt_search.Text;

            try
            {
                if (input.Contains(" "))
                {
                    string[] inputs = input.Split(' ');

                    string str_connection = "Data Source = localhost; Initial Catalog = FruitAndVeg; Trusted_Connection = True; Integrated Security = True";
                    string MySelect = "SELECT [CustomerID], [FirstName], [LastName], [HomePhone],[MobilePhone], [StreetAddress], [Suburb], [Postcode], [DriversLicence], [Email], [CreditCard_type], [CreditCard_Number] FROM[FruitAndVeg].[dbo].Customer WHERE CHARINDEX('" + inputs[0] + "',FirstName)> 0 OR CHARINDEX('" + inputs[1] + "',LastName)> 0;";
                    SqlConnection con = new SqlConnection(str_connection);
                    SqlDataAdapter ada = new SqlDataAdapter(MySelect, con);
                    DataSet ds = new DataSet();
                    ada.Fill(ds);
                    Grd_CustomerView.DataSource = ds.Tables[0];
                    Grd_CustomerView.DataBind();
                }
                else
                {
                    string str_connection = "Data Source = localhost; Initial Catalog = FruitAndVeg; Trusted_Connection = True; Integrated Security = True";
                    string MySelect = "SELECT [CustomerID], [FirstName], [LastName], [HomePhone],[MobilePhone], [StreetAddress], [Suburb], [Postcode], [DriversLicence], [Email], [CreditCard_type], [CreditCard_Number] FROM[FruitAndVeg].[dbo].Customer WHERE CHARINDEX('" + input + "',FirstName)> 0 OR CHARINDEX('" + input + "',LastName)> 0;";
                    SqlConnection con = new SqlConnection(str_connection);
                    SqlDataAdapter ada = new SqlDataAdapter(MySelect, con);
                    DataSet ds = new DataSet();
                    ada.Fill(ds);
                    Grd_CustomerView.DataSource = ds.Tables[0];
                    Grd_CustomerView.DataBind();
                }


            }
            catch (Exception ex)
            {
                MsgPrompt("There was a problem with accessing the database" + ex);
            }



        }

        protected void btn_DisplayAll_Click(object sender, EventArgs e)
        {
            try
            {
                string str_connection = "Data Source = localhost; Initial Catalog = FruitAndVeg; Trusted_Connection = True; Integrated Security = True";
                string MySelect = "SELECT [CustomerID],[FirstName], [LastName], [HomePhone],[MobilePhone], [StreetAddress], [Suburb], [Postcode], [DriversLicence], [Email], [CreditCard_type], [CreditCard_Number] FROM[FruitAndVeg].[dbo].Customer ";
                SqlConnection con = new SqlConnection(str_connection);
                SqlDataAdapter ada = new SqlDataAdapter(MySelect, con);
                DataSet ds = new DataSet();
                ada.Fill(ds);
                Grd_CustomerView.DataSource = ds.Tables[0];
                Grd_CustomerView.DataBind();
            }
            catch (Exception ex)
            {
                MsgPrompt("There was a problem with accessing the database" + ex);

            }
        }

        public void Re_Load()
        {
            string str_connection = "Data Source = localhost; Initial Catalog = FruitAndVeg; Trusted_Connection = True; Integrated Security = True";
            string MySelect = "SELECT [CustomerID],[FirstName], [LastName], [HomePhone],[MobilePhone], [StreetAddress], [Suburb], [Postcode], [DriversLicence], [Email], [CreditCard_type], [CreditCard_Number] FROM[FruitAndVeg].[dbo].Customer ";
            SqlConnection con = new SqlConnection(str_connection);
            SqlDataAdapter ada = new SqlDataAdapter(MySelect, con);
            DataSet ds = new DataSet();
            ada.Fill(ds);
            Grd_CustomerView.DataSource = ds.Tables[0];
            Grd_CustomerView.DataBind();
        }

        protected void CustomerView_PageIndexChanging(object sender, GridViewPageEventArgs e) // Changing the pages in the Customer GridView
        {
            Grd_CustomerView.PageIndex = e.NewPageIndex;
            Re_Load();
        }

        protected void CustomerView_SelectedIndexChanged(object sender, EventArgs e)
        {
            string transfa = "";

            for (int i = 0; i < 12; i++)
            {
                transfa = transfa + Grd_CustomerView.SelectedRow.Cells[i].Text + ";";
            }

            Session["CustList"] = transfa;

            Response.Redirect("ModifyCustomersPage.aspx");

        }

        private void MsgPrompt(string msg)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type=\"text/javascript\">");
            sb.Append("window.onload=function() {");
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            sb.AppendFormat("alert({0});", serializer.Serialize(msg));
            sb.Append("};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(
                this.GetType(),
                "alert",
                sb.ToString(),
                false
            );
        }
    }
}