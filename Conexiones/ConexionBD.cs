using System;
using System.Data;
using System.Data.SqlClient;
#pragma warning disable CS8618



namespace ApiLibro.Conexiones
#pragma warning disable CA2200
{
    public class ConexionBD
    {
        private SqlConnection conexion;
        private SqlCommand comando;

        private SqlDataReader lector; 

        public SqlDataReader Lector
        {
            get { return lector; }
        }


        public ConexionBD()
        {
            conexion = new SqlConnection("server=.\\SQLEXPRESS; database=Biblioteca; integrated security=true;");
            comando = new SqlCommand();

        }

        public void setearQuery(string consulta)

        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        public void setearProcedimiento(string sp)

        {

            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = sp;
        }

        public void setearParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }

        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }

            catch (Exception ex) { throw ex; }
        }

        public void ejecutarAccion()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex) { throw ex; }

        }

        public void cerrarConexion()
        {
            comando.Parameters.Clear();
            if (comando.Connection.State == ConnectionState.Open)
            {
                comando.Connection.Close();
            }
            // Cierra el DataReader si está abierto
            if (lector != null && !lector.IsClosed)
            {
                lector.Close();


            }

            // Cierra la conexión siempre
            if (conexion != null && conexion.State == ConnectionState.Open)
            {
                conexion.Close();
            }
            comando.Dispose();
        }

    }
}
