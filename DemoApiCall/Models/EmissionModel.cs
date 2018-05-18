using DemoApiCall.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApiCall.Models
{
    public class EmissionModel : IReturnModel
    {
        public double Emission { get; set; }
        public double MetersDiesel { get; set; }
        public double MetersGasoline { get; set; }

        public string GetAccesToken()
        {
            return null;
        }
        public string GetRefreshToken()
        {
            return null;
        }
       
        public string GetData()
        {
            return $"Emission: {Emission}\r\n" +
                   $"\r\nMetersDiesel: {MetersDiesel}\r\n" +
                   $"\r\nMetersGasoline: {MetersGasoline}\r\n";
        }

       
    }
}
