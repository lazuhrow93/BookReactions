namespace Chronical.App.Models.OutgoingDto
{
    public class ChronicleResponse<T>
    {
        public bool Success { get; set; }
        public string[]? Error { get; set; }
        public T? Data { get; set; }
    }
}
