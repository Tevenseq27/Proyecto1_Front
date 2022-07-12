using Microsoft.AspNetCore.Mvc;
using Presentacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentacion.Controllers
{
    public class ReservaController : Controller
    {


        //--------LISTAR RESERVA--------
        public async Task<IActionResult> Index()
        {
            GestorConexiones objconexion = new GestorConexiones();
            List<ReservaModel> lstresultados = await objconexion.ListarReserva();
            return View(lstresultados);
        }

        public IActionResult CrearReserva()
        {
            return View();
        }

        public async Task<IActionResult> EditaReserva(ReservaModel ObjReserva)
        {
            short id = ObjReserva.IdReserva;

            GestorConexiones objconexion = new GestorConexiones();
            List<ReservaModel> lstresultados = await objconexion.ListarReserva();
            ReservaModel reserva = lstresultados.Find(x => x.IdReserva.Equals(id));

            return View(reserva);
        }

        public async Task<IActionResult> Eliminar(ReservaModel ObjReserva)
        {
            short id = ObjReserva.IdReserva;

            GestorConexiones objconexion = new GestorConexiones();
            List<ReservaModel> lstresultados = await objconexion.ListarReserva();
            ReservaModel reserva = lstresultados.Find(x => x.IdReserva.Equals(id));

            return View(reserva);
        }

        [HttpPost]
        public async Task<IActionResult> Guardar(ReservaModel P_Modelo)
        {
            GestorConexiones objconexion = new GestorConexiones();
            await objconexion.AgregarReserva(P_Modelo);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Modificar(ReservaModel P_Modelo)
        {
            GestorConexiones objconexion = new GestorConexiones();
            await objconexion.ModificarReserva(P_Modelo);
            return RedirectToAction("Index");
        }

        //ELIMINAR RESERVA
        [HttpPost]
        public async Task<IActionResult> EliminarReserva(ReservaModel P_Modelo)
        {
            GestorConexiones objconexion = new GestorConexiones();
            await objconexion.EliminarReserva(P_Modelo);
            return RedirectToAction("Index");
        }

    }
}
