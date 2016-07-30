<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addpro.aspx.cs" Inherits="sw_addpro" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title></title>
    <link rel="stylesheet" href="kindeditor/themes/default/default.css" />
	<link rel="stylesheet" href="kindeditor/plugins/code/prettify.css" />
	<script charset="utf-8" src="kindeditor/kindeditor.js"></script>
	<script charset="utf-8" src="kindeditor/lang/zh_CN.js"></script>
	<script charset="utf-8" src="kindeditor/plugins/code/prettify.js"></script>
	<script>
	    KindEditor.ready(function (K) {
	        var editor1 = K.create('#content1', {
	            cssPath: 'kindeditor/plugins/code/prettify.css',
	            uploadJson: 'kindeditor/asp.net/upload_json.ashx',
	            fileManagerJson: 'kindeditor/asp.net/file_manager_json.ashx',
	            allowFileManager: true,
	            afterCreate: function () {
	                var self = this;
	                K.ctrl(document, 13, function () {
	                    self.sync();
	                    K('form[name=example]')[0].submit();
	                });
	                K.ctrl(self.edit.doc, 13, function () {
	                    self.sync();
	                    K('form[name=example]')[0].submit();
	                });
	            }
	        });
	        prettyPrint();
	    });
	</script>
    <style type="text/css">
        .style1
        {
            height: 25px;
        }
        .style3
        {
            height: 25px;
            width: 203px;
        }
        .style4
        {
            height: 25px;
            width: 268px;
        }
        .style5
        {
            width: 268px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table style="width:58%;">
        <tr>
                <td class="style5">
                    </td>
                <td class="style6" colspan="2">
                   添加产品
                </td>
            </tr>
            
            <tr>
                <td class="style5">
                    产品名称：</td>
                <td class="style7">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
                 <td class="style3" rowspan="3">
                    <asp:Image ID="Image1" runat="server"  Width="100px" Height="250px"/>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    产品价格：</td>
                <td class="style8">
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4" rowspan="2">
                    产品图片:</td>
                <td class="style8" rowspan="2">
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
            </tr>
            <tr>

                <td class="style1">
                    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="上传" />
                </td>
            </tr>
            <tr>
            <td class="style5">
                    产品类别</td>
            <td colspan="2">
                <asp:DropDownList ID="DropDownList1" runat="server">
                </asp:DropDownList>
            </td>
            </tr>
        </table>
        <br />
        产品介绍：<br />
        <textarea id="content1" runat="server" cols="100" name="S1" rows="8" 
            style="width:650px;height:200px;visibility:hidden;"></textarea>
        <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="保存" />
        <br />
        <br />
        &nbsp;&nbsp;
          
    </div>
    </form>
</body>
</html>
