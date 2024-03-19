using DGII.PruebaTecnica.Contribuyentes.Domain.Shared;
using DGII.PruebaTecnica.Contribuyentes.Domain.Shared.Aggregate;
using DGII.PruebaTecnica.Contribuyentes.Domain.Shared.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGII.PruebaTecnica.Contribuyentes.Domain.Aggregates.TaxpayerAggregate
{
    public class Taxpayer : EntityBase, IAggregateRoot
    {
        public Taxpayer(string rNCCedula, string name, TaxpayerType type, TaxpayerStatus status)
        {
            RNCCedula= rNCCedula;
            Name= name;
            Type = type; 
            Status = status;
        }

        public string RNCCedula { get; private set; }
        public string Name { get; private set; }
        public TaxpayerType Type { get; private set; }
        public TaxpayerStatus Status { get; private set; }

        public virtual IReadOnlyCollection<TaxReceipt> TaxReceipts { get; private set; }


    }

    public enum TaxpayerType
    {
        [Description("Persona Fisica")]
        NaturalPersons = 1,
        [Description("Personas Jurídica")]
        LegalEntity = 2,
        [Description("Registrados")]
        Registered = 3,
        [Description("No lucrativos")]
        NonProfit
    }


    public enum TaxpayerStatus
    {
        [Description("Inactivo")]
        Inactive = 0,
        [Description("Activo")]
        Active = 1,
    }

}
