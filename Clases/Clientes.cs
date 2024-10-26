using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStore
{
    public class Clientes
    {
        public int Id_Client { get; set; }
        public string Doc_Cli { get; set; }
        public string Nombre { get; set; }
        public string Dir { get; set; }
        public string Tlf { get; set; }

        public Clientes() { }
        public Clientes(string doc_Cli, string nombre)
        {
            Doc_Cli = doc_Cli;
            Nombre = nombre;
        }
        public Clientes(int id_Client, string doc_Cli, string nombre, string dir, string tlf)
        {
            Id_Client = id_Client;
            Doc_Cli = doc_Cli;
            Nombre = nombre;
            Dir = dir;
            Tlf = tlf;
        }
    }
}