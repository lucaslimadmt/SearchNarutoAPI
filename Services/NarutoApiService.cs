using System.Net.Http.Json;
using SearchNarutoAPI.Models;

namespace SearchNarutoAPI.Services;

public class NarutoApiService
{
    private readonly HttpClient _httpClient;

    public NarutoApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<CharactersResponse> ListarPersonagensAsync(
        int pagina, int limite, string? nome)
    {
        var endereco = $"characters?page={pagina}&limit={limite}";

        if (!string.IsNullOrWhiteSpace(nome))
        {
            endereco += "&name=" + Uri.EscapeDataString(nome.Trim());
        }

        using var resposta = await _httpClient.GetAsync(endereco);
        resposta.EnsureSuccessStatusCode();

        return await resposta.Content.ReadFromJsonAsync<CharactersResponse>()
            ?? new CharactersResponse();
    }
}
