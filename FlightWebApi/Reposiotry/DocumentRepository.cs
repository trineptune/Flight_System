using FlightWebApi.Data;
using FlightWebApi.DTO;
using FlightWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightWebApi.Reposiotry
{
    public class DocumentRepository:IDocRepository
    {
        private readonly FlightDbContext _context;
        public DocumentRepository(FlightDbContext context)
        {
            _context = context;
        }
        public async Task<List<FlightDocument>> GetAllDocuments()
        {
            return await _context.FlightsDocument.ToListAsync();
        }
        public async Task<FlightDocument> GetDocumentById(int id)
        {
            return await _context.FlightsDocument.FindAsync(id);
        }
        public async Task AddDocument(DocumentDTO documentDTO)
        {
            var newDocument = new FlightDocument
            {
                IdFlight=documentDTO.IdFlight,
                Date=DateTime.Now,
                DocumentName=documentDTO.DocumentName,
                Note=documentDTO.Note,
                Type=documentDTO.Type,
                Version=documentDTO.Version,
            };
            _context.FlightsDocument.Add(newDocument);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> UpdateDocument(int id, DocumentDTO documentDTO)
        {
            var resoure = await _context.FlightsDocument.FindAsync(id);

            if (resoure == null)
            {
                return false;
            }
            resoure.IdFlight= documentDTO.IdFlight;
            resoure.Date= DateTime.Now;
            resoure.DocumentName= documentDTO.DocumentName;
            resoure.Note= documentDTO.Note;
            resoure.Type= documentDTO.Type;
            resoure.Version= documentDTO.Version;
            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<bool> DeleteDocument(int id)
        {
            var resource = await _context.FlightsDocument.FindAsync(id);
            if (resource == null)
            {
                return false;
            }

            if (File.Exists(resource.FilePath))
            {
                File.Delete(resource.FilePath);
            }

            _context.FlightsDocument.Remove(resource);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
