using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FotoApi.Models.Dto
{
    public class FotoDto
    {
        [Key]
        public int ID { get; set; }
        public string? Fornavn { get; set; }
        public string? Efternavn { get; set; }
        public string? Stilling { get; set; }

        public string? Adr { get; set; }

        public string? Sogn { get; set; }
        public string? Dato { get; set; }
        public int? Gange { get; set; }
        public string? Billedetype { get; set; }
        public int? BilledeNr { get; set; }

        public string? Fotoår { get; set; }
        public string? Fotograf { get; set; }

        public string? FotografsNr { get; set; }

        public int? CdNr { get; set; }
        public string? Noter { get; set; }
        public string? Bemærkning { get; set; }
        public Byte[] Billede { get; set; }

    }
}
