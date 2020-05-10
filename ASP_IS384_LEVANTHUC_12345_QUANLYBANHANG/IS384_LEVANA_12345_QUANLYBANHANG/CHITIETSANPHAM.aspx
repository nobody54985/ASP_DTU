<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_USER.master" AutoEventWireup="true" CodeFile="CHITIETSANPHAM.aspx.cs" Inherits="CHITIETSANPHAM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Repeater ID="Repeater2" runat="server">
        <ItemTemplate>
            <div style ="  width:550px;height:350px">
            <%# Eval("MOTA") %>
            
              <img src="<%# Eval("ANHMATHANG")%>" width="300px" height="250px" align ="left" />
            <BR>
            <%# Eval("TENMH") %>     Giá :  <%# Eval("DONGIA") %> USD
            
             </div>
        </ItemTemplate>
    </asp:Repeater>
    <asp:DropDownList ID="drop_SOLUONG" runat="server">
    </asp:DropDownList>
    <asp:Button ID="btn_Giohang" runat="server" OnClick="btn_GioHang_Click" Text="Giỏ hàng" />
</asp:Content>


