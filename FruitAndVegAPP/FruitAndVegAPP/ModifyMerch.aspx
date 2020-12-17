<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModifyMerch.aspx.cs" Inherits="FruitAndVegAPP.ModifyMerch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-color:#93D2D7">
    <form id="form1" runat="server">
        <p>
        <asp:Label ID="lbl_title" runat="server" Text="Produce R US Company" Font-Size="XX-Large"></asp:Label>
        </p>
    <p>
        <asp:Label ID="lbl_MerchandiseMenu" runat="server" Text="Products Modifier  " Font-Size="X-Large"></asp:Label> 
        <asp:Button ID="btn_Home" OnClick="btn_Home_Click" runat="server" Font-Size="Small" Text="Products Menu < BACK <" />
    </p>

    <p>
        <asp:Label ID="lbl_ProductID" runat="server" Width="160px" Text="Product ID"></asp:Label>
        <asp:TextBox ID="txt_ProductID" Width="200px" runat="server" ReadOnly="True"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="lbl_ProductName" runat="server" Width="160px" Text="ProductName"></asp:Label>
        <asp:TextBox ID="txt_ProductName" Width="200px" runat="server"> </asp:TextBox>
    </p>

    <p>
        <asp:Label ID="lbl_QuantityPerUnit" runat="server" Width="160px" Text="QuantityPerUnit"></asp:Label>
        <asp:TextBox ID="txt_QuantityPerUnit" Width="200px" runat="server"> </asp:TextBox>
    </p>
    <p>
        <asp:Label ID="lbl_UnitPrice" runat="server"  Width="160px" Text="Unit Price"></asp:Label>
        <asp:TextBox ID="txt_UnitPrice" Width="200px" runat="server"> </asp:TextBox>
    </p>
    <p>
        <asp:Label ID="lbl_InStock" runat="server" Width="160px" Text="In Stock"></asp:Label>
        <asp:DropDownList ID="ddl_InStock" runat="server"> 
            <asp:ListItem Selected="True">Please Select</asp:ListItem> 
            <asp:ListItem>Y</asp:ListItem>
            <asp:ListItem>N</asp:ListItem>
        </asp:DropDownList>
        
    </p>

    <p>
        <asp:Button ID="btn_SaveMerch" OnClick="btn_SaveMerch_Click" runat="server" Font-Size="Large" Text="Save Changes" />
    </p>

<p>
    <asp:GridView ID="grd_mochlist" runat="server"></asp:GridView>
</p>

    </form>
</body>
</html>
