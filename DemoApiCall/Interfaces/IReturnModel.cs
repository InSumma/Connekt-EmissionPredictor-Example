using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApiCall.Interfaces
{
    public interface IReturnModel
    {
        string GetAccesToken();
        string GetRefreshToken();
        string GetData();
    }
}
