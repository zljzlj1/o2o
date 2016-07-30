<%@ Control Language="C#" AutoEventWireup="true" CodeFile="left.ascx.cs" Inherits="UserControl_left" %>
<table style="width: 177px; height: 223px">
    <tr>
        <td style="width: 96px; background-repeat: no-repeat; height: 34px; text-align: center">
        </td>
    </tr>
    <tr>
        <td style="width: 96px; background-repeat: no-repeat;
            height: 22px; text-align: center;">
            <span style="font-size: 10pt; color: #000033;">商品分类</span></td>
    </tr>
    <tr>
        <td style="width: 96px; height: 196px;">
            <asp:DataList ID="DLClass" runat="server" DataKeyField="ClassID" OnEditCommand="DLClass_EditCommand">
                <ItemTemplate>
                    <table style="width: 143px">
                        <tr>
                            <td style="width: 36px">
                                &nbsp;<asp:Image ID="ImageRefine" runat="server" ImageUrl=<%#DataBinder.Eval(Container.DataItem,"CategoryUrl") %> /></td>
                            <td style="width: 100px">
                               <asp:LinkButton ID="lnkbtnClass" runat="server" CommandName="Edit" CausesValidation="False" Font-Underline="False" ForeColor="Red" Font-Size="Smaller" ><%# DataBinder.Eval(Container.DataItem,"ClassName") %></asp:LinkButton></td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList></td>
    </tr>
</table>


