using DemoApiCall.Models;
using DemoApiCall.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoApiCall
{
    public class Run<T> : IRun<T> where T : IReturnModel
    {
        private readonly IApiCallService _ApiCallService;
        public Run(IApiCallService ApiCallService)
        {
            _ApiCallService = ApiCallService;
        }

        public void Start()
        {
            RequestToApiFlow1();
        }

        public void RequestToApiFlow1()
        {
            Console.WriteLine("Request flow 1: -> Get Accestoken with credentials -> Request with obtained AccessToken\r\n");
            var tokenResult = Execute(() => (T)_ApiCallService.GetAccessTokenWithCredentials().Result);

            if (tokenResult != null)
            {
                Console.WriteLine(tokenResult?.GetData());
                Console.WriteLine("Api two leg result:\r\n");
                var twoLegResult = Execute(() => (T)_ApiCallService.CallApi2Legs(tokenResult.GetAccesToken()).Result);
                Console.WriteLine(twoLegResult?.GetData());
                RequestToApiFlow2(tokenResult?.GetRefreshToken());
            }
            else
            {
                Exit();
            }
        }

        public void RequestToApiFlow2(string refreshToken)
        {
            Console.WriteLine("Request flow 2: -> Get Accestoken with refresh token-> Request with obtained AccessToken\r\n");
            var tokenResult = Execute(() => (T)_ApiCallService.GetAccessTokenWithRefreshToken(refreshToken).Result);
            if (tokenResult != null)
            {
                Console.WriteLine(tokenResult?.GetData());
                Console.WriteLine("Api three leg result:\r\n");
                var threeLegsResult = Execute(() => (T)_ApiCallService.CallApi3Legs(tokenResult.GetAccesToken()).Result);
                Console.WriteLine(threeLegsResult?.GetData());
            }
            Exit();
        }

        public void Exit()
        {
            Console.WriteLine("Press a key to exit");
            Console.ReadKey();
        }

        private static T Execute(Func<T> func)
        {
            try
            {
                return func();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return default(T);
            }
        }
    }
}
