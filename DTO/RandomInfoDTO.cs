using System.Text.Json.Serialization;

namespace randominfo.DTO
{
    public record RandomInfo(
        [property: JsonPropertyName("info")] string Info
    );
}
