using AutoMapper;
using lab_dotnet.Services.Abstract;
using lab_dotnet.Services.Models;
using lab_dotnet.WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lab_dotnet.WebAPI.Controllers;

/// <summary>
/// CreditType endpoints
/// </summary>
[ProducesResponseType(200)]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[Authorize]
public class CreditTypeController : ControllerBase
{
    private readonly ICreditTypeService Service;
    private readonly IMapper Mapper;

    /// <summary>
    /// CreditType controller
    /// </summary>
    public CreditTypeController(ICreditTypeService service, IMapper mapper)
    {
        Service = service;
        Mapper = mapper;
    }

    /// <summary>
    /// Create credit type
    /// </summary>
    [HttpPost]
    public IActionResult CreateCreditType([FromBody] CreditTypeRequest creditType)
    {
        try
        {
            var creditTypeModel = Service.CreateCreditType(Mapper.Map<CreditTypeModel>(creditType));
            var creditTypeResponce = Mapper.Map<CreditTypeResponse>(creditTypeModel);
            return Ok(creditTypeResponce);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    /// <summary>
    /// Delete credit type
    /// </summary>
    [HttpDelete]
    [Route("{id:Guid}")]
    public IActionResult DeleteCreditType([FromRoute] Guid id)
    {
        try
        {
            Service.DeleteCreditType(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    /// <summary>
    /// Get credit type
    /// </summary>
    [HttpGet]
    [Route("{id:Guid}")]
    public IActionResult GetCreditType([FromRoute] Guid id)
    {
        try
        {
            var credittypeModel = Service.GetCreditType(id);
            var credittypeResponse = Mapper.Map<CreditTypeResponse>(credittypeModel);
            return Ok(credittypeResponse);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    /// <summary>
    /// Get credit types
    /// </summary>
    [HttpGet]
    public IActionResult GetCreditTypes([FromQuery] int limit = 20, [FromQuery] int offset = 0)
    {
        var pageModel = Service.GetCreditTypes(limit, offset);
        var pageResponse = Mapper.Map<PageResponse<CreditTypeResponse>>(pageModel);
        return Ok(pageResponse);
    }

    /// <summary>
    /// Update credit type
    /// </summary>
    [HttpPut]
    [Route("{id:Guid}")]
    public IActionResult UpdateCreditType([FromRoute] Guid id, [FromBody] UpdateCreditTypeRequest credittypeRequest)
    {
        var validationResult = credittypeRequest.Validate();

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        try
        {
            var credittypeModel = Mapper.Map<UpdateCreditTypeModel>(credittypeRequest);
            var credittypeResult = Service.UpdateCreditType(id, credittypeModel);
            return Ok(credittypeResult);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }
}