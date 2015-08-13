<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Create Custom Schedule.aspx.vb" Inherits="RussBucksDriver.Create_Custom_Schedule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="CustomLabel1" runat="server" Text="Custom Schedule"></asp:Label>
    <asp:Calendar ID="CustomScheduleCalendar1" runat="server" OnSelectionChanged="CustomScheduleCalendar1_SelectionChanged"></asp:Calendar>
    <asp:CheckBoxList ID="CustomScheduleCheckBoxList1" runat="server" OnSelectedIndexChanged="CustomScheduleCheckBoxList1_SelectedIndexChanged"
         AutoPostBack="true" repeatColumns="3"></asp:CheckBoxList>
    <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click" />
    
</asp:Content>
