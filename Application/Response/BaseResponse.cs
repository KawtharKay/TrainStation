using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Response
{
    public class BaseResponse<T>
    {
        public string Message { get; set; } = default!;
        public T? Value { get; set; }

        public static BaseResponse<T> Success(T value, string message)
        {
            return new BaseResponse<T> { Value = value, Message = message };
        }

        public static BaseResponse<T> Failure(string message)
        {
            return new BaseResponse<T> { Message = message };
        }
    }
}
