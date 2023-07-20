using System;
using System.Globalization;

namespace pharmacy.Api.Controllers
{
    public class CAppException : Exception
    {
        public CAppException() : base() { }

        public CAppException(string message) : base(message) { }

        public CAppException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
