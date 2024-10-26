using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


namespace OnlineStore
{
    public class Sistema
    {
        private static Conexion con;
        private static DataSet ds;
        private static List<Productos> productos;
        private static List<Clientes> clientes;
        private static List<Departamentos> departamentos;
        private static List<Carrito> carrito;
        

       //OBTENER PRODUCTOS
        
        public static List<Productos> ProductosDisponibles()
        {
            con = new Conexion();
            ds = con.Conectar("SELECT * FROM Productos");

            productos = new List<Productos>();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                productos.Add(new Productos(int.Parse(ds.Tables[0].Rows[i]["Id_Prod"].ToString()),
                ds.Tables[0].Rows[i]["Nombre"].ToString(), int.Parse(ds.Tables[0].Rows[i]["Cantidad"].ToString()),
                float.Parse(ds.Tables[0].Rows[i]["Precio"].ToString()), int.Parse(ds.Tables[0].Rows[i]["Id_Dep"].ToString())));
            }
            return productos;
        }

        //OBTENER CLIENTES

        public static List<Clientes> ClientesRegistrados()
        {
            con = new Conexion();
            ds = con.Conectar("SELECT Doc_Cli, Nombre FROM Clientes");

            clientes = new List<Clientes>();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                clientes.Add(new Clientes(ds.Tables[0].Rows[i]["Doc_Cli"].ToString(),
                ds.Tables[0].Rows[i]["Nombre"].ToString()));
            }
            return clientes;
        }


        //OBTENER DEPARTAMENTOS

        public static List<Departamentos> DepartamentosRegistrados()
        {
            con = new Conexion();
            ds = con.Conectar("SELECT Id_Dep, Nombre FROM Departamentos");

            departamentos = new List<Departamentos>();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                departamentos.Add(new Departamentos(int.Parse(ds.Tables[0].Rows[i]["Id_Dep"].ToString()),
                ds.Tables[0].Rows[i]["Nombre"].ToString()));
            }
            return departamentos;
        }

        //OBTENER ID PRODUCTO

        public static int Idproducto(string name)
        {
            con = new Conexion();
            ds = con.Conectar(String.Format("SELECT Id_prod FROM Productos where Nombre = '{0}';", name));

            int id = int.Parse(ds.Tables[0].Rows[0]["Id_Prod"].ToString());

            return id;
        }

        //REALIZAR PEDIDO

        public static void InicializarPedido()
        {
            con = new Conexion();
            ds = con.Conectar("insert into Pedido values('Realizado');");
        }
        public static int IdPedido()
        {
            con = new Conexion();
            ds = con.Conectar("SELECT TOP 1 Id_Pedido FROM Pedido ORDER BY Id_Pedido DESC;");
            int ped = int.Parse(ds.Tables[0].Rows[0]["Id_Pedido"].ToString());
            return ped;
        }

        //LLENAR CARRITO

        public static void RealizarPedido(int id_pedido, int id_Prod, string nombre, int cantidad_Item, float subtotal)
        {
            con = new Conexion();
            ds = con.Conectar(String.Format("insert into Carrito values({0},{1},'{2}',{3},{4})",id_pedido,id_Prod,nombre,cantidad_Item,subtotal));
        }

       
    }   
}