using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DAL;
using BLL;

namespace SVC
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Clinica_Progra_IV" in both code and config file together.
    public class Clinica_Progra_IV : IClinica_Progra_IV
    {
        #region Métodos CRUD
        public bool CRUD_AGENDA(Agenda_TB agenda, string accion)
        {
            try
            {
                return BL.CRUD_AGENDA(agenda, accion);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public bool CRUD_CITAS(Citas_TB cita, string accion)
        {
            try
            {
                return BL.CRUD_CITAS(cita, accion);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public bool CRUD_CLIENTES(Clientes_TB cliente, string accion)
        {
            try
            {
                return BL.CRUD_CLIENTES(cliente, accion);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool CRUD_CLIENTES_PADECIMIENTOS(Clientes_Padecimientos_TB clientes_Padecimientos, string accion)
        {
            try
            {
                return BL.CRUD_CLIENTES_PADECIMIENTOS(clientes_Padecimientos, accion);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool CRUD_CONSULTORIOS(Consultorio_TB consultorio, string accion)
        {
            try
            {
                return BL.CRUD_CONSULTORIOS(consultorio, accion);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool CRUD_ESPECIALIDADES(Especialidades_TB especialidad, string accion)
        {
            try
            {
                return BL.CRUD_ESPECIALIDADES(especialidad, accion);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool CRUD_HORARIOS(Horarios_TB horario, string accion)
        {
            try
            {
                return BL.CRUD_HORARIOS(horario, accion);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool CRUD_MEDICOS(Medicos_TB medicos, string accion)
        {
            try
            {
                return BL.CRUD_MEDICOS(medicos, accion);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool CRUD_MEDICOS_ESPECIALIDADES(Medicos_Especialidades_TB medicos_Especialidades, string accion)
        {
            try
            {
                return BL.CRUD_MEDICOS_ESPECIALIDADES(medicos_Especialidades, accion);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool CRUD_PADECIMIENTOS(Padecimientos_TB padecimiento, string accion)
        {
            try
            {
                return BL.CRUD_PADECIMIENTOS(padecimiento, accion);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool CRUD_TARJETAS(Tarjetas_TB tarjeta, string accion)
        {
            try
            {
                return BL.CRUD_TARJETAS(tarjeta, accion);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion


        #region Métodos Consultas
        public List<Agenda_TB> consultarAgenda()
        {
            try
            {
                return BL.consultarAgenda();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Clientes_TB> consultarClientes()
        {
            try
            {
                return BL.consultarClientes();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Clientes_Padecimientos_TB> consultarClientesPadecimientos()
        {
            try
            {
                return BL.consultarClientesPadecimientos();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Consultorio_TB> consultarConsultorios()
        {
            try
            {
                return BL.consultarConsultorios();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Empleados_TB> consultarEmpleados()
        {
            try
            {
                return BL.consultarEmpleados();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Especialidades_TB> consultarEspecialidades()
        {
            try
            {
                return BL.consultarEspecialidades();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Facturas_TB> consultarFacturas()
        {
            try
            {
                return BL.consultarFacturas();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Horarios_TB> consultarHorarios()
        {
            try
            {
                return BL.consultarHorarios();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Medicos_TB> consultarMedicos()
        {
            try
            {
                return BL.consultarMedicos();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Medicos_Especialidades_TB> consultarMedicosEspecialidades()
        {
            try
            {
                return BL.consultarMedicosEspecialidades();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Metodos_Pago_TB> consultarMetodosPago()
        {
            try
            {
                return BL.consultarMetodosPago();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Padecimientos_TB> consultarPadecimientos()
        {
            try
            {
                return BL.consultarPadecimientos();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Procedimientos_TB> consultarProcedimientos()
        {
            try
            {
                return BL.consultarProcedimientos();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Tarjetas_TB> consultarTarjetas()
        {
            try
            {
                return BL.consultarTarjetas();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Tipos_Perfiles_TB> consultarTiposUsuario()
        {
            try
            {
                return BL.consultarTiposUsuario();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Usuarios_TB> consultarUsuarios()
        {
            try
            {
                return BL.consultarUsuarios();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}
