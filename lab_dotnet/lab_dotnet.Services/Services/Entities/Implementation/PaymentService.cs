using AutoMapper;
using lab_dotnet.Entities.Models;
using lab_dotnet.Repository;
using lab_dotnet.Services.Abstract;
using lab_dotnet.Services.Models;
using Microsoft.Extensions.Logging;

namespace lab_dotnet.Services.Implementation;

public class PaymentService : IPaymentService
{
    private readonly IPageService<Payment, PaymentPreviewModel> PageService;
    private readonly IRepository<Payment> RepositoryPayment;
    private readonly IRepository<Credit> RepositoryCredit;
    private readonly IMapper Mapper;
    private readonly ILogger<PaymentService> Logger;

    public PaymentService(IPageService<Payment, PaymentPreviewModel> pageService,
                          IRepository<Payment> repositoryPayment,
                          IRepository<Credit> repositoryCredit,
                          IMapper mapper,
                          ILogger<PaymentService> logger)
    {
        PageService = pageService;
        RepositoryPayment = repositoryPayment;
        RepositoryCredit = repositoryCredit;
        Mapper = mapper;
        Logger = logger;
    }

    public PaymentModel CreatePayment(PaymentModel paymentModel)
    {
        var existingCredit = RepositoryCredit.GetById(paymentModel.CreditId);
        if (existingCredit == null)
        {
            Exception ex = new Exception("No such credit");
            Logger.LogError(ex.ToString());
            throw ex;
        }

        Payment payment = Mapper.Map<Payment>(paymentModel);
        RepositoryPayment.Save(payment);
        return Mapper.Map<PaymentModel>(payment);
    }

    public void DeletePayment(Guid id)
    {
        var payment = RepositoryPayment.GetById(id);
        if (payment == null)
        {
            Exception ex = new Exception("Payment not found");
            Logger.LogError(ex.ToString());
            throw ex;
        }

        RepositoryPayment.Delete(payment);
    }

    public PaymentModel GetPayment(Guid id)
    {
        var payment = RepositoryPayment.GetById(id);
        if (payment == null)
        {
            Exception ex = new Exception("Payment not found");
            Logger.LogError(ex.ToString());
            throw ex;
        }

        return Mapper.Map<PaymentModel>(payment);
    }

    public PageModel<PaymentPreviewModel> GetPayments(int limit = 20, int offset = 0)
    {
        var payment = RepositoryPayment.GetAll();
        return PageService.CreatePage(payment, limit, offset, x => x.PaymentDate);
    }

    public PageModel<PaymentPreviewModel> GetPaymentsByCreditId(Guid creditId, int limit, int offset)
    {
        var payment = RepositoryPayment.GetAll(x => x.CreditId == creditId);
        return PageService.CreatePage(payment, limit, offset, x => x.PaymentDate);
    }

    public PaymentModel UpdatePayment(Guid id, UpdatePaymentModel payment)
    {
        var existingPayment = RepositoryPayment.GetById(id);
        if (existingPayment == null)
        {
            Exception ex = new Exception("Payment not found");
            Logger.LogError(ex.ToString());
            throw ex;
        }

        if (payment.CreditId != null)
        {
            existingPayment.CreditId = (Guid)payment.CreditId;
        }

        if (payment.PaymentDate != null)
        {
            existingPayment.PaymentDate = (DateTime)payment.PaymentDate;
        }

        if (payment.PaymentAmount != null)
        {
            existingPayment.PaymentAmount = (int)payment.PaymentAmount;
        }

        if (payment.RemainingAmount != null)
        {
            existingPayment.RemainingAmount = (int)payment.RemainingAmount;
        }

        if (payment.Debt != null)
        {
            existingPayment.Debt = (int)payment.Debt;
        }

        existingPayment = RepositoryPayment.Save(existingPayment);
        return Mapper.Map<PaymentModel>(existingPayment);
    }
}