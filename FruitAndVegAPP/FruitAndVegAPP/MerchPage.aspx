<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MerchPage.aspx.cs" Inherits="FruitAndVegAPP.MerchPage" %>

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
        <asp:Label ID="lbl_MerchMenu" runat="server" Text="Merchandise Menu  " Font-Size="X-Large" Font-Names="Arial"></asp:Label> 
        <asp:Button ID="btn_Home" OnClick="btn_Home_Click" runat="server" Font-Size="Small" Text="HOME < BACK" />
    </p>
    <p>
        <asp:Button ID="btn_DisplayAll" OnClick="btn_DisplayAll_Click" runat="server" Text="Display All Products" Font-Size="Medium" Width="170px" /> </p>
    <p>
    <p>
        <asp:GridView ID="Grd_merch_view" runat="server" Height="254px" AllowPaging="True" AutoGenerateSelectButton="True" OnPageIndexChanging="Grd_merch_view_PageIndexChanging" OnSelectedIndexChanged="Grd_merch_view_SelectedIndexChanged" Width="1109px" BackColor="#BBEAF9" BorderColor="#6699FF" BorderStyle="Solid" BorderWidth="7px" Font-Names="Arial"><FooterStyle Font-Names="Onyx" /></asp:GridView>
    </p>

    <p>
        <asp:Button ID="btn_Search" OnClick="btn_Search_Click" runat="server" Text="Search Merch" Font-Size="Medium" Width="170px" /> 
        <asp:TextBox ID="txt_search" Width="160px" runat="server"> </asp:TextBox>
    </p>
    <p>
        <asp:Button ID="btn_CreateMerch" runat="server" OnClick="btn_CreateMerch_Click" Text="Create new Merch" Font-Size="Medium" Width="170px" /> </p>




    </form>
</body>
</html>
