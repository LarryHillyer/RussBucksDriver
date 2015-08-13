<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="CreateFTPFiles.aspx.vb" Inherits="RussBucksDriver.CreateFTPFiles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label2" runat="server" Text="enter sport(lower case)"></asp:Label>
    <asp:TextBox ID="Sport1" runat="server"></asp:TextBox>

    <asp:Label ID="Label1" runat="server" Text="FTP Port Number: "></asp:Label>
    <asp:TextBox ID="PortNumber1" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click"/>
</asp:Content>
