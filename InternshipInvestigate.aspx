<%@ Page Title="" Language="C#" MasterPageFile="~/DukeGroups.Master" AutoEventWireup="true" CodeBehind="InternshipInvestigate.aspx.cs" Inherits="Lab3.InternshipInvestigate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <asp:Label ID="Label4" runat="server" Text="Internship Title"></asp:Label>
    <br />
    <asp:Label ID="lblTitle" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Internship Description"></asp:Label>
    <br />
    <asp:Label ID="lblDDescrip" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Text="Starting Date"></asp:Label>
    <br />
    <asp:Label ID="lblDateStart" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    <asp:Label ID="Label3" runat="server" Text="Ending Date"></asp:Label>
    <br />
    <asp:Label ID="lblDate" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    <asp:Label ID="Label5" runat="server" Text="Company Name"></asp:Label>
    <br />
    <asp:Label ID="lblCompanyName" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    <asp:Label ID="Label6" runat="server" Text="Company Address"></asp:Label>
    <br />
    <asp:Label ID="lblCompanyAddress" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    <asp:Label ID="Label7" runat="server" Text="Contact Name"></asp:Label>
    <br />
    <asp:Label ID="lblContactName" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    <asp:Label ID="Label8" runat="server" Text="Contact Phone Number"></asp:Label>
    <br />
    <asp:Label ID="lblContactPhone" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    <asp:Label ID="Label9" runat="server" Text="Contact Email"></asp:Label>
    <br />
    <asp:Label ID="lblContactEmail" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    <asp:Button ID="Like" runat="server" Text="Like" OnClick="Like_Click" />
    <asp:Button ID="Apply" runat="server" Text="Apply" OnClick="Apply_Click" />
    <asp:Button ID="goBack" runat="server" Text="Back" OnClick="goBack_Click" />

</asp:Content>
