<%@ Page Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="IngresoVoucher.aspx.cs" Inherits="WebApplication.IngresoVoucher" %>
<asp:Content runat="server" ID="Default" ContentPlaceHolderID="ContentPlaceHolder1">
    <div style="min-height: 100vh" class="text-center">
        <asp:Button Text="Verificar Voucher" class="btn btn-info" OnClick="btnVerificarVoucher_OnClick" runat="server" />
        <asp:TextBox runat="server" ID="txtIngresoVoucher"/>

    </div>
</asp:Content>