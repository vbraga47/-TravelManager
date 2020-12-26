
using System;

namespace TravelManager.Models
{
    public class PacoteTuristico
    {


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

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Origem { get; private set; }
        public string Destino { get; private set; }
        public string Atrativos { get; private set; }
        public DateTime Saida { get; private set; } 
        public DateTime Retorno { get; private set; } 
        public int CodUsuarioCriacao { get; private set; }


        public void Editar(string nome, string origem, string destino, string atrativos, DateTime saida, DateTime retorno, int codUsuarioCriacao)
        {
            this.Nome = nome;
            this.Origem = origem;
            this.Destino = destino;
            this.Atrativos = atrativos;
            this.Saida = saida;
            this.Retorno = retorno;
            this.CodUsuarioCriacao = codUsuarioCriacao;
        }
    }
}
