using NorthWind.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.DAO
{
    public class TbDocumentoDao
    {
        //public eEstadoDocumento
        public eEstadoProceso GuardarDocumento(DocumentoBE oDocumentoDTO) { 
            //Guardar Cabecera
            /*string codigodocumentogenerado = "";
            var ConnectionString = @"Data Source=.;Initial Catalog=Northwind;Integrated Security=SSPI";
            using (var conn = new SqlConnection(ConnectionString)) {
                conn.Open();
                using (var cmd = new SqlCommand("GuardarCab", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@codcliente", SqlDbType.Int).Value = oDocumentoDTO.Cabecera.Cliente.CodCliente;
                    cmd.Parameters.Add("@subtotal", SqlDbType.Int).Value = oDocumentoDTO.Cabecera.SubTotal;
                    cmd.Parameters.Add("@igv", SqlDbType.Int).Value = oDocumentoDTO.Cabecera.IGV;
                    cmd.Parameters.Add("@total", SqlDbType.Int, 50).Value = oDocumentoDTO.Cabecera.Total;
                    cmd.Parameters.Add("@fechahora", SqlDbType.SmallDateTime).Value = oDocumentoDTO.Cabecera.FechaHora;
                    cmd.Parameters.Add("@tipodocumento", SqlDbType.NVarChar,50).Value = oDocumentoDTO.Cabecera.TipoDocumento.ToString();
                    //cmd.ExecuteNonQuery()
                    using (SqlDataReader reader = cmd.ExecuteReader()) {
                        while (reader.Read()) {
                            codigodocumentogenerado = reader["CodigoGenerado"].ToString();
                        }
                    }
                }
                //Guarda Detalle
                foreach (var itemlista in oDocumentoDTO.Detalle) {
                    using (SqlCommand command = new SqlCommand("GuardarDet", conn)) {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@coddocumento", SqlDbType.Int).Value = codigodocumentogenerado;
                        command.Parameters.Add("@codproducto", SqlDbType.Int).Value = itemlista.Producto.CodProducto;
                        command.Parameters.Add("@precio", SqlDbType.Int).Value = itemlista.Precio;
                        command.Parameters.Add("@cantidad", SqlDbType.Int).Value = itemlista.Cantidad;
                        command.Parameters.Add("@total", SqlDbType.Decimal).Value = itemlista.Total;

                        command.ExecuteNonQuery();
                    }
                }
                conn.Close();
            }
            return eEstadoProceso.Correcto;*/
            //Tipo de guardado dos, por TVP!!
            //Para asignar el detalle de la cabecera al detalle,
            //sera necesario obtener el ultimo id de la cabecera y aumentarle 1
            oDocumentoDTO.Cabecera.CodDocumento = "22";//<- ultimo mas 1
            var headers = new DataTable();
            //headers.Columns.Add("coddocumento", typeof(string));
            headers.Columns.Add("codcliente", typeof(string));
            headers.Columns.Add("subtotal", typeof(decimal));
            headers.Columns.Add("igv", typeof(decimal));
            headers.Columns.Add("total", typeof(decimal));
            headers.Columns.Add("fechahora", typeof(DateTime));
            headers.Columns.Add("tipodocumento", typeof(string));

            var details = new DataTable();
            details.Columns.Add("coddocumento", typeof(int));//
            details.Columns.Add("codproducto", typeof(int));//
            details.Columns.Add("precio", typeof(decimal));
            details.Columns.Add("cantidad", typeof(int));
            details.Columns.Add("total", typeof(decimal));

            headers.Rows.Add(new Object[]{
                //oDocumentoDTO.Cabecera.CodDocumento,
                oDocumentoDTO.Cabecera.Cliente.CodCliente,
                oDocumentoDTO.Cabecera.SubTotal,
                oDocumentoDTO.Cabecera.IGV,
                oDocumentoDTO.Cabecera.Total,
                oDocumentoDTO.Cabecera.FechaHora,
                oDocumentoDTO.Cabecera.TipoDocumento
            });

            foreach(ItemBE item in oDocumentoDTO.Detalle){
                details.Rows.Add(new object[]{
                    oDocumentoDTO.Cabecera.CodDocumento,
                    item.Producto.CodProducto,
                    item.Precio,
                    Convert.ToInt32(item.Cantidad),
                    item.Total,
                });
            }

            var ConnectionString = @"Data Source=. ; Initial Catalog= Northwind;Integrated Security=SSPI";
            using (var conn = new SqlConnection(ConnectionString)) {
                conn.Open();
                using (var cmd = new SqlCommand("InsertaDocumento", conn)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    var headersParam = cmd.Parameters.AddWithValue("@cabecera_TVP", headers);
                    var detailsParam = cmd.Parameters.AddWithValue("@detalle_TVP", details);

                    headersParam.SqlDbType = SqlDbType.Structured;
                    detailsParam.SqlDbType = SqlDbType.Structured;
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
            return eEstadoProceso.Correcto;
        }
    }
}
