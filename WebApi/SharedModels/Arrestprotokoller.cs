using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebApi.SharedModels
{
    public class Arrestprotokoller
    {
        [Key]
        public int ID { get; set; }
        public string? ProtokolSideFolie { get; set; }

        public string? Protokolid { get; set; }
        public string? ProtokolFotoside1 { get; set; }
        public string? ProtokolFotoside2 { get; set; }
        public string? FangeLbnr { get; set; }
        public string? VisitaionArbejdsProtokolNr { get; set; }
        public string? Fornavn { get; set; }
        public string? Efternavn { get; set; }
        public string? Slægtsnavn { get; set; }
        public string? Opholdssted { get; set; }
        public string? Stilling { get; set; }

        public int? Alder { get; set; }

        public string? Fødested { get; set; }
        public string? Fødedato { get; set; }
        public string? Signalement { get; set; }
        public string? ProtokolDato { get; set; }
        public string? UnderHvisJustits { get; set; }
        public string? Årsag { get; set; }

        public string? SagensUdfald { get; set; }

        public string? Domsdato { get; set; }

        public string? Anmærkninger { get; set; }
       
        public string? Bemærkninger { get; set; }
        public string? HenvisningsfolieProtolkol { get; set; }
      

    }
}
