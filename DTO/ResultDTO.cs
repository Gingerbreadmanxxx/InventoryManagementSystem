

namespace DTO
{
    public class ResultDTO
    {
        public bool IsSuccess { get; set; }
        public bool IsListResult { get; set; }
        public string Message { get; set; }
        public object Result { get; set; }
    }
}
