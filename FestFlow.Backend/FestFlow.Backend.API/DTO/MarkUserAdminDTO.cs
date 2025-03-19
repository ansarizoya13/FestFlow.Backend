using Newtonsoft.Json;

namespace FestFlow.Backend.API.DTO
{
    public class MarkUserAdminDTO
    {
        [JsonProperty("userId")]
        public Guid UserId { get; set; }

        [JsonProperty("isAdmin")]
        public bool IsAdmin { get; set; }
    }
}
