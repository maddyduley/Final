<%@ Page Title="" Language="C#" MasterPageFile="~/DukeGroups.Master" AutoEventWireup="true" CodeBehind="CompanyEdit.aspx.cs" Inherits="Lab3.CompanyEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <asp:Label ID="JobName" runat="server" Text="Job Name:"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="CompanyList" runat="server" AutoPostBack="True" DataSourceID="Mentors" DataTextField="CompanyName" DataValueField="CompanyID">
        </asp:DropDownList>
        <asp:SqlDataSource ID="Mentors" runat="server" ConnectionString="<%$ ConnectionStrings:Lab3 %>" SelectCommand="Select CompanyID, CompanyName from Company"></asp:SqlDataSource>
        <asp:Button ID="bttnShowInfo" runat="server" Text="Show Info" OnClick="bttnShowInfo_Click" CausesValidation="false" />
        <br />
            Company Name
            <asp:TextBox ID="CompName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="CompName" Text="Required"></asp:RequiredFieldValidator>
            <br />
            Company Address:
            <asp:TextBox ID="CompAdd" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="CompAdd" Text="Required"></asp:RequiredFieldValidator>
            <br />
            Company Phone:
            <asp:TextBox ID="CompPhone" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="CompPhone" Text="Required"></asp:RequiredFieldValidator>
            <br />
    <asp:Button ID="updateJob" runat="server" Text="Update" OnClick="updateJob_Click" />
<asp:Label ID="lblStatus" runat="server"></asp:Label>
    <br />
    <asp:Button ID="CreateJob" runat="server" Text="Create" OnClick="CreateJob_Click" CausesValidation="false" />
    <br />

    <asp:Button ID="Goback" runat="server" Text="Home" OnClick="Goback_Click" CausesValidation="false" />
</asp:Content>
