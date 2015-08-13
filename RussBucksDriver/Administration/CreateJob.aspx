<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateJob.aspx.vb" Inherits="RussBucksDriver.CreateJob" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Determine Cron Job Parameters</h3>
    <asp:Label ID="Label7" runat="server" Text="Cron Job Name:  "></asp:Label>
    <asp:TextBox ID="CronJobName1" runat="server"></asp:TextBox>
    <asp:Label ID="Error1" runat="server" Visible="false"></asp:Label>
    <br />
    <asp:Label ID="Label1" runat="server" Text="Select Sports  :"></asp:Label>
    <asp:RadioButtonList ID="SportList1" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" ></asp:RadioButtonList>
    <br />
    <asp:Label ID="Label8" runat="server" Text="Select CronJob Type  :"></asp:Label>
    <asp:RadioButtonList ID="CronJobTypeList1" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" ></asp:RadioButtonList>
    <asp:Label ID="Error2" runat="server" Visible="false"></asp:Label>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Select Pool Types :"></asp:Label><br />
    <asp:ListBox ID="PoolList1" runat="server" Height="42px"></asp:ListBox>
    <br />
    <asp:Label ID="Label6" runat="server" Text="Select Pool Names"></asp:Label>
    <asp:CheckBoxList ID="PoolAliasListCheckBox1" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"></asp:CheckBoxList>
    <asp:Label ID="Error3" runat="server" Visible="false"></asp:Label>
    <br />
    <asp:Table ID="Table1" runat="server">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>    
                <asp:Label ID="Label3" runat="server" Text="Season Start Date"></asp:Label>
            </asp:TableHeaderCell>
            <asp:TableHeaderCell>
               <asp:Label ID="Label4" runat="server" Text="Season Start Game Date"></asp:Label>
            </asp:TableHeaderCell>
            <asp:TableHeaderCell>
                <asp:Label ID="Label5" runat="server" Text="Season End Game Date"></asp:Label>
            </asp:TableHeaderCell>
        </asp:TableHeaderRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Calendar ID="StartDate1" runat="server"></asp:Calendar>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Calendar ID="StartGameDate1" runat="server"></asp:Calendar>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Calendar ID="EndGameDate1" runat="server"></asp:Calendar>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <br />
    <asp:CheckBox ID="CustomScheduleCheckBox1" runat="server" Text="Use Custom Schedule"/>&nbsp;&nbsp;&nbsp;&nbsp;

    <br />
    <br />

    <asp:CheckBox ID="UserTest1" runat="server" Text="    User Test"/>
    <br />
    <asp:CheckBox ID="Preseason1" runat="server" Text="     Preseason Job" />
    <br />
    <br />
    <h3>Save Cron Job</h3>
    <asp:Button ID="Save1" runat="server" Text="Submit Job" OnClick="Save1_Click"/>
    <br />

</asp:Content>
