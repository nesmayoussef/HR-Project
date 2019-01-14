<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="HR_project.test" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    

   
    <asp:GridView ID="GridView1" runat="server" DataKeyNames ="training_id" OnRowEditing ="Edit"               
        OnRowCancelingEdit ="canceledit" OnRowDeleting ="delete"    OnRowUpdating = "Update" AutoGenerateColumns="False"  
         GridLines="None" AllowPaging="true" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt">
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

                <asp:TemplateField HeaderText="Training Number" ItemStyle-HorizontalAlign="Center">

                    <ItemTemplate>

                        <%#Container.DataItemIndex+1%>

                    </ItemTemplate>

                </asp:TemplateField>

 

                <asp:TemplateField HeaderText="Training Name">

                    <ItemTemplate>   

                        <%#Eval("training_name")%>   

                    </ItemTemplate>

                    <EditItemTemplate>

                        <asp:TextBox ID="txtempname" runat="server" Text='<%#Eval("training_name") %>'></asp:TextBox>

                    </EditItemTemplate>

                </asp:TemplateField>

 

             <asp:TemplateField HeaderText="Start Date">

                <ItemTemplate>

                    <%#Eval("start_date")%>

                </ItemTemplate>

                <EditItemTemplate>

                    <asp:TextBox ID="txtempcode" runat="server" Text='<%#Eval("start_date") %>'></asp:TextBox>

                </EditItemTemplate>

            </asp:TemplateField>

 

            <asp:TemplateField HeaderText="End Date">

                <ItemTemplate>

                    <%#Eval("end_date")%>

                </ItemTemplate>

                <EditItemTemplate>

                    <asp:TextBox ID="txtempage" runat="server" Text='<%#Eval("end_date") %>'></asp:TextBox>

                </EditItemTemplate>

            </asp:TemplateField>
            <asp:TemplateField HeaderText="Training time">

                <ItemTemplate>

                    <%#Eval("train_time")%>

                </ItemTemplate>

                <EditItemTemplate>

                    <asp:TextBox ID="txtetpage" runat="server" Text='<%#Eval("train_time") %>'></asp:TextBox>

                </EditItemTemplate>

            </asp:TemplateField>

            <asp:CommandField ShowEditButton="true" ButtonType ="Button"  HeaderText="Edit" />

            <asp:CommandField ShowDeleteButton="true" ButtonType="Button" HeaderText="Delete" /> 

             

    </Columns>
         
       <%--  OnRowDeleting ="delete"    OnRowUpdating = "Update"--%>
    </asp:GridView>

</asp:Content>
