<%@ Page Title="" Language="C#" MasterPageFile="~/DukeGroups.Master" AutoEventWireup="true" CodeBehind="ApplyJob.aspx.cs" Inherits="Lab3.ApplyJob" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <br />
        <asp:TextBox ID="Description" runat="server" PlaceHolder="Message" Height="250px" Width="1082px" TextMode="MultiLine"></asp:TextBox>
            <br />
    <asp:RequiredFieldValidator ID="RequiredText" runat="server" ControlToValidate="Description" Text="Required"></asp:RequiredFieldValidator>
            <br />
     <br />
    <asp:Button ID="ApplyJobs" runat="server" Text="Apply to Job" OnClick="ApplyJobs_Click"/>
            <br />
    <asp:Label ID="Results" runat="server" Text=""></asp:Label>
    <br />
    <asp:Button ID="Goback" runat="server" Text="Home" OnClick="Goback_Click" CausesValidation="false" />
</asp:Content>
 