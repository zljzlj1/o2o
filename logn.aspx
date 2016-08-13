<%@ Page Language="C#" AutoEventWireup="true" CodeFile="logn.aspx.cs" Inherits="sw_logn" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>管理员登录</title>
     <style type="text/css"> 
body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
	overflow:hidden;
}
</style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table border="0" cellpadding="0" cellspacing="0"   width="100%">
  <tr>
    <td bgcolor="#02395f">&nbsp;</td>
  </tr>
  <tr>
    <td height="607" align="center" 
          style="background-image: url('image/htimage/login_02.gif')"><table width="974" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td height="331" style="background-image: url('image/htimage/login_01.png')">&nbsp;</td>
      </tr>
      <tr>
        <td height="116"><table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="393" height="116" style="background-image: url('image/htimage/login_05.gif')">&nbsp;</td>
            <td width="174"><table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td height="81" style="background-image: url('image/htimage/login_06.gif')"><table width="100%" border="0" cellspacing="0" cellpadding="0" font-size="12px">
                  <tr>
                    <td width="24%"><div align="center"><font style="height:1;font-size:9pt; color:#bfdbeb;">用户</font></div></td>
                    <td width="76%" height="25">
                            <asp:TextBox ID="TextBox1" runat="server" BackColor="#32A2E3" Height="20px" 
                                Width="145px"  Font-Size="12" BorderStyle="Solid" BorderWidth="1" BorderColor="#0468A7" ForeColor="#14649F"></asp:TextBox>
                      </td>
                  </tr>
                  <tr>
                    <td><div align="center"><font style="height:1;font-size:9pt; color:#bfdbeb;">密码</font></div></td>
                    <td height="25"><asp:TextBox ID="TextBox2" runat="server" TextMode="Password" BackColor="#32A2E3" Height="20" Width="145" Font-Size="12" BorderStyle="Solid" BorderWidth="1"  BorderColor="#0468A7" ForeColor="#14649F"></asp:TextBox>
                      </td>  
                      
                  </tr>    <tr>
                    <td class="style1" ><div align="center"><font style="height:1;font-size:9pt; color:#bfdbeb;">验证码</font></div></td>
                    <td height="25" >
               <table  width="100%" border="0" cellspacing="0" cellpadding="0"><tr>
                   <td style="width: 45%"> <asp:TextBox ID="TextBox3" runat="server" 
                           BackColor="#32A2E3" Height="20px" 
                                Width="60px"  Font-Size="12" BorderStyle="Solid" BorderWidth="1" 
                           BorderColor="#0468A7" ForeColor="#14649F" CausesValidation="True"></asp:TextBox></td>
                                <td style="width: 55%"> 
                                  
                                     <img src="ValidateCode.aspx" alt="若看不清,点击更换一张!!" onclick="this.src='ValidateCode.aspx?'+Math.random()" />
               </td></tr></table>
                        
                         
                     
                     
                      </td>  
                      
                      
                  </tr>   
                </table></td>
              </tr>
              <tr>
                <td height="35"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td width="50" height="35"><img src="image/htimage/login_08.gif" width="50"height="35" /></td>
                    <td width="46">
                        <asp:ImageButton ID="ImageButton1" runat="server"  
                            ImageUrl="~/image/htimage/login_09.gif" Width="46px" Height="35px" 
                            BorderWidth="0" onclick="ImageButton1_Click" />
                      </td>
                    <td width="45">
                        <asp:ImageButton ID="ImageButton2" runat="server" 
                            ImageUrl="~/image/htimage/login_10.gif"  Width="46px" Height="35px" 
                            BorderWidth="0" PostBackUrl="~/index.aspx"/>
                      </td>
                    <td width="33"><img src="image/htimage/login_11.gif" width="33" height="35"></td>
                  </tr>
                </table></td>
              </tr>
            </table></td>
            <td width="407" style="background-image: url('image/htimage/login_07.gif')">&nbsp;</td>
          </tr>
        </table></td>
      </tr>
      <tr>
        <td height="160" >&nbsp;<div style="font-family: 宋体, Arial, Helvetica, sans-serif; font-size: 24px; color: #FFFFFF; text-align: center">农村电商购物@荣誉出品</div></td>
      </tr>
    </table></td>
  </tr>
  <tr>
    <td bgcolor="#02609c">&nbsp;</td>
  </tr>
</table>
    </div>
    </form>
</body>
</html>
