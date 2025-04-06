using Dapper;
using FestFlow.Backend.API.DTO;
using FestFlow.Backend.API.Resources;
using FestFlow.Backend.API.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace FestFlow.Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public FeedbackController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("getFeedbacks")]
        [Authorize(Roles = "User")]
        public async Task<ActionResult<IEnumerable<EventsResponse>>> GetFeedbacks()
        {
            var authHeader = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var userId = TokenHelper.GetUserIdFromClaims(authHeader);

            if (userId == Guid.Empty)
                return Unauthorized("Authorization token is missing.");

            using (var connection = DbHelper.GetDbConnection(_configuration))
            {
                var result = await connection.QueryAsync<EventsResponse>("usp_GetFeedbacks", new { userId = userId }, commandType: CommandType.StoredProcedure);
                return Ok(result);
            }
        }

        [HttpPost]
        [Route("submitFeedback")]
        [Authorize(Roles = "User")]
        public async Task<ActionResult<object>> SubmitFeedback([FromBody] SubmitFeedbackDTO submitFeedbackDTO)
        {
            var authHeader = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var userId = TokenHelper.GetUserIdFromClaims(authHeader);

            if (userId == Guid.Empty)
                return Unauthorized( new { message = "Authorization token is missing" });

            if (submitFeedbackDTO is null)
                return BadRequest(new { message = "Invalid input data" });

            using (var connection = DbHelper.GetDbConnection(_configuration))
            {
                var parameters = new
                {
                    userId = userId,
                    eventId = submitFeedbackDTO.EventId,
                    rating = submitFeedbackDTO.Rating,
                    comments = submitFeedbackDTO.Comments
                };

                var response = await connection.ExecuteAsync("usp_SubmitFeedback", parameters, commandType : CommandType.StoredProcedure);

                if(response > 0)
                    return Ok(new { message = "Submitted successfully"});
                else
                    return BadRequest(new { message = "Failed to submit feedback" });
            }
        }
    }
}
