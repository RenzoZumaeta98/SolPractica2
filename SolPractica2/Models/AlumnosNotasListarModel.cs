using System.Collections.Generic;

namespace SolPractica2.Models
{

    public class AlumnosNotasListViewModel
    {
        public List<AlumnosNotasListarModel> List { get; set; }

        public AlumnosNotasListViewModel()
        {
            List = new List<AlumnosNotasListarModel>();
        }
    }
    public class AlumnosNotasListarModel
    {
        public int cod { get; set; }
        public string name { get; set; }
        public string apellido { get; set; }
        public string dni { get; set; }
        public string fechaNacimiento { get; set; }

        public string notas { get; set; }
    }
}
