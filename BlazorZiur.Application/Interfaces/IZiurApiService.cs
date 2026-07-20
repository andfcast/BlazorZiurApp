using BlazorZiur.Domain.Entities;

namespace BlazorZiur.Application.Interfaces
{
    public interface IZiurApiService
    {
        Task<List<Documento>> GetDocumentosCombosAsync();
    }
}
