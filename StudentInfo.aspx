<%@ Page Title="" Language="C#" MasterPageFile="~/DukeGroups.Master" AutoEventWireup="true" CodeBehind="StudentInfo.aspx.cs" Inherits="Lab3.StudentInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:Button ID="EditStudent" runat="server" Text="Edit Student" OnClick="EditStudent_Click"/>


    <asp:Button ID="AssignMentor" runat="server" Text="Assign Mentor" OnClick="AssignMentor_Click" />


    <asp:Button ID="Search" runat="server" Text="Search for Student" OnClick="Search_Click" />
</asp:Content>
