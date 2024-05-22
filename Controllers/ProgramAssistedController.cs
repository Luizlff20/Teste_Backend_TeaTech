using Backend_TeaTech.DTO.Assessments;
using Backend_TeaTech.DTO.ProgramAssisteds;
using Backend_TeaTech.Interfaces.Services;
using Backend_TeaTech.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;

namespace Backend_TeaTech.Controllers
{
    [ApiController]
    [Route("api/program")]
    public class ProgramAssistedController : Controller
    {
        private readonly IProgramAssistedService _programService;
        public ProgramAssistedController(IProgramAssistedService programAssisted)
        {
            _programService = programAssisted;
        }
        /// <summary>
        /// Update a Program.
        /// </summary>
        /// <remarks>
        /// Updates a Program with the provided data.
        /// </remarks>
        [Authorize(Roles = "Employee:Coordinator")]
        [HttpPut("update/{idProgram}")]
        [SwaggerResponse(200, "Success")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(401, "Unauthorized")]
        [SwaggerResponse(500, "Internal Server Error")]
        public IActionResult Update(Guid idProgram, [FromBody] ProgramRequestDTO req)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            try
            {
                _programService.UpdateProgram(idProgram, req, new Guid(userId));
                return Ok();
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized("You are not authorized to perform this action.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating the program: {ex.Message}");
            }
        }
    }
}
