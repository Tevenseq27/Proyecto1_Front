using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentacion.Models
{
    public class ClienteModel
    {
        #region Propiedades

        public string CedulaCliente { get; set; }
        public string NombreCliente { get; set; }
        public string Apellido1Cliente { get; set; }
        public string Apellido2Cliente { get; set; }
        public string TelefonoCliente { get; set; }
        public string CorreoCliente { get; set; }

        #endregion

        #region Constructor

        public ClienteModel()
        {
            CedulaCliente = string.Empty;
            NombreCliente = string.Empty;
            Apellido1Cliente = string.Empty;
            Apellido2Cliente = string.Empty;
            TelefonoCliente = string.Empty;
            CorreoCliente = string.Empty;
        }
        #endregion
    }
}
