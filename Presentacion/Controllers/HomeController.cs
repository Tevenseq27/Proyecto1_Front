using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FrontEndProyecto1.Filters;
using FrontEndProyecto1.Models;
using FrontEndProyecto1.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Presentacion.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
        private RepositoryWeb repo;

        public HomeController(RepositoryWeb repo)
        {
            this.repo = repo;
        }


        [HttpPost]
        public IActionResult Registro(string email, string password, string nombre, string apellidos, string tipo)
        {
            bool registrado = this.repo.RegistrarUsuario(email, password, nombre, apellidos, tipo);
            if (registrado)
            {
                ViewData["MENSAJE"] = "Usuario registrado con exito";
            }
            else
            {
                ViewData["MENSAJE"] = "Error al registrar el usuario";
            }
            return View();
        }

        [AuthorizeUsers]
        public IActionResult PaginaProtegida()
        {
            return View();
        }

        [AuthorizeUsers(Policy = "ADMINISTRADORES")]
        public IActionResult AdminUsuarios()
        {
            List<Usuario> usuarios = this.repo.GetUsuarios();
            return View(usuarios);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
