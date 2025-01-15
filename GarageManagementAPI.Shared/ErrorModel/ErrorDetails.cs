using System.Text.Json;
using System.Text.Json.Serialization;

namespace GarageManagementAPI.Shared.ErrorModel
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Message { get; set; }

        public override string ToString()
        => JsonSerializer.Serialize(this);
    }
}
