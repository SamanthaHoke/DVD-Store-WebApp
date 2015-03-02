<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="HokeDVD.home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>




<asp:Content ID="Content2"  ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<br />
    <!--header--> 
    <h2> Welcome to our site. </h2>
    <h2>Please browse the list of DVD’s. </h2>

    <!--DVD datalist-->
    <asp:Datalist id="DVDDatalist" runat="server" OnItemCommand="DVDDatalist_ItemCommand">
       <ItemTemplate> 
          <span class ="header"> Title:</span> <%#Eval("DVDtitle")%>
          <span class ="header"> Artist:</span> <%#Eval("DVDartist")%>
          <span class ="header"> Rating:</span> <%#Eval("DVDrating")%>
          <span class ="header"> Price:</span> <%#Eval("DVDprice", "{0:C}")%>
          <br />
          <asp:LinkButton ID ="ButtonDetails" runat ="server"
              Text=<%#"Details"%>
              CommandName ="details" 
              CommandArgument = <%#Eval("DVDID")%> 
             /> 
            <br />
           <asp:LinkButton ID ="ButtonBuy" runat ="server" 
                Text = <%#"Buy DVD"%>
                 CommandName ="buyDVD" 
                 CommandArgument = <%#Eval("DVDID")%> 
            />

       </ItemTemplate> 
        <SeparatorTemplate> 
        <hr /> 
        </SeparatorTemplate>  
    </asp:Datalist>

</asp:Content>
