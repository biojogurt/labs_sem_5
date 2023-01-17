using AutoMapper;
using lab_dotnet.Services.Abstract;
using lab_dotnet.Services.Models;
using lab_dotnet.WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lab_dotnet.WebAPI.Controllers;

/// <summary>
/// Request endpoints
/// </summary>
[ProducesResponseType(200)]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[Authorize]
public class RequestController : ControllerBase
{
    private readonly IRequestService Service;
    private readonly IMapper Mapper;

    /// <summary>
    /// Request controller
    /// </summary>
    public RequestController(IRequestService service, IMapper mapper)
    {
        Service = service;
        Mapper = mapper;
    }

    /// <summary>
    /// Create request
    /// </summary>
    [HttpPost]
    public IActionResult CreateRequest([FromBody] RequestRequest request)
    {
        try
        {
            var requestModel = Service.CreateRequest(Mapper.Map<RequestModel>(request));
            var requestResponce = Mapper.Map<RequestResponse>(requestModel);
            return Ok(requestResponce);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    /// <summary>
    /// Delete request
    /// </summary>
    [HttpDelete]
    [Route("{id:Guid}")]
    public IActionResult DeleteRequest([FromRoute] Guid id)
    {
        try
        {
            Service.DeleteRequest(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    /// <summary>
    /// Get request
    /// </summary>
    [HttpGet]
    [Route("{id:Guid}")]
    public IActionResult GetRequest([FromRoute] Guid id)
    {
        try
        {
            var requestModel = Service.GetRequest(id);
            var requestResponse = Mapper.Map<RequestResponse>(requestModel);
            return Ok(requestResponse);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    /// <summary>
    /// Get requests
    /// </summary>
    [HttpGet]
    public IActionResult GetRequests([FromQuery] int limit = 20, [FromQuery] int offset = 0)
    {
        var pageModel = Service.GetRequests(limit, offset);
        var pageResponse = Mapper.Map<PageResponse<RequestResponse>>(pageModel);
        return Ok(pageResponse);
    }

    /// <summary>
    /// Get requests by borrower id
    /// </summary>
    [HttpGet]
    [Route("BorrowerId/{borrowerid:Guid}")]
    public IActionResult GetRequestsByBorrowerId([FromRoute] Guid borrowerId, [FromQuery] int limit = 20, [FromQuery] int offset = 0)
    {
        var pageModel = Service.GetRequestsByBorrowerId(borrowerId, limit, offset);
        var pageResponse = Mapper.Map<PageResponse<RequestResponse>>(pageModel);
        return Ok(pageResponse);
    }

    /// <summary>
    /// Get requests by requester id
    /// </summary>
    [HttpGet]
    [Route("RequesterId/{requesterId:Guid}")]
    public IActionResult GetRequestsByRequesterId([FromRoute] Guid requesterId, [FromQuery] int limit = 20, [FromQuery] int offset = 0)
    {
        var pageModel = Service.GetRequestsByRequesterId(requesterId, limit, offset);
        var pageResponse = Mapper.Map<PageResponse<RequestResponse>>(pageModel);
        return Ok(pageResponse);
    }

    /// <summary>
    /// Update request
    /// </summary>
    [HttpPut]
    [Route("{id:Guid}")]
    public IActionResult UpdateRequest([FromRoute] Guid id, [FromBody] UpdateRequestRequest requestRequest)
    {
        var validationResult = requestRequest.Validate();

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        try
        {
            var requestModel = Mapper.Map<UpdateRequestModel>(requestRequest);
            var requestResult = Service.UpdateRequest(id, requestModel);
            return Ok(requestResult);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }
}