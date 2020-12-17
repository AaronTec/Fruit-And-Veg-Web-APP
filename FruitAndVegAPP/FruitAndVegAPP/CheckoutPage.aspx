<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckoutPage.aspx.cs" Inherits="FruitAndVegAPP.CheckoutPage" %>

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
        <asp:Label ID="lbl_Checkout" runat="server" Text="Checkout  " Font-Size="X-Large" Font-Names="Arial"></asp:Label> 
        <asp:Button ID="btn_Back" OnClick="btn_Back_Click" runat="server" Font-Size="Small" Text="Order Creation < BACK" />
    </p>
    <p>
        <asp:GridView ID="grd_products" BackColor="#BBEAF9" BorderColor="#6699FF" BorderStyle="Solid" BorderWidth="7px" Font-Names="Arial" runat="server" AutoGenerateColumns="false" Width="738px" Height="140px" PageSize="15" EmptyDataText="&quot;No data in the data" >

            <Columns>

                <asp:BoundField DataField="ProductID" HeaderText="ProductID" ReadOnly="True" />

                <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="Name" ReadOnly="True"></asp:BoundField>

                <asp:BoundField DataField="QuantityPerUnit" HeaderText="Quantity per Unit" ReadOnly="True" />

                <asp:BoundField DataField="UnitPrice" HeaderText="Unit Price" />

                <asp:TemplateField HeaderText="Qty">
                    <ItemTemplate>
                        <asp:TextBox ID="Qty" runat="server" Text=""></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
            <rowstyle height ="30"/>
            <HeaderStyle Font-Names="Arial Black" Font-Underline="true" />
        </asp:GridView>
    </p>
    <p>

        <asp:Label ID="lbl_delivery" Font-Names="Arial" runat="server" Text="Delivery/Pickup Date: "></asp:Label>
        <asp:TextBox ID="txt_picDate" runat="server"></asp:TextBox>
    </p>
    <p>
        &nbsp;<p>
        <asp:GridView ID="Grd_CustomerView" runat="server" Height="200px" AllowPaging="True" AutoGenerateSelectButton="True" OnPageIndexChanging="Grd_CustomerView_PageIndexChanging" OnSelectedIndexChanged="Grd_CustomerView_SelectedIndexChanged" Width="1109px" BackColor="#BBEAF9" BorderColor="#6699FF" BorderStyle="Solid" BorderWidth="7px" Font-Names="Arial"><FooterStyle Font-Names="Onyx" /></asp:GridView>
    </p>
        <asp:Button ID="btn_DisplayAll" OnClick="btn_DisplayAll_Click" runat="server" Text="Display All Customers" Font-Size="Medium" Width="170px"  /> 
        <asp:Button ID="btn_Search" OnClick="btn_Search_Click" runat="server" Text="Search Customer" Font-Size="Medium" Width="170px"  /> 
        <asp:TextBox ID="txt_search" Width="160px" runat="server"> </asp:TextBox>
        <asp:Label ID="lbl_CustomerID" runat="server" Text="Customer ID: " Font-Size="Large" Font-Names="Arial"></asp:Label>
        <asp:TextBox ID="txt_CustomerID" Width="160px" runat="server"> </asp:TextBox>
    </p>

    <p>
        <asp:Button ID="btn_TotalCost" OnClick="btn_TotalCost_Click" runat="server" Text="Calculate Cost" Font-Size="Medium" Width="170px" /> 
        <asp:TextBox ID="txt_cost" Width="160px" runat="server"> </asp:TextBox>
    </p>
    <p>
        <asp:Button ID="btn_CreateOrder" runat="server" OnClick="btn_CreateOrder_Click" Text="Create Order" Font-Size="Medium" Width="170px" /> </p>




    </form>
</body>
</html>
