<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="DeletePoolParameters.aspx.vb" Inherits="RussBucksDriver.DeletePoolParameters" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <asp:Label ID="Label2" runat="server" Text="Delete Pool:  "></asp:Label>
    <asp:TextBox ID="PoolName1" runat="server"></asp:TextBox>
    <asp:Label ID="Label3" runat="server" ></asp:Label><br />
    <asp:Button ID="Button2" runat="server" Text="Delete" OnClick="Button2_Click"/>
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Delete All Pools:  "></asp:Label>
    <asp:Button ID="Button1" runat="server" Text="Delete" OnClick="Button1_Click" />
</asp:Content>
