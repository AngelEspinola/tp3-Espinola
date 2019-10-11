using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using AccesoDatos;
using Dominio;

namespace Negocio
{
    public class VoucherNegocio
    {
        public List<Voucher> listar()
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            List<Voucher> listado = new List<Voucher>();
            Voucher voucher;
            //PoderSecundarioNegocio poderSecundarioNegocio = new PoderSecundarioNegocio();
            try
            {
                conexion.ConnectionString = AccesoDatosManager.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                //MSF-20190420: agregué todos los datos del heroe. Incluso su universo, que lo traigo con join.
                comando.CommandText = "SELECT [Id] ,[CodigoVoucher] ,[Estado],[IdCliente] ,[IdProducto] ,[FechaRegistro]  FROM[TP_WEB].[dbo].[Vouchers]";
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    voucher = new Voucher();
                    voucher.ID = Convert.ToInt32(lector["Id"]);

                    //MSF-20190420: acá manejamos un posible nulo desde la DB. Recuerdan que la otra vez nos falló?
                    //Era porque en la DB estaba nulo y acá lo queríamos tomar y no le gustaba.
                    //Ojo... en la tabla no todas las columnas van a ser nuleables... en nuestro caso porque no le dimos
                    //importancia casi al diseño de la misma. Pero si está bien armada la tabla, serán pocas las columnas
                    //que sean nulleables. Solo a esa deberían agregarles ésta validación. Que de hecho pueden meter en un método
                    //para no tener que escribirla completa cada vez, por ejemplo.
                    if (!Convert.IsDBNull(lector["CodigoVoucher"]))
                        voucher.Codigo = lector["CodigoVoucher"].ToString();

                    voucher.Estado = Convert.ToBoolean(lector["Estado"]);

                    if (!Convert.IsDBNull(lector["IdCliente"]))
                        voucher.IDCliente = Convert.ToInt32(lector["IdCliente"]);

                    if (!Convert.IsDBNull(lector["IdProducto"]))
                        voucher.IDProducto = Convert.ToInt32(lector["IdProducto"]);

                    if (!Convert.IsDBNull(lector["FechaRegistro"]))
                        voucher.FechaRegistro = Convert.ToDateTime(lector["FechaRegistro"]);

                    listado.Add(voucher);
                }

                return listado;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }

        public void modificar(string voucher, int idCliente, int idProducto)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            List<Voucher> listado = new List<Voucher>();
            //PoderSecundarioNegocio poderSecundarioNegocio = new PoderSecundarioNegocio();
            try
            {
                conexion.ConnectionString = AccesoDatosManager.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                //MSF-20190420: agregué todos los datos del heroe. Incluso su universo, que lo traigo con join.
                comando.CommandText = "UPDATE[TP_WEB].[dbo].[Vouchers] SET Estado=1, IdCliente = @idCliente, IdProducto = @idProducto WHERE[TP_WEB].[dbo].[Vouchers].CodigoVoucher = @Voucher";
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@idCliente", idCliente);
                comando.Parameters.AddWithValue("@idProducto", idProducto);
                comando.Parameters.AddWithValue("@Voucher", voucher);
                comando.Connection = conexion;
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                conexion.Close();
            }
        }
    }
}
