using ClimaTempoSimples.Context;
using ClimaTempoSimples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClimaTempoSimples.Controllers
{
    public class HomeController : Controller
    {
        TempoContext contextTempo = new TempoContext();
        CidadesContext contextCidade = new CidadesContext();
        public ActionResult Index()
        {
            try
            {
                Previsao previsao = new Previsao();

                previsao.CidadesMaisQuentes = contextTempo.ObtenhaCidadesMaisQuentes();
                previsao.CidadesMaisFrias = contextTempo.ObtenhaCidadesMaisFrias();
                previsao.Cidades = contextCidade.ObtenhaCidades();
                return View(previsao);
            }
            catch (Exception ex)
            {
                throw (ex);
            }


        }

        public ActionResult ObterClimaSemana(Cidade cidade)
        {
            try
            {
                contextTempo.ObterClimaSemana(cidade);
                ViewBag.NomeCidade = cidade.Nome;

                return View(cidade.PrevisaoClima);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public ActionResult About()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                throw (ex);
            }


        }
    }
}