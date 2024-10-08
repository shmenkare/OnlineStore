using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Security;

namespace OnlineStore
{
    public partial class login : System.Web.UI.Page
    {
        private List<Clientes> clientes;
      

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Context.User.Identity.IsAuthenticated)
            {
                Response.Write(Context.User.Identity.Name);
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                try
                {
                    clientes = Sistema.ClientesRegistrados();
                }
                catch (Exception ex)
                {
                    // Manejar la excepción, por ejemplo, mostrar un mensaje de error al usuario
                    lblMensaje.Text = "Ocurrió un error al cargar los datos de los clientes." + ex;
                }
            }
            bool usuarioEncontrado = false;

            foreach (Clientes cli in clientes)
            {
                if (txtUser.Text == cli.Nombre && txtId.Text == cli.Doc_Cli)
                {
                    usuarioEncontrado = true;
                    //clienteLogeado = cli;
                    Session["ClienteLogueado"] = cli;

                    break; // Salir del bucle si se encuentra un usuario válido
                }
            }

            if (usuarioEncontrado)
            {
                //lblMensaje.Text = "BIENVENIDO A ONLINE STORE " + clientes.FirstOrDefault().Nombre;
                // Redirigir a otra página o realizar otras acciones
                //Server.Transfer("Default.aspx");
                FormsAuthentication.RedirectFromLoginPage(txtUser.Text,false);
            }
            else
            {
                lblMensaje.Text = "Usuario o contraseña incorrectos, intente de nuevo";
            }

        }
    }
}