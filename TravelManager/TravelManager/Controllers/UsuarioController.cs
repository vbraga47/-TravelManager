using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelManager.Models;
using TravelManager.Services;

namespace TravelManager.Controllers
{
    public class UsuarioController : Controller
    {
        private ICadastroUsuarioServices _cadastroUsuarioServices;

        public UsuarioController(ICadastroUsuarioServices cadastroUsuarioServices)
        {
            _cadastroUsuarioServices = cadastroUsuarioServices;
        }

        public IActionResult Index()
        {
            var model = new ListUsuarios();
            model.Usuarios = _cadastroUsuarioServices.ListarTodos();

            return View(model);
        }

        public IActionResult Excluir(int id)
        {
            _cadastroUsuarioServices.ExcluirUsuario(id);

            return RedirectToAction("Index");
        }

        public IActionResult Editar(int id)
        {
            var model = _cadastroUsuarioServices.BuscarPorId(id);
            return View(model);
        }

        public IActionResult NovoUsuario()
        {
            var model = new Usuario();
            return View("Editar", model);
        }

        public IActionResult Salvar(Usuario usuario)
        {
            if (usuario.Id == 0)
                usuario.Id = _cadastroUsuarioServices.CriarUsuario(usuario);
            else
                _cadastroUsuarioServices.EditarUsuario(usuario);
            return RedirectToAction("Index");
        }
    }
}