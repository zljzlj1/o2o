<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin-sy.aspx.cs" Inherits="admin_admin_sy" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>后台系统管理</title>
    <link href="css/skint.css" rel="stylesheet" type="text/css" />
   
</head>
<body  leftmargin="0" topmargin="0">
    <form id="form1" runat="server">
    <div>
  <div><table width="100%" height="64" border="0" cellpadding="0" cellspacing="0" class="admin_topbg">
  <tr>
    <td height="64" style="width: 61%"><img src="images/logo.gif" width="262" height="64"></td>
    <td width="39%" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="74%" height="38" class="admin_txt" align="right">管理员：<b><asp:Label ID="username" runat="server" ForeColor="#00C000"></asp:Label></b> 您好,感谢登陆使用！</td>
        <td width="22%">
            <asp:ImageButton ID="ImageButton1" runat="server" 
                ImageUrl="~/admin/images/out.gif" OnClick="ImageButton1_Click" /><a href="#" target="_self" onclick="logout();"></a></td>
        <td width="4%">&nbsp;</td>
      </tr>
      <tr>
        <td height="19" colspan="3">&nbsp;</td>
        </tr>
    </table></td>
  </tr>
</table>
</div>
<div style="width: 100%"  >
<div class="left">
    <iframe  src="left.aspx" name="leftFrame" scrolling="no" id="leftFrame" 
        frameborder="0"   width="170px"; height="500px" ></iframe>
    </div>
 


<div class="right"><iframe src="right.aspx" name="mainFrame" id="mainFrame"  frameborder="0"  scrolling="no"   height="500px" width="900px"></iframe></div>
<div class="c"></div>

</div>




</div>
    </form>
</body>
</html>
