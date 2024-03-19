using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGII.PruebaTecnica.Contribuyentes.Domain.Shared.Repository
{
    public interface IEntity
    {
        int Id { get; set; }
        bool Deleted { get; set; }
    }
}
