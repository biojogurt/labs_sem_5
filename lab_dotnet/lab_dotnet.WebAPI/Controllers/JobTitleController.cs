using AutoMapper;
using lab_dotnet.Services.Abstract;
using lab_dotnet.Services.Models;
using lab_dotnet.WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lab_dotnet.WebAPI.Controllers;

/// <summary>
/// JobTitle endpoints
/// </summary>
[ProducesResponseType(200)]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[Authorize]
public class JobTitleController : ControllerBase
{
    private readonly IJobTitleService Service;
    private readonly IMapper Mapper;

    /// <summary>
    /// JobTitle controller
    /// </summary>
    public JobTitleController(IJobTitleService service, IMapper mapper)
    {
        Service = service;
        Mapper = mapper;
    }

    /// <summary>
    /// Create job title
    /// </summary>
    [HttpPost]
    public IActionResult CreateJobTitle([FromBody] JobTitleRequest jobTitle)
    {
        try
        {
            var jobTitleModel = Service.CreateJobTitle(Mapper.Map<JobTitleModel>(jobTitle));
            var jobTitleResponce = Mapper.Map<JobTitleResponse>(jobTitleModel);
            return Ok(jobTitleResponce);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    /// <summary>
    /// Delete job title
    /// </summary>
    [HttpDelete]
    [Route("{id:Guid}")]
    public IActionResult DeleteJobTitle([FromRoute] Guid id)
    {
        try
        {
            Service.DeleteJobTitle(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    /// <summary>
    /// Get job title
    /// </summary>
    [HttpGet]
    [Route("{id:Guid}")]
    public IActionResult GetJobTitle([FromRoute] Guid id)
    {
        try
        {
            var jobtitleModel = Service.GetJobTitle(id);
            var jobtitleResponse = Mapper.Map<JobTitleResponse>(jobtitleModel);
            return Ok(jobtitleResponse);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    /// <summary>
    /// Get job titles
    /// </summary>
    [HttpGet]
    public IActionResult GetJobTitles([FromQuery] int limit = 20, [FromQuery] int offset = 0)
    {
        var pageModel = Service.GetJobTitles(limit, offset);
        var pageResponse = Mapper.Map<PageResponse<JobTitleResponse>>(pageModel);
        return Ok(pageResponse);
    }

    /// <summary>
    /// Update job title
    /// </summary>
    [HttpPut]
    [Route("{id:Guid}")]
    public IActionResult UpdateJobTitle([FromRoute] Guid id, [FromBody] UpdateJobTitleRequest jobtitleRequest)
    {
        var validationResult = jobtitleRequest.Validate();

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        try
        {
            var jobtitleModel = Mapper.Map<UpdateJobTitleModel>(jobtitleRequest);
            var jobtitleResult = Service.UpdateJobTitle(id, jobtitleModel);
            return Ok(jobtitleResult);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }
}