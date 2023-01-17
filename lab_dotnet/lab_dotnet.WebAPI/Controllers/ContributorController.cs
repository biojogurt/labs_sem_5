using AutoMapper;
using lab_dotnet.Services.Abstract;
using lab_dotnet.Services.Models;
using lab_dotnet.WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lab_dotnet.WebAPI.Controllers;

/// <summary>
/// Contributor endpoints
/// </summary>
[ProducesResponseType(200)]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[Authorize]
public class ContributorController : ControllerBase
{
    private readonly IContributorService Service;
    private readonly IMapper Mapper;

    /// <summary>
    /// Contributor controller
    /// </summary>
    public ContributorController(IContributorService service, IMapper mapper)
    {
        Service = service;
        Mapper = mapper;
    }

    /// <summary>
    /// Create contributor
    /// </summary>
    [HttpPost]
    public IActionResult CreateContributor([FromBody] ContributorRequest contributor)
    {
        try
        {
            var contributorModel = Service.CreateContributor(Mapper.Map<ContributorModel>(contributor));
            var contributorResponce = Mapper.Map<ContributorResponse>(contributorModel);
            return Ok(contributorResponce);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    /// <summary>
    /// Delete contributor
    /// </summary>
    [HttpDelete]
    [Route("{id:Guid}")]
    public IActionResult DeleteContributor([FromRoute] Guid id)
    {
        try
        {
            Service.DeleteContributor(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    /// <summary>
    /// Get contributor
    /// </summary>
    [HttpGet]
    [Route("{id:Guid}")]
    public IActionResult GetContributor([FromRoute] Guid id)
    {
        try
        {
            var contributorModel = Service.GetContributor(id);
            var contributorResponse = Mapper.Map<ContributorResponse>(contributorModel);
            return Ok(contributorResponse);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    /// <summary>
    /// Get contributors
    /// </summary>
    [HttpGet]
    public IActionResult GetContributors([FromQuery] int limit = 20, [FromQuery] int offset = 0)
    {
        var pageModel = Service.GetContributors(limit, offset);
        var pageResponse = Mapper.Map<PageResponse<ContributorResponse>>(pageModel);
        return Ok(pageResponse);
    }

    /// <summary>
    /// Update contributor
    /// </summary>
    [HttpPut]
    [Route("{id:Guid}")]
    public IActionResult UpdateContributor([FromRoute] Guid id, [FromBody] UpdateContributorRequest contributorRequest)
    {
        var validationResult = contributorRequest.Validate();

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        try
        {
            var contributorModel = Mapper.Map<UpdateContributorModel>(contributorRequest);
            var contributorResult = Service.UpdateContributor(id, contributorModel);
            return Ok(contributorResult);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }
}