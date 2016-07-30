<%@ Page Language="C#" AutoEventWireup="true" CodeFile="houtaidingdanguanli.aspx.cs" Inherits="sw_houtaidingdanguanli" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    订单管理页面
     
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
            CellPadding="3" DataKeyNames="流水号" ForeColor="Black" GridLines="Vertical" 
            onpageindexchanging="GridView1_PageIndexChanging" 
            onrowcancelingedit="GridView1_RowCancelingEdit" 
            onrowdeleting="GridView1_RowDeleting" onrowediting="GridView1_RowEditing" 
            onrowupdating="GridView1_RowUpdating">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:BoundField DataField="产品流水号" HeaderText="产品号" />
                <asp:BoundField DataField="用户名" HeaderText="用户名" />
                <asp:BoundField DataField="订购数量" HeaderText="订购数量" />
                <asp:BoundField DataField="订购日期" HeaderText="订购日期" />
                <asp:CheckBoxField DataField="处理标志" Text="是否处理" HeaderText="处理标志" />
                <asp:CommandField HeaderText="编辑" ShowEditButton="True" />
                <asp:CommandField HeaderText="删除" ShowDeleteButton="True" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerSettings Visible="False" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="Gray" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
        <br />
        <br />
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
    </div>
    </form>
</body>
</html>
