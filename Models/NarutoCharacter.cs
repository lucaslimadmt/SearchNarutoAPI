using System.Text.Json;
using System.Text.Json.Serialization;

namespace SearchNarutoAPI.Models;

public class NarutoCharacter
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("images")]
    public List<string>? Images { get; set; }

    [JsonPropertyName("personal")]
    public JsonElement Personal { get; set; }

    [JsonPropertyName("jutsu")]
    public List<string>? Jutsu { get; set; }

    [JsonPropertyName("rank")]
    public JsonElement Rank { get; set; }

    public int JutsuCount => Jutsu?.Count ?? 0;

    public string? ImageUrl => Images?.FirstOrDefault(url =>
        Uri.TryCreate(url, UriKind.Absolute, out var endereco) &&
        (endereco.Scheme == Uri.UriSchemeHttps || endereco.Scheme == Uri.UriSchemeHttp));

    public string ClanOuAfiliacao =>
        LerCampo(Personal, "clan") ??
        LerCampo(Personal, "affiliation") ??
        "Não informado";

    public string Patente =>
        LerCampo(Rank, "ninjaRank") ??
        "Não informada";

    private static string? LerCampo(JsonElement objeto, string campo)
    {
        if (objeto.ValueKind != JsonValueKind.Object ||
            !objeto.TryGetProperty(campo, out var valor))
        {
            return null;
        }

        return FormatarValor(valor);
    }

    private static string? FormatarValor(JsonElement valor)
    {
        return valor.ValueKind switch
        {
            JsonValueKind.String => valor.GetString(),
            JsonValueKind.Number => valor.ToString(),
            JsonValueKind.Array => Juntar(valor.EnumerateArray().Select(FormatarValor)),
            JsonValueKind.Object => Juntar(valor.EnumerateObject()
                .Select(item => item.Name + ": " + FormatarValor(item.Value))),
            _ => null
        };
    }

    private static string? Juntar(IEnumerable<string?> valores)
    {
        var texto = string.Join(" · ", valores.Where(valor =>
            !string.IsNullOrWhiteSpace(valor)));

        return string.IsNullOrWhiteSpace(texto) ? null : texto;
    }
}
