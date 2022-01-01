namespace inspectorApi.Models
{
    public class ServiceResponse<T>
    {
        public T Data { get; set; }
        public bool Succsess { get; set; } = true;
        public string Message { get; set; } = null;
    }
}