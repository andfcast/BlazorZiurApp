using BlazorZiur.Application.Interfaces;
using BlazorZiur.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorZiur.Application.Services
{
    public class DocumentoAppService
    {
        private readonly IZiurApiService _apiService;

        public DocumentoAppService(IZiurApiService apiService)
        {
            _apiService = apiService;
        }

        /// <summary>
        /// Caso de Uso: Obtener y procesar los documentos aptos para la grilla
        /// </summary>
        public async Task<List<Documento>> GetDocumentosParaGrillaAsync()
        {
            //Traer los datos sin procesar de la infraestructura
            var datosCrudos = await _apiService.GetDocumentosCombosAsync();

            // Filtrar solo los registros válidos para operar y ordenarlos por descripción
            var datosProcesados = datosCrudos
                .Where(doc => doc.EsValidoParaOperar)
                .OrderBy(doc => doc.Descripcion)
                .ToList();
            return datosProcesados;
        }
    }
}
