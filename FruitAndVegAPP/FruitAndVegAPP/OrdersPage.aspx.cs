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
    public partial class OrdersPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Re_Load();
        }

        protected void btn_complete_Click(object sender, EventArgs e)
        {
            Response.Redirect("CompletedOrdersPage.aspx");
        }

        protected void btn_Home_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void grd_OrderView_PageIndexChanging(object sender, GridViewPageEventArgs e) // Changing the pages in the Customer GridView
        {
            grd_OrderView.PageIndex = e.NewPageIndex;
            Re_Load();
        }

        protected void grd_OrderView_SelectedIndexChanged(object sender, EventArgs e)// When you select an order from the GridView it displays the Order Details
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

            txt_Name.Text = grd_OrderView.SelectedRow.Cells[2].Text + " " +grd_OrderView.SelectedRow.Cells[3].Text;
            txt_selOrderID.Text = grd_OrderView.SelectedRow.Cells[1].Text.ToString();

        }

        public void Re_Load()// Collects data from MSSQL and displays them in a GridView
        {
            string str_connection = "Data Source = localhost; Initial Catalog = FruitAndVeg; Trusted_Connection = True; Integrated Security = True";
            string MySelect = "SELECT Orders.OrderID, Customer.FirstName, Customer.LastName, convert(varchar(10),[Order_Date],103) as 'Order_Date', convert(varchar(10),[Delivary_Date],103) as 'Delivary_Date', Orders.Total_Cost, Orders.Order_Status FROM Orders INNER JOIN Customer ON Orders.CustomerID = Customer.CustomerID WHERE Order_Status != 'Completed'; ";
            SqlConnection con = new SqlConnection(str_connection);
            SqlDataAdapter ada = new SqlDataAdapter(MySelect, con);
            DataSet ds = new DataSet();
            ada.Fill(ds);
            grd_OrderView.DataSource = ds.Tables[0];
            grd_OrderView.DataBind();
        }

        protected void btn_datesSearch_Click(object sender, EventArgs e)//Date Search
        {
            string input1 = txt_date1.Text;
            string input2 = txt_date2.Text;

            try
            {
                string str_connection = "Data Source = localhost; Initial Catalog = FruitAndVeg; Trusted_Connection = True; Integrated Security = True";
                string MySelect = "SELECT Orders.OrderID, Customer.FirstName, Customer.LastName, convert(varchar(10),[Order_Date],103) as 'Order_Date', convert(varchar(10),[Delivary_Date],103) as 'Delivary_Date', Orders.Total_Cost, Orders.Order_Status " +
                                  "FROM[FruitAndVeg].[dbo].Orders " +
                                  "INNER JOIN Customer ON Orders.CustomerID = Customer.CustomerID " +
                                  "WHERE Order_Status != 'Completed'" +
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

        protected void btn_Savestatus_Click(object sender, EventArgs e) // Saves order status
        {
            try
            {
                string str_connection = "Data Source = localhost; Initial Catalog = FruitAndVeg; Trusted_Connection = True; Integrated Security = True";
                string myupd = "UPDATE [dbo].[Orders] SET " +
                    "[Order_Status] = '" + ddl_Status.Text + "'" + " WHERE [OrderID] =" + txt_selOrderID.Text + ";";


                SqlConnection con = new SqlConnection(str_connection);
                con.Open();
                SqlCommand Custupd = new SqlCommand(myupd, con);
                Custupd.ExecuteNonQuery();
                con.Close();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Order Has Been Updated')", true);
                Re_Load();
            }
            catch (Exception ex)
            {
                MsgPrompt("Something went wrongg" + ex);
            }
        }

        private void MsgPrompt(string msg) // Presents a msg to the user
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

        protected void btn_update_Click(object sender, EventArgs e) // Saves the OrderID and name and Redirects you to the Order Modify Page
        {

            Session["Names"] = txt_Name.Text;
            Session["OrdID"] = txt_selOrderID.Text;

            Response.Redirect("ModifyOrder.aspx");

        }

        protected void btn_delete_Click(object sender, EventArgs e) //Deletes a selected order and the order details from the database
        {
            try
            {
                string str_connection = "Data Source = localhost; Initial Catalog = FruitAndVeg; Trusted_Connection = True; Integrated Security = True";
                string mydel = "DELETE FROM Order_Details WHERE OrderID =" + txt_selOrderID.Text + "; DELETE FROM ORDERS WHERE OrderID = " + txt_selOrderID.Text + ";";
                SqlConnection con = new SqlConnection(str_connection);

                con.Open();
                SqlCommand AppUpd = new SqlCommand(mydel, con);
                AppUpd.ExecuteNonQuery();
                con.Close();

                MsgPrompt("Order : " + txt_selOrderID.Text + " was deleted SUCCESSFULLY");

                Re_Load();
            }
            catch ( Exception ex)
            {
                MsgPrompt("Something went wrongg" + ex);

            }


        }

        protected void CustomerPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerPage.aspx");
        }

        protected void ProductsPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("MerchPage.aspx");
        }

        protected void OrderCreationPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateOrderPage.aspx");
        }
    }
}