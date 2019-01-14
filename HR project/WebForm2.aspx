<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="HR_project.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            height: 28px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<table>
    <tr>
    <td> Name </td>
    <td> <asp:TextBox ID="TextBox1" runat="server" style="text-align: center"></asp:TextBox> </td>
    </tr>
    <tr>
    <td> Job Title </td>
    <td> <asp:TextBox ID="TextBox2" runat="server" style="text-align: center"></asp:TextBox> </td>
    </tr>
    <tr>
    <td> Job Grade </td>
    <td> <asp:TextBox ID="TextBox3" runat="server" style="text-align: center"></asp:TextBox> </td>
    </tr>
    <tr>
    <td> Salary </td>
    <td> <asp:TextBox ID="TextBox4" runat="server" style="text-align: center"></asp:TextBox> </td>
    </tr>
    <tr>
    <td> Job Description </td>
    <td> <asp:TextBox ID="TextBox5" runat="server" style="text-align: center"></asp:TextBox> </td>
    </tr>
    <tr>
    <td> Bonus </td>
    <td> <asp:TextBox ID="TextBox6" runat="server" style="text-align: center"></asp:TextBox> </td>
    </tr>
    <tr>
    <td> Housing Allowance </td>
    <td> <asp:TextBox ID="TextBox7" runat="server" style="text-align: center"></asp:TextBox> </td>
    </tr>
    <tr>
    <td> Gender </td>
    <td> 
     <asp:RadioButtonList ID="Radio" runat="server" Checked="True" 
            >
     <asp:ListItem Text="Male" Value="M" Selected="True"></asp:ListItem>
        <asp:ListItem Text="Female" Value="F"></asp:ListItem>
     </asp:RadioButtonList>
        <%--<asp:RadioButton ID="Female" runat="server" Text="Female" />--%>
            </td>
        <%--<asp:TextBox ID="TextBox8" runat="server" style="text-align: center"></asp:TextBox> </td>--%>
    </tr>
       
    <tr>
    <td> Date of birth </td>
    <td> 
    <asp:TextBox ID="TextBox9" runat="server" style="text-align: center"></asp:TextBox>
        <asp:Button
        ID="Button1" runat="server" Text="Date" onclick="Button1_Click" />

     <asp:Calendar ID="Calendar1" runat="server" BackColor="#FFFFCC" 
            BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" 
            Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" 
            ShowGridLines="True" Width="220px" 
            onselectionchanged="Calendar1_SelectionChanged" TitleFormat="Month">
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
    <td> Address </td>
    <td> <asp:TextBox ID="TextBox11" runat="server" style="text-align: center"></asp:TextBox> </td>
    </tr>
    <tr>
    <td> Phone number </td>
    <td> <asp:TextBox ID="TextBox12" runat="server" style="text-align: center"></asp:TextBox> </td>
    </tr>
    <tr>
    <td class="style1"> Marital Status </td>
    <td class="style1"> 
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>Single</asp:ListItem>
            <asp:ListItem>Married</asp:ListItem>
            <asp:ListItem>Divorced</asp:ListItem>
            <asp:ListItem>Separated</asp:ListItem>
            <asp:ListItem>Widowed</asp:ListItem>
        </asp:DropDownList>
        </td>
    </tr>
    <tr>
    <td> Courses Needed </td>
    <td> 

        <asp:CheckBoxList ID="Courselist" runat="server" Width="80px">
        </asp:CheckBoxList>

     </td>
    </tr>
    <tr>
    <td> Qualifications Needed </td>
    <td> <asp:TextBox ID="TextBox15" runat="server" style="text-align: center"></asp:TextBox> </td>
    </tr>
    <tr>
    <td></td>
    <td>
    <asp:Button ID="Button2" runat="server" Text="Hire Employee" 
            style="text-align: center" onclick="Button2_Click" />
    </td>
    </tr>
    </table>
    
</asp:Content>
