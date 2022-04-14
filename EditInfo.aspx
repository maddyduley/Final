<%@ Page Title="" Language="C#" MasterPageFile="~/DukeGroups.Master" AutoEventWireup="true" CodeBehind="EditInfo.aspx.cs" Inherits="Lab3.EditInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:Button ID="EditMember" runat="server" Text="Edit Member" OnClick="EditMember_Click" />
   

        <asp:Button ID="CompanyEdit" runat="server" Text="Edit Company" Onclick="CompanyEdit_Click" />
    <asp:Button ID="ContactEdit" runat="server" Text="Edit Contact" Onclick="ContactEdit_Click" />
    <asp:Button ID="EventEdit" runat="server" Text="Edit Event" Onclick="EventEdit_Click" />
</asp:Content>
