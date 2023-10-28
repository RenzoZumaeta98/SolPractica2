using SolPractica2.DataAccess.Entities.Abstraccions;
using System.Net;

namespace SolPractica2.DataAccess.Entities
{
    public class Notas: BaseEntity
    {
        public int nota { get; set; }

        public virtual Alumnos alumno { get; set; }




    }
}
