using System;
using System.Collections.Generic;
using System.Text;

namespace RCA.Interface.Result
{
    public class Result<T> : IResult<T>
    {
        public bool IsSuccess { get; set; }

        public ResultType ResultType { get; set; }
        public string Html { get; set; }
        public string Message { get; set; }
        public bool IsLastPackage { get; set; }
        public int DataCount { get; set; }
        public T Data { get; set; }

        public Result()
        {
            Data = default(T);
        }

        public Result(T Data)
            : this(true, ResultType.None, string.Empty, Data, false, string.Empty)
        {
        }
        public Result(T Data, int DataCount)
           : this(true, ResultType.None, string.Empty, Data, false, string.Empty, DataCount)
        {
        }
        public Result(ResultType ResultType, T Data, string Message)
          : this(true, ResultType, string.Empty, Data, false, Message)
        {
        }
        public Result(ResultType ResultType, T Data, string Message, int DataCount)
          : this(true, ResultType, string.Empty, Data, false, Message, DataCount)
        {
        }

        public Result(bool IsSuccess, string Message)
          : this(IsSuccess, ResultType.None, string.Empty, default(T), false, Message)
        {
        }
        public Result(bool IsSuccess, ResultType ResultType, string Message)
            : this(IsSuccess, ResultType, string.Empty, default(T), false, Message)
        {
        }

        public Result(bool IsSuccess, ResultType ResultType, string Html, T Data, bool IsLastPackage, string Message, int DataCount = 0)
        {
            this.IsSuccess = IsSuccess;
            this.ResultType = ResultType;
            this.Message = Message;
            this.Html = Html;
            this.Data = Data;
            this.IsLastPackage = IsLastPackage;
            this.DataCount = DataCount;
        }

        public void Import(IResult result)
        {
            this.IsSuccess = result.IsSuccess;
            this.ResultType = result.ResultType;
            this.Message = result.Message;
        }
    }
}
