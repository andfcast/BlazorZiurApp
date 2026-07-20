using BlazorZiur.Application.Interfaces;
using BlazorZiur.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace BlazorZiur.Infrastructure.Services
{
    public class ZiurApiService : IZiurApiService
    {
        private readonly HttpClient _httpClient;

        public ZiurApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ZiurClient");
        }

        public async Task<List<Documento>> GetDocumentosCombosAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("DocumentosFillsCombos");
                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadFromJsonAsync<List<Documento>>();
                return result ?? new List<Documento>();
            }
            catch (Exception ex)
            {
                // Loguear el error de infraestructura
                Console.WriteLine($"[Infrastructure Error]: {ex.Message}");
                return new List<Documento>();
            }
        }
    }
}
