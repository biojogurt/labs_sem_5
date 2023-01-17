using AutoMapper;
using lab_dotnet.Services.Abstract;
using lab_dotnet.Services.Models;
using lab_dotnet.WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lab_dotnet.WebAPI.Controllers;

/// <summary>
/// Payment endpoints
/// </summary>
[ProducesResponseType(200)]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[Authorize]
public class PaymentController : ControllerBase
{
    private readonly IPaymentService Service;
    private readonly IMapper Mapper;

    /// <summary>
    /// Payment controller
    /// </summary>
    public PaymentController(IPaymentService service, IMapper mapper)
    {
        Service = service;
        Mapper = mapper;
    }

    /// <summary>
    /// Create payment
    /// </summary>
    [HttpPost]
    public IActionResult CreatePayment([FromBody] PaymentRequest payment)
    {
        try
        {
            var paymentModel = Service.CreatePayment(Mapper.Map<PaymentModel>(payment));
            var paymentResponce = Mapper.Map<PaymentResponse>(paymentModel);
            return Ok(paymentResponce);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    /// <summary>
    /// Delete payment
    /// </summary>
    [HttpDelete]
    [Route("{id:Guid}")]
    public IActionResult DeletePayment([FromRoute] Guid id)
    {
        try
        {
            Service.DeletePayment(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    /// <summary>
    /// Get payment
    /// </summary>
    [HttpGet]
    [Route("{id:Guid}")]
    public IActionResult GetPayment([FromRoute] Guid id)
    {
        try
        {
            var paymentModel = Service.GetPayment(id);
            var paymentResponse = Mapper.Map<PaymentResponse>(paymentModel);
            return Ok(paymentResponse);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    /// <summary>
    /// Get payments
    /// </summary>
    [HttpGet]
    public IActionResult GetPayments([FromQuery] int limit = 20, [FromQuery] int offset = 0)
    {
        var pageModel = Service.GetPayments(limit, offset);
        var pageResponse = Mapper.Map<PageResponse<PaymentResponse>>(pageModel);
        return Ok(pageResponse);
    }

    /// <summary>
    /// Get payments by credit id
    /// </summary>
    [HttpGet]
    [Route("CreditId/{creditId:Guid}")]
    public IActionResult GetPaymentsByCreditId([FromRoute] Guid creditId, [FromQuery] int limit = 20, [FromQuery] int offset = 0)
    {
        var pageModel = Service.GetPaymentsByCreditId(creditId, limit, offset);
        var pageResponse = Mapper.Map<PageResponse<PaymentResponse>>(pageModel);
        return Ok(pageResponse);
    }

    /// <summary>
    /// Update payment
    /// </summary>
    [HttpPut]
    [Route("{id:Guid}")]
    public IActionResult UpdatePayment([FromRoute] Guid id, [FromBody] UpdatePaymentRequest paymentRequest)
    {
        var validationResult = paymentRequest.Validate();

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        try
        {
            var paymentModel = Mapper.Map<UpdatePaymentModel>(paymentRequest);
            var paymentResult = Service.UpdatePayment(id, paymentModel);
            return Ok(paymentResult);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }
}