using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Contracts
{
    public interface IOperationResult<T>
    {
        string Message { get; }
        bool Success { get; }
        T Entity { get; }
    }
}
