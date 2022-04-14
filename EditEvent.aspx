<%@ Page Title="" Language="C#" MasterPageFile="~/DukeGroups.Master" AutoEventWireup="true" CodeBehind="EditEvent.aspx.cs" Inherits="Lab3.EditEvent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                <br />
                <asp:Label ID="JobName" runat="server" Text="Event Name:"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="EventList" runat="server" AutoPostBack="True" DataSourceID="Mentors" DataTextField="EventTitle" DataValueField="EventID">
        </asp:DropDownList>
        <asp:SqlDataSource ID="Mentors" runat="server" ConnectionString="<%$ ConnectionStrings:Lab3 %>" SelectCommand="Select EventID, EventTitle from Event"></asp:SqlDataSource>
        <asp:Button ID="bttnShowInfo" runat="server" Text="Show Info" OnClick="bttnShowInfo_Click" CausesValidation="false" />
        <br />
            Event Name
            <asp:TextBox ID="EvenName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="EvenName" Text="Required"></asp:RequiredFieldValidator>
            <br />
            Event Date:
            <asp:TextBox ID="EvenDate" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="EvenDate" Text="Required"></asp:RequiredFieldValidator>
            <br />
            Event Description:
            <asp:TextBox ID="EvenDesc" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="EvenDesc" Text="Required"></asp:RequiredFieldValidator>
            <br />
            Event Location:
            <asp:TextBox ID="Location" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Location" Text="Required"></asp:RequiredFieldValidator>
            <br />
    <asp:Button ID="updateJob" runat="server" Text="Update" OnClick="updateJob_Click" />
<asp:Label ID="lblStatus" runat="server"></asp:Label>
    <br />
    <asp:Button ID="CreateEvent" runat="server" Text="Create" OnClick="CreateEvent_Click" CausesValidation="false" />
    <br />
        <asp:Button ID="DeleteEvent" runat="server" Text="Delete" OnClick="DeleteEvent_Click" CausesValidation="false" />
    <br />
    <asp:Button ID="Goback" runat="server" Text="Home" OnClick="Goback_Click" CausesValidation="false" />
</asp:Content>
