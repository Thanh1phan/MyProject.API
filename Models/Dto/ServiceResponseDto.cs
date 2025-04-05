namespace MyProject.API.Models.Dto
{
    public class ServiceResponseDto <T> where T : class
    {
        public bool Iscucess { get; set; } = true;
        public string Message { get; set; }
        public T Result { get; set; }
    }
}
