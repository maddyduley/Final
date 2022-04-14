<%@ Page Title="" Language="C#" MasterPageFile="~/DukeGroups.Master" AutoEventWireup="true" CodeBehind="ScholarMiddle.aspx.cs" Inherits="Lab3.ScholarMiddle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:Button ID="EditScholarship" runat="server" Text="Edit Scholarship" OnClick="EditScholarship_Click" />
    <asp:Button ID="AssignScholarship" runat="server" Text="Assign Scholarship" OnClick="AssignScholarship_Click" />
</asp:Content>
