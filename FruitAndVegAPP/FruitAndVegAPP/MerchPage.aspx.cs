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
    public partial class MerchPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Grd_merch_view_PageIndexChanging(object sender, GridViewPageEventArgs e) // Changing the pages in the Customer GridView
        {
            Grd_merch_view.PageIndex = e.NewPageIndex;
            Re_Load();
        }

        protected void btn_DisplayAll_Click(object sender, EventArgs e)
        {
            Re_Load();
        }


        protected void Grd_merch_view_SelectedIndexChanged(object sender, EventArgs e)//When you select a Product it takes you to the Product Modify Page
        {
            string transfa = "";

            for (int i = 0; i < 5; i++)
            {
                transfa = transfa + Grd_merch_view.SelectedRow.Cells[i].Text + ";";
            }

            Session["mochList"] = transfa;

            Response.Redirect("ModifyMerch.aspx");
        }

        protected void btn_CreateMerch_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateMerchPage.aspx");
        }



        private void Re_Load()// Loads the data from the database to the GridView.
        {
            try
            {
                string str_connection = "Data Source = localhost; Initial Catalog = FruitAndVeg; Trusted_Connection = True; Integrated Security = True";
                string MySelect = "SELECT [ProductID], [ProductName], [QuantityPerUnit], [UnitPrice], [InStock] FROM[FruitAndVeg].[dbo].Products ";
                SqlConnection con = new SqlConnection(str_connection);
                SqlDataAdapter ada = new SqlDataAdapter(MySelect, con);
                DataSet ds = new DataSet();
                ada.Fill(ds);
                Grd_merch_view.DataSource = ds.Tables[0];
                Grd_merch_view.DataBind();
            }
            catch (Exception ex)
            {
                MsgPrompt("There was a problem with accessing the database" + ex);

            }
        }


        protected void btn_Home_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrdersPage.aspx");
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

        protected void btn_Search_Click(object sender, EventArgs e)//Allows the use to search for Products by name.
        {
            string input = txt_search.Text;

            try
            {
                string str_connection = "Data Source = localhost; Initial Catalog = FruitAndVeg; Trusted_Connection = True; Integrated Security = True";
                string MySelect = "SELECT [ProductID], [ProductName], [QuantityPerUnit], [UnitPrice], [InStock] FROM[FruitAndVeg].[dbo].Products WHERE CHARINDEX('" + input + "',ProductName)> 0; ";
                SqlConnection con = new SqlConnection(str_connection);
                SqlDataAdapter ada = new SqlDataAdapter(MySelect, con);
                DataSet ds = new DataSet();
                ada.Fill(ds);
                Grd_merch_view.DataSource = ds.Tables[0];
                Grd_merch_view.DataBind();


            }
            catch (Exception ex)
            {
                MsgPrompt("There was a problem with accessing the database" + ex);
            }

        }

        protected void btn_CreateCustomer_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateCustomerPage.aspx");
        }
    }
}