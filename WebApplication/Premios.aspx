<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Premios.aspx.cs" Inherits="WebApplication.Premios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card-columns" style="margin-left: 10px; margin-right: 10px;">

        <% foreach (var item in listaProductos)
            { %>
        <div class="card" style="margin:auto; margin-top:10px">
            <img src="<% = item.URLImagen %>" class="card-img-top" alt="...">
            <div class="card-body">
                <h5 class="card-title"><% = item.Titulo %></h5>
                <p class="card-text"><% = item.Descripcion %></p>
            </div>
            <a class="btn btn-primary" href="PokemonDetail.aspx?idpkm=<% = item.ID.ToString() %>">Seleccionar</a>
        </div>
        <% } %>
    </div>
</asp:Content>
