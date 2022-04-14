<%@ Page Title="" Language="C#" MasterPageFile="~/DukeGroups.Master" AutoEventWireup="true" CodeBehind="Job.aspx.cs" Inherits="Lab3.Job" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:Label ID="JobName" runat="server" Text="Job Name:"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="JobList" runat="server" AutoPostBack="True" DataSourceID="Mentors" DataTextField="JobTitle" DataValueField="JobID">
        </asp:DropDownList>
        <asp:SqlDataSource ID="Mentors" runat="server" ConnectionString="<%$ ConnectionStrings:Lab3 %>" SelectCommand="Select JobID, JobTitle from Job"></asp:SqlDataSource>
        <asp:Button ID="bttnShowInfo" runat="server" Text="Show Info" OnClick="bttnShowInfo_Click" CausesValidation="false" />
        <br />
            Title:
            <asp:TextBox ID="JobTitlebox" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="JobTitlebox" Text="Required"></asp:RequiredFieldValidator>
            <br />
                Description:
            <asp:TextBox ID="DescriptionBox" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DescriptionBox" Text="Required"></asp:RequiredFieldValidator>
            <br />
            Start Date:
            <asp:TextBox ID="DateStart" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DateStart" Text="Required"></asp:RequiredFieldValidator>
            <br />
    <asp:Button ID="updateJob" runat="server" Text="Update" OnClick="updateJob_Click" />
<asp:Label ID="lblStatus" runat="server"></asp:Label>
    <br />
    <asp:Button ID="CreateJob" runat="server" Text="Create" OnClick="CreateJob_Click" CausesValidation="false" />
    <br />
    <asp:Button ID="Goback" runat="server" Text="Home" OnClick="Goback_Click" CausesValidation="false" />
</asp:Content>
