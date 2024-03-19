using DGII.PruebaTecnica.Contribuyentes.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGII.PruebaTecnica.Contribuyentes.Domain.Exceptions
{
    public class ArgumentException : DomainException
    {
        public ArgumentException(string argument) 
            :base(DomainErrorCodes.InvalidArgument.GetDescription(), (int)DomainErrorCodes.InvalidArgument, "ArgumentName", argument)
        {
            Source = nameof(ArgumentException);
        }
    }
}
