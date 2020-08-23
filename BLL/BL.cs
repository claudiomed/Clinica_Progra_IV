using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BL
    {
        #region Métodos CRUD


        public static bool CRUD_USUARIOS(Usuarios_TB usuario, string accion)
        {
            try
            {
                List<SqlCommand> lstSentencias = new List<SqlCommand>();//Lista de sentencias a ejecutar
                AD objAcceso = new AD();

                SQLSentencias sentencia = new SQLSentencias();
                //Se crea la peticion
                sentencia.Peticion = "EXEC CRUD_USUARIOS_SP @Usuario_ID, @Password, @Tipo_Perfil, @Nombre, @Apellidos, @Fecha_Nacimiento, @Email, @Telefono, @Accion";
                //Se agregan los parametros correspondientes
                SqlParameter Usuario_ID_P = new SqlParameter();
                Usuario_ID_P.Value = usuario.Usuario_ID;
                Usuario_ID_P.SqlDbType = System.Data.SqlDbType.Int;
                Usuario_ID_P.ParameterName = "@Usuario_ID";

                SqlParameter Password_P = new SqlParameter();
                Password_P.Value = usuario.Password;
                Password_P.SqlDbType = System.Data.SqlDbType.VarChar;
                Password_P.ParameterName = "@Password";

                SqlParameter Tipo_Perfil_P = new SqlParameter();
                Tipo_Perfil_P.Value = usuario.Tipo_Perfil;
                Tipo_Perfil_P.SqlDbType = System.Data.SqlDbType.SmallInt;
                Tipo_Perfil_P.ParameterName = "@Tipo_Perfil";

                SqlParameter Nombre_P = new SqlParameter();
                Nombre_P.Value = usuario.Nombre;
                Nombre_P.SqlDbType = System.Data.SqlDbType.VarChar;
                Nombre_P.ParameterName = "@Nombre";

                SqlParameter Apellidos_P = new SqlParameter();
                Apellidos_P.Value = usuario.Apellidos;
                Apellidos_P.SqlDbType = System.Data.SqlDbType.VarChar;
                Apellidos_P.ParameterName = "@Apellidos";

                SqlParameter Fecha_Nacimiento_P = new SqlParameter();
                Fecha_Nacimiento_P.Value = usuario.Fecha_Nacimiento;
                Fecha_Nacimiento_P.SqlDbType = System.Data.SqlDbType.Date;
                Fecha_Nacimiento_P.ParameterName = "@Fecha_Nacimiento";

                SqlParameter Email_P = new SqlParameter();
                Email_P.Value = usuario.Email;
                Email_P.SqlDbType = System.Data.SqlDbType.VarChar;
                Email_P.ParameterName = "@Email";

                SqlParameter Telefono_P = new SqlParameter();
                Telefono_P.Value = usuario.Telefono;
                Telefono_P.SqlDbType = System.Data.SqlDbType.VarChar;
                Telefono_P.ParameterName = "@Telefono";

                SqlParameter Accion_P = new SqlParameter();
                Accion_P.Value = accion;
                Accion_P.SqlDbType = System.Data.SqlDbType.Char;
                Accion_P.ParameterName = "@Accion";

                sentencia.lstParametros.Add(Usuario_ID_P);
                sentencia.lstParametros.Add(Password_P);
                sentencia.lstParametros.Add(Tipo_Perfil_P);
                sentencia.lstParametros.Add(Nombre_P);
                sentencia.lstParametros.Add(Apellidos_P);
                sentencia.lstParametros.Add(Fecha_Nacimiento_P);
                sentencia.lstParametros.Add(Email_P);
                sentencia.lstParametros.Add(Telefono_P);
                sentencia.lstParametros.Add(Accion_P);

                return objAcceso.EjecutarSentencias(sentencia);


            }
            catch (Exception e)
            {

                throw e;
            }


        }

        /// <summary>
        /// Este método recibe tambien la informacion de Usuario y empleado. 
        /// </summary>
        /// <param name="medicos_Especialidades"></param>
        /// <param name="accion"></param>
        /// <returns></returns>
        public static bool CRUD_MEDICOS(Medicos_TB medicos, string accion)
        {
            try
            {
                List<SqlCommand> lstSentencias = new List<SqlCommand>();//Lista de sentencias a ejecutar
                AD objAcceso = new AD();

                SQLSentencias sentencia = new SQLSentencias();
                //Se crea la peticion
                sentencia.Peticion = "EXEC CRUD_MEDICOS_SP @Usuario_ID, @Password, @Tipo_Perfil, @Nombre, @Apellidos, @Fecha_Nacimiento, @Email," +
                                        "@Telefono,@Empleado_ID, @Empleado_Usuario_ID, @Numero_Carne, @Doctor_Empleado_ID, @Accion";

                //PARAMETROS DE USUARIO
                SqlParameter Usuario_ID_P = new SqlParameter();
                Usuario_ID_P.Value = medicos.Empleados_TB.Usuarios_TB.Usuario_ID;
                Usuario_ID_P.SqlDbType = System.Data.SqlDbType.Int;
                Usuario_ID_P.ParameterName = "@Usuario_ID";

                SqlParameter Password_P = new SqlParameter();
                Password_P.Value = medicos.Empleados_TB.Usuarios_TB.Password;
                Password_P.SqlDbType = System.Data.SqlDbType.VarChar;
                Password_P.ParameterName = "@Password";

                SqlParameter Tipo_Perfil_P = new SqlParameter();
                Tipo_Perfil_P.Value = medicos.Empleados_TB.Usuarios_TB.Tipo_Perfil;
                Tipo_Perfil_P.SqlDbType = System.Data.SqlDbType.SmallInt;
                Tipo_Perfil_P.ParameterName = "@Tipo_Perfil";

                SqlParameter Nombre_P = new SqlParameter();
                Nombre_P.Value = medicos.Empleados_TB.Usuarios_TB.Nombre;
                Nombre_P.SqlDbType = System.Data.SqlDbType.VarChar;
                Nombre_P.ParameterName = "@Nombre";

                SqlParameter Apellidos_P = new SqlParameter();
                Apellidos_P.Value = medicos.Empleados_TB.Usuarios_TB.Apellidos;
                Apellidos_P.SqlDbType = System.Data.SqlDbType.VarChar;
                Apellidos_P.ParameterName = "@Apellidos";

                SqlParameter Fecha_Nacimiento_P = new SqlParameter();
                Fecha_Nacimiento_P.Value = medicos.Empleados_TB.Usuarios_TB.Fecha_Nacimiento;
                Fecha_Nacimiento_P.SqlDbType = System.Data.SqlDbType.Date;
                Fecha_Nacimiento_P.ParameterName = "@Fecha_Nacimiento";

                SqlParameter Email_P = new SqlParameter();
                Email_P.Value = medicos.Empleados_TB.Usuarios_TB.Email;
                Email_P.SqlDbType = System.Data.SqlDbType.VarChar;
                Email_P.ParameterName = "@Email";

                SqlParameter Telefono_P = new SqlParameter();
                Telefono_P.Value = medicos.Empleados_TB.Usuarios_TB.Telefono;
                Telefono_P.SqlDbType = System.Data.SqlDbType.VarChar;
                Telefono_P.ParameterName = "@Telefono";

                //PARAMETROS DE EMPLEADO
                SqlParameter Empleado_ID_P = new SqlParameter();
                Empleado_ID_P.Value = medicos.Empleados_TB.Empleado_ID;
                Empleado_ID_P.SqlDbType = System.Data.SqlDbType.Int;
                Empleado_ID_P.ParameterName = "@Empleado_ID";

                SqlParameter Empleado_Usuario_ID_P = new SqlParameter();
                Empleado_Usuario_ID_P.Value = medicos.Empleados_TB.Empleado_Usuario_ID;
                Empleado_Usuario_ID_P.SqlDbType = System.Data.SqlDbType.VarChar;
                Empleado_Usuario_ID_P.ParameterName = "@Empleado_Usuario_ID";

                //PARAMETROS DE DOCTOR
                SqlParameter Numero_Carne_P = new SqlParameter();
                Numero_Carne_P.Value = medicos.Numero_Carne;
                Numero_Carne_P.SqlDbType = System.Data.SqlDbType.Int;
                Numero_Carne_P.ParameterName = "@Numero_Carne";

                SqlParameter Doctor_Empleado_ID_P = new SqlParameter();
                Doctor_Empleado_ID_P.Value = medicos.Doctor_Empleado_ID;
                Doctor_Empleado_ID_P.SqlDbType = System.Data.SqlDbType.Int;
                Doctor_Empleado_ID_P.ParameterName = "@Doctor_Empleado_ID";

                SqlParameter Accion_P = new SqlParameter();
                Accion_P.Value = accion;
                Accion_P.SqlDbType = System.Data.SqlDbType.Char;
                Accion_P.ParameterName = "@Accion";

                sentencia.lstParametros.Add(Usuario_ID_P);
                sentencia.lstParametros.Add(Password_P);
                sentencia.lstParametros.Add(Tipo_Perfil_P);
                sentencia.lstParametros.Add(Nombre_P);
                sentencia.lstParametros.Add(Apellidos_P);
                sentencia.lstParametros.Add(Fecha_Nacimiento_P);
                sentencia.lstParametros.Add(Email_P);
                sentencia.lstParametros.Add(Telefono_P);
                sentencia.lstParametros.Add(Empleado_ID_P);
                sentencia.lstParametros.Add(Empleado_Usuario_ID_P);
                sentencia.lstParametros.Add(Numero_Carne_P);
                sentencia.lstParametros.Add(Doctor_Empleado_ID_P);
                sentencia.lstParametros.Add(Accion_P);

                return objAcceso.EjecutarSentencias(sentencia);


            }
            catch (Exception e)
            {

                throw e;
            }


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="especialidad"></param>
        /// <param name="accion"></param>
        /// <returns></returns>
        public static bool CRUD_ESPECIALIDADES(Especialidades_TB especialidad, string accion)
        {
            try
            {
                List<SqlCommand> lstSentencias = new List<SqlCommand>();//Lista de sentencias a ejecutar
                AD objAcceso = new AD();

                SQLSentencias sentencia = new SQLSentencias();
                //Se crea la peticion
                sentencia.Peticion = "EXEC CRUD_ESPECIALIDADES_SP @Especialidad_ID, @Nombre, @Accion";
                //Se agregan los parametros correspondientes
                SqlParameter especialidad_ID_P = new SqlParameter();
                especialidad_ID_P.Value = especialidad.Especialidad_ID;
                especialidad_ID_P.SqlDbType = System.Data.SqlDbType.SmallInt;
                especialidad_ID_P.ParameterName = "@especialidad_ID";

                SqlParameter Nombre_P = new SqlParameter();
                Nombre_P.Value = especialidad.Nombre;
                Nombre_P.SqlDbType = System.Data.SqlDbType.VarChar;
                Nombre_P.ParameterName = "@Nombre";

                SqlParameter Accion_P = new SqlParameter();
                Accion_P.Value = accion;
                Accion_P.SqlDbType = System.Data.SqlDbType.Char;
                Accion_P.ParameterName = "@Accion";

                sentencia.lstParametros.Add(especialidad_ID_P);
                sentencia.lstParametros.Add(Nombre_P);
                sentencia.lstParametros.Add(Accion_P);

                return objAcceso.EjecutarSentencias(sentencia);


            }
            catch (Exception e)
            {

                throw e;
            }


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="medicos_Especialidades"></param>
        /// <param name="accion"></param>
        /// <returns></returns>
        public static bool CRUD_MEDICOS_ESPECIALIDADES(Medicos_Especialidades_TB medicos_Especialidades, string accion)
        {
            try
            {
                List<SqlCommand> lstSentencias = new List<SqlCommand>();//Lista de sentencias a ejecutar
                AD objAcceso = new AD();

                SQLSentencias sentencia = new SQLSentencias();
                //Se crea la peticion
                sentencia.Peticion = "EXEC CRUD_ESPECIALIDADES_SP @MED_ID, @ME_Especialidad_ID, @ME_Medico_ID, @Accion";

                //Se agregan los parametros correspondientes
                SqlParameter MED_ID_P = new SqlParameter();
                MED_ID_P.Value = medicos_Especialidades.MED_ID;
                MED_ID_P.SqlDbType = System.Data.SqlDbType.SmallInt;
                MED_ID_P.ParameterName = "@MED_ID";

                SqlParameter ME_Especialidad_ID_P = new SqlParameter();
                ME_Especialidad_ID_P.Value = medicos_Especialidades.ME_Especialidad_ID;
                ME_Especialidad_ID_P.SqlDbType = System.Data.SqlDbType.SmallInt;
                ME_Especialidad_ID_P.ParameterName = "@ME_Especialidad_ID";

                SqlParameter ME_Medico_ID_P = new SqlParameter();
                ME_Medico_ID_P.Value = medicos_Especialidades.ME_Medico_ID;
                ME_Medico_ID_P.SqlDbType = System.Data.SqlDbType.VarChar;
                ME_Medico_ID_P.ParameterName = "@ME_Medico_ID";

                SqlParameter Accion_P = new SqlParameter();
                Accion_P.Value = accion;
                Accion_P.SqlDbType = System.Data.SqlDbType.Char;
                Accion_P.ParameterName = "@Accion";

                sentencia.lstParametros.Add(MED_ID_P);
                sentencia.lstParametros.Add(ME_Especialidad_ID_P);
                sentencia.lstParametros.Add(ME_Medico_ID_P);
                sentencia.lstParametros.Add(Accion_P);

                return objAcceso.EjecutarSentencias(sentencia);


            }
            catch (Exception e)
            {

                throw e;
            }


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="agenda"></param>
        /// <param name="accion"></param>
        /// <returns></returns>
        public static bool CRUD_AGENDA(Agenda_TB agenda, string accion)
        {
            try
            {
                List<SqlCommand> lstSentencias = new List<SqlCommand>();//Lista de sentencias a ejecutar
                AD objAcceso = new AD();

                SQLSentencias sentencia = new SQLSentencias();
                //Se crea la peticion
                sentencia.Peticion = "EXEC CRUD_AGENDA_SP @Agenda_ID, @Agenda_Cita_ID, @Agenda_Horario_ID, @Comentarios, @Accion";

                //Se agregan los parametros correspondientes
                SqlParameter Agenda_ID_P = new SqlParameter();
                Agenda_ID_P.Value = agenda.Agenda_ID;
                Agenda_ID_P.SqlDbType = System.Data.SqlDbType.SmallInt;
                Agenda_ID_P.ParameterName = "@Agenda_ID";

                SqlParameter Agenda_Cita_ID_P = new SqlParameter();
                Agenda_Cita_ID_P.Value = agenda.Agenda_Cita_ID;
                Agenda_Cita_ID_P.SqlDbType = System.Data.SqlDbType.Int;
                Agenda_Cita_ID_P.ParameterName = "@Agenda_Cita_ID";

                SqlParameter Agenda_Horario_ID_P = new SqlParameter();
                Agenda_Horario_ID_P.Value = agenda.Agenda_Horario_ID;
                Agenda_Horario_ID_P.SqlDbType = System.Data.SqlDbType.SmallInt;
                Agenda_Horario_ID_P.ParameterName = "@Agenda_Horario_ID";

                SqlParameter Comentarios_P = new SqlParameter();
                Comentarios_P.Value = agenda.Comentarios;
                Comentarios_P.SqlDbType = System.Data.SqlDbType.VarChar;
                Comentarios_P.ParameterName = "@Comentarios";

                SqlParameter Accion_P = new SqlParameter();
                Accion_P.Value = accion;
                Accion_P.SqlDbType = System.Data.SqlDbType.Char;
                Accion_P.ParameterName = "@Accion";

                sentencia.lstParametros.Add(Agenda_ID_P);
                sentencia.lstParametros.Add(Agenda_Cita_ID_P);
                sentencia.lstParametros.Add(Agenda_Horario_ID_P);
                sentencia.lstParametros.Add(Accion_P);

                return objAcceso.EjecutarSentencias(sentencia);


            }
            catch (Exception e)
            {

                throw e;
            }


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cita"></param>
        /// <param name="accion"></param>
        /// <returns></returns>
        public static bool CRUD_CITAS(Citas_TB cita, string accion)
        {
            try
            {
                List<SqlCommand> lstSentencias = new List<SqlCommand>();//Lista de sentencias a ejecutar
                AD objAcceso = new AD();

                SQLSentencias sentencia = new SQLSentencias();
                //Se crea la peticion
                sentencia.Peticion = "EXEC CRUD_CITAS_SP @Cita_ID, @Cita_Cliente, @Cita_MP_ID, @Cita_Consultorio_ID, @Cita_ME_ID, @Cita_Fact_ID, @Fecha, @Estado, @Accion";
                //Se agregan los parametros correspondientes

                SqlParameter Cita_ID_P = new SqlParameter();
                Cita_ID_P.Value = cita.Cita_ID;
                Cita_ID_P.SqlDbType = System.Data.SqlDbType.Int;
                Cita_ID_P.ParameterName = "@Cita_ID";

                SqlParameter Cita_Cliente_P = new SqlParameter();
                Cita_Cliente_P.Value = cita.Cita_Cliente_ID;
                Cita_Cliente_P.SqlDbType = System.Data.SqlDbType.Int;
                Cita_Cliente_P.ParameterName = "@Cita_Cliente";

                SqlParameter Cita_MP_ID_P = new SqlParameter();
                Cita_MP_ID_P.Value = cita.Cita_MP_ID;
                Cita_MP_ID_P.SqlDbType = System.Data.SqlDbType.Int;
                Cita_MP_ID_P.ParameterName = "@Cita_MP_ID";

                SqlParameter Cita_Consultorio_ID_P = new SqlParameter();
                Cita_Consultorio_ID_P.Value = cita.Cita_Consultorio_ID;
                Cita_Consultorio_ID_P.SqlDbType = System.Data.SqlDbType.Int;
                Cita_Consultorio_ID_P.ParameterName = "@Cita_Consultorio_ID";

                SqlParameter Cita_ME_ID_P = new SqlParameter();
                Cita_ME_ID_P.Value = cita.Cita_ME_ID;
                Cita_ME_ID_P.SqlDbType = System.Data.SqlDbType.Int;
                Cita_ME_ID_P.ParameterName = "@Cita_ME_ID";

                SqlParameter Cita_Fact_ID_P = new SqlParameter();
                Cita_Fact_ID_P.Value = cita.Cita_Fact_ID;
                Cita_Fact_ID_P.SqlDbType = System.Data.SqlDbType.Int;
                Cita_Fact_ID_P.ParameterName = "@Cita_Fact_ID";

                SqlParameter Fecha_P = new SqlParameter();
                Fecha_P.Value = cita.Fecha;
                Fecha_P.SqlDbType = System.Data.SqlDbType.DateTime;
                Fecha_P.ParameterName = "@Fecha";

                SqlParameter Estado_P = new SqlParameter();
                Estado_P.Value = cita.Estado;
                Estado_P.SqlDbType = System.Data.SqlDbType.Char;
                Estado_P.ParameterName = "@Estado";

                SqlParameter Accion_P = new SqlParameter();
                Accion_P.Value = accion;
                Accion_P.SqlDbType = System.Data.SqlDbType.Char;
                Accion_P.ParameterName = "@Accion";

                sentencia.lstParametros.Add(Cita_ID_P);
                sentencia.lstParametros.Add(Cita_Cliente_P);
                sentencia.lstParametros.Add(Cita_MP_ID_P);
                sentencia.lstParametros.Add(Cita_Consultorio_ID_P);
                sentencia.lstParametros.Add(Cita_ME_ID_P);
                sentencia.lstParametros.Add(Cita_Fact_ID_P);
                sentencia.lstParametros.Add(Fecha_P);
                sentencia.lstParametros.Add(Estado_P);
                sentencia.lstParametros.Add(Accion_P);

                return objAcceso.EjecutarSentencias(sentencia);


            }
            catch (Exception e)
            {

                throw e;
            }


        }

        /// <summary>
        /// El cliente siempre debe venir con la informacion del usuario completa. 
        /// </summary>
        /// <param name="especialidad"></param> 
        /// <param name="accion"></param>
        /// <returns></returns>
        public static bool CRUD_CLIENTES(Clientes_TB cliente, string accion)
        {
            try
            {
                List<SqlCommand> lstSentencias = new List<SqlCommand>();//Lista de sentencias a ejecutar
                AD objAcceso = new AD();

                SQLSentencias sentencia = new SQLSentencias();
                //Se crea la peticion
                sentencia.Peticion = "EXEC CRUD_CLIENTES_SP @Usuario_ID, @Password, @Tipo_Perfil, @Nombre, @Apellidos, @Fecha_Nacimiento, @Email, @Telefono, @Cliente_ID, @Cliente_Usuario_ID, @Accion";
                //Se agregan los parametros correspondientes

                SqlParameter Usuario_ID_P = new SqlParameter();
                Usuario_ID_P.Value = cliente.Usuarios_TB.Usuario_ID;
                Usuario_ID_P.SqlDbType = System.Data.SqlDbType.Int;
                Usuario_ID_P.ParameterName = "@Usuario_ID";

                SqlParameter Password_P = new SqlParameter();
                Password_P.Value = cliente.Usuarios_TB.Password;
                Password_P.SqlDbType = System.Data.SqlDbType.VarChar;
                Password_P.ParameterName = "@Password";

                SqlParameter Tipo_Perfil_P = new SqlParameter();
                Tipo_Perfil_P.Value = cliente.Usuarios_TB.Tipo_Perfil;
                Tipo_Perfil_P.SqlDbType = System.Data.SqlDbType.SmallInt;
                Tipo_Perfil_P.ParameterName = "@Tipo_Perfil";

                SqlParameter Nombre_P = new SqlParameter();
                Nombre_P.Value = cliente.Usuarios_TB.Nombre;
                Nombre_P.SqlDbType = System.Data.SqlDbType.VarChar;
                Nombre_P.ParameterName = "@Nombre";

                SqlParameter Apellidos_P = new SqlParameter();
                Apellidos_P.Value = cliente.Usuarios_TB.Apellidos;
                Apellidos_P.SqlDbType = System.Data.SqlDbType.VarChar;
                Apellidos_P.ParameterName = "@Apellidos";

                SqlParameter Fecha_Nacimiento_P = new SqlParameter();
                Fecha_Nacimiento_P.Value = cliente.Usuarios_TB.Fecha_Nacimiento;
                Fecha_Nacimiento_P.SqlDbType = System.Data.SqlDbType.Date;
                Fecha_Nacimiento_P.ParameterName = "@Fecha_Nacimiento";

                SqlParameter Email_P = new SqlParameter();
                Email_P.Value = cliente.Usuarios_TB.Email;
                Email_P.SqlDbType = System.Data.SqlDbType.VarChar;
                Email_P.ParameterName = "@Email";

                SqlParameter Telefono_P = new SqlParameter();
                Telefono_P.Value = cliente.Usuarios_TB.Telefono;
                Telefono_P.SqlDbType = System.Data.SqlDbType.VarChar;
                Telefono_P.ParameterName = "@Telefono";


                SqlParameter Cliente_ID_P = new SqlParameter();
                Cliente_ID_P.Value = cliente.Cliente_ID;
                Cliente_ID_P.SqlDbType = System.Data.SqlDbType.Int;
                Cliente_ID_P.ParameterName = "@Cliente_ID";

                SqlParameter Cliente_Usuario_ID_P = new SqlParameter();
                Cliente_Usuario_ID_P.Value = cliente.Cliente_Usuario_ID;
                Cliente_Usuario_ID_P.SqlDbType = System.Data.SqlDbType.VarChar;
                Cliente_Usuario_ID_P.ParameterName = "@Cliente_Usuario_ID";

                SqlParameter Accion_P = new SqlParameter();
                Accion_P.Value = accion;
                Accion_P.SqlDbType = System.Data.SqlDbType.Char;
                Accion_P.ParameterName = "@Accion";

                sentencia.lstParametros.Add(Usuario_ID_P);
                sentencia.lstParametros.Add(Password_P);
                sentencia.lstParametros.Add(Tipo_Perfil_P);
                sentencia.lstParametros.Add(Nombre_P);
                sentencia.lstParametros.Add(Apellidos_P);
                sentencia.lstParametros.Add(Fecha_Nacimiento_P);
                sentencia.lstParametros.Add(Email_P);
                sentencia.lstParametros.Add(Telefono_P);
                sentencia.lstParametros.Add(Cliente_ID_P);
                sentencia.lstParametros.Add(Cliente_Usuario_ID_P);
                sentencia.lstParametros.Add(Accion_P);

                return objAcceso.EjecutarSentencias(sentencia);


            }
            catch (Exception e)
            {

                throw e;
            }


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="especialidad"></param>
        /// <param name="accion"></param>
        /// <returns></returns>
        public static bool CRUD_PADECIMIENTOS(Padecimientos_TB padecimiento, string accion)
        {
            try
            {
                List<SqlCommand> lstSentencias = new List<SqlCommand>();//Lista de sentencias a ejecutar
                AD objAcceso = new AD();

                SQLSentencias sentencia = new SQLSentencias();
                //Se crea la peticion
                sentencia.Peticion = "EXEC CRUD_PADECIMIENTOS_SP @Padecimiento_ID, @Nombre, @Accion";
                //Se agregan los parametros correspondientes
                SqlParameter Padecimiento_ID_P = new SqlParameter();
                Padecimiento_ID_P.Value = padecimiento.Padecimiento_ID;
                Padecimiento_ID_P.SqlDbType = System.Data.SqlDbType.SmallInt;
                Padecimiento_ID_P.ParameterName = "@Padecimiento_ID";

                SqlParameter Nombre_P = new SqlParameter();
                Nombre_P.Value = padecimiento.Nombre;
                Nombre_P.SqlDbType = System.Data.SqlDbType.VarChar;
                Nombre_P.ParameterName = "@Nombre";

                SqlParameter Accion_P = new SqlParameter();
                Accion_P.Value = accion;
                Accion_P.SqlDbType = System.Data.SqlDbType.Char;
                Accion_P.ParameterName = "@Accion";

                sentencia.lstParametros.Add(Padecimiento_ID_P);
                sentencia.lstParametros.Add(Nombre_P);
                sentencia.lstParametros.Add(Accion_P);

                return objAcceso.EjecutarSentencias(sentencia);


            }
            catch (Exception e)
            {

                throw e;
            }


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientes_Padecimientos"></param>
        /// <param name="accion"></param>
        /// <returns></returns>
        public static bool CRUD_CLIENTES_PADECIMIENTOS(Clientes_Padecimientos_TB clientes_Padecimientos, string accion)
        {
            try
            {
                List<SqlCommand> lstSentencias = new List<SqlCommand>();//Lista de sentencias a ejecutar
                AD objAcceso = new AD();

                SQLSentencias sentencia = new SQLSentencias();
                //Se crea la peticion
                sentencia.Peticion = "EXEC CRUD_CLIENTES_PADECIMIENTOS_SP @CP_ID, @CP_Cliente_ID, @CP_Padecimiento_ID, @CP_Comentarios, @Accion";

                //Se agregan los parametros correspondientes
                SqlParameter CP_ID_P = new SqlParameter();
                CP_ID_P.Value = clientes_Padecimientos.CP_ID;
                CP_ID_P.SqlDbType = System.Data.SqlDbType.Int;
                CP_ID_P.ParameterName = "@CP_ID";

                SqlParameter CP_Cliente_ID_P = new SqlParameter();
                CP_Cliente_ID_P.Value = clientes_Padecimientos.CP_Cliente_ID;
                CP_Cliente_ID_P.SqlDbType = System.Data.SqlDbType.Int;
                CP_Cliente_ID_P.ParameterName = "@CP_Cliente_ID";

                SqlParameter CP_Padecimiento_ID_P = new SqlParameter();
                CP_Padecimiento_ID_P.Value = clientes_Padecimientos.CP_Padecimiento_ID;
                CP_Padecimiento_ID_P.SqlDbType = System.Data.SqlDbType.Int;
                CP_Padecimiento_ID_P.ParameterName = "@CP_Padecimiento_ID";

                SqlParameter CP_Comentarios = new SqlParameter();
                CP_Comentarios.Value = clientes_Padecimientos.CP_Comentarios;
                CP_Comentarios.SqlDbType = System.Data.SqlDbType.VarChar;
                CP_Comentarios.ParameterName = "@CP_Comentarios";

                SqlParameter Accion_P = new SqlParameter();
                Accion_P.Value = accion;
                Accion_P.SqlDbType = System.Data.SqlDbType.Char;
                Accion_P.ParameterName = "@Accion";

                sentencia.lstParametros.Add(CP_ID_P);
                sentencia.lstParametros.Add(CP_Cliente_ID_P);
                sentencia.lstParametros.Add(CP_Padecimiento_ID_P);
                sentencia.lstParametros.Add(CP_Comentarios);
                sentencia.lstParametros.Add(Accion_P);

                return objAcceso.EjecutarSentencias(sentencia);


            }
            catch (Exception e)
            {

                throw e;
            }


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="consultorio"></param>
        /// <param name="accion"></param>
        /// <returns></returns>
        public static bool CRUD_CONSULTORIOS(Consultorio_TB consultorio, string accion)
        {
            try
            {
                List<SqlCommand> lstSentencias = new List<SqlCommand>();//Lista de sentencias a ejecutar
                AD objAcceso = new AD();

                SQLSentencias sentencia = new SQLSentencias();
                //Se crea la peticion
                sentencia.Peticion = "EXEC CRUD_CONSULTORIO_SP @Consultorio_ID, @Nombre, @Estado, @Accion";

                //Se agregan los parametros correspondientes
                SqlParameter Consultorio_ID_P = new SqlParameter();
                Consultorio_ID_P.Value = consultorio.Consultorio_ID;
                Consultorio_ID_P.SqlDbType = System.Data.SqlDbType.SmallInt;
                Consultorio_ID_P.ParameterName = "@Consultorio_ID";

                SqlParameter Nombre_P = new SqlParameter();
                Nombre_P.Value = consultorio.Nombre;
                Nombre_P.SqlDbType = System.Data.SqlDbType.VarChar;
                Nombre_P.ParameterName = "@Nombre";

                SqlParameter Estado_P = new SqlParameter();
                Estado_P.Value = consultorio.Estado;
                Estado_P.SqlDbType = System.Data.SqlDbType.Char;
                Estado_P.ParameterName = "@Estado";

                SqlParameter Accion_P = new SqlParameter();
                Accion_P.Value = accion;
                Accion_P.SqlDbType = System.Data.SqlDbType.Char;
                Accion_P.ParameterName = "@Accion";

                sentencia.lstParametros.Add(Consultorio_ID_P);
                sentencia.lstParametros.Add(Nombre_P);
                sentencia.lstParametros.Add(Estado_P);
                sentencia.lstParametros.Add(Accion_P);

                return objAcceso.EjecutarSentencias(sentencia);


            }
            catch (Exception e)
            {

                throw e;
            }


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="consultorio"></param>
        /// <param name="accion"></param>
        /// <returns></returns>
        public static bool CRUD_EMPLEADOS(Empleados_TB empleado, string accion)
        {
            try
            {
                List<SqlCommand> lstSentencias = new List<SqlCommand>();//Lista de sentencias a ejecutar
                AD objAcceso = new AD();

                SQLSentencias sentencia = new SQLSentencias();
                //Se crea la peticion
                sentencia.Peticion = "EXEC CRUD_EMPLEADOS_SP @Empleado_ID, @Empleado_Usuario_ID, @Accion";

                //Se agregan los parametros correspondientes
                SqlParameter Empleado_ID_P = new SqlParameter();
                Empleado_ID_P.Value = empleado.Empleado_ID;
                Empleado_ID_P.SqlDbType = System.Data.SqlDbType.Int;
                Empleado_ID_P.ParameterName = "@Empleado_ID";

                SqlParameter Empleado_Usuario_ID_P = new SqlParameter();
                Empleado_Usuario_ID_P.Value = empleado.Empleado_Usuario_ID;
                Empleado_Usuario_ID_P.SqlDbType = System.Data.SqlDbType.VarChar;
                Empleado_Usuario_ID_P.ParameterName = "@Empleado_Usuario_ID";

                SqlParameter Accion_P = new SqlParameter();
                Accion_P.Value = accion;
                Accion_P.SqlDbType = System.Data.SqlDbType.Char;
                Accion_P.ParameterName = "@Accion";

                sentencia.lstParametros.Add(Empleado_ID_P);
                sentencia.lstParametros.Add(Empleado_Usuario_ID_P);
                sentencia.lstParametros.Add(Accion_P);

                return objAcceso.EjecutarSentencias(sentencia);


            }
            catch (Exception e)
            {

                throw e;
            }


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="horario"></param>
        /// <param name="accion"></param>
        /// <returns></returns>
        public static bool CRUD_HORARIOS(Horarios_TB horario, string accion)
        {
            try
            {
                List<SqlCommand> lstSentencias = new List<SqlCommand>();//Lista de sentencias a ejecutar
                AD objAcceso = new AD();

                SQLSentencias sentencia = new SQLSentencias();
                //Se crea la peticion
                sentencia.Peticion = "EXEC CRUD_HORARIOS_SP @Horario_ID, @Dia, @Hora_Inicio, @Hora_Fin, @Disponible, @Accion";
                //Se agregan los parametros correspondientes
                SqlParameter Horario_ID_P = new SqlParameter();
                Horario_ID_P.Value = horario.Horario_ID;
                Horario_ID_P.SqlDbType = System.Data.SqlDbType.Int;
                Horario_ID_P.ParameterName = "@Horario_ID";

                SqlParameter Dia_P = new SqlParameter();
                Dia_P.Value = horario.Dia;
                Dia_P.SqlDbType = System.Data.SqlDbType.VarChar;
                Dia_P.ParameterName = "@Dia";

                SqlParameter Hora_Inicio_P = new SqlParameter();
                Hora_Inicio_P.Value = horario.Hora_Inicio;
                Hora_Inicio_P.SqlDbType = System.Data.SqlDbType.DateTime;
                Hora_Inicio_P.ParameterName = "@Hora_Inicio";

                SqlParameter Hora_Fin_P = new SqlParameter();
                Hora_Fin_P.Value = horario.Hora_Fin;
                Hora_Fin_P.SqlDbType = System.Data.SqlDbType.DateTime;
                Hora_Fin_P.ParameterName = "@Hora_Fin";

                SqlParameter Disponible_P = new SqlParameter();
                Disponible_P.Value = horario.Disponible;
                Disponible_P.SqlDbType = System.Data.SqlDbType.VarChar;
                Disponible_P.ParameterName = "@Disponible";

                SqlParameter Accion_P = new SqlParameter();
                Accion_P.Value = accion;
                Accion_P.SqlDbType = System.Data.SqlDbType.Char;
                Accion_P.ParameterName = "@Accion";

                sentencia.lstParametros.Add(Horario_ID_P);
                sentencia.lstParametros.Add(Dia_P);
                sentencia.lstParametros.Add(Hora_Inicio_P);
                sentencia.lstParametros.Add(Hora_Fin_P);
                sentencia.lstParametros.Add(Disponible_P);
                sentencia.lstParametros.Add(Accion_P);

                return objAcceso.EjecutarSentencias(sentencia);


            }
            catch (Exception e)
            {

                throw e;
            }


        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tarjeta"></param>
        /// <param name="accion"></param>
        /// <returns></returns>
        public static bool CRUD_TARJETAS(Tarjetas_TB tarjeta, string accion)
        {
            try
            {
                List<SqlCommand> lstSentencias = new List<SqlCommand>();//Lista de sentencias a ejecutar
                AD objAcceso = new AD();

                SQLSentencias sentencia = new SQLSentencias();
                //Se crea la peticion
                sentencia.Peticion = "EXEC CRUD_TARJETAS_SP @Numero_Tarjeta, @Tarjeta_Cliente_ID, @Fecha_Vencimiento, @Accion";

                //Se agregan los parametros correspondientes
                SqlParameter Numero_Tarjeta_P = new SqlParameter();
                Numero_Tarjeta_P.Value = tarjeta.Numero_Tarjeta;
                Numero_Tarjeta_P.SqlDbType = System.Data.SqlDbType.Int;
                Numero_Tarjeta_P.ParameterName = "@Numero_Tarjeta";

                SqlParameter Tarjeta_Cliente_ID_P = new SqlParameter();
                Tarjeta_Cliente_ID_P.Value = tarjeta.Tarjeta_Cliente_ID;
                Tarjeta_Cliente_ID_P.SqlDbType = System.Data.SqlDbType.Int;
                Tarjeta_Cliente_ID_P.ParameterName = "@Tarjeta_Cliente_ID";

                SqlParameter Fecha_Vencimiento_P = new SqlParameter();
                Fecha_Vencimiento_P.Value = tarjeta.Fecha_Vencimiento;
                Fecha_Vencimiento_P.SqlDbType = System.Data.SqlDbType.Date;
                Fecha_Vencimiento_P.ParameterName = "@Fecha_Vencimiento";

                SqlParameter Accion_P = new SqlParameter();
                Accion_P.Value = accion;
                Accion_P.SqlDbType = System.Data.SqlDbType.Char;
                Accion_P.ParameterName = "@Accion";

                sentencia.lstParametros.Add(Numero_Tarjeta_P);
                sentencia.lstParametros.Add(Tarjeta_Cliente_ID_P);
                sentencia.lstParametros.Add(Fecha_Vencimiento_P);
                sentencia.lstParametros.Add(Accion_P);

                return objAcceso.EjecutarSentencias(sentencia);


            }
            catch (Exception e)
            {

                throw e;
            }


        }






        #endregion

    }
}
