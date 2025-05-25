namespace training.Models.Error
{
    public class ErrorResponse
    {
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public int Status { get; set; }
        public string Error { get; set; }
        public string Message { get; set; }
        public string Path { get; set; }
        public Dictionary<string, string>? Errors { get; set; }

        public ErrorResponse(int status, string error, string message, string path)
        {
            Status = status; Error = error; Message = message; Path = path;
        }
    }
}
