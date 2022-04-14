<%@ Page Title="" Language="C#" MasterPageFile="~/DukeGroups.Master" AutoEventWireup="true" CodeBehind="OppStudentSignup.aspx.cs" Inherits="Lab3.OppStudentSignup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                    <br />
        <asp:TextBox ID="Description" runat="server" PlaceHolder="Comments"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredText" runat="server" ControlToValidate="Description" Text="Required"></asp:RequiredFieldValidator>
     <br />
    <asp:Button ID="ApplyJobs" runat="server" Text="Sign up for Opportunity" OnClick="ApplyJobs_Click"/>
    <asp:Label ID="Results" runat="server" Text=""></asp:Label>
    <br />
    <asp:Button ID="Goback" runat="server" Text="Home" OnClick="Goback_Click" CausesValidation="false" />
</asp:Content>
