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
            // 1. Traer los datos crudos de la infraestructura
            var datosCrudos = await _apiService.GetDocumentosCombosAsync();

            // 2. APLICAR LÓGICA DE NEGOCIO DE LA APLICACIÓN
            // Regla: Filtrar solo los registros válidos para operar y ordenarlos por descripción
            var datosProcesados = datosCrudos
                .Where(doc => doc.EsValidoParaOperar)
                .OrderBy(doc => doc.Descripcion)
                .ToList();

            // Regla adicional simulada: Si no hay datos, podrías disparar una alerta de negocio
            return datosProcesados;
        }
    }
}
