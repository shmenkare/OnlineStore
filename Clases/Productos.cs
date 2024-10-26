using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStore
{
    public class Productos
    {
        public int Id_Prod { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public float Precio { get; set; }
        public int Id_Dep { get; set; }
        public bool Seleccionado { get; set; }

        public Productos() { }
        public Productos(int id_Prod)
        {
            Id_Prod = id_Prod;
        }
        public Productos(string nombre,float precio,bool seleccionado)
        {
           Nombre = nombre;
           Precio = precio;
           Seleccionado = seleccionado;
        }
        public Productos(int id_Prod, string nombre, int cantidad, float precio, int int_Dep)
        {
            Id_Prod = id_Prod;
            Nombre = nombre;
            Cantidad = cantidad;
            Precio = precio;
            Id_Dep = int_Dep;
        }
        
    }
}