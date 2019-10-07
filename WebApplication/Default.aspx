<%@ Page Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication.Default" %>

<asp:Content runat="server" ID="Default" ContentPlaceHolderID="ContentPlaceHolder1">
    
    <div style="min-height: 100vh" class="text-center">
        <asp:Button Text="¡Participa!" CssClass="btn btn-info btn-lg" OnClick="MainButton_OnClick" runat="server" />
    </div>
</asp:Content>