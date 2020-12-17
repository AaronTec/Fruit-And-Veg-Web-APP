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
    public partial class ModifyMerch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Re_load();
            }
        }

        protected void btn_SaveMerch_Click(object sender, EventArgs e) // Saves the changes in the txt boxes to the database
        {
            try
            {
                string str_connection = "Data Source = localhost; Initial Catalog = FruitAndVeg; Trusted_Connection = True; Integrated Security = True";
                string myupd = "UPDATE [dbo].[Products] SET " +
                    "[ProductName] = '" + txt_ProductName.Text + "'" +
                    ",[QuantityPerUnit] = '" + txt_QuantityPerUnit.Text + "'" +
                    ",[UnitPrice] = '" + txt_UnitPrice.Text + "'" +
                    ",[InStock] = '" + ddl_InStock.Text + "'" +
                    "WHERE ProductID =" + "'" + txt_ProductID.Text + "'";

                SqlConnection con = new SqlConnection(str_connection);
                con.Open();
                SqlCommand Custupd = new SqlCommand(myupd, con);
                Custupd.ExecuteNonQuery();
                con.Close();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('MERCHANDISE details updated OK')", true);

                Re_load();
            }
            catch (Exception ex)
            {
                MsgPrompt("MERCHANDISE details not Added   " + ex);
            }
        }

        protected void btn_Home_Click(object sender, EventArgs e)
        {
            Response.Redirect("MerchPage.aspx");
        }

        private void Re_load()
        {
            string[] words = ((string)Session["mochList"]).Split(';'); // carrying the selected data from the CusomterPage to the ModifyCustomersPage

            string str_connection = "Data Source = localhost; Initial Catalog = FruitAndVeg; Trusted_Connection = True; Integrated Security = True";
            string MySelect = "SELECT [ProductID], [ProductName], [QuantityPerUnit], [UnitPrice],[InStock] FROM[FruitAndVeg].[dbo].Products WHERE ProductID = " + words[1];
            SqlConnection con = new SqlConnection(str_connection);
            SqlDataAdapter ada = new SqlDataAdapter(MySelect, con);
            DataSet ds = new DataSet();
            ada.Fill(ds);
            grd_mochlist.DataSource = ds.Tables[0];
            grd_mochlist.DataBind();

            grd_mochlist.Visible = false;

            txt_ProductID.Text = grd_mochlist.Rows[0].Cells[0].Text;
            txt_ProductName.Text = grd_mochlist.Rows[0].Cells[1].Text;
            txt_QuantityPerUnit.Text = grd_mochlist.Rows[0].Cells[2].Text;
            txt_UnitPrice.Text = grd_mochlist.Rows[0].Cells[3].Text;
            ddl_InStock.Text = grd_mochlist.Rows[0].Cells[4].Text;


            grd_mochlist.Visible = false;
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