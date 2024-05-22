using Microsoft.AspNetCore.Mvc;
using Backend_TeaTech.DTO.ChildAssisteds;
using Backend_TeaTech.Interfaces.Services;
using Backend_TeaTech.Models;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Annotations;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Backend_TeaTech.Controllers
{
    [ApiController]
    [Route("api/childAssisted")]
    public class ChildAssistedController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IChildAssistedService _childAssistedService;
        private readonly IResponsibleService _responsibleService;
        private readonly IPreAnalysisService _preAnalysisService;
        private readonly IAssessmentService _assessmentService;
        private readonly IProgramAssistedService _programAssistedService;

        public ChildAssistedController(IUserService userService, IChildAssistedService childAssistedService, IResponsibleService responsibleService, IPreAnalysisService preAnalysisService, IAssessmentService assessmentService, IProgramAssistedService programAssistedService)
        {
            _userService = userService;
            _childAssistedService = childAssistedService;
            _responsibleService = responsibleService;
            _preAnalysisService = preAnalysisService;
            _assessmentService = assessmentService;
            _programAssistedService = programAssistedService;

        }

        /// <summary>
        /// Add a new child assisted.
        /// </summary>
        /// <remarks>
        /// Register a child, their guardian and responsible user.
        /// </remarks>
        [Authorize(Roles = "Employee:Coordinator")]
        [HttpPost("add")]
        [SwaggerResponse(200, "Success")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(401, "Unauthorized")]
        public IActionResult Add([FromBody] ChildAssistedRequestDTO req)
        {
            try
            {
                User userResponsible = new User(req.Email, req.ResponsibleCpfOne);
                userResponsible = _userService.CreateUserResponsible(userResponsible);

                Responsible responsible = new Responsible(req.NameResponsibleOne, req.ResponsibleKinshipOne, req.ResponsibleCpfOne, req.NameResponsibleTwo, req.ResponsibleKinshipTwo, req.ResponsibleCpfTwo, req.ContactOne, req.ContactTwo, userResponsible);
                responsible = _responsibleService.CreateResponsible(responsible);

                ChildAssisted childAssited = new ChildAssisted(req.Name, req.BirthDate.ToUniversalTime(), req.FoodSelectivity, req.Aversions, req.Preferences, req.MedicalRecord, req.Photo, responsible);
                childAssited = _childAssistedService.CreateChild(childAssited);

                PreAnalysis preAnalysis = new PreAnalysis(childAssited);
                preAnalysis = _preAnalysisService.CreatePreAnalysis(preAnalysis);

                Assessment assessment = new Assessment(childAssited);
                assessment = _assessmentService.CreateAssessment(assessment);

                ProgramAssisted programAssisted = new ProgramAssisted(childAssited);
                programAssisted = _programAssistedService.CreateProgram(programAssisted);

                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing the request.");
            }

        }

        ///   <summary>
        ///   Filter items by data.
        ///   </summary>
        ///   <remarks>
        ///   Retrieves items filtered by data from the server.
        ///   </remarks>
        [Authorize(Policy = "CoordinatorOrApplicator")]
        [HttpGet("filterByData")]  
        [SwaggerResponse(200, "Success")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(401, "Unauthorized")]
        [SwaggerResponse(500, "Internal Server Error")]
        public IActionResult FilterByData(string data = "", int pageNumber = 1, int pageSize = 10, string orderBy = "Name", string orderDirection = "asc")
        {
            try
            {
                var filteredUsers = _childAssistedService.FilterByData(data, pageNumber, pageSize, orderBy, orderDirection);
                return Ok(filteredUsers);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        /// <summary>
        /// Delete a child.
        /// </summary>
        /// <remarks>
        /// Deletes a child by its ID.
        /// </remarks>
        [Authorize(Roles = "Employee:Coordinator")]
        [HttpDelete("{id}")]
        [SwaggerResponse(200, "Success")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(401, "Unauthorized")]
        [SwaggerResponse(404, "Not Found")]
        [SwaggerResponse(500, "Internal Server Error")]
        public IActionResult DeleteChild(Guid id)
        {
            try
            {
                _childAssistedService.DeleteChildById(id);
                return Ok("Child deleted successfully.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        /// <summary>
        /// Get a child by ID.
        /// </summary>
        /// <remarks>
        /// Retrieves a child by its ID.
        /// </remarks>
        [Authorize]
        [HttpGet("{id}")]
        [SwaggerResponse(200, "Success")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(401, "Unauthorized")]
        [SwaggerResponse(404, "Not Found")]
        [SwaggerResponse(500, "Internal Server Error")]
        public IActionResult GetChildById(Guid id)
        {
            try
            {
                var child = _childAssistedService.GetChildById(id);
                if (child == null)
                {
                    return NotFound("ChildAssisted not found.");
                }
                return Ok(child);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

    }
    
    
}
