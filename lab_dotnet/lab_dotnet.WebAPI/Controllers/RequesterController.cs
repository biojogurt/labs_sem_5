using AutoMapper;
using lab_dotnet.Services.Abstract;
using lab_dotnet.Services.Models;
using lab_dotnet.WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lab_dotnet.WebAPI.Controllers;

/// <summary>
/// Requester endpoints
/// </summary>
[ProducesResponseType(200)]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[Authorize]
public class RequesterController : ControllerBase
{
    private readonly IRequesterService Service;
    private readonly IMapper Mapper;

    /// <summary>
    /// Requester controller
    /// </summary>
    public RequesterController(IRequesterService service, IMapper mapper)
    {
        Service = service;
        Mapper = mapper;
    }

    /// <summary>
    /// Create requester
    /// </summary>
    [HttpPost]
    public IActionResult CreateRequester([FromBody] RequesterRequest requester)
    {
        try
        {
            var requesterModel = Service.CreateRequester(Mapper.Map<RequesterModel>(requester));
            var requesterResponce = Mapper.Map<RequesterResponse>(requesterModel);
            return Ok(requesterResponce);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    /// <summary>
    /// Delete requester
    /// </summary>
    [HttpDelete]
    [Route("{id:Guid}")]
    public IActionResult DeleteRequester([FromRoute] Guid id)
    {
        try
        {
            Service.DeleteRequester(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    /// <summary>
    /// Get requester
    /// </summary>
    [HttpGet]
    [Route("{id:Guid}")]
    public IActionResult GetRequester([FromRoute] Guid id)
    {
        try
        {
            var requesterModel = Service.GetRequester(id);
            var requesterResponse = Mapper.Map<RequesterResponse>(requesterModel);
            return Ok(requesterResponse);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    /// <summary>
    /// Get requesters
    /// </summary>
    [HttpGet]
    public IActionResult GetRequesters([FromQuery] int limit = 20, [FromQuery] int offset = 0)
    {
        var pageModel = Service.GetRequesters(limit, offset);
        var pageResponse = Mapper.Map<PageResponse<RequesterResponse>>(pageModel);
        return Ok(pageResponse);
    }

    /// <summary>
    /// Update requester
    /// </summary>
    [HttpPut]
    [Route("{id:Guid}")]
    public IActionResult UpdateRequester([FromRoute] Guid id, [FromBody] UpdateRequesterRequest requesterRequest)
    {
        var validationResult = requesterRequest.Validate();

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        try
        {
            var requesterModel = Mapper.Map<UpdateRequesterModel>(requesterRequest);
            var requesterResult = Service.UpdateRequester(id, requesterModel);
            return Ok(requesterResult);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }
}