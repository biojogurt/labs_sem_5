using lab_dotnet.Services.Models;

namespace lab_dotnet.Services.Abstract;

public interface IPaymentService
{
    PaymentModel CreatePayment(PaymentModel paymentModel);

    PaymentModel GetPayment(Guid id);

    PaymentModel UpdatePayment(Guid id, UpdatePaymentModel payment);

    void DeletePayment(Guid id);

    PageModel<PaymentPreviewModel> GetPayments(int limit = 20, int offset = 0);

    PageModel<PaymentPreviewModel> GetPaymentsByCreditId(Guid creditId, int limit = 20, int offset = 0);
}