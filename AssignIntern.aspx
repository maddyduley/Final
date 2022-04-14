<%@ Page Title="" Language="C#" MasterPageFile="~/DukeGroups.Master" AutoEventWireup="true" CodeBehind="AssignIntern.aspx.cs" Inherits="Lab3.AssignIntern" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:Label ID="Internapps" runat="server" Text="Intern Applications:"></asp:Label>
    <br />
    <br />
    <asp:GridView ID="JobList" runat="server" AutoGenerateColumns="False" DataSourceID="Schodata">
        <Columns>
            <asp:BoundField DataField="InternshipTitle" HeaderText="Title"  />
            <asp:BoundField DataField="FullName" HeaderText="Name"  />
            <asp:BoundField DataField="InternshipApplicationCurrentDate" HeaderText="Submission Date"  />
           <asp:TemplateField HeaderText="Resume">
               <itemTemplate>
                   <asp:HyperLink ID="reumesss" runat="server" Target="_blank" NavigateUrl='<%# "/TextFile/" + Eval("InternshipApplicationResume") %>'>Resume</asp:HyperLink>
               </itemTemplate>
           </asp:TemplateField>
        </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="Schodata" runat="server" ConnectionString="<%$ ConnectionStrings:Lab3 %>" SelectCommand="SELECT Inter.InternshipTitle, Stu.FirstName + ' '+ Stu.LastName AS FullName, Inta.InternshipApplicationCurrentDate, Inta.InternshipApplicationResume From Student Stu, Internship Inter, InternshipApplication Inta WHERE Stu.StudentID=Inta.StudentID AND Inta.InternshipID =Inter.InternshipID AND Inter.Status='Open'">
        </asp:SqlDataSource>

    
    <br />
    <br />
    <asp:Label ID="MentorName" runat="server" Text="Name:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:DropDownList ID="InternNameList" runat="server" AutoPostBack="True" DataSourceID="Intern" DataTextField="InternshipTitle" DataValueField="InternshipID">
    </asp:DropDownList>
        <asp:SqlDataSource ID="Intern" runat="server" ConnectionString="<%$ ConnectionStrings:Lab3 %>" SelectCommand="Select InternshipID, InternshipTitle FROM Internship"></asp:SqlDataSource>
    <br />
     <br />
    <asp:Label ID="StudentName" runat="server" Text="Student Name:"></asp:Label>
    <asp:DropDownList ID="StudentNameList" runat="server" AutoPostBack="True" DataSourceID="StudentNames" DataTextField="FullName" DataValueField="StudentID" >
    </asp:DropDownList>
        <asp:SqlDataSource ID="StudentNames" runat="server" ConnectionString="<%$ ConnectionStrings:Lab3 %>" SelectCommand="SELECT StudentID, [FirstName] +' '+ [LastName] AS FullName FROM [Student]"></asp:SqlDataSource>
     <br />
    <asp:Button ID="AssignInterns" runat="server" Text="Give Student Internship" Onclick="AwardIntern_Click" />
            <br />
    <asp:Label ID="AssignResult" runat="server" Text=""></asp:Label>
    <br />
    <br />
        <asp:Label ID="Emailsend" runat="server" Text=""></asp:Label>
    <br />
    <asp:Button ID="Goback" runat="server" Text="Home" OnClick="Goback_Click" CausesValidation="false" />
</asp:Content>
