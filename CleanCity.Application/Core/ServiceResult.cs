namespace CleanCity.Application.Core
{
    public class ServiceResult
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;

        public static ServiceResult Ok(string message = "Operacion exitosa")
            => new ServiceResult { Success = true, Message = message };

        public static ServiceResult Fail(string message)
            => new ServiceResult { Success = false, Message = message };
    }
}