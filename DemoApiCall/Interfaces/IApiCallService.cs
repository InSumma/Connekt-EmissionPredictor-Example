using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoApiCall.Interfaces
{
    public interface IApiCallService
    {
        Task<IReturnModel> GetAccessTokenWithCredentials();
        Task<IReturnModel> GetAccessTokenWithRefreshToken(string refreshToken);
        Task<IReturnModel> CallApi2Legs(string accesToken);
        Task<IReturnModel> CallApi3Legs(string accesToken);

    }
}
