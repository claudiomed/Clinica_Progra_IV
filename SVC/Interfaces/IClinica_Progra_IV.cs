using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SVC
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IClinica_Progra_IV" in both code and config file together.
    [ServiceContract]
    public interface IClinica_Progra_IV
    {
        #region Métodos CRUD
        [OperationContract]
        bool CRUD_MEDICOS(Medicos_TB medicos, string accion);

        [OperationContract]
        bool CRUD_ESPECIALIDADES(Especialidades_TB especialidad, string accion);

        [OperationContract]
        bool CRUD_MEDICOS_ESPECIALIDADES(Medicos_Especialidades_TB medicos_Especialidades, string accion);

        [OperationContract]
        bool CRUD_AGENDA(Agenda_TB agenda, string accion);

        [OperationContract]
        bool CRUD_CITAS(Citas_TB cita, string accion);

        [OperationContract]
        bool CRUD_CLIENTES(Clientes_TB cliente, string accion);

        [OperationContract]
        bool CRUD_PADECIMIENTOS(Padecimientos_TB padecimiento, string accion);

        [OperationContract]
        bool CRUD_CLIENTES_PADECIMIENTOS(Clientes_Padecimientos_TB clientes_Padecimientos, string accion);

        [OperationContract]
        bool CRUD_CONSULTORIOS(Consultorio_TB consultorio, string accion);

        [OperationContract]
        bool CRUD_HORARIOS(Horarios_TB horario, string accion);

        [OperationContract]
        bool CRUD_TARJETAS(Tarjetas_TB tarjeta, string accion);
        #endregion


        #region Métodos Consulta
        [OperationContract]
        List<Tipos_Perfiles_TB> consultarTiposUsuario();

        [OperationContract]
        List<Agenda_TB> consultarAgenda();

        [OperationContract]
        List<Clientes_Padecimientos_TB> consultarClientesPadecimientos();

        [OperationContract]
        List<Clientes_TB> consultarClientes();

        [OperationContract]
        List<Consultorio_TB> consultarConsultorios();

        [OperationContract]
        List<Empleados_TB> consultarEmpleados();

        [OperationContract]
        List<Especialidades_TB> consultarEspecialidades();

        [OperationContract]
        List<Facturas_TB> consultarFacturas();

        [OperationContract]
        List<Horarios_TB> consultarHorarios();

        [OperationContract]
        List<Medicos_Especialidades_TB> consultarMedicosEspecialidades();

        [OperationContract]
        List<Medicos_TB> consultarMedicos();

        [OperationContract]
        List<Metodos_Pago_TB> consultarMetodosPago();

        [OperationContract]
        List<Padecimientos_TB> consultarPadecimientos();

        [OperationContract]
        List<Procedimientos_TB> consultarProcedimientos();

        [OperationContract]
        List<Tarjetas_TB> consultarTarjetas();

        [OperationContract]
        List<Usuarios_TB> consultarUsuarios();

        #endregion

    }
}
