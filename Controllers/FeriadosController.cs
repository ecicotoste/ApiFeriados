using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using feriados.Models;

namespace feriados.Controllers
{
    [ApiController]
    [Route("feriados")]
    public class FeriadosController : ControllerBase
    {
        [HttpGet]
        [Route("sp")]
        public List<Feriado> GetSP()
        {
            int ano = DateTime.Now.Year;
            var listFeriados = new List<Feriado>();
            for(int i = 0; i < 2; i++)
            {
                ano = ano + i;
                var feriados = new Feriados(ano);
                foreach (Feriado feriado in feriados._feriados)
                {
                    listFeriados.Add(feriado);
                }
            }   
            
            return listFeriados;
        }

        [HttpGet]
        [Route("sp/{ano:int}")]
        public  List<Feriado> GetSPAno(int ano)
        {
            var feriados = new Feriados(ano);
            return feriados._feriados;
        }

        [HttpGet]
        [Route("sp/diautil/{anomesdia:int}")]
        public  bool GetSPIsDiaUtil(int anomesdia)
        {
            var str_data = anomesdia.ToString();
            var ano = str_data.Substring(0,4);
            var mes = str_data.Substring(4,2);
            var dia = str_data.Substring(6,2);
            var feriados = new Feriados(Convert.ToInt16(ano));
            var data_pesquisa = new DateTime(Convert.ToInt16(ano), Convert.ToInt16(mes), Convert.ToInt16(dia));
            return feriados.IsDiaUtil(data_pesquisa);
        }

        [HttpGet]
        [Route("sp/proxdiautil/{anomesdia:int}")]
        public string GetSPProxDiaUtil(int anomesdia)
        {
            var str_data = anomesdia.ToString();
            var ano = str_data.Substring(0,4);
            var mes = str_data.Substring(4,2);
            var dia = str_data.Substring(6,2);
            var feriados = new Feriados(Convert.ToInt16(ano));
            var data_pesquisa = new DateTime(Convert.ToInt16(ano), Convert.ToInt16(mes), Convert.ToInt16(dia));
            data_pesquisa = data_pesquisa.AddDays(1);
            while (!feriados.IsDiaUtil(data_pesquisa))
            {
                data_pesquisa = data_pesquisa.AddDays(1);
            }
            return data_pesquisa.ToString("yyyyMMdd");
        }

        [HttpGet]
        [Route("nacional")]
        public List<Feriado> GetNac()
        {
            int ano = DateTime.Now.Year;
            var listFeriados = new List<Feriado>();
            for(int i = 0; i < 2; i++)
            {
                ano = ano + i;
                var feriados = new Feriados(ano);
                feriados._feriados.RemoveAll(r => r.descricao == "Aniversario de Sao Paulo City" || r.descricao == "Revolução Constitucionalista" || r.descricao == "Consciência Negra");
                foreach (Feriado feriado in feriados._feriados)
                {
                    listFeriados.Add(feriado);
                }
            }   
            
            return listFeriados;
        }

        [HttpGet]
        [Route("nacional/{ano:int}")]
        public List<Feriado> GetNacAno(int ano)
        {
            var feriados = new Feriados(ano);
            feriados._feriados.RemoveAll(r => r.descricao == "Aniversario de Sao Paulo City" || r.descricao == "Revolução Constitucionalista" || r.descricao == "Consciência Negra");
            return feriados._feriados;
        }
        [HttpGet]
        [Route("nacional/diautil/{anomesdia:int}")]
        public bool GetNacIsDiaUtil(int anomesdia)
        {
            var str_data = anomesdia.ToString();
            var ano = str_data.Substring(0,4);
            var mes = str_data.Substring(4,2);
            var dia = str_data.Substring(6,2);
            var feriados = new Feriados(Convert.ToInt16(ano));
            feriados._feriados.RemoveAll(r => r.descricao == "Aniversario de Sao Paulo City" || r.descricao == "Revolução Constitucionalista" || r.descricao == "Consciência Negra");
            var data_pesquisa = new DateTime(Convert.ToInt16(ano), Convert.ToInt16(mes), Convert.ToInt16(dia));
            return feriados.IsDiaUtil(data_pesquisa);
        }

        [HttpGet]
        [Route("nacional/proxdiautil/{anomesdia:int}")]
        public string GetNacProxDiaUtil(int anomesdia)
        {
            var str_data = anomesdia.ToString();
            var ano = str_data.Substring(0,4);
            var mes = str_data.Substring(4,2);
            var dia = str_data.Substring(6,2);
            var feriados = new Feriados(Convert.ToInt16(ano));
            feriados._feriados.RemoveAll(r => r.descricao == "Aniversario de Sao Paulo City" || r.descricao == "Revolução Constitucionalista" || r.descricao == "Consciência Negra");
            var data_pesquisa = new DateTime(Convert.ToInt16(ano), Convert.ToInt16(mes), Convert.ToInt16(dia));
            data_pesquisa = data_pesquisa.AddDays(1);
            while (!feriados.IsDiaUtil(data_pesquisa))
            {
                data_pesquisa = data_pesquisa.AddDays(1);
            }
            return data_pesquisa.ToString("yyyyMMdd");
        }
    }
}