using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class IngresoVoucher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnVerificarVoucher_OnClick(object sender, EventArgs e)
        {
            Response.Write("<script>alert('Data inserted successfully')</script>");
        }
    }
}