using System;
namespace VeterinaryClinicTest.Core.Exceptions
{
    public class ClinicExceptions : Exception
    {
        public ErrorCode ErrorCode { get; set; }

        public ClinicExceptions(ErrorCode errorCode)
            : this(errorCode, errorCode.Message)
        {
        }

        public ClinicExceptions(ErrorCode errorCode, string message)
            : this(errorCode, message, null)
        {
        }

        public ClinicExceptions(ErrorCode errorCode, string message, Exception innerException)
            : base(message, innerException)
        {
            ErrorCode = errorCode;
        }
    }
}

