using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Presentacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentacion.Controllers
{
    public class ReservaController : Controller
    {

        private List<SelectListItem> ObtenerOpciones()
        {
            return new List<SelectListItem> {
                new SelectListItem{
                    Text = "Cédula del huésped",
                    Value = "A"
                },
                new SelectListItem{
                    Text = "Código de la reserva",
                    Value = "B"
                }
            };
        }

        public IActionResult Consultar()
        {
            ViewBag.Listado = ObtenerOpciones();
            return View();
        }


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

            string CodHabitacion = Request.Form["Habitacion"].ToString();
            string CedCliente = Request.Form["Cliente"].ToString();

            List<HabitacionModel> lstHabitaciones = await objconexion.ListarHabitacion();
            HabitacionModel Habitacion = lstHabitaciones.Find(x => x.CodHabitacion.Equals(CodHabitacion));
            Habitacion.EstadoHabitacion = "Reservada";
            await objconexion.ModificarHabitacion(Habitacion);


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

        [HttpPost]
        public async Task<IActionResult> ValorSeleccionado()
        {
            string opcionSeleccionada = Request.Form["ddlFiltro"].ToString();
            string textBoxDato = Request.Form["TextBoxInfo"].ToString();

            GestorConexiones objconexion = new GestorConexiones();
            List<ReservaModel> lstresultados = await objconexion.ListarReserva();

            if (opcionSeleccionada.Equals("A")) //Filtración por cédula del huésped
            {
                lstresultados = lstresultados.FindAll(x => x.CedulaCliente.Equals(textBoxDato));
            }
            else
            {
                lstresultados = lstresultados.FindAll(x => x.CodReserva.Equals(textBoxDato));
            }
            ViewBag.Lista = lstresultados;

            return View();
        }

    }
}
