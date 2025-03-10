using Newtonsoft.Json;

namespace FestFlow.Backend.API.DTO
{
    public class LoginUserDTO
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
