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
    public partial class CheckoutPage : System.Web.UI.Page
    {
        public int i = 1;
        public int[] prodid = new int[12];
        public string MySelect, MyInsert, MyInsert2;
        public int orderid;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                getBuildData();
            }
        }

        public void getBuildData()//With the collected Session data From the Product selection page it displays it in a Gridview Where you can edit the Quantites
        {
            string[] words = ((string)Session["CheckOutList"]).Split(';');
            int norows = Convert.ToInt16(Session["NumOfRows"]);


            MySelect = "SELECT  [ProductID], [ProductName], [QuantityPerUnit], [UnitPrice] FROM Products WHERE ProductID in (";

            for (int j = 0; j < norows; j++)
                MySelect = MySelect + Convert.ToInt16(words[j]) + ",";

            int index1 = MySelect.LastIndexOf(',');
            MySelect = MySelect.Remove(index1, 1);
            MySelect = MySelect + ")";

            string str_connection = "Data Source = localhost; Initial Catalog = FruitAndVeg; Trusted_Connection = True; Integrated Security = True";
            SqlConnection con = new SqlConnection(str_connection);
            SqlDataAdapter ada = new SqlDataAdapter(MySelect, con);
            DataSet ds = new DataSet();
            ada.Fill(ds);
            grd_products.DataSource = ds.Tables[0];
            grd_products.DataBind();
        }

        protected void btn_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateOrderPage.aspx");
        }
        protected void btn_DisplayAll_Click(object sender, EventArgs e)
        {
            Re_Load();
        }

        protected void Grd_CustomerView_SelectedIndexChanged(object sender, EventArgs e) // Allows the user to select a Customer.
        {
            txt_CustomerID.Text = Grd_CustomerView.SelectedRow.Cells[1].Text;

        }

        protected void Grd_CustomerView_PageIndexChanging(object sender, GridViewPageEventArgs e) // Changing the pages in the Customer GridView
        {
            Grd_CustomerView.PageIndex = e.NewPageIndex;
            Re_Load();
        }

        protected void btn_Search_Click(object sender, EventArgs e)// the user can select a Customer By searching for them.
        {
            string input = txt_search.Text;

            try
            {
                if (input.Contains(" "))
                {
                    string[] inputs = input.Split(' ');

                    string str_connection = "Data Source = localhost; Initial Catalog = FruitAndVeg; Trusted_Connection = True; Integrated Security = True";
                    string MySelect = "SELECT [CustomerID], [FirstName], [LastName], [Email]  FROM[FruitAndVeg].[dbo].Customer WHERE CHARINDEX('" + inputs[0] + "',FirstName)> 0 OR CHARINDEX('" + inputs[1] + "',LastName)> 0;";
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
                    string MySelect = "SELECT [CustomerID], [FirstName], [LastName], [Email] FROM[FruitAndVeg].[dbo].Customer WHERE CHARINDEX('" + input + "',FirstName)> 0 OR CHARINDEX('" + input + "',LastName)> 0;";
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
        protected void btn_TotalCost_Click(object sender, EventArgs e)// Calculate the Cost of the Cart
        {
            float total_cost = 0;

            try
            {
                for (int j = 0; j < grd_products.Rows.Count; j++) //Calculates the total cost
                {
                    int Qty = 0;
                    Qty = Convert.ToInt16(((TextBox)grd_products.Rows[j].Cells[4].FindControl("Qty")).Text);
                    total_cost = total_cost + (float.Parse(grd_products.Rows[j].Cells[3].Text, System.Globalization.NumberStyles.Any)) * Qty;
                }
                txt_cost.Text = "$" + total_cost.ToString();
            }
            catch(Exception ex)
            {
                MsgPrompt("No Quantity found " + ex);
            }

        }
        protected void btn_CreateOrder_Click(object sender, EventArgs e)// Creates the Order
        {

            int insertedID= 0;
            string txtToday = DateTime.Now.ToString("yyyy-MM-dd");
            string txttomorrow = txt_picDate.Text;

            float total_cost = 0;

                try
                {
                    //Getting the total cost

                    for (int j = 0; j < grd_products.Rows.Count; j++)
                    {
                        int Qty = 0;
                        Qty = Convert.ToInt16(((TextBox)grd_products.Rows[j].Cells[4].FindControl("Qty")).Text);
                        total_cost = total_cost + (float.Parse(grd_products.Rows[j].Cells[3].Text, System.Globalization.NumberStyles.Any)) * Qty;
                    }

                    //creating the MYORDERS insert
                    string str_connection = "Data Source = localhost; Initial Catalog = FruitAndVeg; Trusted_Connection = True; Integrated Security = True";
                    SqlConnection con = new SqlConnection(str_connection);

                    con.Open();
                    MyInsert = "INSERT INTO Orders (CustomerID, Order_Date, Delivary_Date, Total_Cost, Order_Status) output Inserted.OrderID VALUES("
                                + txt_CustomerID.Text + ", '" + txtToday + "', convert(DATE,'" + txttomorrow + "',103), " + total_cost.ToString() + ",'" + "Ordered Pending payment'); ";


                    //Create the order Details.
                    //first get the orderID from the indert just made.


                    using (SqlCommand cmd = new SqlCommand(MyInsert, con))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            insertedID = reader.GetInt32(0);
                        }
                    }

                    SqlConnection con2 = new SqlConnection(str_connection);
                    con2.Open();
                    SqlDataAdapter ada2 = new SqlDataAdapter(MyInsert2, con2);
                    for (int j = 0; j < grd_products.Rows.Count; j++) //For each Item in the cark it inserts it into OrderDetails with the Selected Quantity
                    {
                        int Qty = 0;
                        Qty = Convert.ToInt16(((TextBox)grd_products.Rows[j].Cells[3].FindControl("Qty")).Text);
                        string prodid2 = grd_products.Rows[j].Cells[0].Text;
                        MyInsert2 = "INSERT INTO Order_Details (OrderID, ProductID, Quantity) VALUES (" + insertedID + "," + prodid2 + ", " + Qty + ");";

                        SqlCommand ApptUpd2 = new SqlCommand(MyInsert2, con2);
                        ApptUpd2.ExecuteNonQuery();

                       
                    }

                    MsgPrompt("ORDER Has been created SUCCESSFULLY");
                }
                catch (Exception t)
                {

                    MsgPrompt("ORDER FAILED" + t);


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

        public void Re_Load()
        {
            string str_connection = "Data Source = localhost; Initial Catalog = FruitAndVeg; Trusted_Connection = True; Integrated Security = True";
            string MySelect = "SELECT [CustomerID], [FirstName], [LastName], [Email]  FROM[FruitAndVeg].[dbo].Customer ";
            SqlConnection con = new SqlConnection(str_connection);
            SqlDataAdapter ada = new SqlDataAdapter(MySelect, con);
            DataSet ds = new DataSet();
            ada.Fill(ds);
            Grd_CustomerView.DataSource = ds.Tables[0];
            Grd_CustomerView.DataBind();
        }











    }

}
