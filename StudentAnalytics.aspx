<%@ Page Title="" Language="C#" MasterPageFile="~/DukeGroups.Master" AutoEventWireup="true" CodeBehind="StudentAnalytics.aspx.cs" Inherits="Lab3.StudentAnalytics" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:GridView ID="JobView" runat="server" AutoGenerateColumns="false" DataValueField="JobID" DataKeyNames="JobID"  >
         <Columns>
                <asp:BoundField HeaderText="Title" DataField="JobTitle" SortExpression="JobTitle" />
                <asp:BoundField HeaderText="Company" DataField="CompanyName" SortExpression="CompanyName" />
             <asp:TemplateField HeaderText="Job Analytics">   
             <itemtemplate>
                 <asp:LinkButton ID="lnkSelect" Text="More Info" runat="server" CommandArgument='<%# Eval("JobID") %>' Onclick="NavigateJob"/>
             </itemtemplate> 
                
                 </asp:TemplateField>
        </Columns>
    </asp:GridView>
        <asp:GridView ID="InternshipView" runat="server" AutoGenerateColumns="false" DataValueField="InternshipID" DataKeyNames="InternshipID"  >
         <Columns>
                <asp:BoundField HeaderText="Title" DataField="InternshipTitle" SortExpression="InternshipTitle" />
                <asp:BoundField HeaderText="Company" DataField="CompanyName" SortExpression="CompanyName" />
             <asp:TemplateField HeaderText="Internship Analytics">   
             <itemtemplate>
                 <asp:LinkButton ID="LinkButton1" Text="More Info" runat="server" CommandArgument='<%# Eval("InternshipID") %>' Onclick="NavigateIntern"/>
             </itemtemplate> 
                
                 </asp:TemplateField>
        </Columns>
    </asp:GridView>
        <asp:GridView ID="ScholarshipView" runat="server" AutoGenerateColumns="false" DataValueField="ScholarshipID" DataKeyNames="ScholarshipID"  >
         <Columns>
                <asp:BoundField HeaderText="Title" DataField="ScholarshipName" SortExpression="ScholarshipName" />
                <asp:BoundField HeaderText="Year" DataField="ScholarshipYear" SortExpression="ScholarshipYear" />
             <asp:TemplateField HeaderText="Scholarship Analytics">   
             <itemtemplate>
                 <asp:LinkButton ID="LinkButton2" Text="More Info" runat="server" CommandArgument='<%# Eval("ScholarshipID") %>' Onclick="NavigateScholar"/>
             </itemtemplate> 
                
                 </asp:TemplateField>
        </Columns>
    </asp:GridView>
        <asp:GridView ID="OppGrid" runat="server" AutoGenerateColumns="false" DataValueField="OpportunityID" DataKeyNames="OpportunityID"  >
         <Columns>
                <asp:BoundField HeaderText="Title" DataField="OpportunityTitle" SortExpression="OpportunityTitle" />
                <asp:BoundField HeaderText="Date" DataField="Date" SortExpression="Date" />
             <asp:TemplateField HeaderText="Scholarship Analytics">   
             <itemtemplate>
                 <asp:LinkButton ID="OppNav" Text="More Info" runat="server" CommandArgument='<%# Eval("OpportunityID") %>' Onclick="OppNav_Click"/>
             </itemtemplate> 
                
                 </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
