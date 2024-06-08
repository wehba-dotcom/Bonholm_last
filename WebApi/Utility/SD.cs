namespace WebApi.Utility
{
    public class SD
    {
       
        public static string AuthAPIBase { get; set; }
        public static string FeallesAPIBase { get; set; }
        public static string AfgangTilgangAPIBase { get; set; }
        public static string AllsandAPIBase { get; set; }
        public static string GateWayIBase {  get; set; }

        public static string DatoAPIBase { get; set; }
        public static string ArrestAPIBase { get; set; }
        public static string BegravAPIBase { get; set; }
        public static string BorgerAPIBase { get; set; }
        public static string BornAPIBase { get; set; }
        public static string ChristianAPIBase { get; set; }
        public static string FotoAPIBase { get; set; }

        public const string RoleAdmin = "ADMIN";
        public const string RoleCustomer = "CUSTOMER";
        public const string TokenCookie = "JWTToken";
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }

        public const string Status_Pending = "Pending";
        public const string Status_Approved = "Approved";
        public const string Status_ReadyForPickup = "ReadyForPickup";
        public const string Status_Completed = "Completed";
        public const string Status_Refunded = "Refunded";
        public const string Status_Cancelled = "Cancelled";

        public enum ContentType
        {
            Json,
            MultipartFormData,
        }
    }
}
