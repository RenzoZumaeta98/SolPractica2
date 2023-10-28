using SolPractica2.DataAccess.Entities.Abstraccions;

namespace SolPractica2.DataAccess.Entities
{
    public class Alumnos: BaseEntity
    {
        
        public string apellido { get; set; }
        public string dni { get; set; }
        public string fechaNacimiento { get; set; }
    }
}
