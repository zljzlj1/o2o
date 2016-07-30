<%@ Page Language="C#" AutoEventWireup="true" CodeFile="tianjiaguanliyuan.aspx.cs" Inherits="sw_tianjiaguanliyuan" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table style=" width:431px" align="center">
    <tr>
    <td></td>
    <td align="left">管理员信息</td>
    </tr> <tr>
    <td align="right" >   用户名：</td>
    <td align="left">
        <asp:TextBox ID="TextBox1" runat="server" Width="139px"></asp:TextBox>
       
    </td></tr>
    <tr><td align="right">密码：</td>
     <td align="left">
         <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
     </td></tr>
     <tr><td align="right">密码再次确认：</td>
     <td align="left">
         <asp:TextBox ID="TextBox3" runat="server" TextMode="Password"></asp:TextBox>
         <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="密码不一致" 

ControlToValidate="TextBox3" ControlToCompare="TextBox2"></asp:CompareValidator>
     </td></tr>
    <tr><td align="right">用户全称：</td>
     <td align="left">
         <asp:TextBox ID="TextBox4" runat="server" Width="139px"></asp:TextBox>
     </td></tr>
     <tr><td align="right">电话：</td>
     <td align="left">
         <asp:TextBox ID="TextBox5" runat="server" Width="139px"></asp:TextBox>
     </td></tr>
     <tr><td align="right">地址：</td>
     <td align="left">
         <asp:TextBox ID="TextBox6" runat="server" Width="139px"></asp:TextBox>
     </td></tr>
      <tr><td align="right">邮编编码：</td>
     <td align="left">
         <asp:TextBox ID="TextBox7" runat="server" Width="139px"></asp:TextBox>
     </td></tr>
      <tr><td></td>
     <td align="left">
         <asp:Button ID="Button1" runat="server" Text="提交" Width="87px" 
             onclick="Button1_Click" />
     </td></tr>
    </table>
    </div>
    </form>
</body>
</html>