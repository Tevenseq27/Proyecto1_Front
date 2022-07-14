using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentacion.Models
{
    public class ReservaModel
    {
        #region Propiedades
        public short IdReserva { get; set; }
        public string CodReserva { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }
        public short CantidadAdultos { get; set; }
        public short CantidadNinos { get; set; }
        public string CedulaCliente { get; set; }
        public short CodHabitacion { get; set; }
        public decimal PrecioHabitacion { get; set; }
        public ClienteModel Cliente { get; set; }

        #endregion

        #region Constructor

        public ReservaModel()
        {
            IdReserva = short.MinValue;
            CodReserva = string.Empty;
            FechaEntrada = DateTime.MinValue;
            FechaSalida = DateTime.MinValue;
            CantidadAdultos = 0;
            CantidadNinos = 0;
            CedulaCliente = string.Empty;
            CodHabitacion = 0;
            PrecioHabitacion = 0;
            Cliente = null;
        }
        #endregion
    }
}
