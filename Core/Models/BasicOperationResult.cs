using Core.Contracts;

namespace Core.Models
{
    public class BasicOperationResult<T> : IOperationResult<T>
    {
        private BasicOperationResult(string message, bool success, T entity)
        {
            Message = message;
            Success = success;
            Entity = entity;
        }

        public string Message { get; }

        public bool Success { get; }

        public T Entity { get;  }

        public static BasicOperationResult<T> Ok()
            => new BasicOperationResult<T>("", true, default(T));

        public static BasicOperationResult<T> Ok(T entity)
            => new BasicOperationResult<T>("", true, entity);

        public static BasicOperationResult<T> Fail(string message)
            => new BasicOperationResult<T>(message, false, default(T));

    }
}
