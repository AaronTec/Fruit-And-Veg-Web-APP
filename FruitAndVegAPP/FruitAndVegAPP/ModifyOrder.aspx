<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModifyOrder.aspx.cs" Inherits="FruitAndVegAPP.ModifyOrder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-color:#93D2D7;">
    <form id="form1" runat="server">

        <p>
        <asp:Label ID="Label1" runat="server" Text="Produce R US Company" Font-Size="XX-Large" Font-Names="Arial"></asp:Label> </p>
    <p>
        <asp:Label ID="lbl_OrderModifier" runat="server" Text="Order Modifier  " Font-Size="X-Large" Font-Names="Arial"></asp:Label> 
        <asp:Button ID="btn_Home" OnClick="btn_Home_Click" runat="server" Font-Size="Small" Text="HOME < BACK" />
    </p>
    <p>
        <asp:Label ID="lbl_OrderID" runat="server" Text=" " Font-Size="X-Large" Font-Names="Arial"></asp:Label>
        <asp:Label ID="lbl_Name" runat="server" Text=" " Font-Size="X-Large" Font-Names="Arial"></asp:Label>
    </p>
    <p>
        <asp:Button ID="btn_DisplayAll" OnClick="btn_DisplayAll_Click" runat="server" Text="Display All Products" Font-Size="Medium" Width="170px" /> 
        <asp:Button ID="btn_Search" OnClick="btn_Search_Click" runat="server" Text="Search Products" Font-Size="Medium" Width="170px" /> 
        <asp:TextBox ID="txt_search" Width="160px" runat="server"> </asp:TextBox>

    </p>
    <p>
        <asp:GridView ID="Grd_merch_view" runat="server" Height="254px" AllowPaging="True" AutoGenerateSelectButton="True" OnPageIndexChanging="Grd_merch_view_PageIndexChanging" OnSelectedIndexChanged="Grd_merch_view_SelectedIndexChanged" Width="1109px" BackColor="#BBEAF9" BorderColor="#6699FF" BorderStyle="Solid" BorderWidth="7px" Font-Names="Arial"><FooterStyle Font-Names="Onyx" /></asp:GridView> 
        <p>
            <asp:Label ID="Label2" Font-Names="Arial" runat="server" Text="Your Cart "></asp:Label>
        </p>
        
        <asp:ListBox ID="lst_selected" runat="server" Height="140px" Width="405px"></asp:ListBox>
        <asp:ListBox ID="lst_storage" runat="server" Visible="False"></asp:ListBox>
    </p>

    <p>
        &nbsp;</p>
    <p>
        <asp:Button ID="btn_Update" runat="server" OnClick="btn_update_Click" Text="Update" Font-Size="Medium" Width="170px" /> </p>
        <asp:GridView ID="grd_storage" Visible="False" runat="server" ></asp:GridView>
    </form>
</body>
</html>
