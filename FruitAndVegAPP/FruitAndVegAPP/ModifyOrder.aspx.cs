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
    public partial class ModifyOrder : System.Web.UI.Page
    {
        bool pagelodetrigger = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                postinback();
            }


        }

        public void postinback()
        {
            lbl_Name.Text = Session["Names"].ToString();
            string ordID = Session["OrdID"].ToString();

            string str_connection = "Data Source = localhost; Initial Catalog = FruitAndVeg; Trusted_Connection = True; Integrated Security = True";
            string MySelect = "SELECT  Products.ProductID, Products.ProductName FROM Order_Details INNER JOIN Orders ON Orders.OrderID = Order_Details.OrderID INNER JOIN Products ON Products.ProductID = Order_Details.ProductID WHERE Orders.OrderID = " + ordID + ";";
            SqlConnection con = new SqlConnection(str_connection);
            SqlDataAdapter ada = new SqlDataAdapter(MySelect, con);
            DataSet ds = new DataSet();
            ada.Fill(ds);
            grd_storage.DataSource = ds.Tables[0];
            grd_storage.DataBind();

            lst_selected.Items.Clear();
            lst_storage.Items.Clear();

            try
            {
                if (pagelodetrigger)
                {
                    for (int k = 0; k < 50; k++)
                    {
                        lst_selected.Items.Add(grd_storage.Rows[k].Cells[1].Text + ":");

                        lst_storage.Items.Add(grd_storage.Rows[k].Cells[0].Text + ";");
                    }
                    pagelodetrigger = false;

                }


            }
            catch
            {

            }


        }

        protected void btn_Home_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrdersPage.aspx");
        }


        protected void btn_DisplayAll_Click(object sender, EventArgs e)
        {
            Re_Load();
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            int noRows = 0;
            string transfa = "";

            if (lst_selected.Items.Count == 0)
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

                Session["OrderID2"] = Session["OrdID"].ToString();
                Session["Names2"] = Session["Names"].ToString();

                Response.Redirect("ModifiedCheckoutPage.aspx");
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