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
    public partial class CreateOrderPage : System.Web.UI.Page
    {
        string transfa = "";
        string search = "";



        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Home_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrdersPage.aspx");
        }

        protected void btn_Clear_Cart_Click(object sender, EventArgs e)
        {
            lst_selected.Items.Clear();
        }

        protected void btn_DisplayAll_Click(object sender, EventArgs e)
        {
            Re_Load();
        }

        protected void btn_checkout_Click(object sender, EventArgs e)
        {
            int noRows=0;

            if(lst_selected.Items.Count == 0)
            {
                MsgPrompt("Sorry, your cart is empty");
            }
            else
            {
                for (int j = 0; j < lst_storage.Items.Count; j++)
                {
                    noRows++;
                    transfa = transfa + lst_storage.Items[j];
                }

                Session["NumOfRows"] = noRows;
                Session["CheckOutList"] = transfa;

                Response.Redirect("CheckoutPage.aspx");
            }
        }

        protected void btn_Search_Click(object sender, EventArgs e)
        {
            string input = txt_search.Text;

            try
            {
                string str_connection = "Data Source = localhost; Initial Catalog = FruitAndVeg; Trusted_Connection = True; Integrated Security = True";
                string MySelect = "SELECT [ProductID], [ProductName], [QuantityPerUnit], [UnitPrice] FROM[FruitAndVeg].[dbo].Products WHERE CHARINDEX('" + input + "',ProductName)> 0 AND [InStock] = 'Y'";
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

        protected void Grd_merch_view_PageIndexChanging(object sender, GridViewPageEventArgs e) // Changing the pages in the Customer GridView
        {
            Grd_merch_view.PageIndex = e.NewPageIndex;
            Re_Load();
        }

        protected void Grd_merch_view_SelectedIndexChanged(object sender, EventArgs e)
        {
            string search = "";

            for (int i = 0; i < lst_selected.Items.Count; i++)
            {
                search = search + lst_selected.Items[i];
            }

            bool index = search.Contains(Grd_merch_view.SelectedRow.Cells[2].Text);

            if (index == false)
            {
                search = search + Grd_merch_view.SelectedRow.Cells[2].Text + "";

                lst_selected.Items.Add(Grd_merch_view.SelectedRow.Cells[2].Text + ":");

                lst_storage.Items.Add(Grd_merch_view.SelectedRow.Cells[1].Text + ";");
            }
            else
            {
                MsgPrompt("Sorry, this item is already in your Cart.");
            }

        }


        private void Re_Load()
        {
            try
            {
                string str_connection = "Data Source = localhost; Initial Catalog = FruitAndVeg; Trusted_Connection = True; Integrated Security = True";
                string MySelect = "SELECT [ProductID], [ProductName], [QuantityPerUnit], [UnitPrice] FROM[FruitAndVeg].[dbo].Products WHERE [InStock] = 'Y'";
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