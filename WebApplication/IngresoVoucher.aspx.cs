using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AccesoDatos;
using Negocio;
using Dominio;

namespace WebApplication
{
    public partial class IngresoVoucher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnVerificarVoucher_OnClick(object sender, EventArgs e)
        {
            List<Voucher> listaVoucher;
            try
            {
            VoucherNegocio voucherNeg = new VoucherNegocio();
            Voucher voucher;
            listaVoucher = voucherNeg.listar();
                voucher = listaVoucher.Find(X => X.Codigo == txtIngresoVoucher.Text);
                if (voucher != null && voucher.Estado == false)
                {
                    Session["Voucher" + Session.SessionID] = txtIngresoVoucher.Text;
                    Response.Redirect("Premios.aspx");
                }
                else if (voucher == null)
                {
                    Session["Error" + Session.SessionID] = "El voucher ingresado no existe! ¿Seguro que no lo ingresaste mal?";
                    Response.Redirect("Error.aspx");
                }
                else if (voucher != null && voucher.Estado == true)
                {
                    Session["Error" + Session.SessionID] = "El voucher ingresado ya ha sido utilizado! :C";
                    Response.Redirect("Error.aspx");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}