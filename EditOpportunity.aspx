<%@ Page Title="" Language="C#" MasterPageFile="~/DukeGroups.Master" AutoEventWireup="true" CodeBehind="EditOpportunity.aspx.cs" Inherits="Lab3.EditOpportunity" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                    <asp:Label ID="JobName" runat="server" Text="Opportunity Name:"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="OppList" runat="server" AutoPostBack="True" DataSourceID="Mentors" DataTextField="OpportunityTitle" DataValueField="OpportunityID">
        </asp:DropDownList>
        <asp:SqlDataSource ID="Mentors" runat="server" ConnectionString="<%$ ConnectionStrings:Lab3 %>" SelectCommand="Select OpportunityID, OpportunityTitle from Opportunities"></asp:SqlDataSource>
        <asp:Button ID="bttnShowInfo" runat="server" Text="Show Info" OnClick="bttnShowInfo_Click" CausesValidation="false" />
        <br />
            Opportunity Name
            <asp:TextBox ID="OppName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="OppName" Text="Required"></asp:RequiredFieldValidator>
            <br />
            Opportunity Date:
            <asp:TextBox ID="OppDat" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="OppDat" Text="Required"></asp:RequiredFieldValidator>
            <br />
            Opportunity Description:
            <asp:TextBox ID="OppDesc" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="OppDesc" Text="Required"></asp:RequiredFieldValidator>
            <br />
            Opportunity Location:
            <asp:TextBox ID="Location" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Location" Text="Required"></asp:RequiredFieldValidator>
            <br />
    <asp:Button ID="updateJob" runat="server" Text="Update" OnClick="updateJob_Click" />
<asp:Label ID="lblStatus" runat="server"></asp:Label>
    <br />
    <asp:Button ID="CreateEvents" runat="server" Text="Create" OnClick="CreateEvent_Click" CausesValidation="false" />
    <br />
    <asp:Button ID="Goback" runat="server" Text="Home" OnClick="Goback_Click" CausesValidation="false" />
</asp:Content>
