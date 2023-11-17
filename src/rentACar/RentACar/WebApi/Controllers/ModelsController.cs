using Application.Features.Models.Queries.GetList;
using Application.Features.Models.Queries.GetListByDynamic;
using Core.Application.Requests;
using Core.Persistance.Dynamic;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var getListModelQuery = new GetListModelQuery { PageRequest = pageRequest };

            var response = await Mediator.Send(getListModelQuery);

            return Ok(response);
        }

        [HttpPost("GetList/ByDynamic")]
        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] DynamicQuery? dynamicQuery)
        {
            var getListByDynamicModelQuery = new GetListByDynamicModelQuery { PageRequest = pageRequest, DynamicQuery = dynamicQuery };

            var response = await Mediator.Send(getListByDynamicModelQuery);

            return Ok(response);
        }
    }
}