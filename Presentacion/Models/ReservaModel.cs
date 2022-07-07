using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentacion.Models
{
    public class ReservaModel
    {
        #region Propiedades
        public string ID { get; set; }
        public string Codigo { get; set; }
        public DateTime fechaEntrada { get; set; }
        public DateTime fechaSalida { get; set; }
        public int cantAdultos { get; set; }
        public int cantNinos { get; set; }
        public int cantHabitaciones { get; set; }

        #endregion

        #region Constructor

        public ReservaModel()
        {
            ID = string.Empty;
            Codigo = string.Empty;
            fechaEntrada = DateTime.MinValue;
            fechaSalida = DateTime.MinValue;
            cantAdultos = 0;
            cantNinos = 0;
            cantHabitaciones = 0;
        }
        #endregion
    }
}
