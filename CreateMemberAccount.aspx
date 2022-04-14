<%@ Page Title="" Language="C#" MasterPageFile="~/DukeGroups.Master" AutoEventWireup="true" CodeBehind="CreateMemberAccount.aspx.cs" Inherits="Lab3.CreateMemberAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <br />
    <br />
    <strong>Create Member Account</strong><br />
    First Name:&nbsp;
            <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredText" runat="server" ControlToValidate="txtFirstName" Text="Required"></asp:RequiredFieldValidator>
    <br />
    Last Name:
            <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLastName" Text="Required"></asp:RequiredFieldValidator>

    <br />
    Email Address:
            <asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmail" Text="Required"></asp:RequiredFieldValidator>
    <br />
    Phone Number:
            <asp:TextBox ID="txtPhone" runat="server" TextMode="Phone"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPhone" Text="Required"></asp:RequiredFieldValidator>
    <br />
    Grad Year(Ex. 2022):
            <asp:TextBox ID="txtGradYear" runat="server" TextMode="Number"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtGradYear" Text="Required"></asp:RequiredFieldValidator>
    <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Out of Range" ControlToValidate="txtGradYear" MinimumValue="1950" MaximumValue="2022" Type="double"></asp:RangeValidator>
    <br />
    Title:
            <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtTitle" Text="Required"></asp:RequiredFieldValidator>
    <br />
    Username:
            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtUsername" Text="Required"></asp:RequiredFieldValidator>
    <br />
    Password:
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtPassword" Text="Required"></asp:RequiredFieldValidator>
    <br />
    Re-Enter Password:
            <asp:TextBox ID="txtCheckPass" runat="server" TextMode="Password"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtCheckPass" Text="Required"></asp:RequiredFieldValidator>
    <br />
    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Passwords don't match" ControlToCompare="txtPassword" ControlToValidate="txtCheckPass"></asp:CompareValidator>
    <br />
    <asp:CheckBox ID="CheckBox1" runat="server" />
    <asp:Label ID="Label1" runat="server" Text="I acknowledge my information will be public to members of The Ole School Group"></asp:Label>
    <br />
    <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
    <br />
    <asp:CheckBox ID="CheckBox2" runat="server" />
    <asp:Label ID="Label2" runat="server" Text="Sign up for emails"></asp:Label>

    <br />

    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
    <br />
    <asp:Label ID="lblStatus" runat="server"></asp:Label>
    <br />


</asp:Content>
