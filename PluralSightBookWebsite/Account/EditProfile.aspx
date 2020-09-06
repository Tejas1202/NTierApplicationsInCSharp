<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditProfile.aspx.cs" Inherits="PluralSightBookWebsite.Account.EditProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h1>Edit Profile</h1>
Name:<br />
<asp:TextBox runat="server" ID="NameTextBox" /><br />
Favorite Pluralsight Author:<br />
<asp:TextBox runat="server" ID="FavoriteAuthorTextBox" /><br />
<asp:Button runat="server" ID="SaveButton" onclick="SaveButton_Click" Text="Save" />
</asp:Content>
