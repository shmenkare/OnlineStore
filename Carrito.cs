using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStore
{
    public class Carrito
    {
        public int Id_Pedido { get; set; }
        public int Id_Prod { get; set; }
        public string Nombre { get; set; }
        public int Cantidad_Item { get; set; }
        public float Subtotal { get; set; }

        public Carrito() { }
        public Carrito(int id_Prod, int cantidad_Item, string nombre, float subtotal)
        {
            Id_Prod = id_Prod;
            Cantidad_Item = cantidad_Item;
            Nombre = nombre;
            Subtotal = subtotal;
        }
        public Carrito(int id_pedido, int id_Prod , string nombre, int cantidad_Item , float subtotal )
        {
            Id_Pedido = id_pedido;
            Id_Prod = id_Prod;
            Nombre = nombre;
            Cantidad_Item = cantidad_Item;
            Subtotal = subtotal;
        }
    }
}