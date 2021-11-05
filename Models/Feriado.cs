using System;

namespace feriados.Models
{
    public class Feriado
    {
        public  DateTime data {get;set;}
        public   string descricao {get;set;}

         public Feriado(DateTime DataFeriado, string Descricao)
        {
            this.data = DataFeriado;
            this.descricao = Descricao;
        }
    }
}