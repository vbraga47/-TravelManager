using System.Collections.Generic;
using TravelManager.Models;
using TravelManager.Repositories;

namespace TravelManager.Services.Impl
{
    public class CadastroPacoteTuristicoServices : ICadastroPacoteTuristicoServices
    {
        private IPacoteTuristicoRepository _pacoteTuristicoRepository;
        public CadastroPacoteTuristicoServices(IPacoteTuristicoRepository pacoteTuristicoRepository) 
        {
            this._pacoteTuristicoRepository = pacoteTuristicoRepository;
        }
        public PacoteTuristico BuscarPorId(int idPacoteTuristico)
        {
            return _pacoteTuristicoRepository.GetById(idPacoteTuristico);
        }

        public int CriarPacoteTuristico(PacoteTuristico pacoteTuristico)
        {
            return _pacoteTuristicoRepository.Create(pacoteTuristico);
        }

        public void EditarPacoteTuristico(PacoteTuristico pacoteTuristico)
        {
            _pacoteTuristicoRepository.Update(pacoteTuristico);
        }

        public void ExcluirPacoteTuristico(int idPacoteTuristico)
        {
            _pacoteTuristicoRepository.Delete(idPacoteTuristico);
        }

        public List<PacoteTuristico> ListarTodos()
        {
            List<PacoteTuristico> pacoteTuristicos = _pacoteTuristicoRepository.GetAll();
            return pacoteTuristicos;
        }
    }
}
