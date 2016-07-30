<%@ Page Language="C#" AutoEventWireup="true" CodeFile="chanpintt2.aspx.cs" Inherits="sw_chanpintt2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>深圳市力准传感技术有限公司</title>

    <style type="text/css">
        .style2
        {
            width: 53px;
            height: 8px;
        }
        .style3
        {
            height: 8px;
        }
    </style>
<style type="text/css">

#b a{ text-decoration:none; text-align:center;}
img{ border:0;}

</style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="b">
                                         <asp:DataList ID="DataList1" runat="server" CellPadding="4" RepeatColumns="6" 
            RepeatDirection="Horizontal" Font-Size="Small" Width="120px" 
            >
            <ItemTemplate>
                           <a href='chanpingview.aspx?vid=<%# DataBinder.Eval(Container.DataItem,"流水号") %>' target="_blank"> <asp:Image ID="Image1" runat="server" Height="95px" 
                                ImageUrl='<%# DataBinder.Eval(Container.DataItem,"产品图片") %>' Width="150px" /></a>
                            <br />
                            <img height="11" src="images/33.gif" width="5" alt='b' />名称：<%# DataBinder.Eval(Container.DataItem, "产品名称")%><br /><img height="11" src="images/33.gif" width="5" alt='b' />价格：￥<%# DataBinder.Eval(Container.DataItem, "产品价格")%>元<br /><img height="11"src="images/33.gif" width="5" alt='b' />类别：<%# DataBinder.Eval(Container.DataItem, "产品类别")%><br /><a href='chanpingview.aspx?vid=<%# DataBinder.Eval(Container.DataItem,"流水号") %>' target="_blank"><h4>详细信息</h4></a>
          <br>
            </ItemTemplate>
            
   </asp:DataList>
                    <br />
 <table align="center">               
<TD vAlign="middle" align="center" width="90" colSpan="2" class="style3"><asp:label id="lblCurrentPage" runat="server" Width="90px" Font-Size="9pt"></asp:label></TD>
<TD vAlign="middle" align="right" width="57" class="style3"><asp:linkbutton id="btnFirst" runat="server" CommandArgument="first" Font-Size="9pt" onclick="PagerButtonClick">首页</asp:linkbutton>&nbsp;</TD>
<TD vAlign="middle" align="center" width="60" class="style3"><asp:linkbutton id="btnPrev" runat="server" CommandArgument="prev" Font-Size="9pt" onclick="PagerButtonClick">前一页</asp:linkbutton></TD>
<TD vAlign="middle" align="left" width="51" class="style3"><asp:linkbutton id="btnNext" runat="server" CommandArgument="next" Font-Size="9pt" onclick="PagerButtonClick">下一页</asp:linkbutton></TD>
<TD vAlign="middle" align="left" width="40" class="style3"><asp:linkbutton id="btnLast" runat="server" CommandArgument="last" Font-Size="9pt" onclick="PagerButtonClick">末页</asp:linkbutton></TD>
<TD vAlign="middle" align="left" width="53" class="style2">
<asp:label id="Label2" runat="server" Width="30px" Font-Size="9pt">转到</asp:label></TD>
<TD vAlign="middle" align="center" width="34" class="style3">
    <asp:textbox id="TextBox1" runat="server" Width="31px" Height="10px" 
        BorderStyle="Groove" Font-Size="9pt"></asp:textbox></TD>
<TD vAlign="middle" align="center" width="26" class="style3"><asp:label id="Label3" runat="server" Font-Size="9pt">页</asp:label></TD>
<TD vAlign="middle" align="center" class="style3">
                     &nbsp;<br />
                     <br />
                     <asp:button id="Button1" runat="server" Width="44px" Height="20px" BorderStyle="Groove" Text="确定¨"
Font-Size="9pt" onclick="Button1_Click"></asp:button>
<P>&nbsp;</P>
</TD>
</table>
    </div>
    </form>
</body>
</html>
