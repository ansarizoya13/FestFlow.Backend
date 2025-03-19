using Newtonsoft.Json;

namespace FestFlow.Backend.API.DTO
{
    public class MarkUserInactiveDTO
    {
        [JsonProperty("userId")]
        public Guid UserId { get; set; }

        [JsonProperty("isDeleted")]
        public bool IsDeleted { get; set; }
    }
}
