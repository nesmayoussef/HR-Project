<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Assigntraining.aspx.cs" Inherits="HR_project.Assigntraining" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
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
    <td> Training:</td>
    <td>
        <asp:DropDownList ID="DropDownList2" runat="server" Height="19px" Width="212px">
        </asp:DropDownList>
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
