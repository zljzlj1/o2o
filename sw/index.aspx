<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="sw_index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>深圳市力准传感技术有限公司</title>
     <link href="Styles/index.css" type="text/css" rel="Stylesheet" />

    <style type="text/css">
        .style1
        {
            height: 20px;
        }
        .style2
        {
            width: 140px;
            height: 20px;
        }
        .style3
        {
            width: 140px;
            height: 20px;
        }
    </style>
 



    <script src="Scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
<script type="text/javascript" src="Scripts/jquery.nivo.slider.pack.js"></script>
<script type="text/javascript">
    jQuery(function ($) {
        $(window).load(function () {
            $('#slider').nivoSlider({
                directionNav: true,
                captionOpacity: 0.4,
                controlNav: true,
                boxCols: 8,
                boxRows: 4,
                slices: 15,
                effect: 'random',
                animSpeed: 500,
                pauseTime: 3000
            });
        });
    });
</script>
    </head>
<body>
    <form id="form1" runat="server">
    <div id="big">

    <div id="l"></div>
    <div id="logo">
    <ul id="d1" style="  margin-left: 150px;">
 <li  ><a href="index.aspx" >首页</a></li>
<li><a href="about.aspx">关于公司</a></li>
<li><a href="changpin.aspx">产品中心</a></li>
<li><a href="news.aspx">新闻中心</a> </li>
<li style="border-right-style: dashed; border-right-width: 2px; border-right-color: #FFFFFF; padding-right: 20px;"><a href="lianxi.aspx"> 联系我们</a></li>    </ul></div>
    <div id="l1"> 
    <center>
<div id="slider-wrap">
  <div id="slider" class="nivoSlider">
	  <a href="/" class="nivo-imageLink">
		<img src="images/5.gif" alt="" title="a" width="1002" height="225"/>
	  </a>
	  <a href="/" class="nivo-imageLink">
		<img src="images/6.gif" alt="" width="1002" title="b"  height="225" />
	  </a>
        <a href="/" class="nivo-imageLink">
		<img src="images/7.gif" alt="" width="1002" title="b"  height="225" />
	  </a>
  </div>
</div>
</center>
<!-- /slider -->
<br/>
<div style="text-align:center;clear:both">
</div> 
    </div>
    <div id="mid">
    
    <div id="left">
    <div id="pic1"></div>
<h4 style="color:#5656FF; margin-left:25px; margin-top:12px; font-family: 宋体, Arial, Helvetica, sans-serif;">产品种类</h4>
<ul id="d2" 
            style=" font-family: 宋体, Arial, Helvetica, sans-serif; width: 138px; margin-top: 10px;">
<li><a href="changpin.aspx?id=测力传感器"><strong>测力传感器</strong></a></li>
<li><a href="changpin1.aspx?id=秤重传感器"><strong>秤重传感器</strong></a> </li>
<li><a href="changpin2.aspx?id=轴销传感器"><strong>轴销传感器</strong></a>  </li>
<li><a href="changpin3.aspx?id=扭矩传感器"><strong>扭矩传感器</strong></a> </li>
<li><a href="changpin4.aspx?id=数字传感器"><strong>数字传感器</strong></a></li>
<li><a href="changpin5.aspx?id=特殊传感器"><strong>特殊传感器</strong></a></li>      
</ul>
</div>
    <div id="middle">
    <div id="pic2"></div>
<h4 style="color:#5656FF; margin-left:25px; margin-top:12px; font-family: 宋体, Arial, Helvetica, sans-serif;">公司简介</h4>
<div id="text1"><strong>我公司凭借多年的自动化领域的理解和认识，始终坚持"因为专业、所以信服"的企业运作理念打造了一支自动化领域的专业团队，为客户提供一流的售前和售后的技术服务.<a  href="about.aspx"><<< 更多....>>></a></strong>
</div>
</div>
    <div id="right">
         <div id="pic3"></div>
