using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SQLSentencias
    {
        #region Propiedades

        public string Peticion { get; set; }
        public List<SqlParameter> lstParametros { get; set; }

        #endregion

        #region Constructor

        public SQLSentencias()
        {
            Peticion = string.Empty;
            lstParametros = new List<SqlParameter>();
        }

        #endregion
    }
}
