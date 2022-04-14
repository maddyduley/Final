<%@ Page Title="" Language="C#" MasterPageFile="~/DukeGroups.Master" AutoEventWireup="true" CodeBehind="Calendar.aspx.cs" Inherits="Lab3.Calendar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="center">
    <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" BackColor="White" BorderColor="Black" DayNameFormat="Shortest" Font-Names="Times New Roman" Font-Size="10pt" ForeColor="Black" Height="587px" NextPrevFormat="FullMonth" TitleFormat="Month" Width="931px" >
        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" ForeColor="#333333" Height="10pt" />
        <DayStyle Width="14%" />
        <NextPrevStyle Font-Size="8pt" ForeColor="White" />
        <OtherMonthDayStyle ForeColor="#999999" />
        <SelectedDayStyle BackColor="#CC3333" ForeColor="White" />
        <SelectorStyle BackColor="#CCCCCC" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" Width="1%" />
        <TitleStyle BackColor="Black" Font-Bold="True" Font-Size="13pt" ForeColor="White" Height="14pt" />
        <TodayDayStyle BackColor="#CCCC99" />
    </asp:Calendar>
        </div>
    <br />
    <div class="center">
    <asp:GridView ID="GridView1" runat="server"  allowsorting="True" AutoGenerateColumns="False" DataKeyNames="EventID" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
        <Columns>
                <asp:BoundField HeaderText="Title" DataField="EventTitle"  />
                <asp:BoundField HeaderText="Description" DataField="EventDescription" ItemStyle-Wrap="true" />
                <asp:BoundField HeaderText="Location" DataField="EventLocation"  />
                <asp:BoundField HeaderText="Date" DataField="EventDate"  />
        </Columns>
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F7F7F7" />
        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
        <SortedDescendingCellStyle BackColor="#E5E5E5" />
        <SortedDescendingHeaderStyle BackColor="#242121" />
            </asp:GridView>
    <br />
    <asp:Label ID="EventLabel" runat="server" Text=""></asp:Label>
    <br />
    <asp:GridView ID="GridView2" runat="server"  allowsorting="True" AutoGenerateColumns="False" DataKeyNames="OpportunityID" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" >
                <Columns>
                <asp:BoundField HeaderText="Title" DataField="OpportunityTitle"  />
                <asp:BoundField HeaderText="Description" DataField="OpportunityDesc" ItemStyle-Wrap="true"  />
                <asp:BoundField HeaderText="Location" DataField="OppLocation"  />
                <asp:BoundField HeaderText="Date" DataField="Date"  />
        </Columns>
                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#242121" />
            </asp:GridView>
    <br />
    <asp:Label ID="OpportunityLabel" runat="server" Text=""></asp:Label>
    <br />
    <br />
        </div>
</asp:Content>
