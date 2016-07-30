<%@ Page Language="C#" AutoEventWireup="true" CodeFile="newsxin1.aspx.cs" Inherits="sw_newsxin1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <style type="text/css">
    a{ text-decoration:none;}
    </style>
</head>
<body>
     <form id="form1" runat="server">
    <div>
            <table style="width: 100%;" align="center">
                       
                        <tr>
                            <td align="center">
                                &nbsp;
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        GridLines="None" Height="121px" PageSize="5"  Width="618px" 
                        AllowPaging="True"
                        onpageindexchanging="GridView1_PageIndexChanging" CellPadding="4" 
                        ForeColor="#333333">
                        <AlternatingRowStyle BackColor="White" />
                   <Columns>
                   <asp:HyperLinkField DataNavigateUrlFields="流水号" 
                           DataNavigateUrlFormatString="newsshow1.aspx?id={0}" DataTextField="新闻标题"  
                           HeaderText="新闻标题" Target="_blank" />
                    <asp:BoundField DataField="添加时间" HeaderText="添加时间" />
                  <asp:BoundField DataField="新闻类别" HeaderText="新闻类别" />
                  <asp:BoundField DataField="阅读次数" HeaderText="阅读次数" />
                   </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <PagerSettings Visible="False" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                 
                            </td>
                            
                        </tr>
                        <tr>
                            <td align="center">
                                &nbsp;
                                &nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
&nbsp;
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
&nbsp;
        <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument="f" 
            onclick="link">首页</asp:LinkButton>
&nbsp;
        <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument="p" 
            onclick="link">上一页</asp:LinkButton>
&nbsp;&nbsp;
        <asp:LinkButton ID="LinkButton3" runat="server" CommandArgument="n" 
            onclick="link">下一页</asp:LinkButton>
&nbsp;&nbsp;
        <asp:LinkButton ID="LinkButton4" runat="server" CommandArgument="l" 
            onclick="link">末页</asp:LinkButton>
                            </td>
                            
                        </tr>
                    </table>
                             
&nbsp;&nbsp;<br />
        &nbsp;
        <br />
                 
                         <br />
&nbsp;
        <br />
                    &nbsp;
    </div>
    </form>
</body>
</html>
