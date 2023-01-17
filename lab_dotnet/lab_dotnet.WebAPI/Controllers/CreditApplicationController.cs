using AutoMapper;
using lab_dotnet.Services.Abstract;
using lab_dotnet.Services.Models;
using lab_dotnet.WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lab_dotnet.WebAPI.Controllers;

/// <summary>
/// CreditApplication endpoints
/// </summary>
[ProducesResponseType(200)]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[Authorize]
public class CreditApplicationController : ControllerBase
{
    private readonly ICreditApplicationService Service;
    private readonly IMapper Mapper;

    /// <summary>
    /// CreditApplication controller
    /// </summary>
    public CreditApplicationController(ICreditApplicationService service, IMapper mapper)
    {
        Service = service;
        Mapper = mapper;
    }

    /// <summary>
    /// Create credit application
    /// </summary>
    [HttpPost]
    public IActionResult CreateCreditApplication([FromBody] CreditApplicationRequest creditApplication)
    {
        try
        {
            var creditApplicationModel = Service.CreateCreditApplication(Mapper.Map<CreditApplicationModel>(creditApplication));
            var creditApplicationResponce = Mapper.Map<CreditApplicationResponse>(creditApplicationModel);
            return Ok(creditApplicationResponce);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    /// <summary>
    /// Delete credit application
    /// </summary>
    [HttpDelete]
    [Route("{id:Guid}")]
    public IActionResult DeleteCreditApplication([FromRoute] Guid id)
    {
        try
        {
            Service.DeleteCreditApplication(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    /// <summary>
    /// Get credit application
    /// </summary>
    [HttpGet]
    [Route("{id:Guid}")]
    public IActionResult GetCreditApplication([FromRoute] Guid id)
    {
        try
        {
            var creditapplicationModel = Service.GetCreditApplication(id);
            var creditapplicationResponse = Mapper.Map<CreditApplicationResponse>(creditapplicationModel);
            return Ok(creditapplicationResponse);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    /// <summary>
    /// Get credit applications
    /// </summary>
    [HttpGet]
    public IActionResult GetCreditApplications([FromQuery] int limit = 20, [FromQuery] int offset = 0)
    {
        var pageModel = Service.GetCreditApplications(limit, offset);
        var pageResponse = Mapper.Map<PageResponse<CreditApplicationResponse>>(pageModel);
        return Ok(pageResponse);
    }

    /// <summary>
    /// Get credit applications by borrower id
    /// </summary>
    [HttpGet]
    [Route("BorrowerId/{borrowerId:Guid}")]
    public IActionResult GetCreditApplicationsByBorrowerId([FromRoute] Guid borrowerId, [FromQuery] int limit = 20, [FromQuery] int offset = 0)
    {
        var pageModel = Service.GetCreditApplicationsByBorrowerId(borrowerId, limit, offset);
        var pageResponse = Mapper.Map<PageResponse<CreditApplicationResponse>>(pageModel);
        return Ok(pageResponse);
    }

    /// <summary>
    /// Get credit applications by credit type id
    /// </summary>
    [HttpGet]
    [Route("CreditTypeId/{creditTypeId:Guid}")]
    public IActionResult GetCreditApplicationsByCreditTypeId([FromRoute] Guid creditTypeId, [FromQuery] int limit = 20, [FromQuery] int offset = 0)
    {
        var pageModel = Service.GetCreditApplicationsByCreditTypeId(creditTypeId, limit, offset);
        var pageResponse = Mapper.Map<PageResponse<CreditApplicationResponse>>(pageModel);
        return Ok(pageResponse);
    }

    /// <summary>
    /// Get credit applications by creditor id
    /// </summary>
    [HttpGet]
    [Route("CreditorId/{creditorId:Guid}")]
    public IActionResult GetCreditApplicationsByCreditorId([FromRoute] Guid creditorId, [FromQuery] int limit = 20, [FromQuery] int offset = 0)
    {
        var pageModel = Service.GetCreditApplicationsByCreditorId(creditorId, limit, offset);
        var pageResponse = Mapper.Map<PageResponse<CreditApplicationResponse>>(pageModel);
        return Ok(pageResponse);
    }

    /// <summary>
    /// Update credit application
    /// </summary>
    [HttpPut]
    [Route("{id:Guid}")]
    public IActionResult UpdateCreditApplication([FromRoute] Guid id, [FromBody] UpdateCreditApplicationRequest creditapplicationRequest)
    {
        var validationResult = creditapplicationRequest.Validate();

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        try
        {
            var creditapplicationModel = Mapper.Map<UpdateCreditApplicationModel>(creditapplicationRequest);
            var creditapplicationResult = Service.UpdateCreditApplication(id, creditapplicationModel);
            return Ok(creditapplicationResult);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }
}