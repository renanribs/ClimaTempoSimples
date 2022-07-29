using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClimaTempoSimples.Models;
using ClimaTempoSimples.Context;
using System.Data.Entity;

namespace ClimaTempoSimples.Context
{
    public class TempoContext
    {
        private ClimaTempoSimplesEntities db = new ClimaTempoSimplesEntities();

        public List<PrevisaoClima> ObtenhaCidadesMaisQuentes()
        {
            try
            {

                List<PrevisaoClima> climasMaisQuentes = db.PrevisaoClima.Include(x => x.Cidade)
                                    .Include(x => x.Cidade.Estado)
                                    .Where(x => x.DataPrevisao == DateTime.Today.Date)
                                    .OrderByDescending(x => x.TemperaturaMaxima)
                                    .Take(3)
                                    .ToList();



                return climasMaisQuentes;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public List<PrevisaoClima> ObtenhaCidadesMaisFrias()
        {
            try
            {
                List<PrevisaoClima> climasMaisFrios =
                   db.PrevisaoClima.Include(x => x.Cidade)
                                   .Include(x => x.Cidade.Estado)
                                   .Where(x => x.DataPrevisao == DateTime.Today.Date)
                                   .OrderBy(x => x.TemperaturaMinima)
                                   .Take(3)
                                   .ToList();
                return climasMaisFrios;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void ObterClimaSemana(Cidade cidade)
        {
            try
            {
                DateTime dataInicio = DateTime.Today.Date;
                DateTime dataFim = DateTime.Today.AddDays(6).Date;

                cidade.PrevisaoClima =
                    db.PrevisaoClima
                    .Where(x => x.DataPrevisao >= dataInicio
                    && x.DataPrevisao <= dataFim
                    && x.CidadeId == cidade.Id).ToList();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}