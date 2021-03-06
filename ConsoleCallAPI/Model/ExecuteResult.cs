﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCallAPI
{
    public class ExecuteResult
    {
        public bool IsSuccessed { get; set; }

        public string Message { get; set; }
        public ExecuteResult()
        {

        }

        public ExecuteResult(bool isSuccessed, string message)
        {
            IsSuccessed = isSuccessed;
            Message = message;
        }

        public static ExecuteResult Ok()
        {
            return new ExecuteResult { IsSuccessed = true };
        }

        public static ExecuteResult Fail(string errMsg)
        {
            return new ExecuteResult { IsSuccessed = false, Message = errMsg };
        }
    }
    public class ExecuteResult<T> : ExecuteResult
    {
        public T Data { get; set; }

        public ExecuteResult()
        {
            Data = default(T);
        }
        public static ExecuteResult<T> Ok(T data)
        {
            return new ExecuteResult<T> { IsSuccessed = true, Data = data };
        }

        public static ExecuteResult<T> Ok(T data, string msg)
        {
            return new ExecuteResult<T> { IsSuccessed = true, Message = msg, Data = data };
        }

        public static ExecuteResult<T> Fail(string errMsg)
        {
            return new ExecuteResult<T> { IsSuccessed = false, Message = errMsg };
        }
    }
}
