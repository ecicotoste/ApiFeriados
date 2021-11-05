using System;
using System.Collections.Generic;
using System.Globalization;
using feriados.Models;


namespace feriados.Models
{
    public class Feriados
    {
        public List<Feriado> _feriados = new List<Feriado>();
        int Ano;

        /// <summary>
        /// INICIALIZA A CLASSE FERIADOS COM O ANO CORRENTE
        /// </summary>
        public Feriados()
        {
            Ano = DateTime.Now.Year;
            GeraListaFeriados(Ano);
        }

        /// <summary>
        /// INICIALIZA A CLASSE FERIADOS COM O ANO DADO
        /// </summary>
        public Feriados(int Ano)
        {
            GeraListaFeriados(Ano);
        }

        public Feriados(int Ano, CultureInfo cultureInfo)
        {
            if (cultureInfo.Name.Equals("en-US"))
            {
                GeraListaFeriadosFormatoUs(Ano);
            }
            else
            {
                GeraListaFeriados(Ano);
            }
        }

        public void GeraListaFeriados(int ano)
        {
            FeriadosMoveis fm = new FeriadosMoveis(ano);

            //ADICIONE AQUI OS FERIADOS PARA SUA CIDADE OU ESTADO SE NECESSÁRIO

            _feriados.Add(new Feriado(fm.DiaPascoa, "Domingo de Páscoa"));
            _feriados.Add(new Feriado(DateTime.Parse("01/01/" + ano), "Confraternização Universal"));
            _feriados.Add(new Feriado(DateTime.Parse("25/01/" + ano), "Aniversario de Sao Paulo City"));
            _feriados.Add(new Feriado(fm.SegundaCarnaval, "Segunda Carnaval"));
            _feriados.Add(new Feriado(fm.TercaCarnaval, "Terça Carnaval"));
            _feriados.Add(new Feriado(fm.SextaPaixao, "Sexta feira da paixão"));
            _feriados.Add(new Feriado(DateTime.Parse("21/04/" + ano), "Tiradentes"));
            _feriados.Add(new Feriado(DateTime.Parse("01/05/" + ano), "Dia do trabalho"));
            _feriados.Add(new Feriado(fm.CorpusChristi, "Corpus Christi"));
            _feriados.Add(new Feriado(DateTime.Parse("09/07/" + ano), "Revolução Constitucionalista"));
            _feriados.Add(new Feriado(DateTime.Parse("07/09/" + ano), "Independência do Brasil"));
            _feriados.Add(new Feriado(DateTime.Parse("12/10/" + ano), "Padroeira do Brasil"));
            _feriados.Add(new Feriado(DateTime.Parse("02/11/" + ano), "Finados"));
            _feriados.Add(new Feriado(DateTime.Parse("15/11/" + ano), "Proclamação da República"));
            _feriados.Add(new Feriado(DateTime.Parse("20/11/" + ano), "Consciência Negra"));
            _feriados.Add(new Feriado(DateTime.Parse("25/12/" + ano), "Natal"));
            _feriados.Add(new Feriado(fm.RecessoBancario, "Recesso Bancario - CIP " + ano));
        }

        public void GeraListaFeriadosFormatoUs(int ano)
        {
            FeriadosMoveis fm = new FeriadosMoveis(ano);

            //ADICIONE AQUI OS FERIADOS PARA SUA CIDADE OU ESTADO SE NECESSÁRIO

            _feriados.Add(new Feriado(fm.DiaPascoa, "Domingo de Páscoa"));
            _feriados.Add(new Feriado(DateTime.Parse($"{ano}-01-01"), "Confraternização Universal"));
            _feriados.Add(new Feriado(DateTime.Parse($"{ano}-01-25"), "Aniversario de Sao Paulo City"));
            _feriados.Add(new Feriado(fm.SegundaCarnaval, "Segunda Carnaval"));
            _feriados.Add(new Feriado(fm.TercaCarnaval, "Terça Carnaval"));
            _feriados.Add(new Feriado(fm.SextaPaixao, "Sexta feira da paixão"));
            _feriados.Add(new Feriado(DateTime.Parse($"{ano}-04-21"), "Tiradentes"));
            _feriados.Add(new Feriado(DateTime.Parse($"{ano}-05-01"), "Dia do trabalho"));
            _feriados.Add(new Feriado(fm.CorpusChristi, "Corpus Christi"));
            _feriados.Add(new Feriado(DateTime.Parse($"{ano}-07-09"), "Revolução Constitucionalista"));
            _feriados.Add(new Feriado(DateTime.Parse($"{ano}-09-07"), "Independência do Brasil"));
            _feriados.Add(new Feriado(DateTime.Parse($"{ano}-10-12"), "Padroeira do Brasil"));
            _feriados.Add(new Feriado(DateTime.Parse($"{ano}-11-02"), "Finados"));
            _feriados.Add(new Feriado(DateTime.Parse($"{ano}-11-15"), "Proclamação da República"));
            _feriados.Add(new Feriado(DateTime.Parse($"{ano}-11-20"), "Consciência Negra"));
            _feriados.Add(new Feriado(DateTime.Parse($"{ano}-12-25"), "Natal"));
            _feriados.Add(new Feriado(fm.RecessoBancario, "Recesso Bancario - CIP " + ano));
        }

        public bool IsDiaUtil(DateTime data)
        {
            if (IsFimDeSemana(data) || IsFeriado(data))
                return false;
            else
                return true;
        }

        public bool IsFeriado(DateTime data)
        {
            return _feriados.Find(delegate (Feriado f1) { return f1.data == data; }) != null ? true : false;
        }

        public bool IsFimDeSemana(DateTime data)
        {
            if (data.DayOfWeek == DayOfWeek.Sunday || data.DayOfWeek == DayOfWeek.Saturday)
                return true;
            else
                return false;
        }

        public DateTime ProximoDiaUtil(DateTime data)
        {
            DateTime auxData = data;

            while (true)
            {
                if (IsFeriado(auxData) || IsFimDeSemana(auxData))
                {
                    auxData = auxData.AddDays(1);
                    GeraListaFeriados(auxData.Year);
                }
                else
                    break;

            }


            return auxData;
        }
    }
}