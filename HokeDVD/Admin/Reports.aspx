<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="HokeDVD.Admin.Reports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>View reports here</h2>
    
        <!--Input controls-->
        <asp:Button ID="ButtonCustomers" runat="server" Text="List Customers" OnClick="ButtonCustomers_Click" />
        <br />
        <asp:Button ID="OrdersButton" runat="server" Text="Get Orders" OnClick="OrdersButton_Click" />
        <span class="header">For Customer #:</span><asp:TextBox ID="CustNumTextBox" runat="server"></asp:TextBox>
        &nbsp;
        <br />

        <!--Datalists-->
        <asp:Datalist id="DatalistCust" runat="server" Visible ="false">
            <HeaderTemplate>
                <hr />
                <span class="header">Customers</span>
                <hr />
            </HeaderTemplate>
           <ItemTemplate> 
             <strong style="color:  #357001;"> Customer ID: </strong><%#Eval("CustomerID")%>
             <strong style="color:  #357001;"> First Name: </strong><%#Eval("FirstName")%>
             <strong style="color:  #357001;"> Last Name: </strong><%#Eval("LastName")%><br />
              <br />
           </ItemTemplate> 
            <SeparatorTemplate> 
            <hr /> 
            </SeparatorTemplate>  
            <FooterTemplate>
                <hr />
                <hr />
            </FooterTemplate>
        </asp:Datalist>
        <br />
        <br />

        <asp:Datalist id="DatalistOrders" runat="server" Visible ="false">
            <HeaderTemplate>
                <hr />
                <span class="header">Orders</span>
                <hr />
            </HeaderTemplate>
           <ItemTemplate> 
             <strong style="color:  #523a02;"> Order ID: </strong><%#Eval("OrderID")%>
             <strong style="color:  #523a02;"> Customer ID: </strong><%#Eval("CustomerID")%>
             <strong style="color:  #523a02;"> DVD ID: </strong><%#Eval("DVDID")%>
             <strong style="color:  #523a02;"> DVD Title: </strong><%#Eval("DVDtitle")%><br />
              <br />
           </ItemTemplate> 
            <SeparatorTemplate> 
            <hr /> 
            </SeparatorTemplate> 
            <FooterTemplate>
                <hr />
                <hr />
            </FooterTemplate> 
         </asp:Datalist>

        <!--Log off button-->
        <asp:Button ID="ButtonLogout" runat="server" Text="Logoff" OnClick="ButtonLogout_Click" />
    

</asp:Content>
