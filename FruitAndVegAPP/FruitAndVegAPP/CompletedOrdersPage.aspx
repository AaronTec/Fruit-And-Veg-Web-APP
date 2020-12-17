<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompletedOrdersPage.aspx.cs" Inherits="FruitAndVegAPP.CompletedOrdersPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-color:#93D2D7">
    <form id="form1" runat="server">
        <p>
        <asp:Label ID="lbl_title" runat="server" Text="Produce R US Company" Font-Size="XX-Large" Font-Names="Arial"></asp:Label>
        </p>
    <p>
        <asp:Label ID="lbl_OrdersCompleteMenu" runat="server" Text="Completed Orders" Font-Size="X-Large" Font-Names="Arial"></asp:Label> 
        <asp:Button ID="btn_Home" OnClick="btn_Home_Click" runat="server" Font-Size="Small" Text="Orders Menu < BACK <" />
    </p>
        <p>
            <asp:Label ID="Label1" runat="server" Text="Select Dates" Font-Size="Large" Font-Names="Arial"></asp:Label>
            <asp:TextBox ID="txt_date1" runat="server"></asp:TextBox>
            <asp:Label ID="Label2" runat="server" Text="  And  " Font-Size="Large" Font-Names="Arial"></asp:Label>
            <asp:TextBox ID="txt_date2" runat="server"></asp:TextBox> 
            <asp:Button ID="btn_datesSearch" OnClick="btn_datesSearch_Click" runat="server" Text="Search dates" />
        </p>


    <p>
        <asp:Label ID="lbl_Orders" runat="server" Width="160px" Font-Size="Large" Text="Completed Orders" Font-Names="Arial"></asp:Label>
        <asp:GridView ID="grd_OrderView" runat="server" Height="254px" AllowPaging="True" AutoGenerateSelectButton="True" OnPageIndexChanging="grd_OrderView_PageIndexChanging" OnSelectedIndexChanged="grd_OrderView_SelectedIndexChanged" Width="1109px" BackColor="#BBEAF9" BorderColor="#6699FF" BorderStyle="Solid" BorderWidth="7px" Font-Names="Arial">
        <FooterStyle Font-Names="Onyx" />
        </asp:GridView>
    </p>

    <p>
        <asp:Label ID="lbl_Products_Ordered" runat="server" Width="160px" Text="Products Ordered" Font-Names="Arial"></asp:Label>
        
    </p>
    <p>
        <asp:GridView ID="grd_orderDetails" runat="server" Height="254px" Width="1109px" BackColor="#BBEAF9" BorderColor="#6699FF" BorderStyle="Solid" BorderWidth="7px" Font-Names="Arial">
        <FooterStyle Font-Names="Onyx" />
        </asp:GridView>
    </p>

    <p>
        &nbsp;</p>
    </form>
</body>
</html>
