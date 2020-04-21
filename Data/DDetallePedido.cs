using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Data
{
    public class DDetallePedido
    {
        public List<DetallePedido> GetDetallePedidos (DetallePedido detalle)
        {
            SqlParameter[] parameters = null;
            string commandText = string.Empty;
            List<DetallePedido> detalles = null;

            try
            {
  
                parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@IdPedido", SqlDbType.Int);
                parameters[0].Value = detalle.Pedido.IdPedido;
             

                detalles = new List<DetallePedido>();

                using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.Connection, "USP_ListarDetalle",
                    CommandType.StoredProcedure, parameters))
                {
                    while (reader.Read())
                    {
                        detalles.Add(new DetallePedido
                        {
                            IdProducto = reader["IdProducto"] != null ? Convert.ToInt32(reader["IdProducto"]) : 0,
                            Cantidad = reader["Cantidad"] != null ? Convert.ToInt32(reader["Cantidad"]) :0,
                            PrecioUnidad = reader["PrecioUnidad"] != null ? Convert.ToDecimal(reader["PrecioUnidad"]) : 0,
                            Descuento = reader["Descuento"] != null ? Convert.ToDecimal(reader["Descuento"]) : 0             
                        });
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return detalles;

        }
    }
}
