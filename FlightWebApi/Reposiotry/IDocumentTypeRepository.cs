using FlightWebApi.DTO;
using FlightWebApi.Models;

namespace FlightWebApi.Reposiotry
{
    public interface IDocumentTypeRepository
    {
        Task<IEnumerable<DocumentType>> GetAllType();
        Task<DocumentType> GetTypeById(int id);
        Task<TypeDTO> AddType(TypeDTO typeDto);
        Task<bool> UpdateType(int id, TypeDTO typeDto);
        Task<bool> DeleteType(int id);
    }
}
