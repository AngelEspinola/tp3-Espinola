using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;


namespace WebApplication
{
    public partial class Premios : System.Web.UI.Page
    {
        public List<Producto> listaProductos { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                ProductoNegocio negocio = new ProductoNegocio();
                listaProductos = negocio.listar();
                //dgvPokemones.DataSource = negocio.listar();
                //dgvPokemones.DataBind();

                //cboPokemons.DataSource = listaPokemons;
                //cboPokemons.DataBind();

                if (!IsPostBack)
                { //pregunto si es la primera carga de la page
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}