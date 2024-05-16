using System.ComponentModel.DataAnnotations;

namespace AllsandApi.Models
{
    public class Allsand
    {
        [Key]
        public int ID { get; set; }
        public int? Nr { get; set; }
        public string? Efternavn { get; set; }
        public string? Fornavn { get; set; }
        public string? Erhverv { get; set; }
        public string? Sted { get; set; }
        public string? Borgerskab { get; set; }
        public string? Klasse { get; set; }
        public string ? Tingsbogshenvisning { get; set; }

    }
}
