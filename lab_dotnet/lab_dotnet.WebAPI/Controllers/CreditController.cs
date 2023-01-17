using AutoMapper;
using lab_dotnet.Services.Abstract;
using lab_dotnet.Services.Models;
using lab_dotnet.WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lab_dotnet.WebAPI.Controllers;

/// <summary>
/// Credit endpoints
/// </summary>
[ProducesResponseType(200)]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[Authorize]
public class CreditController : ControllerBase
{
    private readonly ICreditService Service;
    private readonly IMapper Mapper;

    /// <summary>
    /// Credit controller
    /// </summary>
    public CreditController(ICreditService service, IMapper mapper)
    {
        Service = service;
        Mapper = mapper;
    }

    /// <summary>
    /// Create credit
    /// </summary>
    [HttpPost]
    public IActionResult CreateCredit([FromBody] CreditRequest credit)
    {
        try
        {
            var creditModel = Service.CreateCredit(Mapper.Map<CreditModel>(credit));
            var creditResponce = Mapper.Map<CreditResponse>(creditModel);
            return Ok(creditResponce);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    /// <summary>
    /// Delete credit
    /// </summary>
    [HttpDelete]
    [Route("{id:Guid}")]
    public IActionResult DeleteCredit([FromRoute] Guid id)
    {
        try
        {
            Service.DeleteCredit(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    /// <summary>
    /// Get credit
    /// </summary>
    [HttpGet]
    [Route("{id:Guid}")]
    public IActionResult GetCredit([FromRoute] Guid id)
    {
        try
        {
            var creditModel = Service.GetCredit(id);
            var creditResponse = Mapper.Map<CreditResponse>(creditModel);
            return Ok(creditResponse);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    /// <summary>
    /// Get credits
    /// </summary>
    [HttpGet]
    public IActionResult GetCredits([FromQuery] int limit = 20, [FromQuery] int offset = 0)
    {
        var pageModel = Service.GetCredits(limit, offset);
        var pageResponse = Mapper.Map<PageResponse<CreditResponse>>(pageModel);
        return Ok(pageResponse);
    }

    /// <summary>
    /// Get credits by borrower id
    /// </summary>
    [HttpGet]
    [Route("BorrowerId/{borrowerId:Guid}")]
    public IActionResult GetCreditsByBorrowerId([FromRoute] Guid borrowerId, [FromQuery] int limit = 20, [FromQuery] int offset = 0)
    {
        var pageModel = Service.GetCreditsByBorrowerId(borrowerId, limit, offset);
        var pageResponse = Mapper.Map<PageResponse<CreditResponse>>(pageModel);
        return Ok(pageResponse);
    }

    /// <summary>
    /// Update credit
    /// </summary>
    [HttpPut]
    [Route("{id:Guid}")]
    public IActionResult UpdateCredit([FromRoute] Guid id, [FromBody] UpdateCreditRequest creditRequest)
    {
        var validationResult = creditRequest.Validate();

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        try
        {
            var creditModel = Mapper.Map<UpdateCreditModel>(creditRequest);
            var creditResult = Service.UpdateCredit(id, creditModel);
            return Ok(creditResult);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }
}