<%@ Page Title="DVD Details" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="details.aspx.cs" Inherits="HokeDVD.details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


</asp:Content>
<asp:Content ID="Content2"  ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 
    <h2>View Your DVD's Details</h2>

    <!--DVD attribute labels-->
    <asp:Label ID ="dbErrorLabel" runat ="server" CssClass ="errorMessages" />
    <asp:Image id="Pic" runat="server" Width="150" Height="200" BackColor = "Black" />
    <span class ="header"> Title: </span><asp:Label runat ="server" ID ="LabelTitle"></asp:Label><br />
    <span class ="header"> Artist: </span><asp:Label runat ="server" ID ="LabelArtist"></asp:Label><br />
    <span class ="header"> Rating: </span><asp:Label runat ="server" ID ="LabelRating"></asp:Label><br />
    <span class ="header"> Description: </span><asp:Label runat ="server" ID ="LabelDescription"></asp:Label><br />

    <!--Done button-->
    <asp:Button ID="ButtonDone" runat="server" Text="Done" OnClick="ButtonDone_Click" />

</asp:Content>
