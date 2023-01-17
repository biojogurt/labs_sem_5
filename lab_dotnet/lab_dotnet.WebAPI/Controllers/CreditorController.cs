using AutoMapper;
using lab_dotnet.Services.Abstract;
using lab_dotnet.Services.Models;
using lab_dotnet.WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lab_dotnet.WebAPI.Controllers;

/// <summary>
/// Creditor endpoints
/// </summary>
[ProducesResponseType(200)]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[Authorize]
public class CreditorController : ControllerBase
{
    private readonly ICreditorService Service;
    private readonly IMapper Mapper;

    /// <summary>
    /// Creditor controller
    /// </summary>
    public CreditorController(ICreditorService service, IMapper mapper)
    {
        Service = service;
        Mapper = mapper;
    }

    /// <summary>
    /// Create creditor
    /// </summary>
    [HttpPost]
    public IActionResult CreateCreditor([FromBody] CreditorRequest creditor)
    {
        try
        {
            var creditorModel = Service.CreateCreditor(Mapper.Map<CreditorModel>(creditor));
            var creditorResponce = Mapper.Map<CreditorResponse>(creditorModel);
            return Ok(creditorResponce);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    /// <summary>
    /// Delete creditor
    /// </summary>
    [HttpDelete]
    [Route("{id:Guid}")]
    public IActionResult DeleteCreditor([FromRoute] Guid id)
    {
        try
        {
            Service.DeleteCreditor(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    /// <summary>
    /// Get creditor
    /// </summary>
    [HttpGet]
    [Route("{id:Guid}")]
    public IActionResult GetCreditor([FromRoute] Guid id)
    {
        try
        {
            var creditorModel = Service.GetCreditor(id);
            var creditorResponse = Mapper.Map<CreditorResponse>(creditorModel);
            return Ok(creditorResponse);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    /// <summary>
    /// Get creditors
    /// </summary>
    [HttpGet]
    public IActionResult GetCreditors([FromQuery] int limit = 20, [FromQuery] int offset = 0)
    {
        var pageModel = Service.GetCreditors(limit, offset);
        var pageResponse = Mapper.Map<PageResponse<CreditorResponse>>(pageModel);
        return Ok(pageResponse);
    }

    /// <summary>
    /// Update creditor
    /// </summary>
    [HttpPut]
    [Route("{id:Guid}")]
    public IActionResult UpdateCreditor([FromRoute] Guid id, [FromBody] UpdateCreditorRequest creditorRequest)
    {
        var validationResult = creditorRequest.Validate();

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        try
        {
            var creditorModel = Mapper.Map<UpdateCreditorModel>(creditorRequest);
            var creditorResult = Service.UpdateCreditor(id, creditorModel);
            return Ok(creditorResult);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }
}