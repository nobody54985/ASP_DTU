<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DANHMUC.aspx.cs" Inherits="DANHMUC" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 30px;
        }
        .auto-style2 {
            width: 271px;
        }
        .auto-style3 {
            height: 30px;
            width: 271px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 263px; width: 316px">
    
        <table style="width:110%; height: 275px;">
            <tr>
                <td colspan="2" style="text-align: center">QUẢN LÝ DANH MỤC</td>
            </tr>
            <tr>
                <td>Mã danh muc</td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtMAM" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Tên danh mục</td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtTENDM" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    &nbsp;</td>
                <td class="auto-style3">
                    <asp:Button ID="btn_Save" runat="server"  Text="Lưu" OnClick="btn_Save_Click" />
                    <asp:Button ID="btn_Xoa" runat="server"  Text="Xóa" OnClick="btn_Xoa_Click" />
                    <asp:Button ID="btn_Sua" runat="server"  Text="Sửa" OnClick="btn_Xoa_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1" colspan="2">
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" Width="349px">
            <AlternatingRowStyle BackColor="#F7F7F7" />
            <Columns>
                <asp:BoundField DataField="MADM" HeaderText="Mã danh mục" />
                <asp:BoundField DataField="TENDM" HeaderText="Tên danh mục" />
                <asp:TemplateField HeaderText="Xóa">
                    <ItemTemplate>
                        <asp:CheckBox ID="cbo_Xoa" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                Mã danh mục
            </EmptyDataTemplate>
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            <SortedAscendingCellStyle BackColor="#F4F4FD" />
            <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
            <SortedDescendingCellStyle BackColor="#D8D8F0" />
            <SortedDescendingHeaderStyle BackColor="#3E3277" />
        </asp:GridView>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
