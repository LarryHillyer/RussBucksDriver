<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="CreateSportDatesOfTheWeeks.aspx.vb" Inherits="RussBucksDriver.CreateSportDatesOfTheWeeks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <asp:Table ID="Table1" runat="server">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>
               <asp:Label ID="Label4" runat="server" Text="Season Start Game Date"></asp:Label>
            </asp:TableHeaderCell>
            <asp:TableHeaderCell>
                <asp:Label ID="Label5" runat="server" Text="Season End Game Date"></asp:Label>
            </asp:TableHeaderCell>
        </asp:TableHeaderRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Calendar ID="StartGameDate1" runat="server" ></asp:Calendar>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Calendar ID="EndGameDate1" runat="server" ></asp:Calendar>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table><br />
    <asp:Label ID="Label1" runat="server" Text="League:  "></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
    <asp:Label ID="Label2" runat="server" Text="Season Phase:  "></asp:Label>
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox><br />
    <br />
    <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click"/>
</asp:Content>
