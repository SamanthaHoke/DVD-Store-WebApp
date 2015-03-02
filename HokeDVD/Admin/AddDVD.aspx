<%@ Page Title="Admin | Add DVD" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AddDVD.aspx.cs" Inherits="HokeDVD.Admin.AddDVD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2"  ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!--Error Label-->
    <asp:Label runat="server" ID="dbErrorLabel" ForeColor="Red"></asp:Label><br />

    <!--DVD attribute labels and textboxes-->

    <!--Title-->
    <asp:Label runat="server" CssClass ="widelabel"> DVD Title: </asp:Label>
    <asp:Textbox id ="TextboxTitle" runat="server"></asp:Textbox>
    <asp:RequiredFieldValidator id ="ReqValidatorTitle" runat="server"
        CssClass ="errorMessages"
        ControlToValidate ="TextboxTitle"
        ErrorMessage ="Title is required!"
        Display ="Dynamic"
        SetFocusOnError ="true">
    </asp:RequiredFieldValidator>
    <br /><br />

    <!--Artist-->
    <asp:Label runat="server" CssClass ="widelabel"> DVD Artist: </asp:Label>
    <asp:Textbox id ="TextboxArtist" runat="server"></asp:Textbox>
    <asp:RequiredFieldValidator id ="ReqValidatorArtist" runat="server"
        CssClass ="errorMessages"
        ControlToValidate ="TextboxArtist"
        ErrorMessage ="Artist is required!"
        Display ="Dynamic"
        SetFocusOnError ="true">
    </asp:RequiredFieldValidator>
    <br /><br />

    <!--Rating-->
    <asp:Label runat="server" CssClass ="widelabel"> DVD Rating: </asp:Label>
    <asp:Textbox id ="TextboxRating" runat="server"></asp:Textbox>
    <asp:RequiredFieldValidator id ="ReqValidatorRating" runat="server"
        CssClass ="errorMessages"
        ControlToValidate ="TextboxRating"
        ErrorMessage ="Rating is required!"
        Display ="Dynamic"
        SetFocusOnError ="true">
    </asp:RequiredFieldValidator>
    <asp:RangeValidator ID="RangeValidatorRating" runat="server" 
        CssClass ="errorMessages"
        ControlToValidate ="TextboxRating"
        ErrorMessage="Rating must be between 1 and 5!"
        MinimumValue="1" 
        MaximumValue="5" 
        Type ="Integer" 
        Display ="Dynamic"
        SetFocusOnError ="true">
    </asp:RangeValidator>
    <br /><br />

    <!--Price-->
    <asp:Label runat="server" CssClass ="widelabel"> DVD Price: $</asp:Label>
    <asp:Textbox id ="TextboxPrice" runat="server"></asp:Textbox>
    <asp:RequiredFieldValidator id ="ReqValidatorPrice" runat="server"
        CssClass ="errorMessages"
        ControlToValidate ="TextboxPrice"
        ErrorMessage ="Price is required!"
        Display ="Dynamic"
        SetFocusOnError ="true">
    </asp:RequiredFieldValidator>
    <asp:CompareValidator ID="CompareValidatorPrice" runat="server" 
        CssClass ="errorMessages"
        ControlToValidate ="TextboxPrice"
        Type="Currency" 
        Operator="DataTypeCheck"
        ErrorMessage="Price must be a currency value!"
        SetFocusOnError ="true"
        Display ="Dynamic">
    </asp:CompareValidator>
    <br /><br />

    <!--Image url-->
    <asp:Label runat="server" CssClass ="widelabel"> DVD Image URL: (optional)</asp:Label>
    <asp:Textbox id ="TextboxImgURL" runat="server"></asp:Textbox>
    <br />

    <!--Decription-->
    <asp:Label runat="server" CssClass ="widelabel"> DVD Description: (optional)</asp:Label>
    <asp:TextBox id="TextBoxDescription" runat="server" 
        Columns="40" Rows ="4" TextMode="MultiLine" />
    <br />

    <!--AddDVD button-->
    <asp:Button id ="AddDVDButton" Text="Add DVD" runat="server" OnClick="AddDVDButton_Click"></asp:Button>


    <!--Log off button-->
    <br />
    <asp:Button ID="ButtonLogOff" runat="server" ValidationGroup="Logoff" OnClick="ButtonLogOff_Click" Text="Log Off" />

    
</asp:Content>
