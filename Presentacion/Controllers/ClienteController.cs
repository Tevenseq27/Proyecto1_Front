using Microsoft.AspNetCore.Mvc;
using Presentacion.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentacion.Controllers
{
    public class ClienteController : Controller
    {
        public async Task<IActionResult> Index()
        {
            GestorConexiones objconexion = new GestorConexiones();
            List<ClienteModel> lstresultados = await objconexion.ListarCliente();

            return View(lstresultados);
        }

        public IActionResult CrearCliente()
        {
            return View();
        }

        public async Task<IActionResult> EditaCliente(ClienteModel ObjCliente)
        {
            string id = ObjCliente.CedulaCliente;

            GestorConexiones objconexion = new GestorConexiones();
            List<ClienteModel> lstresultados = await objconexion.ListarCliente();
            ClienteModel cliente = lstresultados.Find(x => x.CedulaCliente.Equals(id));

            return View(cliente);
        }

        
        public async Task<IActionResult> Eliminar(ClienteModel ObjCliente)
        {
            string id = ObjCliente.CedulaCliente;
            GestorConexiones objconexion = new GestorConexiones();
            List<ClienteModel> lstresultados = await objconexion.ListarCliente();
            ClienteModel cliente = lstresultados.Find(x => x.CedulaCliente.Equals(id));

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
