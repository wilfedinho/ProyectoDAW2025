using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL.Negocio
{
    public class FacturaDAL
    {
        public void Alta(Factura FacturaAlta)
        {
            using (SqlConnection cone = GestorConexion.DevolverConexion())
            {
                cone.Open();

                string query = "INSERT INTO Factura (NumeroFactura, Nombre, Apellido, DNI, FechaEmision, HoraEmision, NumeroBoleto, Subtotal, Total, BeneficioAplicado, CambiosRealizados) VALUES (@NumeroFactura, @Nombre, @Apellido, @DNI, @Fecha, @Hora, @NumeroBoleto, @Subtotal, @Total, @Beneficio, @CambiosRealizados)";

                using (SqlCommand comando = new SqlCommand(query, cone))
                {
                    comando.Parameters.AddWithValue("@NumeroFactura", FacturaAlta.NumeroFactura);
                    comando.Parameters.AddWithValue("@Nombre", FacturaAlta.Nombre);
                    comando.Parameters.AddWithValue("@Apellido", FacturaAlta.Apellido);
                    comando.Parameters.AddWithValue("@DNI", FacturaAlta.DNI);
                    comando.Parameters.AddWithValue("@Fecha", FacturaAlta.FechaEmision);
                    comando.Parameters.AddWithValue("@Hora", FacturaAlta.HoraEmision);
                    comando.Parameters.AddWithValue("@NumeroBoleto", FacturaAlta.NumeroBoleto.ToString());
                    comando.Parameters.AddWithValue("@Subtotal", FacturaAlta.Subtotal);
                    comando.Parameters.AddWithValue("@Total", FacturaAlta.Total);

                    if (string.IsNullOrWhiteSpace(FacturaAlta.BeneficioAplicado))
                        comando.Parameters.AddWithValue("@Beneficio", DBNull.Value);
                    else
                        comando.Parameters.AddWithValue("@Beneficio", FacturaAlta.BeneficioAplicado);
                    if (string.IsNullOrEmpty(FacturaAlta.CambiosRealizados))
                        comando.Parameters.AddWithValue("@CambiosRealizados", DBNull.Value);
                    else
                        comando.Parameters.AddWithValue("@CambiosRealizados", FacturaAlta.CambiosRealizados);

                    comando.ExecuteNonQuery();
                }
            }
        }

        public List<Factura> ObtenerTodasLasFacturas()
        {
            List<Factura> facturas = new List<Factura>();

            using (SqlConnection cone = GestorConexion.DevolverConexion())
            {
                cone.Open();
                string query = "SELECT * FROM Factura";

                using (SqlCommand comando = new SqlCommand(query, cone))
                {
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string beneficioAplicado = null;
                            if (reader["BeneficioAplicado"] != DBNull.Value)
                            {
                                beneficioAplicado = reader["BeneficioAplicado"].ToString();
                            }

                            Factura factura = new Factura(
                                numeroFactura: Convert.ToInt32(reader["NumeroFactura"]),
                                nombreCliente: reader["Nombre"].ToString(),
                                apellidoCliente: reader["Apellido"].ToString(),
                                dniCliente: reader["DNI"].ToString(),
                                fechaEmision: reader["FechaEmision"].ToString(),
                                horaEmision: reader["HoraEmision"].ToString(),
                                numeroBoleto: reader["NumeroBoleto"].ToString(),
                                subtotal: Convert.ToSingle(reader["Subtotal"]),
                                total: Convert.ToSingle(reader["Total"]),
                                beneficioAplicado: beneficioAplicado
                            );
                            factura.CambiosRealizados = reader["CambiosRealizados"].ToString();
                            facturas.Add(factura);
                        }
                    }
                }
            }

            return facturas;
        }



    }
}
