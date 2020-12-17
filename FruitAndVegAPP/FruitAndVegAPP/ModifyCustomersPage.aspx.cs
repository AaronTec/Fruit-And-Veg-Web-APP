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

    public partial class ModifyCustomersPage : System.Web.UI.Page
    {
         

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                RE_load();
            }
        }

        protected void btn_Home_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerPage.aspx");
        }

        protected void btn_SaveChanges_Click(object sender, EventArgs e) // Saves the changes in the txt boxes to the database
        {
            try
            {
                string str_connection = "Data Source = localhost; Initial Catalog = FruitAndVeg; Trusted_Connection = True; Integrated Security = True";
                string myupd = "UPDATE [dbo].[Customer] SET " +
                    "[FirstName] = '" + txt_FirstName.Text+ "'" +
                    ",[LastName] = '" + txt_LastName.Text + "'" +
                    ",[HomePhone] = '" + txt_HomePhone.Text + "'" +
                    ",[MobilePhone] = '" + txt_MobilePhone.Text + "'" +
                    ",[StreetAddress] = '" + txt_StreetAddress.Text + "'" +
                    ",[Suburb] = '" + txt_Suburb.Text + "'" +
                    ",[Postcode] = '" + txt_Postcode.Text + "'" +
                    ",[DriversLicence] = '" + txt_DriversLicence.Text + "'" +
                    ",[Email]= '" + txt_Email.Text + "'" +
                    ",[CreditCard_type]= '" + txt_CreditCard_type.Text + "'" +
                    ",[CreditCard_Number]= '" + txt_CreditCard_Number.Text + "'" +
                    "WHERE CustomerID =" + "'" + txt_CustomerID.Text + "'";

                SqlConnection con = new SqlConnection(str_connection);
                con.Open();
                SqlCommand Custupd = new SqlCommand(myupd, con);
                Custupd.ExecuteNonQuery();
                con.Close();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Customer details updated OK')", true);
                
                RE_load();
            }
            catch (Exception ex)
            {
                MsgPrompt("Customer details not Added" + ex);
            }
        }

        private void RE_load()
        {
            string[] words = ((string)Session["CustList"]).Split(';'); // carrying the selected data from the CusomterPage to the ModifyCustomersPage

            string str_connection = "Data Source = localhost; Initial Catalog = FruitAndVeg; Trusted_Connection = True; Integrated Security = True";
            string MySelect = "SELECT [CustomerID], [FirstName], [LastName], [HomePhone],[MobilePhone], [StreetAddress], [Suburb], [Postcode], [DriversLicence], [Email], [CreditCard_type], [CreditCard_Number] FROM[FruitAndVeg].[dbo].Customer WHERE CustomerID = "+ words[1];
            SqlConnection con = new SqlConnection(str_connection);
            SqlDataAdapter ada = new SqlDataAdapter(MySelect, con);
            DataSet ds = new DataSet();
            ada.Fill(ds);
            grd_custslt.DataSource = ds.Tables[0];
            grd_custslt.DataBind();

            grd_custslt.Visible = false;

            txt_CustomerID.Text = grd_custslt.Rows[0].Cells[0].Text;
            txt_FirstName.Text = grd_custslt.Rows[0].Cells[1].Text;
            txt_LastName.Text = grd_custslt.Rows[0].Cells[2].Text;
            txt_HomePhone.Text = grd_custslt.Rows[0].Cells[3].Text;
            txt_MobilePhone.Text = grd_custslt.Rows[0].Cells[4].Text;
            txt_StreetAddress.Text = grd_custslt.Rows[0].Cells[5].Text;
            txt_Suburb.Text = grd_custslt.Rows[0].Cells[6].Text;
            txt_Postcode.Text = grd_custslt.Rows[0].Cells[7].Text;
            txt_DriversLicence.Text = grd_custslt.Rows[0].Cells[8].Text;
            txt_Email.Text = grd_custslt.Rows[0].Cells[9].Text;
            txt_CreditCard_type.Text = grd_custslt.Rows[0].Cells[10].Text;
            txt_CreditCard_Number.Text = grd_custslt.Rows[0].Cells[11].Text;

            grd_custslt.Visible = false;
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