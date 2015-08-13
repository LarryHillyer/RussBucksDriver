<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ContinueCronJob.aspx.vb" Inherits="RussBucksDriver.ContinueCronJob" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Cron Job Name:  "></asp:Label>
    <asp:TextBox ID="CronJobName1" runat="server"></asp:TextBox>
    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label><br />
    <br />
    <asp:Button ID="Button1" runat="server" Text="Submit"  OnClick="Button1_Click" />
</asp:Content>
