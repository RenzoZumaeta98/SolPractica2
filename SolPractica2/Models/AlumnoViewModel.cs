using System.Collections.Generic;

namespace SolPractica2.Models
{
    public class AlumnoViewModel
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string DNI { get; set; }
        public string FechaNacimiento { get; set; }


        public List<NotasTemporalViewModel> TemporalNotas { get; set; }
        public AlumnoViewModel()
        {
            TemporalNotas = new List<NotasTemporalViewModel>();
        }
    }
}
