﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="DetallesCliente.aspx.cs" Inherits="WebApplication.DetallesCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
        <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
        <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>

    <script src="DetallesCliente.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
    <h1>Ingresa tus datos!</h1>
    
    
        <div class="form-group">
            <label>DNI</label>
            <asp:TextBox ID="txtDNI" MaxLength="20" ClientIDMode="Static" CssClass="form-control" runat="server" />
            <asp:Button Text="Buscar"  CssClass="btn btn-info btn-lg" runat="server"  OnClick="BuscarCUIT"/>
        </div>
        <div class="form-group">
            <label>Nombre</label>
            <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" />
        </div>
    <div class="form-group">
            <label>Apellido</label>
            <asp:TextBox ID="txtApellido" MaxLength="20" ClientIDMode="Static" CssClass="form-control" runat="server" />
        </div>
    <div class="form-group">
            <label>Email</label>
            <asp:TextBox ID="txtEmail" MaxLength="20" ClientIDMode="Static" CssClass="form-control" runat="server" />
        </div>
    <div class="form-group">
            <label>Direccion</label>
            <asp:TextBox ID="txtDireccion" MaxLength="20" ClientIDMode="Static" CssClass="form-control" runat="server" />
        </div>
    <div class="form-group">
            <label>Ciudad</label>
            <asp:TextBox ID="txtCiudad" MaxLength="20" ClientIDMode="Static" CssClass="form-control" runat="server" />
        </div>
    <div class="form-group">
            <label>Codigo Postal</label>
            <asp:TextBox ID="txtCodigoPostal" MaxLength="20" ClientIDMode="Static" CssClass="form-control" runat="server" />
        </div>
    <div class="form-group">
            <label>Fecha de Registro</label>
            <asp:TextBox ID="txtFechaRegistro" MaxLength="20" ClientIDMode="Static" CssClass="form-control" runat="server" />    
    </div>
    <asp:Button Text="Aceptar" ID="btnAceptar" autopostback="false"  OnClientClick="validar();return false;" OnClick ="CargarDatos"  CssClass="btn btn-primary" runat="server" />

</asp:Content>