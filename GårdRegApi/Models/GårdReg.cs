using System.ComponentModel.DataAnnotations;

namespace GårdRegApi.Models
{
    public class GårdReg
    {
        [Key]
        public int ID { get; set; }
        public int Ejernr { get; set; }
        public short Gårdnummer { get; set; }
        public string? Overtagelsesår { get; set; }
        public string? Kilde { get; set; }
       
        public string? Fornavne { get; set; }
        public string? Efternavn { get; set; }
        public string? Efternavn_kort { get; set; }
        public string? Slægtsnavn { get; set; }
        public string? SE_navn { get; set; }
        public string? Født { get; set; }
        public string? Fødesogn { get; set; }
        public string? Gift { get; set; }
        public string? Giftesogn { get; set;}
        public string? Død { get; set; }
        public string? Begravetsogn { get; set; }
        public string? HansForældre { get; set; }
        public string? ÆgtefællesFornavne { get; set; }
        public string? ÆgtefællesEfternavn { get; set; }
        public string? Æ_Efternavn_kort { get; set; }
        public string? Æ_Slægtsnavn { get; set; }
        public string? SÆ_Navn { get; set; }
        public string? HendesFødeår { get; set; }
        public string? HendesFødesogn { get; set; }
        public string? HendesDødsår { get; set; }
        public string? HendesBegravelsesogn { get; set; }
        public string? Hendesforældre { get; set; }
        public string? ØvrigeOplysninger { get; set; }
        public string? Kommentarer { get; set; }
        public string? Gårdnavnveddenneejer { get; set; }
     
    }
}
