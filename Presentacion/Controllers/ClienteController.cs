using FrontEndProyecto1;
using FrontEndProyecto1.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Presentacion.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Presentacion.Controllers
{
    public class ClienteController : Controller
    {
        #region BITÁCORA

        public async void RegistroBitacora(string desc)
        {
            Usuario usuario = new Usuario();

            ClaimsIdentity identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
            //TODO USUARIO PUEDE CONTENER UNA SERIE DE CARACTERISTICAS
            //LLAMADA CLAIMS.  DICHAS CARACTERISTICAS PODEMOS ALMACENARLAS
            //DENTRO DE USER PARA UTILIZARLAS A LO LARGO DE LA APP
            Claim claimUserName = new Claim(ClaimTypes.Name, usuario.Nombre);
            Claim claimRole = new Claim(ClaimTypes.Role, usuario.Tipo);
            Claim claimIdUsuario = new Claim("IdUsuario", usuario.IdUsuario.ToString());
            Claim claimEmail = new Claim("EmailUsuario", usuario.Email);

            identity.AddClaim(claimUserName);
            identity.AddClaim(claimRole);
            identity.AddClaim(claimIdUsuario);
            identity.AddClaim(claimEmail);
            ClaimsPrincipal userPrincipal = new ClaimsPrincipal(identity);

            CBitacora registro = new CBitacora();

            ConexionApis objConexion = new ConexionApis();
            registro.Id_Usuario = usuario.IdUsuario.ToString();
            registro.nombre_usuario = identity.Name.ToString();
            registro.descripcion = desc;
            await objConexion.RegistroBitacora(registro);
        }
        #endregion
        //--------LISTAR CLIENTE--------
        public async Task<IActionResult> Index()
        {
            GestorConexiones objconexion = new GestorConexiones();
            List<ClienteModel> lstresultados = await objconexion.ListarCliente();
            string desc = "Consulta de clientes";
            RegistroBitacora(desc);
            return View(lstresultados);
            
        }

        public IActionResult CrearCliente()
        {
            string desc = "Creación de clientes";
            RegistroBitacora(desc);
            return View();
        }

        public async Task<IActionResult> EditaCliente(ClienteModel ObjCliente)
        {
            string id = ObjCliente.CedulaCliente;

            GestorConexiones objconexion = new GestorConexiones();
            List<ClienteModel> lstresultados = await objconexion.ListarCliente();
            ClienteModel cliente = lstresultados.Find(x => x.CedulaCliente.Equals(id));
            string desc = "Edición de clientes";
            RegistroBitacora(desc);
            return View(cliente);
        }

        
        public async Task<IActionResult> Eliminar(ClienteModel ObjCliente)
        {
            string id = ObjCliente.CedulaCliente;
            GestorConexiones objconexion = new GestorConexiones();
            List<ClienteModel> lstresultados = await objconexion.ListarCliente();
            ClienteModel cliente = lstresultados.Find(x => x.CedulaCliente.Equals(id));
            string desc = "Eliminación de clientes";
            RegistroBitacora(desc);
            return View(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> Guardar(ClienteModel P_Modelo)
        {
            GestorConexiones objconexion = new GestorConexiones();
            await objconexion.AgregarCliente(P_Modelo);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Modificar(ClienteModel P_Modelo)
        {
            GestorConexiones objconexion = new GestorConexiones();
            await objconexion.ModificarCliente(P_Modelo);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> EliminarCliente(ClienteModel P_Modelo)
        {
            GestorConexiones objconexion = new GestorConexiones();
            await objconexion.EliminarCliente(P_Modelo);
            return RedirectToAction("Index");
        }

    }
}
