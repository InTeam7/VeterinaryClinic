using System;
using System.Net;

namespace VeterinaryClinicTest.Core.Exceptions
{
    public class ErrorCode
    {
        public string ErrorCodeName { get; set; }

        public string Message { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public ErrorCode(string errorCodeName, string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            ErrorCodeName = errorCodeName;
            Message = message;
            StatusCode = statusCode;
        }

        public ErrorCode(string errorCodeName, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
            : this(errorCodeName, errorCodeName, statusCode)
        {
        }

        public static ErrorCode GenericNotExist(Type type, string message = null) =>
            new ErrorCode($"{type.Name}NotExist", message);

        public static ErrorCode AnimalNotFound =>
            new ErrorCode(nameof(AnimalNotFound), "AnimalNotFound", HttpStatusCode.NotFound);

        public static ErrorCode ClientNotFound =>
            new ErrorCode(nameof(ClientNotFound), "ClientNotFound", HttpStatusCode.NotFound);

        public static ErrorCode PhoneNotFound =>
            new ErrorCode(nameof(PhoneNotFound), "PhoneNotFound", HttpStatusCode.NotFound);

        public static ErrorCode DoctorNotFound =>
            new ErrorCode(nameof(DoctorNotFound), "DoctorNotFound", HttpStatusCode.NotFound);

        public static ErrorCode VaccineNotFound =>
            new ErrorCode(nameof(VaccineNotFound), "VaccineNotFound",HttpStatusCode.NotFound);

        public static ErrorCode ProvidedServiceNotFound =>
            new ErrorCode(nameof(ProvidedServiceNotFound), "ProvidedServiceNotFound", HttpStatusCode.NotFound);

        public static ErrorCode ServiceNotFound =>
           new ErrorCode(nameof(ServiceNotFound), "ServiceNotFound", HttpStatusCode.NotFound);



        public new string ToString() => $"{ErrorCodeName}: StatusCode: '{StatusCode}', Message: '{Message}'.";
    }
}

