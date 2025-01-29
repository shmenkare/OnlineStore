using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace OnlineStore
{
    public partial class Defaul : System.Web.UI.Page
    {
        private List<Departamentos> departamentos;
        private List<Productos> todosLosProductos;
        private List<Productos> productosMostrar;
        private List<Productos> productosFiltrados;
        private List<Carrito> carrito;
        private List<Carrito> carritoTemp;
        private List<Carrito> realizarPedido;
        private int idDepartamentoSeleccionado;
        private int idPedido;
        private string name;
        private int idprod;
        private int cantidad;
        private float precio;
        private float subTotal;
        private int totItems;
        private float totPrecio;
        private Clientes clienteLogeado;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlDepartamentos.SelectedValue = "1";
                CargarDepartamentos();
                CargarProductosPorDepartamento();
                lblTituloTotalItems.Visible = false;
                lblTotalPedido.Visible = false;
                lblItemAgregado.Visible = false;
                clienteLogeado = new Clientes();
                clienteLogeado = (Clientes)Session["ClienteLogueado"];
                lblClienteLog.Text = clienteLogeado.Nombre;
               
            }
        }
        private void CargarDepartamentos()
        {
            departamentos = Sistema.DepartamentosRegistrados();
            ddlDepartamentos.DataSource = departamentos;
            ddlDepartamentos.DataTextField = "Nombre";
            ddlDepartamentos.DataValueField = "Id_Dep";
            ddlDepartamentos.DataBind();
        }

        protected void ddlDepartamentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                CargarProductosPorDepartamento();
            }
        }

        private void CargarProductosPorDepartamento()
        {
            //idDepartamentoSeleccionado = int.Parse(ddlDepartamentos.SelectedValue);
            //todosLosProductos = Sistema.ProductosDisponibles();
            //productosFiltrados = new List<Productos>();

            //foreach (var producto in todosLosProductos)
            //{
            //    if (producto.Id_Dep == idDepartamentoSeleccionado)
            //    {
            //        productosFiltrados.Add(producto);
            //    }
            //}

            //lsbProductos.DataSource = ProductosMostrar(productosFiltrados);
            //lsbProductos.DataTextField = "Nombre";
            //lsbProductos.DataValueField = "Precio";
            //lsbProductos.DataBind();

            //lblPrecio.Text = "";

            //  ASI SERIA EL CODIGO USANDO LINQ  

            idDepartamentoSeleccionado = int.Parse(ddlDepartamentos.SelectedValue);
            var productos = Sistema.ProductosDisponibles().Where(p => p.Id_Dep == idDepartamentoSeleccionado).ToList();

            lsbProductos.DataSource = productos;
            lsbProductos.DataTextField = "Nombre";
            lsbProductos.DataValueField = "Precio";
            lsbProductos.DataBind();

            lblPrecio.Text = "";

           
        }

        protected void lsbProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
               lblPrecio.Text = lsbProductos.SelectedValue;
               txtCantidad.Focus();
               lblItemAgregado.Visible = false;
            }
        }

        private List<Productos> ProductosMostrar(List<Productos> lista)
        {
            productosMostrar = new List<Productos>();

            foreach (Productos prod in lista)
            {
                productosMostrar.Add(new Productos(prod.Nombre, prod.Precio, prod.Seleccionado));
            }
            return productosMostrar;
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if (txtCantidad.Text == "" || lsbProductos.SelectedItem == null)
                {
                    lblItemAgregado.Text = "Debe ingrear una cantidad o un item valido";
                    lblItemAgregado.ForeColor = Color.Red;
                    lblItemAgregado.Visible = true;
                }
                else
                {
                    name = lsbProductos.SelectedItem.Text;
                    idprod = Sistema.Idproducto(name);
                    cantidad = int.Parse(txtCantidad.Text);
                    precio = float.Parse(lsbProductos.SelectedValue);
                    subTotal = cantidad * precio;
                    carrito = new List<Carrito>();
                    if (Session["Carrito"] != null)
                    {
                        carrito = (List<Carrito>)Session["Carrito"];
                        carrito.Add(new Carrito(idprod, cantidad, name, subTotal));
                        Session["Carrito"] = carrito;
                    }
                    else
                    {
                        carrito.Add(new Carrito(idprod, cantidad, name, subTotal));
                        Session["Carrito"] = carrito;
                    }
                    lblItemAgregado.Visible = true;
                    lblItemAgregado.ForeColor = Color.White;
                    lblItemAgregado.Text = "Producto agregado con exito";
 
                }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                carrito = null;
                Session["Carrito"] = null;
                txtCantidad.Text = "";
                lblPrecio.Text = "";
                lblItemAgregado.Visible = false;
            }
        }

        protected void btnPedido_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Sistema.InicializarPedido();
                idPedido = Sistema.IdPedido();
             
                if (Session["Carrito"] != null)
                {
                    carritoTemp = (List<Carrito>)Session["Carrito"];
                    realizarPedido = new List<Carrito>();
                    foreach (Carrito car in carritoTemp)
                    {
                        realizarPedido.Add(new Carrito(idPedido, car.Id_Prod, car.Nombre, car.Cantidad_Item, car.Subtotal));
                        Sistema.RealizarPedido(idPedido, car.Id_Prod, car.Nombre, car.Cantidad_Item, car.Subtotal);
                        totItems+=car.Cantidad_Item;
                        totPrecio+=car.Subtotal;
                  
                    }

                    lblNumPedido.Text = idPedido.ToString();
                    dgvCarrito.DataSource = realizarPedido;
                    dgvCarrito.DataBind();
                    dgvCarrito.Visible = true;
                    
                    lblTituloTotalItems.Visible = true;
                    lblTotalPedido.Visible = true;
                    lblItemAgregado.Visible = false;

                    btnAgregar.Enabled = false;
                    btnCancelar.Enabled = false;
                    
                    lblTotItems.Text = "El total de articulos es: " + totItems.ToString();
                    lblTotPedido.Text = "El total a cancelar son: " + totPrecio.ToString() + "$";

                    lblMesajePedido.Text = "SU PEDIDO SE REALIZO CON EXITO";
                }
            } 
        }

        protected void btnNuevoPedido_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                carrito = null;
                Session["Carrito"] = null;
                txtCantidad.Text = "";
                lblPrecio.Text = "";
                lblTituloTotalItems.Visible = false;
                lblTotalPedido.Visible = false;
                lblTotItems.Text = "";
                lblTotPedido.Text = "";
                lblMesajePedido.Text = "";
                dgvCarrito.Visible = false;
                lblItemAgregado.Visible = false;
                btnAgregar.Enabled = true;
                btnCancelar.Enabled = true;
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Server.Transfer("login.aspx");
        }

       
    }
}