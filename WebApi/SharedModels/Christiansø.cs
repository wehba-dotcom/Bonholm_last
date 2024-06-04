using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebApi.SharedModels
{
    public class Christiansø
    {
        [Key]
        public int ID { get; set; }
        public string? KildeBog { get; set; }

        public string? Side { get; set; }
      
        public string? AnkomstAfrejse { get; set; }
        public string? Kompani { get; set; }
        public string? Aar { get; set; }
        public string? Nr { get; set; }
        public string? Titel { get; set; }
        public string? Fornavn { get; set; }
        public string? Efternavn { get; set; }
        public string? Slægtsnavn { get; set; }
        public string? Fødested { get; set; }

        public string? FødtDato { get; set; }

        public string? FødtÅr { get; set; }
        public string? Alder { get; set; }
        public string? KomFra { get; set; }
        public string? Distrikt { get; set; }
        public string? Amt { get; set; }
        public string? By { get; set; }

        public string? LægdNr { get; set; }

        public string? PatentNr { get; set; }

        public string? LøbeNr { get; set; }
     
        public string? ExtraTjPåØen { get; set; }
        public string? TjenesteFra1852 { get; set; }

        public string? TjenesteTid { get; set; }

        public string? Premierløjtnant { get; set; }
        public string? SøLøjtnantSøOfficer { get; set; }

        public string? Tømmermand { get; set; }
        public string? Lodsmatros { get; set; }

        public string? LodsQvartersmester { get; set; }

        public string? Soldat { get; set; }
        public string? Konstabel { get; set; }

        public string? UnderKanoner { get; set; }
        public string? Arbejdsmand { get; set; }

        public string? Gift { get; set; }
        public string? Børn { get; set; }

        public string? Anmærkning { get; set; }


    }
}
