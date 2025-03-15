using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace FestFlow.Backend.API.Responses
{
    public class DepartmentResponse
    {
        [JsonProperty("departmentId")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
