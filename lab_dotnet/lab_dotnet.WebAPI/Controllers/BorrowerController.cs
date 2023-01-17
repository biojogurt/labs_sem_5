using AutoMapper;
using lab_dotnet.Services.Abstract;
using lab_dotnet.Services.Models;
using lab_dotnet.WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lab_dotnet.WebAPI.Controllers;

/// <summary>
/// Borrowers endpoints
/// </summary>
[ProducesResponseType(200)]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[Authorize]
public class BorrowerController : ControllerBase
{
    private readonly IBorrowerService Service;
    private readonly IMapper Mapper;

    /// <summary>
    /// Borrowers controller
    /// </summary>
    public BorrowerController(IBorrowerService service, IMapper mapper)
    {
        Service = service;
        Mapper = mapper;
    }

    /// <summary>
    /// Create borrower
    /// </summary>
    [HttpPost]
    public IActionResult CreateBorrower([FromBody] BorrowerRequest borrower)
    {
        try
        {
            var borrowerModel = Service.CreateBorrower(Mapper.Map<BorrowerModel>(borrower));
            var borrowerResponce = Mapper.Map<BorrowerResponse>(borrowerModel);
            return Ok(borrowerResponce);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    /// <summary>
    /// Delete borrower
    /// </summary>
    [HttpDelete]
    [Route("{id:Guid}")]
    public IActionResult DeleteBorrower([FromRoute] Guid id)
    {
        try
        {
            Service.DeleteBorrower(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    /// <summary>
    /// Get borrower by id
    /// </summary>
    [HttpGet]
    [Route("{id:Guid}")]
    public IActionResult GetBorrowerById([FromRoute] Guid id)
    {
        try
        {
            var borrowerModel = Service.GetBorrowerById(id);
            var borrowerResponse = Mapper.Map<BorrowerResponse>(borrowerModel);
            return Ok(borrowerResponse);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    /// <summary>
    /// Get borrower by passport
    /// </summary>
    [HttpGet]
    [Route("GetByPassport")]
    public IActionResult GetBorrowerByPassport([FromBody] PassportRequest passport)
    {
        try
        {
            var passportModel = Mapper.Map<PassportModel>(passport);
            var borrowerModel = Service.GetBorrowerByPassport(passportModel);
            var borrowerResponse = Mapper.Map<BorrowerResponse>(borrowerModel);
            return Ok(borrowerResponse);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    /// <summary>
    /// Get borrowers
    /// </summary>
    [HttpGet]
    public IActionResult GetBorrowers([FromQuery] int limit = 20, [FromQuery] int offset = 0)
    {
        var pageModel = Service.GetBorrowers(limit, offset);
        var pageResponse = Mapper.Map<PageResponse<BorrowerResponse>>(pageModel);
        return Ok(pageResponse);
    }

    /// <summary>
    /// Update borrower
    /// </summary>
    [HttpPut]
    [Route("{id:Guid}")]
    public IActionResult UpdateBorrower([FromRoute] Guid id, [FromBody] UpdateBorrowerRequest borrowerRequest)
    {
        var validationResult = borrowerRequest.Validate();

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        try
        {
            var borrowerModel = Mapper.Map<UpdateBorrowerModel>(borrowerRequest);
            var borrowerResult = Service.UpdateBorrower(id, borrowerModel);
            return Ok(borrowerResult);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }
}