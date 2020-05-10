<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_USER.master" AutoEventWireup="true" CodeFile="WEBGIOHANG.aspx.cs" Inherits="WEBGIOHANG" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="gridGIOHANG" runat="server" AutoGenerateColumns="False" Height="62px" Width="614px" AllowPaging="True" OnPageIndexChanging="gridGIOHANG_PageIndexChanging" PageSize="2">
        <Columns>
            <asp:BoundField DataField="MAMH" HeaderText="Mã mặt hàng" />
            <asp:BoundField DataField="TENMH" HeaderText="Tên mặt hàng" />
            <asp:BoundField DataField="SOLUONG" HeaderText="Số lượng" />
            <asp:BoundField DataField="DONGIA" HeaderText="Đơn giá" />
            <asp:BoundField DataField="THANHTIEN" HeaderText="Thành tiền" />
            <asp:ImageField DataImageUrlField="ANHMATHANG" HeaderText="Hình ảnh" ControlStyle-Height="80px" ControlStyle-Width="100px"  >
            </asp:ImageField>
            <asp:TemplateField HeaderText="Trả hàng">
                <ItemTemplate>
                    <asp:CheckBox ID="ckbTRAHANG" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Button ID="btnTRAHANG" runat="server" OnClick="btnTRAHANG_Click" Text="Trả Hàng" />
    <asp:Button ID="btnTHANHTOAN" runat="server" Text="Thanh toán" />
</asp:Content>

