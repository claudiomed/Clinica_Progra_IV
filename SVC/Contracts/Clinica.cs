using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DAL;

namespace SVC
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Clinica" in both code and config file together.
    public class Clinica : IClinica
    {
        public bool CRUD_USUARIOS(Usuarios_TB usuario, string accion)
        {
            return BLL.BL.CRUD_USUARIOS(usuario, accion);
        }

        public void DoWork()
        {
        }
    }
}
