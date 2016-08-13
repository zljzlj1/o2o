<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LoginControl.ascx.cs" Inherits="UserControl_LoginControl" %>

 
<style type="text/css">
    .style1
    {
        width: 145px;
        height: 31px;
    }
</style>

 
<table border="0" cellpadding="1" cellspacing="0" id="table1" runat=server  
    style="border: thin dotted #000000; width: 394px; border-collapse: collapse; height: 2px; " >
   
 
    <tr>
        <td style="width: 390px; height: 203px; background-repeat: no-repeat;" 
            >
            <table border="0" cellpadding="0" 
                
                style="width: 390px; height: 176px; ">
                <tr>
                    <td align="center" colspan="2">
                        <span style="font-size: 12pt; font-family: 黑体;">用户登录</span></td>
                </tr>
                <tr>
                    <td align="right" style="width: 319px">
                        <asp:Label ID="UserNameLabel" runat="server"   Font-Size="Medium" 
                           Font-Names="方正舒体" >用户名</asp:Label></td>
                    <td style="width: 993px">
                        <asp:TextBox ID="TxtUserName" runat="server" 
           Width="128px" CssClass="TxtUserName" ></asp:TextBox>
                        
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 319px; height: 36px">
                        <asp:Label ID="PasswordLabel" runat="server"  Font-Size="Medium" 
                            Font-Names="方正舒体">密码</asp:Label></td>
                    <td style="width: 993px; height: 36px">
                        <asp:TextBox ID="TxtUserPwd" runat="server" TextMode="Password" Width="128px" CssClass="TxtUserName"></asp:TextBox>
                        
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 319px; height: 36px"
                            ><span style="font-family: 方正舒体; font-size: medium">验证码</span></td>
                    <td style="width: 993px; height: 36px">
                        <asp:TextBox ID="TxtUserCode" runat="server" Width="80px"  CssClass="TxtUserCode"></asp:TextBox>&nbsp;
                        <asp:Image ID="lbValid" runat="server" ImageUrl="~/ValidateCode.aspx" 
                            alt="若看不清,点击更换一张!!" onclick="this.src='ValidateCode.aspx?'+Math.random()" 
                            />
             
                            </td>
                </tr>
                <tr>
                    <td align="center" colspan="2" style="color: red; height: 19px">
                        <asp:ImageButton ID="btnLogin" runat="server" ImageUrl="~/image/登录.jpg" 
                            OnClick="btLogin_Click" />&nbsp;<asp:ImageButton ID="btnRegister"
                            runat="server" ImageUrl="~/image/注册.jpg" OnClick="btRegister_Click" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
&nbsp;

<table style="width:394px; height: 200px;border: thin dotted #000000;" runat =server id=table2 visible =false border="0" cellpadding="0" cellspacing="0" >
    <tr>
        <td style="width: 145px; height: 26px;">
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 
            <span style="font-size: 10pt; font-family: 黑体;">&nbsp; 用户登录</span></td>
    </tr>
    <tr>
        <td style="width: 145px; height: 27px;">
            <span style="font-size: 10pt; font-family: 楷体;">
            欢迎</span><asp:Label ID="lbUserName" runat="server" Font-Names="黑体" Font-Size="10pt"></asp:Label><span
                style="font-size: 10pt;font-family: 楷体;">光临</span></td>
    </tr>
    <tr >
        <td style="width: 145px; height: 29px;">
            <asp:HyperLink ID="hpLinkMyCart" runat="server"  Font-Size="Small"  Font-Names="楷体" Font-Underline="False" 
                ForeColor="Black" NavigateUrl="~/User/CommitGoods.aspx">我的购物车</asp:HyperLink><br />
            <asp:HyperLink ID="hpLinkOrder" runat="server" Font-Size="Small"  Font-Names="楷体" Font-Underline="False" 
                ForeColor="Black"
                NavigateUrl="~/User/MyOrder.aspx" >查看订单</asp:HyperLink>
            
            <br /><asp:HyperLink ID="Hyperscwzxx" runat="server" 
                NavigateUrl="~/User/UpdateMember.aspx" Font-Size="Small"  Font-Names="楷体" Font-Underline="False" 
                ForeColor="Black">上传文章信息</asp:HyperLink>

            <br /><asp:HyperLink ID="Hyperscncpxx" runat="server" Font-Size="Small"  Font-Names="楷体" Font-Underline="False" 
                ForeColor="Black" NavigateUrl="~/User/UpdateMember.aspx">上传农产品信息</asp:HyperLink>

            <br />

            <asp:HyperLink ID="hpLinkChangeInfo" runat="server" Font-Size="Small"  Font-Names="楷体" Font-Underline="False" 
                ForeColor="Black" NavigateUrl="~/User/UpdateMember.aspx">个人基本信息</asp:HyperLink>
            <br />                 <asp:HyperLink ID="Hyperwdcc" runat="server" 
                Font-Size="Small"  Font-Names="楷体" Font-Underline="False" 
                ForeColor="Black" NavigateUrl="~/wdcz.aspx">我的村庄/社区</asp:HyperLink><br />
                         <asp:HyperLink ID="HyperLinkbdsp" runat="server" 
                Font-Size="Small"  Font-Names="楷体" Font-Underline="False" 
                ForeColor="Black" NavigateUrl="~/wdcz.aspx">本地商品</asp:HyperLink>
  <br />     
<asp:HyperLink ID="hpLinkChangePwd" runat="server" Font-Size="Small"  Font-Names="楷体" Font-Underline="False" 
                ForeColor="Black" NavigateUrl="~/User/ChangePwd.aspx">修改密码</asp:HyperLink><br />
            <asp:HyperLink ID="hpLinkLoginOut" runat="server" Font-Size="Small"  
                Font-Names="楷体" Font-Underline="False" 
                ForeColor="Black" NavigateUrl="~/tuichu.aspx">退出</asp:HyperLink></td>

    </tr>
    

    <tr>
        <td style="width: 145px; height: 5px;">
        </td>
    </tr>
</table>

