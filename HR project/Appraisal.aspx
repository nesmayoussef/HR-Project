<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Appraisal.aspx.cs" Inherits="HR_project.Appraisal" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </cc1:ToolkitScriptManager>
<fieldset style="width:406px;">
     <legend>Assign Training</legend>
    <table>
    <tr>
    <td> Employee Name</td>
    <td>
        <asp:DropDownList ID="DropDownList1" runat="server" Height="19px" Width="212px">
        </asp:DropDownList>
    </td>
    </tr>
    <tr>
    <td> Appraisal:</td>
    <td>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
    <td> Date:</td>
    <td>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>

        <cc1:CalendarExtender ID="TextBox2_CalendarExtender" runat="server" 
            Enabled="True" TargetControlID="TextBox2" Format="dd/MM/yyyy">
        </cc1:CalendarExtender>

        </td>
    </tr>
    <tr>
    <td></td>
    <td>
        <asp:Button ID="Button1" runat="server" Text="Assign" onclick="Button1_Click" />
    </td>
    </tr>
    </table>
    </fieldset>
</asp:Content>
