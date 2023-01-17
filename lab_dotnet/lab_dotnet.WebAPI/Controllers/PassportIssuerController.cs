using AutoMapper;
using lab_dotnet.Services.Abstract;
using lab_dotnet.Services.Models;
using lab_dotnet.WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lab_dotnet.WebAPI.Controllers;

/// <summary>
/// PassportIssuer endpoints
/// </summary>
[ProducesResponseType(200)]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[Authorize]
public class PassportIssuerController : ControllerBase
{
    private readonly IPassportIssuerService Service;
    private readonly IMapper Mapper;

    /// <summary>
    /// PassportIssuer controller
    /// </summary>
    public PassportIssuerController(IPassportIssuerService service, IMapper mapper)
    {
        Service = service;
        Mapper = mapper;
    }

    /// <summary>
    /// Create passport issuer
    /// </summary>
    [HttpPost]
    public IActionResult CreatePassportIssuer([FromBody] PassportIssuerRequest passportIssuer)
    {
        try
        {
            var passportIssuerModel = Service.CreatePassportIssuer(Mapper.Map<PassportIssuerModel>(passportIssuer));
            var passportIssuerResponce = Mapper.Map<PassportIssuerResponse>(passportIssuerModel);
            return Ok(passportIssuerResponce);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    /// <summary>
    /// Delete passport issuer
    /// </summary>
    [HttpDelete]
    [Route("{id:Guid}")]
    public IActionResult DeletePassportIssuer([FromRoute] Guid id)
    {
        try
        {
            Service.DeletePassportIssuer(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    /// <summary>
    /// Get passport issuer
    /// </summary>
    [HttpGet]
    [Route("{id:Guid}")]
    public IActionResult GetPassportIssuer([FromRoute] Guid id)
    {
        try
        {
            var passportissuerModel = Service.GetPassportIssuer(id);
            var passportissuerResponse = Mapper.Map<PassportIssuerResponse>(passportissuerModel);
            return Ok(passportissuerResponse);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    /// <summary>
    /// Get passport issuers
    /// </summary>
    [HttpGet]
    public IActionResult GetPassportIssuers([FromQuery] int limit = 20, [FromQuery] int offset = 0)
    {
        var pageModel = Service.GetPassportIssuers(limit, offset);
        var pageResponse = Mapper.Map<PageResponse<PassportIssuerResponse>>(pageModel);
        return Ok(pageResponse);
    }

    /// <summary>
    /// Update passport issuer
    /// </summary>
    [HttpPut]
    [Route("{id:Guid}")]
    public IActionResult UpdatePassportIssuer([FromRoute] Guid id, [FromBody] UpdatePassportIssuerRequest passportissuerRequest)
    {
        var validationResult = passportissuerRequest.Validate();

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        try
        {
            var passportissuerModel = Mapper.Map<UpdatePassportIssuerModel>(passportissuerRequest);
            var passportissuerResult = Service.UpdatePassportIssuer(id, passportissuerModel);
            return Ok(passportissuerResult);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }
}