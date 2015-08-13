<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="CreateAppFolders.aspx.vb" Inherits="RussBucksDriver.CreateAppFolders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <asp:Label ID="Label3" runat="server" Text="Web Site Root Folder: "></asp:Label>
    <asp:TextBox ID="RootFolder1" runat="server" Width="700px"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label4" runat="server" Text="Driver Site Root Folder: "></asp:Label>
    <asp:TextBox ID="DriverRootFolder1" runat="server" Width="700px"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label5" runat="server" Text="Test Cron Job Folder: "></asp:Label>
    <asp:TextBox ID="TestCronJobFolder1" runat="server" Width="700px" ></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Schedule Scrape Cron Job Folder"></asp:Label>
    <asp:TextBox ID="ScheduleCronJobFolder1" runat="server" Width="700px" ></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Text="Score Scrape Cron Job Folder"></asp:Label>
    <asp:TextBox ID="ScoreCronJobFolder1" runat="server" Width="700px" ></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" Text="Submit" Onclick="Button1_Click"/>
    <br />

</asp:Content>
