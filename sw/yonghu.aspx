<%@ Page Language="C#" AutoEventWireup="true" CodeFile="yonghu.aspx.cs" Inherits="sw_yonghu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>深圳市力准传感技术有限公司</title>
    <link href="Styles/leirong.css" type="text/css" rel="Stylesheet" />
    <style type="text/css">
        .style2
        {
            width: 120px;
           padding-left:10px;
          padding-top:5px;
           
        }
        .style4
        {
            padding-left:10px;
               padding-top:5px;
            width: 120px;
           
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
<body >
    <form id="form1" runat="server">
    <div id="big" >

    <div id="l"></div>
    <div id="logo">
    <ul id="d1" style="  margin-left: 150px;">
 <li  ><a href="index.aspx" >首页</a></li>
<li><a>关于公司</a></li>
<li><a>产品中心</a></li>
<li><a>新闻中心</a> </li>
<li style="border-right-style: dashed; border-right-width: 2px; border-right-color: #FFFFFF; padding-right: 20px;"><a> 联系我们</a></li>    </ul></div>
    <div id="l1"> 
    <center>
<div id="slider-wrap">
  <div id="slider" class="nivoSlider">
	   <a href="/" class="nivo-imageLink">
		<img src="images/bg10.gif"  alt="" title="a" width="1002" height="140"/>
	  </a>
	  <a href="/" class="nivo-imageLink">
		<img src="images/bg11.gif"" alt="" width="1002" title="b"  height="140" />
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
    <center>
   <table style=" border-style: groove; border-width: medium; width:600px; font-family: 楷体_GB2312; font-size: 12px; text-align: left;  margin-left: 20px; margin-top: 10px;" >
             <thead><tr><td></td><td style="font-family: 华文楷体; font-size: 20px; height: 20px; ">客户信息</td></tr></thead>
            <tr>
                <td class="style4">
                    用户名：&nbsp;&nbsp;&nbsp; 
                </td>
               <td>
                   <asp:TextBox ID="TextBox1" runat="server" width="180px" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    密码：&nbsp;&nbsp;&nbsp; 
                </td>
                 <td> <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" width="180px" ></asp:TextBox></td>    
            </tr>
            <tr>
                <td class="style2">
                    密码确认：&nbsp;&nbsp;&nbsp; 
                    
                </td>
                 <td><asp:TextBox ID="TextBox3" runat="server" TextMode="Password" width="180px" ></asp:TextBox>
                     <asp:CompareValidator ID="CompareValidator1" runat="server" 
                         ControlToCompare="TextBox2" ControlToValidate="TextBox3" ErrorMessage="密码不一致"></asp:CompareValidator>
                </td>    
            </tr>
            <tr>
                <td class="style2">
                    用户全称：
                </td>
                 <td><asp:TextBox ID="TextBox4" runat="server" width="180px" ></asp:TextBox></td>    
            </tr>
            <tr>
                <td class="style2">
                    电话：&nbsp;&nbsp;&nbsp; 
                  
                </td>
                 <td>  <asp:TextBox ID="TextBox5" runat="server" width="180px"></asp:TextBox></td>    
            </tr>
           <tr>
                <td class="style2">
                    地址：&nbsp;&nbsp;&nbsp; 
                   
                </td>
                 <td> <asp:TextBox ID="TextBox6" runat="server" width="180px"></asp:TextBox></td>    
            </tr>
           <tr>
                <td class="style2">
                    邮政编码：&nbsp;&nbsp;&nbsp; 
                    
                </td>
                 <td><asp:TextBox ID="TextBox7" runat="server" width="180px" ></asp:TextBox></td>    
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                 <td><asp:Button ID="Button1" runat="server" Text="提交" onclick="Button1_Click" 
                        Height="27px" Width="83px" BackColor="#BFBEBF" BorderColor="#BFBEBF" 
                         BorderStyle="Outset" BorderWidth="5px"  />&nbsp; 
                     <asp:Button ID="Button2" 
                         runat="server" Text="返回" onclick="Button1_Click" 
                        Height="27px" Width="83px" BackColor="#BFBEBF" BorderColor="#BFBEBF" 
                         BorderStyle="Outset" BorderWidth="5px" PostBackUrl="~/sw/index.aspx"  />
                </td>    
            </tr>
        </table>
        </center>
    </div>
    <div id="footer"><div id="pic4"></div>
        <h5 style="margin:5px; font-family: 黑体; font-size: 14px; text-align: center; font-style: oblique; color: #0000FF;" 
            ><a href="logn.aspx" target="_self">管理入口</a></h5>
<div id="text2"><strong>地址：深圳市龙岗区荷坳银荷路诚发工业厂区四楼南侧 邮编：518151&nbsp;&nbsp;&nbsp;咨询电话：0755-89233819 89233406 传真: 0755 89233919<br />COPYRIGHT©2013深圳市力准传感技术有限公司 All Rights Reserved 粤ICP备：13049907号</strong>
</div>
</div>
  </div>
    </form>
</body>
</html>
