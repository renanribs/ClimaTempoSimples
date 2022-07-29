using ClimaTempoSimples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClimaTempoSimples.Context
{
    public class CidadesContext
    {
        private ClimaTempoSimplesEntities db = new ClimaTempoSimplesEntities();

        public List<Cidade> ObtenhaCidades()
        {
            try
            {
                return db.Cidade.ToList();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}