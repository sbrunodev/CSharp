using System;
using System.Collections.Generic;
using System.Text;

namespace WS.Business.Interfaces
{
    public interface IFileLogService
    {
        string PathDefault();
        void CreateDirectory();
        void Create();
       
    }
}
