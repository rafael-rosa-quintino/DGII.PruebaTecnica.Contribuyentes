using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DGII.PruebaTecnica.Contribuyentes.Application.Taxpayers.DTOs
{
    public class TaxReceiptsDto
    {
        [JsonPropertyName("rncCedula")]
        public string RNCCedula { get; set; }

        [JsonPropertyName("NCF")]
        public string NCF { get; set; }

        [JsonPropertyName("monto")]
        public decimal Monto { get; set; }

        [JsonPropertyName("itbis18")]
        public decimal ITBIS18 { get; set; }
    }
}
