<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SalaryDeduction.aspx.cs" Inherits="HR_project.SalaryDeduction" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style2
        {
            width: 331px;
        }
        .style3
        {
            width: 125px;
        }
        .style4
        {
            width: 391px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </cc1:ToolkitScriptManager>
    <asp:Panel ID="Panel1" runat="server" >    
    
     <fieldset style="width:631px;">
     <legend>Salary Deduction</legend>
    <table>
    <tr>
   <td class="style3">
       Employee Name:</td>
   <td class="style4">

       <asp:DropDownList ID="DropDownList1" runat="server" Height="25px" Width="248px">
       </asp:DropDownList>

   </td>
   </tr>
   <tr>
   <td class="style3">Deduction Type</td>
   <td class="style4">
       <asp:RadioButtonList ID="RadioButtonList1" runat="server" Autopostback="true" 
           onselectedindexchanged="RadioButtonList1_SelectedIndexChanged" >
           <asp:ListItem Selected="True" Text="Medical Insurance" Value="Medical Insurance"></asp:ListItem>
           <asp:ListItem Text="Social Security Insurance" Value="Social Security Insurance"></asp:ListItem>
       </asp:RadioButtonList>
   </td>
   </tr>
   <tr>
   <td class="style3">Date:</td>
   <td class="style4">
       <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
       <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" TargetControlID="TextBox1" Format="MMMM">
       </cc1:CalendarExtender>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
           ErrorMessage="Please enter Date!!" ControlToValidate="TextBox1" 
           Display="Dynamic" ForeColor="Red" style="font-weight: 700" ></asp:RequiredFieldValidator>

       <%--<asp:Calendar ID="Calendar1" runat="server" BackColor="#FFFFCC" 
           BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" 
           Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" 
           onselectionchanged="Calendar1_SelectionChanged" ShowGridLines="True" 
           Width="220px">
           <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
           <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
           <OtherMonthDayStyle ForeColor="#CC9966" />
           <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
           <SelectorStyle BackColor="#FFCC66" />
           <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" 
               ForeColor="#FFFFCC" />
           <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
       </asp:Calendar>--%>
       <asp:Label ID="Label3" runat="server" ForeColor="#FF5050" 
           style="font-weight: 700" Text="Label" Visible="False"></asp:Label>
   </td>
   </tr>

   <tr>
   <td class="style3">
   Amount:
   </td>
   <td class="style4">
       <asp:Label ID="Label2" runat="server" Text="200"></asp:Label>
   </td>
   </tr>
   
   <tr>
   <td class="style3"></td>
   <td class="style4">
       <asp:Button ID="Button1" runat="server" Text="Submit" Width="147px" 
           onclick="Button1_Click" />
       </td>
   </tr>
   <tr><td class="style3">
   </td>
   <td class="style4">
       <asp:Label ID="Label1" runat="server" ForeColor="Red" 
           Text="A salary deduction has been imposed"></asp:Label>
       </td>
   </tr>
   
    </table>
    </fieldset>
    </asp:Panel>
</asp:Content>
