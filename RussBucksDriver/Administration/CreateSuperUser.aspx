<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="CreateSuperUser.aspx.vb" Inherits="RussBucksDriver.CreateSuperUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    Enter Email Address:<br />
    <asp:TextBox ID="SuperUser1" runat="server" Width="136px"></asp:TextBox>
&nbsp;&nbsp;
    
    <asp:Button ID="Button1" runat="server" Text="Submit" onclick="Button1_Click"/>
    <br />
    <asp:Label ID="Label1" runat="server" ></asp:Label>
<br />
</asp:Content>
