using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AfgangTilgangApi.Models
{
    public class AfgangTilgang
    {
        [Key]
        public int ID { get; set; }
        public string? Sogn { get; set; }
        public int? SogneNo { get; set; }
        public string? Billedfil { get; set; }
        public string? Folieside { get; set; }

        public string? Liste { get; set; }

        public int? Aar { get; set; }
        public int? No { get; set; }
        public int? Familieno { get; set; }
        public string? Fornavn { get; set; }
        public string? Efternavn { get; set; }
        public string? Sleagtsnavn { get; set; }
        public int? Alder { get; set; }

        public int? Fodeaar { get; set; }

        public string? Haandtering { get; set; }
        public string? Hvorhenrejst { get; set; }
        public string? Hvorfraankommet { get; set; }
        public string? HvoriJeavnfReg { get; set; }
        public string? Anmearkning { get; set; }
       

       
        public AfgangTilgang()
        {

        }
    }
}
