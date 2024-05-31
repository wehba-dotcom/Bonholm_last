using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BørnRøApi.Models.Dto
{
    public class BørnDto
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
