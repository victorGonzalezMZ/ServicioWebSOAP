using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;

namespace ServicioWebSOAP
{
    public class ServicioWeb : System.Web.Services.WebService
    {
        [WebMethod]
        public int validaUsuario(string usuario, string password)
        {
            var Conexion = new SqlConnection
                ("data source=VICTOR-LAP; Initial Catalog=acceso; User ID=sa; Password=sa123");
            var Consulta = new SqlCommand
                ("SELECT COUNT(*) FROM Datos Where usuario='" + usuario + 
                "' and password='" + password + "'", Conexion);
            int verificar = 0;

            try
            {
                Conexion.Open();
                verificar = int.Parse(Consulta.ExecuteScalar().ToString());
                Conexion.Close();
                return verificar;
            }
            catch (Exception ex)
            {
                return verificar;
            }
        }

        [WebMethod]
        public string extraerRutaImagen(string usuario)
        {
            var Conexion = new SqlConnection
                ("data source=VICTOR-LAP; Initial Catalog=acceso; User ID=sa; Password=sa123");
            var Consulta = new SqlDataAdapter
                ("SELECT ruta FROM Datos Where usuario='" + usuario + "'", Conexion);
            var Conjunto = new DataSet();
            DataRow Renglon;
            string ruta = null;

            try
            {
                Conexion.Open();
                Consulta.Fill(Conjunto, "Datos");
                Conexion.Close();
                Renglon = Conjunto.Tables["Datos"].Rows[0];
                ruta = Renglon["ruta"].ToString();
                return ruta;
            }
            catch (Exception ex)
            {
                return ruta;
            }
        }
    }
}
