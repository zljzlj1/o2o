<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wdcz.aspx.cs" Inherits="wdcz" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>我的村庄/社区</title>
    <link href="css/wdcz.css" rel="Stylesheet" type="text/css" />
 <script src="js/jquery-1.6.2.min.js" type="text/javascript"></script>
<script type="text/javascript" src="js/jquery.nivo.slider.pack.js"></script>

<script type="text/javascript" src="js/jquery-1.2.6.pack.js"></script>
<script type="text/javascript" src="js/jquery.easing.min.js"></script>
<script type="text/javascript" src="js/jquery.lavalamp.min.js"></script>
<script type="text/javascript">
    $(function () {
        $("#1, #2, #3").lavaLamp({
            fx: "backout", //缓动类型
            speed: 700, //缓动时间
            click: function (event, menuItem) {
                return true; //单击触发事件
            }
        });
    });
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
    <div id="logo">
        <div style="font-family: 黑体; font-size: 14px; padding-left: 10px; padding-top: 5px;">欢迎<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>登录--<a 
                href="tuichu.aspx"  class="tc">退出</a><br />
        <a href="index.aspx" style="font-family: 黑体; font-size: 14px; color: #000000;">返回农村电商首页</a><br />
          <a href='index.aspx' ><img src="image/logo.gif" style="width: 67px; height: 53px; margin-top: 10px; margin-left: 50px;" 
               alt="图标" /></a><br /><span  style=" padding-left: 55px;">
          <a  href='index.aspx' style="font-family: 黑体; font-size: 14px; color: #000000;">农村电商</a></span>
        
        
        </div>

     <div class="zxx_test_list">
	<ul class="lava_with_image fix" id="1">
		<li class="current"><a href="wdcz.aspx">首页</a></li>
		<li><a href="#">关于我们</a></li>
		<li><a href="#">咨询服务</a></li>
		<li><a href="#">投资中国</a></li>
		<li><a href="#">企业观点</a></li>
        <li><a href="#x">诚聘英才</a></li>
	</ul>
</div>
  
 

    </div> 
    <div id="banner">
        <center>
<div id="slider-wrap">
  <div id="slider" class="nivoSlider">
	  <a href="/" class="nivo-imageLink">
		<img src="Images/bgbg-1.gif" alt="" title="a" width="1002" height="277"/>
	  </a>  
       <a href="/" class="nivo-imageLink">
		<img src="Images/bgbg-5.gif" alt="" width="1002" title="b"  height="277" />
	  </a>
	

      
  </div>
</div>
</center>
        </div>
        <div id="ban" >
</div>
    <div id="middle">
    <div id="left">
       
             
             </div>
  <div id="mid">
 
  
</div>
     <div id="right">   
     
           
                   </div>
                 
     <div class="c"></div>
       
    </div>
    <div id="footer">
    
     
     
     
 
 
  <div style="position: relative; top: 40px;background-image: url('image/lava_bg-1.gif'); background-repeat: repeat;" align="center">  
      <h4 style="font-family: 微软雅黑; font-weight: bold; color: #000000;" >版权所有  <br /> </h4>
    </div>
    
         
    
   
   </div>
    </div>
    </form>
</body>
</html>
