<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModifyCustomersPage.aspx.cs" Inherits="FruitAndVegAPP.ModifyCustomersPage" %>

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
        <asp:Label ID="lbl_CustomerMenu" runat="server" Text="Customer Modifier" Font-Size="X-Large" Font-Names="Arial"></asp:Label> 
        <asp:Button ID="btn_Home" OnClick="btn_Home_Click" runat="server" Font-Size="Small" Text="Customer Menu < BACK <" />
    </p>
    <p>
        <asp:Label ID="lbl_CustomerID" runat="server" Width="160px" Text="CustomerID" Font-Names="Arial"></asp:Label>
        <asp:TextBox ID="txt_CustomerID" Width="200px" runat="server" ReadOnly="True"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="lbl_FirstName" runat="server" Width="160px" Text="First Name" Font-Names="Arial"></asp:Label>
        <asp:TextBox ID="txt_FirstName" Width="200px" runat="server"> </asp:TextBox>
    </p>

    <p>
        <asp:Label ID="lbl_LastName" runat="server" Width="160px" Text="LastName" Font-Names="Arial"></asp:Label>
        <asp:TextBox ID="txt_LastName" Width="200px" runat="server"> </asp:TextBox>
    </p>
    <p>
        <asp:Label ID="lbl_HomePhone" runat="server"  Width="160px" Text="HomePhone" Font-Names="Arial"></asp:Label>
        <asp:TextBox ID="txt_HomePhone" Width="200px" runat="server"> </asp:TextBox>
    </p>
    <p>
        <asp:Label ID="lbl_MobilePhone" runat="server" Width="160px" Text="MobilePhone" Font-Names="Arial"></asp:Label>
        <asp:TextBox ID="txt_MobilePhone" Width="200px" runat="server"> </asp:TextBox>
    </p>
    <p>
        <asp:Label ID="lbl_StreetAddress" runat="server" Width="160px"  Text="StreetAddress" Font-Names="Arial"></asp:Label>
        <asp:TextBox ID="txt_StreetAddress" Width="200px" runat="server"> </asp:TextBox>
    </p>
    <p>
        <asp:Label ID="lbl_Suburb" runat="server" Width="160px"  Text="Suburb" Font-Names="Arial"></asp:Label>
        <asp:TextBox ID="txt_Suburb" Width="200px" runat="server"> </asp:TextBox>
    </p>
    <p>
        <asp:Label ID="lbl_Postcode" runat="server" Width="160px"  Text="Postcode" Font-Names="Arial"></asp:Label>
        <asp:TextBox ID="txt_Postcode" Width="200px" runat="server"> </asp:TextBox>
    </p>
    <p>
        <asp:Label ID="lbl_DriversLicence" runat="server" Width="160px"  Text="DriversLicence" Font-Names="Arial"></asp:Label>
        <asp:TextBox ID="txt_DriversLicence" Width="200px" runat="server"> </asp:TextBox>
    </p>
    <p>
        <asp:Label ID="lbl_Email" runat="server" Width="160px"  Text="Email" Font-Names="Arial"></asp:Label>
        <asp:TextBox ID="txt_Email" Width="200px" runat="server"> </asp:TextBox>
    </p>
    <p>
        <asp:Label ID="CreditCard_type" runat="server" Width="160px"  Text="CreditCard_type" Font-Names="Arial"></asp:Label>
        <asp:TextBox ID="txt_CreditCard_type" Width="200px" runat="server"> </asp:TextBox>
    </p>
    <p>
        <asp:Label ID="CreditCard_Number" runat="server" Width="160px"  Text="CreditCard_Number" Font-Names="Arial"></asp:Label>
        <asp:TextBox ID="txt_CreditCard_Number" Width="200px" runat="server"> </asp:TextBox>
    </p>
    <p>
        <asp:Button ID="btn_SaveChanges" OnClick="btn_SaveChanges_Click" runat="server" Font-Size="Large" Text="Save Changes" />
    </p>


<p>
    <asp:GridView ID="grd_custslt" runat="server"></asp:GridView>
</p>


    </form>
</body>
</html>
