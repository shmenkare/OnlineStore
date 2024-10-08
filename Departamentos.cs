using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStore
{
    public class Departamentos
    {
        public int Id_Dep { get; set; }
        public string Nombre { get; set; }
        public string Descrip { get; set; }

        public Departamentos() { }
        public Departamentos(int id_Dep, string nombre)
        {
            Id_Dep = id_Dep;
            Nombre = nombre;
        }
        public Departamentos(int id_Dep, string nombre, string descrip)
        {
            Id_Dep = id_Dep;
            Nombre = nombre;
            Descrip = descrip;
        }
    }
}