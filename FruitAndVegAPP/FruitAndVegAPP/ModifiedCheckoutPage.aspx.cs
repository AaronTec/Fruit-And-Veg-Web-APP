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
    public partial class ModifiedCheckoutPage : System.Web.UI.Page
    {

        public int i = 1;
        public int[] prodid = new int[12];
        public string MySelect, MyInsert, MyInsert2;
        public int orderid;

        protected void Page_Load(object sender, EventArgs e)
        {

            //i = Convert.ToInt16(Session["NumOfRows"]);

            //string[] words = ((string)Session["CheckOutList"]).Split(';');
            ////lbl_msg1.Text = "Your list is " + words[0] + words[1] + words[2];
            //for (int j = 0; j <= i - 1; j++)
            //    prodid[j] = Convert.ToInt16(words[j]);

            if (!Page.IsPostBack)
            {
                getBuildData();
            }

            lbl_Name.Text = " Customer Name: " + Session["Names"];
            lbl_OrderID.Text = " OrderID : " + Session["OrderID2"];

        }

        public void getBuildData()
        {
            //_________________________________________________________________

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

            string[] quants = ((string)Session["quants"]).Split(';');

            try
            {
                for (int x = 0; x < 100; x++)
                {
                    Convert.ToInt16(((TextBox)grd_products.Rows[x].Cells[4].FindControl("Qty")).Text = quants[x]);
                }
            }
            catch
            {

            }


        }

        protected void btn_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrdersPage.aspx");
        }

        protected void btn_TotalCost_Click(object sender, EventArgs e)
        {
            float total_cost = 0;

            try
            {
                for (int j = 0; j < grd_products.Rows.Count; j++)
                {
                    int Qty = 0;
                    Qty = Convert.ToInt16(((TextBox)grd_products.Rows[j].Cells[4].FindControl("Qty")).Text);
                    total_cost = total_cost + (float.Parse(grd_products.Rows[j].Cells[3].Text, System.Globalization.NumberStyles.Any)) * Qty;
                }
                txt_cost.Text = "$" + total_cost.ToString();
            }
            catch (Exception ex)
            {
                MsgPrompt("No Quantity found " + ex);
            }

        }
        protected void btn_SaveMods_Click(object sender, EventArgs e)
        {
            //WE need to delete all the Order details with the given OrderID number and then we are going to make new order details.

            try
            {
                string ordrID = Session["OrderID2"].ToString();
                string txtToday = DateTime.Now.ToString("yyyy-MM-dd");
                string txttomorrow = txt_picDate.Text;

                float total_cost = 0;

                //Getting the total cost

                for (int j = 0; j < grd_products.Rows.Count; j++)
                {
                    int Qty = 0;
                    Qty = Convert.ToInt16(((TextBox)grd_products.Rows[j].Cells[4].FindControl("Qty")).Text);
                    total_cost = total_cost + (float.Parse(grd_products.Rows[j].Cells[3].Text, System.Globalization.NumberStyles.Any)) * Qty;
                }

                //Deleteing the order details, getting it ready for a new one.
                string str_connection = "Data Source = localhost; Initial Catalog = FruitAndVeg; Trusted_Connection = True; Integrated Security = True";
                string mydel = "DELETE FROM Order_Details WHERE OrderID =" + ordrID + ";";
                SqlConnection con = new SqlConnection(str_connection);

                con.Open();
                SqlCommand AppUpd = new SqlCommand(mydel, con);
                AppUpd.ExecuteNonQuery();
                con.Close();

                //Create the order Details.

                SqlConnection con2 = new SqlConnection(str_connection);
                con2.Open();
                SqlDataAdapter ada2 = new SqlDataAdapter(MyInsert2, con2);
                for (int j = 0; j < grd_products.Rows.Count; j++)
                {
                    int Qty = 0;
                    Qty = Convert.ToInt16(((TextBox)grd_products.Rows[j].Cells[4].FindControl("Qty")).Text);
                    if(Qty != 0)
                    {
                        string prodid2 = grd_products.Rows[j].Cells[0].Text;
                        MyInsert2 = "INSERT INTO Order_Details (OrderID, ProductID, Quantity) VALUES (" + ordrID + "," + prodid2 + ", " + Qty + ");";
                        SqlCommand ApptUpd2 = new SqlCommand(MyInsert2, con2);
                        ApptUpd2.ExecuteNonQuery();
                    }

                    //total_cost = total_cost + (float.Parse(GridView1.Rows[j].Cells[2].Text, System.Globalization.NumberStyles.Any)) * Qty;
                }

                string dell = "DELETE FROM Order_Details WHERE Quantity = 0";
                SqlConnection con3 = new SqlConnection(str_connection);
                con3.Open();
                SqlCommand delle = new SqlCommand(dell, con3);
                delle.ExecuteNonQuery();
                con3.Close();

                string upd = "UPDATE Orders" +
                    " SET Delivary_Date = convert(DATE,'" + txttomorrow + "',103), Total_Cost = "+ total_cost.ToString() +
                    " WHERE OrderID = " + ordrID + ";";
                SqlConnection con4 = new SqlConnection(str_connection);
                con4.Open();
                SqlCommand upsd = new SqlCommand(upd, con4);
                upsd.ExecuteNonQuery();
                con3.Close();




                MsgPrompt("Order was Updated SUCCESSFULLY");


            }
            catch (Exception ex)
            {
                MsgPrompt("Order was not Updated, Contact admin:   " + ex);
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