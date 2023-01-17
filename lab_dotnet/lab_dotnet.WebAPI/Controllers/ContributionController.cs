using AutoMapper;
using lab_dotnet.Services.Abstract;
using lab_dotnet.Services.Models;
using lab_dotnet.WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lab_dotnet.WebAPI.Controllers;

/// <summary>
/// Contribution endpoints
/// </summary>
[ProducesResponseType(200)]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[Authorize]
public class ContributionController : ControllerBase
{
    private readonly IContributionService Service;
    private readonly IMapper Mapper;

    /// <summary>
    /// Contribution controller
    /// </summary>
    public ContributionController(IContributionService service, IMapper mapper)
    {
        Service = service;
        Mapper = mapper;
    }

    /// <summary>
    /// Create contribution
    /// </summary>
    [HttpPost]
    public IActionResult CreateContribution([FromBody] ContributionRequest contribution)
    {
        try
        {
            var contributionModel = Service.CreateContribution(Mapper.Map<ContributionModel>(contribution));
            var contributionResponce = Mapper.Map<ContributionResponse>(contributionModel);
            return Ok(contributionResponce);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    /// <summary>
    /// Delete contribution
    /// </summary>
    [HttpDelete]
    [Route("{id:Guid}")]
    public IActionResult DeleteContribution([FromRoute] Guid id)
    {
        try
        {
            Service.DeleteContribution(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    /// <summary>
    /// Get contribution
    /// </summary>
    [HttpGet]
    [Route("{id:Guid}")]
    public IActionResult GetContribution([FromRoute] Guid id)
    {
        try
        {
            var contributionModel = Service.GetContribution(id);
            var contributionResponse = Mapper.Map<ContributionResponse>(contributionModel);
            return Ok(contributionResponse);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    /// <summary>
    /// Get contributions
    /// </summary>
    [HttpGet]
    public IActionResult GetContributions([FromQuery] int limit = 20, [FromQuery] int offset = 0)
    {
        var pageModel = Service.GetContributions(limit, offset);
        var pageResponse = Mapper.Map<PageResponse<ContributionResponse>>(pageModel);
        return Ok(pageResponse);
    }

    /// <summary>
    /// Get contributions by borrower id
    /// </summary>
    [HttpGet]
    [Route("BorrowerId/{borrowerid:Guid}")]
    public IActionResult GetContributionsByBorrowerId([FromRoute] Guid borrowerId, [FromQuery] int limit = 20, [FromQuery] int offset = 0)
    {
        var pageModel = Service.GetContributionsByBorrowerId(borrowerId, limit, offset);
        var pageResponse = Mapper.Map<PageResponse<ContributionResponse>>(pageModel);
        return Ok(pageResponse);
    }

    /// <summary>
    /// Get contributions by contributor id
    /// </summary>
    [HttpGet]
    [Route("ContributorId/{contributorId:Guid}")]
    public IActionResult GetContributionsByContributorId([FromRoute] Guid contributorId, [FromQuery] int limit = 20, [FromQuery] int offset = 0)
    {
        var pageModel = Service.GetContributionsByContributorId(contributorId, limit, offset);
        var pageResponse = Mapper.Map<PageResponse<ContributionResponse>>(pageModel);
        return Ok(pageResponse);
    }

    /// <summary>
    /// Update contribution
    /// </summary>
    [HttpPut]
    [Route("{id:Guid}")]
    public IActionResult UpdateContribution([FromRoute] Guid id, [FromBody] UpdateContributionRequest contributionRequest)
    {
        var validationResult = contributionRequest.Validate();

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        try
        {
            var contributionModel = Mapper.Map<UpdateContributionModel>(contributionRequest);
            var contributionResult = Service.UpdateContribution(id, contributionModel);
            return Ok(contributionResult);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }
}