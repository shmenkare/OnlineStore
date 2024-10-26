using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace OnlineStore
{
    /*public class Metodos
    {
        private static DataSet ds;
        private static Conexion con = new Conexion();

        public static void Consulta(string consulta)
        {
            ds = con.Conectar(consulta);
        }
        public static void Consulta(string consulta, DataGridView dgv)
        {
            ds = con.Conectar(consulta);
            dgv.DataSource = ds.Tables[0];
        }

        public static void Consulta(string consulta, Label lbl)
        {
            ds = con.Conectar(consulta);
            if (ds.Tables[0].Rows.Count == 0)
            {
                lbl.Text = "0";
            }
            else
            {
                lbl.Text = ds.Tables[0].Rows[0][0].ToString();
            }

        }
        public static void Consulta(string consulta, ref int var)
        {
            ds = con.Conectar(consulta);
            var = int.Parse(ds.Tables[0].Rows[0][0].ToString());
        }

        public static void Consulta(string consulta, ref float var)
        {
            ds = con.Conectar(consulta);
            var = float.Parse(ds.Tables[0].Rows[0][0].ToString());
        }
        public static void Consulta(string consulta, ComboBox cbx, string valuemember)
        {
            ds = con.Conectar(consulta);
            cbx.DataSource = ds.Tables[0];
            cbx.ValueMember = valuemember;
        }
    }*/
}