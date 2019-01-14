<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Penalty.aspx.cs" Inherits="HR_project.Penalty" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            height: 35px;
        }
        .style2
        {
            height: 78px;
        }
        .style3
        {
            height: 44px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


<table>
   <tr>
   
   <td> Penalty Type </td>
    <td> 
     <asp:RadioButtonList ID="Radio" runat="server" Checked="True" AutoPostBack = "true" Height="50px" 
            onselectedindexchanged="Radio_SelectedIndexChanged">
     <asp:ListItem Text="Automatic" Value="Auto" Selected="True"></asp:ListItem>
        <asp:ListItem Text="Manual" Value="Manual"></asp:ListItem>
     </asp:RadioButtonList>
            </td>
            </tr>
    </table>
    <asp:Panel ID="Panel1" runat="server" >    
    
     <fieldset style="width:406px;">
                    <legend>Automatic Penalty</legend>
    <table>
       <tr>
   <td class="style1">
       Employee Name:</td>
   <td class="style1">

       <asp:DropDownList ID="DropDownList1" runat="server" Height="25px" Width="248px" 
           onselectedindexchanged="DropDownList1_SelectedIndexChanged">
       </asp:DropDownList>

   </td>
   </tr>
   <tr>
   <td>
       Penalty</td>
   <td>
       <asp:RadioButtonList ID="RadioButtonList1" runat="server">
           <asp:ListItem>Incompliance with company policy</asp:ListItem>
           <asp:ListItem>Incompliance with manager descision</asp:ListItem>
           <asp:ListItem>Incompliance with team</asp:ListItem>
       </asp:RadioButtonList>
   </td>
   </tr>
   <tr>
   <td>
   Date:
   </td>
   <td>
       <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
       <asp:Calendar ID="Calendar1" runat="server" BackColor="#FFFFCC" 
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
       </asp:Calendar>
   </td>
   </tr>

   <tr>
   <td>
   Amount:
   </td>
   <td>
       <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
   </td>
   </tr>
   
   <tr>
   <td></td>
   <td>
       <asp:Button ID="Button1" runat="server" Text="Submit" Width="147px" 
           onclick="Button1_Click" />
       </td>
   </tr>
   <tr><td>
   </td>
   <td>
       <asp:Label ID="Label1" runat="server" ForeColor="Red" 
           Text="A penalty has been imposed"></asp:Label>
       </td>
   </tr>
   
    </table>
    </fieldset>
    </asp:Panel>



      <asp:Panel ID="Panel2" runat="server" >    
    
     <fieldset style="width:406px;">
                    <legend>Manual Penalty</legend>
    <table>
       <tr>
   <td class="style1">
       Employee Name:</td>
   <td class="style1">

       <asp:DropDownList ID="DropDownList2" runat="server" Height="25px" Width="248px">
       </asp:DropDownList>

   </td>
   </tr>
   <tr>
   <td class="style3">
   Penalty Reason:
   </td>
   <td class="style3">
       <asp:TextBox ID="TextBox4" runat="server" Height="77px" 
           style="margin-right: 0px; margin-bottom: 4px" Width="241px"></asp:TextBox>
   </td>
   </tr>
   <tr>
   <td>
   Date:
   </td>
   <td>
       <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
       <asp:Calendar ID="Calendar2" runat="server" BackColor="#FFFFCC" 
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
       </asp:Calendar>
   </td>
   </tr>

   <tr>
   <td>
   Amount:
   </td>
   <td>
       <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
   </td>
   </tr>
   
   <tr>
   <td></td>
   <td>
       <asp:Button ID="Button2" runat="server" Text="Submit" Width="147px" 
           onclick="Button2_Click" />
       </td>
   </tr>
   <tr>
   <td>
   </td>
   <td>
       <asp:Label ID="Label2" runat="server" ForeColor="Red" 
           Text="A penalty has been imposed"></asp:Label>
       </td>
   </tr>
    </table>
    </fieldset>
    </asp:Panel>
</asp:Content>
