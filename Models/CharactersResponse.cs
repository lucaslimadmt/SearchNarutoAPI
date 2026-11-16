using System.Text.Json.Serialization;

namespace SearchNarutoAPI.Models;

public class CharactersResponse
{
    [JsonPropertyName("characters")]
    public List<NarutoCharacter>? Characters { get; set; }

    [JsonPropertyName("totalCharacters")]
    public int TotalCharacters { get; set; }

    [JsonPropertyName("totalPages")]
    public int TotalPages { get; set; }
}
