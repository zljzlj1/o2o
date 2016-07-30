<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wodedingdan.aspx.cs" Inherits="sw_wodedingdan" %>

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
    
  <table style="width: 100%;" align="center">
                        <tr>
                            <td>
                     <asp:DataList ID="DataList1" runat="server" CellPadding="8" RepeatColumns="6" 
            RepeatDirection="Horizontal" Font-Size="Small" HorizontalAlign="Center">
            <ItemTemplate>
            
                                                                                    
                <img height="11" src="images/33.gif" width="5" alt='b' />产品流水号：<%# DataBinder.Eval
                                                                                      (Container.DataItem, "产品流水号")%><br>  

                                <img height="11" src="images/33.gif" width="5" alt='b' />订购数量：<%# DataBinder.Eval

(Container.DataItem, "订购数量")%><br>
           <img height="11" src="images/33.gif" width="5" alt='b' />订购日期：<%# 

DataBinder.Eval(Container.DataItem, "订购日期")%><br>
            <a href='chanpingview.aspx?vid=<%# DataBinder.Eval(Container.DataItem,"产品流水号") %>' target="_blank"><h4>详细信息</h4></a>
            </ItemTemplate>
            </asp:DataList>
                            </td>
                        </tr>
                      <table align="center">               
<TD vAlign="middle" align="center" width="135" colSpan="2"><asp:label id="lblCurrentPage" runat="server" Width="120px" Font-Size="9pt"></asp:label></TD>
<TD vAlign="middle" align="right" width="57"><asp:linkbutton id="btnFirst" runat="server" CommandArgument="first" Font-Size="9pt" onclick="PagerButtonClick">首页</asp:linkbutton>&nbsp;</TD>
<TD vAlign="middle" align="center" width="60"><asp:linkbutton id="btnPrev" runat="server" CommandArgument="prev" Font-Size="9pt" onclick="PagerButtonClick">前一页</asp:linkbutton></TD>
<TD vAlign="middle" align="left" width="51"><asp:linkbutton id="btnNext" runat="server" CommandArgument="next" Font-Size="9pt" onclick="PagerButtonClick">下一页</asp:linkbutton></TD>
<TD vAlign="middle" align="left" width="40"><asp:linkbutton id="btnLast" runat="server" CommandArgument="last" Font-Size="9pt" onclick="PagerButtonClick">末页</asp:linkbutton></TD>
<TD vAlign="middle" align="left" width="53" style="WIDTH: 53px">&nbsp;&nbsp;
<asp:label id="Label2" runat="server" Width="30px" Font-Size="9pt">转到</asp:label></TD>
<TD vAlign="middle" align="center" width="34"><asp:textbox id="TextBox1" runat="server" Width="33px" Height="20px" BorderStyle="Groove" Font-Size="9pt"></asp:textbox></TD>
<TD vAlign="middle" align="center" width="26"><asp:label id="Label3" runat="server" Font-Size="9pt">页</asp:label></TD>
<TD vAlign="middle" align="center" width="34">
                     &nbsp;&nbsp;
                     <asp:button id="Button1" runat="server" Width="44px" Height="20px" BorderStyle="Groove" Text="确定¨"
Font-Size="9pt" onclick="Button1_Click"></asp:button>
<P>&nbsp;</P>
</TD>
                    </table>
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
