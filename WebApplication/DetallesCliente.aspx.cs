using System;
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
            Cliente cliente;
            ClienteNegocio negocio = new ClienteNegocio();
            List<Cliente> listaClientes;
            listaClientes = negocio.listar();
            cliente = listaClientes.Find(X => X.DNI == txtDNI.Text);
            if (cliente != null)
            {
                txtNombre.Text = cliente.Nombre.ToString();
                txtApellido.Text = cliente.Apellido.ToString();
                txtEmail.Text = cliente.Email.ToString();
                txtDireccion.Text = cliente.Direccion.ToString();
                txtCiudad.Text = cliente.Ciudad.ToString();
                txtCodigoPostal.Text = cliente.CodigoPostal.ToString();
                txtFechaRegistro.Text = cliente.FechaRegistro.ToShortDateString();
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
            // CARGAR ID CLIENTE - ID PRODUCTO  - FECHA REGISTRO EN VOUCHER
        }
    }
}