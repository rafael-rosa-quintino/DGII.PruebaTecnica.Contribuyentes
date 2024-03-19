using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGII.PruebaTecnica.Contribuyentes.Domain.Exceptions
{
    public enum DomainErrorCodes
    {
        [Description("The given key was not present in the dictionary.")]
        MissingKey = 1000,


        [Description("Bad Request.")]
        BadRequest = 400,

        [Description($"{MessagesPrefix.TheValueProvied} {MessagesSuffix.IsNotValid}.")]
        InvalidArgument = 4000001,


        [Description($"{MessagesPrefix.TheSpecified} resource {MessagesSuffix.NotFound}.")]
        NotFound = 404,

        [Description($"{MessagesPrefix.TheSpecified} taxpayer {MessagesSuffix.NotFound}.")]
        TaxpayerNotFound = 4040001,

        [Description("Internal server error.")]
        InternalServerError = 500
    }

    public class MessagesSuffix
    {
        public const string NotFound = "does not exist or could not be found";
        public const string IsNotValid = "is not valid or contains errors";
        public const string HasBeenUsed = "has already been used";
    }

    public class MessagesPrefix
    {
        public const string TheSpecified = "The specified";
        public const string TheValueProvied = "The value provided in the field";
    }

}
