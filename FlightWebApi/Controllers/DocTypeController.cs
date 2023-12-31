﻿using FlightWebApi.DTO;
using FlightWebApi.Reposiotry;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlightWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentTypeController : ControllerBase
    {
        private readonly IDocumentTypeRepository _documentTypeRepository;

        public DocumentTypeController(IDocumentTypeRepository documentTypeRepository)
        {
            _documentTypeRepository = documentTypeRepository;
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAllTypes()
        {
            var types = await _documentTypeRepository.GetAllType();
            return Ok(types);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTypeById(int id)
        {
            var type = await _documentTypeRepository.GetTypeById(id);
            if (type == null)
            {
                return NotFound();
            }
            return Ok(type);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddType(TypeDTO typeDto)
        {
            var createType = await _documentTypeRepository.AddType(typeDto);

            return Ok(createType);
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateType(int id, TypeDTO typeDto)
        {
            var updated = await _documentTypeRepository.UpdateType(id, typeDto);
            if (!updated)
            {
                return NotFound();
            }
            return NoContent();
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteType(int id)
        {
            var deleted = await _documentTypeRepository.DeleteType(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}