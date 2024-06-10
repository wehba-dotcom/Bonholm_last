using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FT1845Api.Models.Dto
{
    public class FTDto
    {
        [Key]
        
        public int ID { get; set; }
        public string? Efternavn { get; set; }
        public string? Fornavne { get; set; }
        public string? Fødested { get; set; }
        public string? Alder { get; set; }
        public string? GiftUgift { get; set; }
        public string? Stilling { get; set; }
        public string? Amt { get; set; }
        public string? SognAdresse { get; set; }
        public string? Løbenr { get; set; }

        public string? IndtastNr { get; set; }

        public string? Bemærkninger { get; set; }




    }
}
