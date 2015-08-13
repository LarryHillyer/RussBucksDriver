<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="CreateLicensee.aspx.vb" Inherits="RussBucksDriver.CreateLicensee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Licensee E-Mail Address:  "></asp:Label>
    <asp:TextBox ID="LicenseeEmailAddress1" runat="server"></asp:TextBox>
    <br /><br />
    <asp:Button ID="Button1" runat="server" Text="Submit" Onclick="CreateLicensee_Click"/>
</asp:Content>
