<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="increasesalary.aspx.cs" Inherits="HR_project.applicants" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </cc1:ToolkitScriptManager>

    <asp:GridView ID="grdincreasesalary" runat="server" 
    ShowFooter="true" AutoGenerateColumns="False"  CellPadding="4" ForeColor="#333333" 
    GridLines="None" 
       OnRowDeleting="grdincreasesalary_RowDeleting"  OnRowDataBound ="OnRowDataBound"
        >
        
    <Columns>
        <asp:BoundField DataField="RowNumber" HeaderText="SerialNumber" />
        <asp:TemplateField HeaderText="Employee Name">
            <ItemTemplate>
                <asp:DropDownList ID="DropDownList1" runat="server">
                </asp:DropDownList>
                <%--<asp:TextBox ID="txtName" runat="server"></asp:TextBox>--%>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Amount">
            <ItemTemplate>
                <asp:TextBox ID="txtamount" runat="server"></asp:TextBox>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Reason">
            <ItemTemplate>
                <asp:TextBox ID="txtreason" runat="server" 
                Height="55px" TextMode="MultiLine"></asp:TextBox>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Date">
            <ItemTemplate>
            <asp:TextBox ID="txtdate" runat="server"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender1"
                runat="server" Enabled="True" TargetControlID="txtdate" Format="dd/MM/yyyy">
            </cc1:CalendarExtender>
            </ItemTemplate>
                <FooterStyle HorizontalAlign="Right" />
            <FooterTemplate>
                <asp:Button ID="ButtonAdd" runat="server" Text="Add Employee" OnClick="ButtonAdd_Click" />
                <asp:Button ID="ButtonSave" runat="server" Text="Save Data" OnClick="ButtonSave_Click"/>
            </FooterTemplate>
        </asp:TemplateField>
   
        <%--<asp:CommandField ShowDeleteButton="True" />--%>
    </Columns>
    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <RowStyle BackColor="#EFF3FB" />
    <EditRowStyle BackColor="#2461BF" />
    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <AlternatingRowStyle BackColor="White" />


    </asp:GridView>

</asp:Content>