<h4 style="color:#5656FF; margin-left:25px; margin-top:12px; font-family: 宋体, Arial, Helvetica, sans-serif;">企业新闻</h4>
<ul id="d3" style="margin-top: 10px">
<li><a href="news.aspx?id=企业新闻"><strong>企业新闻</strong></a></li>
<li><a href="new1.aspx?id=业内新闻"><strong>业内新闻</strong></a> </li>
</ul>
        </div>
        <div id="r2">
        <asp:Panel ID="Panel1" runat="server">
         <div id="right1">
        <table style="border-style: groove; border-width: 1px; width:170px; ">
             <tr>
                <td style="border-style: ridge; border-width: 2px;  background-image: url('images/login_11.gif'); ">
                 <div style="margin: auto; font-family: 华文彩云; color: #FFFFFF; font-style: oblique; width: 80px; text-align: center; background-image: url('images/login1.gif'); background-repeat: no-repeat; clip: rect(auto, auto, auto, auto);">用户登录</div></td>
            </tr>
            <tr>
                <td style="font-family: 方正舒体; font-size: 14px; width: 160px; text-align: center;">
                    用户名：<asp:TextBox 
                        ID="TextBox1" runat="server" Width="90px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="font-family: 方正舒体; font-size: 14px; width: 160px; text-align: center; padding-left: 14px;" >
                   密码：<asp:TextBox 
                        ID="TextBox2" runat="server" Width="90px" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="center" class="style1">
                    <asp:Button ID="Button1" runat="server" Text="登录" BackColor="#BFBEBF" 
                        BorderColor="#BFBEBF" BorderStyle="Outset" BorderWidth="2px" 
                        Font-Bold="False" Font-Italic="False" onclick="Button1_Click" />
                    &nbsp;
                    <asp:Button ID="Button2"
                        runat="server" Text="注册" BackColor="#BFBEBF" BorderColor="#BFBEBF" 
                        BorderStyle="Outset" BorderWidth="2px" PostBackUrl="~/sw/yonghu.aspx"  />
                </td>
            </tr>
        </table></div></asp:Panel>
             <asp:Panel ID="Panel2" runat="server"> 
             <div id="right2" style="height: 130px; width:100%">
        
            <table style="width: 100%; font-family: 宋体, Arial, Helvetica, sans-serif; font-size: 12px;">
                <tr>
                    <td align="center" class="style2">
                      ::用户中心：：
                    </td>
                </tr>
                <tr>
                    <td align="center" 
                        style="font-family: 宋体, Arial, Helvetica, sans-serif; text-align: center;" 
                        class="style3">
                       欢迎您<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label><br /><br />您可以进行以下操作：
                    </td>
                </tr>
                <tr>
                    <td style="width: 90px; height: 80px; text-align: center;" align="center">
                       <table style="font-size: 12px; font-family: 宋体, Arial, Helvetica, sans-serif"> 
                       <tr><td style="width: 80px" align="left"><a href="xiugaiyonghu.aspx">修改注册资料</a></td></tr>
                        <tr><td style="width: 80px; height: 20px;" align="left"><a href="wodedingdan.aspx">我的订单</a></td></tr>
                         <tr><td style="width: 80px; height: 20px; " align="left">
                             <asp:Button ID="Button3" runat="server" BackColor="#CED6CE" 
                                 BorderColor="#CED6CE" onclick="Button3_Click1" Text="退出" />
                             </td></tr>
                         <tr><td><br /></td></tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
             </asp:Panel>    
       </div>
      
    <div id="c"></div>
    </div>
    <div id="footer"><div id="pic4"></div>
        <h5 style="margin:5px; font-family: 黑体; font-size: 14px; text-align: center; font-style: oblique; color: #0000FF;" 
            ><a href="logn.aspx"  target="_self">管理入口</a></h5>
<div id="text2"><strong>地址：深圳市龙岗区荷坳银荷路诚发工业厂区四楼南侧 邮编：518151&nbsp;&nbsp;&nbsp;咨询电话：0755-89233819 89233406 传真: 0755 89233919<br />COPYRIGHT©2013深圳市力准传感技术有限公司 All Rights Reserved 粤ICP备：13049907号</strong>
</div>
</div>
  </div>
    </form>
</body>
</html>
