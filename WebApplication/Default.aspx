<%@ Page Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication.Default" %>

<asp:Content runat="server" ID="Default" ContentPlaceHolderID="ContentPlaceHolder1">
    
    <div style="min-height: 100vh" class="text-center">
        <div>
        BIENVENIDO!
            APROVECHA TU COMPRA Y UTILIZA EL VOUCHER CON EL QUE VINO PARA GANARTE LOS MEJORES PREMIOS
        </div>
        <asp:Button Text="¡Participa!" CssClass="btn btn-info btn-lg" OnClick="MainButton_OnClick" runat="server" />
    </div>
</asp:Content>