<%@ Control Language="C#" AutoEventWireup="true" CodeFile="left.ascx.cs" Inherits="UserControl_left" %>
<table style=" width: 177px; height: 223px; margin-left: 80px;" 
   >
 
    <tr>
        <td style="width: 100px; background-repeat: no-repeat;
            height: 22px; ">
            <span style="font-size: 24px; color: #000033; font-family: 华文宋体;"><b>商品分类</b></span></td>
    </tr>
    <tr>
        <td style="width: 100px; height: 196px;" >
            <asp:DataList ID="Splb" runat="server" DataKeyField="splbid" 
                OnEditCommand=" Splb_EditCommand" Font-Names="宋体">
                <ItemTemplate>
                    <table style="width: 143px;height: 30px; ">
                        <tr>
                            <td style="width: 16px">&nbsp;<asp:Image ID="Image2" runat="server" ImageUrl="~/image/bg2.gif" /> 
                        </td>
                            <td style="width: 100px">
                                <asp:LinkButton ID="lnkbtnClass" runat="server" CommandName="Edit" CausesValidation="False" Font-Underline="False" ForeColor="Black" Font-Size="Medium" ><%# DataBinder.Eval(Container.DataItem, "lbmc")%></asp:LinkButton></td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList></td>
    </tr>
</table>


