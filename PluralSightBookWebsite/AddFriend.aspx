<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddFriend.aspx.cs" Inherits="PluralSightBookWebsite.AddFriend" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Add Friend</h1>
    <asp:Label AssociatedControlID="EmailTextBox" runat="server" ID="EmailLabel" Text="Friend's Email Address" />
    <asp:TextBox runat="server" ID="EmailTextBox" />
    <asp:Button runat="server" ID="SaveButton" Text="Add" OnClick="SaveButton_Click" />
</asp:Content>
