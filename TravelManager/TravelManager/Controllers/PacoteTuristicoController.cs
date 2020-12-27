using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelManager.Models;
using TravelManager.Services;

namespace TravelManager.Controllers
{
    public class PacoteTuristicoController : Controller
    {
        private ICadastroPacoteTuristicoServices _cadastroPacoteTuristicoServices;

        public PacoteTuristicoController(ICadastroPacoteTuristicoServices cadastroPacoteTuristicoServices)
        {
            _cadastroPacoteTuristicoServices = cadastroPacoteTuristicoServices;
        }

        public IActionResult Index()
        {
            var model = new ListPacotesTuristico();
            model.PacotesTuristicos = _cadastroPacoteTuristicoServices.ListarTodos();

            return View(model);
        }

        public IActionResult Excluir(int id)
        {
            _cadastroPacoteTuristicoServices.ExcluirPacoteTuristico(id);

            return RedirectToAction("Index");
        }

        public IActionResult Editar(int id)
        {
            var model = _cadastroPacoteTuristicoServices.BuscarPorId(id);
            return View(model);
        }

        public IActionResult NovoPacote()
        {
            var model = new PacoteTuristico();
            return View("Editar", model);
        }

        public IActionResult Salvar(PacoteTuristico pacoteTuristico)
        {
            pacoteTuristico.CodUsuarioCriacao = 3;
            if (pacoteTuristico.Id == 0)
                pacoteTuristico.Id = _cadastroPacoteTuristicoServices.CriarPacoteTuristico(pacoteTuristico);
            else
                _cadastroPacoteTuristicoServices.EditarPacoteTuristico(pacoteTuristico);
            return RedirectToAction("Index");
        }

    }

}
