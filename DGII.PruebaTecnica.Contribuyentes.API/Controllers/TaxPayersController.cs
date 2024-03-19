using DGII.PruebaTecnica.Contribuyentes.API.Models;
using DGII.PruebaTecnica.Contribuyentes.Application.Taxpayers.DTOs;
using DGII.PruebaTecnica.Contribuyentes.Application.Taxpayers.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DGII.PruebaTecnica.Contribuyentes.API.Controllers
{
    [Route("api/contribuyentes")]
    [ApiController]
    public class TaxPayersController : ControllerBase
    {

        private readonly IMediator _mediator;

        public TaxPayersController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [ProducesResponseType(typeof(ApiResponse<IEnumerable<TaxpayerDto>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<object>), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ApiResponse<object>), (int)HttpStatusCode.InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetTaxpayersQuery());
            var response = new ApiResponse<IEnumerable<TaxpayerDto>>(result);
            return response.OK();
        }



        [ProducesResponseType(typeof(ApiResponse<IEnumerable<TaxReceiptsDto>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<object>), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ApiResponse<object>), (int)HttpStatusCode.InternalServerError)]
        [HttpGet("{rncCedula}/comprobantes-fiscales")]
        public async Task<IActionResult> GetTaxReceipts([FromRoute(Name = "rncCedula")] string rncCedula)
        {
            var query = new GetTaxReceiptsByRncCedulaQuery(rncCedula);
            var result = await _mediator.Send(query);
            var response = new ApiResponse<IEnumerable<TaxReceiptsDto>>(result);
            return response.OK();            
        }

    }
}
