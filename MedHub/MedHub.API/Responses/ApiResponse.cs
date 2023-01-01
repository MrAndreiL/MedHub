namespace MedHub.API.Responses
{
    public class ApiResponse<T>
    {
        public bool IsSuccess { get; private set; }
        public string Message { get; private set; }
        public T Result { get; private set; }

        public static ApiResponse<T> Success(T result)
        {
            return new ApiResponse<T>
            {
                IsSuccess = true,
                Result = result
            };
        }

        public static ApiResponse<T> Failure(string message)
        {
            return new ApiResponse<T>
            {
                IsSuccess = false,
                Message = message
            };
        }
    }
}
