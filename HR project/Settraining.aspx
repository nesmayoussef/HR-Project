<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Settraining.aspx.cs" Inherits="HR_project.Settraining" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            height: 26px;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </cc1:ToolkitScriptManager>

    <asp:Panel ID="Panel1" runat="server" >   
    
    <fieldset style="width:406px;">
                    <legend>Set Training</legend>
<table>
<tr>
<td>Training</td>
<td>
    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
    </td>
</tr>
<tr>
<td style="margin-left: 40px" >
    
    <asp:Label ID="Label1" runat="server" Text="Start Date"></asp:Label>
    
    </td>
<td >
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <cc1:CalendarExtender ID="CalendarExtender1"   TargetControlID="TextBox1" runat="server" Format="dd/MM/yyyy">
    </cc1:CalendarExtender></td>
</tr>
<tr>
<td class="style1">
    <asp:Label ID="Label2" runat="server" Text="End Date"></asp:Label>
    </td>
<td class="style1">
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    <cc1:CalendarExtender ID="TextBox2_CalendarExtender" runat="server" 
        Enabled="True" TargetControlID="TextBox2" Format="dd/MM/yyyy">
    </cc1:CalendarExtender>
    </td>
</tr>
<tr>
<td>
    <asp:Label ID="Label3" runat="server" Text="Amount"></asp:Label>
    </td>
<td>
    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
    </td>
</tr>
<tr>
    <td>          </td>
<td><asp:Button ID="Button1" runat="server" Text="Save" Width="84px" 
        onclick="Button1_Click" />
        
       
        </td>
</tr>
</table>
</fieldset>
</asp:Panel>

</asp:Content>
