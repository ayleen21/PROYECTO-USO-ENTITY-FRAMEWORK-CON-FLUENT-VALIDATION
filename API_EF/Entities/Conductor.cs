using System;
using System.Collections.Generic;

namespace API_EF.Entities
{
    public partial class Conductor
    {
        public Conductor()
        {
            Sanciones = new HashSet<Sanciones>();
        }

        public int Id { get; set; }
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public bool? Activo { get; set; }
        public int? IdMatricula { get; set; }

        public virtual Matricula IdMatriculaNavigation { get; set; }
        public virtual ICollection<Sanciones> Sanciones { get; set; }
    }
}
