<%@ Page Title="" Language="C#" MasterPageFile="~/DukeGroups.Master" AutoEventWireup="true" CodeBehind="StudentLogedIn.aspx.cs" Inherits="Lab3.StudentLogedIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:Button ID="ApplyScholar" runat="server" Text="Apply for Scholarship" OnClick="ApplyScholar_Click" CssClass="topbuttons" />
    <asp:Button ID="ApplyJob" runat="server" Text="Apply for Job" OnClick="ApplyJob_Click" CssClass="topbuttons" />
    <asp:Button ID="ApplyIntern" runat="server" Text="Apply for Internship" OnClick="ApplyIntern_Click" CssClass="topbuttons"  />
    
    <div class="rightside">
    <asp:Button ID="UploadResume" runat="server" Text="Upload Resume" OnClick="UploadResume_Click" CssClass="rightbuttons" Height="65px" Width="200px"/>
        <br />
        <br />
    <asp:Button ID="Calandar" runat="server" Text="View Dates on Calendar" OnClick="Calandar_Click" CssClass="rightbuttons" Height="65px" Width="200px" />
    <br />
    <br />
    <asp:Button ID="SignupOpp" runat="server" Text="Sign up for Opportunities" OnClick="SignupOpp_Click" CssClass="rightbuttons" Height="65px" Width="200px" />
        <br />
        <br />
    <asp:Button ID="Image" runat="server" Text="Upload Image" OnClick="Image_Click" CssClass="rightbuttons" Height="65px" Width="200px"/>
    <br />
    <br />
    <asp:Button ID="Messages" runat="server" Text="View Messages" OnClick="Messages_Click" CssClass="rightbuttons" Height="65px" Width="200px"/>
    </div>
    
    
    <asp:GridView ID="grdStudentTable" runat="server" DataSourceID="sqlsrc" AllowSorting="true" AutoGenerateColumns="false" DataKeyNames="StudentID" GridLines="None" Width="1093px">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" Width="150px" Height="150px" ImageUrl='<%# "/Images/" + Eval("Image")%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="FirstName" />
            <asp:BoundField DataField="LastName" />
            <asp:BoundField DataField="Email" />
            <asp:BoundField DataField="PhoneNumber" />
            <asp:BoundField DataField="UniversityYear" />
            <asp:BoundField DataField="Major" />
            <asp:BoundField DataField="GradYear" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:HyperLink ID="reumesss" runat="server" Target="_blank" NavigateUrl='<%# "/TextFile/" + Eval("Files") %>'>Resume</asp:HyperLink>
                </ItemTemplate>

            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="sqlsrc" runat="server" ConnectionString="<%$ ConnectionStrings:Lab3 %>"
        SelectCommand="Select * from Student WHERE UserName=@UserNamed">
        <SelectParameters>
            <asp:SessionParameter Name="UserNamed" SessionField="Username" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>



    <asp:Button ID="EditInfo" runat="server" Text="Edit Information" OnClick="EditInfo_Click" CssClass="topbuttons" />
    <br />
    <asp:Label ID="Mentor" runat="server" Text="Mentor:"></asp:Label>
    <asp:GridView ID="MentorGrid" runat="server" AutoGenerateColumns="false" GridLines="None">
        <Columns>
            <asp:BoundField DataField="Mentor_Name" />
        </Columns>
    </asp:GridView>
    <br />

    <br />
</asp:Content>
