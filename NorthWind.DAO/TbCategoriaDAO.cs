using NorthWind.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.DAO
{
    public class TbCategoriaDAO
    {
        public static List<TbCategoriaBE> SelectAll()
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["Northwind"].ToString();
            string sql = "Select codCategoria,Nombre,Descripcion from TbCategoria";
            using(SqlConnection connection = new SqlConnection(ConnectionString)){
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection)) {
                    command.CommandType = CommandType.Text;
                    List<TbCategoriaBE> Categorias = new List<TbCategoriaBE>();
                    using (SqlDataReader reader = command.ExecuteReader()) 
                    {
                        while (reader.Read()) {
                            TbCategoriaBE objCategoria = new TbCategoriaBE();
                            objCategoria.CodCategoria = reader.GetInt32(0);
                            objCategoria.Descripcion = reader.GetString(1);
                            objCategoria.Nombre = reader.GetString(2);
                            Categorias.Add(objCategoria);
                        }
                    }
                    return Categorias;
                }

            }
        }
    }
}
