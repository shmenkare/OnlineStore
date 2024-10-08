using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStore
{
    public class Ventas
    {
        public int Id_Venta { get; set; }
        public int Tot_Prod { get; set; }
        public float Tot_Venta { get; set; }
        public int Id_Prod { get; set; }
        public int Id_Client { get; set; }

        public Ventas() { }
        public Ventas(int id_Venta, int tot_Prod, float tot_Venta, int id_Prod, int id_Client)
        {
            Id_Venta = id_Venta;
            Tot_Prod = tot_Prod;
            Tot_Venta = tot_Venta;
            Id_Prod = id_Prod;
            Id_Client = id_Client;
        }
    }
}