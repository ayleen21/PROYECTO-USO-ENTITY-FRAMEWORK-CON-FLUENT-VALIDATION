using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_EF.DTOS
{
    public class MatriculaDTO
    {
        public int Id { get; set; }
        public string NumeroV { get; set; }
        public DateTime? FechaExpedicion { get; set; }
        public DateTime? ValidoHasta { get; set; }
        public bool? Activo { get; set; }
    }
}
