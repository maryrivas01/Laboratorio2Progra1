using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Producto
    {
        public  CD_Conexion connect = new CD_Conexion();

        SqlDataReader leer; 
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable Mostrar()
        {
            comando.Connection = connect.AbrirConexion();
            comando.CommandText = "LeerProductos"; 
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            connect.CerrarConexion();
            return tabla;
        }

        public void Insertar(string nombre, string desc, double precio, int cantidad, int estado)
        {
            comando.Connection = connect.AbrirConexion();
            comando.CommandText = "InsertarProductos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nomprod", nombre);
            comando.Parameters.AddWithValue("@descripcion", desc);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.Parameters.AddWithValue("@cantidad", cantidad);
            comando.Parameters.AddWithValue("@estado", estado);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public void Actualizar(string nombre, string desc, double precio, int cantidad, int estado, int idproducto)
        {
            comando.Connection = connect.AbrirConexion();
            comando.CommandText = "ActualizarProductos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nomprod", nombre);
            comando.Parameters.AddWithValue("@descripcion", desc);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.Parameters.AddWithValue("@cantidad", cantidad);
            comando.Parameters.AddWithValue("@estado", estado);
            comando.Parameters.AddWithValue("@idproducto", idproducto);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public void Borrar(int idproducto)
        {
            comando.Connection = connect.AbrirConexion();
            comando.CommandText = "InsertarProductos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idprod", idproducto);
            
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }
    }
}
