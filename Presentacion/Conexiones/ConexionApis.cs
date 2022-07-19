using FrontEndProyecto1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FrontEndProyecto1
{
    public class ConexionApis
    {
        #region Atributos

        private HttpClient Cliente = new HttpClient();

        #endregion
        #region Metodos

        #region Metodos Privados

        private void InicializarBitacora()
        {
            Cliente.BaseAddress = new Uri("http://localhost:10060"); //Direccion del backend, lo puedo tomar del postman
            Cliente.DefaultRequestHeaders.Accept.Clear();
            Cliente.DefaultRequestHeaders.Accept.Add
            (
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
            );
        }

        #endregion

        #region Metodos Publicos

        public async Task<bool> RegistroBitacora(CBitacora P_Registro)
        {
            InicializarBitacora();
            string urlAgregarRegistro = "api/Seguridad/AgregarRegistro";
            HttpResponseMessage resultado = await Cliente.PostAsJsonAsync(urlAgregarRegistro, P_Registro);
            return resultado.IsSuccessStatusCode;
        }

        public async Task<List<CBitacora>> ConsultarRegistro(CBitacora P_Registro)
        {
            List<CBitacora> lista = new List<CBitacora>();
            InicializarBitacora();
            string urlConsultarRegistro = "api/Seguridad/ConsultarRegistro"; 
            HttpResponseMessage resultado = await Cliente.GetAsync(urlConsultarRegistro);
            if (resultado.IsSuccessStatusCode)
            {
                var convertirAstring = await resultado.Content.ReadAsStringAsync();
                lista = JsonConvert.DeserializeObject<List<CBitacora>>(convertirAstring);
            }
            return lista;
        }

        #endregion

        #endregion
    }
}
