using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Net;
using Maia.Maps.Domain.DTO.SearchHistory;
using Maia.Maps.Domain.DTO;

namespace Maia.Maps.Api.v1
{
    [ApiController]
    [Route("v{version:apiVersion}/SearchHistory")]
    public class SearchHistoryController : ControllerBase
    {
        private readonly ISender _sender;

        public SearchHistoryController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(PagedList<LatestSearchHistoriesViewModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetSearchHistoriesAsync([FromQuery] GetLatestSearchHistoriesQuery query)
        {
            var list = await _sender.Send(query);
            return Ok(list);
        }

        [HttpGet("{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(DistanceViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> GetSearchHistoriesAsync([FromRoute] long id)
        {
            var query = new GetDistanceQuery(id);

            var distance = await _sender.Send(query);
            return Ok(distance);
        }

        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> PostSearchHistoryAsync([FromBody] CreateSearchHistoryCommand command)
        {
            var response = await _sender.Send(command);
            return Created(string.Empty, response);
        }
    }
}
