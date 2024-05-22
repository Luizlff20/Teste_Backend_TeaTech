using Backend_TeaTech.DTO.PreAnalysiss;
using Backend_TeaTech.Interfaces.Services;
using Backend_TeaTech.Models;
using Backend_TeaTech.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;

namespace Backend_TeaTech.Controllers
{
    
    [ApiController]
    [Route("api/preAnalysis")]
    public class PreAnalysisController : Controller
    {
        private readonly IPreAnalysisService _preAnalysisService;
        public PreAnalysisController(IPreAnalysisService preAnalysisService)
        {
            _preAnalysisService = preAnalysisService;
        }

        /// <summary>
        /// Update a pre-analysis.
        /// </summary>
        /// <remarks>
        /// Updates a pre-analysis with the provided data.
        /// </remarks>
        [Authorize(Roles = "Employee:Coordinator")]
        [HttpPut("update/{idPreAnalysis}")]
        [SwaggerResponse(200, "Success")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(401, "Unauthorized")]
        [SwaggerResponse(500, "Internal Server Error")]
        public IActionResult Update(Guid idPreAnalysis, [FromBody] PreAnalysisRequestDTO req)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            try
            {
                _preAnalysisService.UpdatePreAnalysis(idPreAnalysis, req, new Guid(userId));
                return Ok();
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized("You are not authorized to perform this action.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating the pre-analysis: {ex.Message}");
            }
        }

        ///// <summary>
        ///// List all pre-analyses.
        ///// </summary>
        ///// <remarks>
        ///// Retrieves a list of all pre-analyses.
        ///// </remarks>
        //[Authorize(Policy = "CoordinatorOrApplicator")]
        //[HttpGet("list")]
        //[SwaggerResponse(200, "Success")]
        //[SwaggerResponse(401, "Unauthorized")]
        //[SwaggerResponse(500, "Internal Server Error")]
        //public IActionResult ListAllPreAnalysis()
        //{
        //    try
        //    {
        //        var preAnalyses = _preAnalysisService.ListAllPreAnalysis();
        //        return Ok(new { message = "List retrieved successfully", preAnalyses });
        //    }
        //    catch (UnauthorizedAccessException)
        //    {
        //        return Unauthorized("You are not authorized to perform this action.");
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"An error occurred while retrieving the list of pre-analyses: {ex.Message}");
        //    }
        //}

        /// <summary>
        /// Delete a pre-analysis
        /// </summary>
        /// <remarks>
        /// Deletes a pre-analysis by its ID.
        /// </remarks>
        [Authorize(Roles = "Employee:Coordinator")]
        [HttpDelete("{id}")]
        [SwaggerResponse(200, "Success")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "Not Found")]
        [SwaggerResponse(500, "Internal Server Error")]
        public IActionResult DeletePreAnalysis(Guid id)
        {
            try
            {
                _preAnalysisService.DeletePreAnalysisById(id);
                return Ok("Pre Analysis deleted successfully.");
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        /// <summary>
        /// Get a pre-analysis by ID.
        /// </summary>
        /// <remarks>
        /// Retrieves a pre-analysis by its ID.
        /// </remarks>
        [Authorize(Policy = "CoordinatorOrApplicator")]
        [HttpGet("{id}")]
        [SwaggerResponse(200, "Success")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "Not Found")]
        [SwaggerResponse(500, "Internal Server Error")]
        public IActionResult GetPreAnalysisById(Guid id)
        {
            try
            {
                var user = _preAnalysisService.GetPreAnalysisById(id);
                if (user == null)
                {
                    return NotFound("Pre-Analysis not found.");
                }
                return Ok(user);
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
