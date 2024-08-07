﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebApi.SharedModels
{
    public class Begrav
    {
        [Key]
        public int ID { get; set; }
        public string? Protokol { get; set; }

        public string? ProtokolNr { get; set; }
        public string? Side { get; set; }
        public string? Fornavn { get; set; }
        public string? Efternavn { get; set; }
        public string? Fødenavn { get; set; }
        public string? Stilling { get; set; }
        public string? Adresse { get; set; }
       
        public string? SognBy { get; set; }
        public string? Født { get; set; }
        public string? Død { get; set; }

        public string? Begravet { get; set; }

        public string? Pasning { get; set; }
        public string? Adresse2 { get; set; }
        public string? Sogn { get; set; }
        public string? Sletning { get; set; }
        public string? Anmærkning { get; set; }
  

       
      

    }
}
