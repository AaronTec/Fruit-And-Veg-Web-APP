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
    public partial class CreateCustomerPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Home_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerPage.aspx");
        }

        protected void btn_SaveCustomer_Click(object sender, EventArgs e)
        {

            try
            {
                string str_connection = "Data Source = localhost; Initial Catalog = FruitAndVeg; Trusted_Connection = True; Integrated Security = True";
                string myIns = "INSERT INTO [dbo].[Customer] " +
                    "([FirstName], " +
                    "[LastName], " +
                    "[HomePhone], " +
                    "[MobilePhone], " +
                    "[StreetAddress], " +
                    "[Suburb], " +
                    "[Postcode], " +
                    "[DriversLicence], " +
                    "[Email], " +
                    "[CreditCard_type], " +
                    "[CreditCard_Number]) " +
                    "VALUES ('" +
                    txt_FirstName.Text + "','" +
                    txt_LastName.Text + "','" +
                    txt_HomePhone.Text + "','" +
                    txt_MobilePhone.Text + "','" +
                    txt_StreetAddress.Text + "','" +
                    txt_Suburb.Text + "','" +
                    txt_Postcode.Text + "','" +
                    txt_DriversLicence.Text + "','" +
                    txt_Email.Text + "','" +
                    txt_CreditCard_type.Text + "','" +
                    txt_CreditCard_Number.Text + "')";

                SqlConnection con = new SqlConnection(str_connection);
                con.Open();
                SqlCommand Custupd = new SqlCommand(myIns, con);
                Custupd.ExecuteNonQuery();
                con.Close();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Customer details Added OK')", true);

                txt_FirstName.Text = "";
                txt_LastName.Text = "";
                txt_HomePhone.Text = "";
                txt_MobilePhone.Text = "";
                txt_StreetAddress.Text = "";
                txt_Suburb.Text = "";
                txt_Postcode.Text = "";
                txt_DriversLicence.Text = "";
                txt_Email.Text = "";
                txt_CreditCard_type.Text = "";
                txt_CreditCard_Number.Text = "";

            }
            catch (Exception ex)
            {
                MsgPrompt("Customer details not Added" + ex);
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