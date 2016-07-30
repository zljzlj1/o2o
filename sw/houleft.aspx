<%@ Page Language="C#" AutoEventWireup="true" CodeFile="houleft.aspx.cs" Inherits="sw_houleft" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>后台管理</title>
 <link href="Styles/houleftt.css" type="text/css" rel="Stylesheet" />
 <script>
　　function clear()<br>　　{<br>　<%Clear();%><br>　　}
</script>


<SCRIPT language="javascript">
    function tupian(idt) {
        var nametu = "xiaotu" + idt;
        var tp = document.getElementById(nametu);
        tp.src = "images/images/ico05.gif "; //图片ico04为白色的正方形

        for (var i = 1; i < 30; i++) {

            var nametu2 = "xiaotu" + i;
            if (i != idt * 1) {
                var tp2 = document.getElementById('xiaotu' + i);
                if (tp2 != undefined)
                { tp2.src = "images/images/ico06.gif"; } //图片ico06为蓝色的正方形
            }
        }
    }

    function list(idstr) {
        var name1 = "subtree" + idstr;
        var name2 = "img" + idstr;
        var objectobj = document.all(name1);
        var imgobj = document.all(name2);


        //alert(imgobj);

        if (objectobj.style.display == "none") {
            for (i = 1; i < 10; i++) {
                var name3 = "img" + i;
                var name = "subtree" + i;
                var o = document.all(name);
                if (o != undefined) {
                    o.style.display = "none";
                    var image = document.all(name3);
                    //alert(image);
                    image.src = "images/images/ico04.gif";
                }
            }
            objectobj.style.display = "";
            imgobj.src = "images/images/ico03.gif";
        }
        else {
            objectobj.style.display = "none";
            imgobj.src = "images/images/ico04.gif";
        }
    }

