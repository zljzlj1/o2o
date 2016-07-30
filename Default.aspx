<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>jQuery火焰灯动画导航条 - 站长素材</title>
<style type="text/css">

body{background:#eeeeee;color:#333333;font-family:'宋体',Verdana, Geneva, sans-serif;}
.zxx_test_list{width:520px;margin:40px auto;}
.zxx_test_list{border-bottom:0; padding-bottom:40px;}

</style>

  <link href="css/wdcz.css" rel="Stylesheet" type="text/css" />
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
</script>

</head>

<body>


<div class="zxx_test_list">

	<ul class="lava_with_image fix" id="1">
		<li class="current"><a href="#zhangxinxu">圣诞节</a></li>
		<li><a href="#zhangxinxu">地震</a></li>
		<li><a href="#zhangxinxu">股市</a></li>
		<li><a href="#zhangxinxu">《十月围城》</a></li>
		<li><a href="#zhangxinxu">无线音乐咪咕汇</a></li>
	</ul>
	
</div>

</body>
</html>