using FlightWebApi.DTO;
using FlightWebApi.Models;

namespace FlightWebApi.Reposiotry
{
    public interface IDocRepository
    {
        Task<List<FlightDocument>> GetAllDocuments();
        Task<FlightDocument> GetDocumentById(int id);
        Task AddDocument(DocumentDTO documentDTO);
        Task<bool> UpdateDocument(int id, DocumentDTO documentDTO);
        Task<bool> DeleteDocument(int id);
    }
}
