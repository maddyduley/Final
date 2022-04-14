<%@ Page Title="" Language="C#" MasterPageFile="~/DukeGroups.Master" AutoEventWireup="true" CodeBehind="AssignJob.aspx.cs" Inherits="Lab3.AssignJob" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <br />
    <asp:Label ID="JobApps" runat="server" Text="Job Applications:"></asp:Label>
    <br />
    <br />
    <asp:GridView ID="JobList" runat="server" AutoGenerateColumns="False" DataSourceID="JobAppd">
        <Columns>
            <asp:BoundField DataField="JobTitle" HeaderText="Job" SortExpression="JobTitle" />
            <asp:BoundField DataField="FullName" HeaderText="Student Name"  />
            <asp:BoundField DataField="JobApplicationDescription" HeaderText="Details"  />
            <asp:BoundField DataField="JobApplicationDueDate" HeaderText="Submission Date"  />
                      <asp:TemplateField HeaderText="Resumes">
               <itemTemplate>
                   <asp:HyperLink ID="reumesss" runat="server" Target="_blank" NavigateUrl='<%# "/TextFile/" + Eval("JobApplicationResume") %>'>Resume</asp:HyperLink>
               </itemTemplate>
           </asp:TemplateField>
        </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="JobAppd" runat="server" ConnectionString="<%$ ConnectionStrings:Lab3 %>" SelectCommand="SELECT Jo.JobTitle, Stu.FirstName + ' '+ Stu.LastName AS FullName, Ja.JobApplicationDescription, Ja.JobApplicationDueDate, Ja.JobApplicationResume From Student Stu, Job Jo, JobApplication Ja WHERE Stu.StudentID=Ja.StudentID AND Jo.JobID=Ja.JobID AND Jo.JobStatus='Open'">
        </asp:SqlDataSource>



    <br />
    <asp:Label ID="JobName" runat="server" Text="Name:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:DropDownList ID="JobNameList" runat="server" AutoPostBack="True" DataSourceID="Jobs" DataTextField="JobName" DataValueField="JobID">
    </asp:DropDownList>
        <asp:SqlDataSource ID="Jobs" runat="server" ConnectionString="<%$ ConnectionStrings:Lab3 %>" SelectCommand="Select JobID, JobTitle AS JobName from Job WHERE JobStatus='Open'"></asp:SqlDataSource>
    <br />
     <br />
    <asp:Label ID="StudentName" runat="server" Text="Student Name:"></asp:Label>
    <asp:DropDownList ID="StudentNamedList" runat="server" AutoPostBack="True" DataSourceID="StudentNames" DataTextField="FullName" DataValueField="StudentID" >
    </asp:DropDownList>
        <asp:SqlDataSource ID="StudentNames" runat="server" ConnectionString="<%$ ConnectionStrings:Lab3 %>" SelectCommand="SELECT StudentID, [FirstName] +' '+ [LastName] AS FullName FROM [Student]"></asp:SqlDataSource>
     <br />
    <asp:Button ID="AwardJob" runat="server" Text="Award Student with Job" OnClick="AwardJob_Click" />
            <br />
    <asp:Label ID="JobResult" runat="server" Text=""></asp:Label>
            <br />
    <br />
    <asp:Label ID="Emailsend" runat="server" Text=""></asp:Label>
    <br />
    <asp:Button ID="Goback" runat="server" Text="Home" OnClick="Goback_Click" CausesValidation="false" />
</asp:Content>
