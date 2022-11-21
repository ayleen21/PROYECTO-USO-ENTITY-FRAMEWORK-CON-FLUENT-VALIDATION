using System;
using System.Collections.Generic;

namespace API_EF.Entities
{
    public partial class Matricula
    {
        public Matricula()
        {
            Conductor = new HashSet<Conductor>();
        }

        public int Id { get; set; }
        public string NumeroV { get; set; }
        public DateTime? FechaExpedicion { get; set; }
        public DateTime? ValidoHasta { get; set; }
        public bool? Activo { get; set; }

        public virtual ICollection<Conductor> Conductor { get; set; }
    }
}
