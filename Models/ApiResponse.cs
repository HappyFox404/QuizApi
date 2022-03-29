namespace QuizApi.Models
{
    public class ApiResponse
    {
        public int Status { get; set; }
        public string? Message { get; set; }
        public object? Data { get; set; }

        public static ApiResponse ResponseOk(object? data = null, string message = "OK")
        {
            return new ApiResponse() { Status = 200, Data = data, Message = message };
        }

        public static ApiResponse ResponseServerError(string message)
        {
            return new ApiResponse() { Status = 500, Message = message };
        }

        public static ApiResponse ResponseClientError(string message)
        {
            return new ApiResponse() { Status = 400, Message = message };
        }
    }
}