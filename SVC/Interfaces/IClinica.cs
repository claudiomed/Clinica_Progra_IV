using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BLL;
using DAL;

namespace SVC
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IClinica" in both code and config file together.
    [ServiceContract]
    public interface IClinica
    {
        [OperationContract]
        bool CRUD_USUARIOS(Usuarios_TB usuario, string accion);
    }
}
