<%@ Page Language="C#" AutoEventWireup="true" CodeFile="newguanli.aspx.cs" Inherits="sw_newguanli" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title></title>
     <style>a{ text-decoration:none;}</style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        新闻类型：<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True"
                                    onselectedindexchanged="DropDownList1_SelectedIndexChanged1">
                                </asp:DropDownList><br />
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" DataKeyNames="流水号" 
            CellPadding="4" ForeColor="#333333" 
            GridLines="None" PageSize="5" 
            onpageindexchanging="GridView1_PageIndexChanging1" 
            onrowcancelingedit="GridView1_RowCancelingEdit" 
            onrowdeleting="GridView1_RowDeleting" onrowediting="GridView1_RowEditing" 
            onrowupdating="GridView1_RowUpdating">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="流水号" HeaderText="流水号" />
                <asp:BoundField DataField="新闻标题" HeaderText="新闻标题" />
                <asp:BoundField DataField="新闻类别" HeaderText="新闻类别" />
                <asp:BoundField DataField="添加时间" HeaderText="添加时间" />
                <asp:BoundField DataField="阅读次数" HeaderText="阅读次数" />
                <asp:HyperLinkField FooterText="查看" HeaderText="查看" Text="查看" 
                    DataNavigateUrlFields="流水号" 
                    DataNavigateUrlFormatString="newwhow.aspx?id={0}" />
                <asp:HyperLinkField HeaderText="修改" Text="修改" DataNavigateUrlFields="流水号" 
                    DataNavigateUrlFormatString="xiugainews.aspx?vid={0}" />
                <asp:CommandField HeaderText="编辑" ShowEditButton="True" />
                <asp:CommandField ShowDeleteButton="True" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerSettings Visible="False" />
            <PagerStyle BackColor="#284775" ForeColor="White" 
                HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
    
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
    <p>
        &nbsp;</p>
</body>
</html>
