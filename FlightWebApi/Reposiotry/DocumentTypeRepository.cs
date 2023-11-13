using FlightWebApi.Data;
using FlightWebApi.DTO;
using FlightWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightWebApi.Reposiotry
{
    public class DocumentTypeRepository:IDocumentTypeRepository
    {
        private readonly FlightDbContext _context;
        public DocumentTypeRepository(FlightDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<DocumentType>> GetAllType()
        {
            return await _context.DocumentType.ToListAsync();
        }

        public async Task<DocumentType> GetTypeById(int id)
        {
            return await _context.DocumentType.FindAsync(id);
        }

        public async Task<TypeDTO> AddType(TypeDTO typeDto)
        {
            var newType = new DocumentType
            {
                TypeName=typeDto.TypeName

            };
            _context.DocumentType.Add(newType);
            await _context.SaveChangesAsync();

            return typeDto;
        }

        public async Task<bool> UpdateType(int id, TypeDTO typeDto)
        {
            var type = await _context.DocumentType.FindAsync(id);

            if (type == null)
            {
                return false;
            }

            type.TypeName= typeDto.TypeName;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteType(int id)
        {
            var Type = await _context.DocumentType.FindAsync(id);
            if (Type == null)
            {
                return false;
            }

            _context.DocumentType.Remove(Type);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
