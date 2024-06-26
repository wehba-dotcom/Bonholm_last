using System.ComponentModel.DataAnnotations;

namespace FæsteProtokollerBog.Models
{
    public class FPBog
    {
        [Key]
        public int ID { get; set; }
        public int Indskrivningsnr { get; set; }
        public string? FaesterNavn { get; set; }
        public string? Fornavn { get; set; }
        public string? Efternavn { get; set; }
        public string? FaesterTilnavn { get; set; }
        public string? ForrigeFaesterNavn { get; set; }
        public string? ForrigeFaesterFornavn { get; set; }
        public string? ForrigeFaesterEfternavn { get; set; }
        public string? ForrigeFaesterTilnavnmm { get; set; }
        public string? Kommentarer { get; set; }
        public string? Gaard { get; set; }
        public string? Sogn { get; set; }
        public string? FaestebrevUdstedt { get; set; }
        public string? Side { get; set; }
        public int Bog { get; set; }
        public int Film { get; set; }
        public string? Herred { get; set; }

    }
}
