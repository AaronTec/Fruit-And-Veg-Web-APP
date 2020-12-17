<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrdersPage.aspx.cs" Inherits="FruitAndVegAPP.OrdersPage" %>

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
        <asp:Label ID="lbl_CustomerMenu" runat="server" Text="Orders Menu" Font-Size="X-Large" Font-Names="Arial"></asp:Label> 

        <asp:Button  ID="CustomerPage" runat="server" Text="Customers Page" OnClick="CustomerPage_Click" Height="36px" Width="140px" />
        <asp:Button  ID="ProductsPage" runat="server" Text="Products Page" OnClick="ProductsPage_Click" Height="36px" Width="140px" />
        <asp:Button ID="OrderCreationPage" runat="server" Text="Order Creation" OnClick="OrderCreationPage_Click" Height="36px" Width="140px" />

    </p>
    <p>
        <asp:Label ID="lbl_Orders" runat="server" Width="160px" Font-Size="Large" Text="Active Orders" Font-Names="Arial"></asp:Label>
        <p>
            <asp:Label ID="Label1" runat="server" Text="Select Dates" Font-Size="Large" Font-Names="Arial"></asp:Label>
            <asp:TextBox ID="txt_date1" runat="server"></asp:TextBox>
            <asp:Label ID="Label2" runat="server" Text="  And  " Font-Size="Large" Font-Names="Arial"></asp:Label>
            <asp:TextBox ID="txt_date2" runat="server"></asp:TextBox> 
            <asp:Button ID="btn_datesSearch" OnClick="btn_datesSearch_Click" runat="server" Text="Search dates" />
        </p>
        <asp:GridView ID="grd_OrderView" runat="server" Height="254px" AllowPaging="True" AutoGenerateSelectButton="True" OnPageIndexChanging="grd_OrderView_PageIndexChanging" OnSelectedIndexChanged="grd_OrderView_SelectedIndexChanged" Width="1109px" BackColor="#BBEAF9" BorderColor="#6699FF" BorderStyle="Solid" BorderWidth="7px" Font-Names="Arial">
        <FooterStyle Font-Names="Onyx" />
        </asp:GridView>
    </p>
    <p>
        <asp:Label ID="lbl_Date" runat="server" Font-Size="Large" Font-Names="Arial" Text="Search By Date"></asp:Label>
    </p>

    <p>
        <asp:Label ID="lbl_Products_Ordered" runat="server" Width="160px" Text="Products Ordered" Font-Names="Arial"></asp:Label>
        
    </p>
    <p>
        <asp:GridView ID="grd_orderDetails" runat="server" Height="254px" Width="1109px" AllowCustomPaging="True" BackColor="#BBEAF9" BorderColor="#6699FF" BorderStyle="Solid" BorderWidth="7px" Font-Names="Arial">
        <FooterStyle Font-Names="Onyx" />
        </asp:GridView>
    </p>
    <p>
        <asp:Label ID="lbl_selectedOrder" runat="server"  Width="160px" Text="Order ID: " Font-Names="Arial"></asp:Label>
        <asp:TextBox ID="txt_selOrderID" Width="200px" runat="server" ReadOnly="True"></asp:TextBox>
        <asp:Label ID="txt_CustName" runat="server"  Width="160px" Text="For Customer: " Font-Names="Arial"></asp:Label>
        <asp:TextBox ID="txt_Name" Width="200px" runat="server" ReadOnly="True"></asp:TextBox>
        <asp:Label ID="lbl_orderStatus" runat="server" Width="160px" Text="Order Status: " Font-Names="Arial"></asp:Label>
        <asp:DropDownList ID="ddl_Status" runat="server"> 
            <asp:ListItem Selected="True">Please Select</asp:ListItem> 
            <asp:ListItem>Completed</asp:ListItem>
            <asp:ListItem>Payment Complete, pending pickup</asp:ListItem>
            <asp:ListItem>Ordered Pending payment</asp:ListItem>
        </asp:DropDownList>
        

    </p>
    <p>
        <asp:Button ID="btn_Savestatus" OnClick="btn_Savestatus_Click" runat="server" Font-Size="Medium" Text="Save Status" />
        <asp:Button ID="btn_delete" runat="server" Font-Size="Medium" Text="Delete Order" OnClick="btn_delete_Click" />
    </p>
    <p>
        <asp:Button ID="btn_update" runat="server" Text="Update Order Products" Font-Size="Medium" OnClick="btn_update_Click" />
    </p>
    <p>
        <asp:Button ID="btn_complete" OnClick="btn_complete_Click" runat="server" Font-Size="Medium" Text="Completed Orders" />

    </p>
    <p>
        &nbsp;</p>
    </form>
</body>
</html>
