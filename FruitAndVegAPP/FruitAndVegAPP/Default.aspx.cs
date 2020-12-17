using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FruitAndVegAPP
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Customers_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerPage.aspx");
        }
        protected void btn_Merchandise_Click(object sender, EventArgs e)
        {
            Response.Redirect("MerchPage.aspx");
        }
        protected void btn_CreateOrders_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateOrderPage.aspx");
        }
        protected void btn_Orders_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrdersPage.aspx");
        }

    }
}