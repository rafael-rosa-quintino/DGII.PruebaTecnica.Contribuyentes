using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DGII.PruebaTecnica.Contribuyentes.Application.Taxpayers.DTOs
{
    public class TaxpayerDto
    {
        [JsonPropertyName("rncCedula")]
        public string RNCCedula { get; set; }

        [JsonPropertyName("nombre")]
        public string Name { get; set; }

        [JsonPropertyName("tipo")]
        public string Type { get; set; }

        [JsonPropertyName("estatus")]
        public string Status { get; set; }

    }
}
