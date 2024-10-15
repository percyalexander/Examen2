using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Repositorio
{
    public class MovimientoRepository : IMovimientoRepository
    {
        private readonly string _cadenaconexion;
        public MovimientoRepository()
        {
            _cadenaconexion = ConfigurationManager.ConnectionStrings["conexionbd"].ToString();

        }

        public async Task<IEnumerable<Movimiento>> ListarMovimiento(Movimiento mov)
        {
            try
            {
                var movimientos = new List<Movimiento>();

                using(var conexion = new SqlConnection(_cadenaconexion))
                {
                    var cmd = new SqlCommand("spListarMovimiento", conexion);;

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@COD_CIA", mov.COD_CIA == null ? "" : mov.COD_CIA);
                    cmd.Parameters.AddWithValue("@NRO_DOCUMENTO", mov.NRO_DOCUMENTO == null ? "" : mov.NRO_DOCUMENTO);

                    await conexion.OpenAsync();

                    using(var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var movimiento = MapaMovimiento(reader);

                            if(movimiento!= null)
                            {
                                movimientos.Add(movimiento);
                            }
                        }
                    }
                }
                return movimientos;
            }
            catch (SqlException sqlex)
            {
                throw new Exception("Se creo un excepcion sql" + sqlex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Se creo un excepcion" + ex.Message);
            }
        }

        public async Task<Movimiento> ObtenerxCodigo(string codigo)
        {
            try
            {
                Movimiento movimiento = null;

                using (var conexion = new SqlConnection(_cadenaconexion))
                {
                    var cmd = new SqlCommand("spMovimientoxId", conexion); ;

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NRO_DOCUMENTO", codigo);
                    
                    await conexion.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            movimiento = MapaMovimiento(reader);
                        }
                    }
                }
                return movimiento;
            }
            catch (SqlException sqlex)
            {
                throw new Exception("Se creo un excepcion sql" + sqlex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Se creo un excepcion" + ex.Message);
            }
        }
        public async Task Actualizar(Movimiento mov)
        {
            try
            {
                using (var conexion = new SqlConnection(_cadenaconexion))
                {
                    var cmd = new SqlCommand("spActualizarMovimiento", conexion); ;

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@COD_CIA", mov.COD_CIA == null ? "" : mov.COD_CIA);
                    cmd.Parameters.AddWithValue("@COMPANIA_VENTA_3", mov.COMPANIA_VENTA_3 == null ? "" : mov.COMPANIA_VENTA_3);
                    cmd.Parameters.AddWithValue("@ALMACEN_VENTA", mov.ALMACEN_VENTA == null ? "" : mov.ALMACEN_VENTA);
                    cmd.Parameters.AddWithValue("@TIPO_MOVIMIENTO", mov.TIPO_MOVIMIENTO == null ? "" : mov.TIPO_MOVIMIENTO);
                    cmd.Parameters.AddWithValue("@TIPO_DOCUMENTO", mov.TIPO_DOCUMENTO == null ? "" : mov.TIPO_DOCUMENTO);
                    cmd.Parameters.AddWithValue("@NRO_DOCUMENTO", mov.NRO_DOCUMENTO == null ? "" : mov.NRO_DOCUMENTO);
                    cmd.Parameters.AddWithValue("@COD_ITEM_2", mov.COD_ITEM_2 == null ? "" : mov.COD_ITEM_2);


                    await conexion.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                };
            }
            catch (SqlException sqlex)
            {
                throw new Exception("Error en la inserccion en la base de datos : " + sqlex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error general al insertar  :" + ex.Message);
            }
        }

        public async Task Crear(Movimiento mov)
        {
            try
            {
                using (var conexion = new SqlConnection(_cadenaconexion))
                {
                    var cmd = new SqlCommand("spInsertarMovimiento", conexion); ;

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@COD_CIA", mov.COD_CIA == null ? "" : mov.COD_CIA);
                    cmd.Parameters.AddWithValue("@COMPANIA_VENTA_3", mov.COMPANIA_VENTA_3 == null ? "" : mov.COMPANIA_VENTA_3);
                    cmd.Parameters.AddWithValue("@ALMACEN_VENTA", mov.ALMACEN_VENTA == null ? "" : mov.ALMACEN_VENTA);
                    cmd.Parameters.AddWithValue("@TIPO_MOVIMIENTO", mov.TIPO_MOVIMIENTO == null ? "" : mov.TIPO_MOVIMIENTO);
                    cmd.Parameters.AddWithValue("@TIPO_DOCUMENTO", mov.TIPO_DOCUMENTO == null ? "" : mov.TIPO_DOCUMENTO);
                    cmd.Parameters.AddWithValue("@NRO_DOCUMENTO", mov.NRO_DOCUMENTO == null ? "" : mov.NRO_DOCUMENTO);
                    cmd.Parameters.AddWithValue("@COD_ITEM_2", mov.COD_ITEM_2 == null ? "" : mov.COD_ITEM_2);
                

                    await conexion.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                };
            }
            catch (SqlException sqlex)
            {
                throw new Exception("Error en la inserccion en la base de datos : " + sqlex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error general al insertar  :" + ex.Message);
            }
        }

        public async Task Eliminar(string codigo)
        {
            try
            {
                using (var conexion = new SqlConnection(_cadenaconexion))
                {
                    var cmd = new SqlCommand("spEliminarMovimiento", conexion); ;

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;                   
                    cmd.Parameters.AddWithValue("@NRO_DOCUMENTO", codigo == null ? "" : codigo);
                   
                    await conexion.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                };
            }
            catch (SqlException sqlex)
            {
                throw new Exception("Error en la inserccion en la base de datos : " + sqlex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error general al insertar  :" + ex.Message);
            }
        }

        private Movimiento MapaMovimiento(IDataRecord record)
        {
            return new Movimiento
            {
                COD_CIA = (string)record["COD_CIA"],
                TIPO_MOVIMIENTO = (string)record["TIPO_MOVIMIENTO"],
                NRO_DOCUMENTO =(string)record["NRO_DOCUMENTO"]
            };
        }
    }
}
