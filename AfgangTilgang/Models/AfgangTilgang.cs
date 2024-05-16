using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using NuGet.Packaging.Signing;
using Microsoft.EntityFrameworkCore;

namespace AfgangTilgangApi.Models
{
    public class AfgangTilgang
    {
        [Key]
        public int ID { get; set; }
        public string? Sogn { get; set; }
        public string? SogneNo { get; set; }
        public string? Billedfil { get; set; }
        public string? Folieside { get; set; }

        public string? Liste { get; set; }

        public string? Aar { get; set; }
        public Double? No { get; set; }
        public string? Familieno { get; set; }
        public string? Fornavn { get; set; }
        public string? Efternavn { get; set; }
        public string? Slægtsnavn { get; set; }
        public string? Alder { get; set; }

        public string? Fødeaar { get; set; }

        public string? Haandtering { get; set; }
        public string? Hvorhenrejst { get; set; }
        public string? Hvorfraankommet { get; set; }
        public string? HvoriJeavnfReg { get; set; }
        public string? Anmærkning { get; set; }
        


        public AfgangTilgang()
        {

        }
    }
}
