using FrontEndProyecto1;
using FrontEndProyecto1.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Presentacion.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Presentacion.Controllers
{
    public class HabitacionController : Controller
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

        //--------LISTAR HABITACION--------
        public async Task<IActionResult> Index()
        {
            GestorConexiones objconexion = new GestorConexiones();
            List<HabitacionModel> lstresultados = await objconexion.ListarHabitacion();
            string desc = "Consulta de habitaciones";
            RegistroBitacora(desc);
            return View(lstresultados);
        }

        //--------CREAR--------
        public IActionResult CrearHabitacion()
        {
            string desc = "Creación de habitaciones";
            RegistroBitacora(desc);
            return View();
        }

        //--------MODIFICAR--------
        public async Task<IActionResult> EditaHabitacion(HabitacionModel ObjHabitacion)
        {
            short id = ObjHabitacion.CodHabitacion;

            GestorConexiones objconexion = new GestorConexiones();
            List<HabitacionModel> lstresultados = await objconexion.ListarHabitacion();
            HabitacionModel habitacion = lstresultados.Find(x => x.CodHabitacion.Equals(id));

            string desc = "Edición de habitaciones";
            RegistroBitacora(desc);

            return View(habitacion);
        }

        //--------ELIMINAR--------
        public async Task<IActionResult> Eliminar(HabitacionModel ObjHabitacion)
        {
            short id = ObjHabitacion.CodHabitacion;

            GestorConexiones objconexion = new GestorConexiones();
            List<HabitacionModel> lstresultados = await objconexion.ListarHabitacion();
            HabitacionModel habitacion = lstresultados.Find(x => x.CodHabitacion.Equals(id));

            string desc = "Eliminación de habitaciones";
            RegistroBitacora(desc);


            return View(habitacion);
        }

        [HttpPost]
        public async Task<IActionResult> Guardar(HabitacionModel P_Modelo)
        {

            GestorConexiones objconexion = new GestorConexiones();
            await objconexion.AgregarHabitacion(P_Modelo);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Modificar(HabitacionModel P_Modelo)
        {
            GestorConexiones objconexion = new GestorConexiones();
            await objconexion.ModificarHabitacion(P_Modelo);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> EliminarHabitacion(HabitacionModel P_Modelo)
        {
            GestorConexiones objconexion = new GestorConexiones();
            await objconexion.EliminarHabitacion(P_Modelo);
            return RedirectToAction("Index");
        }
    }
}
