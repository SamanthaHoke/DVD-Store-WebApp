<%@ Page Title="Admin | Edit DVD" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EditDVD.aspx.cs" Inherits="HokeDVD.Admin.EditDVD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2"   ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--Error messages--%>
    <asp:Label ID="dbErrorLabel" ForeColor="Red" runat="server" /><br />

    <%--DVD dropdown list--%><span class ="header">Select a DVD to update:</span> <br />
    <asp:DropDownList ID="dvdList" runat="server" />
    <asp:Button ID="selectButton" Text="Select" runat="server" OnClick="selectButton_Click"
       />
    <br />
    
    <%--Textboxes for DVD fields--%>
    <span class="widelabel">Title:</span>
    <asp:TextBox ID="TextBoxTitle" runat="server" />
    <br />
    <span class="widelabel">Artist:</span>
    <asp:TextBox ID="TextBoxArtist" runat="server" />
    <br />
    <span class="widelabel">Rating:</span>
    <asp:TextBox ID="TextBoxRating" runat="server" />
    <br />
    <span class="widelabel">Price:</span>
    <asp:TextBox ID="TextBoxPrice" runat="server" />
    <br />
    <span class="widelabel">Image URL:</span>
    <asp:TextBox ID="TextBoxImgURL" runat="server" />
    <br />
    <span class="widelabel">Description:</span>
    <asp:TextBox id="TextBoxDescription" runat="server" 
        Columns="40" Rows ="4" TextMode="MultiLine" />
    
    <%--Update and Delete button--%>
    <asp:Button ID ="ButtonUpdate" Text ="Update DVD" Width ="200" 
          Enabled ="False" runat ="server" OnClick="ButtonUpdate_Click"  />
    <asp:Button ID ="ButtonDelete" Text ="Delete DVD" Width ="200" 
          Enabled ="False" runat ="server" OnClick="ButtonDelete_Click"  />
    <%--Log off button--%>
    
    <br />
    <asp:Button ID="ButtonLogoff" runat="server" Text="Log Off" OnClick="ButtonLogoff_Click" />
    

</asp:Content>
