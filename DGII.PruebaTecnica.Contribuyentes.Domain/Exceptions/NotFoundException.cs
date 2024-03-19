using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGII.PruebaTecnica.Contribuyentes.Domain.Exceptions
{
    public class NotFoundException : DomainException
    {
        public NotFoundException(DomainErrorCodes domainErrorCode) : base(domainErrorCode)
        {
            Source = nameof(NotFoundException);
        }
    }
}
