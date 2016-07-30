<%@ Page Language="C#" AutoEventWireup="true" CodeFile="productview1.aspx.cs" Inherits="sw_productview1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     详情信息&nbsp;<asp:HyperLink ID="HyperLink1" runat="server" 
            NavigateUrl="~/sw/productguanli.aspx">返回</asp:HyperLink>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        &nbsp;&nbsp;&nbsp;
        <br />
        <hr style="background-color: #000080" />
        <br />
        <table style="width:100%;">
            <tr>
                <td class="style4">
                    流水号:<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </td>
                <td rowspan="5">
                    <asp:Image ID="Image1" runat="server" Width="200px"/>
                </td>

            </tr>
            <tr>
                <td class="style2">
                    产品名称:<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                </td>
               
            </tr>
            <tr>
                <td class="style3">
                    产品价格:<asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                </td>
                
            </tr>
            <tr>
                <td class="style1">
                    产品类别:<asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                </td>
                
            </tr>
            <tr>
                <td class="style1">
                    产品介绍:<asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                </td>
                
            </tr>
            
        </table>
    </div>
    </form>
</body>
</html>

