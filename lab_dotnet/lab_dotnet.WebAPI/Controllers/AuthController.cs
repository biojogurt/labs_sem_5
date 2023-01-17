using AutoMapper;
using lab_dotnet.Entities.Models;
using lab_dotnet.Services.Abstract;
using lab_dotnet.Services.Models;
using lab_dotnet.WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lab_dotnet.WebAPI.Controllers;

/// <summary>
/// Auth endpoints
/// </summary>
[ProducesResponseType(200)]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService Service;
    private readonly IMapper Mapper;

    /// <summary>
    /// Auth controller
    /// </summary>
    public AuthController(IAuthService service, IMapper mapper)
    {
        Service = service;
        Mapper = mapper;
    }

    /// <summary>
    /// Register app user
    /// </summary>
    [HttpPost]
    public IActionResult RegisterUser([FromBody] RegisterUserRequest request)
    {
        var validationResult = request.Validate();

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        try
        {
            var appUserModel = Service.RegisterUser(Mapper.Map<RegisterUserModel>(request)).Result;
            var appUserResponce = Mapper.Map<AppUserResponse>(appUserModel);
            return Ok(appUserResponce);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    /// <summary>
    /// Login app user
    /// </summary>
    [HttpGet]
    public IActionResult LoginUser([FromBody] LoginUserRequest request)
    {
        var validationResult = request.Validate();

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        try
        {
            var tokenResponse = Service.LoginUser(Mapper.Map<LoginUserModel>(request)).Result;
            return Ok(tokenResponse);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }
}