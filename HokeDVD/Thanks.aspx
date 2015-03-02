<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Thanks.aspx.cs" Inherits="HokeDVD.Thanks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Thank you for your order </h1> 
    <span class="header"> Your Customer Number is: </span><asp:Label ID="custNum" runat="server" Text="Label"></asp:Label>


</asp:Content>
