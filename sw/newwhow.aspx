<%@ Page Language="C#" AutoEventWireup="true" CodeFile="newwhow.aspx.cs" Inherits="sw_newwhow" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table style="width: 100%;">
                        <tr>
                            <td align="center" class="style1">
                                <h1><asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></h1>
                            </td>
                            
                        </tr>
                        <tr>
                            <td class="style1" align="center">
                               <h3>&nbsp;点击率：<asp:Label 
                                    ID="Label3" runat="server" Text="Label"></asp:Label>
&nbsp; 发表时间：<asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                            &nbsp; 【<asp:HyperLink ID="HyperLink7" runat="server">打印</asp:HyperLink>
                                】&nbsp; 【<asp:HyperLink ID="HyperLink8" runat="server" 
                                    NavigateUrl="~/sw/newguanli.aspx">返回</asp:HyperLink>
                                】</h3></td> 
                            
                        </tr>
                       <tr>
                       <td align="center">

                               <h2><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></h2> 

                       </td>
                       </tr>
                    </table>
    </div>
    </form>
</body>
</html>
