using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelManager.Models
{
    public class Usuario
    { 

        public Usuario(string nomeCompleto, DateTime dataNascimento, string login, string senha, string tipo) 
        {
            this.NomeCompleto = nomeCompleto;
            this.DataNascimento = dataNascimento;
            this.Login = login;
            this.Senha = senha;
            this.Tipo = tipo;
        }

        public int Id { get; private set;  }
        public string NomeCompleto { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Login { get; private set; }
        public string Senha { get; private set; }
        public string Tipo { get; private set; }

        public void Editar(string nomeCompleto, DateTime dataNascimento, string login, string senha, string tipo)
        {
            this.NomeCompleto = nomeCompleto;
            this.DataNascimento = dataNascimento;
            this.Login = login;
            this.Senha = senha;
            this.Tipo = tipo;
        }
    }
}
