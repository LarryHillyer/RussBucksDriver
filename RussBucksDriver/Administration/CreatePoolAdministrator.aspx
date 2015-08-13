<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="CreatePoolAdministrator.aspx.vb" Inherits="RussBucksDriver.CreatePoolAdministrator" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    
    <asp:Label ID="Label3" runat="server" Text="Enter Pool Name: "></asp:Label>
    <asp:TextBox ID="PoolName1" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label1" runat="server" ></asp:Label>
    <br />
    <asp:Label ID="Label5" runat="server" Text="Enter Licensee UserName:  "></asp:Label>
    <asp:TextBox ID="LicenseeName1" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label4" runat="server" Text="Enter Administrator UserName:  "></asp:Label>
    <asp:TextBox ID="UserName1" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label2" runat="server" ></asp:Label>
    <br />
    <asp:Label ID="Label6" runat="server" Text="Enter Pool Code:  "></asp:Label>
    <asp:TextBox ID="PoolCode1" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click"/>
</asp:Content>
