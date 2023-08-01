namespace Maia.Maps.Domain.DTO
{
	public class Result
	{
		public Result()
		{
		}

		public Result(bool isValid, string? message = null)
		{
			IsValid = isValid;
			Message = message;
		}

		public bool IsValid { get; set; }
		public string? Message { get; set; }
	}

    public class Result<T> : Result
    {
        public Result()
        {
        }

        public Result(bool isValid, T data, string? message = null) : base(isValid, message)
        {
            Data = data;
        }

        public T? Data { get; set; }
    }
}
