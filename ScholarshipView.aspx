<%@ Page Title="" Language="C#" MasterPageFile="~/DukeGroups.Master" AutoEventWireup="true" CodeBehind="ScholarshipView.aspx.cs" Inherits="Lab3.ScholarshipView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DropDownList ID="TypeList" runat="server">
        <asp:ListItem Text="A-Z" Value=" Sc.ScholarshipName ASC"></asp:ListItem>
        <asp:ListItem Text="Z-A" Value=" Sc.ScholarshipName Desc"></asp:ListItem>
        <asp:ListItem Text="Newest" Value=" Sc.Upload ASC"></asp:ListItem>
        <asp:ListItem Text="Oldest" Value=" Sc.Upload Desc"></asp:ListItem>
    </asp:DropDownList>
    <asp:Button ID="refresh" runat="server" Text="Update" Onclick="RefreshResults" />
    <asp:GridView ID="ScholarView" runat="server" AutoGenerateColumns="false" DataValueField="ScholarshipID" DataKeyNames="ScholarshipID"  >
         <Columns>
                <asp:BoundField HeaderText="Name" DataField="ScholarshipName" SortExpression="ScholarshipName" />
                <asp:BoundField HeaderText="Year" DataField="ScholarshipYear" SortExpression="ScholarshipYear" />
                <asp:BoundField HeaderText="Amount" DataField="ScholarshipAmount" SortExpression="ScholarshipAmount" />
             <asp:TemplateField HeaderText="Additional Info">   
             <itemtemplate>
                 <asp:LinkButton ID="lnkSelect" Text="More Info" runat="server" CommandArgument='<%# Eval("ScholarshipID") %>' Onclick="NavigateClick"/>
             </itemtemplate> 
                
                 </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
