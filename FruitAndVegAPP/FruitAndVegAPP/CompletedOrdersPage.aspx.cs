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
    public partial class CompletedOrdersPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)// Displays the Data from th Database
        {
            try
            {
                string str_connection = "Data Source = localhost; Initial Catalog = FruitAndVeg; Trusted_Connection = True; Integrated Security = True";
                string MySelect = "SELECT Orders.OrderID, Customer.FirstName, Customer.LastName, Orders.Order_Date, Orders.Delivary_Date, Orders.Total_Cost, Orders.Order_Status FROM Orders INNER JOIN Customer ON Orders.CustomerID = Customer.CustomerID WHERE Orders.Order_Status = 'Completed' ";
                SqlConnection con = new SqlConnection(str_connection);
                SqlDataAdapter ada = new SqlDataAdapter(MySelect, con);
                DataSet ds = new DataSet();
                ada.Fill(ds);
                grd_OrderView.DataSource = ds.Tables[0];
                grd_OrderView.DataBind();
            }
            catch (Exception ex)
            {
                MsgPrompt("something went wrong here   " + ex);
            }

        }

        protected void grd_OrderView_SelectedIndexChanged(object sender, EventArgs e)//When an Order is Selected it displays the OrderDetails.
        {
            string str_connection = "Data Source = localhost; Initial Catalog = FruitAndVeg; Trusted_Connection = True; Integrated Security = True";
            string MySelect = "SELECT  Products.ProductName, Products.QuantityPerUnit, Order_Details.Quantity " +
                "FROM Order_Details " +
                "INNER JOIN Orders ON Orders.OrderID = Order_Details.OrderID " +
                "INNER JOIN Products ON Products.ProductID = Order_Details.ProductID " +
                "WHERE Orders.OrderID = " + grd_OrderView.SelectedRow.Cells[1].Text + ";";
            SqlConnection con = new SqlConnection(str_connection);
            SqlDataAdapter ada = new SqlDataAdapter(MySelect, con);
            DataSet ds = new DataSet();
            ada.Fill(ds);
            grd_orderDetails.DataSource = ds.Tables[0];
            grd_orderDetails.DataBind();

        }

        protected void btn_Home_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrdersPage.aspx");
        }

        protected void grd_OrderView_PageIndexChanging(object sender, GridViewPageEventArgs e) // Changing the pages in the Customer GridView
        {
            grd_OrderView.PageIndex = e.NewPageIndex;
            Re_Load();
        }

        protected void btn_datesSearch_Click(object sender, EventArgs e)// user can Search for Order Dates.
        {
            string input1 = txt_date1.Text;
            string input2 = txt_date2.Text;

            try
            {
                string str_connection = "Data Source = localhost; Initial Catalog = FruitAndVeg; Trusted_Connection = True; Integrated Security = True";
                string MySelect = "SELECT Orders.OrderID, Customer.FirstName, Customer.LastName, convert(varchar(10),[Order_Date],103) as 'Order_Date', convert(varchar(10),[Delivary_Date],103) as 'Delivary_Date', Orders.Total_Cost, Orders.Order_Status " +
                                  "FROM[FruitAndVeg].[dbo].Orders " +
                                  "INNER JOIN Customer ON Orders.CustomerID = Customer.CustomerID " +
                                  "WHERE Order_Status = 'Completed'" +
                                  "AND Order_Date BETWEEN convert(DATE,'" + input1 + "',103) AND convert(DATE,'" + input2 + "',103)";

                SqlConnection con = new SqlConnection(str_connection);
                SqlDataAdapter ada = new SqlDataAdapter(MySelect, con);
                DataSet ds = new DataSet();
                ada.Fill(ds);
                grd_OrderView.DataSource = ds.Tables[0];
                grd_OrderView.DataBind();

            }
            catch (Exception ex)
            {
                MsgPrompt("There was a problem with accessing the database" + ex);
            }
        }



        public void Re_Load()
        {
            string str_connection = "Data Source = localhost; Initial Catalog = FruitAndVeg; Trusted_Connection = True; Integrated Security = True";
            string MySelect = "SELECT Orders.OrderID, Customer.FirstName, Customer.LastName, Orders.Order_Date, Orders.Delivary_Date, Orders.Total_Cost, Orders.Order_Status FROM Orders INNER JOIN Customer ON Orders.CustomerID = Customer.CustomerID WHERE Orders.Order_Status = 'Completed' ";
            SqlConnection con = new SqlConnection(str_connection);
            SqlDataAdapter ada = new SqlDataAdapter(MySelect, con);
            DataSet ds = new DataSet();
            ada.Fill(ds);
            grd_OrderView.DataSource = ds.Tables[0];
            grd_OrderView.DataBind();
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