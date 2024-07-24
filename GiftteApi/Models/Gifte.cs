namespace GifteApi.Models
{
    public class Gifte
    {
        public int ID { get; set; }
        public string? Sogn { get; set; }
        public string? SognNr { get; set; }
        public int? Aar { get; set; }
        public string bog { get; set; }
        public string? Folieside { get; set; }
        public int? LbNr { get; set; }
        public string? G_Status { get; set; }
        public string? G_fornavn { get; set; }
        public string? G_efternavn { get; set; }
        public string? G_slægtsnavn { get; set; }
        public string? G_alder { get; set; }
        public int? G_fødeaar { get; set;}
        public string? G_fødesogn { get; set; }
        public string? G_haandtering { get; set; }
        public string? G_bopæl { get; set; }
        public string? B_status { get; set; }
        public string? B_fornavn { get; set; }
        public string? B_efternavn { get; set; }
        public string? B_slægtsnavn { get; set; }
        public string? B_alder { get; set; }
        public int? B_fødeår { get; set; }
        public string? B_fødesogn { get; set; }
        public string? B_haandtering { get; set; }
        public string? B_bopæl { get; set; }
        public string? Giftedag { get; set; }
        public string? Forlover { get; set; }
        public string? Bemærkninger { get; set; }
     
    }
}
