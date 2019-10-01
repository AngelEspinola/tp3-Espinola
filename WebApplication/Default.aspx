<%@ Page Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication.Default" %>

<asp:Content runat="server" ID="Default" ContentPlaceHolderID="ContentPlaceHolder1">
    <div style="min-height: 100vh" class="text-center">
        <button id="MainButton" onclick="MainButton_OnClick" style="height:100%" type="button" class="btn btn-info btn-lg">¡Participa del concurso!</button>
        <asp:Button Text="¡Participa!" CssClass="btn btn-info btn-lg" OnClick="MainButton_OnClick" runat="server" />
    </div>
</asp:Content>