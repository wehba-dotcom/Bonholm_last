using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebApi.SharedModels
{
    public class Borger
    {
        [Key]
        public int ID { get; set; }
        public int? Nr { get; set; }
        public string? Efternavn { get; set; }
        public string? Fornavn { get; set; }

        public string? Erhverv { get; set; }
        public string? KommerFra { get; set; }
       
       
        public string? Alder { get; set; }
        public string? Borgerskab { get; set; }
        public string? By { get; set; }
       
        public string? ProtokolNr { get; set; }
      
       
      

    }
}
