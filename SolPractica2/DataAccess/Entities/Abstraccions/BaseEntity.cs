using System.ComponentModel.DataAnnotations;

namespace SolPractica2.DataAccess.Entities.Abstraccions
{
    public class BaseEntity
    {
        [Key]
        public int cod { get; set; }
        public string name { get; set; }
    }
}
