using System;
namespace VeterinaryClinicTest.Core.Constants
{
    public static class ConstantValues
    {
        public static string LogTemplate => "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} {Level} - {Message:lj}{NewLine}{Exception}";

        public static string DevelopmentLogPath => "../Log/clinic.log";

        public static string ProductionLogPath => "./Log/clinic.log";

        public static string PriceDecimalType => "decimal(18,2)";

       
    }
}

