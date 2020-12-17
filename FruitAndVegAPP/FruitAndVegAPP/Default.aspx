<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FruitAndVegAPP._Default" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server"> 

    <p>
        <asp:Label ID="Label1" runat="server" Text="Produce R US Company" Font-Size="XX-Large"></asp:Label>
    <p>
        <asp:Label ID="lbl_Menu" runat="server" Text="Main Menu" Font-Size="X-Large"></asp:Label>
    <p>
        <asp:Button ID="btn_Customers" OnClick="btn_Customers_Click" runat="server" Text="Customers" Font-Size="Large" Width="160px" />
    <p>
        <asp:Button ID="btn_Merchandise" OnClick="btn_Merchandise_Click" runat="server" Text="Products" Font-Size="Large" Width="160px" />
    <p>
        <asp:Button ID="btn_CreateOrders" OnClick="btn_CreateOrders_Click" runat="server" Text="Create Order" Font-Size="Large" Width="160px" />
    <p>
        <asp:Button ID="btn_Orders" runat="server" OnClick="btn_Orders_Click" Text="Orders" Font-Size="Large" Width="160px" />
    </p>


</asp:Content>