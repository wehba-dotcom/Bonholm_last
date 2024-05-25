using System.ComponentModel.DataAnnotations;

namespace WebApi.SharedModels
{
    public class Dato1822
    {
        [Key]
        public int ID { get; set; }
        public string? Nr { get; set; }
        public string? Sogn { get; set; }
        public string? År { get; set; }
        public string? Ophold { get; set; }
        public string? Fornavn { get; set; }
        public string? Efternavn { get; set; }
       
        public string? Stilling { get; set; }
        public string? Alder { get; set; }

        public string? Bemærkninger { get; set; }
        
       

    }
}
