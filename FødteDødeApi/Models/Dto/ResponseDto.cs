namespace FødteDødeApi.Models.Dto
{
    public class ResponseDto
    {
        public string Message { get; set; } = "";
        public bool IsSuccess { get; set; } = true;
        public Object? Result { get; set; }
    }
}
