using AutoMapper;
using lab_dotnet.Services.Abstract;
using lab_dotnet.Services.Models;
using lab_dotnet.WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lab_dotnet.WebAPI.Controllers;

/// <summary>
/// AppUser endpoints
/// </summary>
[ProducesResponseType(200)]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[Authorize]
public class AppUserController : ControllerBase
{
    private readonly IAppUserService Service;
    private readonly IMapper Mapper;

    /// <summary>
    /// AppUser controller
    /// </summary>
    public AppUserController(IAppUserService service, IMapper mapper)
    {
        Service = service;
        Mapper = mapper;
    }

    /// <summary>
    /// Delete app user
    /// </summary>
    [HttpDelete]
    [Route("{id:Guid}")]
    public IActionResult DeleteAppUser([FromRoute] Guid id)
    {
        try
        {
            Service.DeleteAppUser(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    /// <summary>
    /// Get app user
    /// </summary>
    [HttpGet]
    [Route("{id:Guid}")]
    public IActionResult GetAppUser([FromRoute] Guid id)
    {
        try
        {
            var appuserModel = Service.GetAppUser(id);
            var appuserResponse = Mapper.Map<AppUserResponse>(appuserModel);
            return Ok(appuserResponse);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    /// <summary>
    /// Get app users
    /// </summary>
    [HttpGet]
    public IActionResult GetAppUsers([FromQuery] int limit = 20, [FromQuery] int offset = 0)
    {
        var pageModel = Service.GetAppUsers(limit, offset);
        var pageResponse = Mapper.Map<PageResponse<AppUserResponse>>(pageModel);
        return Ok(pageResponse);
    }

    /// <summary>
    /// Get app users by access level
    /// </summary>
    [HttpGet]
    [Route("AccessLevel/{accessLevel:int}")]
    public IActionResult GetAppUsersByAccessLevel([FromRoute] int accessLevel, [FromQuery] int limit = 20, [FromQuery] int offset = 0)
    {
        var pageModel = Service.GetAppUsersByAccessLevel(accessLevel, limit, offset);
        var pageResponse = Mapper.Map<PageResponse<AppUserResponse>>(pageModel);
        return Ok(pageResponse);
    }

    /// <summary>
    /// Get app users by job title id
    /// </summary>
    [HttpGet]
    [Route("JobTitleId/{jobTitleId:Guid}")]
    public IActionResult GetAppUsersByJobTitleId([FromRoute] Guid jobTitleId, [FromQuery] int limit = 20, [FromQuery] int offset = 0)
    {
        var pageModel = Service.GetAppUsersByJobTitleId(jobTitleId, limit, offset);
        var pageResponse = Mapper.Map<PageResponse<AppUserResponse>>(pageModel);
        return Ok(pageResponse);
    }

    /// <summary>
    /// Update app user
    /// </summary>
    [HttpPut]
    [Route("{id:Guid}")]
    public IActionResult UpdateAppUser([FromRoute] Guid id, [FromBody] UpdateAppUserRequest appuserRequest)
    {
        var validationResult = appuserRequest.Validate();

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        try
        {
            var appuserModel = Mapper.Map<UpdateAppUserModel>(appuserRequest);
            var appuserResult = Service.UpdateAppUser(id, appuserModel);
            return Ok(appuserResult);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }
}