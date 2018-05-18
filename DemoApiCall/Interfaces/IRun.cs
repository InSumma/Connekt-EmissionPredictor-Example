using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApiCall.Interfaces
{
    public interface IRun<T> where T : IReturnModel
    {
        void Start();
    }
}
