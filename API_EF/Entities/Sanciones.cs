using System;
using System.Collections.Generic;

namespace API_EF.Entities
{
    public partial class Sanciones
    {
        public int Id { get; set; }
        public DateTime? FechaActual { get; set; }
        public int? IdConductor { get; set; }
        public string Sancion { get; set; }
        public string Observacion { get; set; }
        public decimal? Valor { get; set; }

        public virtual Conductor IdConductorNavigation { get; set; }
    }
}
