namespace FødteDødeApi.Models
{
    public class FødteDøde
    {
        public int ID { get; set; }
        public string fornavne { get; set; }
        public string Efternavn { get; set; }
        public string Slægtsnavn { get; set; }
        public string Født { get; set; }
        public string Fødesogn { get; set; }
        public string Død { get; set; }
        public string Dødssted { get; set; }
        public string BegravetBisat { get; set; }
        public string Begravelsesogn { get; set; }
        public string Bemærkninger1 { get; set; }
        public string Bemærkninger2 { get; set; }
        public string Kildehenvisninger { get; set;}
    }
}
