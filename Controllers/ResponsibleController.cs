using Microsoft.AspNetCore.Mvc;
using Backend_TeaTech.Interfaces.Services;
using Backend_TeaTech.DTO.Responsibles;
using Backend_TeaTech.Services;
using Microsoft.AspNetCore.Authorization;
using Backend_TeaTech.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Backend_TeaTech.Controllers
{
    [ApiController]
    [Route("api/responsible")]
    public class ResponsibleController : ControllerBase
    {
        private readonly IResponsibleService _responsibleService;

        public ResponsibleController(IResponsibleService responsibleService)
        {
            _responsibleService = responsibleService;
        }

        /// <summary>
        /// List all responsibles.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all responsibles.
        /// </remarks>
        [Authorize(Policy = "CoordinatorOrApplicator")]
        [HttpGet("list")]
        [SwaggerResponse(200, "Success")]
        [SwaggerResponse(401, "Unauthorized")]
        [SwaggerResponse(500, "Internal Server Error")]
        public IActionResult ListAllResponsible()
        {
            try
            {
                var responsibles = _responsibleService.ListAllResponsible();
                return Ok(new { message = "List retrieved successfully", responsibles });
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized("You are not authorized to perform this action.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving the list of responsibles: {ex.Message}");
            }
        }

        /// <summary>
        /// Delete a responsible.
        /// </summary>
        /// <remarks>
        /// Deletes a responsible by its ID.
        /// </remarks>
        [Authorize(Roles = "Employee:Coordinator")]
        [HttpDelete("{id}")]
        [SwaggerResponse(200, "Success")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "Not Found")]
        [SwaggerResponse(500, "Internal Server Error")]
        public IActionResult DeleteResponsible(Guid id)
        {
            try
            {
                _responsibleService.DeleteResponsibleById(id);
                return Ok("Responsible deleted successfully.");
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized("You are not authorized to perform this action.");
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        /// <summary>
        /// Update a responsible.
        /// </summary>
        /// <remarks>
        /// Updates a responsible with the provided data.
        /// </remarks>
        [Authorize(Roles = "CoordinatorOrResponsible")]
        [HttpPut("update/{id}")]
        [SwaggerResponse(200, "Success")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "Not Found")]
        [SwaggerResponse(500, "Internal Server Error")]
        public IActionResult PutResponsible(Guid id, [FromBody] ResponsibleRequestDTO req)
        {
            try
            {
                // Adicionar regra de negócio
                return Ok("Responsible updated successfully.");
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized("You are not authorized to perform this action.");
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        /// <summary>
        /// Get a responsible by ID.
        /// </summary>
        /// <remarks>
        /// Retrieves a responsible by its ID.
        /// </remarks>
        [Authorize]
        [HttpGet("{id}")]
        [SwaggerResponse(200, "Success")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "Not Found")]
        [SwaggerResponse(500, "Internal Server Error")]
        public IActionResult GetResponsibleById(Guid id)
        {
            try
            {
                var responsible = _responsibleService.GetResponsibleById(id);
                if (responsible == null)
                {
                    return NotFound("Resposible not found.");
                }
                return Ok(responsible);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized("You are not authorized to perform this action.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing the request." + ex);
            }

        }

    }
}
