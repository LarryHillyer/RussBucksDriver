<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="KillCronJob.aspx.vb" Inherits="RussBucksDriver.KillCronJob" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Delete Cron Job Data"></asp:Label><br />
    <asp:CheckBoxList ID="CronJobList1" runat="server"></asp:CheckBoxList>
    <asp:Button ID="Button1" runat="server" Text="Delete" ONclick="Button1_Click"/>
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Text="Clear Temp Tables"></asp:Label><br />
    <asp:Button ID="Button2" runat="server" Text="Clear" OnClick="Button2_Click"/>

</asp:Content>
