using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebApi.SharedModels
{
    public class Børn
    {
        [Key]
        public int ID { get; set; }
        public int? LbNr { get; set; }
        public string? Fornavn { get; set; }
        public string? Efternavn { get; set; }
        public string? Titel { get; set; }
        public int? AntalBørn { get; set; }
        public string? Div { get; set; }
       
      

    }
}
