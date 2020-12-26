using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TravelManager.Models;
using TravelManager.Repositories;

namespace TravelManager.Controllers
{
    public class HomeController : Controller
    {
        private IUsuarioRepository _usuarioRepository;
        public HomeController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public IActionResult Index()
        {
            //var usuario = new Usuario("Vinicius Perroni", DateTime.Parse("18/07/1987"), "vinicius.perroni", "12345", TipoUsuario.Administrado);
            //var idUsuario =  _usuarioRepository.Create(usuario);
            //_usuarioRepository.Delete(1);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
