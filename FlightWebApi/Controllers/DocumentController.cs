using FlightWebApi.DTO;
using FlightWebApi.Models;
using FlightWebApi.Reposiotry;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightWebApi.Controllers
{
    [ApiController]
    [Route("api/documents")]
    public class DocumentController : ControllerBase
    {
        private readonly IDocRepository _documentRepository;

        public DocumentController(IDocRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<List<FlightDocument>>> GetAllDocuments()
        {
            var documents = await _documentRepository.GetAllDocuments();
            return Ok(documents);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<ActionResult<FlightDocument>> GetDocumentById(int id)
        {
            var document = await _documentRepository.GetDocumentById(id);

            if (document == null)
            {
                return NotFound();
            }

            return Ok(document);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddDocument(IFormFile file, int TypeId, double version,int FlightId,string Note)
        {


            var targetDirectory = Path.Combine(Directory.GetCurrentDirectory(), "FileResoure", "File");
            var fileName = file.FileName;
            var filePath = Path.Combine(targetDirectory, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var resourcesFile = new DocumentDTO
            {
                DocumentName = fileName,
                Date = DateTime.Now,
                FilePath = filePath,
                IdFlight = FlightId,
                TypeId = TypeId,
                Note = Note,
                Version = version
            };

            await _documentRepository.AddDocument(resourcesFile);

            return Ok(resourcesFile.DocumentName);
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDocument(int id, DocumentDTO documentDTO)
        {
            try
            {
                var result = await _documentRepository.UpdateDocument(id, documentDTO);

                if (!result)
                {
                    return NotFound();
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocument(int id)
        {
            try
            {
                var result = await _documentRepository.DeleteDocument(id);

                if (!result)
                {
                    return NotFound();
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}