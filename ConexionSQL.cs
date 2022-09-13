using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudiandoHilos
{
    internal class ConexionSQL
    {
        
        public string setConexion(string pUser, string pContrasena, string pBaseDatos, string pServidor)
        {
            return $"Persist Security Info=False;User ID={pUser};Password={pContrasena};Initial Catalog={pBaseDatos};Server={pServidor}";
        }
        
        
        public bool abrirConexion()
        {
            SqlConnection conexion = new SqlConnection(setConexion("sa", "SQL%2017STAN", "ADESYNETCON_HyS_20220904", "SRV-DATABASE\\SQL2017STAN"));

            try
            {
                conexion.Open();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool Ejecutar()
        {

            return true;
        }

    }
}
