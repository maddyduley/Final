<%@ Page Title="" Language="C#" MasterPageFile="~/DukeGroups.Master" AutoEventWireup="true" CodeBehind="StudentSearch.aspx.cs" Inherits="Lab3.StudentSearch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:Label ID="Searchlbl" runat="server" Text="Search Student" Font-Bold="true"></asp:Label>
    <br />
    <br />
    <asp:TextBox ID="Searchtxt" runat="server" placeholder="Student Name"></asp:TextBox>
    <br />
    <asp:Button ID="Search4Student" runat="server" Text="Search" OnClick="Search4Student_Click" class="btn btn-primary" />
    <br />
    <br />
    <asp:GridView ID="StudentsView" runat="server"  AllowSorting="True" AllowPaging="True" AutoGenerateColumns="False"  EmptyDataText="No match" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" >
       
        <AlternatingRowStyle BackColor="#DCDCDC" />
       
        <columns> 
           <asp:TemplateField HeaderText="Image">
              <ItemTemplate>
                  <asp:Image ID="Image1" runat="server" Width="150px" Height="150px" ImageUrl='<%# "/Images/" + Eval("Image")%>' />
              </ItemTemplate>
           </asp:TemplateField>
           <asp:BoundField ReadOnly="True" HeaderText="First Name" ItemStyle-HorizontalAlign="Center" Datafield="FirstName"  >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
           <asp:BoundField ReadOnly="True" HeaderText="Last Name" ItemStyle-HorizontalAlign="Center" Datafield="LastName"  >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
           <asp:BoundField ReadOnly="True" HeaderText="Email" ItemStyle-HorizontalAlign="Center" Datafield="Email"  >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
           <asp:BoundField ReadOnly="True" HeaderText="Phone Number" ItemStyle-HorizontalAlign="Center" Datafield="PhoneNumber"  >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
           <asp:BoundField ReadOnly="True" HeaderText="University Year" ItemStyle-HorizontalAlign="Center" Datafield="UniversityYear"  >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
           <asp:BoundField ReadOnly="True" HeaderText="Major" ItemStyle-HorizontalAlign="Center" Datafield="Major" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
           <asp:BoundField ReadOnly="True" HeaderText="Graduation Year" ItemStyle-HorizontalAlign="Center" Datafield="GradYear"  >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
           <asp:BoundField ReadOnly="True" HeaderText="User Name" ItemStyle-HorizontalAlign="Center" Datafield="UserName"  >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
           <asp:TemplateField HeaderText="Resumes">
               <itemTemplate>
                   <asp:HyperLink ID="reumesss" runat="server" NavigateUrl='<%# "/TextFile/" + Eval("Files") %>'>Resume</asp:HyperLink>
               </itemTemplate>

           </asp:TemplateField>

       </columns>

        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#0000A9" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#000065" />

    </asp:GridView>
    <br />

    <asp:Button ID="Goback" runat="server" Text="Home" OnClick="Goback_Click" CausesValidation="false" />

</asp:Content>
