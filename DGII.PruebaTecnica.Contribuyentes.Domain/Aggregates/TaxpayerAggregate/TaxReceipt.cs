using DGII.PruebaTecnica.Contribuyentes.Domain.Shared.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGII.PruebaTecnica.Contribuyentes.Domain.Aggregates.TaxpayerAggregate
{
    public class TaxReceipt : EntityBase
    {
        public TaxReceipt(string nCF, decimal monto, decimal iTBIS18)
        {
            NCF = nCF;
            Monto = monto;
            ITBIS18 = iTBIS18;
        }

        public string NCF { get; private set; }
        public decimal Monto { get; private set; }
        public decimal ITBIS18 { get; private set; }


        public int TaxpayerId { get; private set; }
        public virtual Taxpayer Taxpayer { get; private set; }
    }
}
