<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Comment.aspx.cs" Inherits="Comment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>jQuery实现用户评论留言代码 - 站长素材</title>

<link rel="stylesheet" href="css/semantic.css" type="text/css" />
<link rel="stylesheet" href="css/zyComment.css" type="text/css" />

<style type="text/css" media="print, screen">  
label {
	font-weight: bold;
}

a {
	font-family: Microsoft YaHei;
}

#articleComment {
	width: 600px;
	margin:0 auto;
}
</style> 

</head>
<body>
	<div id="articleComment"></div>
	
	<script type="text/javascript" src="js/jquery-1.7.2.min.js"></script>
	<script type="text/javascript" src="js/zyComment.js"></script>
	
	<script type="text/javascript">
	    $(function () {
	        getCommentList();
	    });
	    function getCommentList() {
	        $.ajax({
	            type: "POST", //要用post方式
	            //data: "{str1:{str:1,str2:'asdasd'}}",
	            //"{str:我是,str2:XXX}"
	            data: "{txtid: 2}",
	            url: "Comment.aspx/getCommentList", //方法所在页面和方法名
	            contentType: "application/json; charset=utf-8",
	            dataType: "json",
	            success: function (data) {
	                kk(data.d);
	            },
	            error: function (err) {
	                alert("发生错误");
	            }
	        });
	    }
	    function setCommentList(last) {
	        $.ajax({
	            type: "POST", //要用post方式
	            //data: "{str1:{str:1,str2:'asdasd'}}",
	            //"{str:我是,str2:XXX}"
	            data: last,
	            url: "Comment.aspx/setComment", //方法所在页面和方法名
	            contentType: "application/json; charset=utf-8",
	            dataType: "json",
	            success: function (data) {
	                if (data.d.result == true) {
	                    // $("#articleComment").zyComment("setCommentAfter", data.d.data);
	                    $("#articleComment").empty();
	                    getCommentList();

	                } else {
	                    alert(data.d.msg)
	                }
	            },
	            error: function (err) {
	                alert("发生错误");
	            }
	        });
	    }
	    function replay(bu) {
	        replyClickEvent();
        }
	    function kk(agoComment) {
	        $("#articleComment").zyComment({
	            "width": "355",
	            "height": "33",
	            "agoComment": agoComment,
	            "callback": function (comment) {
	                console.info("填写内容返回值：");
	                console.info(comment);
	                if (comment.yhpl == '' || comment.yhpl == null) {
	                    alert("评论内容不能为空");
	                }
	                else {
	                    var last = JSON.stringify(comment); //将JSON对象转化为JSON字符
	                    // 添加新的评论
	                    //$("#articleComment").zyComment("setCommentAfter", { "wzplid": 123, "plyhid": "userNam", "yhpl": "comment", "plsj": "2014-04-14" });
	                    setCommentList(last)
	                }
	            }
	        });
	    }

	</script>

<div style="text-align:center;margin:50px 0; font:normal 14px/24px 'MicroSoft YaHei';">
</div>

</body>
</html>
