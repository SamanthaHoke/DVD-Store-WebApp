<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="BuyDVD.aspx.cs" Inherits="HokeDVD.BuyDVD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Purchase your DVD</h2>

    <!-- Labels and inputs-->
    <asp:Label ID="dbErrorLabel" runat="server" ForeColor="Red" ></asp:Label>
    <br />
    <br />
    <asp:Label ID="DVDIDlabel" runat="server" Text="Label" Visible="False"></asp:Label>
    <br />
    <span class ="header"> DVD Title:</span> <asp:Label ID="TitleLabel" runat="server" Text="Label"></asp:Label>
    <br />
    <span class ="header">DVD Price: </span>  <asp:Label ID="PriceLabel" runat="server" Text="Label"></asp:Label>
    <br />
    <!--Returning customer-->
    <span class ="header">Enter your customer number:</span><br />
    <asp:TextBox ID="InputCustNumberTextBox" runat="server"></asp:TextBox>
    <br />
    <br />
    <!--New customer-->
    <span class ="header">If you don’t have a customer number, please enter this information to create one:</span><br />

    <span class ="header">Your First Name: </span> <asp:TextBox ID="FirstNameTextBox" runat="server"></asp:TextBox>
    <br />
    <span class ="header">Your Last Name: </span><asp:TextBox ID="LastNameTextBox" runat="server"></asp:TextBox>
    <br />
    <br />
    <!--Purchase button-->
    <asp:Button ID="PurchaseButton" runat="server" Text="Purchase" OnClick="PurchaseButton_Click" />
    

    



</asp:Content>
