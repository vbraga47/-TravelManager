using System;
using System.Collections.Generic;

namespace TravelManager.Models
{
    public class Usuario
    { 
        //Usado pelo Dapper para bindar as consultas
        public Usuario() { }

        public Usuario(string nomeCompleto, DateTime dataNascimento, string login, string senha, TipoUsuario tipo) 
        {
            this.NomeCompleto = nomeCompleto;
            this.DataNascimento = dataNascimento;
            this.Login = login;
            this.Senha = senha;
            this.Tipo = tipo;
        }

        public int Id { get;  set;  }
        public string NomeCompleto { get;  set; }
        public DateTime DataNascimento { get;  set; }
        public string Login { get;  set; }
        public string Senha { get;  set; }
        public TipoUsuario Tipo { get;  set; }

    }

    public class ListUsuarios
    {
        public ListUsuarios()
        {
            Usuarios = new List<Usuario>();
        }

        public List<Usuario> Usuarios { get; set; }
    }
}