</SCRIPT>


          
   
  
</head>
<body>
    <form id="form1" runat="server">
    <div id="llll">
  <table width="198" border="0" cellpadding="0" cellspacing="0" class="left-table01">
  <tr>
    <TD>
		<table width="100%" border="0" cellpadding="0" cellspacing="0">
		  <tr>
			<td width="207" height="55" 
                  style="background-image: url('images/images/nav01.gif'); width: 198px; height: 55px;">
				<table width="90%" border="0" align="center" cellpadding="0" cellspacing="0">
				  <tr>
					<td width="25%" rowspan="2"><img src="images/images/ico02.gif" width="35" height="35" /></td>
					<td width="75%" height="22" class="left-font01"><span class="left-font02"><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label> 您好！欢迎使用</span> </td>
				  </tr>
				   <tr>
                 
					<td height="22" class="left-font01">
                    <asp:ScriptManager ID="ScriptManager1" runat="Server" ></asp:ScriptManager>  <asp:UpdatePanel ID="UpdatePanel1" runat="server">  
                <ContentTemplate> 
            <!--Lable和Timer控件必须都包含在UpdatePanel控件中 -->  
                    <asp:Label ID="Label2" runat="server" Text="Labe2 " style="color: Black; font-family:@楷体; font-size:12;" ></asp:Label>  <!--用于显示时间-->  
                    <asp:Timer ID="Timer1" runat="server" Interval="1000"></asp:Timer><!-- 用于更新时间，每1秒更新一次-->  
                </ContentTemplate>                  
            </asp:UpdatePanel> 
						
                      
						
				  </tr>
                 
				</table>
			</td>
		  </tr>
		</table>
		<TABLE width="100%" border="0" cellpadding="0" cellspacing="0" class="left-table03">
          <tr>
            <td height="29">
				<table width="85%" border="0" align="center" cellpadding="0" cellspacing="0">
					<tr>
						<td width="8%"><img name="img8" id="img4" src="images/images/ico04.gif" 
                                width="8" height="11" /></td>
						<td width="92%">
						
						[&nbsp;<a href="logn.aspx" target="_top" class="left-font01" onclick="Clear()">退出</a>&nbsp;]
                                        
                                        </td>
					</tr>
				</table>
			</td>
          </tr>		  
        </TABLE>
		<TABLE width="100%" border="0" cellpadding="0" cellspacing="0" class="left-table03">
          <tr>
            <td height="29">
				<table width="85%" border="0" align="center" cellpadding="0" cellspacing="0">
					<tr>
						<td width="8%"><img name="img8" id="img8" src="images/images/ico04.gif" 
                                width="8" height="11" /></td>
						<td width="92%">
								<a href="javascript:" target="right" class="left-font03" onClick="list('8');" >新闻管理</a></td>
					</tr>
				</table>
			</td>
          </tr>		  
        </TABLE>
		<table id="subtree8" style="DISPLAY: none" width="80%" border="0" align="center" cellpadding="0" 
				cellspacing="0" class="left-table02">
				<tr>
				  <td width="9%" height="20" ><img id="xiaotu20" src="images/images/ico06.gif" width="8" height="12" /></td>
				  <td width="91%"><a href="newguanli.aspx" target="right" class="left-font03" 
                          onClick="tupian('20');">新闻管理</a></td>
				</tr>
				<tr>
				  <td width="9%" height="21" ><img id="xiaotu21" src="images/images/ico06.gif" width="8" height="12" /></td>
				  <td width="91%"><a href="newsadd.aspx" target="right" class="left-font03" 
                          onClick="tupian('21');">新闻添加</a></td>
				</tr>
                <tr>
				  <td width="9%" height="20" ><img id="xiaotu24" src="images/images/ico06.gif" width="8" height="12" /></td>
				  <td width="91%">
						<a href="xinwenkind.aspx" target="right" class="left-font03" 
                            onClick="tupian('24');">新闻类别管理
							</a></td>
				</tr>
      </table>
	
		<TABLE width="100%" border="0" cellpadding="0" cellspacing="0" class="left-table03">
          <tr>
            <td height="29">
				<table width="85%" border="0" align="center" cellpadding="0" cellspacing="0">
					<tr>
						<td width="8%"><img name="img7" id="img7" src="images/images/ico04.gif" width="8" height="11" /></td>
						<td width="92%">
								<a href="javascript:" target="right" class="left-font03" onClick="list('7');" >产品管理</a></td>
					</tr>
				</table>
			</td>
          </tr>		  
        </TABLE>
		<table id="subtree7" style="DISPLAY: none" width="80%" border="0" align="center" cellpadding="0" 
				cellspacing="0" class="left-table02">
				<tr>
				  <td width="9%" height="20" ><img id="xiaotu17" src="images/images/ico06.gif" width="8" height="12" /></td>
				  <td width="91%">
						<a href="productguanli.aspx" target="right" class="left-font03" 
                            onClick="tupian('17');">产品管理</a></td>
				</tr>
				<tr>
				  <td width="9%" height="20" ><img id="xiaotu18" src="images/images/ico06.gif" width="8" height="12" /></td>
				  <td width="91%">
					<a href="addpro.aspx" target="right" class="left-font03" onClick="tupian('18');">产品添加</a></td>
				</tr>
				<tr>
				  <td width="9%" height="20" ><img id="xiaotu19" src="images/images/ico06.gif" width="8" height="12" /></td>
				  <td width="91%">
						<a href="chanpinleibie.aspx" target="right" class="left-font03" onClick="tupian('19');">产品类别管理
							</a></td>
				</tr>
				
      </table>

        <TABLE width="100%" border="0" cellpadding="0" cellspacing="0" class="left-table03">
          <tr>
            <td height="29">
				<table width="85%" border="0" align="center" cellpadding="0" cellspacing="0">
					<tr>
						<td width="8%"><img name="img1" id="img1" src="images/images/ico04.gif" width="8" height="11" /></td>
						<td width="92%">
								<a href="javascript:" target="right" class="left-font03" onClick="list('1');" >订单管理</a></td>
					</tr>
				</table>
			</td>
          </tr>		  
        </TABLE>
		<table id="subtree1" style="DISPLAY: none" width="80%" border="0" align="center" cellpadding="0" 
				cellspacing="0" class="left-table02">
				<tr>
				  <td width="9%" height="20" ><img id="xiaotu1" src="images/images/ico06.gif" width="8" height="12" /></td>
				  <td width="91%"><a href="houtaidingdanguanli.aspx" target="right" 
                          class="left-font03" onClick="tupian('1');">订单管理</a></td>
				</tr>
      </table>

	  <table width="100%" border="0" cellpadding="0" cellspacing="0" class="left-table03">
          <tr>
            <td height="29"><table width="85%" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                  <td width="8%" height="12"><img name="img2" id="img2" src="images/images/ico04.gif" width="8" height="11" /></td>
                  <td width="92%"><a href="javascript:" target="right" class="left-font03" onClick="list('2');" >用户管理</a></td>
                </tr>
            </table></td>
          </tr>
      </table>
	  
	  <table id="subtree2" style="DISPLAY: none" width="80%" border="0" align="center" cellpadding="0" cellspacing="0" class="left-table02">
        
		<tr>
          <td width="9%" height="20" ><img id="xiaotu7" src="images/images/ico06.gif" width="8" height="12" /></td>
          <td width="91%"><a href="yonghuguanlii.aspx" target="right" class="left-font03" 
                  onClick="tupian('7');">用户管理</a></td>
        </tr>
      </table>
	  <table width="100%" border="0" cellpadding="0" cellspacing="0" class="left-table03">
          <tr>
            <td height="29"><table width="85%" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                  <td width="8%" height="12"><img name="img3" id="img3" src="images/images/ico04.gif" width="8" height="11" /></td>
                  <td width="92%"><a href="javascript:" target="_top" class="left-font03" 
                          onClick="list('3');" >管理员管理</a></td>
                </tr>
            </table></td>
          </tr>
      </table>
	  
	  <table id="subtree3" style="DISPLAY: none" width="80%" border="0" align="center" cellpadding="0" cellspacing="0" class="left-table02">
        <tr>
          <td width="9%" height="20" ><img id="xiaotu8" src="images/images/ico06.gif" width="8" height="12" /></td>
          <td width="91%"><a href="tianjiaguanliyuan.aspx" target="right" class="left-font03" onClick="tupian('8');">添加管理员</a></td>
        </tr>
		<tr>
          <td width="9%" height="20" ><img id="xiaotu9" src="images/images/ico06.gif" width="8" height="12" /></td>
          <td width="91%"><a href="guanliyuanaspx.aspx" target="right" class="left-font03" onClick="tupian('9');">管理员管理</a></td>
        </tr>
		
      </table>
	   
	  </TD>
  </tr>
  
</table>
    </div>
    </form>
</body>
</html>
