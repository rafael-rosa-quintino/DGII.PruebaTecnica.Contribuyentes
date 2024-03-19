using DGII.PruebaTecnica.Contribuyentes.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGII.PruebaTecnica.Contribuyentes.Domain.Exceptions
{
    public class AppSettingMissingKeyException :DomainException
    {
        public AppSettingMissingKeyException(string key)
            :base(DomainErrorCodes.MissingKey.GetDescription(), (int)DomainErrorCodes.MissingKey, "Key", key)
        {
            Source = nameof(AppSettingMissingKeyException);
        }
    }
}
