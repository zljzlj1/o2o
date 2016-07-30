<%@ Page Language="C#" AutoEventWireup="true" CodeFile="productguanli.aspx.cs" Inherits="sw_productguanli" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>a{ text-decoration:none;}</style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" DataKeyNames="流水号" 
            onpageindexchanging="GridView1_PageIndexChanging" 
            onrowcancelingedit="GridView1_RowCancelingEdit" 
            onrowdeleting="GridView1_RowDeleting" onrowediting="GridView1_RowEditing" 
            onrowupdating="GridView1_RowUpdating" PageSize="5">
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
            <Columns>
                <asp:BoundField DataField="流水号" HeaderText="流水号" />
                <asp:BoundField DataField="产品名称" HeaderText="产品名称" />
                <asp:BoundField DataField="产品价格" HeaderText="产品价格" />
                <asp:BoundField DataField="产品类别" HeaderText="产品类别" />
                <asp:HyperLinkField FooterText="查看" HeaderText="查看" Text="查看" 
                    DataNavigateUrlFields="流水号" 
                    DataNavigateUrlFormatString="productview1.aspx?vid={0}" />
                <asp:HyperLinkField HeaderText="修改" Text="修改" DataNavigateUrlFields="流水号" 
                    DataNavigateUrlFormatString="alterpro.aspx?vid={0}" />
                <asp:CommandField HeaderText="编辑" ShowEditButton="True" />
                <asp:CommandField ShowDeleteButton="True" />
            </Columns>
            <FooterStyle BackColor="Tan" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
            <PagerSettings Visible="False" />
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
                HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <SortedAscendingCellStyle BackColor="#FAFAE7" />
            <SortedAscendingHeaderStyle BackColor="#DAC09E" />
            <SortedDescendingCellStyle BackColor="#E1DB9C" />
            <SortedDescendingHeaderStyle BackColor="#C2A47B" />
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
</body>
</html>
