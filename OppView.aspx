<%@ Page Title="" Language="C#" MasterPageFile="~/DukeGroups.Master" AutoEventWireup="true" CodeBehind="OppView.aspx.cs" Inherits="Lab3.OppView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:GridView ID="JobView" runat="server" AutoGenerateColumns="false" DataValueField="OpportunityID" DataKeyNames="OpportunityID"  >
         <Columns>
                <asp:BoundField HeaderText="Title" DataField="OpportunityTitle" SortExpression="OpportunityTitle" />
             <asp:TemplateField HeaderText="Additional Info">   
             <itemtemplate>
                 <asp:LinkButton ID="lnkSelect" Text="More Info" runat="server" CommandArgument='<%# Eval("OpportunityID") %>' Onclick="NavigateClick"/>
             </itemtemplate> 
                
                 </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
