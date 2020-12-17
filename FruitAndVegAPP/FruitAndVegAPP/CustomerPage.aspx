<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerPage.aspx.cs" Inherits="FruitAndVegAPP.CustomerPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-color:#93D2D7;">
    <form id="form1" runat="server">

        <p>
        <asp:Label ID="Label1" runat="server" Text="Produce R US Company" Font-Size="XX-Large" BorderColor="Black" ForeColor="Black" Font-Names="Arial"></asp:Label> </p>
    <p>
        <asp:Label ID="lbl_CustomerMenu" runat="server" Text="Customer Menu" Font-Size="X-Large" Font-Names="Arial" ForeColor="Black"></asp:Label> 
        <asp:Button ID="btn_Home" OnClick="btn_Home_Click" runat="server" Font-Size="Small" Text="HOME < BACK" />
    </p>
    <p>
        <asp:GridView ID="Grd_CustomerView" PageSize="5" runat="server" Height="254px" AllowPaging="True" AutoGenerateSelectButton="True" OnPageIndexChanging="CustomerView_PageIndexChanging" OnSelectedIndexChanged="CustomerView_SelectedIndexChanged" Width="1109px" BackColor="#BBEAF9" BorderColor="#6699FF" BorderStyle="Solid" BorderWidth="7px" Font-Names="Arial">
            <FooterStyle Font-Names="Onyx" />
        </asp:GridView>
    </p>
    <p>
        <asp:Button ID="btn_DisplayAll" OnClick="btn_DisplayAll_Click" runat="server" Text="Display All Customers" Font-Size="Medium" Width="170px" /> </p>
    <p>
        <asp:Button ID="btn_Search" OnClick="btn_Search_Click" runat="server" Text="Search Name" Font-Size="Medium" Width="170px" /> 
        <asp:TextBox ID="txt_search" Width="160px" runat="server"> </asp:TextBox>
    </p>
    <p>
        <asp:Button ID="btn_CreateCustomer" runat="server" OnClick="btn_CreateCustomer_Click" Text="Create Customer" Font-Size="Medium" Width="170px" /> </p>




    </form>
</body>
</html>
