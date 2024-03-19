using DGII.PruebaTecnica.Contribuyentes.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGII.PruebaTecnica.Contribuyentes.Domain.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException(string message) : base(message)
        {
            this.Source = nameof(DomainException);
        }

        public DomainException(string message, int code) :this(message)
        {
            HResult = code;
        }


        public DomainException(string message, int code, string dataKey, string dataValue) : this(message, code)
        {
            Data.Add(dataKey, dataValue);
        }

        public DomainException(string message, int code, IDictionary<string, string> data) :this(message, code) 
        {
            foreach (var item in data)
            {
                Data.Add(item.Key, item.Value);
            }
        }

        public DomainException(DomainErrorCodes domainErrorCodes)
            :this(domainErrorCodes.GetDescription(), (int)domainErrorCodes)
        {

        }

    }
}
