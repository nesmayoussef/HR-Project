<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="finSalary.aspx.cs" Inherits="HR_project.finSalary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" DataKeyNames ="eno" 
         OnRowDeleting ="delete"     AutoGenerateColumns="False"
         GridLines="None" AllowPaging="true" CssClass="mGrid" 
        PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" 
        AutoGenerateSelectButton="True" OnRowUpdating = "update" 
        OnRowEditing ="Edit" OnRowCancelingEdit ="canceledit" >
         <AlternatingRowStyle BackColor="White" />
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />

            <Columns>

                <asp:TemplateField HeaderText="ID" ItemStyle-HorizontalAlign="Center" Visible="false" >

                    <ItemTemplate>

                        <%#Container.DataItemIndex+1%>

                    </ItemTemplate>

                </asp:TemplateField>

                 <asp:TemplateField HeaderText="Employee ID" Visible="false" >

                    <ItemTemplate>   

                        <%#Eval("emp_id")%>   

                    </ItemTemplate>

                    <EditItemTemplate>

                        <asp:TextBox ID="txtempid" runat="server" Text='<%#Eval("emp_id") %>'></asp:TextBox>

                    </EditItemTemplate>

                </asp:TemplateField>

                <asp:TemplateField HeaderText="Employee Name">

                    <ItemTemplate>   

                        <%#Eval("emp_name")%>  
                         <%--<%#Eval("emp_id")%>  --%>

                    </ItemTemplate>

                    <EditItemTemplate>
                         <asp:TextBox ID="txtempid" runat="server" Text='<%#Eval("emp_id") %>' Visible="false"></asp:TextBox>
                       <%-- <asp:TextBox ID="txtempname" runat="server" Text='<%#Eval("emp_name") %>'></asp:TextBox>--%>

                    </EditItemTemplate>

                </asp:TemplateField>

             <asp:TemplateField HeaderText="Salary">

                <ItemTemplate>

                    <%#Eval("sal_increase")%>

                </ItemTemplate>

                <EditItemTemplate>

                    <asp:TextBox ID="salIncrease" runat="server" Text='<%#Eval("sal_increase") %>'></asp:TextBox>

                </EditItemTemplate>

            </asp:TemplateField>

            <asp:TemplateField HeaderText="Reason">

                <ItemTemplate>

                    <%#Eval("reason")%>

                </ItemTemplate>

                <EditItemTemplate>

                    <asp:TextBox ID="txtreason" runat="server" Text='<%#Eval("reason") %>'></asp:TextBox>

                </EditItemTemplate>

            </asp:TemplateField>
            <asp:TemplateField HeaderText="Date" >

                <ItemTemplate>

                    <%#Eval("date")%>

                </ItemTemplate>

                <EditItemTemplate>

                    <asp:TextBox ID="txtdate" runat="server" Text='<%#Eval("date") %>'></asp:TextBox>

                </EditItemTemplate>

            </asp:TemplateField>

            <asp:CommandField ShowDeleteButton="true" ButtonType="Button" HeaderText="Delete" /> 
            <asp:CommandField ShowEditButton="true" ButtonType="Button" HeaderText="Edit" /> 
        
    </Columns>
         
       <%--  OnRowDeleting ="delete"    OnRowUpdating = "Update"--%>
    </asp:GridView>

    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

    </asp:Content>
