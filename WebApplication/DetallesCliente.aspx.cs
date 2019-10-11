﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;
using AccesoDatos;

namespace WebApplication
{
    public partial class DetallesCliente : System.Web.UI.Page
    {
        Producto producto;
        Cliente clienteLocal;

        protected void Page_Load(object sender, EventArgs e)
        {
            var productoID = Convert.ToInt32(Request.QueryString["idpkm"]);
            ProductoNegocio negocio = new ProductoNegocio();
            List<Producto> listaProductos = negocio.listar();
            producto = listaProductos.Find(J => J.ID == productoID);
            
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid)
            return;
        }

        public void BuscarCUIT(object sender, EventArgs e)
        {
            ClienteNegocio negocio = new ClienteNegocio();
            List<Cliente> listaClientes;
            listaClientes = negocio.listar();
            clienteLocal = listaClientes.Find(X => X.DNI == txtDNI.Text);
            if (clienteLocal != null)
            {
                txtNombre.Text = clienteLocal.Nombre.ToString();
                txtApellido.Text = clienteLocal.Apellido.ToString();
                txtEmail.Text = clienteLocal.Email.ToString();
                txtDireccion.Text = clienteLocal.Direccion.ToString();
                txtCiudad.Text = clienteLocal.Ciudad.ToString();
                txtCodigoPostal.Text = clienteLocal.CodigoPostal.ToString();
                txtFechaRegistro.Text = clienteLocal.FechaRegistro.ToShortDateString();
                Session["ClienteID" + Session.SessionID] = negocio.traerIDCliente(txtDNI.Text);
            }
            else
            {
                string msg = "<script language=\"javascript\">";
                msg += "alert(' DNI no encontrado ');";
                msg += "</script>";
                Response.Write(msg);
            }
        }
        public void MainButton_OnClick(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("/IngresoVoucher.aspx");
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void CargarDatos(object sender, EventArgs e)
        {
            string voucher = Session["Voucher" + Session.SessionID].ToString();
            VoucherNegocio negocioVoucher = new VoucherNegocio();
            ClienteNegocio negocioCliente = new ClienteNegocio();
            clienteLocal = new Cliente();

            if (Session["ClienteID" + Session.SessionID] == null)
            {
                clienteLocal.DNI = txtDNI.Text;
                clienteLocal.Apellido = txtApellido.Text;
                clienteLocal.Nombre = txtNombre.Text;
                clienteLocal.Email = txtEmail.Text;
                clienteLocal.Direccion = txtDireccion.Text;
                clienteLocal.Ciudad = txtCiudad.Text;
                clienteLocal.CodigoPostal = txtCodigoPostal.Text;
                clienteLocal.FechaRegistro = Convert.ToDateTime(txtFechaRegistro.Text);

                negocioCliente.agregar(clienteLocal);
                clienteLocal.ID = Convert.ToInt32(negocioCliente.traerIDCliente(clienteLocal.DNI));
            }
            else
            {
                clienteLocal.ID = Convert.ToInt32(Session["ClienteID" + Session.SessionID]);
            }

            negocioVoucher.modificar(voucher, clienteLocal.ID, producto.ID);
            // CARGAR ID CLIENTE - ID PRODUCTO  - FECHA REGISTRO EN VOUCHER
        }
    }
}