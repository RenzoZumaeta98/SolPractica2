using System.Collections.Generic;

namespace SolPractica2.Models
{
    public class NotasListViewModel
    {
        public List<NotasListarModel> List { get; set; }

        public NotasListViewModel()
        {
            List = new List<NotasListarModel>();
        }
    }

    public class NotasListarModel
    {
        public int cod { get; set; }
        public string name { get; set; }
        public int nota { get; set; }

    }
}
