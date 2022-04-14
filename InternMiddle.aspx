<%@ Page Title="" Language="C#" MasterPageFile="~/DukeGroups.Master" AutoEventWireup="true" CodeBehind="InternMiddle.aspx.cs" Inherits="Lab3.InternMiddle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:Button ID="EditInternship" runat="server" Text="Edit Internship" OnClick="EditInternship_Click" />


        <asp:Button ID="AssignInternship" runat="server" Text="Assign Internship" OnClick="AssignInternship_Click" />

</asp:Content>
