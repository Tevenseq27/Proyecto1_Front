using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Presentacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Presentacion.Controllers
{
    public class GestorConexiones : Controller
    {
        #region Propiedad

        public HttpClient Cliente { get; set; }

        #endregion

        #region Constructor 

        private void GestorDeConexiones()
        {
            Cliente = new HttpClient();
            Cliente.BaseAddress = new Uri("http://localhost:10060");
            Cliente.DefaultRequestHeaders.Accept.Clear();
            Cliente.DefaultRequestHeaders.Accept.Add
                (
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );
        }

        //Métodos
        #region Cliente
        public async Task<List<ClienteModel>> ListarCliente()
        {
            List<ClienteModel> lstresultados = new List<ClienteModel>();
            GestorDeConexiones();
            string url = "api/Seguridad/ConsultarCliente";
            HttpResponseMessage resultado = await Cliente.GetAsync(url);

            if (resultado.IsSuccessStatusCode)
            {
                var convertirAstring = await resultado.Content.ReadAsStringAsync();
                lstresultados = JsonConvert.DeserializeObject<List<ClienteModel>>(convertirAstring);
            }

            return lstresultados;
        }

        public async Task<bool> AgregarCliente(ClienteModel P_Modelo)
        {
            GestorDeConexiones();
            string url = "api/Seguridad/AgregarCliente";
            HttpResponseMessage resultado = await Cliente.PostAsJsonAsync(url, P_Modelo);
            return resultado.IsSuccessStatusCode;
        }

        public async Task<bool> EliminarCliente(ClienteModel P_Modelo)
        {
            GestorDeConexiones();
            string url = "api/Seguridad/EliminarCliente";
            HttpResponseMessage resultado = await Cliente.PostAsJsonAsync(url, P_Modelo);
            return resultado.IsSuccessStatusCode;
        }

        public async Task<bool> ModificarCliente(ClienteModel P_Modelo)
        {
            GestorDeConexiones();
            string url = "api/Seguridad/ModificarCliente";
            HttpResponseMessage resultado = await Cliente.PostAsJsonAsync(url, P_Modelo);
            return resultado.IsSuccessStatusCode;
        }
        #endregion
        #region Habitación

        //MÉTODO PARA LISTAR HABITACIÓN EN DB
        public async Task<List<HabitacionModel>> ListarHabitacion()
        {
            GestorDeConexiones();

            List<HabitacionModel> lstresultados = new List<HabitacionModel>();
            
            string url = "api/Seguridad/ConsultarHabitacion";

            HttpResponseMessage resultado = await Cliente.GetAsync(url);

            if(resultado.IsSuccessStatusCode)
            {
              var convertirAstring = await resultado.Content.ReadAsStringAsync();
              lstresultados = JsonConvert.DeserializeObject<List<HabitacionModel>>(convertirAstring);
            }
            return lstresultados;
        }

        //MÉTODO PARA AGREGAR HABITACIÓN EN DB
        public async Task<bool> AgregarHabitacion(HabitacionModel P_Modelo)
        {
            GestorDeConexiones();
            string url = "api/Seguridad/AgregarHabitacion";
            HttpResponseMessage resultado = await Cliente.PostAsJsonAsync(url, P_Modelo);
            return resultado.IsSuccessStatusCode;
        }

        //MÉTODO PARA ELIMINAR HABITACIÓN EN DB
        public async Task<bool> EliminarHabitacion(HabitacionModel P_Modelo)
        {
            GestorDeConexiones();
            string url = "api/Seguridad/EliminarHabitacion";
            HttpResponseMessage resultado = await Cliente.PostAsJsonAsync(url, P_Modelo);
            return resultado.IsSuccessStatusCode;
        }

        //MÉTODO PARA MODIFICAR HABITACIÓN EN DB
        public async Task<bool> ModificarHabitacion(HabitacionModel P_Modelo)
        {
            GestorDeConexiones();
            string url = "api/Seguridad/ModificarHabitacion";
            HttpResponseMessage resultado = await Cliente.PostAsJsonAsync(url, P_Modelo);
            return resultado.IsSuccessStatusCode;
        }
        #endregion
        #region Reserva
        //MÉTODO PARA LISTAR RESERVA EN DB
        public async Task<List<ReservaModel>> ListarReserva()
        {          
            List<ReservaModel> lstresultados = new List<ReservaModel>();
            GestorDeConexiones();
            string url = "api/Seguridad/ConsultarReserva";
            HttpResponseMessage resultado = await Cliente.GetAsync(url);

            if (resultado.IsSuccessStatusCode)
            {
                var convertirAstring = await resultado.Content.ReadAsStringAsync();
                lstresultados = JsonConvert.DeserializeObject<List<ReservaModel>>(convertirAstring);
            }
            return lstresultados;
        }

        public async Task<bool> AgregarReserva(ReservaModel P_Modelo)
        {
            GestorDeConexiones();
            string url = "api/Seguridad/AgregarReserva";
            HttpResponseMessage resultado = await Cliente.PostAsJsonAsync(url, P_Modelo);
            return resultado.IsSuccessStatusCode;
        }

        public async Task<bool> EliminarReserva(ReservaModel P_Modelo)
        {
            GestorDeConexiones();
            string url = "api/Seguridad/EliminarReserva";
            HttpResponseMessage resultado = await Cliente.PostAsJsonAsync(url, P_Modelo);
            return resultado.IsSuccessStatusCode;
        }

        public async Task<bool> ModificarReserva(ReservaModel P_Modelo)
        {
            GestorDeConexiones();
            string url = "api/Seguridad/ModificarReserva";
            HttpResponseMessage resultado = await Cliente.PostAsJsonAsync(url, P_Modelo);
            return resultado.IsSuccessStatusCode;
        }

        public async Task<List<ReservaModel>> ListarFecha(ReservaModel P_Modelo)
        {
            List<ReservaModel> lstresultados = new List<ReservaModel>();
            GestorDeConexiones();
            string url = "api/Seguridad/ConsultarReserva";
            HttpResponseMessage resultado = await Cliente.GetAsync(url);

            if (resultado.IsSuccessStatusCode)
            {
                var convertirAstring = await resultado.Content.ReadAsStringAsync();
                lstresultados = JsonConvert.DeserializeObject<List<ReservaModel>>(convertirAstring);
            }

            if (P_Modelo.FechaInicioRango != DateTime.MinValue && P_Modelo.FechaFinRango != DateTime.MinValue)
            {
                lstresultados = lstresultados.Where(x => x.FechaEntrada >= P_Modelo.FechaInicioRango &&
                                                         x.FechaSalida <= P_Modelo.FechaFinRango).ToList();
            }

            return lstresultados;
        }
        #endregion
        #endregion
    }
}
