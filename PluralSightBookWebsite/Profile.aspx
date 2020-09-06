<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="PluralSightBookWebsite.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h1>Profile</h1>
Welcome <asp:Literal ID="NameLiteral" runat="server" />!
<p>
Your favorite Pluralsight author's name is <asp:Literal ID="AuthorLiteral" runat="server" />.  Thanks for sharing!
</p>
<a href="/Account/EditProfile.aspx">Edit Profile</a>
</asp:Content>
