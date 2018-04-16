using System;
using System.Collections.Generic;
using System.Text;

namespace RCA.Interface.Result
{
    public interface IResult<T> : IResult
    {
        T Data { get; set; }
    }

    public interface IResult
    {
        bool IsSuccess { get; set; }
        string Message { get; set; }
        ResultType ResultType { get; set; }
    }
}
