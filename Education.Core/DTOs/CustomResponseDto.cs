using Education.Core.Models;
using System.Text.Json.Serialization;

namespace Education.Core
{
    public class CustomResponseDto<T>
    {
        public T Payload { get; set; }
        public int StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public List<string> Errors { get; set; }

        public static CustomResponseDto<T> Success(int statusCode, T data)
        {
            return new CustomResponseDto<T> { Payload = data, StatusCode = statusCode, Errors = null, IsSuccess = true };
        }
        public static CustomResponseDto<T> Success(int statusCode)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, IsSuccess = true };
        }
        public static CustomResponseDto<T> Fail(int statusCode, List<string> errors)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Errors = errors, IsSuccess = false };
        }
        public static CustomResponseDto<T> Fail(int statusCode, string error)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Errors = new List<string> { error }, IsSuccess = false };
        }
    }

    public class NoContentDto
    {
    }
}