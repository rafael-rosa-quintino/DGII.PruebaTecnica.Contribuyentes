﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGII.PruebaTecnica.Contribuyentes.Domain.Shared.Repository
{
    public abstract class EntityBase : IEntity
    {
        public int Id { get; set; }

        public bool Deleted { get; set; }
    }
}
