<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HireEmployee.aspx.cs" Inherits="HR_project.HireEmployee" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Employee Information" 
        Font-Bold="True" ForeColor="Red"></asp:Label>
    <br />
    <div style="height: 761px; width: 1022px">
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
    <td> <asp:TextBox ID="TextBox6" runat="server" style="text-align: center"></asp:TextBox> 
        </td>
    </tr>
    <tr>
    <td> Housing Allowance </td>
    <td> <asp:TextBox ID="TextBox7" runat="server" style="text-align: center"></asp:TextBox> </td>
    </tr>
    <tr>
    <td> Gender </td>
    <td> 
     <asp:RadioButtonList ID="Radio" runat="server" Checked="True">
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
    <td> Phone </td>
    <td> <asp:TextBox ID="TextBox10" runat="server" style="text-align: center"></asp:TextBox> </td>
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
    <td> Marital Status </td>
    <td> 
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
    <td> <asp:TextBox ID="TextBox14" runat="server" style="text-align: center"></asp:TextBox> </td>
    </tr>
    <tr>
    <td> Qualifications Needed </td>
    <td> <asp:TextBox ID="TextBox15" runat="server" style="text-align: center"></asp:TextBox> </td>
    </tr>
    <tr>
    <td></td>
    <td>
    <asp:Button ID="Button2" runat="server" Text="Hire Employee" 
            style="text-align: center" />
    </td>
    </tr>
    </table>
        <%--<p style="height: 116px; width: 989px">
        <asp:Label ID="Label1" runat="server" Text="Name" style="text-align: center"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="TextBox1" runat="server" style="text-align: center"></asp:TextBox>
       &nbsp;&nbsp <asp:Label ID="Label5" runat="server" Text="Job Description" 
                style="text-align: center"></asp:Label>
            <asp:TextBox ID="TextBox5" runat="server" style="text-align: center" 
                Height="79px" ontextchanged="TextBox5_TextChanged" Width="368px"></asp:TextBox>
        </p>
        <p style="height: 30px; width: 942px">
        <asp:Label ID="Label2" runat="server" Text="Job Title" style="text-align: center"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="TextBox2" runat="server" style="text-align: center"></asp:TextBox>
        <asp:Label ID="Label6" runat="server" Text="Bonus"></asp:Label>
            <asp:TextBox ID="TextBox6" runat="server" 
                ontextchanged="TextBox5_TextChanged"></asp:TextBox>
        </p>
        <p style="height: 27px; width: 945px">
        <asp:Label ID="Label3" runat="server" Text="Job Grade" style="text-align: center"></asp:Label>
        &nbsp;&nbsp;<asp:TextBox ID="TextBox3" runat="server" style="text-align: center"></asp:TextBox>
        <asp:Label ID="Label7" runat="server" Text="Housing Allowance"></asp:Label>
            <asp:TextBox ID="TextBox7" runat="server" 
                ontextchanged="TextBox5_TextChanged"></asp:TextBox>
        </p>
        <p style="height: 69px; width: 964px">
        <asp:Label ID="Label4" runat="server" Text="Salary" style="text-align: center"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="TextBox4" runat="server" style="text-align: center"></asp:TextBox>
        <asp:Label ID="Label8" runat="server" Text="Gender" style="text-align: center"></asp:Label>
            <asp:RadioButton ID="RadioButton1" runat="server" />
            <asp:RadioButton ID="RadioButton2" runat="server" />
        </p>
        <p style="height: 27px; width: 207px">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button1" 
                runat="server" Text="Hire Employee" />
        </p>--%>
        
    </div>
    </form>
</body>
</html>
