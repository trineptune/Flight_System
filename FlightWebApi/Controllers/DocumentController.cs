using FlightWebApi.DTO;
using FlightWebApi.Models;
using FlightWebApi.Reposiotry;
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

        [HttpGet]
        public async Task<ActionResult<List<FlightDocument>>> GetAllDocuments()
        {
            var documents = await _documentRepository.GetAllDocuments();
            return Ok(documents);
        }

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

        [HttpPost]
        public async Task<IActionResult> AddDocument(DocumentDTO documentDTO)
        {
            try
            {
                await _documentRepository.AddDocument(documentDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

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