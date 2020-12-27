
using System;
using System.Collections.Generic;

namespace TravelManager.Models
{
    public class PacoteTuristico
    {
        public PacoteTuristico()
        {
        }

        public PacoteTuristico(string nome, string origem, string destino, string atrativos, DateTime saida, DateTime retorno, int codUsuarioCriacao)
        {
            this.Nome = nome;
            this.Origem = origem;
            this.Destino = destino;
            this.Atrativos = atrativos;
            this.Saida = saida;
            this.Retorno = retorno;
            this.CodUsuarioCriacao = codUsuarioCriacao;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
        public string Atrativos { get; set; }
        public DateTime Saida { get; set; } 
        public DateTime Retorno { get; set; } 
        public int CodUsuarioCriacao { get; set; }

    }
    public class ListPacotesTuristico
    {
        public ListPacotesTuristico()
        {
            PacotesTuristicos = new List<PacoteTuristico>();
        }
        public List<PacoteTuristico> PacotesTuristicos { get; set; } 

    }
}
