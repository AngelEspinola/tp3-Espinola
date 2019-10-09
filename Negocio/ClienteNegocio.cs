﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Negocio;
using Dominio;
using AccesoDatos;

namespace Negocio
{
    public class ClienteNegocio
    {
        public List<Cliente> listar()
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            List<Cliente> listado = new List<Cliente>();
            Cliente cliente;
            //PoderSecundarioNegocio poderSecundarioNegocio = new PoderSecundarioNegocio();
            try
            {
                conexion.ConnectionString = AccesoDatosManager.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                //MSF-20190420: agregué todos los datos del heroe. Incluso su universo, que lo traigo con join.
                comando.CommandText = "SELECT [Id],[DNI],[Nombre],[Apellido],[Email],[Direccion],[Ciudad],[CodigoPostal],[FechaRegistro] FROM[TP_WEB].[dbo].[Clientes]";
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    cliente = new Cliente();

                    if (!Convert.IsDBNull(lector["DNI"]))
                        cliente.DNI = lector["DNI"].ToString();

                    if (!Convert.IsDBNull(lector["Nombre"]))
                        cliente.Nombre = lector["Nombre"].ToString();

                    if (!Convert.IsDBNull(lector["Apellido"]))
                        cliente.Apellido = lector["Apellido"].ToString();

                    if (!Convert.IsDBNull(lector["Email"]))
                        cliente.Email = lector["Email"].ToString();

                    if (!Convert.IsDBNull(lector["Direccion"]))
                        cliente.Direccion = lector["Direccion"].ToString();

                    if (!Convert.IsDBNull(lector["Ciudad"]))
                        cliente.Ciudad = lector["Ciudad"].ToString();

                    if (!Convert.IsDBNull(lector["CodigoPostal"]))
                        cliente.CodigoPostal = lector["CodigoPostal"].ToString();

                    if (!Convert.IsDBNull(lector["FechaRegistro"]))
                        cliente.FechaRegistro = Convert.ToDateTime(lector["FechaRegistro"]);

                    listado.Add(cliente);
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
    }
}
