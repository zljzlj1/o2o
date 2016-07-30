<%@ Page Language="C#" AutoEventWireup="true" CodeFile="about-1.aspx.cs" Inherits="sw_about_1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <title>深圳市力准传感技术有限公司</title>
     <link href="Styles/leirong.css" type="text/css" rel="Stylesheet" />
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
      <ul id="d1" style=" margin-top: 0px; margin-bottom: 0px; margin-left: 150px;">
 <li  ><a href="index.aspx">首页</a></li>
<li><a href="about.aspx">关于公司</a></li>
<li><a href="changpin.aspx">产品中心</a></li>
<li><a href="news.aspx">新闻中心</a> </li>
<li style="border-right-style: dashed; border-right-width: 2px; border-right-color: #FFFFFF; padding-right: 20px;"> <a href="lianxi.aspx">联系我们</a></li></ul> </div>
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
    
 <div id="left">
 <div id="pic1"></div>
<h2>关于我们</h2>
<ul id="d2">
<li><a href="gongsijianjie.aspx" target="fi"><strong>公司简介</strong></a></li>
<li><a href="qiyewenhua.aspx" target="fi"><strong>企业文化</strong></a></li>
<li><a href="qiyelinian.aspx" target="fi"><strong>企业理念</strong> </a></li>
<li><a href="qiyezhanshi.aspx"target="fi"><strong>企业展示</strong></a></li>  
</ul>
 </div>
 <div id="right"><iframe width="666px" height="408px" name="fi"  scrolling="no" frameborder="0" src="qiyewenhua.aspx"></iframe></div>
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
