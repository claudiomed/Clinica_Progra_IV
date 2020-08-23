using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AD
    {
        #region Atributos
        private string cadenaconexion = Properties.Settings.Default.Conexion;
        private SqlConnection objconexion;
        #endregion

        #region Constructor
        public AD()
        {
            try
            {
                objconexion = new SqlConnection(cadenaconexion);
                this.ABRIR();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.CERRAR();
            }
        }
        #endregion

        #region MÉTODOS



        #region PRIVADOS

        private void ABRIR()
        {
            if (objconexion.State == System.Data.ConnectionState.Closed)
                objconexion.Open();
        }

        private void CERRAR()
        {
            if (objconexion.State == System.Data.ConnectionState.Open)
                objconexion.Close();
        }
        #endregion


        #region Publicos
       
        public bool EjecutarSentencias(SQLSentencias P_Peticion)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();

                //ASigna los valores del QUERY a ejecutar en SQL
                cmd.Connection = objconexion; //ASigna conexion
                cmd.CommandType = System.Data.CommandType.StoredProcedure; //ASigna el tipo
                cmd.CommandText = P_Peticion.Peticion; //ASigna peticion recibida

                if (P_Peticion.lstParametros.Count > 0) //Consulta si tiene parametros
                    cmd.Parameters.AddRange(P_Peticion.lstParametros.ToArray()); //Los asigna

                //Ejecutar la sentencia
                this.ABRIR();
                cmd.ExecuteNonQuery(); //Ejecuta en BD la peticion configurada               
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.CERRAR();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="P_Peticion"></param>
        /// <param name="listaComandos"></param>
        /// <returns></returns>
        public bool agregarSentenciaTransaccion(SQLSentencias P_Peticion, ref List<SqlCommand> listaComandos)
        {

            try
            {
                SqlCommand cmd = new SqlCommand();

                //ASigna los valores del QUERY a ejecutar en SQL
                cmd.Connection = objconexion; //ASigna conexion
                cmd.CommandType = System.Data.CommandType.Text; //ASigna el tipo
                cmd.CommandText = P_Peticion.Peticion; //ASigna peticion recibida

                if (P_Peticion.lstParametros.Count > 0) //Consulta si tiene parametros
                    cmd.Parameters.AddRange(P_Peticion.lstParametros.ToArray()); //Los asigna

                //Ejecutar la sentencia
                listaComandos.Add(cmd);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.CERRAR();
            }
            //return true;
        }

        public bool ejecutarTransaccion(List<SqlCommand> listaComandos)
        {
            this.ABRIR();
            SqlTransaction transaccion = objconexion.BeginTransaction();
            //this.ABRIR();
            //transaccion = objconexion.BeginTransaction();

            try
            {
                foreach (SqlCommand cmd in listaComandos)
                {
                    cmd.Transaction = transaccion;
                    cmd.ExecuteNonQuery();
                }

                transaccion.Commit();
            }
            catch (Exception e)
            {
                transaccion.Rollback();
                throw e;
            }
            finally
            {
                this.CERRAR();
            }
            return true;
        }


        #region Métodos de consulta

        public List<Usuarios_TB> Consultar_Usuarios(SQLSentencias P_Peticion)
        {
            List<Usuarios_TB> Lst_Resultados = new List<Usuarios_TB>(); //Esta es la variable local que retornara valores
            DataTable dt = new DataTable(); //Variable contenedora del resultado en BD - Temporal

            try
            {
                SqlCommand cmd = new SqlCommand(); //Instancia de SQL Command, que permite configurar comando a ejecutar en BD

                //ASigna los valores del QUERY a ejecutar en SQL
                cmd.Connection = objconexion; //ASigna conexion
                cmd.CommandType = System.Data.CommandType.Text; //ASigna el tipo
                cmd.CommandText = P_Peticion.Peticion; //ASigna peticion recibida

                if (P_Peticion.lstParametros.Count > 0) //Consulta si tiene parametros
                    cmd.Parameters.AddRange(P_Peticion.lstParametros.ToArray()); //Los asigna

                SqlDataAdapter objCaptura = new SqlDataAdapter(cmd); //Aqui se crea instancia para reliazar consultas en BD
                objCaptura.Fill(dt); //Aqui se ejecuta la consulta en BD y se almacena en memoria la respuesta

                if (dt.Rows.Count > 0) //Valida si la consulta devolvio resultados
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        Usuarios_TB u = new Usuarios_TB(); //Instancia temporal

                        u.Usuario_ID = item.ItemArray[0].ToString();
                        u.Password = item.ItemArray[1].ToString();
                        u.Tipo_Perfil = Int16.Parse(item.ItemArray[2].ToString());
                        u.Nombre = item.ItemArray[3].ToString();
                        u.Apellidos = item.ItemArray[4].ToString();
                        u.Fecha_Nacimiento = DateTime.Parse(item.ItemArray[5].ToString());
                        u.Email = item.ItemArray[6].ToString();
                        u.Telefono = item.ItemArray[7].ToString();

                        Lst_Resultados.Add(u);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.CERRAR();
            }

            return Lst_Resultados;
        }

        public List<Empleados_TB> Consultar_Empleados(SQLSentencias P_Peticion)
        {
            List<Empleados_TB> Lst_Resultados = new List<Empleados_TB>(); //Esta es la variable local que retornara valores
            DataTable dt = new DataTable(); //Variable contenedora del resultado en BD - Temporal

            try
            {
                SqlCommand cmd = new SqlCommand(); //Instancia de SQL Command, que permite configurar comando a ejecutar en BD

                //ASigna los valores del QUERY a ejecutar en SQL
                cmd.Connection = objconexion; //ASigna conexion
                cmd.CommandType = System.Data.CommandType.Text; //ASigna el tipo
                cmd.CommandText = P_Peticion.Peticion; //ASigna peticion recibida

                if (P_Peticion.lstParametros.Count > 0) //Consulta si tiene parametros
                    cmd.Parameters.AddRange(P_Peticion.lstParametros.ToArray()); //Los asigna

                SqlDataAdapter objCaptura = new SqlDataAdapter(cmd); //Aqui se crea instancia para reliazar consultas en BD
                objCaptura.Fill(dt); //Aqui se ejecuta la consulta en BD y se almacena en memoria la respuesta

                if (dt.Rows.Count > 0) //Valida si la consulta devolvio resultados
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        Empleados_TB u = new Empleados_TB(); //Instancia temporal

                        u.Empleado_ID = int.Parse(item.ItemArray[0].ToString());
                        u.Empleado_Usuario_ID = item.ItemArray[1].ToString();


                        Lst_Resultados.Add(u);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.CERRAR();
            }

            return Lst_Resultados;
        }

        public List<Medicos_TB> Consultar_Medicos(SQLSentencias P_Peticion)
        {
            List<Medicos_TB> Lst_Resultados = new List<Medicos_TB>(); //Esta es la variable local que retornara valores
            DataTable dt = new DataTable(); //Variable contenedora del resultado en BD - Temporal

            try
            {
                SqlCommand cmd = new SqlCommand(); //Instancia de SQL Command, que permite configurar comando a ejecutar en BD

                //ASigna los valores del QUERY a ejecutar en SQL
                cmd.Connection = objconexion; //ASigna conexion
                cmd.CommandType = System.Data.CommandType.Text; //ASigna el tipo
                cmd.CommandText = P_Peticion.Peticion; //ASigna peticion recibida

                if (P_Peticion.lstParametros.Count > 0) //Consulta si tiene parametros
                    cmd.Parameters.AddRange(P_Peticion.lstParametros.ToArray()); //Los asigna

                SqlDataAdapter objCaptura = new SqlDataAdapter(cmd); //Aqui se crea instancia para reliazar consultas en BD
                objCaptura.Fill(dt); //Aqui se ejecuta la consulta en BD y se almacena en memoria la respuesta

                if (dt.Rows.Count > 0) //Valida si la consulta devolvio resultados
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        Medicos_TB u = new Medicos_TB(); //Instancia temporal

                        u.Numero_Carne = int.Parse(item.ItemArray[0].ToString());
                        u.Doctor_Empleado_ID = int.Parse(item.ItemArray[1].ToString());


                        Lst_Resultados.Add(u);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.CERRAR();
            }

            return Lst_Resultados;
        }

        public List<Especialidades_TB> Consultar_Especialidades(SQLSentencias P_Peticion)
        {
            List<Especialidades_TB> Lst_Resultados = new List<Especialidades_TB>(); //Esta es la variable local que retornara valores
            DataTable dt = new DataTable(); //Variable contenedora del resultado en BD - Temporal

            try
            {
                SqlCommand cmd = new SqlCommand(); //Instancia de SQL Command, que permite configurar comando a ejecutar en BD

                //ASigna los valores del QUERY a ejecutar en SQL
                cmd.Connection = objconexion; //ASigna conexion
                cmd.CommandType = System.Data.CommandType.Text; //ASigna el tipo
                cmd.CommandText = P_Peticion.Peticion; //ASigna peticion recibida

                if (P_Peticion.lstParametros.Count > 0) //Consulta si tiene parametros
                    cmd.Parameters.AddRange(P_Peticion.lstParametros.ToArray()); //Los asigna

                SqlDataAdapter objCaptura = new SqlDataAdapter(cmd); //Aqui se crea instancia para reliazar consultas en BD
                objCaptura.Fill(dt); //Aqui se ejecuta la consulta en BD y se almacena en memoria la respuesta

                if (dt.Rows.Count > 0) //Valida si la consulta devolvio resultados
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        Especialidades_TB u = new Especialidades_TB(); //Instancia temporal

                        u.Especialidad_ID = Int16.Parse(item.ItemArray[0].ToString());
                        u.Nombre = item.ItemArray[1].ToString();


                        Lst_Resultados.Add(u);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.CERRAR();
            }

            return Lst_Resultados;
        }

        public List<Medicos_Especialidades_TB> Consultar_Medicos_Especialidades(SQLSentencias P_Peticion)
        {
            List<Medicos_Especialidades_TB> Lst_Resultados = new List<Medicos_Especialidades_TB>(); //Esta es la variable local que retornara valores
            DataTable dt = new DataTable(); //Variable contenedora del resultado en BD - Temporal

            try
            {
                SqlCommand cmd = new SqlCommand(); //Instancia de SQL Command, que permite configurar comando a ejecutar en BD

                //ASigna los valores del QUERY a ejecutar en SQL
                cmd.Connection = objconexion; //ASigna conexion
                cmd.CommandType = System.Data.CommandType.Text; //ASigna el tipo
                cmd.CommandText = P_Peticion.Peticion; //ASigna peticion recibida

                if (P_Peticion.lstParametros.Count > 0) //Consulta si tiene parametros
                    cmd.Parameters.AddRange(P_Peticion.lstParametros.ToArray()); //Los asigna

                SqlDataAdapter objCaptura = new SqlDataAdapter(cmd); //Aqui se crea instancia para reliazar consultas en BD
                objCaptura.Fill(dt); //Aqui se ejecuta la consulta en BD y se almacena en memoria la respuesta

                if (dt.Rows.Count > 0) //Valida si la consulta devolvio resultados
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        Medicos_Especialidades_TB u = new Medicos_Especialidades_TB(); //Instancia temporal

                        u.MED_ID = Int16.Parse(item.ItemArray[0].ToString());
                        u.ME_Medico_ID = int.Parse(item.ItemArray[1].ToString());
                        u.ME_Especialidad_ID = Int16.Parse(item.ItemArray[2].ToString());


                        Lst_Resultados.Add(u);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.CERRAR();
            }

            return Lst_Resultados;
        }

        public List<Procedimientos_TB> Consultar_Procedimientos(SQLSentencias P_Peticion)
        {
            List<Procedimientos_TB> Lst_Resultados = new List<Procedimientos_TB>(); //Esta es la variable local que retornara valores
            DataTable dt = new DataTable(); //Variable contenedora del resultado en BD - Temporal

            try
            {
                SqlCommand cmd = new SqlCommand(); //Instancia de SQL Command, que permite configurar comando a ejecutar en BD

                //ASigna los valores del QUERY a ejecutar en SQL
                cmd.Connection = objconexion; //ASigna conexion
                cmd.CommandType = System.Data.CommandType.Text; //ASigna el tipo
                cmd.CommandText = P_Peticion.Peticion; //ASigna peticion recibida

                if (P_Peticion.lstParametros.Count > 0) //Consulta si tiene parametros
                    cmd.Parameters.AddRange(P_Peticion.lstParametros.ToArray()); //Los asigna

                SqlDataAdapter objCaptura = new SqlDataAdapter(cmd); //Aqui se crea instancia para reliazar consultas en BD
                objCaptura.Fill(dt); //Aqui se ejecuta la consulta en BD y se almacena en memoria la respuesta

                if (dt.Rows.Count > 0) //Valida si la consulta devolvio resultados
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        Procedimientos_TB u = new Procedimientos_TB(); //Instancia temporal

                        u.Procedimiento_ID = Int16.Parse(item.ItemArray[0].ToString());
                        u.Procedimiento_Especialidad_ID = Int16.Parse(item.ItemArray[1].ToString());
                        u.Descripcion = item.ItemArray[2].ToString();
                        u.Costo = Decimal.Parse(item.ItemArray[3].ToString());


                        Lst_Resultados.Add(u);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.CERRAR();
            }

            return Lst_Resultados;
        }

        public List<Padecimientos_TB> Consultar_Padecimientos(SQLSentencias P_Peticion)
        {
            List<Padecimientos_TB> Lst_Resultados = new List<Padecimientos_TB>(); //Esta es la variable local que retornara valores
            DataTable dt = new DataTable(); //Variable contenedora del resultado en BD - Temporal

            try
            {
                SqlCommand cmd = new SqlCommand(); //Instancia de SQL Command, que permite configurar comando a ejecutar en BD

                //ASigna los valores del QUERY a ejecutar en SQL
                cmd.Connection = objconexion; //ASigna conexion
                cmd.CommandType = System.Data.CommandType.Text; //ASigna el tipo
                cmd.CommandText = P_Peticion.Peticion; //ASigna peticion recibida

                if (P_Peticion.lstParametros.Count > 0) //Consulta si tiene parametros
                    cmd.Parameters.AddRange(P_Peticion.lstParametros.ToArray()); //Los asigna

                SqlDataAdapter objCaptura = new SqlDataAdapter(cmd); //Aqui se crea instancia para reliazar consultas en BD
                objCaptura.Fill(dt); //Aqui se ejecuta la consulta en BD y se almacena en memoria la respuesta

                if (dt.Rows.Count > 0) //Valida si la consulta devolvio resultados
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        Padecimientos_TB u = new Padecimientos_TB(); //Instancia temporal

                        u.Padecimiento_ID = Int16.Parse(item.ItemArray[0].ToString());
                        u.Nombre = item.ItemArray[1].ToString();


                        Lst_Resultados.Add(u);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.CERRAR();
            }

            return Lst_Resultados;
        }

        public List<Clientes_TB> Consultar_Clientes(SQLSentencias P_Peticion)
        {
            List<Clientes_TB> Lst_Resultados = new List<Clientes_TB>(); //Esta es la variable local que retornara valores
            DataTable dt = new DataTable(); //Variable contenedora del resultado en BD - Temporal

            try
            {
                SqlCommand cmd = new SqlCommand(); //Instancia de SQL Command, que permite configurar comando a ejecutar en BD

                //ASigna los valores del QUERY a ejecutar en SQL
                cmd.Connection = objconexion; //ASigna conexion
                cmd.CommandType = System.Data.CommandType.Text; //ASigna el tipo
                cmd.CommandText = P_Peticion.Peticion; //ASigna peticion recibida

                if (P_Peticion.lstParametros.Count > 0) //Consulta si tiene parametros
                    cmd.Parameters.AddRange(P_Peticion.lstParametros.ToArray()); //Los asigna

                SqlDataAdapter objCaptura = new SqlDataAdapter(cmd); //Aqui se crea instancia para reliazar consultas en BD
                objCaptura.Fill(dt); //Aqui se ejecuta la consulta en BD y se almacena en memoria la respuesta

                if (dt.Rows.Count > 0) //Valida si la consulta devolvio resultados
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        Clientes_TB u = new Clientes_TB(); //Instancia temporal

                        u.Cliente_ID = int.Parse(item.ItemArray[0].ToString());
                        u.Cliente_Usuario_ID = item.ItemArray[1].ToString();


                        Lst_Resultados.Add(u);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.CERRAR();
            }

            return Lst_Resultados;
        }

        public List<Clientes_Padecimientos_TB> Consultar_Clientes_Padecimientos(SQLSentencias P_Peticion)
        {
            List<Clientes_Padecimientos_TB> Lst_Resultados = new List<Clientes_Padecimientos_TB>(); //Esta es la variable local que retornara valores
            DataTable dt = new DataTable(); //Variable contenedora del resultado en BD - Temporal

            try
            {
                SqlCommand cmd = new SqlCommand(); //Instancia de SQL Command, que permite configurar comando a ejecutar en BD

                //ASigna los valores del QUERY a ejecutar en SQL
                cmd.Connection = objconexion; //ASigna conexion
                cmd.CommandType = System.Data.CommandType.Text; //ASigna el tipo
                cmd.CommandText = P_Peticion.Peticion; //ASigna peticion recibida

                if (P_Peticion.lstParametros.Count > 0) //Consulta si tiene parametros
                    cmd.Parameters.AddRange(P_Peticion.lstParametros.ToArray()); //Los asigna

                SqlDataAdapter objCaptura = new SqlDataAdapter(cmd); //Aqui se crea instancia para reliazar consultas en BD
                objCaptura.Fill(dt); //Aqui se ejecuta la consulta en BD y se almacena en memoria la respuesta

                if (dt.Rows.Count > 0) //Valida si la consulta devolvio resultados
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        Clientes_Padecimientos_TB u = new Clientes_Padecimientos_TB(); //Instancia temporal

                        u.CP_ID = int.Parse(item.ItemArray[0].ToString());
                        u.CP_Cliente_ID = int.Parse(item.ItemArray[1].ToString());
                        u.CP_Padecimiento_ID = int.Parse(item.ItemArray[2].ToString());
                        u.CP_Comentarios = item.ItemArray[3].ToString();


                        Lst_Resultados.Add(u);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.CERRAR();
            }

            return Lst_Resultados;
        }

        public List<Consultorio_TB> Consultar_Consultorios(SQLSentencias P_Peticion)
        {
            List<Consultorio_TB> Lst_Resultados = new List<Consultorio_TB>(); //Esta es la variable local que retornara valores
            DataTable dt = new DataTable(); //Variable contenedora del resultado en BD - Temporal

            try
            {
                SqlCommand cmd = new SqlCommand(); //Instancia de SQL Command, que permite configurar comando a ejecutar en BD

                //ASigna los valores del QUERY a ejecutar en SQL
                cmd.Connection = objconexion; //ASigna conexion
                cmd.CommandType = System.Data.CommandType.Text; //ASigna el tipo
                cmd.CommandText = P_Peticion.Peticion; //ASigna peticion recibida

                if (P_Peticion.lstParametros.Count > 0) //Consulta si tiene parametros
                    cmd.Parameters.AddRange(P_Peticion.lstParametros.ToArray()); //Los asigna

                SqlDataAdapter objCaptura = new SqlDataAdapter(cmd); //Aqui se crea instancia para reliazar consultas en BD
                objCaptura.Fill(dt); //Aqui se ejecuta la consulta en BD y se almacena en memoria la respuesta

                if (dt.Rows.Count > 0) //Valida si la consulta devolvio resultados
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        Consultorio_TB u = new Consultorio_TB(); //Instancia temporal

                        u.Consultorio_ID = Int16.Parse(item.ItemArray[0].ToString());
                        u.Nombre = item.ItemArray[1].ToString();
                        u.Estado = item.ItemArray[2].ToString();


                        Lst_Resultados.Add(u);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.CERRAR();
            }

            return Lst_Resultados;
        }

        public List<Metodos_Pago_TB> Consultar_Metodos_Pago(SQLSentencias P_Peticion)
        {
            List<Metodos_Pago_TB> Lst_Resultados = new List<Metodos_Pago_TB>(); //Esta es la variable local que retornara valores
            DataTable dt = new DataTable(); //Variable contenedora del resultado en BD - Temporal

            try
            {
                SqlCommand cmd = new SqlCommand(); //Instancia de SQL Command, que permite configurar comando a ejecutar en BD

                //ASigna los valores del QUERY a ejecutar en SQL
                cmd.Connection = objconexion; //ASigna conexion
                cmd.CommandType = System.Data.CommandType.Text; //ASigna el tipo
                cmd.CommandText = P_Peticion.Peticion; //ASigna peticion recibida

                if (P_Peticion.lstParametros.Count > 0) //Consulta si tiene parametros
                    cmd.Parameters.AddRange(P_Peticion.lstParametros.ToArray()); //Los asigna

                SqlDataAdapter objCaptura = new SqlDataAdapter(cmd); //Aqui se crea instancia para reliazar consultas en BD
                objCaptura.Fill(dt); //Aqui se ejecuta la consulta en BD y se almacena en memoria la respuesta

                if (dt.Rows.Count > 0) //Valida si la consulta devolvio resultados
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        Metodos_Pago_TB u = new Metodos_Pago_TB(); //Instancia temporal

                        u.MP_ID = Int16.Parse(item.ItemArray[0].ToString());
                        u.Descripcion = item.ItemArray[1].ToString();


                        Lst_Resultados.Add(u);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.CERRAR();
            }

            return Lst_Resultados;
        }

        public List<Facturas_TB> Consultar_Facturas(SQLSentencias P_Peticion)
        {
            List<Facturas_TB> Lst_Resultados = new List<Facturas_TB>(); //Esta es la variable local que retornara valores
            DataTable dt = new DataTable(); //Variable contenedora del resultado en BD - Temporal

            try
            {
                SqlCommand cmd = new SqlCommand(); //Instancia de SQL Command, que permite configurar comando a ejecutar en BD

                //ASigna los valores del QUERY a ejecutar en SQL
                cmd.Connection = objconexion; //ASigna conexion
                cmd.CommandType = System.Data.CommandType.Text; //ASigna el tipo
                cmd.CommandText = P_Peticion.Peticion; //ASigna peticion recibida

                if (P_Peticion.lstParametros.Count > 0) //Consulta si tiene parametros
                    cmd.Parameters.AddRange(P_Peticion.lstParametros.ToArray()); //Los asigna

                SqlDataAdapter objCaptura = new SqlDataAdapter(cmd); //Aqui se crea instancia para reliazar consultas en BD
                objCaptura.Fill(dt); //Aqui se ejecuta la consulta en BD y se almacena en memoria la respuesta

                if (dt.Rows.Count > 0) //Valida si la consulta devolvio resultados
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        Facturas_TB u = new Facturas_TB(); //Instancia temporal

                        u.Factura_ID = Int16.Parse(item.ItemArray[0].ToString());
                        u.Fact_Metodo_Pago = item.ItemArray[1].ToString();


                        Lst_Resultados.Add(u);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.CERRAR();
            }

            return Lst_Resultados;
        }

        public List<Citas_TB> Consultar_Citas(SQLSentencias P_Peticion)
        {
            List<Citas_TB> Lst_Resultados = new List<Citas_TB>(); //Esta es la variable local que retornara valores
            DataTable dt = new DataTable(); //Variable contenedora del resultado en BD - Temporal

            try
            {
                SqlCommand cmd = new SqlCommand(); //Instancia de SQL Command, que permite configurar comando a ejecutar en BD

                //ASigna los valores del QUERY a ejecutar en SQL
                cmd.Connection = objconexion; //ASigna conexion
                cmd.CommandType = System.Data.CommandType.Text; //ASigna el tipo
                cmd.CommandText = P_Peticion.Peticion; //ASigna peticion recibida

                if (P_Peticion.lstParametros.Count > 0) //Consulta si tiene parametros
                    cmd.Parameters.AddRange(P_Peticion.lstParametros.ToArray()); //Los asigna

                SqlDataAdapter objCaptura = new SqlDataAdapter(cmd); //Aqui se crea instancia para reliazar consultas en BD
                objCaptura.Fill(dt); //Aqui se ejecuta la consulta en BD y se almacena en memoria la respuesta

                if (dt.Rows.Count > 0) //Valida si la consulta devolvio resultados
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        Citas_TB u = new Citas_TB(); //Instancia temporal

                        u.Cita_ID = Int16.Parse(item.ItemArray[0].ToString());
                        u.Cita_Cliente_ID = int.Parse(item.ItemArray[1].ToString());
                        u.Cita_Consultorio_ID = Int16.Parse(item.ItemArray[2].ToString());
                        u.Cita_ME_ID = Int16.Parse(item.ItemArray[3].ToString());
                        u.Cita_Fact_ID = Int16.Parse(item.ItemArray[4].ToString());
                        u.Fecha = DateTime.Parse(item.ItemArray[5].ToString());
                        u.Estado = item.ItemArray[6].ToString();


                        Lst_Resultados.Add(u);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.CERRAR();
            }

            return Lst_Resultados;
        }

        public List<Horarios_TB> Consultar_Horarios(SQLSentencias P_Peticion)
        {
            List<Horarios_TB> Lst_Resultados = new List<Horarios_TB>(); //Esta es la variable local que retornara valores
            DataTable dt = new DataTable(); //Variable contenedora del resultado en BD - Temporal

            try
            {
                SqlCommand cmd = new SqlCommand(); //Instancia de SQL Command, que permite configurar comando a ejecutar en BD

                //ASigna los valores del QUERY a ejecutar en SQL
                cmd.Connection = objconexion; //ASigna conexion
                cmd.CommandType = System.Data.CommandType.Text; //ASigna el tipo
                cmd.CommandText = P_Peticion.Peticion; //ASigna peticion recibida

                if (P_Peticion.lstParametros.Count > 0) //Consulta si tiene parametros
                    cmd.Parameters.AddRange(P_Peticion.lstParametros.ToArray()); //Los asigna

                SqlDataAdapter objCaptura = new SqlDataAdapter(cmd); //Aqui se crea instancia para reliazar consultas en BD
                objCaptura.Fill(dt); //Aqui se ejecuta la consulta en BD y se almacena en memoria la respuesta

                if (dt.Rows.Count > 0) //Valida si la consulta devolvio resultados
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        Horarios_TB u = new Horarios_TB(); //Instancia temporal

                        u.Horario_ID = Int16.Parse(item.ItemArray[0].ToString());
                        u.Dia = item.ItemArray[1].ToString();
                        u.Hora_Inicio = DateTime.Parse(item.ItemArray[2].ToString());
                        u.Hora_Fin = DateTime.Parse(item.ItemArray[3].ToString());
                        u.Disponible = item.ItemArray[4].ToString();


                        Lst_Resultados.Add(u);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.CERRAR();
            }

            return Lst_Resultados;
        }

        public List<Agenda_TB> Consultar_Agenda(SQLSentencias P_Peticion)
        {
            List<Agenda_TB> Lst_Resultados = new List<Agenda_TB>(); //Esta es la variable local que retornara valores
            DataTable dt = new DataTable(); //Variable contenedora del resultado en BD - Temporal

            try
            {
                SqlCommand cmd = new SqlCommand(); //Instancia de SQL Command, que permite configurar comando a ejecutar en BD

                //ASigna los valores del QUERY a ejecutar en SQL
                cmd.Connection = objconexion; //ASigna conexion
                cmd.CommandType = System.Data.CommandType.Text; //ASigna el tipo
                cmd.CommandText = P_Peticion.Peticion; //ASigna peticion recibida

                if (P_Peticion.lstParametros.Count > 0) //Consulta si tiene parametros
                    cmd.Parameters.AddRange(P_Peticion.lstParametros.ToArray()); //Los asigna

                SqlDataAdapter objCaptura = new SqlDataAdapter(cmd); //Aqui se crea instancia para reliazar consultas en BD
                objCaptura.Fill(dt); //Aqui se ejecuta la consulta en BD y se almacena en memoria la respuesta

                if (dt.Rows.Count > 0) //Valida si la consulta devolvio resultados
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        Agenda_TB u = new Agenda_TB(); //Instancia temporal

                        u.Agenda_ID = Int16.Parse(item.ItemArray[0].ToString());
                        u.Agenda_Cita_ID = int.Parse(item.ItemArray[1].ToString());
                        u.Agenda_Horario_ID = Int16.Parse(item.ItemArray[2].ToString());
                        u.Comentarios = item.ItemArray[3].ToString();


                        Lst_Resultados.Add(u);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.CERRAR();
            }

            return Lst_Resultados;
        }

        public List<Tarjetas_TB> Consultar_Tarjetas(SQLSentencias P_Peticion)
        {
            List<Tarjetas_TB> Lst_Resultados = new List<Tarjetas_TB>(); //Esta es la variable local que retornara valores
            DataTable dt = new DataTable(); //Variable contenedora del resultado en BD - Temporal

            try
            {
                SqlCommand cmd = new SqlCommand(); //Instancia de SQL Command, que permite configurar comando a ejecutar en BD

                //ASigna los valores del QUERY a ejecutar en SQL
                cmd.Connection = objconexion; //ASigna conexion
                cmd.CommandType = System.Data.CommandType.Text; //ASigna el tipo
                cmd.CommandText = P_Peticion.Peticion; //ASigna peticion recibida

                if (P_Peticion.lstParametros.Count > 0) //Consulta si tiene parametros
                    cmd.Parameters.AddRange(P_Peticion.lstParametros.ToArray()); //Los asigna

                SqlDataAdapter objCaptura = new SqlDataAdapter(cmd); //Aqui se crea instancia para reliazar consultas en BD
                objCaptura.Fill(dt); //Aqui se ejecuta la consulta en BD y se almacena en memoria la respuesta

                if (dt.Rows.Count > 0) //Valida si la consulta devolvio resultados
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        Tarjetas_TB u = new Tarjetas_TB(); //Instancia temporal

                        u.Numero_Tarjeta = int.Parse(item.ItemArray[0].ToString());
                        u.Tarjeta_Cliente_ID = int.Parse(item.ItemArray[1].ToString());
                        u.Fecha_Vencimiento = DateTime.Parse(item.ItemArray[2].ToString());
                        


                        Lst_Resultados.Add(u);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.CERRAR();
            }

            return Lst_Resultados;
        }



        #endregion






        #endregion





        #endregion
    }
}
