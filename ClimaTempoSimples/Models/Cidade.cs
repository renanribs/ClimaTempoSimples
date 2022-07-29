

namespace ClimaTempoSimples.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cidade
    {

        public Cidade()
        {
            this.PrevisaoClima = new HashSet<PrevisaoClima>();
        }
    
        public int Id { get; set; }
        public string Nome { get; set; }
        public int EstadoId { get; set; }
    
        public virtual Estado Estado { get; set; }
        public virtual ICollection<PrevisaoClima> PrevisaoClima { get; set; }
    }
}
