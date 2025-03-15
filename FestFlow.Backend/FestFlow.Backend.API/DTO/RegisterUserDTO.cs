using Newtonsoft.Json;

namespace FestFlow.Backend.API.DTO
{
    public class RegisterUserDTO
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("studentEnrollmentNumber")]
        public string StudentEnrollmentNumber { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("branchId")]
        public Guid BranchId { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; } = "admin@test.com";
    }
}
