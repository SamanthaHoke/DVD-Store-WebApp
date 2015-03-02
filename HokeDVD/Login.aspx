<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HokeDVD.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Please Login Here</h1>
    <!--username-->
    <p> 
       Username:
       <asp:TextBox id ="usernameTextBox" runat ="server" />
       <asp:RequiredFieldValidator id ="usernameReq" runat ="server" 
            ControlToValidate ="usernameTextBox"  
            SetFocusOnError = "true"
            ErrorMessage ="Username is required!"
            CssClass ="errorMessages"  /> 
    </p> 

    <!--password-->
    <p> 
       Password:
       <asp:TextBox id ="passwordTextBox" runat ="server" TextMode ="Password" />
       <asp:RequiredFieldValidator id ="passwordReq" runat ="server" 
            ControlToValidate ="passwordTextBox" 
            SetFocusOnError = "true"
            ErrorMessage ="Password is required!" 
            CssClass ="errorMessages"  />
    </p> 
    <!--submit button-->
    <p>
    <asp:Button id ="submitButton" runat ="server" Text ="Login" OnClick="submitButton_Click"/>
    </p>



</asp:Content>
