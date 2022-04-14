<%@ Page Title="" Language="C#" MasterPageFile="~/DukeGroups.Master" AutoEventWireup="true" CodeBehind="ContactEdit.aspx.cs" Inherits="Lab3.ContactEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <br />
            <asp:Label ID="JobName" runat="server" Text="Job Name:"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ContactList" runat="server" AutoPostBack="True" DataSourceID="Mentors" DataTextField="ContactName" DataValueField="ContactID">
        </asp:DropDownList>
        <asp:SqlDataSource ID="Mentors" runat="server" ConnectionString="<%$ ConnectionStrings:Lab3 %>" SelectCommand="Select ContactID, ContactName from Contact"></asp:SqlDataSource>
        <asp:Button ID="bttnShowInfo" runat="server" Text="Show Info" OnClick="bttnShowInfo_Click" CausesValidation="false" />
        <br />
            Contact Name:
            <asp:TextBox ID="ContactName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ContactName" Text="Required"></asp:RequiredFieldValidator>
            <br />
            Contact Phone Number:
            <asp:TextBox ID="ContactPhone" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ContactPhone" Text="Required"></asp:RequiredFieldValidator>
            <br />
            Contact Email:
            <asp:TextBox ID="ContactEmail" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ContactEmail" Text="Required"></asp:RequiredFieldValidator>
            <br />
    <asp:Button ID="updateJob" runat="server" Text="Update" OnClick="updateJob_Click" />
<asp:Label ID="lblStatus" runat="server"></asp:Label>
    <br />
    <asp:Button ID="CreateJob" runat="server" Text="Create" OnClick="CreateJob_Click" CausesValidation="false" />
    <br />
    <asp:Button ID="Goback" runat="server" Text="Home" OnClick="Goback_Click" CausesValidation="false" />
</asp:Content>
