<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_USER.master" AutoEventWireup="true" CodeFile="DANHSACHMATHANG.aspx.cs" Inherits="DANHSACHMATHANG" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:DataList ID="DataList1" runat="server" RepeatColumns="3"  style="margin-right: 238px; margin-top: 110px">
        <ItemTemplate>
            <BR>
            <a href ="CHITIETSANPHAM.aspx?MAMH=<%# Eval("MAMH") %>"><img src="<%# Eval("ANHMATHANG")%>" width="200px" height="150px" /></a>
            <div style="background-color:whitesmoke; width:200px; height:150px;text-align:center">
            <BR>

            <%# Eval("TENMH") %> 
            </div>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>

