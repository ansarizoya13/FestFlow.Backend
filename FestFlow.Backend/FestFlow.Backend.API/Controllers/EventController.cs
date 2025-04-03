using Dapper;
using FestFlow.Backend.API.Enums;
using FestFlow.Backend.API.Resources;
using FestFlow.Backend.API.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FestFlow.Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public EventController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("getEvents")]
        [Authorize(Roles = "User")]
        public async Task<ActionResult<IEnumerable<EventsResponse>>> GetEvents()
        {
            var authHeader = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var userId = TokenHelper.GetUserIdFromClaims(authHeader);

            if (userId == Guid.Empty)
                return Unauthorized("Authorization token is missing.");

            using (var connection = DbHelper.GetDbConnection(_configuration))
            {
                var result = await connection.QueryAsync<EventsResponse>("usp_GetEvents", new { userId = userId }, commandType: CommandType.StoredProcedure);
                return Ok(result);
            }
        }

        [HttpGet]
        [Route("getEventWithQuestionairre/{id}")]
        [Authorize(Roles = "User")]
        public async Task<ActionResult<EventWithQuestionResponse>> GetEvent(Guid id)
        {
            using (var connection = DbHelper.GetDbConnection(_configuration))
            {
                var data = await connection.QueryAsync<dynamic>("usp_GetEvent", new { eventId = id }, commandType: CommandType.StoredProcedure);

                if (!data.Any())
                    return BadRequest($"Event with {id} does not exists");

                var response = new EventWithQuestionResponse();
                response.EventId = data.First().EventId;
                response.EventName = data.First().EventName;
                response.EventQuestionairres = data
                         .GroupBy(q => new { q.EventQuestionnaireId, q.Label, q.Type, q.Mandatory, q.Sequence, q.HasMultipleAnswers })
                         .Select(qGroup => new EventQuestionairre
                         {
                             EventQuestionnaireId = qGroup.Key.EventQuestionnaireId,
                             Label = qGroup.Key.Label,
                             Type = (InputElements)qGroup.Key.Type,
                             Mandatory = qGroup.Key.Mandatory,
                             Sequence = qGroup.Key.Sequence ?? 0,
                             HasMultipleAnswers = qGroup.Key.HasMultipleAnswers,
                             Options = qGroup
                                 .Where(q => q.EventQuestionnaireOptionSetId != null)
                                 .Select(opt => new EventQuestionairreOption
                                 {
                                     EventQuestionairreOptionSetId = opt.EventQuestionnaireOptionSetId,
                                     Option = opt.Option
                                 })
                                 .ToList()
                         })
                         .ToList();

                return Ok(response);
            }
        }

        [HttpPost]
        [Route("sendEventResponse")]
        [Authorize(Roles = "User")]
        public async Task<ActionResult> SendEventResponse([FromBody] EventResponseDto eventResponseDTO)
        {
            var authHeader = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var userId = TokenHelper.GetUserIdFromClaims(authHeader);

            if (userId == Guid.Empty)
                return Unauthorized("Authorization token is missing.");

            using(var connection = DbHelper.GetDbConnection(_configuration))
            {

            }

            return Ok();
        }
    }
}
