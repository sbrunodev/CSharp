using System;
using System.Collections.Generic;
using System.Text;

namespace WS.Business.Interfaces
{
    public abstract class LogService
    {
        protected string Id { get; private set; }

        public LogService()
        {
            Id = GetLogId();
        }

        private static string GetLogId()
        {
            return DateTime.Now.ToString()
                .Replace(" ", "")
                .Replace("/", "")
                .Replace(":", "");
        }


    }
}

