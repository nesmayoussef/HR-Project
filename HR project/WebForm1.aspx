<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="HR_project.WebForm1" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 239px; width: 329px">--%>

    <%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="HR_project.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            height: 28px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
     <%--<asp:TextBox ID="Username" runat="server">Username</asp:TextBox> --%>
    
    <h2>Login</h2>
    
           <p>
               &nbsp;<asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>
               <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
           </p>
           <p>
               &nbsp;<asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
              &nbsp;<asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
           </p>
            <p>
            <asp:Label ID="Label3" runat="server" Text="Label" ForeColor="#FF3300" 
            Visible="False" Font-Bold="True"></asp:Label>
            </p>   
           <p>
           <asp:Label ID="Label4" runat="server" Text="Label" Font-Bold="True" 
                   Font-Italic="True" Font-Size="Medium" ForeColor="Red" Visible="False"></asp:Label>
           </p>
           <p>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Login" runat="server" 
                   CommandName="MoveNext" Text="Login" Width="118px" onclick="Login_Click1" />
               <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Logout" 
                   Width="115px" />
           </p>
               
</asp:Content>

  <%--  </div>
    </form>
</body>
</html>--%>


<%--<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="WebForm1.aspx.cs" Inherits="HR_project._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
        <h2>Login</h2>
    
           <p>
               &nbsp;<asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>
               <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
           </p>
           <p>
               &nbsp;<asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
              &nbsp;<asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
           </p>
               <asp:Label ID="Label3" runat="server" Text="Label" ForeColor="#FF3300" 
            Visible="False"></asp:Label>
           <p>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Login" runat="server" 
                   CommandName="MoveNext" Text="Login" Width="118px" onclick="Login_Click1" />
               <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Logout" 
                   Width="115px" />
           </p>
</asp:Content>
--%>