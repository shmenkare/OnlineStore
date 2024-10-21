using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace OnlineStore
{
    public class Conexion
    {
        private SqlConnection con;
        private SqlDataAdapter da;
        private DataSet ds;
        //private string cadena = "Data Source=.;Initial Catalog=OnLineStore;Integrated Security=True;Encrypt=False";
        private string cadena = ConfigurationManager.ConnectionStrings["OnlineDB"].ConnectionString;


        public DataSet Conectar(string sql)
        {
            try
            {
                con = new SqlConnection(cadena);
                con.Open();
                da = new SqlDataAdapter(sql, con);
                ds = new DataSet();
                da.Fill(ds);
                con.Close();
            }
            catch (SqlException e)
            {
                               
                //MessageBox.Show("La coneccion ha fallado o ha habido un error en la base de datos, intente de nuevo" + e);

            }
            return ds;
        }
    }
}